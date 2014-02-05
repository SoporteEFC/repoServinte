using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TransportePublico.servicios.documentos;
using TransportePublico;
using LibreriasSintrat.ServiciosCuposTrans;
using LibreriasSintrat.ServiciosVehiculos;
using LibreriasSintrat.ServiciosViewVehiculo;
using LibreriasSintrat.ServiciosMedidasCautelares;
using LibreriasSintrat.ServiciosDocumentos;
using LibreriasSintrat.utilidades;
using TransitoPrincipal;
using LibreriasSintrat.forms.documentos;
using System.IO;
using LibreriasSintrat.ServiciosConfiguraciones;
using LibreriasSintrat.ServiciosAccesorias;
using LibreriasSintrat.ServiciosGenerales;
using LibreriasSintrat.ServiciosPropietarios;
using LibreriasSintrat.ServiciosLogs;
using LibreriasSintrat.ServiciosUsuarios;

using LibreriasSintrat.utilidades;

namespace TransportePublico.servicios.tramites
{
    public partial class cambiodeempresa : Form
    {
        ServiciosLogsService serviciosLogs;
        usuarios usuarioSistema;
        ServiciosCuposTransService clienteCuposTrans;
        ServiciosVehiculosService clienteVehiculos;
        ServiciosViewVehiculoService clienteViewVehiculos;
        ServiciosMedidasCautelaresService clienteCautelares;
        empresasdeServicioTrans empAnterior;
        empresasdeServicioTrans newempresa;
        viewVehiculo encontrado;
        vehiculo elvehi = new vehiculo();
        cuposTaxisTrans cupseleccionado = null;
        int idvehicu = 0;
        int idempres = 0;
        int idantiguo = 0;
        Object[] listacupos = null;
        Boolean cargainicial;

        Funciones funciones;

        public cambiodeempresa(usuarios user)
        {
            InitializeComponent();
            usuarioSistema = user;
            serviciosLogs = WS.ServiciosLogsService();
        }

        private void cambiodeempresa_Load(object sender, EventArgs e)
        {
            cargainicial = true;
            btnSave.Enabled = false;
            tipoVehiculoTrans tipo = new tipoVehiculoTrans();
            clienteCuposTrans = WS.ServiciosCuposTransService();

            funciones = WS.Funciones();

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
                cmbTipoVehiculo.DataSource = null;
                cmbTipoVehiculo.DisplayMember = "NOMBRE";
                cmbTipoVehiculo.ValueMember = "ID";
                funciones.llenarCombo(cmbTipoVehiculo, listat);
                cmbTipoVehiculo.SelectedIndex = -1;
                cmbTipoVehiculo.Focus();
            }

            cargainicial = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
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

            buscador buscador = new buscador(Empresas, Campos, "Empresas", null);

            if (buscador.ShowDialog() == DialogResult.OK)
            {
                newempresa = (empresasdeServicioTrans)funciones.listToEmpresaServicio(buscador.Seleccion);
                if (newempresa.ID_EMPSERVICIO == idempres)
                {
                    MessageBox.Show("Debe seleccionar una empresa diferente a: " + newempresa.NOMBRE, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSiglaEmpresa.Text = "";
                    txtNombreEmpresa.Text = "";
                    buscarEmpresa();
                }
                else
                {
                    txtSiglaEmpresa.Text = newempresa.NIT;
                    txtNombreEmpresa.Text = newempresa.NOMBRE;
                    btnSave.Enabled = true;
                }
            }
        }

        private void tipovehiculo_SelectedValueChanged(object sender, EventArgs e)
        {
            limpiarCampos();

            if (cargainicial)
                cmbTipoVehiculo.SelectedIndex = -1;
            else
            {
                if (cmbTipoVehiculo.SelectedIndex >= 0)
                {
                    cargainicial = true;
                    buscarCupos();
                    cargainicial = false;
                }
            }
        }

        private bool buscarCupos()
        {
            Funciones funciones = WS.Funciones();

            cuposTaxisTrans elcupo = new cuposTaxisTrans();

            elcupo.TT_TIPOVEH = cmbTipoVehiculo.SelectedValue.ToString();

            logs tmpLog = new logs();
            tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
            tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
            tmpLog.OBJETO = "T_CUPOSTAXIS";
            tmpLog.MODULO = "TPUBLICO";
            tmpLog.TIPO_TRANSACCION = "SELECT";
            TimeSpan TS;
            DateTime dt1 = DateTime.Now;

            string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(elcupo.GetType(), new object[] { elcupo});
            tmpLog.ESTADO_ANTERIOR = objetoAnalizado;

            listacupos = (Object[])clienteCuposTrans.getSCupos(elcupo);

            DateTime dt2 = DateTime.Now;
            TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
            tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;
            serviciosLogs.crearRegistroLog(tmpLog);

               
            if (listacupos != null)
            {                
                //funciones.llenarCombo(cmbCupo, listacupos);

                return true;
            }
            else
                return false;
        }

        //private void cmbCupo_SelectedValueChanged(object sender, EventArgs e)
        //{
        //    limpiarCampos();

        //    if (cargainicial)
        //    {
        //        cmbCupo.SelectedIndex = -1;
        //    }
        //    else
        //    {
        //        if (cmbCupo.SelectedIndex >= 0)
        //        {
        //            cupseleccionado = new cuposTaxisTrans();
        //            cupseleccionado = (cuposTaxisTrans)listacupos[cmbCupo.SelectedIndex];

        //            idvehicu = cupseleccionado.TT_ID_VEHICULO;
        //            idempres = cupseleccionado.TT_ID_EMPSERVICIO;

        //            buscarPendientes();

        //            cargainicial = false;
        //        }
        //    }
        //}

        private void buscarPendientes()
        {
            clienteVehiculos = WS.ServiciosVehiculosService();
            clienteCautelares = WS.ServiciosMedidasCautelaresService();
            jPendiente pendiente = new jPendiente();
            pendiente.JP_V_ID = idvehicu;
            pendiente.JP_ACTIVO = 1;

            logs tmpLog = new logs();
            tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
            tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
            tmpLog.OBJETO = "J_PENDIENTE";
            tmpLog.MODULO = "TPUBLICO";
            tmpLog.TIPO_TRANSACCION = "SELECT";
            TimeSpan TS;
            DateTime dt1 = DateTime.Now;

            string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(pendiente.GetType(), new object[] { pendiente });
            tmpLog.ESTADO_ANTERIOR = objetoAnalizado;

            Object[] listapendientes = clienteCautelares.ListarMedidasCautelares(pendiente);

            DateTime dt2 = DateTime.Now;
            TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
            tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;
            serviciosLogs.crearRegistroLog(tmpLog);

            if (listapendientes != null && listapendientes.Length >= 0)
            {
                MessageBox.Show("El vehiculo tiene Pendiente Judiciales Activos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnSave.Enabled = false;
            }
            else
            {
                buscarVehiculo();
            }
        }

        public void buscarEmpresaActual()
        {
            Object[] tmp;
            viewVehiculosActivosEmpresa myViewVehiAct = new viewVehiculosActivosEmpresa();
            myViewVehiAct.DPLACA = encontrado.PLACA;

            logs tmpLog = new logs();
            tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
            tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
            tmpLog.OBJETO = "VIEW_VEHICULOACTIVOS_EMPRESA";
            tmpLog.MODULO = "TPUBLICO";
            tmpLog.TIPO_TRANSACCION = "SELECT";
            TimeSpan TS;
            DateTime dt1 = DateTime.Now;

            string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(myViewVehiAct.GetType(), new object[] { myViewVehiAct });
            tmpLog.ESTADO_ANTERIOR = objetoAnalizado;

            tmp = (Object[])clienteCuposTrans.getSVehiculosActivosEmpresa(myViewVehiAct);

            DateTime dt2 = DateTime.Now;
            TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
            tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;
            serviciosLogs.crearRegistroLog(tmpLog);


            if (tmp != null && tmp.Length > 0)
            {
                myViewVehiAct = (viewVehiculosActivosEmpresa)tmp[0];
                empAnterior = new empresasdeServicioTrans();

                empAnterior.ID_EMPSERVICIO = myViewVehiAct.AIDEMPRESA;
                empAnterior.DIGVERIF = -2;

                logs tmpLog1 = new logs();
                tmpLog1.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                tmpLog1.ID_USUARIO = usuarioSistema.ID_USUARIO;
                tmpLog1.OBJETO = "EMPRESASDESERVICIO";
                tmpLog1.MODULO = "TPUBLICO";
                tmpLog1.TIPO_TRANSACCION = "SELECT";
                TimeSpan TS1;
                DateTime dt11 = DateTime.Now;

                string objetoAnalizado1 = AnalizadorDeObjetos.analizarObjeto(empAnterior.GetType(), new object[] { empAnterior });
                tmpLog1.ESTADO_ANTERIOR = objetoAnalizado1;

                tmp = (Object[])clienteCuposTrans.getEmpresaServicio(empAnterior);

                DateTime dt21 = DateTime.Now;
                TS1 = new TimeSpan(dt21.Ticks - dt11.Ticks);
                tmpLog1.TIEMPO_EJECUCION = TS1.Milliseconds;
                serviciosLogs.crearRegistroLog(tmpLog1);

                if (tmp != null && tmp.Length > 0)
                {
                    empAnterior = (empresasdeServicioTrans)tmp[0];
                    idempres = empAnterior.ID_EMPSERVICIO;
                    txtSigEmpresaAnt.Text = empAnterior.NIT.ToString();
                    txtEmpresaAnt.Text = empAnterior.NOMBRE;
                }
                else
                {
                    txtSigEmpresaAnt.Text = "";
                    txtEmpresaAnt.Text = "";
                }
            }
            else
            {
                txtSigEmpresaAnt.Text = "";
                txtEmpresaAnt.Text = "";
            }
        }

        private void buscarVehiculo()
        {
            clienteViewVehiculos = WS.ServiciosViewVehiculoService();
            viewVehiculo vehiculobusca = new viewVehiculo();
            encontrado = new viewVehiculo();
            vehiculobusca.IDVEHICULO = idvehicu;

            logs tmpLog = new logs();
            tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
            tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
            tmpLog.OBJETO = "VIEW_VEHICULO";
            tmpLog.MODULO = "TPUBLICO";
            tmpLog.TIPO_TRANSACCION = "SELECT";
            TimeSpan TS;
            DateTime dt1 = DateTime.Now;

            string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(vehiculobusca.GetType(), new object[] { vehiculobusca });
            tmpLog.ESTADO_ANTERIOR = objetoAnalizado;

            encontrado = clienteViewVehiculos.consultarInformacionVehiculoPorIdVehiculo(vehiculobusca);

            DateTime dt2 = DateTime.Now;
            TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
            tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;
            serviciosLogs.crearRegistroLog(tmpLog);

            if (encontrado != null && encontrado.IDVEHICULO > 0)
            {
                txtPlacavehiculo.Text = encontrado.PLACA;
                txtMarcaVehiculo.Text = encontrado.MARCAVEH;
                txtLineaVehiculo.Text = encontrado.LINEAVEH;
                txtClaseVehiculo.Text = encontrado.CLASEVEH;
                txtNumeroChasis.Text = encontrado.NUMEROCHASIS;
                txtTipoCarroceria.Text = encontrado.TIPOCARROCERIA;
                txtNumeroMotor.Text = encontrado.NUMEROMOTOR;
                buscarEmpresaActual();
            }
            else
            {
                txtPlacavehiculo.Text = "";
                txtMarcaVehiculo.Text = "";
                txtLineaVehiculo.Text = "";
                txtClaseVehiculo.Text = "";
                txtNumeroChasis.Text = "";
                txtTipoCarroceria.Text = "";
                txtNumeroMotor.Text = "";
                MessageBox.Show("No se encontraron datos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            validaciones();
        }

        private void validaciones()
        {
            bool val = true;
            
            if (txtResolucion.Text == "")
            {
                funciones.mostrarMensaje("Debe ingresar un número de resolucion", "W");
                txtResolucion.Focus();

                val = false;
            }
            else if (txtRepresentanteLegalNew.Text == "")
            {
                funciones.mostrarMensaje("Debe ingresar El nuevo representante legal", "W");
                txtRepresentanteLegalOld.Focus();

                val = false;
            }
            else if (txtRepresentanteLegalOld.Text == "")
            {
                funciones.mostrarMensaje("Debe ingresar El representante legal anterior", "W");
                txtRepresentanteLegalNew.Focus();

                val = false;
            }
            else if (cmbTipoVehiculo.SelectedIndex < 0)
            {
                funciones.mostrarMensaje("Debe seleccionar un tipo de vehículo", "W");
                cmbTipoVehiculo.Focus();
            }
            else if (txtNumeroCupo.Text == "")
            {
                funciones.mostrarMensaje("Debe seleccionar un número de cupo", "W");

                val = false;
            }
            else if (idempres <= 0 || (txtSiglaEmpresa.Text == "" && txtNombreEmpresa.Text == ""))
            {
                funciones.mostrarMensaje("Debe seleccionar la nueva empresa", "W");
                buscarEmpresa();

                val = false;
            }

            if(val)
                modificarCupo();
        }

        private void modificarCupo()
        {
            inventarioCuposTrans editainven = new inventarioCuposTrans();

            idantiguo = cupseleccionado.TT_ID_EMPSERVICIO;
            editainven.ID_EMPRESAASIGNADA = cupseleccionado.TT_ID_EMPSERVICIO;

            editainven.ID_TIPOVEHICULO = Int32.Parse(cmbTipoVehiculo.SelectedValue.ToString());
            editainven.NROCUPO = cupseleccionado.TT_NUMCUPO.ToString();

            logs tmpLog = new logs();
            tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
            tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
            tmpLog.OBJETO = "T_INVENTARIOCUPOS";
            tmpLog.MODULO = "TPUBLICO";
            tmpLog.TIPO_TRANSACCION = "SELECT";
            TimeSpan TS;
            DateTime dt1 = DateTime.Now;

            string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(editainven.GetType(), new object[] { editainven });
            tmpLog.ESTADO_ANTERIOR = objetoAnalizado;

            Object[] listainventario = clienteCuposTrans.getSInventarioCupos(editainven);

            DateTime dt2 = DateTime.Now;
            TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
            tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;
            serviciosLogs.crearRegistroLog(tmpLog);


            if (listainventario != null && listainventario.Length >= 0)
            {
                inventarioCuposTrans invenaeditar = new inventarioCuposTrans();
                invenaeditar = (inventarioCuposTrans)listainventario[0];

                logs tmpLog1 = new logs();
                tmpLog1.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                tmpLog1.ID_USUARIO = usuarioSistema.ID_USUARIO;
                tmpLog1.OBJETO = "T_CUPOSTAXIS";
                tmpLog1.MODULO = "TPUBLICO";
                tmpLog1.TIPO_TRANSACCION = "SELECT";
                TimeSpan TS1;
                DateTime dt11 = DateTime.Now;

                string objetoAnalizado11 = AnalizadorDeObjetos.analizarObjeto(invenaeditar.GetType(), new object[] { invenaeditar });
                tmpLog1.ESTADO_ANTERIOR = objetoAnalizado11;

                invenaeditar.ID_EMPRESAASIGNADA = newempresa.ID_EMPSERVICIO;

                string objetoAnalizado1 = AnalizadorDeObjetos.analizarObjeto(invenaeditar.GetType(), new object[] { invenaeditar });
                tmpLog1.ESTADO_FINAL = objetoAnalizado1;

                Boolean actinven = clienteCuposTrans.editarCupos(invenaeditar);

                DateTime dt21 = DateTime.Now;
                TS1 = new TimeSpan(dt21.Ticks - dt11.Ticks);
                tmpLog1.TIEMPO_EJECUCION = TS1.Milliseconds;
                serviciosLogs.crearRegistroLog(tmpLog1);


                if (actinven == true)
                {
                    cupseleccionado.TT_ID_EMPSERVICIO = newempresa.ID_EMPSERVICIO;

                    logs tmpLog2 = new logs();
                    tmpLog2.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                    tmpLog2.ID_USUARIO = usuarioSistema.ID_USUARIO;
                    tmpLog2.OBJETO = "T_CUPOSTAXIS";
                    tmpLog2.MODULO = "TPUBLICO";
                    tmpLog2.TIPO_TRANSACCION = "SELECT";
                    TimeSpan TS2;
                    DateTime dt12 = DateTime.Now;

                    string objetoAnalizado2 = AnalizadorDeObjetos.analizarObjeto(cupseleccionado.GetType(), new object[] { cupseleccionado });
                    tmpLog.ESTADO_ANTERIOR = objetoAnalizado;

                    Boolean actcuptax = clienteCuposTrans.editarCuposTaxis(cupseleccionado);

                    string objetoAnalizado22 = AnalizadorDeObjetos.analizarObjeto(cupseleccionado.GetType(), new object[] { cupseleccionado });
                    tmpLog2.ESTADO_FINAL = objetoAnalizado22;

                    DateTime dt22 = DateTime.Now;
                    TS2 = new TimeSpan(dt22.Ticks - dt12.Ticks);
                    tmpLog2.TIEMPO_EJECUCION = TS2.Milliseconds;
                    serviciosLogs.crearRegistroLog(tmpLog2);

                    if (actcuptax == true)
                    {
                        MessageBox.Show("El cupo ha sido editado con exito");
                        historicoCupoTrans elhistorico = new historicoCupoTrans();
                        elhistorico.IDCUPO = cupseleccionado.TT_IDCUPOTAXI;
                        elhistorico.IDVEHICULO = idvehicu;
                        elhistorico.IDEMPRESASERVICIO = idantiguo;

                        logs tmpLog3 = new logs();
                        tmpLog3.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                        tmpLog3.ID_USUARIO = usuarioSistema.ID_USUARIO;
                        tmpLog3.OBJETO = "TIPOVEHICULO";
                        tmpLog3.MODULO = "TPUBLICO";
                        tmpLog3.TIPO_TRANSACCION = "SELECT";
                        TimeSpan TS3;
                        DateTime dt13 = DateTime.Now;

                        string objetoAnalizado3 = AnalizadorDeObjetos.analizarObjeto(elhistorico.GetType(), new object[] { elhistorico });
                        tmpLog3.ESTADO_ANTERIOR = objetoAnalizado3;

                        Object[] listahistorico = clienteCuposTrans.getSHistoricoCuposTaxis(elhistorico);

                        DateTime dt23 = DateTime.Now;
                        TS3 = new TimeSpan(dt23.Ticks - dt13.Ticks);
                        tmpLog3.TIEMPO_EJECUCION = TS3.Milliseconds;
                        serviciosLogs.crearRegistroLog(tmpLog3);

                        historicoCupoTrans nuevohistorico = new historicoCupoTrans();

                        if (listahistorico != null && listahistorico.Length >= 0)
                        {
                            nuevohistorico = (historicoCupoTrans)listahistorico[0];
                            nuevohistorico.IDEMPRESASERVICIO = newempresa.ID_EMPSERVICIO;
                        }

                        nuevohistorico.DESCRIPCION = "Cambio de Empresa";

                        generarResolucion();

                        logs tmpLog4 = new logs();
                        tmpLog4.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                        tmpLog4.ID_USUARIO = usuarioSistema.ID_USUARIO;
                        tmpLog4.OBJETO = "TT_HISTORICOCUPO";
                        tmpLog4.MODULO = "TPUBLICO";
                        tmpLog4.TIPO_TRANSACCION = "INSERT";
                        TimeSpan TS4;
                        DateTime dt14 = DateTime.Now;

                        string objetoAnalizado4 = AnalizadorDeObjetos.analizarObjeto(nuevohistorico.GetType(), new object[] { nuevohistorico });
                        tmpLog4.ESTADO_ANTERIOR = objetoAnalizado4;

                        Boolean inshistorico = clienteCuposTrans.crearHistoricoCuposTaxis(nuevohistorico);

                        DateTime dt24 = DateTime.Now;
                        TS4 = new TimeSpan(dt24.Ticks - dt14.Ticks);
                        tmpLog4.TIEMPO_EJECUCION = TS4.Milliseconds;
                        serviciosLogs.crearRegistroLog(tmpLog4);

                        if (inshistorico == true)
                        {
                            funciones.mostrarMensaje("Resolución y registro generados con éxito", "I");
                        }
                        else
                        {
                            funciones.mostrarMensaje("Error actualizando el cupo", "E");
                        }
                    }
                    else
                    {
                        funciones.mostrarMensaje("El cupo no fue actualizado con exito", "E");
                    }
                }
            }
            else
            {
                MessageBox.Show("Error en modificación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void generarResolucion()
        {
            try
            {
                ServiciosConfiguracionesService serviciosConfiguraciones = WS.ServiciosConfiguracionesService();

                object fileName = serviciosConfiguraciones.leerRegistroIni("PLANTILLAS") + "\\Cambio_Empresa.dotx";
                transferir myTransferencia = new transferir();
                myTransferencia.archivoDelServerSinAbrir((String)fileName);

                ProcesadorDocumentos myProcesadorDocs = new ProcesadorDocumentos();

                Dictionary<string, string> dicVariablesValores = new Dictionary<string, string>();
                ServiciosAccesoriasService clienteAccesorias = WS.ServiciosAccesoriasService();
                ServiciosViewVehiculoService clienteVehiculos = WS.ServiciosViewVehiculoService();
                 //clientegenerales = WS.ServiciosGeneralesService();

                viewVehiculo vehiculo = new viewVehiculo();
                vehiculo.IDVEHICULO = idvehicu;

                logs tmpLog = new logs();
                tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
                tmpLog.OBJETO = "VIEW_VEHICULO";
                tmpLog.MODULO = "TPUBLICO";
                tmpLog.TIPO_TRANSACCION = "SELECT";
                TimeSpan TS;
                DateTime dt1 = DateTime.Now;

                string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(vehiculo.GetType(), new object[] { vehiculo });
                tmpLog.ESTADO_ANTERIOR = objetoAnalizado;

                vehiculo = clienteVehiculos.consultarInformacionVehiculoPorIdVehiculo(vehiculo);

                DateTime dt2 = DateTime.Now;
                TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
                tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;
                serviciosLogs.crearRegistroLog(tmpLog);

                LibreriasSintrat.ServiciosPropietarios.ServiciosPropietariosService servicioPropietarios = WS.ServiciosPropietariosService();
                LibreriasSintrat.ServiciosPropietarios.viewPropietarios objPropietarios = new LibreriasSintrat.ServiciosPropietarios.viewPropietarios();
                Funciones func = new Funciones();

                objPropietarios.ID_VEHICULO = vehiculo.IDVEHICULO.ToString();
                objPropietarios.PROPIETARIOACTUAL = "T";
                //VIEW_PROPIETARIOS

                logs tmpLog3 = new logs();
                tmpLog3.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                tmpLog3.ID_USUARIO = usuarioSistema.ID_USUARIO;
                tmpLog3.OBJETO = "TIPOVEHICULO";
                tmpLog3.MODULO = "TPUBLICO";
                tmpLog3.TIPO_TRANSACCION = "SELECT";
                TimeSpan TS3;
                DateTime dt13 = DateTime.Now;

                string objetoAnalizado3 = AnalizadorDeObjetos.analizarObjeto(objPropietarios.GetType(), new object[] { objPropietarios });
                tmpLog3.ESTADO_ANTERIOR = objetoAnalizado3;


                Object[] propietarios = servicioPropietarios.getViewPropietariosDeVehiculos(objPropietarios);

                DateTime dt23 = DateTime.Now;
                TS3 = new TimeSpan(dt23.Ticks - dt13.Ticks);
                tmpLog3.TIEMPO_EJECUCION = TS3.Milliseconds;
                serviciosLogs.crearRegistroLog(tmpLog3);

                if (propietarios != null && propietarios.Length > 0)
                    objPropietarios = (viewPropietarios)propietarios[0];

                LibreriasSintrat.ServiciosCuposTrans.viewCupos VC = new LibreriasSintrat.ServiciosCuposTrans.viewCupos();
                VC.PLACA = vehiculo.PLACA;

                //ServiciosCuposTransService sct = new ServiciosCuposTransService();
                //object[] listaCupos = sct.getSViewCupos(VC);
                //cuposTaxisTrans ctt = new cuposTaxisTrans();
                //if (listacupos != null && listacupos.Length > 0)
                //{
                //    ctt = (LibreriasSintrat.ServiciosCuposTrans.viewCupos)listacupos[0];
                //}

                dicVariablesValores.Add("NUMIDENTIFICACION",objPropietarios.IDENTIFICACION);
                dicVariablesValores.Add("PROPIETARION", objPropietarios.NOMBRE);
                dicVariablesValores.Add("TIPODOCUMENTO", VC.NUMERO.ToString());
                dicVariablesValores.Add("PROPIETARIO", objPropietarios.NOMBRE);
                dicVariablesValores.Add("PROPIETARIOV", objPropietarios.NOMBRE);
                dicVariablesValores.Add("NUMTARJETA", VC.TARJETAOPERACION);
                dicVariablesValores.Add("PLACA", vehiculo.PLACA);
                //dicVariablesValores.Add("PROPIETARIOV", "PENDIENTE");
                dicVariablesValores.Add("TIPOVEHICULO", vehiculo.SERVICIOVEH);
                dicVariablesValores.Add("MARCA", vehiculo.MARCAVEH);
                dicVariablesValores.Add("MODELO", vehiculo.MODELO);
                dicVariablesValores.Add("MOTOR", vehiculo.NUMEROMOTOR);
                dicVariablesValores.Add("CUPO", cupseleccionado.TT_NUMCUPO.ToString());
                
                dicVariablesValores.Add("EMPRESANUEVA", txtNombreEmpresa.Text);
                dicVariablesValores.Add("REPRESENTANTELEGALNUEVO", txtRepresentanteLegalNew.Text);
                dicVariablesValores.Add("EMPRESAVIEJA", txtEmpresaAnt.Text);
                dicVariablesValores.Add("REPRESENTANTELEGAL", txtRepresentanteLegalOld.Text);//cupseleccionado.TT_ID_PERSONA + " " + cupseleccionado.TT_IDEMPRESA);
                dicVariablesValores.Add("NRO_TARJETA", cupseleccionado.TT_IDTARJETA.ToString());
                dicVariablesValores.Add("NUMRESOLUCION", txtResolucion.Text);
                dicVariablesValores.Add("FECHARESOLUCION", dateTimePicker1.Text);
                dicVariablesValores.Add("FECHASOLICITUD", dateTimePicker2.Text);
                //dicVariablesValores.Add("NRO_INTERNO", cmbCupo.Text);
                dicVariablesValores.Add("NRO_INTERNO", txtNumeroCupo.Text);
                
                String rutaarchivo = (String)fileName;

                String result = "";

                string misDocumentos = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                string rutaTemp = misDocumentos + "\\filetemp.rtf";

                //Eliminar archivo temporal si existe
                if (File.Exists(rutaTemp))
                    File.Delete(rutaTemp);

                //Creating the instance of Word Application
                Microsoft.Office.Interop.Word.Application newApp = new Microsoft.Office.Interop.Word.Application();

                //specifying the Source & Target file names
                object Source = rutaarchivo;//"c:\\abc\\Source.doc";
                object Target = rutaTemp;//"c:\\abc\\Target.rtf";

                // Use for the parameter whose type are not known or  
                // say Missing
                object Unknown = Type.Missing;

                //Source document open here
                //Additional Parameters are not known so that are  
                //set as a missing type
                newApp.Documents.Open(ref Source, ref Unknown,
                     ref Unknown, ref Unknown, ref Unknown,
                     ref Unknown, ref Unknown, ref Unknown,
                     ref Unknown, ref Unknown, ref Unknown,
                     ref Unknown, ref Unknown, ref Unknown, ref Unknown);

                //Reemplazar las variables en la plantilla
                myProcesadorDocs.reemplazarVariables(newApp, dicVariablesValores);

                //Specifying the format in which you want the output file 
                object format = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatRTF;

                //Changing the format of the document
                newApp.ActiveDocument.SaveAs(ref Target, ref format,
                        ref Unknown, ref Unknown, ref Unknown,
                        ref Unknown, ref Unknown, ref Unknown,
                        ref Unknown, ref Unknown, ref Unknown,
                        ref Unknown, ref Unknown, ref Unknown,
                        ref Unknown, ref Unknown);

                //for closing the application
                newApp.Quit(ref Unknown, ref Unknown, ref Unknown);

                //Leer el contenido del archivo transformado
                System.Threading.Thread.Sleep(1000);    //Tiempo para que word cierre la app
                result = File.ReadAllText(Target.ToString());

                //Eliminar archivo temporal si existe
                if (File.Exists(rutaTemp))
                    File.Delete(rutaTemp);

                String contenido = result;

                //contenido = myProcesadorDocs.reemplazarVariables(dicVariablesValores, contenido);

                if (contenido != null)
                {
                    FrmGeneradorDocumentos myformGenerarDoc = new FrmGeneradorDocumentos(fileName.ToString(), misDocumentos + "\\Siatt\\ResolCambioEmpresa" + DateTime.Now.ToString("yyyyMMdd"), contenido, true, false, false, true, true, true, Modulo.Transporte_Publico);

                    DialogResult dr = myformGenerarDoc.ShowDialog(this);

                    if (dr == DialogResult.OK)
                    {
                        String rutaguardar = myformGenerarDoc.rutaG;
                    }
                }
                else
                    funciones.mostrarMensaje("Error al genera el documento cuando se intentaba reemplazar las variables de la plantilla", "E");
            }
            catch (Exception exp)
            {
                funciones.mostrarMensaje("Error inesperado al generar el documento", "E");
            }
        }

        public void limpiarCampos()
        {
            txtEmpresaAnt.Clear();
            txtSigEmpresaAnt.Clear();
            txtClaseVehiculo.Clear();
            txtEmpresaAnt.Clear();
            txtLineaVehiculo.Clear();
            txtMarcaVehiculo.Clear();
            txtNombreEmpresa.Clear();
            txtNumeroChasis.Clear();
            txtNumeroMotor.Clear();
            txtPlacavehiculo.Clear();
            txtSigEmpresaAnt.Clear();
            txtSiglaEmpresa.Clear();
            txtTipoCarroceria.Clear();
            txtNumeroCupo.Clear();
        }

        //--    Eventos formulario
        #region Eventos formulario

        private void btnBuscarCupo_Click(object sender, EventArgs e)
        {
            limpiarCampos();

            if (cmbTipoVehiculo.SelectedIndex > -1)
            {
                cargainicial = true;

                if (buscarCupos())
                {
                    ArrayList Campos = new ArrayList();

                    Campos.Add("TT_NUMCUPO = NÚMERO CUPO");

                    buscador buscador = new buscador(listacupos, Campos, "Cupos", null);

                    if (buscador.ShowDialog() == DialogResult.OK)
                    {
                        cupseleccionado = new cuposTaxisTrans();
                        cupseleccionado = (cuposTaxisTrans)funciones.listToCuposTaxiTrans(buscador.Seleccion);

                        //cmbCupo.SelectedValue = cupseleccionado.TT_IDCUPOTAXI;
                        txtNumeroCupo.Text = "" + cupseleccionado.TT_NUMCUPO;

                        idvehicu = cupseleccionado.TT_ID_VEHICULO;
                        idempres = cupseleccionado.TT_ID_EMPSERVICIO;

                        buscarPendientes();
                    }
                    else
                    {
                        MessageBox.Show("Se canceló la busqueda.");
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron cupos registrados para ese tipo de vehículo");
                }

                cargainicial = false;
            }
            else
            {
                MessageBox.Show("Debe seleccionar un tipo de vehículo.");
                cmbTipoVehiculo.Focus();
            }
        }

        private void cmbTipoVehiculo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones myFun = new Funciones();
            myFun.lanzarTapConEnter(e);
        }

        //private void cmbCupo_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    Funciones myFun = new Funciones();
        //    myFun.lanzarTapConEnter(e);
        //}

        #endregion

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
