using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibreriasSintrat.ServiciosLogs;
using LibreriasSintrat.utilidades;
using LibreriasSintrat.ServiciosUsuarios;

namespace TransportePublico.utilidades
{
    public partial class frmGestionLogs : Form
    {
        ServiciosLogsService serviciosLogs;
        usuarios usuario;
        
        public frmGestionLogs(usuarios user)
        {
            InitializeComponent();
            serviciosLogs = WS.ServiciosLogsService();
            usuario = user;
        }

        private void btnVistaPrevia_Click(object sender, EventArgs e)
        {
            try
            {
                logs tmpLog = new logs();
                tmpLog.ESTADO_ANTERIOR = "1234567890";

                tmpLog.ESTADO_FINAL = "0987654321";
                tmpLog.FECHA_HORA = "22/01/2014";
                tmpLog.ID_USUARIO = usuario.ID_USUARIO;
                tmpLog.MODULO = "TPRINCIPAL";
                tmpLog.OBJETO = "PRUEBA";
                tmpLog.TIEMPO_EJECUCION = 10;
                tmpLog.TIPO_TRANSACCION = "INSERT";

                tmpLog = serviciosLogs.crearRegistroLog(tmpLog);
            }
            catch (Exception exce) 
            { 
            
            }
        }

        private void frmGestionLogs_Load(object sender, EventArgs e)
        {
            ServiciosUsuariosService servicioUsuarios = WS.ServiciosUsuariosService();
            object[] listaUsuarios = servicioUsuarios.listarUsuarios();
            Funciones funciones = new Funciones();
            cmbUsuario.DisplayMember = "LOGIN";
            cmbUsuario.ValueMember = "ID_USUARIO";
            funciones.llenarCombo(cmbUsuario, listaUsuarios);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            logs tmpLog = new logs();
            tmpLog.MODULO = cmbModulo.Text;
            tmpLog.OBJETO = cmbTablaAfectada.Text;
            tmpLog.FECHA_HORA = dtpFechaTransaccion.Value.ToString("dd/MM/yyyy");
            tmpLog.TIPO_TRANSACCION = cmbTipoTransacción.Text;
            tmpLog.ID_USUARIO = int.Parse(cmbUsuario.SelectedValue.ToString());
            object[] listaLogs = serviciosLogs.buscarLogs(tmpLog);
            Funciones funciones = new Funciones();
            dgwResultados.DataSource = funciones.ToDataTable(funciones.ObjectToArrayList(listaLogs));

        }
    }
}
