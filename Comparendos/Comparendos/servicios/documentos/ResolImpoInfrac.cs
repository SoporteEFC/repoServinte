using System; using TransitoPrincipal;
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
using LibreriasSintrat.utilidades; 
using LibreriasSintrat;
using System.Web.UI.WebControls;


namespace Comparendos.servicios.documentos
{
    enum AccionAlcoholemia
    {
        Ninguna = 0,
        Suspension = 1,
        Cancelacion = 2
    }

    public partial class ResolImpoInfrac : Form
    {
        private usuarios myUsuario;
        
        private infractorComp myInfractor;
        private Object[] myComparendos;
        
        private int numResolucion;

        private plantilla myPlantilla;
        private plantilla myPlantillaAlcoholemia;
        private plantilla myPlantillaMototaxismo;

        private tipoResolucionComp myTipoResolucion;
        
        Funciones funciones;
        Boolean bandera;

        ServiciosGeneralesService serviciosGenerales;
        ServiciosDocumentosService serviciosDocumentos;
        ServiciosGeneralesCompService serviciosGeneralesComp;
        ServiciosConfiguracionesService serviciosConfiguraciones;
        
        Log log = new Log();

        public ResolImpoInfrac(usuarios user)
        {
            bandera = true;
            InitializeComponent();
            
            serviciosGenerales = WS.ServiciosGeneralesService();
            serviciosDocumentos = WS.ServiciosDocumentosService();
            serviciosGeneralesComp = WS.ServiciosGeneralesCompService();
            serviciosConfiguraciones = WS.ServiciosConfiguracionesService();

            funciones = new Funciones();            
            
            myUsuario = user;
            numResolucion = -1;
        }

        private void ResolImpoInfrac_Load(object sender, EventArgs e)
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
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        public void cargarCombos()
        {
            //Tipo Acción
            ListItem itemNinguna = new ListItem("Ninguna", AccionAlcoholemia.Ninguna.ToString());
            ListItem itemSuspension = new ListItem("Suspensión", AccionAlcoholemia.Suspension.ToString());
            ListItem itemCancelacion = new ListItem("Cancelación", AccionAlcoholemia.Cancelacion.ToString());
            cmbTipoAccionAlcoholemia.Items.Add(itemNinguna);
            cmbTipoAccionAlcoholemia.Items.Add(itemSuspension);
            cmbTipoAccionAlcoholemia.Items.Add(itemCancelacion);
            cmbTipoAccionAlcoholemia_SelectedIndexChanged(null, null);


            ServiciosAccesoriasCompService serviciosAccesoriasComp = WS.ServiciosAccesoriasCompService();
            Object[] arreglo;

            arreglo = (Object[])serviciosAccesoriasComp.obtenerTiposDocumento();
            funciones.llenarCombo(cmbBoxTipoDoc,arreglo);
                        
            plantilla myTmpPlantilla = new plantilla();
            myTmpPlantilla.IDTIPORESOLUCION = 5;
            arreglo = (Object[])serviciosDocumentos.buscarPlantillasComp(myTmpPlantilla);
            
            funciones.llenarCombo(cmbBoxPlantillas, arreglo);
            funciones.llenarCombo(cmbPlantillaAlcoholemia, arreglo);
            funciones.llenarCombo(cmbPlantillaMotoTaxi, arreglo);

            cmbBoxPlantillas.SelectedIndex = -1;
            cmbPlantillaAlcoholemia.SelectedIndex = -1;
            cmbPlantillaMotoTaxi.SelectedIndex = -1;
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

        public void cargarComparendosInfractor()
        {
            limpiarComparendos();
            
            String filtroEstados;
            String[] estados;
            Object[] tmpComparendos;
            
            viewComparendosResolSancionComp myCompResoSanc = new viewComparendosResolSancionComp();
            myCompResoSanc.ID_INFRACTOR = myInfractor.ID_INFRACTOR;
                        
            filtroEstados = serviciosGeneralesComp.obtenerEstadosResolSancion();

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

        private void mostrarInfoInfractor()
        {
            txtInfractor.Text = myInfractor.NOMBRES + " " + myInfractor.APELLIDOS;
            txtDireccion.Text = myInfractor.DIRECCION;
            txtTelefono.Text = myInfractor.TELEFONO;
        }

        private void mostrarComparendos()
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

            dt = funciones.ToDataTableEnOrden(funciones.ObjectToArrayList(myComparendos),campos);
            dtGrViewComparendos.DataSource = dt;

            if (dt!=null && dt.Rows.Count > 0)
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

        private void limpiarComparendos()
        {
            dtGrViewComparendos.DataSource = null;            
            myComparendos = null;
        }


        private bool validarDatos(viewComparendosResolSancionComp infoComparendo)
        {
            if (cmbBoxPlantillas.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar una plantilla para imposición.");
                cmbBoxPlantillas.Focus();
                return false;
            }

            if (infoComparendo != null && infoComparendo.NUEVO_CODIGO.Equals("E3"))
                if (cmbPlantillaAlcoholemia.SelectedIndex < 0)
                {
                    MessageBox.Show("Debe seleccionar una plantilla para alcoholemia.");
                    cmbPlantillaAlcoholemia.Focus();
                    return false;
                }

            if (infoComparendo != null && infoComparendo.NUEVO_CODIGO.Equals("D12"))
                if (cmbPlantillaMotoTaxi.SelectedIndex < 0)
                {
                    MessageBox.Show("Debe seleccionar una plantilla para mototaxismo.");
                    cmbPlantillaMotoTaxi.Focus();
                    return false;
                }

            if (infoComparendo != null && infoComparendo.NUEVO_CODIGO.Equals("E3"))
                if (!rbtEspecificarAccion.Checked && !rbtPorDefecto.Checked)
                {
                    MessageBox.Show("Debe especificar la acción en caso de alcoholemia.");
                    grbAccionAlcoholemia.Focus();
                    return false;
                }

            if (infoComparendo != null && infoComparendo.NUEVO_CODIGO.Equals("E3"))
                if (!rbtEspecificarAccion.Checked)
                {
                    MessageBox.Show("Debe especificar el tipo de acción.");
                    cmbTipoAccionAlcoholemia.Focus();
                    return false;
                }

            if (infoComparendo != null && infoComparendo.NUEVO_CODIGO.Equals("E3"))
                if (rbtEspecificarAccion.Checked && cmbTipoAccionAlcoholemia.SelectedIndex < 0)
                {
                    MessageBox.Show("Debe especificar el tipo de acción.");
                    cmbTipoAccionAlcoholemia.Focus();
                    return false;
                }

            if (infoComparendo != null && infoComparendo.NUEVO_CODIGO.Equals("E3"))
                if (rbtEspecificarAccion.Checked && cmbTipoAccionAlcoholemia.SelectedIndex.Equals((int)AccionAlcoholemia.Suspension) && string.IsNullOrWhiteSpace(txtTiempoSuspension.Text))
                {
                    MessageBox.Show("Debe especificar el tiempo de suspensión.");
                    txtTiempoSuspension.Focus();
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


        private void btnGenerarResolucion_Click(object sender, EventArgs e)
        {
            Boolean resolucionCreada = true;
            this.Cursor = Cursors.WaitCursor;

            try
            {
                if (validarDatos(null))
                {
                    if (dtGrViewComparendos.SelectedCells.Count > 0)
                    {
                        numResolucion = int.Parse(txtNumResol.Text);

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
                            myResolucionComparendo.MOTIVO = txtMotivo.Text;
                            myResolucionComparendo.CONSIDERACIONJURIDICA = txtConsidJurid.Text;
                            myResolucionComparendo.ID_TIPORESOLUCION = myPlantilla.IDTIPORESOLUCION;

                            if (validarDatos(infoComparendo))
                            {
                                resolucionCreada = true;
                                //SUSPENSIÒN / CANCELACIÒN ALCOHOLEMIA - Generar Resolución adicional (si aplica)
                                if (infoComparendo.NUEVO_CODIGO.Equals("E3"))
                                {
                                    if (rbtPorDefecto.Checked)
                                    {
                                        comparendoComp myComparendo = new comparendoComp();
                                        myComparendo.ID_COMPARENDO = infoComparendo.ID_COMPARENDO;

                                        myComparendo = serviciosGeneralesComp.searchOneComparendo(myComparendo);

                                        if (myComparendo != null && myComparendo.ID_COMPARENDO >= 0)
                                        {
                                            estadoAlcoholemia estadoAlcohol = new estadoAlcoholemia();
                                            estadoAlcohol = serviciosGeneralesComp.getFechaSuspension(null, int.Parse(myComparendo.VALORALCOLEMIA.ToString()), true);
                                            if (estadoAlcohol != null && estadoAlcohol.ID > 0)
                                            {
                                                myResolucionComparendo.ACCION_ALCOHOLEMIA = (int)AccionAlcoholemia.Suspension;
                                                myResolucionComparendo.TIEMPOSUSPENSIONLIC = int.Parse(estadoAlcohol.SUSPENCIONINFERIOR);
                                            }
                                        }
                                    }

                                    if (rbtEspecificarAccion.Checked)
                                    {
                                        myResolucionComparendo.ACCION_ALCOHOLEMIA = (int)cmbTipoAccionAlcoholemia.SelectedIndex;

                                        if (cmbTipoAccionAlcoholemia.SelectedIndex.Equals((int)AccionAlcoholemia.Suspension))
                                            myResolucionComparendo.TIEMPOSUSPENSIONLIC = int.Parse(txtTiempoSuspension.Text);
                                    }

                                    //Crear resolución alcoholemia
                                    abrirArchivo = false;
                                    generarResolucion.crearResolucion(abrirArchivo, "ResolucionInfractor.dotx", numResolucion, myInfractor, myTipoResolucion, myUsuario, fechaResolucion, myPlantillaAlcoholemia, infoComparendo, ref myResolucionComparendo);

                                    //Actualizar número de resolución y contador de generadas
                                    numResolucion++;
                                    countResolucionesGeneradas++;
                                }

                                //SUSPENSIÒN / CANCELACIÒN MOTOTAXISMO - Generar Resolución adicional (si aplica)
                                if (infoComparendo.NUEVO_CODIGO.Equals("D12"))
                                {
                                    //Buscar si el mismo infractor ha cometido esta infracción otras veces en un periodo no mayor a un año
                                    viewComparendosResolSancionComp tmpViewComparendo = new viewComparendosResolSancionComp();
                                    tmpViewComparendo.IDINFRACCION = infoComparendo.IDINFRACCION;
                                    tmpViewComparendo.ID_INFRACTOR = infoComparendo.ID_INFRACTOR;

                                    Object[] tmpComparendos = (Object[])serviciosGeneralesComp.buscarComparendosEnRangoFecha(funciones.convFormatoFecha(dtPickFechaResolucion.Value.AddYears(-1).ToString(), "MM/dd/yyyy"), fechaResolucion, tmpViewComparendo);

                                    if (tmpComparendos != null)
                                    {
                                        //Si es la primera vez, no se hace nada
                                        if (tmpComparendos.Length == 1)
                                        {
                                            myResolucionComparendo.ACCION_ALCOHOLEMIA = (int)AccionAlcoholemia.Ninguna;
                                            myResolucionComparendo.TIEMPOSUSPENSIONLIC = 0;
                                        }

                                        //Si es la segunda vez, se suspende la licencia por 6 meses
                                        if (tmpComparendos.Length == 2)
                                        {
                                            myResolucionComparendo.ACCION_ALCOHOLEMIA = (int)AccionAlcoholemia.Suspension;
                                            myResolucionComparendo.TIEMPOSUSPENSIONLIC = 6;
                                        }

                                        //Si es la tercera vez, se cancela la licencia
                                        if (tmpComparendos.Length >= 3)
                                        {
                                            myResolucionComparendo.ACCION_ALCOHOLEMIA = (int)AccionAlcoholemia.Cancelacion;
                                            myResolucionComparendo.TIEMPOSUSPENSIONLIC = 0;
                                        }
                                    }

                                    //Crear resolución mototaxismo
                                    abrirArchivo = false;
                                    generarResolucion.crearResolucion(abrirArchivo, "ResolucionInfractor.dotx", numResolucion, myInfractor, myTipoResolucion, myUsuario, fechaResolucion, myPlantillaMototaxismo, infoComparendo, ref myResolucionComparendo);

                                    //Actualizar número de resolución y contador de generadas
                                    numResolucion++;
                                    countResolucionesGeneradas++;
                                }


                                //Crear resolución Imposición
                                //Limpiar los campos de Acción en caso de Alcoholemia
                                myResolucionComparendo.ACCION_ALCOHOLEMIA = (int)AccionAlcoholemia.Ninguna;
                                myResolucionComparendo.TIEMPOSUSPENSIONLIC = 0;

                                if (totalComparendos > 1)
                                    abrirArchivo = false;
                                else
                                    abrirArchivo = true;
                                generarResolucion.crearResolucion(abrirArchivo, "ResolucionInfractor.dotx", numResolucion, myInfractor, myTipoResolucion, myUsuario, fechaResolucion, myPlantilla, infoComparendo, ref myResolucionComparendo);

                                //Actualizar número de resolución y contador de generadas
                                numResolucion++;
                                countResolucionesGeneradas++;
                            }
                            else
                                resolucionCreada = false;
                        }

                        if (resolucionCreada)
                        {
                            string message = "";
                            message = countResolucionesGeneradas + " resolucion(es) creada(s) de " + totalComparendos + " comparendo(s) seleccionado(s).";
                            if (!abrirArchivo)
                                message += " Los archivos han sido almacenados en: " + serviciosConfiguraciones.leerRegistroIni("RESOLUCIONES");

                            MessageBox.Show(message, "Terminado", 0, MessageBoxIcon.Information);
                            bandera = false;
                            cargarComparendosInfractor();
                        }
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
        
        private void txtNumResol_KeyDown(object sender, KeyEventArgs e)
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
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
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
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void cmbPlantillaAlcoholemia_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbPlantillaAlcoholemia.SelectedIndex > -1)
                {
                    myPlantillaAlcoholemia = new plantilla();
                    myPlantillaAlcoholemia.ID = (int)cmbPlantillaAlcoholemia.SelectedValue;
                    myPlantillaAlcoholemia = (plantilla)((Object[])serviciosDocumentos.buscarPlantillasComp(myPlantillaAlcoholemia))[0];

                    myTipoResolucion = new tipoResolucionComp();
                    myTipoResolucion.IDTIPORESOLUCION = myPlantillaAlcoholemia.IDTIPORESOLUCION;
                    myTipoResolucion = (tipoResolucionComp)((Object[])serviciosDocumentos.buscarTipoResolucionComp(myTipoResolucion))[0];
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

        private void cmbPlantillaMotoTaxi_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbPlantillaMotoTaxi.SelectedIndex > -1)
                {
                    myPlantillaMototaxismo = new plantilla();
                    myPlantillaMototaxismo.ID = (int)cmbPlantillaMotoTaxi.SelectedValue;
                    myPlantillaMototaxismo = (plantilla)((Object[])serviciosDocumentos.buscarPlantillasComp(myPlantillaMototaxismo))[0];

                    myTipoResolucion = new tipoResolucionComp();
                    myTipoResolucion.IDTIPORESOLUCION = myPlantillaMototaxismo.IDTIPORESOLUCION;
                    myTipoResolucion = (tipoResolucionComp)((Object[])serviciosDocumentos.buscarTipoResolucionComp(myTipoResolucion))[0];
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

        private void cmbTipoAccionAlcoholemia_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbTipoAccionAlcoholemia.SelectedIndex.Equals((int)AccionAlcoholemia.Suspension))
                    txtTiempoSuspension.Enabled = true;
                else
                    txtTiempoSuspension.Enabled = false;
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
            }
        }

        #region Eventos KeyPress
            private void txtNumResol_KeyPress(object sender, KeyPressEventArgs e)
            {
                try
                {
                    Funciones fnc = new Funciones();
                    fnc.esNumero(e);
                    funciones.lanzarTapConEnter(e);

                    if (string.IsNullOrWhiteSpace(txtNumResol.Text))
                        btnGenerarResolucion.Enabled = false;
                }
                catch (Exception exp)
                {
                    log.escribirError(exp.ToString(), this.GetType());
                    MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                }
            }
            private void cmbBoxTipoDoc_KeyPress(object sender, KeyPressEventArgs e)
            {
                try
                {
                    funciones.lanzarTapConEnter(e);
                }
                catch (Exception exp)
                {
                    log.escribirError(exp.ToString(), this.GetType());
                    MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                    //Console.WriteLine(exp.Message);
                    //Console.WriteLine(exp.StackTrace);
                }
            }

            private void cmbBoxPlantillas_KeyPress(object sender, KeyPressEventArgs e)
            {
                try
                {
                    funciones.lanzarTapConEnter(e);
                }
                catch (Exception exp)
                {
                    log.escribirError(exp.ToString(), this.GetType());
                    MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                    //Console.WriteLine(exp.Message);
                    //Console.WriteLine(exp.StackTrace);
                }
            }

            private void dtPickFechaAudiencia_KeyPress(object sender, KeyPressEventArgs e)
            {
                try
                {
                    funciones.lanzarTapConEnter(e);
                }
                catch (Exception exp)
                {
                    log.escribirError(exp.ToString(), this.GetType());
                    MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                    //Console.WriteLine(exp.Message);
                    //Console.WriteLine(exp.StackTrace);
                }
            }

            private void dtPickFechaResolucion_KeyPress(object sender, KeyPressEventArgs e)
            {
                try
                {
                    funciones.lanzarTapConEnter(e);
                }
                catch (Exception exp)
                {
                    log.escribirError(exp.ToString(), this.GetType());
                    MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                    //Console.WriteLine(exp.Message);
                    //Console.WriteLine(exp.StackTrace);
                }
            }

            private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
            {
                try
                {
                    Funciones myFun = new Funciones();
                    myFun.esNumero(e);
                }
                catch (Exception exp)
                {
                    log.escribirError(exp.ToString(), this.GetType());
                    MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                }
            }

            private void txtTiempoSuspension_KeyPress(object sender, KeyPressEventArgs e)
            {
                try
                {
                    funciones.esNumero(e);
                }
                catch (Exception exp)
                {
                    log.escribirError(exp.ToString(), this.GetType());
                    MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                }
            }
        #endregion                        
            
    }
}
