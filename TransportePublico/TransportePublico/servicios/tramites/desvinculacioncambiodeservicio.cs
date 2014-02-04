using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TransportePublico;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using LibreriasSintrat.ServiciosCuposTrans;
using LibreriasSintrat.ServiciosTramitesTrans;
using LibreriasSintrat.ServiciosAccesorias;
using LibreriasSintrat.ServiciosEmpresas;
using LibreriasSintrat.ServiciosPersonas;
using LibreriasSintrat.ServiciosPropietarios;
using LibreriasSintrat.ServiciosVehiculos;
using LibreriasSintrat.ServiciosViewVehiculo;
using LibreriasSintrat.ServiciosTransito;
using LibreriasSintrat.utilidades;
using TransitoPrincipal;
using LibreriasSintrat.ServiciosLogs;
using LibreriasSintrat.ServiciosUsuarios;
using TransportePublico.utilidades;
using LibreriasSintrat.utilidades;

namespace TransportePublico.servicios.tramites
{
    public partial class desvinculacioncambiodeservicio : Form
    {
        ServiciosLogsService serviciosLogs;
        usuarios usuarioSistema;
        ServiciosCuposTransService clienteCuposTrans;
        ServiciosTramitesTransService clienteTramitesTrans;
        ServiciosAccesoriasService clienteAccesorias;
        cuposTaxisTrans cuposeleccionado = null;
        Object[] listacupos = null;
        Object[] listacuposs = null;
        Object[] listapropietariosaaa;
        int idresolucion = 0;
        int numpropietario = 0, quees = 0, idp = 0;
        string modelovehi;
        string colorVehiAntiguo;
        string myTipoVehiculo;
        Funciones funciones;

        public desvinculacioncambiodeservicio(ServiciosAccesoriasService mySerAcc, usuarios user)
        {
            clienteAccesorias = mySerAcc;
            InitializeComponent();
            funciones = WS.Funciones();
            usuarioSistema = user;
            serviciosLogs = WS.ServiciosLogsService();
        }

        private void desvinculacioncambiodeservicio_Load(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            informacionderegistro.Enabled = false;

            tipoVehiculoTrans tipo = new tipoVehiculoTrans();
            clienteCuposTrans = WS.ServiciosCuposTransService();

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
            }

            rdNumeroCupo.Checked = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            validaciones();
        }

        private void validaciones()
        {
            bool val = true;

            if (tipovehiculo.SelectedIndex < 0)
            {
                funciones.mostrarMensaje("Debe Seleccionar un Tipo de Vehículo", "W");
                tipovehiculo.Focus();

                val = false;
            }
            else if (rdNumeroCupo.Checked && txtNumeroCupo.Text == "")
            {
                funciones.mostrarMensaje("El Campo Número Cupo no Puede ser vacío", "W");
                txtNumeroCupo.Focus();

                val = false;
            }
            else if (rdPlaca.Checked && txtPlaca.Text == "")
            {
                funciones.mostrarMensaje("El campo Placa no Puede ser vacío", "W");
                txtPlaca.Focus();

                val = false;
            }
            else if (numeroresolucion.Text == "")
            {
                funciones.mostrarMensaje("El Campo Número Resolución no Puede ser vacío", "W");
                numeroresolucion.Focus();

                val = false;
            }
            else if (fecharesolucion.Text == "")
            {
                funciones.mostrarMensaje("Debe Seleccionar una Fecha de Resolución", "W");
                fecharesolucion.Focus();

                val = false;
            }
            else if (nuevocolor.Text == "")
            {
                funciones.mostrarMensaje("El Campo Nuevo Color del Vehículo no Puede ser Vacío", "W");
                nuevocolor.Focus();

                val = false;
            }
            else if (placavehiculo.Text == "")
            {
                funciones.mostrarMensaje("El Vehículo asociado al número de cupo ya ha sido cambiado de Servicio", "W");
                txtNumeroCupo.Focus();

                val = false;
            }

            if (val)
                guardarDatos();
        }

        private void guardarDatos()
        {
            Object[] tmp;

            clienteTramitesTrans = WS.ServiciosTramitesTransService();
            ttResolucionesTrans laresolucion = new ttResolucionesTrans();

            laresolucion.IDTIPORESOLUCION = 1;

            laresolucion.FECHARESOLUCION = funciones.convFormatoFecha("fecharesolucion.Text", "MM/dd/yyyy");
            laresolucion.NUMERO = numeroresolucion.Text;
            laresolucion.NUEVOCOLOR = nuevocolor.Text;

            logs tmpLog = new logs();
            tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
            tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
            tmpLog.OBJETO = "TT_RESOLUCIONES";
            tmpLog.MODULO = "TPUBLICO";
            tmpLog.TIPO_TRANSACCION = "INSERT";
            TimeSpan TS;
            DateTime dt1 = DateTime.Now;

            string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(laresolucion.GetType(), new object[] { laresolucion });
            tmpLog.ESTADO_ANTERIOR = objetoAnalizado;

            idresolucion = clienteTramitesTrans.crearTtResolucionesTrans(laresolucion);

            DateTime dt2 = DateTime.Now;
            TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
            tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;
            serviciosLogs.crearRegistroLog(tmpLog);


            if (idresolucion > 0)
            {
                historicoCupoTrans elhistorico = new historicoCupoTrans();
                elhistorico.IDCUPO = cuposeleccionado.TT_IDCUPOTAXI;

                if (cuposeleccionado != null && cuposeleccionado.TT_ID_PERSONA > 0)
                {
                    elhistorico.IDPERSONA = cuposeleccionado.TT_ID_PERSONA;
                }

                if (cuposeleccionado != null && cuposeleccionado.TT_IDEMPRESA > 0)
                {
                    elhistorico.TT_IDEMPRESA = cuposeleccionado.TT_IDEMPRESA;
                }

                elhistorico.IDVEHICULO = cuposeleccionado.TT_ID_VEHICULO;
                elhistorico.DESCRIPCION = "Desvincular vehiculo para asignar a vehiculo nuevo";
                elhistorico.IDRESOLUCION = idresolucion;

                logs tmpLog1 = new logs();
                tmpLog1.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                tmpLog1.ID_USUARIO = usuarioSistema.ID_USUARIO;
                tmpLog1.OBJETO = "TT_HISTORICOCUPO";
                tmpLog1.MODULO = "TPUBLICO";
                tmpLog1.TIPO_TRANSACCION = "SELECT";
                TimeSpan TS1;
                DateTime dt11 = DateTime.Now;

                string objetoAnalizado1 = AnalizadorDeObjetos.analizarObjeto(elhistorico.GetType(), new object[] { elhistorico});
                tmpLog1.ESTADO_ANTERIOR = objetoAnalizado1;

                Boolean inshisto = clienteCuposTrans.crearHistoricoCuposTaxis(elhistorico);

                DateTime dt21 = DateTime.Now;
                TS1 = new TimeSpan(dt21.Ticks - dt11.Ticks);
                tmpLog1.TIEMPO_EJECUCION = TS1.Milliseconds;
                serviciosLogs.crearRegistroLog(tmpLog1);


                if (inshisto == true)
                {
                    cuposTaxisTrans editacupo = new cuposTaxisTrans();
                    editacupo = cuposeleccionado;
                    editacupo.TT_ID_PERSONA = 0;
                    editacupo.TT_ID_VEHICULO = 0;
                    editacupo.TT_IDEMPRESA = 0;

                    logs tmpLog3 = new logs();
                    tmpLog3.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                    tmpLog3.ID_USUARIO = usuarioSistema.ID_USUARIO;
                    tmpLog3.OBJETO = "T_CUPOSTAXIS";
                    tmpLog3.MODULO = "TPUBLICO";
                    tmpLog3.TIPO_TRANSACCION = "UPDATE";
                    TimeSpan TS3;
                    DateTime dt13 = DateTime.Now;

                    string objetoAnalizado3 = AnalizadorDeObjetos.analizarObjeto(cuposeleccionado.GetType(), new object[] { cuposeleccionado });
                    tmpLog3.ESTADO_ANTERIOR = objetoAnalizado3;

                    Boolean editacup = clienteCuposTrans.editarCuposTaxis(editacupo);

                    string objetoAnalizado33 = AnalizadorDeObjetos.analizarObjeto(editacupo.GetType(), new object[] { editacupo });
                    tmpLog3.ESTADO_FINAL = objetoAnalizado33;                        

                    DateTime dt23 = DateTime.Now;
                    TS3 = new TimeSpan(dt23.Ticks - dt13.Ticks);
                    tmpLog3.TIEMPO_EJECUCION = TS3.Milliseconds;
                    serviciosLogs.crearRegistroLog(tmpLog3);

                    if (editacup == true)
                    {
                        inventarioCuposTrans myInvent = new inventarioCuposTrans();

                        myInvent.NROCUPO = cuposeleccionado.TT_NUMCUPO.ToString();
                        myInvent.ID_TIPOVEHICULO = int.Parse(cuposeleccionado.TT_TIPOVEH);

                        logs tmpLog4 = new logs();
                        tmpLog4.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                        tmpLog4.ID_USUARIO = usuarioSistema.ID_USUARIO;
                        tmpLog4.OBJETO = "T_INVENTARIOCUPOS";
                        tmpLog4.MODULO = "TPUBLICO";
                        tmpLog4.TIPO_TRANSACCION = "SELECT";
                        TimeSpan TS4;
                        DateTime dt14 = DateTime.Now;

                        string objetoAnalizado4 = AnalizadorDeObjetos.analizarObjeto(myInvent.GetType(), new object[] { myInvent });
                        tmpLog4.ESTADO_ANTERIOR = objetoAnalizado4;

                        tmp = (Object[])clienteCuposTrans.getSInventarioCupos(myInvent);

                        DateTime dt24 = DateTime.Now;
                        TS4 = new TimeSpan(dt24.Ticks - dt14.Ticks);
                        tmpLog4.TIEMPO_EJECUCION = TS4.Milliseconds;
                        serviciosLogs.crearRegistroLog(tmpLog4);


                        if (tmp != null && tmp.Length > 0)
                        {
                            logs tmpLog5 = new logs();
                            tmpLog5.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                            tmpLog5.ID_USUARIO = usuarioSistema.ID_USUARIO;
                            tmpLog5.OBJETO = "T_INVENTARIOCUPOS";
                            tmpLog5.MODULO = "TPUBLICO";
                            tmpLog5.TIPO_TRANSACCION = "UPDATE";
                            TimeSpan TS5;
                            DateTime dt15 = DateTime.Now;

                            myInvent = (inventarioCuposTrans)tmp[0];

                            string objetoAnalizado5 = AnalizadorDeObjetos.analizarObjeto(myInvent.GetType(), new object[] { myInvent });
                            tmpLog5.ESTADO_ANTERIOR = objetoAnalizado5;

                            myInvent.DISPONIBLE = "F";

                            string objetoAnalizado55 = AnalizadorDeObjetos.analizarObjeto(myInvent.GetType(), new object[] { myInvent });
                            tmpLog.ESTADO_FINAL = objetoAnalizado1;                        

                            if (clienteCuposTrans.editarCupos(myInvent))
                            {
                                DateTime dt25 = DateTime.Now;
                                TS5 = new TimeSpan(dt25.Ticks - dt15.Ticks);
                                tmpLog5.TIEMPO_EJECUCION = TS5.Milliseconds;
                                serviciosLogs.crearRegistroLog(tmpLog5);

                                detalleRangoCupoTrans detalleRango = new detalleRangoCupoTrans();
                                detalleRango.IDDETALLERANGO = editacupo.t_IDDETALLERANGOCUPO;

                                logs tmpLog6 = new logs();
                                tmpLog6.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                                tmpLog6.ID_USUARIO = usuarioSistema.ID_USUARIO;
                                tmpLog6.OBJETO = "T_DETALLERANGOCUPO";
                                tmpLog6.MODULO = "TPUBLICO";
                                tmpLog6.TIPO_TRANSACCION = "SELECT";
                                TimeSpan TS6;
                                DateTime dt16 = DateTime.Now;

                                string objetoAnalizado6 = AnalizadorDeObjetos.analizarObjeto(detalleRango.GetType(), new object[] { detalleRango });
                                tmpLog6.ESTADO_ANTERIOR = objetoAnalizado6;

                                object[] listaDetalles = clienteCuposTrans.getDetalleRangoCupos(detalleRango);

                                DateTime dt26 = DateTime.Now;
                                TS6 = new TimeSpan(dt26.Ticks - dt16.Ticks);
                                tmpLog6.TIEMPO_EJECUCION = TS6.Milliseconds;
                                serviciosLogs.crearRegistroLog(tmpLog6);


                                if (listaDetalles != null && listaDetalles.Length > 0)
                                    detalleRango = (detalleRangoCupoTrans)listaDetalles[0];

                                logs tmpLog7 = new logs();
                                tmpLog7.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                                tmpLog7.ID_USUARIO = usuarioSistema.ID_USUARIO;
                                tmpLog7.OBJETO = "T_DETALLERANGOCUPO";
                                tmpLog7.MODULO = "TPUBLICO";
                                tmpLog7.TIPO_TRANSACCION = "SELECT";
                                TimeSpan TS7;
                                DateTime dt17 = DateTime.Now;

                                string objetoAnalizado7 = AnalizadorDeObjetos.analizarObjeto(detalleRango.GetType(), new object[] { detalleRango });
                                tmpLog7.ESTADO_ANTERIOR = objetoAnalizado7;

                                detalleRango.ASIGNADO = "F";

                                bool editado = clienteCuposTrans.editarDetalleRangoCupos(detalleRango);

                                string objetoAnalizado77 = AnalizadorDeObjetos.analizarObjeto(detalleRango.GetType(), new object[] { detalleRango });
                                tmpLog7.ESTADO_FINAL = objetoAnalizado77;

                                DateTime dt27 = DateTime.Now;
                                TS7 = new TimeSpan(dt27.Ticks - dt17.Ticks);
                                tmpLog7.TIEMPO_EJECUCION = TS7.Milliseconds;
                                serviciosLogs.crearRegistroLog(tmpLog7);

                                if (editado)
                                    funciones.mostrarMensaje("Desvinculación de vehículo de servicio público exitosa", "I");
                                else
                                    funciones.mostrarMensaje("Error desvinculando el vehículo", "E");
                            }
                        }
                    }
                    else
                    {
                        funciones.mostrarMensaje("Error al Modificar Cupo", "E");
                    }
                }
                else
                {
                    funciones.mostrarMensaje("Error al Registrar Histórico", "E");
                }

                funciones.mostrarMensaje("Registro de Resolución Exitoso", "I");

                generarResolucion();

                //this.Close();
                limpiarCampos();
            }
            else
            {
                funciones.mostrarMensaje("Error al Insertar Resolución", "E");
                this.Close();
            }
        }

        private void numeroresolucion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones funciones = WS.Funciones();
            funciones.esNumero(e);
        }

        private void btnbuscarcolor_Click(object sender, EventArgs e)
        {
            buscarColor();
        }

        public void buscarColor()
        {
            colores micolor = new colores();
            colores coloresveh = new colores();
            Funciones funciones = WS.Funciones();
            ArrayList Campos = new ArrayList();
            Campos.Add("DESCRIPCION = DESCRIPCION");

            logs tmpLog = new logs();
            tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
            tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
            tmpLog.OBJETO = "COLORES";
            tmpLog.MODULO = "TPUBLICO";
            tmpLog.TIPO_TRANSACCION = "SELECT";
            TimeSpan TS;
            DateTime dt1 = DateTime.Now;

            string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(micolor.GetType(), new object[] { micolor });
            tmpLog.ESTADO_ANTERIOR = objetoAnalizado;


            Object[] Colores = (Object[])clienteAccesorias.getColor(micolor);

            DateTime dt2 = DateTime.Now;
            TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
            tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;
            serviciosLogs.crearRegistroLog(tmpLog);
            
            buscador buscador = new buscador(Colores, Campos, "Colores", null);

            if (buscador.ShowDialog() == DialogResult.OK)
            {
                coloresveh = (colores)funciones.listToColores(buscador.Seleccion);
                nuevocolor.Text = coloresveh.DESCRIPCION;
            }
        }

        /*private void generarResolucion()
        {
            clienteAccesorias.getFechaActual();
            plantilla myPlantilla = new plantilla();
            myPlantilla.NOMBRE = "DESVINCULACION CAMBIO SERVICIO";
            ServiciosDocumentosService MySerDoc = WS.ServiciosDocumentosService();
            try
            {
                myPlantilla = (plantilla)((Object[])MySerDoc.buscarPlantillas(myPlantilla))[0];
            }
            catch (Exception e) { 
            }
            if (myPlantilla != null)
            {
                String param;
                Funciones myFnc = WS.Funciones();
                plantillaAPDF myPlToPdf = new plantillaAPDF();
                transferir myTrans = new transferir();
                ServiciosDocumentosService mySerDoc = WS.ServiciosDocumentosService();
                Object[] parametros = new Object[12];
                param = "EMPRESASERVICIO = " + cuposeleccionado.TT_ID_EMPSERVICIO;
                parametros[0] = param;
                param = "PROPIETARIOVEHICULO = " + cuposeleccionado.TT_ID_PERSONA + " " + cuposeleccionado.TT_ID_VEHICULO;
                parametros[1] = param;
                //param = "IDENTIFICACIONPROPIETARIO = PENDIENTE";
                param = "NUMEROCUPO = " + cuposeleccionado.TT_NUMCUPO;
                parametros[3] = param;
                param = "PLACAVEHICULO = PENDIENTE";
                parametros[4] = param;
                param = "CLASEVEHICULO = PENDIENTE";
                parametros[5] = param;
                param = "MODELOVEHICULO = PENDIENTE";
                parametros[6] = param;
                param = "MARCAVEHICULO = PENDIENTE";
                parametros[7] = param;
                param = "MOTORVEHICULO = PENDIENTE";
                parametros[8] = param;
                param = "NUMEROTARJETA = PENDIENTE";
                parametros[9] = param;
                param = "NUEVOCOLOR = " + nuevocolor.Text;
                parametros[10] = param;
                param = "FECHAACTUAL = " + clienteAccesorias.getFechaActual();
                parametros[11] = param;
                try
                {
                    myPlantilla = mySerDoc.procesarPlantillaValores(myPlantilla, parametros);
                    String nombreDoc = "RESOLUCIÓN DESVINCULACIÓN CAMBIO DE SERVICIO " + numeroresolucion.Text;
                    myPlToPdf.creaPdfPlantilla(myPlantilla, nombreDoc);
                    myTrans.archivoAlServer(nombreDoc + ".pdf");
                }
                catch (Exception e) { }
                
            }
        }*/

        void generarResolucion()
        {
            try
            {
                object oMissing = System.Reflection.Missing.Value;
                object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */

                //Start Word and create a new document.
                Word._Application oWord;
                Word._Document oDoc;
                oWord = new Word.Application();
                oWord.Visible = true;

                oDoc = oWord.Documents.Add(ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing);

                string nombreAlcaldia = "", nombreSecretaria = "", direccionSecretaria = "", webSecretaria = "", telefonosSecretaria = "";
                string ciudadSecretaria = "", departamentoSecretaria = "", secretarioTransito = "", funcionarioTramite = "";
                string placaVehiculo = "";

                //Recuperar informacion de secretaria de transito
                transito myTransito = new transito();
                ServiciosTransitoService mySerTransito = WS.ServiciosTransitoService();

                logs tmpLog = new logs();
                tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
                tmpLog.OBJETO = "TRANSITO";
                tmpLog.MODULO = "TPUBLICO";
                tmpLog.TIPO_TRANSACCION = "SELECT";
                TimeSpan TS;
                DateTime dt1 = DateTime.Now;

                myTransito = mySerTransito.obtenerTransito();

                DateTime dt2 = DateTime.Now;
                TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
                tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;
                serviciosLogs.crearRegistroLog(tmpLog);


                if (myTransito != null && myTransito.ID_TRANSITO > 0)
                {
                    nombreAlcaldia = myTransito.NOMBREALCALDIA;
                    nombreSecretaria = myTransito.DESCRIPCION;
                    direccionSecretaria = myTransito.DIRECCION;
                    telefonosSecretaria = myTransito.TELEFONOS + " - " + myTransito.FAX1;
                    webSecretaria = myTransito.WEB;
                    secretarioTransito = myTransito.SECRETARIOTRANSITO;
                    funcionarioTramite = myTransito.FUNCIONARIOTRAMITES;

                    ciudad myCiudad = new ciudad();
                    myCiudad.ID_CIUDAD = myTransito.ID_CIUDAD;

                    logs tmpLog1 = new logs();
                    tmpLog1.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                    tmpLog1.ID_USUARIO = usuarioSistema.ID_USUARIO;
                    tmpLog1.OBJETO = "CIIUDAD";
                    tmpLog1.MODULO = "TPUBLICO";
                    tmpLog1.TIPO_TRANSACCION = "SELECT";
                    TimeSpan TS1;
                    DateTime dt11 = DateTime.Now;

                    string objetoAnalizado1 = AnalizadorDeObjetos.analizarObjeto(myCiudad.GetType(), new object[] {  myCiudad });
                    tmpLog1.ESTADO_ANTERIOR = objetoAnalizado1;

                    myCiudad = clienteAccesorias.getCiudadporID(myCiudad);

                    DateTime dt21 = DateTime.Now;
                    TS1 = new TimeSpan(dt21.Ticks - dt11.Ticks);
                    tmpLog1.TIEMPO_EJECUCION = TS1.Milliseconds;
                    serviciosLogs.crearRegistroLog(tmpLog1);

                    ciudadSecretaria = myCiudad.NOMBRE;

                    departamento myDepartamento = new departamento();
                    myDepartamento.CODDPTO = myCiudad.ID_DEPTO;

                    logs tmpLog3 = new logs();
                    tmpLog3.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                    tmpLog3.ID_USUARIO = usuarioSistema.ID_USUARIO;
                    tmpLog3.OBJETO = "TIPOVEHICULO";
                    tmpLog3.MODULO = "TPUBLICO";
                    tmpLog3.TIPO_TRANSACCION = "SELECT";
                    TimeSpan TS3;
                    DateTime dt13 = DateTime.Now;

                    string objetoAnalizado3 = AnalizadorDeObjetos.analizarObjeto(myDepartamento.GetType(), new object[] { myDepartamento });
                    tmpLog.ESTADO_ANTERIOR = objetoAnalizado3;

                    object[] listaDep = clienteAccesorias.getDepartamentos(myDepartamento);

                    DateTime dt23 = DateTime.Now;
                    TS3 = new TimeSpan(dt23.Ticks - dt13.Ticks);
                    tmpLog3.TIEMPO_EJECUCION = TS3.Milliseconds;
                    serviciosLogs.crearRegistroLog(tmpLog3);

                    if (listaDep != null && listaDep.Length > 0)
                    {
                        myDepartamento = (departamento)listaDep[0];
                        departamentoSecretaria = myDepartamento.NOMBRE;
                    }
                }

                string nombreEmpresa = "";
                string numeroTarjeta = "";

                if (cuposeleccionado != null && cuposeleccionado.TT_IDCUPOTAXI > 0)
                {
                    empresasdeServicioTrans myEmpresa = new empresasdeServicioTrans();

                    myEmpresa.ID_EMPSERVICIO = cuposeleccionado.TT_ID_EMPSERVICIO;
                    ServiciosCuposTransService mySerCupo = WS.ServiciosCuposTransService();

                    logs tmpLog4 = new logs();
                    tmpLog4.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                    tmpLog4.ID_USUARIO = usuarioSistema.ID_USUARIO;
                    tmpLog4.OBJETO = "EMPRESASDESERVICIO";
                    tmpLog4.MODULO = "TPUBLICO";
                    tmpLog4.TIPO_TRANSACCION = "SELECT";
                    TimeSpan TS4;
                    DateTime dt14 = DateTime.Now;

                    string objetoAnalizado4 = AnalizadorDeObjetos.analizarObjeto(myEmpresa.GetType(), new object[] { myEmpresa });
                    tmpLog4.ESTADO_ANTERIOR = objetoAnalizado4;

                    object[] listaEmp = mySerCupo.getEmpresaServicio(myEmpresa);

                    DateTime dt24 = DateTime.Now;
                    TS4 = new TimeSpan(dt24.Ticks - dt14.Ticks);
                    tmpLog4.TIEMPO_EJECUCION = TS.Milliseconds;
                    serviciosLogs.crearRegistroLog(tmpLog4);

                    if (listaEmp != null && listaEmp.Length > 0)
                    {
                        myEmpresa = (empresasdeServicioTrans)listaEmp[0];
                        nombreEmpresa = myEmpresa.NOMBRE;
                    }

                    tarjetaOperacion myTarjeta = new tarjetaOperacion();
                    myTarjeta.ID = cuposeleccionado.TT_IDTARJETA;

                    ServiciosTramitesTransService mySerTramite = WS.ServiciosTramitesTransService();

                    logs tmpLog5 = new logs();
                    tmpLog5.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                    tmpLog5.ID_USUARIO = usuarioSistema.ID_USUARIO;
                    tmpLog5.OBJETO = "TIPOVEHICULO";
                    tmpLog5.MODULO = "TPUBLICO";
                    tmpLog5.TIPO_TRANSACCION = "SELECT";
                    TimeSpan TS5;
                    DateTime dt15 = DateTime.Now;

                    string objetoAnalizado5 = AnalizadorDeObjetos.analizarObjeto(myTarjeta.GetType(), new object[] { myTarjeta });
                    tmpLog5.ESTADO_ANTERIOR = objetoAnalizado5;

                    object[] listaTarjeta = mySerTramite.buscarTarjetaOperacion(myTarjeta);

                    DateTime dt25 = DateTime.Now;
                    TS5 = new TimeSpan(dt25.Ticks - dt15.Ticks);
                    tmpLog5.TIEMPO_EJECUCION = TS5.Milliseconds;
                    serviciosLogs.crearRegistroLog(tmpLog5);


                    if (listaTarjeta != null && listaTarjeta.Length > 0)
                    {
                        myTarjeta = (tarjetaOperacion)listaTarjeta[0];
                        numeroTarjeta = myTarjeta.NUMERO;
                    }
                }

                placaVehiculo = placavehiculo.Text;

                //Insert a paragraph at the beginning of the document.
                Word.Paragraph oPara1;
                oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
                oPara1.Range.Text = nombreAlcaldia;
                oPara1.Range.Font.Bold = 1;
                oPara1.Range.Font.Size = 14;
                oPara1.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oPara1.Range.InsertParagraphAfter();

                Word.Paragraph oPara2;
                object oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara2 = oDoc.Content.Paragraphs.Add(ref oMissing);
                oPara2.Range.Text = nombreSecretaria;
                oPara2.Range.Font.Bold = 1;
                oPara2.Range.Font.Size = 12;
                oPara2.Format.SpaceAfter = 24;    //24 pt spacing after paragraph.
                oPara2.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oPara2.Range.InsertParagraphAfter();

                Word.Paragraph oPara3;
                oPara3 = oDoc.Content.Paragraphs.Add(ref oMissing);
                oPara3.Range.Text = "RESOLUCIÓN Nro. " + numeroresolucion.Text;
                oPara3.Range.Font.Bold = 1;
                oPara3.Range.Font.Size = 12;
                oPara3.Format.SpaceAfter = 14;    //24 pt spacing after paragraph.
                oPara3.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oPara3.Range.InsertParagraphAfter();

                Word.Paragraph oPara4;
                oPara4 = oDoc.Content.Paragraphs.Add(ref oMissing);
                oPara4.Range.Text = "Fecha " + fecharesolucion.Text;
                oPara4.Range.Font.Bold = 1;
                oPara4.Range.Font.Size = 12;
                oPara4.Format.SpaceAfter = 14;    //24 pt spacing after paragraph.
                oPara4.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oPara4.Range.InsertParagraphAfter();

                Word.Paragraph oPara5;
                oPara5 = oDoc.Content.Paragraphs.Add(ref oMissing);
                oPara5.Range.Text = "POR MEDIO DE LA CUAL SE AUTORIZA LA DESVINCULACIÓN DE COMÚN ACUERDO, CAMBIO DE SERVICIO Y CAMBIO DE COLOR DE UN VEHÍCULO TIPO " + myTipoVehiculo;
                oPara5.Range.Font.Bold = 1;
                oPara5.Range.Font.Size = 12;
                oPara5.Format.SpaceAfter = 14;    //24 pt spacing after paragraph.
                oPara5.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphJustify;
                oPara5.Range.InsertParagraphAfter();

                Word.Paragraph oPara6;
                oPara6 = oDoc.Content.Paragraphs.Add(ref oMissing);
                oPara6.Range.Text = "EL Secretario de Tránsito y Transporte Municipal de " + ciudadSecretaria + ", en uso de sus facultades legales en especial las que le confiere el Decreto 172 de 2001, Ley 903 Decreto Reglamentario 4116 del 9 de diciembre de 2004, y demás normas afines y concordantes y";
                oPara6.Range.Font.Bold = 0;
                oPara6.Range.Font.Size = 12;
                oPara6.Format.SpaceAfter = 14;    //24 pt spacing after paragraph.
                oPara6.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphJustify;
                oPara6.Range.InsertParagraphAfter();

                Word.Paragraph oPara7;
                oPara7 = oDoc.Content.Paragraphs.Add(ref oMissing);
                oPara7.Range.Text = "CONSIDERANDO";
                oPara7.Range.Font.Bold = 1;
                oPara7.Range.Font.Size = 12;
                oPara7.Format.SpaceAfter = 14;    //24 pt spacing after paragraph.
                oPara7.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oPara7.Range.InsertParagraphAfter();

                Word.Paragraph oPara8;
                oPara8 = oDoc.Content.Paragraphs.Add(ref oMissing);
                oPara8.Range.Text = "Que el decreto 172 de 2001 en su artículo 29 consagra. \"cuando exista acuerdo para la desvinculación del vehículo, la empresa y el propietario del mismo en forma conjunta, informaran por escrito a la autoridad de transporte competente y esta procederá a efectuar el trámite correspondiente desvinculando el vehículo y cancelando la respectiva tarjeta de operación\".";
                oPara8.Range.Font.Bold = 0;
                oPara8.Range.Font.Size = 12;
                oPara8.Format.SpaceAfter = 14;    //24 pt spacing after paragraph.
                oPara8.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphJustify;
                oPara8.Range.InsertParagraphAfter();

                Word.Paragraph oPara9;
                oPara9 = oDoc.Content.Paragraphs.Add(ref oMissing);
                oPara9.Range.Text = "Que el Decreto 4116 de diciembre de 2004, reglamentario de la ley 903 de 2004, que regula el cambio de servicio de público a particular a los vehículos tipo Taxi, en su Artículo 9. Establece: \"CAMBIO DE SERVICIO DE PUBLICO A PARTICULAR.- A partir de la publicación de este Decreto, los propietarios de vehículos tipo taxi, podrán solicitar ante el Organismo de Tránsito y Transporte donde se encuentre registrado el automotor, el cambio de servicio de público a particular, el cual implica el cambio de la licencia de Tránsito y de las placas, siempre y cuando el vehículo tenga una antigüedad en el servicio público, mínima de cinco (5) años.\"";
                oPara9.Range.Font.Bold = 0;
                oPara9.Range.Font.Size = 12;
                oPara9.Format.SpaceAfter = 14;    //24 pt spacing after paragraph.
                oPara9.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphJustify;
                oPara9.Range.InsertParagraphAfter();

                Word.Paragraph oPara10;
                oPara10 = oDoc.Content.Paragraphs.Add(ref oMissing);
                oPara10.Range.Text = "Se ha Recibido en la " + nombreSecretaria + ", la solicitud de desvinculación, cambio de servicio y color del vehículo de las siguientes características:";
                oPara10.Range.Font.Bold = 0;
                oPara10.Range.Font.Size = 12;
                oPara10.Format.SpaceAfter = 14;    //24 pt spacing after paragraph.
                oPara10.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphJustify;
                oPara10.Range.InsertParagraphAfter();

                //Insert a 11 x 2 table, fill it with data, and make the first row
                //bold and italic.
                Word.Table oTable;
                Word.Range wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oTable = oDoc.Tables.Add(wrdRng, 11, 2, ref oMissing, ref oMissing);
                oTable.Range.ParagraphFormat.SpaceAfter = 6;
                oTable.Borders.Enable = 0;
                oTable.Cell(1, 1).Range.Text = "NUMERO INTERNO:";
                oTable.Cell(2, 1).Range.Text = "PLACA PUBLICA:";
                oTable.Cell(3, 1).Range.Text = "CLASE:";
                oTable.Cell(4, 1).Range.Text = "MODELO:";
                oTable.Cell(5, 1).Range.Text = "MARCA:";
                oTable.Cell(6, 1).Range.Text = "MOTOR:";
                oTable.Cell(7, 1).Range.Text = "CHASIS:";
                oTable.Cell(8, 1).Range.Text = "COLOR:";
                oTable.Cell(9, 1).Range.Text = "EMPRESA A QUE PERTENECE:";
                oTable.Cell(10, 1).Range.Text = "PROPIETARIO:";
                oTable.Cell(11, 1).Range.Text = "IDENTIFICACIÓN:";
                //INFORMACION DE LA BASE
                oTable.Cell(1, 2).Range.Text = "276";
                oTable.Cell(2, 2).Range.Text = placavehiculo.Text;
                oTable.Cell(3, 2).Range.Text = clasevehiculo.Text;
                oTable.Cell(4, 2).Range.Text = modelovehi;
                oTable.Cell(5, 2).Range.Text = marcavehiculo.Text;
                oTable.Cell(6, 2).Range.Text = numeromotor.Text;
                oTable.Cell(7, 2).Range.Text = numerochasis.Text;
                oTable.Cell(8, 2).Range.Text = colorVehiAntiguo;
                oTable.Cell(9, 2).Range.Text = nombreEmpresa;
                oTable.Cell(10, 2).Range.Text = nombrespropietario.Text + " " + primerapellido.Text + " " + segundoapellido.Text;
                oTable.Cell(11, 2).Range.Text = identificacionpropietario.Text.Trim();

                oTable.Rows[1].Range.Font.Bold = 0;

                //Add some text after the table.
                Word.Paragraph oPara12;
                oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara12 = oDoc.Content.Paragraphs.Add(ref oRng);
                oPara12.Range.InsertParagraphBefore();
                oPara12.Range.Text = "Continuación Resolución No." + numeroresolucion.Text + " vehículo de Placas " + placaVehiculo + " de Fecha " + fecharesolucion.Text;
                oPara12.Format.SpaceAfter = 14;
                oPara12.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphJustify;
                oPara12.Range.InsertParagraphAfter();

                Word.Paragraph oPara13;
                oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara13 = oDoc.Content.Paragraphs.Add(ref oRng);
                oPara13.Range.InsertParagraphBefore();
                oPara13.Range.Text = "Revisada la documentación presentada ante la Secretaria se encontró la documentación en orden y acorde a lo estipulado en el artículo 29 del decreto 172 de 2001, e igualmente su situación se atempera a lo reglamentado  en el decreto 4116 de 2004.";
                oPara13.Format.SpaceAfter = 14;
                oPara13.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphJustify;
                oPara13.Range.InsertParagraphAfter();

                Word.Paragraph oPara14;
                oPara14 = oDoc.Content.Paragraphs.Add(ref oMissing);
                oPara14.Range.Text = "RESUELVE";
                oPara14.Range.Font.Bold = 1;
                oPara14.Range.Font.Size = 12;
                oPara14.Format.SpaceAfter = 14;    //24 pt spacing after paragraph.
                oPara14.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oPara14.Range.InsertParagraphAfter();

                Word.Paragraph oPara15;
                oPara15 = oDoc.Content.Paragraphs.Add(ref oMissing);
                oPara15.Range.Text = "ARTÍCULO PRIMERO: Autorizar la Desvinculación de la Empresa " + nombreEmpresa + ", al vehículo de placas " + placaVehiculo + ", Propietario: " + nombrespropietario.Text + " " + primerapellido.Text + " " + segundoapellido.Text + " con documento de identidad No. " + identificacionpropietario.Text.Trim() + " y con las siguientes características:";
                oPara15.Range.Font.Bold = 0;
                oPara15.Range.Font.Size = 12;
                oPara15.Format.SpaceAfter = 14;    //24 pt spacing after paragraph.
                oPara15.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphJustify;
                oPara15.Range.InsertParagraphAfter();

                //Insert a 6 x 2 table, fill it with data, and make the first row
                //bold and italic.
                Word.Table oTable2;
                wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oTable2 = oDoc.Tables.Add(wrdRng, 6, 2, ref oMissing, ref oMissing);
                oTable2.Range.ParagraphFormat.SpaceAfter = 6;
                oTable2.Borders.Enable = 0;
                oTable2.Cell(1, 1).Range.Text = "NUMERO INTERNO:";
                oTable2.Cell(2, 1).Range.Text = "PLACA PUBLICA:";
                oTable2.Cell(3, 1).Range.Text = "CLASE:";
                oTable2.Cell(4, 1).Range.Text = "MODELO:";
                oTable2.Cell(5, 1).Range.Text = "MARCA:";
                oTable2.Cell(6, 1).Range.Text = "MOTOR:";
                //INFORMACION DE LA BASE
                oTable2.Cell(1, 2).Range.Text = "276";
                oTable2.Cell(2, 2).Range.Text = placavehiculo.Text;
                oTable2.Cell(3, 2).Range.Text = clasevehiculo.Text;
                oTable2.Cell(4, 2).Range.Text = modelovehi;
                oTable2.Cell(5, 2).Range.Text = marcavehiculo.Text;
                oTable2.Cell(6, 2).Range.Text = numeromotor.Text;

                oTable2.Rows[1].Range.Font.Bold = 0;

                string complementoTarjetaOperacion = "";

                if (!String.IsNullOrEmpty(numeroTarjeta))
                    complementoTarjetaOperacion = "No. " + numeroTarjeta;

                //Add some text after the table.
                Word.Paragraph oPara16;
                oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara16 = oDoc.Content.Paragraphs.Add(ref oRng);
                oPara16.Range.InsertParagraphBefore();
                oPara16.Range.Text = "ARTÍCULO SEGUNDO: Cancelar la respectiva tarjeta de Operación " + complementoTarjetaOperacion;
                oPara16.Format.SpaceAfter = 14;
                oPara16.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphJustify;
                oPara16.Range.InsertParagraphAfter();

                Word.Paragraph oPara17;
                oPara17 = oDoc.Content.Paragraphs.Add(ref oMissing);
                oPara17.Range.Text = "ARTÍCULO TERCERO: Autorizar el cambio de servicio de público a particular del vehículo: ";
                oPara17.Range.Font.Bold = 0;
                oPara17.Range.Font.Size = 12;
                oPara17.Format.SpaceAfter = 14;    //24 pt spacing after paragraph.
                oPara17.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphJustify;
                oPara17.Range.InsertParagraphAfter();

                //Insert a 6 x 2 table, fill it with data, and make the first row
                //bold and italic.
                Word.Table oTable3;
                wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oTable3 = oDoc.Tables.Add(wrdRng, 6, 2, ref oMissing, ref oMissing);
                oTable3.Range.ParagraphFormat.SpaceAfter = 6;
                oTable3.Borders.Enable = 0;
                oTable3.Cell(1, 1).Range.Text = "NUMERO INTERNO:";
                oTable3.Cell(2, 1).Range.Text = "PLACA PUBLICA:";
                oTable3.Cell(3, 1).Range.Text = "CLASE:";
                oTable3.Cell(4, 1).Range.Text = "MODELO:";
                oTable3.Cell(5, 1).Range.Text = "MARCA:";
                oTable3.Cell(6, 1).Range.Text = "MOTOR:";
                //INFORMACION DE LA BASE
                oTable3.Cell(1, 2).Range.Text = "276";
                oTable3.Cell(2, 2).Range.Text = placavehiculo.Text;
                oTable3.Cell(3, 2).Range.Text = clasevehiculo.Text;
                oTable3.Cell(4, 2).Range.Text = modelovehi;
                oTable3.Cell(5, 2).Range.Text = marcavehiculo.Text;
                oTable3.Cell(6, 2).Range.Text = numeromotor.Text;

                //Add some text after the table.
                Word.Paragraph oPara18;
                oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara18 = oDoc.Content.Paragraphs.Add(ref oRng);
                oPara18.Range.InsertParagraphBefore();
                oPara18.Range.Text = "ARTÍCULO CUARTO: Autorizar el cambio de color " + colorVehiAntiguo + " a:";
                oPara18.Format.SpaceAfter = 14;
                oPara18.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphJustify;
                oPara18.Range.InsertParagraphAfter();

                //Insert a 1 x 2 table, fill it with data, and make the first row
                //bold and italic.
                Word.Table oTable4;
                wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oTable4 = oDoc.Tables.Add(wrdRng, 1, 2, ref oMissing, ref oMissing);
                oTable4.Range.ParagraphFormat.SpaceAfter = 6;
                oTable4.Borders.Enable = 0;
                oTable4.Cell(1, 1).Range.Text = "COLOR:";
                //INFORMACION DE LA BASE
                oTable4.Cell(1, 2).Range.Text = nuevocolor.Text;

                Word.Paragraph oPara19;
                oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara19 = oDoc.Content.Paragraphs.Add(ref oRng);
                oPara19.Range.InsertParagraphBefore();
                oPara19.Range.Text = "ARTÍCULO QUINTO: Contra el presente acto administrativo procede, el recurso de REPOSICIÓN para este despacho, y de APELACIÓN ante el Señor ALCALDE DE " + ciudadSecretaria + ", dentro de los cinco (5) días siguientes a la notificación personal o por edicto.";
                oPara19.Format.SpaceAfter = 14;
                oPara19.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphJustify;
                oPara19.Range.InsertParagraphAfter();

                Word.Paragraph oPara20;
                oPara20 = oDoc.Content.Paragraphs.Add(ref oMissing);
                oPara20.Range.Text = "NOTIFIQUESE Y CUMPLASE";
                oPara20.Range.Font.Bold = 1;
                oPara20.Range.Font.Size = 12;
                oPara20.Format.SpaceAfter = 14;    //24 pt spacing after paragraph.
                oPara20.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oPara20.Range.InsertParagraphAfter();

                Word.Paragraph oPara21;
                oPara21 = oDoc.Content.Paragraphs.Add(ref oMissing);
                oPara21.Range.Text = "Dada en " + ciudadSecretaria + " en la fecha " + clienteAccesorias.getFechaActualTexto();
                oPara21.Range.Font.Bold = 0;
                oPara21.Range.Font.Size = 12;
                oPara21.Format.SpaceAfter = 34;    //24 pt spacing after paragraph.
                oPara21.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphJustify;
                oPara21.Range.InsertParagraphAfter();

                Word.Paragraph oPara22;
                oPara22 = oDoc.Content.Paragraphs.Add(ref oMissing);
                oPara22.Range.Text = secretarioTransito;
                oPara22.Range.Font.Bold = 0;
                oPara22.Range.Font.Size = 12;
                oPara22.Format.SpaceAfter = 5;    //24 pt spacing after paragraph.
                oPara22.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oPara22.Range.InsertParagraphAfter();

                Word.Paragraph oPara23;
                oPara23 = oDoc.Content.Paragraphs.Add(ref oMissing);
                oPara23.Range.Text = "Secretario de Tránsito y Transporte Municipal";
                oPara23.Range.Font.Bold = 1;
                oPara23.Range.Font.Size = 12;
                oPara23.Format.SpaceAfter = 24;    //24 pt spacing after paragraph.
                oPara23.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oPara23.Range.InsertParagraphAfter();

                Word.Paragraph oPara24;
                oPara24 = oDoc.Content.Paragraphs.Add(ref oMissing);
                oPara24.Range.Text = "Elaboro/" + funcionarioTramite;
                oPara24.Range.Font.Bold = 0;
                oPara24.Range.Font.Size = 12;
                oPara24.Format.SpaceAfter = 24;    //24 pt spacing after paragraph.
                oPara24.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphJustify;
                oPara24.Range.InsertParagraphAfter();

                //Insert a paragraph at the end of the document.
                Word.Paragraph oPara25;
                oPara25 = oDoc.Content.Paragraphs.Add(ref oMissing);
                oPara25.Range.Text = direccionSecretaria + " Teléfonos " + telefonosSecretaria + " " + "<" + webSecretaria + ">" + " línea transparente: 018000913891 " + ciudadSecretaria + "-" + departamentoSecretaria;
                oPara25.Format.SpaceAfter = 6;
                oPara25.Range.Bold = 1;
                oPara25.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oPara25.Range.InsertParagraphAfter();
            }
            catch (Exception exp)
            {
                funciones.mostrarMensaje("Hubo un error al generar el documento", "E");
            }
        }

        private void rdNumeroCupo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdNumeroCupo.Checked)
            {
                txtNumeroCupo.Enabled = true;
                txtPlaca.Enabled = false;
                tipovehiculo.Enabled = true;
            }
            else
            {
                txtNumeroCupo.Enabled = false;
                txtPlaca.Enabled = true;
                tipovehiculo.Enabled = false;
            }
        }

        private void rdPlaca_CheckedChanged(object sender, EventArgs e)
        {
            if (rdPlaca.Checked)
            {
                txtPlaca.Enabled = true;
                txtNumeroCupo.Enabled = false;
                tipovehiculo.Enabled = false;
            }
            else
            {
                txtPlaca.Enabled = false;
                txtNumeroCupo.Enabled = true;
                tipovehiculo.Enabled = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            limpiarCampos();

            if (rdNumeroCupo.Checked)
            {
                if (!txtNumeroCupo.Text.Equals(""))
                {
                    buscarCupoNumero();

                    if (cuposeleccionado != null && cuposeleccionado.TT_IDCUPOTAXI > 0)
                    {
                        llenarCamposVehiculo(cuposeleccionado.TT_ID_VEHICULO);
                        buscarPropietarios(cuposeleccionado.TT_ID_VEHICULO);
                        numeroresolucion.Focus();
                    }
                }
                else
                {
                    funciones.mostrarMensaje("El campo número de cupo no puede ser vacio", "W");
                }
            }
            else
            {
                if (!txtPlaca.Text.Equals(""))
                {
                    vehiculo myVehiculo = new vehiculo();
                    myVehiculo.PLACA = txtPlaca.Text;

                    ServiciosVehiculosService mySerVehi = WS.ServiciosVehiculosService();

                    logs tmpLog = new logs();
                    tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                    tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
                    tmpLog.OBJETO = "VEHICULO";
                    tmpLog.MODULO = "TPUBLICO";
                    tmpLog.TIPO_TRANSACCION = "SELECT";
                    TimeSpan TS;
                    DateTime dt1 = DateTime.Now;

                    string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(myVehiculo.GetType(), new object[] { myVehiculo });
                    tmpLog.ESTADO_ANTERIOR = objetoAnalizado;

                    myVehiculo = mySerVehi.getVehiculo(myVehiculo);

                    DateTime dt2 = DateTime.Now;
                    TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
                    tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;
                    serviciosLogs.crearRegistroLog(tmpLog);

                    if (myVehiculo != null && myVehiculo.ID_VEHICULO > 0)
                    {
                        buscarCupoVehiculo(myVehiculo.ID_VEHICULO);

                        if (cuposeleccionado != null && cuposeleccionado.TT_IDCUPOTAXI > 0)
                        {
                            llenarCamposVehiculo(cuposeleccionado.TT_ID_VEHICULO);
                            buscarPropietarios(cuposeleccionado.TT_ID_VEHICULO);
                            numeroresolucion.Focus();
                        }
                    }
                    else
                    {
                        funciones.mostrarMensaje("Vehiculo no encontrado", "W");
                    }
                }
                else
                {
                    funciones.mostrarMensaje("El campo placa no puede ser vacio", "W");
                }
            }
        }

        void buscarCupoVehiculo(int idVehiculo)
        {
            cuposTaxisTrans elcupos = new cuposTaxisTrans();
            elcupos.TT_ID_VEHICULO = idVehiculo;

            logs tmpLog = new logs();
            tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
            tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
            tmpLog.OBJETO = "T_CUPOSTAXIS";
            tmpLog.MODULO = "TPUBLICO";
            tmpLog.TIPO_TRANSACCION = "SELECT";
            TimeSpan TS;
            DateTime dt1 = DateTime.Now;

            string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(elcupos.GetType(), new object[] { elcupos });
            tmpLog.ESTADO_ANTERIOR = objetoAnalizado;

            listacuposs = (Object[])clienteCuposTrans.getSCupos(elcupos);

            DateTime dt2 = DateTime.Now;
            TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
            tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;
            serviciosLogs.crearRegistroLog(tmpLog);

            if (listacuposs != null && listacuposs.Length >= 0)
            {
                cuposeleccionado = (cuposTaxisTrans)listacuposs[0];
                btnSave.Enabled = true;
                informacionderegistro.Enabled = true;

                tipoVehiculoTrans myVehiculoTrans = new tipoVehiculoTrans();
                myVehiculoTrans.ID = int.Parse(cuposeleccionado.TT_TIPOVEH);

                logs tmpLog1 = new logs();
                tmpLog1.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                tmpLog1.ID_USUARIO = usuarioSistema.ID_USUARIO;
                tmpLog1.OBJETO = "TIPOVEHICULO";
                tmpLog1.MODULO = "TPUBLICO";
                tmpLog1.TIPO_TRANSACCION = "SELECT";
                TimeSpan TS1;
                DateTime dt11 = DateTime.Now;

                string objetoAnalizado1 = AnalizadorDeObjetos.analizarObjeto(myVehiculoTrans.GetType(), new object[] { myVehiculoTrans });
                tmpLog1.ESTADO_ANTERIOR = objetoAnalizado1;

                object[] listaTipo = clienteCuposTrans.buscarTipoVehiculoTrans(myVehiculoTrans);

                DateTime dt21 = DateTime.Now;
                TS1 = new TimeSpan(dt21.Ticks - dt11.Ticks);
                tmpLog1.TIEMPO_EJECUCION = TS1.Milliseconds;
                serviciosLogs.crearRegistroLog(tmpLog1);

                if (listaTipo != null && listaTipo.Length > 0)
                {
                    myVehiculoTrans = (tipoVehiculoTrans)listaTipo[0];
                    myTipoVehiculo = myVehiculoTrans.NOMBRE;
                }
            }
            else
            {
                btnSave.Enabled = false;
                informacionderegistro.Enabled = false;
                funciones.mostrarMensaje("No se encontraron coincidencias con ese número de placa", "W");
            }
        }

        void buscarCupoNumero()
        {
            if (tipovehiculo.SelectedIndex > -1)
            {
                cuposTaxisTrans elcupos = new cuposTaxisTrans();

                elcupos.TT_TIPOVEH = tipovehiculo.SelectedValue.ToString();
                elcupos.TT_NUMCUPO = int.Parse(txtNumeroCupo.Text);

                logs tmpLog = new logs();
                tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
                tmpLog.OBJETO = "T_CUPOSTAXIS";
                tmpLog.MODULO = "TPUBLICO";
                tmpLog.TIPO_TRANSACCION = "SELECT";
                TimeSpan TS;
                DateTime dt1 = DateTime.Now;

                string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(elcupos.GetType(), new object[] { elcupos });
                tmpLog.ESTADO_ANTERIOR = objetoAnalizado;

                listacuposs = (Object[])clienteCuposTrans.getSCupos(elcupos);

                DateTime dt2 = DateTime.Now;
                TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
                tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;
                serviciosLogs.crearRegistroLog(tmpLog);

                if (listacuposs != null && listacuposs.Length >= 0)
                {
                    cuposeleccionado = (cuposTaxisTrans)listacuposs[0];

                    btnSave.Enabled = true;
                    informacionderegistro.Enabled = true;
                    tipoVehiculoTrans myVehiculoTrans = new tipoVehiculoTrans();

                    myVehiculoTrans.ID = int.Parse(cuposeleccionado.TT_TIPOVEH);

                    logs tmpLog1 = new logs();
                    tmpLog1.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                    tmpLog1.ID_USUARIO = usuarioSistema.ID_USUARIO;
                    tmpLog1.OBJETO = "TIPOVEHICULO";
                    tmpLog1.MODULO = "TPUBLICO";
                    tmpLog1.TIPO_TRANSACCION = "SELECT";
                    TimeSpan TS1;
                    DateTime dt11 = DateTime.Now;

                    string objetoAnalizado1 = AnalizadorDeObjetos.analizarObjeto(myVehiculoTrans.GetType(), new object[] { myVehiculoTrans});
                    tmpLog1.ESTADO_ANTERIOR = objetoAnalizado1;

                    DateTime dt21 = DateTime.Now;
                    TS1 = new TimeSpan(dt21.Ticks - dt11.Ticks);
                    tmpLog1.TIEMPO_EJECUCION = TS1.Milliseconds;
                    serviciosLogs.crearRegistroLog(tmpLog1);

                    object[] listaTipo = clienteCuposTrans.buscarTipoVehiculoTrans(myVehiculoTrans);

                    if (listaTipo != null && listaTipo.Length > 0)
                    {
                        myVehiculoTrans = (tipoVehiculoTrans)listaTipo[0];
                        myTipoVehiculo = myVehiculoTrans.NOMBRE;
                    }
                }
                else
                {
                    btnSave.Enabled = false;
                    informacionderegistro.Enabled = false;
                    funciones.mostrarMensaje("No se encontraron coincidencias con ese número de cupo", "W");
                }
            }
        }

        private void llenarCamposVehiculo(int idVehiculo)
        {
            if (idVehiculo > 0)
            {
                vehiculo myVehi = new vehiculo();
                myVehi.ID_VEHICULO = idVehiculo;
                ServiciosVehiculosService mySerVehi = WS.ServiciosVehiculosService();

                logs tmpLog = new logs();
                tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
                tmpLog.OBJETO = "VEHICULO";
                tmpLog.MODULO = "TPUBLICO";
                tmpLog.TIPO_TRANSACCION = "SELECT";
                TimeSpan TS;
                DateTime dt1 = DateTime.Now;

                string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(myVehi.GetType(), new object[] { myVehi });
                tmpLog.ESTADO_ANTERIOR = objetoAnalizado;
                
                myVehi = mySerVehi.getVehiculo(myVehi);

                DateTime dt2 = DateTime.Now;
                TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
                tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;
                serviciosLogs.crearRegistroLog(tmpLog);

                if (myVehi != null && myVehi.ID_VEHICULO > 0)
                {
                    contenedorvehiculo.Enabled = true;
                    viewVehiculo myViewVehiculo = new viewVehiculo();
                    myViewVehiculo.PLACA = myVehi.PLACA;
                    ServiciosViewVehiculoService mySerViewVehi = WS.ServiciosViewVehiculoService();

                    logs tmpLog1 = new logs();
                    tmpLog1.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                    tmpLog1.ID_USUARIO = usuarioSistema.ID_USUARIO;
                    tmpLog1.OBJETO = "TIPOVEHICULO";
                    tmpLog1.MODULO = "TPUBLICO";
                    tmpLog1.TIPO_TRANSACCION = "SELECT";
                    TimeSpan TS1;
                    DateTime dt11 = DateTime.Now;

                    string objetoAnalizado1 = AnalizadorDeObjetos.analizarObjeto(myViewVehiculo.GetType(), new object[] { myViewVehiculo });
                    tmpLog1.ESTADO_ANTERIOR = objetoAnalizado1;

                    object[] listVehiculo = mySerViewVehi.getSViewVehiculo(myViewVehiculo);

                    DateTime dt21 = DateTime.Now;
                    TS1 = new TimeSpan(dt21.Ticks - dt11.Ticks);
                    tmpLog1.TIEMPO_EJECUCION = TS1.Milliseconds;
                    serviciosLogs.crearRegistroLog(tmpLog1);

                    if (listVehiculo != null && listVehiculo.Length > 0)
                    {
                        myViewVehiculo = (viewVehiculo)listVehiculo[0];
                        marcavehiculo.Text = myViewVehiculo.MARCAVEH;
                        lineavehiculo.Text = myViewVehiculo.LINEAVEH;
                        clasevehiculo.Text = myViewVehiculo.CLASEVEH;
                        numerochasis.Text = myViewVehiculo.NUMEROCHASIS;
                        tipocarroseria.Text = myViewVehiculo.TIPOCARROCERIA;
                        numeromotor.Text = myViewVehiculo.NUMEROMOTOR;
                        modelovehi = myViewVehiculo.MODELO;
                        placavehiculo.Text = myViewVehiculo.PLACA;
                        colorVehiAntiguo = myViewVehiculo.COLORVEH;
                    }

                    ServiciosPropietariosService mySerProp = WS.ServiciosPropietariosService();
                    propietarioDeVehiculo myPropietariosVehi = new propietarioDeVehiculo();
                    myPropietariosVehi.ID_VEHICULO = myVehi.ID_VEHICULO;
                    myPropietariosVehi.PROPIETARIOACTUAL = "T";

                    logs tmpLog2 = new logs();
                    tmpLog2.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                    tmpLog2.ID_USUARIO = usuarioSistema.ID_USUARIO;
                    tmpLog2.OBJETO = "PROPIETARIODEVEHICULO";
                    tmpLog2.MODULO = "TPUBLICO";
                    tmpLog2.TIPO_TRANSACCION = "SELECT";
                    TimeSpan TS2;
                    DateTime dt12 = DateTime.Now;

                    string objetoAnalizado2 = AnalizadorDeObjetos.analizarObjeto(myPropietariosVehi.GetType(), new object[] { myPropietariosVehi});
                    tmpLog2.ESTADO_ANTERIOR = objetoAnalizado2;

                    object[] listaProp = mySerProp.getPropietariosDeVehiculos(myPropietariosVehi);

                    DateTime dt22 = DateTime.Now;
                    TS2 = new TimeSpan(dt22.Ticks - dt12.Ticks);
                    tmpLog2.TIEMPO_EJECUCION = TS2.Milliseconds;
                    serviciosLogs.crearRegistroLog(tmpLog2);

                    if (listaProp != null && listaProp.Length > 0)
                    {
                        contenedorpropietarios.Enabled = true;
                        if (listaProp.Length > 0)
                        {
                            btnprimero.Enabled = true;
                            btnanterior.Enabled = true;
                            btnsiguiente.Enabled = true;
                            btnultimo.Enabled = true;
                        }
                        else
                        {
                            btnprimero.Enabled = false;
                            btnanterior.Enabled = false;
                            btnsiguiente.Enabled = false;
                            btnultimo.Enabled = false;
                        }
                        cargarPropietario(listaProp, 0);
                    }
                }
            }
        }

        private void buscarPropietarios(int idVehiculo)
        {
            ServiciosPropietariosService mySerProp = WS.ServiciosPropietariosService();
            propietarioDeVehiculo propietariosss = new propietarioDeVehiculo();

            propietariosss.ID_VEHICULO = idVehiculo;
            propietariosss.PROPIETARIOACTUAL = "T";

            logs tmpLog = new logs();
            tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
            tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
            tmpLog.OBJETO = "PROPIETARIODEVEHICULO";
            tmpLog.MODULO = "TPUBLICO";
            tmpLog.TIPO_TRANSACCION = "SELECT";
            TimeSpan TS;
            DateTime dt1 = DateTime.Now;

            string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(propietariosss.GetType(), new object[] { propietariosss  });
            tmpLog.ESTADO_ANTERIOR = objetoAnalizado;

            listapropietariosaaa = (Object[])mySerProp.getPropietariosDeVehiculos(propietariosss);

            DateTime dt2 = DateTime.Now;
            TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
            tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;
            serviciosLogs.crearRegistroLog(tmpLog);

            if (listapropietariosaaa != null && listapropietariosaaa.Length > 0)
            {
                btnSave.Enabled = true;

                if (listapropietariosaaa.Length > 0)
                {
                    btnprimero.Enabled = true;
                    btnanterior.Enabled = true;
                    btnsiguiente.Enabled = true;
                    btnultimo.Enabled = true;
                }
                else
                {
                    btnprimero.Enabled = false;
                    btnanterior.Enabled = false;
                    btnsiguiente.Enabled = false;
                    btnultimo.Enabled = false;
                }

                cargarPropietario(listapropietariosaaa, 0);
            }
            else
            {
                btnSave.Enabled = false;
                funciones.mostrarMensaje("No se encontraron propietarios", "I");
            }
        }

        private void cargarPropietario(Object[] listadopropietarios, int npropietario)
        {
            propietarioDeVehiculo elpropietario = new propietarioDeVehiculo();
            elpropietario = (propietarioDeVehiculo)listadopropietarios[npropietario];

            if (elpropietario.EMPPER != "" && elpropietario.EMPPER == "PER")
            {
                quees = 1;
                idp = elpropietario.ID_PROPIETARIO;
                cargarPersona(elpropietario.ID_PROPIETARIO);
                contenedorpersona.Visible = true;
                contenedorempresa.Visible = false;
            }
            else if (elpropietario.EMPPER != "" && elpropietario.EMPPER == "EMP")
            {
                quees = 2;
                idp = elpropietario.ID_PROPIETARIO;
                cargarEmpresa(elpropietario.ID_PROPIETARIO);
                contenedorpersona.Visible = false;
                contenedorempresa.Visible = true;
            }
        }

        private void cargarPersona(int idperson)
        {
            ServiciosPersonasService mySerPer = WS.ServiciosPersonasService();
            Funciones funciones = WS.Funciones();
            Object[] listad = (Object[])clienteAccesorias.getDocumentos();

            if (listad != null)
            {
                clasedocumento.DataSource = null;
                clasedocumento.DisplayMember = "DESCRIPCION";
                clasedocumento.ValueMember = "ID_DOCTO";
                funciones.llenarCombo(clasedocumento, listad);
            }

            persona person = new persona();
            persona lapersona = new persona();
            person.ID_PERSONAS = idperson;
            lapersona = mySerPer.getPersona(person);

            clasedocumento.SelectedValue = lapersona.ID_DOCTO;
            identificacionpropietario.Text = lapersona.IDENTIFICACION;
            nombrespropietario.Text = lapersona.NOMBRES;
            primerapellido.Text = lapersona.APELLIDO1;
            segundoapellido.Text = lapersona.APELLIDO2;
            direccionpropietario.Text = lapersona.DIRECCION;
            telefonopropietario.Text = lapersona.TELEFONO;

            if (lapersona.ID_MUNICIPIO != "" && lapersona.ID_MUNICIPIO != null)
            {
                ciudad ciuda = new ciudad();
                ciudad laciudad = new ciudad();

                ciuda.ID_CIUDAD = Int32.Parse(lapersona.ID_MUNICIPIO);

                logs tmpLog = new logs();
                tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
                tmpLog.OBJETO = "CIUDAD";
                tmpLog.MODULO = "TPUBLICO";
                tmpLog.TIPO_TRANSACCION = "SELECT";
                TimeSpan TS;
                DateTime dt1 = DateTime.Now;

                string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(ciuda.GetType(), new object[] { ciuda });
                tmpLog.ESTADO_ANTERIOR = objetoAnalizado;

                laciudad = clienteAccesorias.getCiudadporID(ciuda);

                DateTime dt2 = DateTime.Now;
                TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
                tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;
                serviciosLogs.crearRegistroLog(tmpLog);

                if (laciudad != null)
                {
                    codigociudad.Text = laciudad.CODCIUDAD;
                    nombreciudad.Text = laciudad.NOMBRE;
                }
            }
        }

        private void cargarEmpresa(int idempres)
        {
            ServiciosEmpresasService mySerEmp = WS.ServiciosEmpresasService();
            empresa empres = new empresa();
            empresa laempresa = new empresa();

            empres.ID_EMPRESA = idempres;

            logs tmpLog = new logs();
            tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
            tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
            tmpLog.OBJETO = "EMPRESA";
            tmpLog.MODULO = "TPUBLICO";
            tmpLog.TIPO_TRANSACCION = "SELECT";
            TimeSpan TS;
            DateTime dt1 = DateTime.Now;

            string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(empres.GetType(), new object[] { empres });
            tmpLog.ESTADO_ANTERIOR = objetoAnalizado;

            Object[] lempres = (Object[])mySerEmp.getEmpresa(empres);

            DateTime dt2 = DateTime.Now;
            TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
            tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;
            serviciosLogs.crearRegistroLog(tmpLog);

            if (lempres != null && lempres.Length >= 0)
            {
                laempresa = (empresa)lempres[0];
                identificacionpropietario.Text = laempresa.NIT;
                nombrespropietario.Text = laempresa.RAZONSOCIAL;
            }
        }

        private void btnprimero_Click(object sender, EventArgs e)
        {
            if (listapropietariosaaa != null)
            {
                cargarPropietario(listapropietariosaaa, 0);
            }
        }

        private void btnultimo_Click(object sender, EventArgs e)
        {
            if (listapropietariosaaa != null)
            {
                int fin = listapropietariosaaa.Length - 1;
                cargarPropietario(listapropietariosaaa, fin);
            }
        }

        private void btnsiguiente_Click(object sender, EventArgs e)
        {
            if (listapropietariosaaa != null)
            {
                if (numpropietario < listapropietariosaaa.Length - 1)
                {
                    numpropietario = numpropietario + 1;
                    cargarPropietario(listapropietariosaaa, numpropietario);
                }
            }
        }

        private void btnanterior_Click(object sender, EventArgs e)
        {
            if (listapropietariosaaa != null)
            {
                if (numpropietario > 0)
                {
                    numpropietario = numpropietario - 1;
                    cargarPropietario(listapropietariosaaa, numpropietario);
                }
            }
        }

        private void txtNumeroCupo_KeyPress(object sender, KeyPressEventArgs e)
        {

            Funciones myFun = WS.Funciones();
            myFun.esNumero(e);

            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (!txtNumeroCupo.Text.Equals(""))
                {
                    limpiarCampos();
                    buscarCupoNumero();
                    if (cuposeleccionado != null && cuposeleccionado.TT_IDCUPOTAXI > 0)
                    {
                        llenarCamposVehiculo(cuposeleccionado.TT_ID_VEHICULO);
                        buscarPropietarios(cuposeleccionado.TT_ID_VEHICULO);
                    }
                }
                else
                {
                    funciones.mostrarMensaje("El campo número de cupo no puede ser vacio", "W");
                }
            }
        }

        private void txtPlaca_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones myFun = WS.Funciones();
            myFun.esAlfanumerico(e);

            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (!txtPlaca.Text.Equals(""))
                {
                    limpiarCampos();
                    vehiculo myVehiculo = new vehiculo();
                    myVehiculo.PLACA = txtPlaca.Text;

                    ServiciosVehiculosService mySerVehi = WS.ServiciosVehiculosService();

                    logs tmpLog = new logs();
                    tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                    tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
                    tmpLog.OBJETO = "VEHICULO";
                    tmpLog.MODULO = "TPUBLICO";
                    tmpLog.TIPO_TRANSACCION = "SELECT";
                    TimeSpan TS;
                    DateTime dt1 = DateTime.Now;

                    string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(myVehiculo.GetType(), new object[] { myVehiculo });
                    tmpLog.ESTADO_ANTERIOR = objetoAnalizado;
                    
                    myVehiculo = mySerVehi.getVehiculo(myVehiculo);

                    DateTime dt2 = DateTime.Now;
                    TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
                    tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;
                    serviciosLogs.crearRegistroLog(tmpLog);

                    if (myVehiculo != null && myVehiculo.ID_VEHICULO > 0)
                    {
                        buscarCupoVehiculo(myVehiculo.ID_VEHICULO);
                        if (cuposeleccionado != null && cuposeleccionado.TT_IDCUPOTAXI > 0)
                        {
                            llenarCamposVehiculo(cuposeleccionado.TT_ID_VEHICULO);
                            buscarPropietarios(cuposeleccionado.TT_ID_VEHICULO);
                        }
                    }
                    else
                    {
                        funciones.mostrarMensaje("Vehiculo no encontrado", "W");
                    }
                }
                else
                {
                    funciones.mostrarMensaje("El campo placa no puede ser vacio", "W");
                }
            }
        }

        private void limpiarCampos()
        {
            btnprimero.Enabled = false;
            btnanterior.Enabled = false;
            btnsiguiente.Enabled = false;
            btnultimo.Enabled = false;
            listapropietariosaaa = null;
            placavehiculo.Text = "";
            marcavehiculo.Text = "";
            lineavehiculo.Text = "";
            clasevehiculo.Text = "";
            numerochasis.Text = "";
            tipocarroseria.Text = "";
            numeromotor.Text = "";
            //POPIETARIO
            clasedocumento.DataSource = null;
            clasedocumento.DisplayMember = "DESCRIPCION";
            clasedocumento.ValueMember = "ID_DOCTO";
            identificacionpropietario.Text = "";
            nombrespropietario.Text = "";
            primerapellido.Text = "";
            segundoapellido.Text = "";
            direccionpropietario.Text = "";
            telefonopropietario.Text = "";
            codigociudad.Text = "";
            nombreciudad.Text = "";
            cuposeleccionado = new cuposTaxisTrans();
            informacionderegistro.Enabled = false;
        }
    }
}
