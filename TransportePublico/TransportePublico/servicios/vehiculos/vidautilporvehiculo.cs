using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibreriasSintrat.ServiciosCuposTrans;
using TransportePublico.servicios.reportes;
using TransportePublico.servicios.reportes.vidaUtilVehiculo;
using LibreriasSintrat.utilidades;
using LibreriasSintrat.ServiciosLogs;
using LibreriasSintrat.ServiciosUsuarios;
using TransportePublico.utilidades; 

namespace TransportePublico.servicios.vehiculos
{
    public partial class vidautilporvehiculo : Form
    {
        ServiciosLogsService serviciosLogs;
        usuarios usuarioSistema;
        ServiciosCuposTransService clienteCuposTrans;
        Object[] listavidautil = null;
        Log log = new Log();

        public vidautilporvehiculo(usuarios user)
        {
            usuarioSistema = user;
            serviciosLogs = WS.ServiciosLogsService();
            
            InitializeComponent();
            clienteCuposTrans = WS.ServiciosCuposTransService();
            log = new Log();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void vidautilporvehiculo_Load(object sender, EventArgs e)
        {
            btninformevehiculos.Enabled = false;
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

            if (listat != null)
            {
                tipovehiculo.DataSource = null;
                tipovehiculo.DisplayMember = "NOMBRE";
                tipovehiculo.ValueMember = "NOMBRE";
                funciones.llenarCombo(tipovehiculo, listat);
            }
        }

        private void btnSearchVehiculos_Click(object sender, EventArgs e)
        {
            validaciones();
        }

        private void validaciones()
        {
            if (tipovehiculo.SelectedIndex < 0)
            {
                MessageBox.Show("Debe Seleccionar un tipo de Vehículo","Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
                tipovehiculo.Focus();
            }
            else
            {
                buscarVidaUtil();
            }
        }

        private void buscarVidaUtil()
        {
            
            viewVidaUtilVehiculoTrans vidautil = new viewVidaUtilVehiculoTrans();
            vidautil.TIPODEVEHICULO = tipovehiculo.SelectedValue.ToString();

            logs tmpLog = new logs();
            tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
            tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
            tmpLog.OBJETO = "VIEW_VIDAUTIL_VEHICULO";
            tmpLog.MODULO = "TPUBLICO";
            tmpLog.TIPO_TRANSACCION = "SELECT";
            TimeSpan TS;
            DateTime dt1 = DateTime.Now;

            string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(vidautil.GetType(), new object[] { vidautil });
            tmpLog.ESTADO_ANTERIOR = objetoAnalizado;

            listavidautil = clienteCuposTrans.getSViewVidaUtilVehiculo(vidautil);

            DateTime dt2 = DateTime.Now;
            TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
            tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;
            serviciosLogs.crearRegistroLog(tmpLog);

            if (listavidautil != null && listavidautil.Length > 0)
            {
                mostrarVidaUtil();
                btninformevehiculos.Enabled = true;
            }
            else
            {
                MessageBox.Show("No se encontró información","Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
                grillavehiculos.DataSource = null;
                btninformevehiculos.Enabled = false;
            }
        }

        private void mostrarVidaUtil()
        {
            Funciones funciones = WS.Funciones();
            DataTable dt = new DataTable();
            ArrayList Campos = new ArrayList();
            Campos.Add("ANUMEROCUPO = NÚMERO_DEL_CUPO");
            Campos.Add("BEMPRESAASOCIADA = EMPRESA_DE_SERVICIO_ASOCIADA");
            Campos.Add("CPLACA = PLACA_DE_VEHÍCULO");
            Campos.Add("DVIDAUTIL = VIDA_UTIL_DE_VEHÍCULO");
            try
            {
                dt = funciones.ToDataTable(funciones.ObjectToArrayList(listavidautil));
            }
            catch (Exception e) {
                log.escribirError(e.ToString(), this.GetType());
            }
            grillavehiculos.DataSource = dt;
            if (dt.Rows.Count > 0)
                funciones.configurarGrilla(grillavehiculos, Campos);
            dt = null;
            Campos = null;
        }

        private void btninformevehiculos_Click(object sender, EventArgs e)
        {
            VerReporteVidaUtil visor = new VerReporteVidaUtil(grillavehiculos);
            visor.ShowDialog();
        }

        private void tipovehiculo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones myFun = new Funciones();
            myFun.lanzarTapConEnter(e);
        }
    }
}
