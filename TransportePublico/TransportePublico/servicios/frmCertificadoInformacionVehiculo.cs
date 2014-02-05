using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibreriasSintrat.ServiciosDocumentos;
using LibreriasSintrat.utilidades;
using LibreriasSintrat.ServiciosConfiguraciones;
using LibreriasSintrat.ServiciosTransito;
using LibreriasSintrat.ServiciosAccesorias;
using System.IO;
using Word = Microsoft.Office.Interop.Word;
using LibreriasSintrat.forms.documentos;
using TransportePublico.servicios.documentos;
using LibreriasSintrat.ServiciosLogs;
using LibreriasSintrat.ServiciosUsuarios;
 


namespace TransportePublico.servicios
{
    public partial class frmCertificadoInformacionVehiculo : Form
    {
        ServiciosLogsService serviciosLogs;
        usuarios usuarioSistema;

        ServiciosDocumentosService serviciosDocumentos;
        ServiciosConfiguracionesService serviciosConfiguraciones;
        Funciones funciones;

        public frmCertificadoInformacionVehiculo(usuarios user)
        {
            usuarioSistema = user;
            serviciosLogs = WS.ServiciosLogsService();

            InitializeComponent();
            funciones = WS.Funciones();
            serviciosDocumentos = WS.ServiciosDocumentosService();
            serviciosConfiguraciones = WS.ServiciosConfiguracionesService();
        }

        private String crearSqlInformacionVehiculoTransportePublico(String placa)
        {
            String sql;
            sql = "select " +
                    "vehiculo.placa as PLACA, " +
                    "tipovehiculo.nombre as TIPO_VEHICULO, " +
                    "vehiculo.nro_motor as MOTOR, " +
                    "vehiculo.chasis as CHASIS, " +
                    "vehiculo.serie_motor as SERIE, " +
                    "tt_tarjetaoperacion.numero as No_TARJETA_OPERACION, " +
                    "tt_tarjetaoperacion.fechavencimiento as FECHA_VENCE, " +
                    "t_cupostaxis.tt_numcupo as CUPO, " +
                    "empresasdeservicio.nombre as EMPRESA, " +
                    "runtradioaccion.descripcion as RADIO_ACCION, " +
                    "vehiculo.capacidad as CAPACIDAD, " +
                    "vehiculo.capacidadton as CAPACIDAD_TONELADAS " +
                    "from " +
                    "vehiculo " +
                    "left join t_cupostaxis on (vehiculo.id_vehiculo = t_cupostaxis.tt_id_vehiculo) " +
                    "left join tipovehiculo on (t_cupostaxis.tt_tipoveh = tipovehiculo.id) " +
                    "left join tt_tarjetaoperacion on (t_cupostaxis.tt_idcupotaxi = tt_tarjetaoperacion.idcupo) " +
                    "left join empresasdeservicio on (t_cupostaxis.tt_id_empservicio = empresasdeservicio.id_empservicio) " +
                    "left join runtradioaccion on (vehiculo.id_runtradioaccion = runtradioaccion.id_runtradioaccion) " +
                    "where " +
                    "vehiculo.id_servicio = 2 and " +
                    "tt_tarjetaoperacion.estado = 'activo' and " +
                    "vehiculo.id_motivocancelacion is null and " +
                    "vehiculo.vehforaneo is null and " +
                    "vehiculo.placa = '" + placa + "'";
            return sql;
        }

        private void generarCertificadoInformacionVehiculoTranportePublico(String placa)
        {
            String query;
            Object[] objTmp;
            ArrayList campos;
            DataTable datos;
            
            query = crearSqlInformacionVehiculoTransportePublico(placa);

            logs tmpLog = new logs();
            tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
            tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
            tmpLog.OBJETO = "VERIFICAR_QUERY";
            tmpLog.MODULO = "TPUBLICO";
            tmpLog.TIPO_TRANSACCION = "SELECT";
            TimeSpan TS;
            DateTime dt1 = DateTime.Now;
            string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(query.GetType(), new object[] { query });
            tmpLog.ESTADO_ANTERIOR = objetoAnalizado;

            objTmp = serviciosDocumentos.verificarConsulta(query);

            DateTime dt2 = DateTime.Now;
            TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
            tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;
            serviciosLogs.crearRegistroLog(tmpLog);


            datos = new DataTable();

            if (objTmp != null)
            {
                campos = funciones.ObjectToArrayList(objTmp);

                logs tmpLog2 = new logs();
                tmpLog2.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                tmpLog2.ID_USUARIO = usuarioSistema.ID_USUARIO;
                tmpLog2.OBJETO = "TIPOVEHICULO";
                tmpLog2.MODULO = "TPUBLICO";
                tmpLog2.TIPO_TRANSACCION = "SELECT";
                TimeSpan TS2;
                DateTime dt12 = DateTime.Now;
                string objetoAnalizado2 = AnalizadorDeObjetos.analizarObjeto(query.GetType(), new object[] { query });
                tmpLog.ESTADO_ANTERIOR = objetoAnalizado2;


                objTmp = serviciosDocumentos.executeQueryPrincipal(query);

                DateTime dt22 = DateTime.Now;
                TS2 = new TimeSpan(dt22.Ticks - dt12.Ticks);
                tmpLog2.TIEMPO_EJECUCION = TS2.Milliseconds;
                serviciosLogs.crearRegistroLog(tmpLog2);


                datos = funciones.getData(funciones.ObjectToArrayList(objTmp), campos);
                if (datos.Rows.Count > 0)
                {
                    dataGridView1.DataSource = datos;

                    // Aqui obtengo los datos de la secretaria de transito
                    ServiciosTransitoService servicioTransito = WS.ServiciosTransitoService();
                    LibreriasSintrat.ServiciosTransito.transito transitoLocal = new LibreriasSintrat.ServiciosTransito.transito();

                    logs tmpLog3 = new logs();
                    tmpLog3.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                    tmpLog3.ID_USUARIO = usuarioSistema.ID_USUARIO;
                    tmpLog3.OBJETO = "TRANSITO";
                    tmpLog3.MODULO = "TPUBLICO";
                    tmpLog3.TIPO_TRANSACCION = "SELECT";
                    TimeSpan TS3;
                    DateTime dt13 = DateTime.Now;
            
                    transitoLocal = servicioTransito.obtenerTransito();

                    DateTime dt23 = DateTime.Now;
                    TS3 = new TimeSpan(dt23.Ticks - dt13.Ticks);
                    tmpLog3.TIEMPO_EJECUCION = TS3.Milliseconds;
                    serviciosLogs.crearRegistroLog(tmpLog3);

                    // Aqui obtengo la fecha y hora del sistema
                    ServiciosAccesoriasService servicioAccesorias = WS.ServiciosAccesoriasService();
                    String fecha;

                    logs tmpLog4 = new logs();
                    tmpLog4.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                    tmpLog4.ID_USUARIO = usuarioSistema.ID_USUARIO;
                    tmpLog4.OBJETO = "FECHA_ACTUAL";
                    tmpLog4.MODULO = "TPUBLICO";
                    tmpLog4.TIPO_TRANSACCION = "SELECT";
                    TimeSpan TS4;
                    DateTime dt14 = DateTime.Now;

                    fecha = servicioAccesorias.getFechaActualTexto();

                    DateTime dt24 = DateTime.Now;
                    TS4 = new TimeSpan(dt24.Ticks - dt14.Ticks);
                    tmpLog4.TIEMPO_EJECUCION = TS4.Milliseconds;
                    serviciosLogs.crearRegistroLog(tmpLog4);

                    ciudad ciudadTransito = new ciudad();
                    Object[] ciudades;

                    if (transitoLocal != null && transitoLocal.ID_TRANSITO > 0)
                    {
                        // Aqui obtengo la ciudad del transito
                        ciudadTransito.ID_CIUDAD = transitoLocal.ID_CIUDAD;

                        logs tmpLog5 = new logs();
                        tmpLog5.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                        tmpLog5.ID_USUARIO = usuarioSistema.ID_USUARIO;
                        tmpLog5.OBJETO = "TIPOVEHICULO";
                        tmpLog5.MODULO = "TPUBLICO";
                        tmpLog5.TIPO_TRANSACCION = "SELECT";
                        TimeSpan TS5;
                        DateTime dt15 = DateTime.Now;

                        string objetoAnalizado3 = AnalizadorDeObjetos.analizarObjeto(ciudadTransito.GetType(), new object[] { ciudadTransito });
                        tmpLog.ESTADO_ANTERIOR = objetoAnalizado3;

                        ciudades = servicioAccesorias.getCiudadesPorDepto(ciudadTransito);

                        DateTime dt25 = DateTime.Now;
                        TS5 = new TimeSpan(dt25.Ticks - dt15.Ticks);
                        tmpLog5.TIEMPO_EJECUCION = TS5.Milliseconds;
                        serviciosLogs.crearRegistroLog(tmpLog5);


                        if (ciudades != null)
                            ciudadTransito = (ciudad)ciudades[0];
                    }

                    //object fileName = "c:\\certificadoInformacionVehiculoTransportePublico.dotx";
                    logs tmpLog6 = new logs();
                    tmpLog6.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                    tmpLog6.ID_USUARIO = usuarioSistema.ID_USUARIO;
                    tmpLog6.OBJETO = "PLANTILLAS";
                    tmpLog6.MODULO = "TPUBLICO";
                    tmpLog6.TIPO_TRANSACCION = "SELECT";
                    TimeSpan TS6;
                    DateTime dt16 = DateTime.Now;
                    
                    object fileName = serviciosConfiguraciones.leerRegistroIni("PLANTILLAS") + "\\certificadoInformacionVehiculoTransportePublico.dotx";

                    string objetoAnalizado5 = AnalizadorDeObjetos.analizarObjeto(fileName.GetType(), new object[] { fileName });
                    tmpLog.ESTADO_ANTERIOR = objetoAnalizado5;

                    transferir myTransferencia = new transferir();
                    myTransferencia.archivoDelServerSinAbrir((String)fileName);

                    DateTime dt26 = DateTime.Now;
                    TS6 = new TimeSpan(dt26.Ticks - dt16.Ticks);
                    tmpLog6.TIEMPO_EJECUCION = TS6.Milliseconds;
                    serviciosLogs.crearRegistroLog(tmpLog6);

                    //************************************************** INSERCION DE LOGO ***************************

                    funciones.insertarLogoTransitoOLD((String)fileName, Funciones.alineacionlogo.izquierda);

                    //************************************************************************************************

                    Dictionary<string, string> dicVariables = new Dictionary<string, string>();
                    dicVariables.Add("PLACA", placa);


                    if (datos.Rows[0][1].ToString() != "null" && datos.Rows[0][1].ToString().Length > 0)
                        dicVariables.Add("TIPO_VEHICULO", datos.Rows[0][1].ToString());
                    else
                        dicVariables.Add("TIPO_VEHICULO", "");
                    if (datos.Rows[0][2].ToString() != "null" && datos.Rows[0][2].ToString().Length > 0)
                        dicVariables.Add("NRO_MOTOR", datos.Rows[0][2].ToString());
                    else
                        dicVariables.Add("NRO_MOTOR", "");
                    if (datos.Rows[0][3].ToString() != "null" && datos.Rows[0][3].ToString().Length > 0)
                        dicVariables.Add("CHASIS", datos.Rows[0][3].ToString());
                    else
                        dicVariables.Add("CHASIS", "");
                    if (datos.Rows[0][4].ToString() != "null" && datos.Rows[0][4].ToString().Length > 0)
                        dicVariables.Add("SERIE_MOTOR", datos.Rows[0][4].ToString());
                    else
                        dicVariables.Add("SERIE_MOTOR", "");
                    if (datos.Rows[0][5].ToString() != "null" && datos.Rows[0][5].ToString().Length > 0)
                        dicVariables.Add("NRO_TARJETA_OPERACION", datos.Rows[0][5].ToString());
                    else
                        dicVariables.Add("NRO_TARJETA_OPERACION", "");
                    if (datos.Rows[0][6].ToString() != "null" && datos.Rows[0][6].ToString().Length > 0)
                        dicVariables.Add("FECHA_VENCE_TARJETA", datos.Rows[0][6].ToString());
                    else
                        dicVariables.Add("FECHA_VENCE_TARJETA", "");
                    if (datos.Rows[0][7].ToString() != "null" && datos.Rows[0][7].ToString().Length > 0)
                        dicVariables.Add("NRO_CUPO", datos.Rows[0][7].ToString());
                    else
                        dicVariables.Add("NRO_CUPO", "");
                    if (datos.Rows[0][8].ToString() != "null" && datos.Rows[0][8].ToString().Length > 0)
                        dicVariables.Add("EMPRESA_SERVICIO", datos.Rows[0][8].ToString());
                    else
                        dicVariables.Add("EMPRESA_SERVICIO", "");
                    if (datos.Rows[0][9].ToString() != "null" && datos.Rows[0][9].ToString().Length > 0)
                        dicVariables.Add("RADIO_ACCION", datos.Rows[0][9].ToString());
                    else
                        dicVariables.Add("RADIO_ACCION", "");
                    if (datos.Rows[0][10].ToString() != "null" && datos.Rows[0][10].ToString().Length > 0)
                        dicVariables.Add("CAPACIDAD", datos.Rows[0][10].ToString());
                    else
                        dicVariables.Add("CAPACIDAD", "");
                    if (datos.Rows[0][11].ToString() != "null" && datos.Rows[0][11].ToString().Length > 0)
                        dicVariables.Add("CAPACIDADTON", datos.Rows[0][11].ToString());
                    else
                        dicVariables.Add("CAPACIDADTON", "");

                    dicVariables.Add("CIUDAD_TRANSITO", ciudadTransito.NOMBRE);
                    dicVariables.Add("FECHA_ACTUAL", fecha);
                    dicVariables.Add("SECRETARIOTRANSITO", transitoLocal.SECRETARIOTRANSITO);
                    dicVariables.Add("NOMBREALCALDIA", transitoLocal.NOMBREALCALDIA);
                    dicVariables.Add("DESCRIPCION", transitoLocal.DESCRIPCION);
                    dicVariables.Add("DIRECCION", transitoLocal.DIRECCION);
                    dicVariables.Add("EMAIL", transitoLocal.EMAIL);

                    String rutaarchivo = (String)fileName;
                    String result = "";

                    string misDocumentos = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    string rutaTemp = misDocumentos + "\\filetemp.rtf";

                    //Eliminar archivo temporal si existe
                    if (File.Exists(rutaTemp))
                        File.Delete(rutaTemp);


                    Word.Application newApp = new Word.Application();
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

                    ProcesadorDocumentos myProcesadorDocs = new ProcesadorDocumentos();

                    //Reemplazar las variables en la plantilla
                    myProcesadorDocs.reemplazarVariables(newApp, dicVariables);

                    //Specifying the format in which you want the output file 
                    object format = Word.WdSaveFormat.wdFormatRTF;

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
                        FrmGeneradorDocumentos myformGenerarDoc = new FrmGeneradorDocumentos(fileName.ToString(), misDocumentos + "\\siatt\\Certificado_Informacion_Vehiculo_Transporte_Publico_" + DateTime.Now.ToString("yyyyMMdd"), contenido, true, false, false, false, false, true, Modulo.Principal);

                        DialogResult dr = myformGenerarDoc.ShowDialog(this);
                        if (dr == DialogResult.OK)
                        {
                            String rutaguardar = myformGenerarDoc.rutaG;
                        }
                    }
                    else
                        MessageBox.Show("Error al generar el Certificado de Información del Vehículo de Transporte Público, cuando se intentaba reemplazar las variables de la plantilla.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    funciones.mostrarMensaje("El vehículo de placas " + placa + " no se encuentra registrado en la base de datos o no es de servicio público", "E");
            }
        }


        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtPlaca.Text))
                {
                    funciones.mostrarMensaje("Debe digitar una placa valida", "E");
                    txtPlaca.Focus();
                }
                else
                    generarCertificadoInformacionVehiculoTranportePublico(txtPlaca.Text);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            
        }
    }
}
