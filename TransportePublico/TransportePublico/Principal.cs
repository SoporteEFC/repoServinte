using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibreriasSintrat.ServiciosUsuarios;
using TransportePublico.servicios.tramites;
using TransportePublico.servicios.cupos;
using TransportePublico.servicios.documentos;
using TransportePublico.servicios.vehiculos;
using LibreriasSintrat.ServiciosAccesorias;
using System.Threading;
using LibreriasSintrat.utilidades;
using LibreriasSintrat.forms.commons;
using Comparendos.servicios.documentos;
using TransportePublico.servicios;
using LibreriasSintrat.ServiciosLogs;
using TransportePublico.utilidades;

using LibreriasSintrat.ServiciosErroresSW;


namespace TransportePublico
{
    public partial class FPrincipal : Form
    {
        ServiciosAccesoriasService myServAcc;
        public usuarios myUsuario;
        private Object[] myOpciones;
        Log log = new Log();
        ServiciosErroresSWService serviciosErroresSW;
        ServiciosLogsService serviciosLogs;

        public FPrincipal(usuarios user)
        {
            try
            {
                try
                {
                    //configurar WS
                    usuarios usuarioSistema;
                    FrmCargarWS frm = new FrmCargarWS(true);
                    frm.ShowDialog();
                    serviciosLogs = WS.ServiciosLogsService();
                    serviciosErroresSW = WS.ServiciosErroresSWService();
                }
                catch (Exception exp)
                {
                    log.escribirError(exp.ToString(), this.GetType());
                    MessageBox.Show("Error desconocido realizando la funcionalidad!");
                    //Console.WriteLine(Thread.CurrentThread.Name);
                    //Console.WriteLine(exp.Message);
                    //Console.WriteLine(exp.StackTrace);
                }
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }

            myServAcc = WS.ServiciosAccesoriasService();
            InitializeComponent();
            myUsuario = user;
            configurarMenu();
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
            myOpcion.MODULO = "PUBLICO";

            logs tmpLog = new logs();
            tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
            tmpLog.ID_USUARIO = myUsuario.ID_USUARIO;
            tmpLog.OBJETO = "PERFIL_OPCION";
            tmpLog.MODULO = "TPUBLICO";
            tmpLog.TIPO_TRANSACCION = "SELECT";
            TimeSpan TS; 
            DateTime dt1 = DateTime.Now;

            string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(myOpcion.GetType(),new object[]{myOpcion});
            tmpLog.ESTADO_ANTERIOR = objetoAnalizado;
            ServiciosUsuariosService mySerUsu = WS.ServiciosUsuariosService();
            
            try
            {
                myOpciones = (Object[])mySerUsu.OpcionesDePerfil(myOpcion);
            }
            catch (Exception exe)
            {
                erroresSW error = new erroresSW();
                error.ERROR = exe.Message;

                object[]listaErrores = serviciosErroresSW.buscarErroresSW(error);

                if (listaErrores != null && listaErrores.Length > 0)
                    error = (erroresSW)listaErrores[0];                
                if (error == null || error.ID_ERRORES_SW < 1)
                {
                    if (DialogResult.Yes == MessageBox.Show(this, "El error no ha sido registrado. Desea hacerlo ahora?", "Registro de error", MessageBoxButtons.YesNo))
                    {
                        FrmMostrarErrorSW frm = new FrmMostrarErrorSW(myUsuario, true, error.ERROR, -1);
                        frm.ShowDialog();
                    }
                }
                else
                {
                    FrmMostrarErrorSW frm = new FrmMostrarErrorSW(myUsuario, true, "", error.ID_ERRORES_SW);
                    frm.ShowDialog();
                }
            }

            DateTime dt2 = DateTime.Now;
            TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
            tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;                
            serviciosLogs.crearRegistroLog(tmpLog);
        }

        public bool buscarOpcion(String opcion)
        {
            perfilOpcion temp;

            if (myOpciones != null)
            {
                for (int i = 0; i < myOpciones.Length; i++)
                {
                    temp = (perfilOpcion)myOpciones[i];

                    if (temp.MODULO.ToUpper() == "PUBLICO")
                    {
                        if (opcion == temp.OPCION)
                            return true;
                    }
                }
            }
            return false;
        }

        private void cambioDeEmpresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                cambiodeempresa cambio = new cambiodeempresa(myUsuario);
                cambio.Show();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                fRoles roles = new fRoles(menuStrip1, Modulo.Transporte_Publico);
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

        private void registrarCuposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                inventariocupos invent = new inventariocupos(myUsuario);
                invent.Show();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void editarCuposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                cuposporempresa cupsemp = new cuposporempresa(myUsuario);
                cupsemp.Show();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void gestiónDeCuposToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                editarcupo editacup = new editarcupo(myUsuario);
                editacup.Show();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void gestiónDeCuposToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                gestioncupos gestioncup = new gestioncupos(myUsuario);
                gestioncup.Show();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void generarConceptoFavorableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                generarconceptofavorable generarconcepto = new generarconceptofavorable(myUsuario);
                generarconcepto.Show();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void desvinculaciónPorCambioDeServicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                desvinculacioncambiodeservicio desvinccambioserv = new desvinculacioncambiodeservicio(myServAcc,myUsuario);
                desvinccambioserv.Show();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void desvinculaciónPorComúnAcuerdoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                desvporcomunacuerdo desvcomunacuerdo = new desvporcomunacuerdo(myUsuario);
                desvcomunacuerdo.Show();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void imprimirTarjetaDeOperaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                tarjetadeoperacion tarjetaoperacion = new tarjetadeoperacion(myUsuario);
                tarjetaoperacion.Show();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void trasladoDeCuposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                trasladodecupos trasladocupos = new trasladodecupos(myUsuario);
                trasladocupos.Show();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void gestiónDePlantillasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                fPlantilla myPlantilla = new fPlantilla();
                myPlantilla.Show();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void vehículosActivosPorEmpresaDeTransporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmVehiculosActivosEmpresa activosactivos = new frmVehiculosActivosEmpresa(myUsuario);
                activosactivos.Show();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void generalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                informesgenerales generales = new informesgenerales(myUsuario);
                generales.Show();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        /*private void vidaUtilVehículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                vidautilporvehiculo vidautil = new vidautilporvehiculo();
                vidautil.Show();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }*/

        private void tarjetaDeOperaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                tarjetadeoperacion tarjeta = new tarjetadeoperacion(myUsuario);
                tarjeta.Show();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void FPrincipal_Load(object sender, EventArgs e)
        {
            
        }

        void usuarioToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            try
            {
                fUsuario usuarios = new fUsuario(myUsuario, false);
                usuarios.Show();
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
                fUsuarios usuarios = new fUsuarios(myUsuario);
                usuarios.Show();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void inventarioDeCuposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void empresasDeServicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void inventarioDeCuposToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmInventarioCupos frminvcupos = new FrmInventarioCupos(myUsuario);//ListarCupos lcupos = new ListarCupos();
            frminvcupos.Show();
        }

        private void rangosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmInventarioRango frmInventariorango = new FrmInventarioRango(myUsuario);
            frmInventariorango.Show();
        }

        private void administracionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void crearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEmpresaServicio frmEmpresaServicio = new FrmEmpresaServicio(0,myUsuario);
            frmEmpresaServicio.btnBuscar.Visible = false;
            frmEmpresaServicio.Show();
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEmpresaServicio frmEmpresaServicio = new FrmEmpresaServicio(1,myUsuario);
            frmEmpresaServicio.Show();
        }

        private void gestiónPersonasToolStripMenuItem_Click(object sender, EventArgs e)
        {         
            try
            {
                LibreriasSintrat.forms.commons.FPersona fpersona = new LibreriasSintrat.forms.commons.FPersona();
                fpersona.Show();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(),this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad!");
            }
        }

        private void generarCertificadoDeInformaciónVehículoDeTransportePúblicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmCertificadoInformacionVehiculo certificadoInformacionVehiculo = new frmCertificadoInformacionVehiculo(myUsuario);
                certificadoInformacionVehiculo.Show();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void erroresSWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGestionErroresSW frm = new FrmGestionErroresSW(myUsuario);
            frm.Show();
        }

        private void gestiónLogsSWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGestionLogs frm = new frmGestionLogs(myUsuario);
            frm.Show();
        }
    }
}
