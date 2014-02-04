using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
  using LibreriasSintrat.utilidades; 

namespace utilidades.configuracionIni
{
    public partial class FrmVisorLog : Form
    {
        string archivo;
        Log log = new Log();

        public FrmVisorLog(string archivo)
        {
            InitializeComponent();
            this.archivo = archivo;
            log = new Log();
        }

        private void FrmVisorLog_Load(object sender, EventArgs e)
        {
            try
            {
                //cerrar stream
                Console.Out.Close();
                ArrayList lista = GestionArchivo.Leer(archivo);
                //reabrir stream
                System.IO.TextWriter log = null;
                string directory = "logs\\";
                string fileName = directory + "transporte-" + DateTime.Now.ToString("yyyy.MM.dd") + ".log";
                if (!System.IO.Directory.Exists(directory))
                    System.IO.Directory.CreateDirectory(directory);
                log = new System.IO.StreamWriter(fileName, true);
                Console.SetOut(log);
                Console.WriteLine("Inicia aplicacion");

                txtTexto.Text = "";
                for (int i = 0; i < lista.Count; i++)
                {
                    txtTexto.Text += lista[i].ToString() + "\r\n";
                }
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                WS.Funciones().mostrarMensaje("Error realizando funcionalidad. " + exp.Message, "E");
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = DialogResult.Cancel;
                this.Close();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                WS.Funciones().mostrarMensaje("Error realizando funcionalidad. " + exp.Message, "E");
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }
    }
}
