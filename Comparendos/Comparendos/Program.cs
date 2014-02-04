using System; using TransitoPrincipal; using LibreriasSintrat.utilidades;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LibreriasSintrat.ServiciosUsuarios;
using Comparendos.servicios.generales;
using Comparendos.utilidades; using LibreriasSintrat;
using LibreriasSintrat.forms.commons;

namespace Comparendos
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*try
            {*/
            
                Log log = new Log();
                log.escribir("Inicia aplicacion");
                usuarios myUsuario;
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                try
                {
                    LibreriasSintrat.forms.commons.FrmCargarWS.ConfgurarWSRemote();
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Error configurando inicialmente los servicios web. " + exp.Message);
                    Console.WriteLine(exp.Message);
                    Console.WriteLine(exp.StackTrace);
                }

                inicio frmLogin = new inicio(Tema.ServiciosIntegrales,Modulo.Comparendos);
                if (frmLogin.ShowDialog() == DialogResult.OK)
                {
                    myUsuario = frmLogin.myUser;
                    WS.MyUsuario = myUsuario;
                    if (myUsuario != null && myUsuario.ID_USUARIO > 0)
                        Application.Run(new FPrincipal(myUsuario));
                    else
                    {
                        log.escribir("Salida de aplicación, por maximo de intentos con datos incorrectos.");
                        return;
                    }
                }
                else
                {
                    log.escribir("Cancelación de ingreso a la aplicación por petición del usuario");
                    return;
                }
                log.escribir("Cierre de aplicación");
            /*}
            catch (Exception exp)
            {
                MessageBox.Show("Error inesperado en un proceso de la aplicación. LA APLICACIÓN SE CERRARÁ");
                Console.WriteLine(exp.InnerException);
                Console.WriteLine(exp.Message);
                Console.WriteLine(exp.StackTrace);
            }
            finally
            {
                CerrarConsoleLog(ref log);
            }*/
        }
    }
}
