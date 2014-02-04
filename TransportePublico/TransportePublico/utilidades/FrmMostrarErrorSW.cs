using LibreriasSintrat.ServiciosUsuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibreriasSintrat.ServiciosLogs;
using LibreriasSintrat.ServiciosUsuarios;
using TransportePublico.utilidades;
using LibreriasSintrat.ServiciosErroresSW;
using LibreriasSintrat.utilidades;

namespace TransportePublico.utilidades
{
    public partial class FrmMostrarErrorSW : Form
    {
        bool esNuevoRegistro;
        ServiciosLogsService serviciosLogs;
        usuarios usuarioSistema;
        ServiciosErroresSWService serviciosErroresSW;
        string excepcionSW;
        int idErrorSw;
        erroresSW ErrorSW;

        public FrmMostrarErrorSW(usuarios user, bool nuevoResgistro, string excepcion, int id)
        {
            InitializeComponent();
            usuarioSistema = user;
            serviciosLogs = WS.ServiciosLogsService();
            serviciosErroresSW = WS.ServiciosErroresSWService();
            esNuevoRegistro = nuevoResgistro;
            excepcionSW = excepcion;
            idErrorSw = id;
            txtExcepcion.Text = excepcion;
        }

        private void FrmMostrarErrorSW_Load(object sender, EventArgs e)
        {
            if (!esNuevoRegistro && idErrorSw > 0)
            {
                erroresSW tmpError = new erroresSW();
                tmpError.ID_ERRORES_SW = idErrorSw;

                logs tmpLog = new logs();
                tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
                tmpLog.OBJETO = "ERRORES_SW";
                tmpLog.MODULO = "TPUBLICO";
                tmpLog.TIPO_TRANSACCION = "DELETE";
                TimeSpan TS;
                DateTime dt1 = DateTime.Now;


                string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(tmpError.GetType(), new object[] { tmpError});
                tmpLog.ESTADO_ANTERIOR = objetoAnalizado;

                if (serviciosErroresSW.eliminarErrorSW(tmpError))
                {
                    DateTime dt2 = DateTime.Now;
                    TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
                    tmpLog.TIEMPO_EJECUCION = TS.Seconds;
                    serviciosLogs.crearRegistroLog(tmpLog);

                    MessageBox.Show("Error de Servicios Web ELIMINADO correctamente");
                }
                else
                {
                    MessageBox.Show("Error de servicios Web NO ELIMINADO.");
                }
                this.Close();
            }
            else
            {

                if (esNuevoRegistro)
                {
                    txtExcepcion.ReadOnly = false;
                    txtMensajeAmigable.ReadOnly = false;
                    txtPosibleSolucion.ReadOnly = false;
                    txtDescripcionRapida.ReadOnly = false;
                    cmbTipoServicio.Enabled = false;
                }
                else
                {
                    txtExcepcion.ReadOnly = true;
                    txtMensajeAmigable.ReadOnly = true;
                    txtPosibleSolucion.ReadOnly = true;
                    txtMensajeAmigable.ReadOnly = true;
                    txtDescripcionRapida.ReadOnly = true;
                    cmbTipoServicio.Enabled = true;
                }
                txtExcepcion.Text = excepcionSW;
                if (idErrorSw != null && idErrorSw > 0)
                {
                    ErrorSW = new erroresSW();
                    ErrorSW.ID_ERRORES_SW = idErrorSw;
                    try
                    {
                        logs tmpLog = new logs();
                        tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                        tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
                        tmpLog.OBJETO = "ERRORES_SW";
                        tmpLog.MODULO = "TPUBLICO";
                        tmpLog.TIPO_TRANSACCION = "SELECT";
                        TimeSpan TS;
                        DateTime dt1 = DateTime.Now;

                        string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(ErrorSW.GetType(), new object[] { ErrorSW });
                        tmpLog.ESTADO_ANTERIOR = objetoAnalizado;


                        ErrorSW = (erroresSW)(serviciosErroresSW.buscarErroresSW(ErrorSW))[0];

                        DateTime dt2 = DateTime.Now;
                        TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
                        tmpLog.TIEMPO_EJECUCION = TS.Seconds;
                        serviciosLogs.crearRegistroLog(tmpLog);

                        txtDescripcionRapida.Text = ErrorSW.NOMBRE;
                        txtExcepcion.Text = ErrorSW.ERROR;
                        txtMensajeAmigable.Text = ErrorSW.DESCRIPCION;
                        txtPosibleSolucion.Text = ErrorSW.SUGERENCIA;
                    }
                    catch (Exception excep)
                    { }
                }
            }
        }

        private bool validarCampos()
        {

            if (txtDescripcionRapida.Text.Equals(string.Empty))
            {
                MessageBox.Show("El campo Descripción Rápida es obligatorio.");
                txtDescripcionRapida.Focus();
                return false;
            }
            if (txtExcepcion.Text.Equals(string.Empty))
            {
                MessageBox.Show("El campo excepción es obligatorio.");
                txtExcepcion.Focus();
                return false;
            }
            if (txtMensajeAmigable.Text.Equals(string.Empty))
            {
                MessageBox.Show("El campo Mensaje de error amigable es obligatorio.");
                txtMensajeAmigable.Focus();
                return false;
            }
            if (txtPosibleSolucion.Text.Equals(string.Empty))
            {
                MessageBox.Show("El campo posible solucion es obligatorio.");
                txtPosibleSolucion.Focus();
                return false;
            }
            return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                erroresSW tmpError = new erroresSW();
                tmpError.ERROR = txtExcepcion.Text;
                tmpError.DESCRIPCION = txtMensajeAmigable.Text;
                tmpError.SUGERENCIA = txtPosibleSolucion.Text;
                tmpError.NOMBRE = txtDescripcionRapida.Text;

                if (esNuevoRegistro && (idErrorSw == null || idErrorSw < 1))
                {
                    logs tmpLog = new logs();
                    tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                    tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
                    tmpLog.OBJETO = "ERRORES_SW";
                    tmpLog.MODULO = "TPUBLICO";
                    tmpLog.TIPO_TRANSACCION = "INSERT";
                    TimeSpan TS;
                    DateTime dt1 = DateTime.Now;

                    string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(tmpError.GetType(), new object[] { tmpError });
                    tmpLog.ESTADO_ANTERIOR = objetoAnalizado;

                    tmpError = serviciosErroresSW.crearRegistroErroresSW(tmpError);

                    DateTime dt2 = DateTime.Now;
                    TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
                    tmpLog.TIEMPO_EJECUCION = TS.Seconds;
                    serviciosLogs.crearRegistroLog(tmpLog);

                    if (tmpError != null && tmpError.ID_ERRORES_SW > 0)
                        MessageBox.Show("Error de servicio web registrado con exito");
                    else
                        MessageBox.Show("Error de servicio web NO REGISTRADO");
                }
                else
                {
                    tmpError.ID_ERRORES_SW = idErrorSw;

                    erroresSW tmpErrorOld = (erroresSW)(serviciosErroresSW.buscarErroresSW(new erroresSW() { ID_ERRORES_SW=idErrorSw}))[0];

                    logs tmpLog = new logs();
                    tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                    tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
                    tmpLog.OBJETO = "ERRORES_SW";
                    tmpLog.MODULO = "TPUBLICO";
                    tmpLog.TIPO_TRANSACCION = "UPDATE";
                    TimeSpan TS;
                    DateTime dt1 = DateTime.Now;

                    string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(tmpErrorOld.GetType(), new object[] { tmpErrorOld  });
                    tmpLog.ESTADO_ANTERIOR = objetoAnalizado;

                    string objetoAnalizado1 = AnalizadorDeObjetos.analizarObjeto(tmpError.GetType(), new object[] { tmpError });
                    tmpLog.ESTADO_FINAL = objetoAnalizado1;                        
                    
                    tmpError = serviciosErroresSW.actualizarErrorSW(tmpError);

                    DateTime dt2 = DateTime.Now;
                    TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
                    tmpLog.TIEMPO_EJECUCION = TS.Seconds;
                    serviciosLogs.crearRegistroLog(tmpLog);

                    
                    if (tmpError != null && tmpError.ID_ERRORES_SW > 0)
                    {
                        MessageBox.Show("Error de Servicios Web EDITADO correctamente");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("NO SE EDITO el Error de Servicios Web");
                        this.Close();
                    }
                }
                this.Close();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
