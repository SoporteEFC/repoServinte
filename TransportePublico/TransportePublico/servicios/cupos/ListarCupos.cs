using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibreriasSintrat.ServiciosCuposTrans;
using LibreriasSintrat.utilidades;
using LibreriasSintrat.ServiciosLogs;
using LibreriasSintrat.ServiciosUsuarios;
using TransportePublico.utilidades;
using LibreriasSintrat.utilidades;

namespace TransportePublico.servicios.cupos
{
    public partial class ListarCupos : Form
    {
        ServiciosCuposTransService clienteCuposTrans;
        ServiciosLogsService serviciosLogs;
        usuarios usuarioSistema;


        public ListarCupos(usuarios user)
        {
            clienteCuposTrans = WS.ServiciosCuposTransService();
            InitializeComponent();
            usuarioSistema = user;
            serviciosLogs = WS.ServiciosLogsService();
        }

        private void ListarCupos_Load(object sender, EventArgs e)
        {
            tipoVehiculoTrans tipo = new tipoVehiculoTrans();
            
            Funciones funciones = WS.Funciones();

            logs tmpLog = new logs();
            tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
            tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
            tmpLog.OBJETO = "TIPOVEHICULO";
            tmpLog.MODULO = "TPUBLICO";
            tmpLog.TIPO_TRANSACCION = "SELECT";
            TimeSpan TS;
            DateTime dt1 = DateTime.Now;

            string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(tipo.GetType(), new object[] { tipo });
            tmpLog.ESTADO_ANTERIOR = objetoAnalizado;

            Object[] listat = (Object[])clienteCuposTrans.getTipoVehiculoTrans(tipo);

            DateTime dt2 = DateTime.Now;
            TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
            tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;
            serviciosLogs.crearRegistroLog(tmpLog);

            if (listat != null && listat.Length > 0)
            {
                cmbTioVehiculo.DataSource = null;
                cmbTioVehiculo.DisplayMember = "NOMBRE";
                cmbTioVehiculo.ValueMember = "ID";
                funciones.llenarCombo(cmbTioVehiculo, listat);
                cmbTioVehiculo.SelectedIndex = -1;
            }
        }

        private void btnBuscarCupos_Click(object sender, EventArgs e)
        {
            object[] listaCupos;
            inventariocupos tmpCupo = new inventariocupos(usuarioSistema);
        }
    }
}
