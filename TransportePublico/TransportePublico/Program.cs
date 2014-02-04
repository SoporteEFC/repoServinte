using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LibreriasSintrat.ServiciosUsuarios;
  using LibreriasSintrat.utilidades;
using LibreriasSintrat.forms.commons;
using LibreriasSintrat.ServiciosConfiguraciones; 

namespace TransportePublico
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Log log = new Log();
            log.escribir("Inicia aplicacion");

                usuarios myUsuario;
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                try
                {
                    FrmCargarWS.ConfgurarWSRemote();
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Error configurando inicialmente los servicios web. " + exp.Message);
                    Console.WriteLine(exp.Message);
                    Console.WriteLine(exp.StackTrace);
                }
                inicio frmLogin = new inicio(Modulo.Transporte_Publico);
                
                if (frmLogin.ShowDialog() == DialogResult.OK)
                {
                    myUsuario = frmLogin.myUser;
                    log.escribir("Ingreso como usuario ID: " + myUsuario.ID_USUARIO.ToString());
                    if (myUsuario != null && myUsuario.ID_USUARIO > 0)
                        Application.Run( new FPrincipal(myUsuario));
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
            //}
            //catch (Exception exp)
            //{
            //    MessageBox.Show("Error inesperado en un proceso de la aplicación. LA APLICACIÓN SE CERRARÁ");
            //    Console.WriteLine(exp.InnerException);
            //    Console.WriteLine(exp.Message);
            //    Console.WriteLine(exp.StackTrace);
            //}
            //finally
            //{
            //    CerrarConsoleLog(ref log);

            //}
        }

    }
}
