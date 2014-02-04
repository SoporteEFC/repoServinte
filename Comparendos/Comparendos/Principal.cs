using System; using TransitoPrincipal; using LibreriasSintrat.utilidades;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibreriasSintrat.ServiciosUsuarios;
using Comparendos.servicios.generales;
using Comparendos.servicios.administracion;
using Comparendos.servicios.documentos;
using Comparendos.servicios.liquidacion;
using Comparendos.servicios.reportes;
using LibreriasSintrat.ServiciosAccesoriasComp;
using Comparendos.utilidades; using LibreriasSintrat.utilidades; using LibreriasSintrat;
using Comparendos.servicios.Coativos;
using Comparendos.servicios.documentos;
using LibreriasSintrat.forms.commons;
using LibreriasSintrat.forms.comparendos;

namespace Comparendos
{
    public partial class FPrincipal : Form
    {
        public ServiciosAccesoriasCompService serviciosAccesoriasComp;
        public usuarios myUsuario;
        private Object[] myOpciones;
        Log log = new Log();
        Funciones funciones;


        public FPrincipal(usuarios user)
        {
            funciones = new Funciones();
            InitializeComponent();
            FrmCargarWS frm = new FrmCargarWS(true);
            frm.ShowDialog();
            serviciosAccesoriasComp = WS.ServiciosAccesoriasCompService();
            myUsuario = user;
            configurarMenu();
            log = new Log();
            this.BackColor = Color.White;
        }

        private void FPrincipal_Load(object sender, EventArgs e)
        {
            MdiClient ctlMDI = new MdiClient();

            foreach (Control ctl in this.Controls)
            {
                try
                {
                    ctlMDI = (MdiClient)ctl;
                    ctlMDI.BackColor = Color.White;
                }
                catch (InvalidCastException exc)
                {
                    
                }
            }
            
            try
            {
                //configurar WS               
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void configurarMenu()
        {
            cargarOpciones();
            System.Collections.IEnumerator ie;
            ie = menuStrip1.Items.GetEnumerator();
            while (ie.MoveNext())
                hablitarOpciones((ToolStripItem)ie.Current);
        }

        private void hablitarOpciones(ToolStripItem item)
        {
            try
            {
                if (item.GetType().Equals(typeof(ToolStripMenuItem)))
                {
                    if (!buscarOpcion(item.Text))
                        item.Visible = false;
                    System.Collections.IEnumerator ie = ((ToolStripMenuItem)item).DropDownItems.GetEnumerator();
                    while (ie.MoveNext())
                        hablitarOpciones((ToolStripItem)ie.Current);
                }
            }
            catch (Exception ee)
            {
                log.escribirError(ee.ToString(), this.GetType());
                MessageBox.Show("Error: ", ee.ToString());
            }
        }

        public void cargarOpciones()
        {
            perfilOpcion myOpcion = new perfilOpcion();
            myOpcion.ID_PERFIL = myUsuario.ID_PERFIL;
            myOpcion.MODULO = "COMPARENDOS";
            ServiciosUsuariosService mySerUsu = WS.ServiciosUsuariosService();
            myOpciones = (Object[])mySerUsu.OpcionesDePerfil(myOpcion);
        }

        public bool buscarOpcion(String opcion)
        {
            perfilOpcion temp;
            if (myOpciones != null)
            {
                for (int i = 0; i < myOpciones.Length; i++)
                {
                    temp = (perfilOpcion)myOpciones[i];
                    if (temp.MODULO.ToUpper() == "COMPARENDOS")
                    {
                        if (opcion == temp.OPCION)
                            return true;
                    }
                }
            }
            return false;
        }

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                fRoles roles = new fRoles(menuStrip1, Modulo.Comparendos);
                roles.MdiParent = this;
                roles.Show();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void modificarComparendoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                fGestionComparendo comparendos = new fGestionComparendo(true, myUsuario, serviciosAccesoriasComp);
                comparendos.MdiParent = this;
                comparendos.Show();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void asignarComparenderasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                asignarcomparendera aisnacomparendera = new asignarcomparendera();
                aisnacomparendera.MdiParent = this;
                aisnacomparendera.Show();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void crearRangoComparendoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmCrearRangoComparendos newrango = new FrmCrearRangoComparendos(serviciosAccesoriasComp);
                newrango.MdiParent = this;
                newrango.Show();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void buscarComparenderasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                buscarcomparenderas buscacopm = new buscarcomparenderas(myUsuario);
                buscacopm.MdiParent = this;
                buscacopm.Show();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void configurarInfraccionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                configurarinfracciones confinfrac = new configurarinfracciones();
                confinfrac.MdiParent = this;
                confinfrac.Show();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void imposicionPorInfractorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void reesolucionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                fConsultaResoluciones myConsulResol = new fConsultaResoluciones();
                myConsulResol.MdiParent = this;
                myConsulResol.Show();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void crearComparendoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                fGestionComparendo comparendos = new fGestionComparendo(false, myUsuario, serviciosAccesoriasComp);
                comparendos.MdiParent = this;
                comparendos.Show();
                this.Cursor = Cursors.Arrow;
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                fUsuarios myFUsuarios = new fUsuarios(myUsuario);
                myFUsuarios.MdiParent = this;
                myFUsuarios.Show();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void acuerdosDePagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                fAcuerdoPago myAcuerPag = new fAcuerdoPago(myUsuario);
                myAcuerPag.MdiParent = this;
                myAcuerPag.Show();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void pagarFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PagarFactura frm = new PagarFactura("", myUsuario);
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void anularPagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PagarFactura frm = new PagarFactura("", myUsuario, AccionBuscarFactura.Anular);
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void generarPlanosSimitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                fArchivosPlanos archivosPlanos = new fArchivosPlanos();
                archivosPlanos.MdiParent = this;
                archivosPlanos.Show();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }


        private void gestionarAgentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                fGestionAgentes gestionAgentes = new fGestionAgentes(serviciosAccesoriasComp);
                gestionAgentes.MdiParent = this;
                gestionAgentes.Show();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void reportesGeneralesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                fReportesGenerales myRepGen = new fReportesGenerales(myUsuario);
                myRepGen.MdiParent = this;
                myRepGen.Show();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void liquidaciónComparendoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                LiquidacionComparendos frm = new LiquidacionComparendos(myUsuario);
                frm.MdiParent = this;
                frm.Show();
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

        private void coToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                administradortarifas frm = new administradortarifas(myUsuario);
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void gestionInfractorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                fInfractor frmInfractor = new fInfractor();
                frmInfractor.MdiParent = this;
                frmInfractor.Show();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void gestionVehiculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                fVehiculos frmVehiculo = new fVehiculos();
                frmVehiculo.MdiParent = this;
                frmVehiculo.Show();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
            }
        }

        private void consultarComparendoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                fConsultarComparendo frmConsultar = new fConsultarComparendo(false, myUsuario, serviciosAccesoriasComp);
                frmConsultar.MdiParent = this;
                frmConsultar.Show();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void anularComparendoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                anularcomparendo frmanular = new anularcomparendo(myUsuario, serviciosAccesoriasComp);
                frmanular.MdiParent = this;
                frmanular.Show();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        void auditoriaToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            try
            {
                fAuditoria myAudit = new fAuditoria();
                myAudit.MdiParent = this;
                myAudit.Show();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        void cancelaranulacionComparendoToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            try
            {
                FrmCancelacionAnulacion myFCancelAnul = new FrmCancelacionAnulacion(myUsuario, serviciosAccesoriasComp);
                myFCancelAnul.MdiParent = this;
                myFCancelAnul.Show();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        void buscarFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //fBuscarFactura frmBuscar = new fBuscarFactura("", myUsuario, AccionBuscarFactura.Buscar);
                BuscarFactura frmBuscar = new BuscarFactura(myUsuario);
                frmBuscar.MdiParent = this;
                frmBuscar.Show();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        void registrarPagoSimitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                fPagosSimit myPagoSimit = new fPagosSimit(myUsuario);
                myPagoSimit.MdiParent = this;
                myPagoSimit.Show();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        void eliminarAcuerdoDePagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmEliminarAcuerdoPago myFrmEliminar = new FrmEliminarAcuerdoPago();
                myFrmEliminar.MdiParent = this;
                myFrmEliminar.Show();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        void acuerdosDePagoPorInfractorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmAcuerdoPagoPorInfractor myFrmAcuerdos = new FrmAcuerdoPagoPorInfractor();
                myFrmAcuerdos.MdiParent = this;
                myFrmAcuerdos.Show();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        void configuracionTransitoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmConfiguracionSecretariaTransito frmConfig = new FrmConfiguracionSecretariaTransito(serviciosAccesoriasComp);
                frmConfig.MdiParent = this;
                frmConfig.Show();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        void usuarioToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            try
            {
                fUsuario frmUsuario = new fUsuario(myUsuario,false);
                frmUsuario.MdiParent = this;
                frmUsuario.Show();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        void ConsultarInfractorToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                FrmCoativos frmCoactivo = new FrmCoativos();
                frmCoactivo.MdiParent = this;
                frmCoactivo.Show();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType()); 
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        
        }

        private void comparendosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void expedienteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void resolucionesPorRangoFechasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void plantillasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                fPlantilla myFrmPlantilla = new fPlantilla();
                myFrmPlantilla.MdiParent = this;
                myFrmPlantilla.Show();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void imposiciónInfractorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                ResolImpoInfrac myFrmResoImpoInfra = new ResolImpoInfrac(myUsuario);
                myFrmResoImpoInfra.MdiParent = this;
                myFrmResoImpoInfra.Show();
                this.Cursor = Cursors.Arrow;
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void cambioCódigoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                ResolCambioCodigo myResCamCod = new ResolCambioCodigo(myUsuario);
                myResCamCod.MdiParent = this;
                myResCamCod.Show();
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

        private void prescripciónInfractorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                ResolPrescInfrac myResPresInfra = new ResolPrescInfrac(myUsuario);
                myResPresInfra.MdiParent = this;
                myResPresInfra.Show();
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

        private void exoneraciónInfractorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {                
                ResolExonInfrac myResolExonInf = new ResolExonInfrac(myUsuario);
                myResolExonInf.MdiParent = this;
                myResolExonInf.Show();               
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

        //private void exoneraciónFallecemientoToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ResolExonFalleci myResolExonFalle = new ResolExonFalleci(myUsuario);
        //        myResolExonFalle.MdiParent = this;
        //        myResolExonFalle.Show();
        //    }
        //    catch (Exception exp)
        //    {
        //        log.escribirError(exp.ToString(), this.GetType());
        //        MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
        //        //Console.WriteLine(exp.Message);
        //        //Console.WriteLine(exp.StackTrace);
        //    }
        //}

        //private void exoneraciónInconsistenciaToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ResolExonInconsis myResExonIncon = new ResolExonInconsis(myUsuario);
        //        myResExonIncon.MdiParent = this;
        //        myResExonIncon.Show();
        //    }
        //    catch (Exception exp)
        //    {
        //        log.escribirError(exp.ToString(), this.GetType());
        //        MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
        //        //Console.WriteLine(exp.Message);
        //        //Console.WriteLine(exp.StackTrace);
        //    }
        //}

        private void masivasRangoFechasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {                
                fGenerarResolucionFecha frmGRF = new fGenerarResolucionFecha(myUsuario);
                frmGRF.MdiParent = this;
                frmGRF.Show();                
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

        private void tsmGenerarResolucion_Click(object sender, EventArgs e)
        {

        }

        private void numResolucionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                fVigenciasNumResoluciones frmVigenciasNumResoluciones = new fVigenciasNumResoluciones();
                frmVigenciasNumResoluciones.MdiParent = this;
                frmVigenciasNumResoluciones.Show();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void revocatoriaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                ResolRevocatoria myFrmResolucionRevocatoria = new ResolRevocatoria(myUsuario);
                myFrmResolucionRevocatoria.MdiParent = this;
                myFrmResolucionRevocatoria.Show();
                this.Cursor = Cursors.Arrow;
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void importarArchivosPlanosSimitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cargarPlanosSimitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fCargarPlanosSimit cargarPlanosSimit = new fCargarPlanosSimit(myUsuario);
            cargarPlanosSimit.MdiParent = this;
            cargarPlanosSimit.Show();
        }


        
        //private void toolStripMenuItem4_Click(object sender, EventArgs e)
        //{
        //    Help.ShowPopup(this, "AYUDA", new Point(0, 0));
        //    Help.ShowHelp(this, "E:\\Repositorio\\TransitoCSharp\\Comparendos\\Manual Usuario\\comparendos.hhp", txtComando.Text);
        //}

        //private void tsmBuscar_Click(object sender, EventArgs e)
        //{
        //    Help.ShowHelp(this, "E:\\help\\transito-principal.chm",txtComando.Text);
        //}

        
    }
}
