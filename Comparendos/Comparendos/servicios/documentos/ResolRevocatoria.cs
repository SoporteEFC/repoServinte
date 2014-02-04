using System;
using TransitoPrincipal;
using LibreriasSintrat.utilidades;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibreriasSintrat.ServiciosAccesoriasComp;
using LibreriasSintrat.ServiciosGeneralesComp;
using LibreriasSintrat.ServiciosDocumentos;
using LibreriasSintrat.ServiciosUsuarios;
using LibreriasSintrat.ServiciosConfiguraciones;
using LibreriasSintrat.ServiciosGenerales;
using Word = Microsoft.Office.Interop.Word;
using Comparendos.utilidades;
using LibreriasSintrat;


namespace Comparendos.servicios.documentos
{
    public partial class ResolRevocatoria : Form
    {

        private usuarios myUsuario;

        private infractorComp myInfractor;
        private Object[] myComparendos;

        private int numResolucion;

        private plantilla myPlantilla;
        private tipoResolucionComp myTipoResolucion;

        Funciones funciones;
        Boolean bandera;

        ServiciosGeneralesService serviciosGenerales;
        ServiciosDocumentosService serviciosDocumentos;
        ServiciosGeneralesCompService serviciosGeneralesComp;
        ServiciosConfiguracionesService serviciosConfiguraciones;

        Log log = new Log();

        public ResolRevocatoria(usuarios user)
        {
            InitializeComponent();

            serviciosGenerales = WS.ServiciosGeneralesService();
            serviciosDocumentos = WS.ServiciosDocumentosService();
            serviciosGeneralesComp = WS.ServiciosGeneralesCompService();
            serviciosConfiguraciones = WS.ServiciosConfiguracionesService();

            funciones = new Funciones();
            bandera = true;

            myUsuario = user;
            numResolucion = -1; 
        }

        private void ResolRevocatoria_Load_1(object sender, EventArgs e)
        {
            try
            {
                btnGenerarResolucion.Enabled = false;
                cargarCombos();
                cmbBoxTipoDoc.SelectedIndex = 0;
                txtDocumento.Focus();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
            }
        }

        /* REQUIERE UN CAMBIO */
        public void cargarCombos()
        {
            ServiciosAccesoriasCompService serviciosAccesoriasComp = WS.ServiciosAccesoriasCompService();
            Object[] arreglo;

            // Carga en el combo box los tipos de documentos de identificación
            arreglo = (Object[])serviciosAccesoriasComp.obtenerTiposDocumento();
            funciones.llenarCombo(cmbBoxTipoDoc, arreglo);

            // Carga en el combo box de plantillas las plantillas asociadas al tipo de resolución 4-> estado resolución
            plantilla myTmpPlantilla = new plantilla();
            myTmpPlantilla.IDTIPORESOLUCION = 10; //REVOCATORIA DIRECTA
            arreglo = (Object[])serviciosDocumentos.buscarPlantillasComp(myTmpPlantilla); //En la base de datos se debe agregar la plantilla para revocatoria
            funciones.llenarCombo(cmbBoxPlantillas, arreglo);

            cmbBoxPlantillas.SelectedIndex = -1;
        }

        public void buscarInfractor()
        {
            myInfractor = new infractorComp();

            myInfractor.ID_DOCTO = (int)cmbBoxTipoDoc.SelectedValue;
            myInfractor.NROIDENTIFICACION = txtDocumento.Text;

            myInfractor = serviciosGeneralesComp.buscarInfractor(myInfractor);

            if (myInfractor != null && myInfractor.ID_INFRACTOR >= 0)
            {
                mostrarInfoInfractor();
                cargarComparendosInfractor();
                dtGrViewComparendos.Focus();
            }
            else
                MessageBox.Show("Verifique la informacion ingresada!!!", "Infractor no encontrado");
        }

        /* REQUIERE UN CAMBIO */
        public void cargarComparendosInfractor()
        {
            limpiarComparendos();

            String filtroEstados;
            String[] estados;
            Object[] tmpComparendos;

            viewComparendosResolSancionComp myCompResoSanc = new viewComparendosResolSancionComp();
            myCompResoSanc.ID_INFRACTOR = myInfractor.ID_INFRACTOR;

            //filtroEstados = serviciosGeneralesComp.obtenerEstadosResolExoneracion(); //cambiar por obtener estados resolución revocatoria

            filtroEstados = "4"; //En estado resolucion

            if (!string.IsNullOrEmpty(filtroEstados))
            {
                estados = filtroEstados.Split(',');

                for (int i = 0; i < estados.Length; i++)
                {
                    myCompResoSanc.ID_ESTADO = int.Parse(estados[i]);

                    tmpComparendos = (Object[])serviciosGeneralesComp.obtenerComparendosResolSancion(myCompResoSanc);
                    myComparendos = funciones.unirArrayObject(myComparendos, tmpComparendos);
                }

                if (myComparendos != null && myComparendos.Length > 0)
                {
                    mostrarComparendos();
                    bandera = true;
                }
                else
                {
                    if (bandera != false)
                        MessageBox.Show("El infractor no presenta comparendos", "Información no encontrada");
                    bandera = true;
                }
            }
            else
            {
                MessageBox.Show("Debe configurar los estados de resolución de sanción en la base de datos.", "Información no encontrada");
            }
        }

        public void mostrarInfoInfractor()
        {
            txtInfractor.Text = myInfractor.NOMBRES + " " + myInfractor.APELLIDOS;
            txtDireccion.Text = myInfractor.DIRECCION;
            txtTelefono.Text = myInfractor.TELEFONO;
        }

        public void mostrarComparendos()
        {
            DataTable dt = new DataTable();
            ArrayList campos = new ArrayList();

            campos.Add("NUMEROCOMPARENDO = NUMEROCOMPARENDO");
            campos.Add("FECHACOMPARENDO = FECHACOMPARENDO");
            campos.Add("NUEVO_CODIGO = NUEVO_CODIGO");
            campos.Add("ESTADO = ESTADO");
            campos.Add("PLACA = PLACA");
            campos.Add("DESCRIPCION = DESCRIPCION");
            campos.Add("COD_INFRACCION = COD_INFRACCION");

            campos.Add("ID = ID");
            campos.Add("ID_COMPARENDO = ID_COMPARENDO");
            campos.Add("ID_ESTADO = ID_ESTADO");
            campos.Add("ID_INFRACTOR = ID_INFRACTOR");
            campos.Add("ID_SERVICIO = ID_SERVICIO");
            campos.Add("IDINFRACCION = IDINFRACCION");

            dt = funciones.ToDataTableEnOrden(funciones.ObjectToArrayList(myComparendos), campos);
            dtGrViewComparendos.DataSource = dt;

            if (dt != null && dt.Rows.Count > 0)
            {
                funciones.configurarGrilla(dtGrViewComparendos, campos);

                //Ocultar campos
                dtGrViewComparendos.Columns["ID"].Visible = false;
                dtGrViewComparendos.Columns["ID_COMPARENDO"].Visible = false;
                dtGrViewComparendos.Columns["ID_ESTADO"].Visible = false;
                dtGrViewComparendos.Columns["ID_INFRACTOR"].Visible = false;
                dtGrViewComparendos.Columns["ID_SERVICIO"].Visible = false;
                dtGrViewComparendos.Columns["IDINFRACCION"].Visible = false;
            }
        }

        public void limpiarComparendos()
        {
            dtGrViewComparendos.DataSource = null;
            myComparendos = null;
        }

        private bool validarDatos()
        {
            if (cmbBoxPlantillas.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar una plantilla.");
                cmbBoxPlantillas.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtNumResol.Text))
            {
                MessageBox.Show("El campo número de resolución es obligatorio.");
                txtNumResol.Focus();
                return false;
            }

            return true;
        }


        #region eventos
        /* Modificada */
        private void btnGenerarResolucion_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                String nombreResolucion;
                if (validarDatos())
                {
                    if (dtGrViewComparendos.SelectedCells.Count > 0)
                    {
                        numResolucion = int.Parse(txtNumResol.Text);
                        nombreResolucion = ""; 

                        DataGridViewSelectedRowCollection comparendosSeleccionados = dtGrViewComparendos.SelectedRows;

                        int totalComparendos = comparendosSeleccionados.Count;
                        int countResolucionesGeneradas = 0;

                        bool abrirArchivo = true;
                        if (totalComparendos > 1)
                            abrirArchivo = false;

                        for (int i = 0; i < totalComparendos; i++)
                        {
                            viewComparendosResolSancionComp infoComparendo = (viewComparendosResolSancionComp)funciones.listToViewCompResolSanc(comparendosSeleccionados[i]);
                            resolucionesComparendoComp myResolucionComparendo = new resolucionesComparendoComp();

                            GenerarResoluciones generarResolucion = new GenerarResoluciones();

                            string fechaResolucion = funciones.convFormatoFecha(dtPickFechaResolucion.Text, "MM/dd/yyyy");

                            myResolucionComparendo.IDUSUARIO = myUsuario.ID_USUARIO;
                            myResolucionComparendo.FECHAAUDIENCIA = funciones.convFormatoFecha(dtPickFechaAudiencia.Text, "MM/dd/yyyy");
                            myResolucionComparendo.FECHA = fechaResolucion;
                            //myResolucionComparendo.MOTIVO = txtMotivo.Text;
                            //myResolucionComparendo.CONSIDERACIONJURIDICA = txtConsidJurid.Text;
                            
                            myResolucionComparendo.MOTIVORESOLUCION = txtMotivoRevocatoria.Text;
                            myResolucionComparendo.HECHOS = txtHechosRevocatoria.Text;
                            myResolucionComparendo.SOLICITUDRESOLUCION = txtSolicitudRevocatoria.Text;

                            myResolucionComparendo.ID_TIPORESOLUCION = myPlantilla.IDTIPORESOLUCION;

                            numResolucion = serviciosDocumentos.obtenerNumeroResolucionComp(numResolucion);
                            myResolucionComparendo.NUMERO = numResolucion.ToString();

                            nombreResolucion = funciones.quitarEspacios(myInfractor.NROIDENTIFICACION.ToString());
                            nombreResolucion += "_" + myResolucionComparendo.NUMERO + "_" + myTipoResolucion.DES_TIPORESOLUCION;
                            myResolucionComparendo.NOMBRE = nombreResolucion;

                            //Crear resolución REVOCATORIA                            
                            generarResolucion.crearResolucion(abrirArchivo, "revocatoria.dotx", numResolucion, myInfractor, myTipoResolucion, myUsuario, fechaResolucion, myPlantilla, infoComparendo, ref myResolucionComparendo);

                            //Actualizar número de resolución y contador de generadas
                            numResolucion++;
                            countResolucionesGeneradas++;
                        }


                        string message = "";
                        message = countResolucionesGeneradas + " resolucion(es) creada(s) de " + totalComparendos + " comparendo(s) seleccionado(s).";
                        if (!abrirArchivo)
                            message += " Los archivos han sido almacenados en: " + serviciosConfiguraciones.leerRegistroIni("RESOLUCIONES");

                        MessageBox.Show(message, "Terminado", 0, MessageBoxIcon.Information);
                        bandera = false;
                        cargarComparendosInfractor();
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar al menos un comparendo!");
                        dtGrViewComparendos.Focus();
                    }
                }
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message + " -Por favor cierre los documentos de resoluciones abiertos.");
            }

            this.Cursor = Cursors.Arrow;
        }

        private void txtNumResol_KeyDown_1(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && txtNumResol.Text != "")
                {
                    if (serviciosDocumentos.validarNumeroResolucionComp(txtNumResol.Text))
                    {
                        btnGenerarResolucion.Enabled = true;
                        numResolucion = int.Parse(txtNumResol.Text);
                    }
                    else
                    {
                        MessageBox.Show("El número de resolución ya existe!. Ingrese otro número.");
                        btnGenerarResolucion.Enabled = false;
                        txtNumResol.Focus();
                        numResolucion = 0;
                    }
                }
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
            }
        }

        private void cmbBoxPlantillas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbBoxPlantillas.SelectedIndex > -1)
                {
                    myPlantilla = new plantilla();
                    myPlantilla.ID = (int)cmbBoxPlantillas.SelectedValue;
                    myPlantilla = (plantilla)((Object[])serviciosDocumentos.buscarPlantillasComp(myPlantilla))[0];

                    myTipoResolucion = new tipoResolucionComp();
                    myTipoResolucion.IDTIPORESOLUCION = myPlantilla.IDTIPORESOLUCION;
                    myTipoResolucion = (tipoResolucionComp)((Object[])serviciosDocumentos.buscarTipoResolucionComp(myTipoResolucion))[0];
                }
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            try
            {
                buscarInfractor();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void txtDocumento_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    buscarInfractor();
                }
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        #endregion

        #region Eventos KeyPress

        private void txtNumResol_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones fnc = new Funciones();
            fnc.esNumero(e);
        }

        private void cmbBoxTipoDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones myFun = new Funciones();
            myFun.lanzarTapConEnter(e);
        }

        private void cmbBoxPlantillas_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones myFun = new Funciones();
            myFun.lanzarTapConEnter(e);
        }

        private void dtPickFechaResolucion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones myFun = new Funciones();
            myFun.lanzarTapConEnter(e);
        }

        private void dtPickFechaAudiencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones myFun = new Funciones();
            myFun.lanzarTapConEnter(e);
        }

        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones myFun = new Funciones();
            myFun.esNumero(e);
        }
        #endregion  

    }
}
