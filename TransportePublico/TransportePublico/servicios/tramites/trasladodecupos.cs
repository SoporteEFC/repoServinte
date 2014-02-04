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
using TransportePublico;
using LibreriasSintrat.ServiciosCuposTrans;
using LibreriasSintrat.utilidades;
using TransitoPrincipal;
using LibreriasSintrat.ServiciosLogs;
using LibreriasSintrat.ServiciosUsuarios;
using TransportePublico.utilidades; 

namespace TransportePublico.servicios.tramites
{
    public partial class trasladodecupos : Form
    {
        ServiciosCuposTransService clienteCuposTrans;
        empresasdeServicioTrans newempresa = null;
        empresasdeServicioTrans desempresa = null;
        Boolean cargainicial;
        ServiciosLogsService serviciosLogs;
        usuarios usuarioSistema;

        public trasladodecupos(usuarios user)
        {
            InitializeComponent();
            usuarioSistema = user;
            serviciosLogs = WS.ServiciosLogsService();
        }

        private void trasladodecupos_Load(object sender, EventArgs e)
        {
            cargainicial = true;
            tipoVehiculoTrans tipo = new tipoVehiculoTrans();
            clienteCuposTrans = WS.ServiciosCuposTransService();
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
                tipovehiculo.ValueMember = "ID";
                funciones.llenarCombo(tipovehiculo, listat);
                cargainicial = false;
            }
        }

        private void btnbuscarempresa_Click(object sender, EventArgs e)
        {
            buscarEmpresa();
        }

        public void buscarEmpresa()
        {
            clienteCuposTrans = WS.ServiciosCuposTransService();
            empresasdeServicioTrans empresa = new empresasdeServicioTrans();
            newempresa = new empresasdeServicioTrans();
            Funciones funciones = WS.Funciones();
            ArrayList Campos = new ArrayList();
            Campos.Add("SIGLA = SIGLA");
            Campos.Add("NOMBRE = NOMBRE");

            logs tmpLog = new logs();
            tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
            tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
            tmpLog.OBJETO = "EMPRESASDESERVICIO";
            tmpLog.MODULO = "TPUBLICO";
            tmpLog.TIPO_TRANSACCION = "SELECT";
            TimeSpan TS;
            DateTime dt1 = DateTime.Now;

            string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(empresa.GetType(), new object[] { empresa });
            tmpLog.ESTADO_ANTERIOR = objetoAnalizado;

            Object[] Empresas = (Object[])clienteCuposTrans.getTEmpresasServicio(empresa);

            DateTime dt2 = DateTime.Now;
            TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
            tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;
            serviciosLogs.crearRegistroLog(tmpLog);

            buscador buscador = new buscador(Empresas, Campos, "Seleccione Empresa Propietaria del Cupo", null);

            if (buscador.ShowDialog() == DialogResult.OK)
            {
                newempresa = (empresasdeServicioTrans)funciones.listToEmpresaServicio(buscador.Seleccion);
                siglaempresa.Text = newempresa.SIGLA;
                nombreempresa.Text = newempresa.NOMBRE;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tipovehiculo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cargainicial)
            {
                tipovehiculo.SelectedIndex = -1;
            }
            else
            {
                if (tipovehiculo.SelectedIndex >= 0)
                {
                    verificarCupos();
                }
            }
        }

        private void verificarCupos()
        {
            Object[] mysCupos;
            clienteCuposTrans = WS.ServiciosCuposTransService();
            //detalleRangoCupoTrans cuposdisp = new detalleRangoCupoTrans();
            Funciones funciones = WS.Funciones();

            if (newempresa != null)
            {
                if (Int32.Parse(tipovehiculo.SelectedIndex.ToString()) >= 0)
                {
                    cuposTaxisTrans myCupoTaxis = new cuposTaxisTrans();
                    myCupoTaxis.TT_ID_EMPSERVICIO = newempresa.ID_EMPSERVICIO;
                    myCupoTaxis.TT_TIPOVEH= tipovehiculo.SelectedIndex.ToString();

                    logs tmpLog = new logs();
                    tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                    tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
                    tmpLog.OBJETO = "T_CUPOSTAXIS";
                    tmpLog.MODULO = "TPUBLICO";
                    tmpLog.TIPO_TRANSACCION = "SELECT";
                    TimeSpan TS;
                    DateTime dt1 = DateTime.Now;
                    string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(myCupoTaxis.GetType(), new object[] { myCupoTaxis });
                    tmpLog.ESTADO_ANTERIOR = objetoAnalizado;

                    mysCupos = clienteCuposTrans.getSCupos(myCupoTaxis);
                    if (mysCupos != null && mysCupos.Length > 0)
                    {
                        funciones.llenarCombo(numerocupo, mysCupos);
                        numerocupo.Enabled = true;
                        btnSave.Enabled = true;
                    }
                    else
                    {
                        numerocupo.Enabled = false;
                        btnSave.Enabled = false;
                        MessageBox.Show("No existen cupos disponibles para este tipo de vehículo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (desempresa != null)
                        {
                            desempresa = null;
                        }
                        codigodestino.Text = "";
                        nombredestino.Text = "";
                        //limpiarCampos();
                    }
                }
            }

            else
            {
                buscarEmpresa();
            }
        }

        private void btn_SearchDestino_Click(object sender, EventArgs e)
        {
            buscarEmpresaDestino();
        }

        public void buscarEmpresaDestino()
        {
            clienteCuposTrans = WS.ServiciosCuposTransService();
            empresasdeServicioTrans empresa = new empresasdeServicioTrans();
            desempresa = new empresasdeServicioTrans();
            Funciones funciones = WS.Funciones();
            ArrayList Campos = new ArrayList();
            Campos.Add("SIGLA = SIGLA");
            Campos.Add("NOMBRE = NOMBRE");

            logs tmpLog = new logs();
            tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
            tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
            tmpLog.OBJETO = "EMPRESASDESERVICIO";
            tmpLog.MODULO = "TPUBLICO";
            tmpLog.TIPO_TRANSACCION = "SELECT";
            TimeSpan TS;
            DateTime dt1 = DateTime.Now;

            string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(empresa.GetType(), new object[] { empresa});
            tmpLog.ESTADO_ANTERIOR = objetoAnalizado;

            Object[] Empresas = (Object[])clienteCuposTrans.getTEmpresasServicio(empresa);

            DateTime dt2 = DateTime.Now;
            TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
            tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;
            serviciosLogs.crearRegistroLog(tmpLog);

            buscador buscador = new buscador(Empresas, Campos, "Seleccione Empresa a la que se Trasladará del Cupo", null);

            if (buscador.ShowDialog() == DialogResult.OK)
            {
                desempresa = (empresasdeServicioTrans)funciones.listToEmpresaServicio(buscador.Seleccion);
                codigodestino.Text = desempresa.SIGLA;
                nombredestino.Text = desempresa.NOMBRE;

                if (newempresa.ID_EMPSERVICIO == desempresa.ID_EMPSERVICIO)
                {
                    MessageBox.Show("La empresa de destino no puede ser la misma empresa de orígen, Por Favor seleccione otra empresa","Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    codigodestino.Text = "";
                    nombredestino.Text = "";
                    buscarEmpresaDestino();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            trasladar();
            //MessageBox.Show("Traslado de cupo realizado correctamente.");
        }

        private void trasladar()
        {
            if (newempresa == null)
            {
                MessageBox.Show("Debe seleccionar una empresa de orígen","Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
                buscarEmpresa();
            }
            else if (tipovehiculo.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un tipo de vehículo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tipovehiculo.Focus();
            }
            else if (numerocupo.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un número de cupo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                numerocupo.Focus();
            }
            else if (desempresa == null)
            {
                MessageBox.Show("Debe seleccionar una empresa de destino", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buscarEmpresaDestino();
            }
            else
            {                
                trasladaCupo();
            }
        }

        private void trasladaCupo()
        {
            cuposTaxisTrans cuposeleccionado = new cuposTaxisTrans();
            cuposTaxisTrans micupo = new cuposTaxisTrans();
            Object[] listacups = null;
            cuposeleccionado.TT_IDCUPOTAXI = Int32.Parse(numerocupo.SelectedValue.ToString());

            logs tmpLog = new logs();
            tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
            tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
            tmpLog.OBJETO = "T_CUPOSTAXIS";
            tmpLog.MODULO = "TPUBLICO";
            tmpLog.TIPO_TRANSACCION = "SELECT";
            TimeSpan TS;
            DateTime dt1 = DateTime.Now;
            string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(cuposeleccionado.GetType(), new object[] { cuposeleccionado });
            tmpLog.ESTADO_ANTERIOR = objetoAnalizado;

            listacups = clienteCuposTrans.getSCupos(cuposeleccionado);

            DateTime dt2 = DateTime.Now;
            TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
            tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;
            serviciosLogs.crearRegistroLog(tmpLog);

            if (listacups != null && listacups.Length >= 0)
            {
                micupo = (cuposTaxisTrans)listacups[0];
                
                string objetoAnalizado1 = AnalizadorDeObjetos.analizarObjeto(micupo.GetType(), new object[] { micupo });
                tmpLog.ESTADO_ANTERIOR = objetoAnalizado1;

                micupo.TT_ID_EMPSERVICIO = desempresa.ID_EMPSERVICIO;

                logs tmpLog2 = new logs();
                tmpLog2.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                tmpLog2.ID_USUARIO = usuarioSistema.ID_USUARIO;
                tmpLog2.OBJETO = "TIPOVEHICULO";
                tmpLog2.MODULO = "TPUBLICO";
                tmpLog2.TIPO_TRANSACCION = "SELECT";
                TimeSpan TS2;
                DateTime dt12 = DateTime.Now;



                Boolean editcup = clienteCuposTrans.cambiarEmpresaCuposTaxis(micupo);


                string objetoAnalizado2 = AnalizadorDeObjetos.analizarObjeto(micupo.GetType(), new object[] { micupo });
                tmpLog.ESTADO_FINAL = objetoAnalizado2;

                DateTime dt22 = DateTime.Now;
                TS2 = new TimeSpan(dt22.Ticks - dt12.Ticks);
                tmpLog2.TIEMPO_EJECUCION = TS2.Milliseconds;
                serviciosLogs.crearRegistroLog(tmpLog2);

                if (editcup)
                {
                    MessageBox.Show("Traslado Exitoso", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    verificarCupos();
                }
                else
                {
                    MessageBox.Show("Error en traslado de cupo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
        }

        private void tipovehiculo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones myFun = new Funciones();
            myFun.lanzarTapConEnter(e);
        }

        private void numerocupo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones myFun = new Funciones();
            myFun.lanzarTapConEnter(e);
        }
    }
}
