using System; using TransitoPrincipal; using LibreriasSintrat.utilidades;
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
using LibreriasSintrat.ServiciosConfiguraciones;
using System.IO;
using Comparendos.utilidades; using LibreriasSintrat.utilidades; using LibreriasSintrat;
using LibreriasSintrat.utilidades;

namespace Comparendos.servicios.documentos
{
    public partial class fConsultaResoluciones : Form
    {
        private infractorComp myInfractor;
        private Object[] myResoluciones;
        ServiciosAccesoriasCompService ServAccComp;
        ServiciosGeneralesCompService ServGenComp;
        ServiciosDocumentosService ServDocComp;
        Log log = new Log();


        public fConsultaResoluciones()
        {
            InitializeComponent();
            ServAccComp = WS.ServiciosAccesoriasCompService();
            ServGenComp = WS.ServiciosGeneralesCompService();
            ServDocComp = WS.ServiciosDocumentosService();
            log = new Log();
        }

        private void fConsultaResoluciones_Load(object sender, EventArgs e)
        {
            try
            {
                cargarCombos();
                cmbBoxTipoDoc.Focus();
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
            Funciones myFunc = WS.Funciones();
            ServiciosAccesoriasCompService myServAccComp = WS.ServiciosAccesoriasCompService();
            Object[] arreglo;
            arreglo = myServAccComp.obtenerTiposDocumento();
            myFunc.llenarCombo(cmbBoxTipoDoc, arreglo);
        }

        //Carga informacion infractor y muestra
        public void limpiarDatos()
        {
            txtInfractor.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            dtGrWiewResoluciones.DataSource = null;
        }

        public void buscarInfractor()
        {
            ServiciosGeneralesCompService mySerGenComp = WS.ServiciosGeneralesCompService();
            myInfractor = new infractorComp();
            myInfractor.ID_DOCTO = (int)cmbBoxTipoDoc.SelectedValue;
            myInfractor.NROIDENTIFICACION = txtDocumento.Text;
            myInfractor = mySerGenComp.buscarInfractor(myInfractor);

            if (myInfractor == null)
            {
                MessageBox.Show("Verifique la información ingresada!!!", "Infractor no encontrado");
                limpiarDatos();
            }
            else
            {
                //MessageBox.Show("Informacion del infractor cargado con exito!!!", "Infractor");
                limpiarDatos();
                cargarResolucionesInfractor();
                mostrarInfoInfractor();
                dateTPickFechaInicial.Focus();
            }
        }

        public void mostrarInfoInfractor()
        {
            if (myInfractor != null)
            {
                txtInfractor.Text = myInfractor.NOMBRES + " " + myInfractor.APELLIDOS;
                txtDireccion.Text = myInfractor.DIRECCION;
                txtTelefono.Text = myInfractor.TELEFONO;
                if (myResoluciones != null && myResoluciones.Length > 0)
                    mostrarResoluciones();
            }
        }

        public void mostrarResoluciones()
        {
            Funciones funciones = WS.Funciones();
            DataTable dtPrincipal = new DataTable();
            DataTable dtForanea = new DataTable();
            DataTable dtGrilla = new DataTable();
            ArrayList Campos = new ArrayList();
            Campos.Add("NROIDENTIFICACION = IDENTIFICACION");
            Campos.Add("NOMBRES = NOMBRES");
            Campos.Add("APELLIDOS = APELLIDOS");
            Campos.Add("NUMERO = NUMERO RESOLUCION");
            Campos.Add("ID_TIPORESOLUCION = ID_TIPORESOLUCION");
            Campos.Add("FECHA = FECHA RESOLUCION");
            Campos.Add("DIRECCION = DIRECCION");
            Campos.Add("TELEFONO = TELEFONO");
            Campos.Add("NOMBRE = NOMBRE ARCHIVO");


            ArrayList Campos2 = new ArrayList();
            Campos2.Add("IDTIPORESOLUCION = IDTIPORESOLUCION");
            Campos2.Add("DES_TIPORESOLUCION = TIPO RESOLUCION");

            string idForaneo = "IDTIPORESOLUCION";
            string idPrincipal = "ID_TIPORESOLUCION";

            try
            {
                dtPrincipal = funciones.ToDataTableEnOrden(funciones.ObjectToArrayList(myResoluciones), Campos);
                object[] listaTresoluciones = ServDocComp.ListarTipoResolucionComp();
                dtForanea = funciones.ToDataTableEnOrden(funciones.ObjectToArrayList(listaTresoluciones), Campos2);
                dtGrilla = funciones.UnirDatatables(dtPrincipal, dtForanea, idPrincipal, idForaneo);
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
            dtGrWiewResoluciones.DataSource = dtGrilla;
            //if (dtGrilla.Rows.Count > 0)
            //funciones.configurarGrillaEnOrden(dtGrWiewResoluciones, fun Campos);
            dtGrilla = null;
            Campos = null;
        }

        public void cargarResolucionesInfractor()
        {
            ServiciosDocumentosService mySerDoc = WS.ServiciosDocumentosService();
            viewResolucionesInfractorComp myResInf = new viewResolucionesInfractorComp();
            if (myInfractor != null)
            {
                Funciones funciones = new LibreriasSintrat.utilidades.Funciones();

                myResInf.ID_DOCTO = myInfractor.ID_DOCTO;
                myResInf.NROIDENTIFICACION = myInfractor.NROIDENTIFICACION;
                if (chBoxFiltroFecha.Checked)
                {
                    //String filtro = "";
                    //filtro += " AND FECHA BETWEEN '";
                    //filtro += funciones.convFormatoFecha(dateTPickFechaInicial.Text, "MM/dd/yyyy") + "' AND '";
                    //filtro += funciones.convFormatoFecha(dateTPickFechaFinal.Text, "MM/dd/yyyy") + "' ";
                    //myResoluciones = mySerDoc.obtenerResolucionesInfractorFiltro(myResInf, filtro);

                    myResoluciones = mySerDoc.obtenerResolucionesInfractorFiltro(myResInf, funciones.convFormatoFecha(dateTPickFechaInicial.Text, "MM/dd/yyyy"), funciones.convFormatoFecha(dateTPickFechaFinal.Text, "MM/dd/yyyy"));
                }
                else
                {
                    myResoluciones = mySerDoc.obtenerResolucionesInfractor(myResInf);
                }
                if (myResoluciones == null || myResoluciones.Count() < 1)
                {
                    MessageBox.Show("No se encontraron resoluciones asociadas al infractor");
                }
            }
        }

        //controlan el campo del documento

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

        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Funciones myFun = WS.Funciones();
                myFun.esNumero(e);
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                Funciones myFun = WS.Funciones();
                saveFileDialog1.ShowDialog();
                if (saveFileDialog1.FileName != "")
                    myFun.exportarDataGridViewAExcel(saveFileDialog1.FileName, "Reporte Resoluciones", dtGrWiewResoluciones);
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void dtGrWiewResoluciones_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                imprimirResolucion();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            
            try
            {
                chBoxFiltroFecha.Checked = false;
                buscarInfractor();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }

            this.Cursor = Cursors.Arrow;
        }

        private void btnReImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                imprimirResolucion();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void imprimirResolucion()
        {
            if (dtGrWiewResoluciones.SelectedRows.Count > 0)
            {
                Funciones myFunciones = WS.Funciones();
                transferir myTransfer = new transferir();
                viewResolucionesInfractorComp myResol;
                ServiciosConfiguracionesService mySerConf = WS.ServiciosConfiguracionesService();
                String ruta;

                if (dtGrWiewResoluciones.CurrentRow != null)
                {
                    myResol = (viewResolucionesInfractorComp)myFunciones.listToviewResolucionesInfractorComp(dtGrWiewResoluciones.CurrentRow);
                    ruta = mySerConf.directorioResoluciones();
                    myTransfer.archivoDelServer(ruta + myResol.NOMBRE + ".doc");
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un comparendo.");
                dtGrWiewResoluciones.Focus();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                chBoxFiltroFecha.Checked = true;
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

        private void cmbBoxTipoDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Funciones myFun = WS.Funciones();
                myFun.lanzarTapConEnter(e);
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void dateTPickFechaInicial_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Funciones myFun = WS.Funciones();
                myFun.lanzarTapConEnter(e);
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void dateTPickFechaFinal_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Funciones myFun = WS.Funciones();
                myFun.lanzarTapConEnter(e);
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void chBoxFiltroFecha_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Funciones myFun = WS.Funciones();
                myFun.lanzarTapConEnter(e);
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
