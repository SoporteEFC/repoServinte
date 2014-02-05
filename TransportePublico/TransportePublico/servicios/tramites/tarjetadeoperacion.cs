using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibreriasSintrat.ServiciosVehiculos;
using LibreriasSintrat.ServiciosAccesorias;
using LibreriasSintrat.ServiciosCuposTrans;
using LibreriasSintrat.ServiciosTramitesTrans;
using TransportePublico.servicios.reportes.tarjetaOperacion;
using LibreriasSintrat.utilidades;
using LibreriasSintrat.ServiciosConfiguraciones;
using TransportePublico.servicios.documentos;
using LibreriasSintrat.forms.documentos;
using Word = Microsoft.Office.Interop.Word;
using System.IO;
using LibreriasSintrat.ServiciosLogs;
using LibreriasSintrat.ServiciosUsuarios;
 

namespace TransportePublico.servicios.tramites
{
    public partial class tarjetadeoperacion : Form
    {
        ServiciosLogsService serviciosLogs;
        usuarios usuarioSistema;

        ServiciosVehiculosService mySerVeh;
        ServiciosAccesoriasService mySerAcc;
        ServiciosCuposTransService mySerCupos;
        ServiciosTramitesTransService mySerTramite;
        Funciones funciones;
        Log log = new Log();

        bool reimprimir = false;
        string fechaVenActual = "";

        bool buscarinicial = false;

        DateTime dtFechaVencimiento;

        bool dtpCambiado;

        string radioAccion = "";

        bool estadoImprimir = false;

        public tarjetadeoperacion(usuarios user)
        {
            usuarioSistema = user;
            serviciosLogs = WS.ServiciosLogsService();

            InitializeComponent();
            mySerAcc = WS.ServiciosAccesoriasService();
            funciones = WS.Funciones();
            mySerCupos = WS.ServiciosCuposTransService();
            mySerVeh = WS.ServiciosVehiculosService();
            mySerTramite = WS.ServiciosTramitesTransService();
            log = new Log();

            dtpCambiado = false;

            limpiarCampos();

            getRadioAccion();
        }

        //--    Funciones varias
        #region Funciones varias

        public void buscarVehiculo()
        {
            vehiculo myVehiculo = new vehiculo();
            combustible myCombustible = new combustible();
            claseVehiculo myClaseVehiculo = new claseVehiculo();
            niveldeServicio myNivelServicio = new niveldeServicio();
            cuposTaxisTrans myCupo = new cuposTaxisTrans();
            tipCarroceria myTipoCarroceria = new tipCarroceria();
            empresasdeServicioTrans myEmpresa = new empresasdeServicioTrans();

            //limpiar datos:
            buscarinicial = true;
            limpiarCampos();

            txtnrotarjeta.Text = "";
            txtnrotarjeta.ReadOnly = false;

            //dtpFechaVencimiento.Text = DateTime.Now.ToString("dd/MM/yyyy");
            //dtpFechaVencimiento.Enabled = true;

            //txtradioaccion.Text = "";
            txtrazonsocial.Text = "";

            btnSave.Enabled = true;
            btnimprimir.Visible = false;

            if (!txtplacaunica.Text.Equals(""))
            {
                myVehiculo.PLACA = txtplacaunica.Text;
                myVehiculo = mySerVeh.getVehiculo(myVehiculo);

                if (myVehiculo != null && myVehiculo.ID_VEHICULO > 0)
                {
                    myCupo.TT_ID_VEHICULO = myVehiculo.ID_VEHICULO;

                    try
                    {
                        logs tmpLog = new logs();
                        tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                        tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
                        tmpLog.OBJETO = "T_CUPOSTAXIS";
                        tmpLog.MODULO = "TPUBLICO";
                        tmpLog.TIPO_TRANSACCION = "SELECT";
                        TimeSpan TS;
                        DateTime dt1 = DateTime.Now;
                        string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(myCupo.GetType(), new object[] { myCupo});
                        tmpLog.ESTADO_ANTERIOR = objetoAnalizado;
            
                        myCupo = mySerCupos.getOneCuposTaxis(myCupo);

                        DateTime dt2 = DateTime.Now;
                        TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
                        tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;
                        serviciosLogs.crearRegistroLog(tmpLog);
                        //myCupo.TT_IDTARJETA;

                        if (myCupo != null && myCupo.TT_IDCUPOTAXI > 0)
                        {
                            if (myVehiculo.ID_COMBUSTIBLE != null)
                            {
                                myCombustible.ID_COMBUSTIBLE = int.Parse(myVehiculo.ID_COMBUSTIBLE);

                                int idtipoCombustible = myCombustible.ID_COMBUSTIBLE;

                                logs tmpLog2 = new logs();
                                tmpLog2.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                                tmpLog2.ID_USUARIO = usuarioSistema.ID_USUARIO;
                                tmpLog2.OBJETO = "COMBUSTIBLE";
                                tmpLog2.MODULO = "TPUBLICO";
                                tmpLog2.TIPO_TRANSACCION = "SELECT";
                                TimeSpan TS2;
                                DateTime dt12 = DateTime.Now;

                                string objetoAnalizado2 = AnalizadorDeObjetos.analizarObjeto(myCombustible.GetType(), new object[] { myCombustible });
                                tmpLog.ESTADO_ANTERIOR = objetoAnalizado2;

                                object[] listTipoCombustible = mySerAcc.getTipoCombustible(myCombustible);

                                DateTime dt22 = DateTime.Now;
                                TS2 = new TimeSpan(dt22.Ticks - dt12.Ticks);
                                tmpLog2.TIEMPO_EJECUCION = TS2.Milliseconds;
                                serviciosLogs.crearRegistroLog(tmpLog2);
                                combustible combustibleAsoc;

                                if (listTipoCombustible != null && listTipoCombustible.Length > 0)
                                {
                                    //myCombustible = (combustible)listTipoCombustible[0];

                                    for (int el = 0; el < listTipoCombustible.Length; el++) 
                                    {
                                        combustibleAsoc = (combustible)listTipoCombustible[el];

                                        if (combustibleAsoc.ID_COMBUSTIBLE == idtipoCombustible)
                                        {
                                            txtclasecombustible.Text = ((combustible)listTipoCombustible[el]).DESCRIPCION;
                                            break;
                                        }
                                    }

                                    if (String.IsNullOrEmpty(txtclasecombustible.Text))
                                        txtclasecombustible.Text = ((combustible)listTipoCombustible[0]).DESCRIPCION;
                                }
                            }

                            myClaseVehiculo.ID_CVEHICULO = int.Parse(myVehiculo.ID_CVEHICULO);


                            object[] listClaseVehiculo = mySerAcc.getClaseVehiculo(myClaseVehiculo);

                            if (listClaseVehiculo != null && listClaseVehiculo.Length > 0)
                            {
                                myClaseVehiculo = (claseVehiculo)listClaseVehiculo[0];

                                txtclasevehiculo.Text = myClaseVehiculo.DESCRIPCION;
                            }

                            int idmarca = -1;
                            int.TryParse(myVehiculo.ID_MARCAPPAL, out idmarca);

                            logs tmpLog7 = new logs();
                            tmpLog7.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                            tmpLog7.ID_USUARIO = usuarioSistema.ID_USUARIO;
                            tmpLog7.OBJETO = "MARCA";
                            tmpLog7.MODULO = "TPUBLICO";
                            tmpLog7.TIPO_TRANSACCION = "SELECT";
                            TimeSpan TS7;
                            DateTime dt17 = DateTime.Now;

                            string objetoAnalizado3 = AnalizadorDeObjetos.analizarObjeto(idmarca.GetType(), new object[] { idmarca });
                            tmpLog7.ESTADO_ANTERIOR = objetoAnalizado3;

                            txtmarca.Text = mySerAcc.getDescMarca(idmarca);

                            DateTime dt27 = DateTime.Now;
                            TS7 = new TimeSpan(dt27.Ticks - dt17.Ticks);
                            tmpLog7.TIEMPO_EJECUCION = TS7.Milliseconds;
                            serviciosLogs.crearRegistroLog(tmpLog7);

                            txtmodelo.Text = myVehiculo.MODELO;

                            if (myVehiculo.ID_NIVELSERVICIO != null)
                                myNivelServicio.ID_NIVEL = int.Parse(myVehiculo.ID_NIVELSERVICIO);
                            
                            logs tmpLog6 = new logs();
                            tmpLog6.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                            tmpLog6.ID_USUARIO = usuarioSistema.ID_USUARIO;
                            tmpLog6.OBJETO = "NIVELDESERVICIO";
                            tmpLog6.MODULO = "TPUBLICO";
                            tmpLog6.TIPO_TRANSACCION = "SELECT";
                            TimeSpan TS6;
                            DateTime dt16 = DateTime.Now;

                            string objetoAnalizado4 = AnalizadorDeObjetos.analizarObjeto(myNivelServicio.GetType(), new object[] { myNivelServicio });
                            tmpLog6.ESTADO_ANTERIOR = objetoAnalizado4;

                            object[] listNivelServicio = mySerAcc.getNivelServicio(myNivelServicio);

                            DateTime dt26 = DateTime.Now;
                            TS6 = new TimeSpan(dt26.Ticks - dt16.Ticks);
                            tmpLog6.TIEMPO_EJECUCION = TS6.Milliseconds;
                            serviciosLogs.crearRegistroLog(tmpLog6);

                            if (listNivelServicio != null && listNivelServicio.Length > 0)
                            {
                                myNivelServicio = (niveldeServicio)listNivelServicio[0];

                                txtnivelservicio.Text = myNivelServicio.DESCRIPCION;
                            }

                            myTipoCarroceria.ID_TCARROCERIA = int.Parse(myVehiculo.ID_TCARROCERIA);

                            int idTipoCarroceria = myTipoCarroceria.ID_TCARROCERIA;

                            logs tmpLog5 = new logs();
                            tmpLog5.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                            tmpLog5.ID_USUARIO = usuarioSistema.ID_USUARIO;
                            tmpLog5.OBJETO = "TIPCARROCERIA";
                            tmpLog5.MODULO = "TPUBLICO";
                            tmpLog5.TIPO_TRANSACCION = "SELECT";
                            TimeSpan TS5;
                            DateTime dt15 = DateTime.Now;

                            string objetoAnalizado5 = AnalizadorDeObjetos.analizarObjeto(myClaseVehiculo.GetType(), new object[] { myClaseVehiculo});
                            tmpLog.ESTADO_ANTERIOR = objetoAnalizado5;

                            object[] listCarroceria = mySerAcc.getCarroceria(myTipoCarroceria, myClaseVehiculo);

                            DateTime dt25 = DateTime.Now;
                            TS5 = new TimeSpan(dt25.Ticks - dt15.Ticks);
                            tmpLog5.TIEMPO_EJECUCION = TS5.Milliseconds;
                            serviciosLogs.crearRegistroLog(tmpLog5);

                            tipCarroceria tipoCarroceriaAsoc;

                            if (listCarroceria != null && listCarroceria.Length > 0)
                            {
                                //myTipoCarroceria = (tipCarroceria)listCarroceria[0];

                                for (int el = 0; el < listCarroceria.Length; el++)
                                {
                                    tipoCarroceriaAsoc = (tipCarroceria)listCarroceria[el];

                                    if (tipoCarroceriaAsoc.ID_TCARROCERIA == idTipoCarroceria)
                                    {
                                        txttipocarroceria.Text = tipoCarroceriaAsoc.DESCRIPCION;
                                        break;
                                    }
                                }

                                if (String.IsNullOrEmpty(txttipocarroceria.Text))
                                {
                                    txttipocarroceria.Text = ((tipCarroceria)listCarroceria[0]).DESCRIPCION;
                                }
                            }

                            txtnumeromotor.Text = myVehiculo.NRO_MOTOR;
                            txtpasajeros.Text = myVehiculo.CAPACIDAD;
                            txttoneladas.Text = myVehiculo.CAPACIDADTON;

                            if (myCupo.TT_ID_EMPSERVICIO > 0)
                            {
                                myEmpresa.ID_EMPSERVICIO = myCupo.TT_ID_EMPSERVICIO;

                                logs tmpLog8 = new logs();
                                tmpLog8.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                                tmpLog8.ID_USUARIO = usuarioSistema.ID_USUARIO;
                                tmpLog8.OBJETO = "EMPRESASDESERVICIO";
                                tmpLog8.MODULO = "TPUBLICO";
                                tmpLog8.TIPO_TRANSACCION = "SELECT";
                                TimeSpan TS8;
                                DateTime dt18 = DateTime.Now;

                                string objetoAnalizado8 = AnalizadorDeObjetos.analizarObjeto(myEmpresa.GetType(), new object[] { myEmpresa});
                                tmpLog8.ESTADO_ANTERIOR = objetoAnalizado8;

                                object[] listEmpresasServicio = mySerCupos.getTEmpresasServicio(myEmpresa);

                                DateTime dt28 = DateTime.Now;
                                TS8 = new TimeSpan(dt28.Ticks - dt18.Ticks);
                                tmpLog.TIEMPO_EJECUCION = TS8.Milliseconds;
                                serviciosLogs.crearRegistroLog(tmpLog8);


                                if (listEmpresasServicio != null && listEmpresasServicio.Length > 0)
                                {
                                    myEmpresa = (empresasdeServicioTrans)listEmpresasServicio[0];

                                    txtrazonsocial.Text = myEmpresa.NOMBRE;
                                }
                            }

                            txtnrocupo.Text = myCupo.TT_NUMCUPO.ToString();
                            lblradioaccion.Visible = true;
                            //txtradioaccion.Visible = true;
                            cmbRadioAccion.Visible = true;
                            lblzonaoperacion.Visible = true;
                            txtzonaoperacion.Visible = true;
                            txtnrotarjeta.Visible = true;
                            lblnrotarjeta.Visible = true;
                            lblfecha.Visible = true;
                            dtpFechaVencimiento.Visible = true;
                            btnSave.Visible = true;
                            //txtradioaccion.Focus();
                            cmbRadioAccion.Focus();
                            //dateTimePicker1.
                        }
                        else
                        {
                            funciones.mostrarMensaje("El vehículo no tiene cupo asignado!", "I");
                            buscarinicial = false;
                            limpiarCampos();
                        }
                    }
                    catch (Exception exce)
                    {
                        funciones.mostrarMensaje("Ocurrió un error en la búsqueda", "E");
                        buscarinicial = false;
                        limpiarCampos();
                    }
                }
                else
                {
                    funciones.mostrarMensaje("El vehículo no ha sido encontrado en el Sistema!", "W");
                    buscarinicial = false;
                    limpiarCampos();
                }
            }
            else
            {
                funciones.mostrarMensaje("Digite un número de placa!", "W");
                buscarinicial = false;
                limpiarCampos();
            }
        }

        public void limpiarCampos()
        {
            txtclasecombustible.Clear();
            txtclasevehiculo.Clear();
            txtmarca.Clear();
            txtmodelo.Clear();
            txtnivelservicio.Clear();
            txtnrocupo.Clear();
            txtnrotarjeta.Clear();
            txtnumeromotor.Clear();
            txtpasajeros.Clear();

            if(!buscarinicial)
                txtplacaunica.Clear();

            //txtradioaccion.Clear();
            cmbRadioAccion.Text = "";
            txtrazonsocial.Clear();
            txttipocarroceria.Clear();
            txttoneladas.Clear();
            txtzonaoperacion.Clear();

            if (!dtpCambiado)
                dtpFechaVencimiento.Text = DateTime.Now.AddDays(365).ToString("dd/MM/yyyy");
            dtpFechaVencimiento.Enabled = true;
        }

        public void crearTarjetaOperacion(cuposTaxisTrans cupoAsoc, tarjetaOperacion toperacion)
        {
            historicoCupoTrans myHistorico = new historicoCupoTrans();

            try
            {
                myHistorico.IDCUPO = cupoAsoc.TT_IDCUPOTAXI;
                toperacion.ESTADO = "activo";
                toperacion.FECHAVENCIMIENTO = funciones.convFormatoFecha(dtpFechaVencimiento.Text, "MM/dd/yyyy");
                toperacion.IDCUPO = cupoAsoc.TT_IDCUPOTAXI;

                logs tmpLog9 = new logs();
                tmpLog9.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                tmpLog9.ID_USUARIO = usuarioSistema.ID_USUARIO;
                tmpLog9.OBJETO = "TT_HISTORICOCUPO";
                tmpLog9.MODULO = "TPUBLICO";
                tmpLog9.TIPO_TRANSACCION = "SELECT";
                TimeSpan TS9;
                DateTime dt19 = DateTime.Now;

                string objetoAnalizado9 = AnalizadorDeObjetos.analizarObjeto(myHistorico.GetType(), new object[] { myHistorico});
                tmpLog9.ESTADO_ANTERIOR = objetoAnalizado9;


                myHistorico = (historicoCupoTrans)((Object[])mySerCupos.getSHistoricoCuposTaxis(myHistorico))[0];

                DateTime dt29 = DateTime.Now;
                TS9 = new TimeSpan(dt29.Ticks - dt19.Ticks);
                tmpLog9.TIEMPO_EJECUCION = TS9.Milliseconds;
                serviciosLogs.crearRegistroLog(tmpLog9);

                if (myHistorico != null && myHistorico.ID > 0)
                {
                    toperacion.IDHISTORICOCUPO = myHistorico.ID;
                }

                logs tmpLog10 = new logs();
                tmpLog10.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                tmpLog10.ID_USUARIO = usuarioSistema.ID_USUARIO;
                tmpLog10.OBJETO = "TT_TARJETAOPERACION";
                tmpLog10.MODULO = "TPUBLICO";
                tmpLog10.TIPO_TRANSACCION = "INSERT";
                TimeSpan TS10;
                DateTime dt110 = DateTime.Now;

                string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(toperacion.GetType(), new object[] { toperacion });
                
                tmpLog10.ESTADO_ANTERIOR = objetoAnalizado;

                toperacion = mySerTramite.crearTarjetaOperacion(toperacion);

                DateTime dt210 = DateTime.Now;
                TS10 = new TimeSpan(dt210.Ticks - dt110.Ticks);
                tmpLog10.TIEMPO_EJECUCION = TS10.Milliseconds;
                serviciosLogs.crearRegistroLog(tmpLog10);

                if (toperacion != null && toperacion.ID > 0)
                {
                    funciones.mostrarMensaje("Tarjeta de Operación almacenada correctamente!", "I");

                    txtnrotarjeta.Enabled = false;
                    //txtradioaccion.Enabled = false;
                    cmbRadioAccion.Enabled = false;
                    txtzonaoperacion.Enabled = false;
                    dtpFechaVencimiento.Enabled = false;
                    txtplacaunica.Enabled = false;
                    btnimprimir.Visible = true;
                    btnbuscar.Enabled = false;
                    btnSave.Enabled = false;
                    btnimprimir.Focus();
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public void imprimirTO(string fechaVencimientoAsociado)
        {
            try
            {
                estadoImprimir = true;
                
                ServiciosConfiguracionesService serviciosConfiguraciones = WS.ServiciosConfiguracionesService();

                object fileName = serviciosConfiguraciones.leerRegistroIni("PLANTILLAS") + "\\tarjeta_de_operacionVertical.dotx";
                transferir myTransferencia = new transferir();
                myTransferencia.archivoDelServerSinAbrir((String)fileName);

                Dictionary<string, string> dicVariablesValores = new Dictionary<string, string>();
                                

                dicVariablesValores.Add("FECHA_VENCIMIENTO", fechaVencimientoAsociado); //dtpFechaVencimiento.Text
                dicVariablesValores.Add("CLASE_VEHICULO", txtclasevehiculo.Text);
                dicVariablesValores.Add("PLACA", txtplacaunica.Text);
                dicVariablesValores.Add("CLASE_COMBUSTIBLE", txtclasecombustible.Text);
                dicVariablesValores.Add("TIPO_CARROCERIA", txttipocarroceria.Text);
                dicVariablesValores.Add("MARCA", txtmarca.Text);
                dicVariablesValores.Add("MODELO", txtmodelo.Text);
                dicVariablesValores.Add("NUMERO_MOTOR", txtnumeromotor.Text);
                dicVariablesValores.Add("NIVEL_SERVICIO", txtnivelservicio.Text);
                dicVariablesValores.Add("CAPACIDAD_PASAJEROS", txtpasajeros.Text);
                dicVariablesValores.Add("CAPACIDAD_TONELADAS", txttoneladas.Text);
                dicVariablesValores.Add("RAZON_SOCIAL", txtrazonsocial.Text);

                //dicVariablesValores.Add("RADIO_ACCION", txtradioaccion.Text);
                dicVariablesValores.Add("RADIO_ACCION", radioAccion);

                dicVariablesValores.Add("ZONA_OPERACION", txtzonaoperacion.Text);
                dicVariablesValores.Add("NRO_TARJETA", txtnrotarjeta.Text);
                dicVariablesValores.Add("NRO_INTERNO", "Documento");
                dicVariablesValores.Add("CUPO", txtnrocupo.Text);

                String rutaarchivo = (String)fileName;

                Word.Application oWord;
                Word.Document oDoc;

                oWord = new Word.Application();
                oWord.Visible = false;
                


                object newTmp = System.Reflection.Missing.Value;
                object DocType = false;
                object visible = true;
                object Readonly = true;
                object missing = Type.Missing;
                

                // Ubicación de la plantilla en el disco duro
                
                oDoc = oWord.Documents.Add(ref fileName, ref newTmp, ref DocType, ref visible);
                                
                //oDoc = oWord.Documents.Open(ref fileName, ref missing, ref Readonly, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);

                object objTmp;

                objTmp = "PLACA";
                oDoc.Bookmarks.get_Item(ref objTmp).Range.Text = dicVariablesValores["PLACA"] != null ? dicVariablesValores["PLACA"] : "";

                objTmp = "CAPACIDADTONELADAS";
                oDoc.Bookmarks.get_Item(ref objTmp).Range.Text = dicVariablesValores["CAPACIDAD_TONELADAS"] != null ? dicVariablesValores["CAPACIDAD_TONELADAS"] : "";

                objTmp = "CLASECOMBUSTIBLE";
                oDoc.Bookmarks.get_Item(ref objTmp).Range.Text = dicVariablesValores["CLASE_COMBUSTIBLE"] != null ? dicVariablesValores["CLASE_COMBUSTIBLE"] : "";

                objTmp = "CLASEVEHICULO";
                oDoc.Bookmarks.get_Item(ref objTmp).Range.Text = dicVariablesValores["CLASE_VEHICULO"] != null ? dicVariablesValores["CLASE_VEHICULO"] : "";

                objTmp = "EMPRESASERVICIO";
                oDoc.Bookmarks.get_Item(ref objTmp).Range.Text = dicVariablesValores["RAZON_SOCIAL"] != null ? dicVariablesValores["RAZON_SOCIAL"] : "";

                objTmp = "FECHAVENCIMIENTO";
                oDoc.Bookmarks.get_Item(ref objTmp).Range.Text = dicVariablesValores["FECHA_VENCIMIENTO"] != null ? dicVariablesValores["FECHA_VENCIMIENTO"] : "";

                objTmp = "MARCA";
                oDoc.Bookmarks.get_Item(ref objTmp).Range.Text = dicVariablesValores["MARCA"] != null ? dicVariablesValores["MARCA"] : "";

                objTmp = "MODELO";
                oDoc.Bookmarks.get_Item(ref objTmp).Range.Text = dicVariablesValores["MODELO"] != null ? dicVariablesValores["MODELO"] : "";

                objTmp = "NIVELSERVICIO";
                oDoc.Bookmarks.get_Item(ref objTmp).Range.Text = dicVariablesValores["NIVEL_SERVICIO"] != null ? dicVariablesValores["NIVEL_SERVICIO"] : "";

                objTmp = "NUMEROCUPO";
                oDoc.Bookmarks.get_Item(ref objTmp).Range.Text = dicVariablesValores["CUPO"] != null ? dicVariablesValores["CUPO"] : "";

                objTmp = "NUMERODEMOTOR";
                oDoc.Bookmarks.get_Item(ref objTmp).Range.Text = dicVariablesValores["NUMERO_MOTOR"] != null ? dicVariablesValores["NUMERO_MOTOR"] : "";

                objTmp = "NUMEROINTERNO";
                oDoc.Bookmarks.get_Item(ref objTmp).Range.Text = "Documento";

                objTmp = "NUMEROTARJETA";
                oDoc.Bookmarks.get_Item(ref objTmp).Range.Text = dicVariablesValores["NRO_TARJETA"] != null ? dicVariablesValores["NRO_TARJETA"] : "";

                objTmp = "PASAJEROS";
                oDoc.Bookmarks.get_Item(ref objTmp).Range.Text = dicVariablesValores["CAPACIDAD_PASAJEROS"] != null ? dicVariablesValores["CAPACIDAD_PASAJEROS"] : "";

                objTmp = "RADIOACCION";
                oDoc.Bookmarks.get_Item(ref objTmp).Range.Text = dicVariablesValores["RADIO_ACCION"] != null ? dicVariablesValores["RADIO_ACCION"] : "";

                objTmp = "TIPOCARROCERIA";
                oDoc.Bookmarks.get_Item(ref objTmp).Range.Text = dicVariablesValores["TIPO_CARROCERIA"] != null ? dicVariablesValores["TIPO_CARROCERIA"] : "";

                objTmp = "ZONAOPERACION";
                oDoc.Bookmarks.get_Item(ref objTmp).Range.Text = dicVariablesValores["ZONA_OPERACION"] != null ? dicVariablesValores["ZONA_OPERACION"] : "";

                fileName = serviciosConfiguraciones.leerRegistroIni("DOCUMENTOS") + "\\TarjetaOperacion_" + dicVariablesValores["PLACA"] + "_" + System.DateTime.Now.ToString("ddMMyyyyHHmmss");

                
                oDoc.SaveAs(ref fileName, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);

                
                oWord.Quit(ref missing, ref missing, ref missing);

                //esperando a que word cierre
                System.Threading.Thread.Sleep(1000);

                fileName = (String)fileName + ".docx";

                //Abriendo documento generado
                oWord = new Word.Application();
                oWord.Visible = true;
                
                oWord.Documents.Open(ref fileName, ref missing, ref Readonly, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
                              

                

            }
            catch
            {
                throw;
            }

        }



        public void imprimirTarjetaOperacion(string fechaVencimientoAsociado)
        {
            try
            {
                estadoImprimir = true;
                
                ServiciosConfiguracionesService serviciosConfiguraciones = WS.ServiciosConfiguracionesService();

                object fileName = serviciosConfiguraciones.leerRegistroIni("PLANTILLAS") + "\\tarjeta_de_operacion.dotx";
                transferir myTransferencia = new transferir();
                myTransferencia.archivoDelServerSinAbrir((String)fileName);

                ProcesadorDocumentos myProcesadorDocs = new ProcesadorDocumentos();

                Dictionary<string, string> dicVariablesValores = new Dictionary<string, string>();

                dicVariablesValores.Add("FECHA_VENCIMIENTO", fechaVencimientoAsociado); //dtpFechaVencimiento.Text
                dicVariablesValores.Add("CLASE_VEHICULO", txtclasevehiculo.Text);
                dicVariablesValores.Add("PLACA", txtplacaunica.Text);
                dicVariablesValores.Add("CLASE_COMBUSTIBLE", txtclasecombustible.Text);
                dicVariablesValores.Add("TIPO_CARROCERIA", txttipocarroceria.Text);
                dicVariablesValores.Add("MARCA", txtmarca.Text);
                dicVariablesValores.Add("MODELO", txtmodelo.Text);
                dicVariablesValores.Add("NUMERO_MOTOR", txtnumeromotor.Text);
                dicVariablesValores.Add("NIVEL_SERVICIO", txtnivelservicio.Text);
                dicVariablesValores.Add("CAPACIDAD_PASAJEROS", txtpasajeros.Text);
                dicVariablesValores.Add("CAPACIDAD_TONELADAS", txttoneladas.Text);
                dicVariablesValores.Add("RAZON_SOCIAL", txtrazonsocial.Text);

                //dicVariablesValores.Add("RADIO_ACCION", txtradioaccion.Text);
                dicVariablesValores.Add("RADIO_ACCION", radioAccion);

                dicVariablesValores.Add("ZONA_OPERACION", txtzonaoperacion.Text);
                dicVariablesValores.Add("NRO_TARJETA", txtnrotarjeta.Text);
                dicVariablesValores.Add("NRO_INTERNO", "Documento");
                dicVariablesValores.Add("CUPO", txtnrocupo.Text);

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
                    //FrmGeneradorDocumentos myformGenerarDoc = new FrmGeneradorDocumentos(fileName.ToString(), misDocumentos + "\\Siatt\\TarjetaOperacion" + DateTime.Now.ToString("yyyyMMdd"), contenido, true, false, false, false, true, false, Modulo.Transporte_Publico);
                    FrmGeneradorDocumentos myformGenerarDoc = new FrmGeneradorDocumentos(fileName.ToString(), misDocumentos + "\\Siatt\\TarjetaOperacion" + DateTime.Now.ToString("yyyyMMdd"), contenido, false, true, false, false, true, false, Modulo.Transporte_Publico, true); //con redimension del tamaño del documento impreso, en word
                    //FrmGeneradorDocumentos myformGenerarDoc = new FrmGeneradorDocumentos(fileName.ToString(), misDocumentos + "\\Siatt\\TarjetaOperacion" + DateTime.Now.ToString("yyyyMMdd"), contenido, true, false, false, false, false, true, Modulo.Transporte_Publico, true);//con redimension del tamaño del documento impreso, en PDF

                    DialogResult dr = myformGenerarDoc.ShowDialog(this);

                    if (dr == DialogResult.OK)
                    {
                        String rutaguardar = myformGenerarDoc.rutaG;
                    }
                }
                else
                    funciones.mostrarMensaje("Error al generar la tarjeta de operación.", "E");
            }
            catch (Exception exp)
            {
                //funciones.mostrarMensaje("Error inesperado al generar la tarjeta de operación: " + exp.Message, "E");

                throw exp;
            }
        }

        public void getRadioAccion()
        {
            using (LibreriasSintrat.wsServiciosAccesorias.ServiciosAccesoriasService clienteAccesoriasAvaluos = new LibreriasSintrat.wsServiciosAccesorias.ServiciosAccesoriasService())
            {
                logs tmpLog = new logs();
                tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
                tmpLog.OBJETO = "RUNTRADIOACCION";
                tmpLog.MODULO = "TPUBLICO";
                tmpLog.TIPO_TRANSACCION = "SELECT";
                TimeSpan TS;
                DateTime dt1 = DateTime.Now;

                Object[] listaRadioAccion = (Object[])clienteAccesoriasAvaluos.listarRuntradioaccion();

                DateTime dt2 = DateTime.Now;
                TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
                tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;
                serviciosLogs.crearRegistroLog(tmpLog);
                //funciones.llenarCombo(cmbRadioAccion, listaRadioAccion);

                //llenar combo Radio Accion

                LibreriasSintrat.wsServiciosAccesorias.runtradioaccion runtdaccion;

                if (listaRadioAccion != null && listaRadioAccion.Length > 0) 
                {
                    for (int el = 0; el < listaRadioAccion.Length; el++) 
                    {
                        runtdaccion = (LibreriasSintrat.wsServiciosAccesorias.runtradioaccion)listaRadioAccion[el];

                        cmbRadioAccion.Items.Add(runtdaccion.DESCRIPCION);
                    }
                }               
            }
        }

        #endregion

        //--    Eventos formulario
        #region Eventos formulario

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            buscarVehiculo();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            estadoImprimir = false;
            
            tarjetaOperacion toperacion = new tarjetaOperacion();
            cuposTaxisTrans myCupo = new cuposTaxisTrans();
            vehiculo myVehiculo = new vehiculo();

            historicoCupoTrans myHistorico = new historicoCupoTrans();

            /*if(cmbRadioAccion.SelectedItem != null)
            {
               radioAccion = cmbRadioAccion.SelectedItem.ToString();
            }
            else radioAccion = cmbRadioAccion.Text.ToUpper();*/

            try
            {
                //if (!txtnrotarjeta.Text.Equals("") && !txtradioaccion.Text.Equals("") && !txtzonaoperacion.Text.Equals(""))
                if (!txtnrotarjeta.Text.Equals("") && !radioAccion.Equals("") && !txtzonaoperacion.Text.Equals(""))
                {
                    toperacion.NUMERO = txtnrotarjeta.Text;

                    logs tmpLog13 = new logs();
                    tmpLog13.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                    tmpLog13.ID_USUARIO = usuarioSistema.ID_USUARIO;
                    tmpLog13.OBJETO = "TT_TARJETAOPERACION";
                    tmpLog13.MODULO = "TPUBLICO";
                    tmpLog13.TIPO_TRANSACCION = "SELECT";
                    TimeSpan TS13;
                    DateTime dt113 = DateTime.Now;

                    string objetoAnalizado13 = AnalizadorDeObjetos.analizarObjeto(toperacion.GetType(), new object[] { toperacion});
                    tmpLog13.ESTADO_ANTERIOR = objetoAnalizado13;

                    object[] listaTarjetas = mySerTramite.buscarTarjetaOperacion(toperacion);

                    DateTime dt213 = DateTime.Now;
                    TS13 = new TimeSpan(dt213.Ticks - dt113.Ticks);
                    tmpLog13.TIEMPO_EJECUCION = TS13.Milliseconds;
                    serviciosLogs.crearRegistroLog(tmpLog13);


                    if (listaTarjetas == null || listaTarjetas.Count() < 0)
                    {
                        myVehiculo.PLACA = txtplacaunica.Text;
                        myVehiculo = mySerVeh.getVehiculo(myVehiculo);

                        if (myVehiculo != null && myVehiculo.ID_VEHICULO > 0)
                        {
                            myCupo.TT_ID_VEHICULO = myVehiculo.ID_VEHICULO;

                            logs tmpLog12 = new logs();
                            tmpLog12.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                            tmpLog12.ID_USUARIO = usuarioSistema.ID_USUARIO;
                            tmpLog12.OBJETO = "T_CUPOSTAXIS";
                            tmpLog12.MODULO = "TPUBLICO";
                            tmpLog12.TIPO_TRANSACCION = "SELECT";
                            TimeSpan TS12;
                            DateTime dt112 = DateTime.Now;

                            string objetoAnalizado12 = AnalizadorDeObjetos.analizarObjeto(myCupo.GetType(), new object[] { myCupo});
                            tmpLog12.ESTADO_ANTERIOR = objetoAnalizado12;

                            myCupo = mySerCupos.getOneCuposTaxis(myCupo);

                            DateTime dt212 = DateTime.Now;
                            TS12 = new TimeSpan(dt212.Ticks - dt112.Ticks);
                            tmpLog12.TIEMPO_EJECUCION = TS12.Milliseconds;
                            serviciosLogs.crearRegistroLog(tmpLog12);


                            if (myCupo != null && myCupo.TT_IDCUPOTAXI > 0)
                            {
                                bool val = true;

                                tarjetaOperacion tarjetaOperacionTemp = new tarjetaOperacion();
                                tarjetaOperacionTemp.IDCUPO = myCupo.TT_IDCUPOTAXI;

                                //toperacion.IDCUPO = myCupo.TT_IDCUPOTAXI;

                                //buscando si hay tarjetas de operación anteriores...
                                logs tmpLog11 = new logs();
                                tmpLog11.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                                tmpLog11.ID_USUARIO = usuarioSistema.ID_USUARIO;
                                tmpLog11.OBJETO = "TT_TARJETAOPERACION";
                                tmpLog11.MODULO = "TPUBLICO";
                                tmpLog11.TIPO_TRANSACCION = "SELECT";
                                TimeSpan TS11;
                                DateTime dt111 = DateTime.Now;

                                string objetoAnalizado11 = AnalizadorDeObjetos.analizarObjeto(tarjetaOperacionTemp.GetType(), new object[] { tarjetaOperacionTemp});
                                tmpLog11.ESTADO_ANTERIOR = objetoAnalizado11;

                                object[] listaTO = mySerTramite.buscarTarjetaOperacion(tarjetaOperacionTemp);

                                DateTime dt211 = DateTime.Now;
                                TS11 = new TimeSpan(dt211.Ticks - dt111.Ticks);
                                tmpLog11.TIEMPO_EJECUCION = TS11.Milliseconds;
                                serviciosLogs.crearRegistroLog(tmpLog11);


                                if (listaTO != null && listaTO.Length > 0)
                                {
                                    string fechaServidor = mySerAcc.getFechaHora("MM/dd/yyyy");

                                    DateTime dtFechaActualSistema;
                                    dtFechaActualSistema = DateTime.Parse(fechaServidor, System.Globalization.CultureInfo.InvariantCulture);

                                    for (int il = 0; il < listaTO.Length; il++)
                                    {
                                        logs tmpLog = new logs();
                                        tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                                        tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
                                        tmpLog.OBJETO = "TT_TARJETAOPERACION";
                                        tmpLog.MODULO = "TPUBLICO";
                                        tmpLog.TIPO_TRANSACCION = "UPDATE";
                                        TimeSpan TS;
                                        DateTime dt1 = DateTime.Now;


                                        tarjetaOperacion tarjetaOperacionAsoc = new tarjetaOperacion();
                                        tarjetaOperacionAsoc = (tarjetaOperacion)listaTO[il];

                                        string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(tarjetaOperacionAsoc.GetType(), new object[] { tarjetaOperacionAsoc });
                                        tmpLog.ESTADO_ANTERIOR = objetoAnalizado;

                                        dtFechaVencimiento = DateTime.Parse(tarjetaOperacionAsoc.FECHAVENCIMIENTO, System.Globalization.CultureInfo.InvariantCulture);

                                        int valorVigencia = DateTime.Compare(dtFechaActualSistema, dtFechaVencimiento);

                                        if (tarjetaOperacionAsoc.ESTADO.Equals("activo"))
                                        {
                                            if (valorVigencia >= 0)
                                            {
                                                tarjetaOperacionAsoc.ESTADO = "inactivo";

                                                string objetoAnalizado1 = AnalizadorDeObjetos.analizarObjeto(tarjetaOperacionAsoc.GetType(), new object[] { tarjetaOperacionAsoc});
                                                tmpLog.ESTADO_FINAL = objetoAnalizado1;                        

                                                bool editada = mySerTramite.modificarTarjetaOperacion(tarjetaOperacionAsoc);

                                                DateTime dt2 = DateTime.Now;
                                                TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
                                                tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;                
                                                serviciosLogs.crearRegistroLog(tmpLog);

                                            }
                                            else
                                            {
                                                funciones.mostrarMensaje("Existe una tarjeta de Operación activa vigente para el cupo asociado", "I");

                                                //activar función de reimprimir tarjeta de operación

                                                val = false;

                                                reimprimir = true;

                                                //mostrar datos numero de la tarjeta
                                                txtnrotarjeta.Text = tarjetaOperacionAsoc.NUMERO;
                                                txtnrotarjeta.ReadOnly = true;

                                                dtpFechaVencimiento.Text = DateTime.Parse(tarjetaOperacionAsoc.FECHAVENCIMIENTO, System.Globalization.CultureInfo.InvariantCulture).ToString("dd/MM/yyyy");
                                                fechaVenActual = dtpFechaVencimiento.Text;
                                                dtpFechaVencimiento.Enabled = false;

                                                btnSave.Enabled = false;
                                                btnimprimir.Visible = true;
                                                btnimprimir.Focus();

                                                break;
                                            }
                                        }
                                    }

                                    if (val)
                                        crearTarjetaOperacion(myCupo, toperacion);
                                }
                                else
                                {
                                    //no hay tarjetas de operacion activas vigentes para el cupo asociado, se crea la tarjeta
                                    if (val)
                                        crearTarjetaOperacion(myCupo, toperacion);
                                }
                            }
                            else
                            {
                                funciones.mostrarMensaje("El vehículo no tiene cupo asignado", "I");
                            }
                        }
                        else
                        {
                            funciones.mostrarMensaje("Seleccione un vehículo válido", "I");
                        }
                    }
                    else
                    {
                        funciones.mostrarMensaje("Número de tarjeta de operación ya se encuentra en uso", "I");
                    }
                }
                else
                {
                    funciones.mostrarMensaje("Los campos número de tarjeta de operación, radio de acción, y zona de operación son obligatorios", "I");
                }
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error: " + exp.ToString());
            }

            ///--------------------------------------------------OLD    
            /*try
            {
                if (!txtnrotarjeta.Text.Equals("") && !txtradioaccion.Text.Equals("") && !txtzonaoperacion.Text.Equals(""))
                {
                    toperacion.NUMERO = txtnrotarjeta.Text;

                    object[] listaTarjetas = mySerTramite.buscarTarjetaOperacion(toperacion);

                    if (listaTarjetas == null || listaTarjetas.Count() < 0)
                    {
                        myVehiculo.PLACA = txtplacaunica.Text;
                        myVehiculo = mySerVeh.getVehiculo(myVehiculo);

                        if (myVehiculo != null && myVehiculo.ID_VEHICULO > 0)
                        {
                            myCupo.TT_ID_VEHICULO = myVehiculo.ID_VEHICULO;
                            myCupo = mySerCupos.getOneCuposTaxis(myCupo);

                            if (myCupo != null && myCupo.TT_IDCUPOTAXI > 0)
                            {
                                toperacion.IDCUPO = myCupo.TT_IDCUPOTAXI;
                                listaTO = mySerTramite.buscarTarjetaOperacion(toperacion);
                                int i;

                                if (listaTO != null && listaTO.Count() > 0)
                                {
                                    for (i = 0; i < listaTO.Count(); i++)
                                    {
                                        tarjetaOperacion tmpTarjetaOperacion = new tarjetaOperacion();
                                        tmpTarjetaOperacion = (tarjetaOperacion)listaTO[i];

                                        tmpTarjetaOperacion.ESTADO = "inactivo";
                                        mySerTramite.modificarTarjetaOperacion(tmpTarjetaOperacion);
                                    }
                                }

                                myHistorico.IDCUPO = myCupo.TT_IDCUPOTAXI;
                                toperacion.ESTADO = "activo";
                                toperacion.FECHAVENCIMIENTO = dtpFechaVencimiento.Text;

                                myHistorico = (historicoCupoTrans)((Object[])mySerCupos.getSHistoricoCuposTaxis(myHistorico))[0];

                                if (myHistorico != null && myHistorico.ID > 0)
                                {
                                    toperacion.IDHISTORICOCUPO = myHistorico.ID;
                                }

                                toperacion = mySerTramite.crearTarjetaOperacion(toperacion);

                                if (toperacion != null && toperacion.ID > 0)
                                {
                                    MessageBox.Show("Tarjeta de Operación almacenada correctamente!", "Almacenamiento exitoso!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    txtnrotarjeta.Enabled = false;
                                    txtradioaccion.Enabled = false;
                                    txtzonaoperacion.Enabled = false;
                                    dtpFechaVencimiento.Enabled = false;
                                    txtplacaunica.Enabled = false;
                                    btnimprimir.Visible = true;
                                    btnbuscar.Enabled = false;
                                    btnSave.Enabled = false;
                                    btnimprimir.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("El vehículo no tiene cupo asignado");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Seleccione un vehículo válido.");
                        }
                    }
                    else
                    {
                        DialogResult dr = MessageBox.Show(this, "Número de tarjeta de operación ya se encuentra en uso, Desea Continuar?", "Desea Continuar?", MessageBoxButtons.YesNo);

                        if (dr == DialogResult.Yes)
                        {
                            myVehiculo.PLACA = txtplacaunica.Text;
                            myVehiculo = mySerVeh.getVehiculo(myVehiculo);

                            if (myVehiculo != null && myVehiculo.ID_VEHICULO > 0)
                            {
                                myCupo.TT_ID_VEHICULO = myVehiculo.ID_VEHICULO;
                                myCupo = mySerCupos.getOneCuposTaxis(myCupo);

                                if (myCupo != null && myCupo.TT_IDCUPOTAXI > 0)
                                {
                                    toperacion.IDCUPO = myCupo.TT_IDCUPOTAXI;
                                    listaTO = mySerTramite.buscarTarjetaOperacion(toperacion);
                                    int i;

                                    if (listaTO != null && listaTO.Count() > 0)
                                    {
                                        for (i = 0; i < listaTO.Count(); i++)
                                        {
                                            tarjetaOperacion tmpTarjetaOperacion = new tarjetaOperacion();
                                            tmpTarjetaOperacion = (tarjetaOperacion)listaTO[i];
                                            tmpTarjetaOperacion.ESTADO = "inactivo";
                                            mySerTramite.modificarTarjetaOperacion(tmpTarjetaOperacion);
                                        }
                                    }

                                    myHistorico.IDCUPO = myCupo.TT_IDCUPOTAXI;
                                    toperacion.ESTADO = "activo";
                                    toperacion.FECHAVENCIMIENTO = dtpFechaVencimiento.Text;

                                    myHistorico = (historicoCupoTrans)((Object[])mySerCupos.getSHistoricoCuposTaxis(myHistorico))[0];

                                    if (myHistorico != null && myHistorico.ID > 0)
                                    {
                                        toperacion.IDHISTORICOCUPO = myHistorico.ID;
                                    }

                                    toperacion = mySerTramite.crearTarjetaOperacion(toperacion);

                                    if (toperacion != null && toperacion.ID > 0)
                                    {
                                        MessageBox.Show("Tarjeta de Operación almacenada correctamente!", "Almacenamiento exitoso!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        txtnrotarjeta.Enabled = false;
                                        txtradioaccion.Enabled = false;
                                        txtzonaoperacion.Enabled = false;
                                        dtpFechaVencimiento.Enabled = false;
                                        txtplacaunica.Enabled = false;
                                        btnimprimir.Visible = true;
                                        btnbuscar.Enabled = false;
                                        btnSave.Enabled = false;
                                        btnimprimir.Focus();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("El vehículo no tiene cupo asignado");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Seleccione un vehiculo valido.");
                            }
                        }
                        else
                            txtnrotarjeta.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Los campos número de tarjeta de operacion, radio de acción, y zona de operación son obligatorios");
                }
            }
            catch (Exception exce)
            {
                log.escribirError(exce.ToString(), this.GetType());
                MessageBox.Show("Error: " + exce.ToString());
            }*/

            //---------------------------END OLD
        }

        private void txtplacaunica_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones myFnc = WS.Funciones();
            myFnc.esAlfanumerico(e);
            if (e.KeyChar == 13)
            {
                buscarVehiculo();
            }
        }

        private void txtnrotarjeta_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones myFnc = WS.Funciones();
            myFnc.esAlfanumerico(e);
            if (e.KeyChar == 13)
                btnSave.Focus();
        }

        /*private void txtradioaccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones myFnc = WS.Funciones();
            myFnc.esLetra(e);
            funciones.lanzarTapConEnter(e);
        }*/

        private void txtzonaoperacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones myFnc = WS.Funciones();
            myFnc.esLetra(e);
            funciones.lanzarTapConEnter(e);
        }

        private void btnimprimir_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;


                /*
                if (reimprimir)
                    imprimirTarjetaOperacion(fechaVenActual);
                else imprimirTarjetaOperacion(dtpFechaVencimiento.Text);
                */
                if (reimprimir)
                    imprimirTO(fechaVenActual);
                else imprimirTO(dtpFechaVencimiento.Text);

                this.Cursor = Cursors.Default;
            }
            catch (Exception exp)
            {
                this.Cursor = Cursors.Default;

                funciones.mostrarMensaje("Error inesperado al generar la tarjeta de operación: " + exp.Message, "E");
            }

            /*try
            {
                ServiciosConfiguracionesService serviciosConfiguraciones = WS.ServiciosConfiguracionesService();

                object fileName = serviciosConfiguraciones.leerRegistroIni("PLANTILLAS") + "\\tarjeta_de_operacion.dotx";
                transferir myTransferencia = new transferir();
                myTransferencia.archivoDelServerSinAbrir((String)fileName);

                ProcesadorDocumentos myProcesadorDocs = new ProcesadorDocumentos();

                Dictionary<string, string> dicVariablesValores = new Dictionary<string, string>();

                dicVariablesValores.Add("FECHA_VENCIMIENTO", dtpFechaVencimiento.Text);
                dicVariablesValores.Add("CLASE_VEHICULO", txtclasevehiculo.Text);
                dicVariablesValores.Add("PLACA", txtplacaunica.Text);
                dicVariablesValores.Add("CLASE_COMBUSTIBLE", txtclasecombustible.Text);
                dicVariablesValores.Add("TIPO_CARROCERIA", txttipocarroceria.Text);
                dicVariablesValores.Add("MARCA", txtmarca.Text);
                dicVariablesValores.Add("MODELO", txtmodelo.Text);
                dicVariablesValores.Add("NUMERO_MOTOR", txtnumeromotor.Text);
                dicVariablesValores.Add("NIVEL_SERVICIO", txtnivelservicio.Text);
                dicVariablesValores.Add("CAPACIDAD_PASAJEROS", txtpasajeros.Text);
                dicVariablesValores.Add("CAPACIDAD_TONELADAS", txttoneladas.Text);
                dicVariablesValores.Add("RAZON_SOCIAL", txtrazonsocial.Text);
                dicVariablesValores.Add("RADIO_ACCION", txtradioaccion.Text);
                dicVariablesValores.Add("ZONA_OPERACION", txtzonaoperacion.Text);
                dicVariablesValores.Add("NRO_TARJETA", txtnrotarjeta.Text);
                dicVariablesValores.Add("NRO_INTERNO", "Documento");
                dicVariablesValores.Add("CUPO", txtnrocupo.Text);

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
                    FrmGeneradorDocumentos myformGenerarDoc = new FrmGeneradorDocumentos(fileName.ToString(), misDocumentos + "\\Siatt\\TarjetaOperacion" + DateTime.Now.ToString("yyyyMMdd"), contenido, true, false, false, false, false, true, Modulo.Transporte_Publico);
                    //FrmGeneradorDocumentos myformGenerarDoc = new FrmGeneradorDocumentos(fileName.ToString(), misDocumentos + "\\Siatt\\TarjetaOperacion" + DateTime.Now.ToString("yyyyMMdd"), contenido, true, false, false, true, true, true, Modulo.Transporte_Publico);

                    DialogResult dr = myformGenerarDoc.ShowDialog(this);

                    if (dr == DialogResult.OK)
                    {
                        String rutaguardar = myformGenerarDoc.rutaG;
                    }
                }
                else
                    MessageBox.Show("Error al generar la tarjeta de operación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error inesperado al generar la tarjeta de operación. " + exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        private void tarjetadeoperacion_Load(object sender, EventArgs e)
        {
            txtplacaunica.Focus();
        }

        private void dateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
        {
            funciones.lanzarTapConEnter(e);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dtpCambiado = true;
        }

        private void cmbRadioAccion_TextChanged(object sender, EventArgs e)
        {
            radioAccion = cmbRadioAccion.Text.ToUpper();

            if (estadoImprimir && radioAccion == "")
            {
                funciones.mostrarMensaje("El campo Radio de Acción es obligatorio", "W");
                cmbRadioAccion.Focus();
            }
        }

        #endregion
     
    }
}
