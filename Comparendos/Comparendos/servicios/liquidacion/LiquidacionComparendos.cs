using System; using TransitoPrincipal; using LibreriasSintrat.utilidades;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibreriasSintrat.ServiciosLiquidadorComparendos;
using LibreriasSintrat.ServiciosAccesoriasComp;
using LibreriasSintrat.ServiciosGeneralesComp;
using LibreriasSintrat.ServiciosConfiguraciones;
using LibreriasSintrat.ServiciosUsuarios;
using System.Collections;
using Comparendos.utilidades; 
using LibreriasSintrat;
using System.Globalization;

namespace Comparendos.servicios.liquidacion
{
    public partial class LiquidacionComparendos : Form
    {
        ServiciosLiquidadorComparendosService clienteLiquidacion;
        ServiciosAccesoriasCompService clienteAccesorias;
        ServiciosGeneralesCompService clienteComparendos;
        ServiciosConfiguracionesService serviciosConfiguraciones;

        public tarifa tarifasel;
        public DataTable conceptos;
        public DataTable comparendos;
        char[] divisores = { '^' };
        LibreriasSintrat.ServiciosGeneralesComp.infractorComp infractor;
        
        Object[] comparendosLiquidar;
        double total = 0;
        Object[] listaConceptos;
        Log log = new Log();
        CultureInfo culturaEspaniolCol = new CultureInfo("es-CO", false);

        string directorioComparendos;
        usuarios myUsuario;
        Funciones funciones;

        public LiquidacionComparendos(usuarios usuario)
        {
            this.Cursor = Cursors.WaitCursor;
            
            funciones = new Funciones();
            log = new Log();
            try
            {
                InitializeComponent();
                crearObjetos();
                CargarRutasDirectorios();
                LimpiarFormulario();
                myUsuario = usuario;
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error cargando formulario " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }

            this.Cursor = Cursors.Arrow;
        }

        private void LiquidacionComparendos_Load(object sender, EventArgs e)
        {
            cmbTipoIdentificacion.SelectedIndex = -1;
        }

        private void LimpiarFormulario()
        {
            cmbTipoIdentificacion.Focus();
            cmbTipoIdentificacion.SelectedIndex = -1;
            txtNroIdentificacion.Text = "";
            labInfractor.Text = "";
            cmbTarifas.Enabled = false;
            btnFacturar.Enabled = false;
            tblComparendos.DataSource = null;
            tblConceptos.DataSource = null;
            tblComparendos.Enabled = true;
        }

        private void CargarRutasDirectorios()
        {
            directorioComparendos = serviciosConfiguraciones.directorioFacturasComparendo();
        }

        public void crearObjetos()
        {
            clienteLiquidacion = WS.ServiciosLiquidadorComparendosService();
            clienteAccesorias = WS.ServiciosAccesoriasCompService();
            clienteComparendos = WS.ServiciosGeneralesCompService();
            serviciosConfiguraciones = WS.ServiciosConfiguracionesService();
            crearTablaComparendos();
            tblComparendos.DataSource = comparendos;
            getTipoDocumento();
            getTarifas();

        }

        public void getTipoDocumento()
        {

           // Object[] lista = clienteAccesorias.obtenerTiposDocumento();
            ServiciosAccesoriasCompService serviciosAccesoriasComp = WS.ServiciosAccesoriasCompService();
            funciones.llenarCombo(cmbTipoIdentificacion, serviciosAccesoriasComp.obtenerTiposDocumento());
           // funciones.llenarCombo(cmbTipoIdentificacion, lista);
            //foreach (documentoComp obje in lista)
            //{
            //    cmbTipoIdentificacion.Items.Add(obje);
            //}
        }

        public void getTarifas()
        {
            cmbTarifas.Items.Clear();
            tarifa tarifa = new tarifa();
            tarifa.LT_VIGENCIA = DateTime.Now.Year.ToString(); // "2011"; //TODO cambiarlo por Now.Year || serviciosConfiguraciones.getVigencia()
            Object[] lista = (Object[])clienteLiquidacion.getTarifas(tarifa);

            if(lista!=null)
            foreach (tarifa tarifa1 in lista)
            {
                cmbTarifas.Items.Add(tarifa1);
            }
        }

        private void cmbTarifa_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbTarifas.SelectedIndex >= 0)
                {
                    tarifasel = (tarifa)cmbTarifas.SelectedItem;
                    crearTablaConceptos();
                    //tarifasel.conceptos = getConceptosTarifa(tarifasel);
                    getConceptosTarifa(tarifasel);
                    tblConceptos.DataSource = conceptos;
                }
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error cargando formulario " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }


        public Object[] getConceptosTarifa(tarifa tar)
        {
            conceptosTarifa conceptosTarifa = new conceptosTarifa();
            conceptosTarifa.LT_ID = tar.LT_ID;
            Object[] lista = null;
            Funciones funciones = new Funciones();

            String datos;
            int i = 0;
            //llenamos el infractor
            LibreriasSintrat.ServiciosLiquidadorComparendos.infractorComp infractorAux = new LibreriasSintrat.ServiciosLiquidadorComparendos.infractorComp();
            infractorAux.ID_DOCTO = infractor.ID_DOCTO;
            infractorAux.NROIDENTIFICACION = infractor.NROIDENTIFICACION;

            //consultamos los conceptos y su previafacturacion
            object[] comparendosSeleccionados = ComparendosSeleccionados();
            if (comparendosSeleccionados != null && comparendosSeleccionados.Length > 0)
            {
                lista = clienteLiquidacion.getConceptosTarifa(conceptosTarifa, infractorAux, comparendosSeleccionados, new LibreriasSintrat.ServiciosLiquidadorComparendos.comparendoComp());
                if (lista != null)
                {
                    listaConceptos = lista;
                    total = 0;

                    foreach (conceptosTarifa concepto in lista)
                    {
                        //llenamos el dt conceptos

                        //new

                        string LTD_VALOR = "0";

                        if (!(String.IsNullOrEmpty(concepto.LTD_VALOR)))
                            LTD_VALOR = concepto.LTD_VALOR;

                        //endnew 

                        double d = double.Parse(LTD_VALOR, System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.InvariantCulture);

                        //d = funciones.RedondearSegunServidor(d);
                        datos = concepto.NUMEROCOMPARENDO + "^" + concepto.FECHACOMPARENDO + "^" + 
                            concepto.DESCRIPCION + "^" + d + "^" + concepto.LTD_CALCULO + "^" + 
                            concepto.LTD_TIPO + "^" + concepto.LTD_DESCONTABLE + "^" + concepto.LT_VIGENCIA;
                        conceptos.Rows.Add(datos.Split(divisores));

                        //calculamos el valor el total
                        //double aux = 0;
                        //if (!Double.TryParse(concepto.LTD_VALOR.Replace(".", ","), out aux))
                        //    if (!Double.TryParse(concepto.LTD_VALOR.Replace(",", "."), out aux))
                        //        aux = Convert.ToDouble(concepto.LTD_VALOR);
                        total += d;
                        i = i + 1;

                    }
                    label15.Text = total.ToString("C", culturaEspaniolCol);
                    btnFacturar.Enabled = true;
                    //tblComparendos.Enabled = false;
                }
                else
                {
                    MessageBox.Show("La tarifa seleccionada no contiene ningún concepto que se pueda aplicar a los comparendos seleccionados");
                }
            }
            return lista;
        }

        private double Redondear(double valor)
        {
            Funciones funciones = new Funciones();
            int valorUnidad = serviciosConfiguraciones.redondeoValorUnidad();
            string usoRedondeo = serviciosConfiguraciones.usoRedondeo();
            if (usoRedondeo == "ARRIBA")
            {
                valor = funciones.RedondeoArriba(valor, valorUnidad);
            }
            else if (usoRedondeo == "ABAJO")
            {
                valor = funciones.RedondeoAbajo(valor, valorUnidad);
            }
            else if (usoRedondeo == "CERCANO")
            {
                valor = funciones.RedondeoCercano(valor, valorUnidad);
            }
            return valor;
        }

        private object[] ComparendosSeleccionados()
        {
            LibreriasSintrat.ServiciosLiquidadorComparendos.comparendoComp compLiqu;
            object[] res = new object[tblComparendos.SelectedRows.Count];
            int k = 0;
            for (int i = 0; i < tblComparendos.SelectedRows.Count; i++)
            {
                for (int j = 0; j < comparendosLiquidar.Length; j++)
                {
                    compLiqu = (LibreriasSintrat.ServiciosLiquidadorComparendos.comparendoComp)comparendosLiquidar[j];
                    if (compLiqu.NUMEROCOMPARENDO == tblComparendos.SelectedRows[i].Cells["Numero"].Value.ToString())
                    {
                        res[k] = comparendosLiquidar[j];
                        k++;
                        break;
                    }
                }
            }
            return res;
        }

        public Object[] crearComparendos(Object[] concep)
        {
            Object[] resConceptos = new Object[concep.Length];
            int i = 0;
            foreach (LibreriasSintrat.ServiciosLiquidadorComparendos.comparendoComp concepto in concep)
            {
                resConceptos[i] = concepto;
                i++;
            }
            return resConceptos;
        }



        public DataTable crearTablaConceptos()
        {
            conceptos = new DataTable();
            conceptos.Columns.Add("Numero Comparendo", typeof(string));
            conceptos.Columns.Add("Fecha", typeof(string));
            conceptos.Columns.Add("Concepto", typeof(string));
            conceptos.Columns.Add("Valor", typeof(string));
            conceptos.Columns.Add("Calculo", typeof(string));
            conceptos.Columns.Add("Tipo", typeof(string));
            conceptos.Columns.Add("Descontable", typeof(string));
            conceptos.Columns.Add("Vigencia", typeof(string));
            return conceptos;

        }

        public DataTable crearTablaComparendos()
        {
            comparendos = new DataTable();
            comparendos.Columns.Add("Numero", typeof(string));
            comparendos.Columns.Add("Fecha", typeof(string));
            comparendos.Columns.Add("Hora", typeof(string));
            comparendos.Columns.Add("Codigo", typeof(string));
            comparendos.Columns.Add("Descripcion", typeof(string));
            comparendos.Columns.Add("Valor", typeof(string));
            return comparendos;

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                AccionBuscar();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error cargando formulario " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void AccionBuscar()
        {
            cmbTarifas.SelectedIndex = -1;
            if (cmbTipoIdentificacion.SelectedIndex != -1 && txtNroIdentificacion.Text != "")
                getComparendos();
            else
                MessageBox.Show("Ingrese tanto el tipo de identificación como el numero del mismo");
        }

        public void getComparendos()
        {
            LimpiarComparendos();

            Object[] lista = null;
            String datos;
            infractor = new LibreriasSintrat.ServiciosGeneralesComp.infractorComp();

            //buscamos el infractor
            infractor.NROIDENTIFICACION = txtNroIdentificacion.Text;
            String id_docto = cmbTipoIdentificacion.SelectedValue.ToString();
            infractor.ID_DOCTO = int.Parse(cmbTipoIdentificacion.SelectedValue.ToString());
            infractor = clienteComparendos.buscarInfractor(infractor);
            if (infractor != null)
            {
                labInfractor.Text = infractor.NOMBRES + " " + infractor.APELLIDOS;

                //buscamos los comparendos para el id del infractor
                LibreriasSintrat.ServiciosLiquidadorComparendos.comparendoComp comparendo = new LibreriasSintrat.ServiciosLiquidadorComparendos.comparendoComp();
                comparendo.ID_INFRACTOR = infractor.ID_INFRACTOR;
                lista = clienteLiquidacion.searchComparendo(comparendo);

                if (lista != null)
                {
                    int i = 0;
                    comparendosLiquidar = crearComparendos(lista);
                    LibreriasSintrat.ServiciosGeneralesComp.infracionComparendoComp infraccionComparendo;
                    foreach (LibreriasSintrat.ServiciosLiquidadorComparendos.comparendoComp comparendo1 in lista)
                    {
                        infraccionComparendo = new LibreriasSintrat.ServiciosGeneralesComp.infracionComparendoComp();
                        infraccionComparendo.IDCOMPARENDO = comparendo1.ID_COMPARENDO;
                        infraccionComparendo.IDESTADO = 4;
                        infraccionComparendo = clienteComparendos.getInfraccionComparendo(infraccionComparendo);
                        if (infraccionComparendo == null || infraccionComparendo.ID < 0)
                        {
                            infraccionComparendo = new LibreriasSintrat.ServiciosGeneralesComp.infracionComparendoComp();
                            infraccionComparendo.IDCOMPARENDO = comparendo1.ID_COMPARENDO;
                            infraccionComparendo.IDESTADO = 10;
                            infraccionComparendo = clienteComparendos.getInfraccionComparendo(infraccionComparendo);
                        }
                        if (infraccionComparendo != null && infraccionComparendo.ID >= 0)
                        {
                            LibreriasSintrat.ServiciosAccesoriasComp.infraccionesComp infraccion = new LibreriasSintrat.ServiciosAccesoriasComp.infraccionesComp();
                            infraccion.ID_INFRACCION = infraccionComparendo.IDINFRACCION;
                            infraccion = clienteAccesorias.getInfraccionComp(infraccion);

                            if (infraccion != null)
                            {
                                //llenamos el dtcomparendos
                                datos = comparendo1.NUMEROCOMPARENDO + "^" + comparendo1.FECHACOMPARENDO + "^" + comparendo1.HORACOMPARENDO + "^" + infraccion.NUEVO_CODIGO + "^" + infraccion.DESCRIPCION + "^" + infraccionComparendo.VALORINFRACCION;
                                comparendos.Rows.Add(datos.Split(divisores));
                                i++;
                            }
                        }
                    }
                    if (comparendos.Rows.Count > 0)
                    {
                        tblComparendos.DataSource = comparendos;
                        cmbTarifas.Enabled = true;
                        lnkVerFactura.Links.Clear();
                        lnkVerFactura.BackColor = Color.LightGray;
                        lnkVerFactura.Enabled = false;
                        label3.Text = "";
                        cmbTarifas.SelectedIndex = 0;
                        cmbTarifas.Focus();
                    }
                    else
                    {
                        MessageBox.Show("El infractor ingrasado no tiene comparendos o estos estan en un estado sin resolución");
                    }
                }
                else
                {
                    MessageBox.Show("La persona ingresada no tiene comparendos registrados");
                }
            }
        }

        private void LimpiarComparendos()
        {
            comparendosLiquidar = null;
            if (comparendos != null) comparendos.Clear();
            tblComparendos.DataSource = null;
            if (conceptos != null) conceptos.Clear();
            listaConceptos = null;
            cmbTarifas.SelectedIndex = -1;
        }

        private void cmbTipoIdentificacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //documentoComp td = (documentoComp)cmbTipoIdentificacion.SelectedValue;
                if (cmbTipoIdentificacion.SelectedIndex != -1)
                    txtNroIdentificacion.Focus();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error cargando formulario " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                bool facturacionTotal = true;
                DialogResult dr = MessageBox.Show("La facturación a realizar es para PAGO TOTAL (NO ACUERDO DE PAGO)",
                    "Facturación total", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, 
                    MessageBoxDefaultButton.Button3, MessageBoxOptions.DefaultDesktopOnly);
                if (dr == DialogResult.Yes) facturacionTotal = true;
                else if (dr == DialogResult.No) facturacionTotal = false;
                
                if (dr != DialogResult.Cancel)
                {
                    FNota fnota = new FNota();
                    if (fnota.ShowDialog() == DialogResult.OK)
                    {
                        datosAdicionalesFactura datosAdicionales = new datosAdicionalesFactura();
                        datosAdicionales.nota = fnota.getNota();
                        datosAdicionales.idPersona = Convert.ToString(infractor.ID_INFRACTOR);
                        datosAdicionales.total = Convert.ToString(total).Replace(",", ".");
                        
                        header header1 = new header();
                        header1.idUsuario = myUsuario.ID_USUARIO.ToString();
                        LibreriasSintrat.ServiciosLiquidadorComparendos.infractorComp infractorAux = new LibreriasSintrat.ServiciosLiquidadorComparendos.infractorComp();
                        infractorAux.ID_INFRACTOR = infractor.ID_INFRACTOR;
                        infractorAux.NOMBRES = infractor.NOMBRES;
                        infractorAux.APELLIDOS = infractor.APELLIDOS;
                        infractorAux.NROIDENTIFICACION = infractor.NROIDENTIFICACION;
                        
                        datosFactura datosFactura;
                        if (facturacionTotal)
                        {
                            datosFactura = clienteLiquidacion.facturar(header1, listaConceptos, datosAdicionales, infractorAux, WS.MyUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName());

                            label3.Text = datosFactura.numeroFacturaLocal;
                            //String ruta = "D:\\tmp\\facturaOracle\\facturas\\comparendos\\" + datosFactura.numeroFacturaLocal + ".pdf";
                            String ruta = directorioComparendos + datosFactura.numeroFacturaLocal + ".pdf";

                            lnkVerFactura.Links.Clear();
                            lnkVerFactura.Links.Add(0, 11, ruta);
                            lnkVerFactura.BackColor = Color.LightGray;
                            lnkVerFactura.Enabled = true;
                        }
                        else
                        {
                            datosFactura = clienteLiquidacion.facturarParaCuota(header1, listaConceptos, datosAdicionales, infractorAux, WS.MyUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName());
                        }

                        btnFacturar.Enabled = false;
                        cmbTarifas.SelectedIndex = -1;

                        //cambiar estado del comparendos
                        object[] objs = ComparendosSeleccionados();
                        if (objs != null && objs.Length > 0)
                        {
                            LibreriasSintrat.ServiciosLiquidadorComparendos.comparendoComp comparendo;
                            LibreriasSintrat.ServiciosGeneralesComp.infracionComparendoComp infraccionComparendo;
                            for (int i = 0; i < objs.Length; i++)
                            {
                                infraccionComparendo = new LibreriasSintrat.ServiciosGeneralesComp.infracionComparendoComp();
                                comparendo = (LibreriasSintrat.ServiciosLiquidadorComparendos.comparendoComp)objs[i];
                                infraccionComparendo.IDCOMPARENDO = comparendo.ID_COMPARENDO;
                                infraccionComparendo = clienteComparendos.getInfraccionComparendo(infraccionComparendo);
                                if (infraccionComparendo != null && infraccionComparendo.ID >= 0)
                                {
                                    infraccionComparendo.IDESTADO = 11;
                                    clienteComparendos.actualizarInfraccionComparendo(infraccionComparendo, WS.MyUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName());
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error, los comparendos seleccionados fueron descartados");
                        }

                        if (conceptos != null) conceptos.Clear();
                        listaConceptos = null;
                        cmbTarifas.SelectedIndex = -1;
                        btnFacturar.Enabled = false;
                        tblConceptos.DataSource = null;
                        MessageBox.Show("Factura generada satisfactoriamente!");
                    }
                }
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error cargando formulario " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }

            this.Cursor = Cursors.Arrow;
        }

        public Object[] crearConceptos(List<conceptosTarifa> concep)
        {
            Object[] resConceptos = new Object[concep.Count];
            int i = 0;
            foreach (conceptosTarifa concepto in concep)
            {
                resConceptos[i] = concepto;
                i++;
            }
            return resConceptos;
        }

        private void lnkVerFactura_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (e.Link != null && e.Link.LinkData != null)
                {
                    documentos.transferir trans = new Comparendos.servicios.documentos.transferir();
                    trans.archivoDelServer(e.Link.LinkData.ToString());
                    //System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
                }
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("El recurso no pudo ser encontrado. " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void txtNroIdentificacion_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (cmbTipoIdentificacion.SelectedIndex != -1 && txtNroIdentificacion.Text != "")
                        getComparendos();
                    else
                        MessageBox.Show("Ingrese tanto el tipo de identificación como el numero del mismo");
                }
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error cargando formulario " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                LimpiarComparendos();
                LimpiarFormulario();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error cargando formulario " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void txtNroIdentificacion_TextChanged(object sender, EventArgs e)
        {

        }

        private void tblComparendos_SelectionChanged(object sender, System.EventArgs e)
        {
            btnFacturar.Enabled = false;
            tblConceptos.DataSource = null;
            if (cmbTarifas.Items.Count > 0)
            {
                cmbTarifas.SelectedIndex = -1;
                cmbTarifas.SelectedIndex = 0;
            }
        }        

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
