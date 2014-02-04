using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
  using LibreriasSintrat.utilidades; 

namespace utilidades.configuracionIni
{
    public partial class FrmConfigurarAplicacion : Form
    {
        Log log = new Log();

        public FrmConfigurarAplicacion()
        {
            InitializeComponent();
            log = new Log();
        }

        private void FrmConfigurarAplicacion_Load(object sender, EventArgs e)
        {
            try
            {
                CargarDatosServiciosWeb();
                CargarDatosLog();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                WS.Funciones().mostrarMensaje("Error realizando funcionalidad. " + exp.Message, "E");
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (EsValido())
                {
                    List<ClaveIni> lista = new List<ClaveIni>();
                    lista.Add(new ClaveIni("WS_PROTOCOLO", cmbProtocolo.SelectedItem + "://"));
                    lista.Add(new ClaveIni("WS_IP", txtIp.Text));
                    lista.Add(new ClaveIni("WS_PUERTO", numPuerto.Value + ""));
                    lista.Add(new ClaveIni("WS_APP_NOMBRE", txtAplicacionNombre.Text));
                    lista.Add(new ClaveIni("CARGA_RECORDAR_RESPUESTA", chkAutoCrear.Checked ? "SI" : "NO"));
                    lista.Add(new ClaveIni("CARGA_RECARGAR_TODOS", chkRecargarTodos.Checked ? "SI" : "NO"));
                    lista.Add(new ClaveIni("CARGAR", chkAutoCrear.Checked ? "SI" : "NO"));
                    GestionConfiguracion.ActualizarValores(GestionConfiguracion.NombreArchivoIni(), lista);
                    if (chkRecargarAhora.Checked)
                    {
                        WS.RemoteAppName = txtAplicacionNombre.Text;
                        WS.RemotePort = numPuerto.Value + "";
                        WS.RemoteProtocol = cmbProtocolo.SelectedItem + "://";
                        WS.RemoteServerName = txtIp.Text;
                        WS.LimpiarServicios();
                        WS.CrearTodos();
                    }
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

        private bool EsValido()
        {
            if (txtAplicacionNombre.Text.Trim() == "")
            {
                WS.Funciones().mostrarMensaje("Nombre de la aplicación no válido", "E");
                return false;
            }
            if (txtIp.Text.Trim() == "")
            {
                WS.Funciones().mostrarMensaje("IP del servidor no válida", "E");
                return false;
            }
            string ip = "";
            int pin;
            string[] pines;
            try
            {
                pines = txtIp.Text.Split(new char[] { '.' });
                if (pines.Length != 4)
                {
                    WS.Funciones().mostrarMensaje("IP del servidor mal formada", "E");
                    return false;
                }
                for (int i = 0; i < pines.Length; i++)
                {
                    pin = int.Parse(pines[i]);
                    if (pin > 255)
                    {
                        WS.Funciones().mostrarMensaje("IP del servidor mal formada", "E");
                        return false;
                    }
                    if (i > 0) ip += ".";
                    ip += pin + "";
                }
            }
            catch(Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                WS.Funciones().mostrarMensaje("IP del servidor mal formada", "E");
                return false;
            }
            txtIp.Text = ip;
            if (cmbProtocolo.SelectedItem == null)
            {
                WS.Funciones().mostrarMensaje("Protocolo de comunicación no válido", "E");
                return false;
            }

            return true;
        }

        private void btnRestablecer_Click(object sender, EventArgs e)
        {
            try
            {
                List<ClaveIni> lista = new List<ClaveIni>();
                lista.Add(new ClaveIni("WS_PROTOCOLO", "http://"));
                lista.Add(new ClaveIni("WS_IP", "192.168.1.129"));
                lista.Add(new ClaveIni("WS_PUERTO", "8080"));
                lista.Add(new ClaveIni("WS_APP_NOMBRE", "Model"));
                lista.Add(new ClaveIni("CARGA_RECORDAR_RESPUESTA", "SI"));
                lista.Add(new ClaveIni("CARGA_RECARGAR_TODOS", "SI"));
                lista.Add(new ClaveIni("CARGAR", "NO"));
                GestionConfiguracion.ActualizarValores(GestionConfiguracion.NombreArchivoIni(), lista);
                CargarDatosServiciosWeb();
                CargarDatosLog();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                WS.Funciones().mostrarMensaje("Error realizando funcionalidad. " + exp.Message, "E");
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void CargarDatosServiciosWeb()
        {
            ClaveIni clave;
            clave = GestionConfiguracion.ConsultarValor(GestionConfiguracion.NombreArchivoIni(), new ClaveIni("WS_PROTOCOLO"));
            cmbProtocolo.SelectedItem = clave.Valor.Substring(0, clave.Valor.IndexOf(":")); ;
            clave = GestionConfiguracion.ConsultarValor(GestionConfiguracion.NombreArchivoIni(), new ClaveIni("WS_IP"));
            txtIp.Text = clave.Valor;
            clave = GestionConfiguracion.ConsultarValor(GestionConfiguracion.NombreArchivoIni(), new ClaveIni("WS_PUERTO"));
            numPuerto.Value = decimal.Parse(clave.Valor);
            clave = GestionConfiguracion.ConsultarValor(GestionConfiguracion.NombreArchivoIni(), new ClaveIni("WS_APP_NOMBRE"));
            txtAplicacionNombre.Text = clave.Valor;
            clave = GestionConfiguracion.ConsultarValor(GestionConfiguracion.NombreArchivoIni(), new ClaveIni("CARGA_RECORDAR_RESPUESTA"));
            //
            clave = GestionConfiguracion.ConsultarValor(GestionConfiguracion.NombreArchivoIni(), new ClaveIni("CARGA_RECARGAR_TODOS"));
            chkRecargarTodos.Checked = clave.Valor == "SI" ? true : false;
            clave = GestionConfiguracion.ConsultarValor(GestionConfiguracion.NombreArchivoIni(), new ClaveIni("CARGAR"));
            chkAutoCrear.Checked = clave.Valor == "SI" ? true : false;
        }

        private void CargarDatosLog()
        {
            string[] archivos = Directory.GetFiles("logs", "transporte*");
            DataTable dt = new DataTable();
            dt.Columns.Add("Archivo");
            dt.Columns.Add("Tamano");
            dt.Columns.Add("Creacion");
            DataRow dr;
            for (int i = 0; i < archivos.Length; i++)
            {
                dr = dt.NewRow();
                dr["Archivo"] = archivos[i];
                dr["Tamano"] = "0";
                dr["Creacion"] = Directory.GetCreationTime(archivos[i]).ToString("dd/MMM/yyyy HH:mm");
                dt.Rows.Add(dr);
            }
            tblLogs.DataSource = dt;
        }

        private void btnCargarLog_Click(object sender, EventArgs e)
        {
            try
            {
                if (tblLogs.SelectedCells.Count > 0)
                {
                    string archivo = tblLogs.Rows[tblLogs.SelectedCells[0].RowIndex].Cells["Archivo"].Value.ToString();
                    
                    FrmVisorLog frm = new FrmVisorLog(archivo);
                    frm.ShowDialog();
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
    }
}
