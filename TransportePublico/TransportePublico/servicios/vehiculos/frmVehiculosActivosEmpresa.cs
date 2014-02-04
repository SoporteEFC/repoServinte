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
using TransportePublico.servicios.reportes.vehiculosActivosporEmpresa;
using TransportePublico;
using LibreriasSintrat.utilidades; 
using LibreriasSintrat.utilidades;
using TransitoPrincipal;
using LibreriasSintrat.ServiciosLogs;
using LibreriasSintrat.ServiciosUsuarios;
using TransportePublico.utilidades; 


namespace TransportePublico.servicios.vehiculos
{
    public partial class frmVehiculosActivosEmpresa : Form
    {
        ServiciosLogsService serviciosLogs;
        usuarios usuarioSistema;
        ServiciosCuposTransService clienteCuposTrans;
        empresasdeServicioTrans newempresa;
        Funciones funciones;
        Log log = new Log();

        public frmVehiculosActivosEmpresa(usuarios user)
        {
            usuarioSistema = user;
            serviciosLogs = WS.ServiciosLogsService();
            InitializeComponent();
            funciones = WS.Funciones();
            log = new Log();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void vehiculosactivosempresa_Load(object sender, EventArgs e)
        {
            logs tmpLog = new logs();
            tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
            tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
            tmpLog.OBJETO = "TIPOVEHICULO";
            tmpLog.MODULO = "TPUBLICO";
            tmpLog.TIPO_TRANSACCION = "SELECT";
            TimeSpan TS;
            DateTime dt1 = DateTime.Now;

            btnInformeVehiculos.Enabled = false;
            tipoVehiculoTrans tipo = new tipoVehiculoTrans();
            clienteCuposTrans = WS.ServiciosCuposTransService();
            Funciones funciones = WS.Funciones();

            string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(tipo.GetType(), new object[] { tipo });
            tmpLog.ESTADO_ANTERIOR = objetoAnalizado;

            Object[] listat = (Object[])clienteCuposTrans.getTipoVehiculoTrans(tipo);

            DateTime dt2 = DateTime.Now;
            TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
            tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;
            serviciosLogs.crearRegistroLog(tmpLog);

            if (listat != null)
            {
                cmbTipoVehiculo.DataSource = null;
                cmbTipoVehiculo.DisplayMember = "NOMBRE";
                cmbTipoVehiculo.ValueMember = "ID";
                funciones.llenarCombo(cmbTipoVehiculo, listat);
            }
            btnBuscarEmpresa.Focus();
        }

        private void btnbuscarempresa_Click(object sender, EventArgs e)
        {
            buscarEmpresa();
            cmbTipoVehiculo.Focus();
        }

        public void buscarEmpresa()
        {
            logs tmpLog = new logs();
            tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
            tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
            tmpLog.OBJETO = "EMPRESASDESERVICIO";
            tmpLog.MODULO = "TPUBLICO";
            tmpLog.TIPO_TRANSACCION = "SELECT";
            TimeSpan TS;
            DateTime dt1 = DateTime.Now;

            clienteCuposTrans = WS.ServiciosCuposTransService();
            empresasdeServicioTrans empresa = new empresasdeServicioTrans();
            newempresa = new empresasdeServicioTrans();
            Funciones funciones = WS.Funciones();
            ArrayList Campos = new ArrayList();
            Campos.Add("NIT = NIT");
            Campos.Add("NOMBRE = NOMBRE");

            string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(empresa.GetType(), new object[] { empresa });
            tmpLog.ESTADO_ANTERIOR = objetoAnalizado;

            Object[] Empresas = (Object[])clienteCuposTrans.getTEmpresasServicio(empresa);

            DateTime dt2 = DateTime.Now;
            TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
            tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;
            serviciosLogs.crearRegistroLog(tmpLog);

            buscador buscador = new buscador(Empresas, Campos, "Empresas", null);

            if (buscador.ShowDialog() == DialogResult.OK)
            {
                newempresa = (empresasdeServicioTrans)funciones.listToEmpresaServicio(buscador.Seleccion);
                siglaempresa.Text = newempresa.NIT;
                nombreempresa.Text = newempresa.NOMBRE;
            }
        }

        private void btnSearchVehiculos_Click(object sender, EventArgs e)
        {
            if (newempresa != null && newempresa.ID_EMPSERVICIO > 0)
            {
                logs tmpLog = new logs();
                tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
                tmpLog.OBJETO = "TIPOVEHICULO";
                tmpLog.MODULO = "TPUBLICO";
                tmpLog.TIPO_TRANSACCION = "SELECT";
                TimeSpan TS;
                DateTime dt1 = DateTime.Now;

                clienteCuposTrans = WS.ServiciosCuposTransService();

                viewVehiculosActivosEmpresa vistaVehActivosEmp = new viewVehiculosActivosEmpresa();
                vistaVehActivosEmp.AIDEMPRESA = newempresa.ID_EMPSERVICIO;
                vistaVehActivosEmp.IDTIPOVEHICULO = cmbTipoVehiculo.SelectedValue.ToString();

                string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(vistaVehActivosEmp.GetType(), new object[] { vistaVehActivosEmp });
                tmpLog.ESTADO_ANTERIOR = objetoAnalizado;

                Object[] listavehic = (Object[])clienteCuposTrans.getSVehiculosActivosEmpresa(vistaVehActivosEmp);

                DateTime dt2 = DateTime.Now;
                TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
                tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;
                serviciosLogs.crearRegistroLog(tmpLog);

                if (listavehic != null)
                {
                    mostrarVehiculos(listavehic);
                    btnInformeVehiculos.Enabled = true;
                    btnInformeVehiculos.Focus();
                }
                else
                {
                    MessageBox.Show("No se encontró información", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgwVehivulos.DataSource = null;
                    btnInformeVehiculos.Enabled = false;
                }
            }
            else
                MessageBox.Show("Debe seleccionar una empresa");
        }

        private void mostrarVehiculos(Object[] lista)
        {
            Funciones funciones = WS.Funciones();
            DataTable dt = new DataTable();

            ArrayList Campos = new ArrayList();
            Campos.Add("BNEMPRESA = EMPRESA");
            Campos.Add("CNIT = NIT");
            Campos.Add("DPLACA = PLACA");
            Campos.Add("ENUMCUPO = NUMERO CUPO");
            Campos.Add("FNUMEROTARJETA = TARJETA DE OPERACION");
            Campos.Add("GFECHAVENCIMIENTO = FECHA DE VENCIMIENTO");
            Campos.Add("HNROCUPOS = CAPACIDAD CUPO");
            try
            {
                dt = funciones.ToDataTable(funciones.ObjectToArrayList(lista));
            }
            catch (Exception e) {
                log.escribirError(e.ToString(), this.GetType());
            }

            dgwVehivulos.DataSource = dt;

            if (dt.Rows.Count > 0)
                funciones.configurarGrilla(dgwVehivulos, Campos);
            dt = null;
            Campos = null;

            dgwVehivulos.Select();
        }

        private void btninformevehiculos_Click(object sender, EventArgs e)
        {
            VerReporteActivos visor = new VerReporteActivos(dgwVehivulos);
            visor.ShowDialog();
        }

        private void cmbTipoVehiculo_KeyPress(object sender, KeyPressEventArgs e)
        {
            funciones.lanzarTapConEnter(e);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            funciones.exportarDataGridViewAExcelToDocuments("informeVehiculos", "Informe de vehiculos actívos por empresa", dgwVehivulos);
        }

        private void acciones_Enter(object sender, EventArgs e)
        {

        }
    }
}
