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
using LibreriasSintrat.ServiciosTramitesTrans;
using LibreriasSintrat.ServiciosAccesorias;
using LibreriasSintrat.ServiciosDocumentos;
using TransportePublico.servicios.documentos;
using TransportePublico;
using LibreriasSintrat.utilidades;
using TransitoPrincipal;
using LibreriasSintrat.ServiciosConfiguraciones;
using LibreriasSintrat.forms.documentos;
using System.IO;
using LibreriasSintrat.ServiciosLogs;
using LibreriasSintrat.ServiciosLogs;
using LibreriasSintrat.ServiciosUsuarios;


namespace TransportePublico.servicios.tramites
{
    public partial class generarconceptofavorable : Form
    {
        ServiciosCuposTransService clienteCuposTrans;
        ServiciosTramitesTransService clienteTramitesTrans;
        ServiciosAccesoriasService clienteAccesorias;
        viewResoluciones resolucionseleccionada = new viewResoluciones();

        ServiciosLogsService serviciosLogs;
        usuarios usuarioSistema;

        Object[] listaresoluciones = null;
        marca newmarca = null;
        Log log = new Log();
        int numconcept = 0;

        Funciones funciones;

        public generarconceptofavorable(usuarios user)
        {
            InitializeComponent();
            log = new Log();
            usuarioSistema = user;
            serviciosLogs = WS.ServiciosLogsService();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void generarconceptofavorable_Load(object sender, EventArgs e)
        {
            btnsearchmarca.Enabled = false;
            btnSave.Enabled = false;
            viewResoluciones vistaresolucion = new viewResoluciones();

            funciones = WS.Funciones();

            //vistaresolucion.IDTIPOVEHICULO = 1;

            clienteCuposTrans = WS.ServiciosCuposTransService();

            logs tmpLog = new logs();
            tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
            tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
            tmpLog.OBJETO = "VIEW_RESOLUCIONES";
            tmpLog.MODULO = "TPUBLICO";
            tmpLog.TIPO_TRANSACCION = "SELECT";
            TimeSpan TS;
            DateTime dt1 = DateTime.Now;

            string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(vistaresolucion.GetType(), new object[] { vistaresolucion });
            tmpLog.ESTADO_ANTERIOR = objetoAnalizado;

            Object[] listaresol = (Object[])clienteCuposTrans.getSViewResoluciones(vistaresolucion);

            DateTime dt2 = DateTime.Now;
            TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
            tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;
            serviciosLogs.crearRegistroLog(tmpLog);

            if (listaresol != null)
            {
                numeroresolucion.DataSource = null;
                numeroresolucion.DisplayMember = "NUMERORESOLUCION";
                numeroresolucion.ValueMember = "IDRESOLUCION";
                funciones.llenarCombo(numeroresolucion, listaresol);
            }
        }

        private void btnbuscarresol_Click(object sender, EventArgs e)
        {
            buscarResoluciones();
        }

        private void buscarResoluciones()
        {
            viewResoluciones lavista = new viewResoluciones();
            clienteCuposTrans = WS.ServiciosCuposTransService();
            Funciones funciones = WS.Funciones();

            //lavista.IDTIPOVEHICULO = 1;

            if (placavehiculo.Text != "")
            {
                lavista.PLACA = placavehiculo.Text;
            }

            logs tmpLog = new logs();
            tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
            tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
            tmpLog.OBJETO = "VIEW_RESOLUCIONES";
            tmpLog.MODULO = "TPUBLICO";
            tmpLog.TIPO_TRANSACCION = "SELECT";
            TimeSpan TS;
            DateTime dt1 = DateTime.Now;

            string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(lavista.GetType(), new object[] { lavista });
            tmpLog.ESTADO_ANTERIOR = objetoAnalizado;

            listaresoluciones = (Object[])clienteCuposTrans.getSViewResoluciones(lavista);

            DateTime dt2 = DateTime.Now;
            TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
            tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;
            serviciosLogs.crearRegistroLog(tmpLog);


            if (listaresoluciones != null && listaresoluciones.Length >= 0)
            {
                mostrarResoluciones(listaresoluciones);
                btnSave.Enabled = true;
            }
            else
            {
                if (placavehiculo.Text == "")
                {
                    funciones.mostrarMensaje("El campo placa no puede ser vacío", "E");
                }
                else
                {
                    grillaresoluciones.DataSource = null;
                    btnSave.Enabled = false;
                    funciones.mostrarMensaje("No se encontraron resoluciones", "I");
                }
            }
        }

        private void mostrarResoluciones(Object[] lista)
        {
            Funciones funciones = WS.Funciones();
            DataTable dt = new DataTable();
            ArrayList Campos = new ArrayList();

            Campos.Add("NUMERORESOLUCION = NUMERO DE RESOLUCIÓN");
            Campos.Add("EMPRESADESERVICIO = EMPRESA DE SERVICIO");
            Campos.Add("NOMTIPOVEHICULO = TIPO DE VEHICULO");
            Campos.Add("PLACA = PLACA");
            Campos.Add("MARCAVEHICULO = MARCA VEHÍCULO");
            Campos.Add("NUMEROCUPO = NUMERO DE CUPO");

            try
            {
                dt = funciones.ToDataTable(funciones.ObjectToArrayList(lista));
            }
            catch (Exception e)
            {
                log.escribirError(e.ToString(), this.GetType());
            }

            grillaresoluciones.DataSource = dt;

            if (dt.Rows.Count > 0)
                funciones.configurarGrilla(grillaresoluciones, Campos);

            dt = null;
            Campos = null;

            grillaresoluciones.Select();
        }

        private void grillaresoluciones_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (grillaresoluciones.CurrentRow != null)
                {
                    resolucionseleccionada = (viewResoluciones)listaresoluciones[grillaresoluciones.CurrentRow.Index];
                }
                else
                {
                    resolucionseleccionada = null;
                }

                cargarDatos();
            }
            catch
            {
            }
        }

        private void cargarDatos()
        {
            if (resolucionseleccionada != null)
            {
                btnsearchmarca.Enabled = true;
                clienteTramitesTrans = WS.ServiciosTramitesTransService();
                clienteAccesorias = WS.ServiciosAccesoriasService();
                claseVehiculo laclase = new claseVehiculo();
                Funciones funciones = WS.Funciones();

                numresolucion.Text = resolucionseleccionada.NUMERORESOLUCION;
                numercupo.Text = resolucionseleccionada.NUMEROCUPO.ToString();
                numconcept = clienteTramitesTrans.getMaxConcepto();
                numconceptofavorable.Text = numconcept.ToString();
                nombreempresa.Text = resolucionseleccionada.EMPRESADESERVICIO;

                //limpiando datos variables:
                identificacionnit.Clear();
                nombrerazonsocial.Clear();
                modelovehiculo.Clear();
                numerochasis.Clear();
                numeromotor.Clear();

                logs tmpLog = new logs();
                tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
                tmpLog.OBJETO = "L_CLASESVEHICULOS";
                tmpLog.MODULO = "TPUBLICO";
                tmpLog.TIPO_TRANSACCION = "SELECT";
                TimeSpan TS;
                DateTime dt1 = DateTime.Now;

                Object[] listaclases = clienteAccesorias.getClaseVehiculo(null);
                
                DateTime dt2 = DateTime.Now;
                TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
                tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;
                serviciosLogs.crearRegistroLog(tmpLog);


                txtPlaca.Text = resolucionseleccionada.PLACA.ToUpper();

                if (listaclases != null && listaclases.Length >= 0)
                {
                    clasevehiculo.DataSource = null;
                    clasevehiculo.DisplayMember = "DESCRIPCION";
                    clasevehiculo.ValueMember = "ID_CVEHICULO";
                    funciones.llenarCombo(clasevehiculo, listaclases);
                }
            }
            else
            {
                btnsearchmarca.Enabled = false;
            }
        }

        private void btnsearchmarca_Click(object sender, EventArgs e)
        {
            buscarMarca();
        }

        public void buscarMarca()
        {
            clienteAccesorias = WS.ServiciosAccesoriasService();
            marca lamarca = new marca();
            newmarca = new marca();
            Funciones funciones = WS.Funciones();
            ArrayList Campos = new ArrayList();
            Campos.Add("CODNUMMARCA = CODNUMMARCA");
            Campos.Add("DESCRIPCION = DESCRIPCION");

            logs tmpLog = new logs();
            tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
            tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
            tmpLog.OBJETO = "MARCA";
            tmpLog.MODULO = "TPUBLICO";
            tmpLog.TIPO_TRANSACCION = "SELECT";
            TimeSpan TS;
            DateTime dt1 = DateTime.Now;

            Object[] Marcas = (Object[])clienteAccesorias.getMarca(lamarca);
            buscador buscador = new buscador(Marcas, Campos, "Marcas", null);

            DateTime dt2 = DateTime.Now;
            TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
            tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;
            serviciosLogs.crearRegistroLog(tmpLog);

            if (buscador.ShowDialog() == DialogResult.OK)
            {
                newmarca = (marca)funciones.listToMarca(buscador.Seleccion);
                marcavehiculo.Text = newmarca.DESCRIPCION;
            }
        }

        private void modelovehiculo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones funciones = WS.Funciones();
            funciones.esNumero(e);
            funciones.lanzarTapConEnter(e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            validaciones();
        }

        private void validaciones()
        {
            bool val = true;

            if (newmarca == null)
            {
                funciones.mostrarMensaje("Debe seleccionar una Marca", "I");
                buscarMarca();

                val = false;
            }
            else if (modelovehiculo.Text == "")
            {
                funciones.mostrarMensaje("El campo Modelo no puede ser vacío", "W");
                modelovehiculo.Focus();

                val = false;
            }
            else
            {
                clienteAccesorias = WS.ServiciosAccesoriasService();
                runtModeloVehi modelovehi = new runtModeloVehi();
                runtModeloVehi elmodelo = new runtModeloVehi();
                modelovehi.COD_MODELO = modelovehiculo.Text;

                
                logs tmpLog = new logs();
                tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
                tmpLog.OBJETO = "RUNT_MODELOVEH";
                tmpLog.MODULO = "TPUBLICO";
                tmpLog.TIPO_TRANSACCION = "SELECT";
                TimeSpan TS; 
                DateTime dt1 = DateTime.Now;

                string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(modelovehi.GetType(), new object[] { modelovehi});
                tmpLog.ESTADO_ANTERIOR = objetoAnalizado;

                elmodelo = (runtModeloVehi)clienteAccesorias.getRuntModeloVehi(modelovehi);

                DateTime dt2 = DateTime.Now;
                TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
                tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;
                serviciosLogs.crearRegistroLog(tmpLog);

                if (elmodelo != null && elmodelo.ID_MODELO < 0)
                {
                    funciones.mostrarMensaje("No se encontró el modelo : " + modelovehiculo.Text + " por favor verifique la información ingresada", "W");
                    modelovehiculo.Focus();

                    val = false;
                }
                else
                {
                    if (identificacionnit.Text == "")
                    {
                        funciones.mostrarMensaje("El campo identificación o NIT esta vacío", "W");
                        identificacionnit.Focus();

                        val = false;
                    }
                    else if (nombrerazonsocial.Text == "")
                    {
                        funciones.mostrarMensaje("El campo Nombre/Razón social esta vacío", "W");
                        identificacionnit.Focus();

                        val = false;
                    }
                    else if (txtPlaca.Text == "")
                    {
                        funciones.mostrarMensaje("El campo Placa esta vacío", "W");
                        identificacionnit.Focus();

                        val = false;
                    }
                    else if (clasevehiculo.SelectedIndex < 0)
                    {
                        funciones.mostrarMensaje("Debe seleccionar una Clase de Vehículo", "W");
                        clasevehiculo.Focus();

                        val = false;
                    }
                    else if (numerochasis.Text == "")
                    {
                        funciones.mostrarMensaje("El campo Número Chasis no puede ser vacío", "W");
                        numerochasis.Focus();

                        val = false;
                    }
                    else if (numeromotor.Text == "")
                    {
                        funciones.mostrarMensaje("El campo Número Motor no puede ser vacío", "W");
                        numeromotor.Focus();

                        val = false;
                    }
                    else if (!String.IsNullOrEmpty(numresolucion.Text))
                    {
                        ttResolucionesTrans resolucionAsociada = new ttResolucionesTrans();

                        resolucionAsociada.NUMERO = resolucionseleccionada.NUMERORESOLUCION;

                        numConceptosFavorablesTrans numeroConceptoFavorableAsociado = new numConceptosFavorablesTrans();

                        logs tmpLog2 = new logs();
                        tmpLog2.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                        tmpLog2.ID_USUARIO = usuarioSistema.ID_USUARIO;
                        tmpLog2.OBJETO = "TT_RESOLUCIONES";
                        tmpLog2.MODULO = "TPUBLICO";
                        tmpLog2.TIPO_TRANSACCION = "SELECT";
                        TimeSpan TS2;
                        DateTime dt12 = DateTime.Now;

                        string objetoAnalizado2 = AnalizadorDeObjetos.analizarObjeto(resolucionAsociada.GetType(), new object[] { resolucionAsociada});
                        tmpLog2.ESTADO_ANTERIOR = objetoAnalizado2;

                        object[] listaTTResoluciones = clienteTramitesTrans.getSTtResolucionesTrans(resolucionAsociada);

                        DateTime dt22 = DateTime.Now;
                        TS2 = new TimeSpan(dt22.Ticks - dt12.Ticks);
                        tmpLog2.TIEMPO_EJECUCION = TS2.Milliseconds;
                        serviciosLogs.crearRegistroLog(tmpLog2);

                        if (listaTTResoluciones != null && listaTTResoluciones.Length > 0) 
                        {
                            for (int il = 0; il < listaTTResoluciones.Length; il++)
                            {
                                int idResolucion = ((ttResolucionesTrans)listaTTResoluciones[il]).ID;

                                numeroConceptoFavorableAsociado.TT_IDRESOLUCION = idResolucion;

                                logs tmpLog4 = new logs();
                                tmpLog4.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                                tmpLog4.ID_USUARIO = usuarioSistema.ID_USUARIO;
                                tmpLog4.OBJETO = "T_CONCEPTOSFAVORABLES";
                                tmpLog4.MODULO = "TPUBLICO";
                                tmpLog4.TIPO_TRANSACCION = "SELECT";
                                TimeSpan TS4;
                                DateTime dt14 = DateTime.Now;

                                string objetoAnalizado4 = AnalizadorDeObjetos.analizarObjeto(numeroConceptoFavorableAsociado.GetType(), new object[] { numeroConceptoFavorableAsociado });
                                tmpLog4.ESTADO_ANTERIOR = objetoAnalizado4;

                                object[] listNumCopFavorable = clienteTramitesTrans.getSNumConceptosFavorablesTrans(numeroConceptoFavorableAsociado);

                                DateTime dt24 = DateTime.Now;
                                TS4 = new TimeSpan(dt24.Ticks - dt14.Ticks);
                                tmpLog4.TIEMPO_EJECUCION = TS4.Milliseconds;
                                serviciosLogs.crearRegistroLog(tmpLog4);

                                if (listNumCopFavorable != null && listNumCopFavorable.Length > 0)
                                {
                                    funciones.mostrarMensaje("Ya existe un concepto Favorable para esta resolución", "W");

                                    val = false;

                                    break;
                                }
                            }
                        }
                    }
                }
            }

            if (val)
                guardarConcepto();
        }

        private void guardarConcepto()
        {
            clienteTramitesTrans = WS.ServiciosTramitesTransService();
            tNuevosVehiculosTrans nuevovehiculo = new tNuevosVehiculosTrans();

            nuevovehiculo.TNV_CHASIS = numerochasis.Text;
            nuevovehiculo.TNV_ID_CVEHICULO = Int32.Parse(clasevehiculo.SelectedValue.ToString());
            nuevovehiculo.TNV_MARCA = newmarca.DESCRIPCION;
            nuevovehiculo.TNV_MODELO = modelovehiculo.Text;
            nuevovehiculo.TNV_MOTOR = numeromotor.Text;
            nuevovehiculo.TNV_PLACA = txtPlaca.Text;

            logs tmpLog = new logs();
            tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
            tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
            tmpLog.OBJETO = "T_NUEVOSVEHICULO";
            tmpLog.MODULO = "TPUBLICO";
            tmpLog.TIPO_TRANSACCION = "INSERT";
            TimeSpan TS;
            DateTime dt1 = DateTime.Now;

            string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(nuevovehiculo.GetType(), new object[] { nuevovehiculo});
            tmpLog.ESTADO_ANTERIOR = objetoAnalizado;

            int insnew = clienteTramitesTrans.crearTNuevosVehiculosTrans(nuevovehiculo);

            DateTime dt2 = DateTime.Now;
            TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
            tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;
            serviciosLogs.crearRegistroLog(tmpLog);


            if (insnew > 0)
            {
                Boolean insnumconcep = false;

                //if (insnumconcep == true)
                //{
                //    MessageBox.Show("Registro Exitoso","Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
                //    this.Close();
                //}
                //else
                //{
                //    MessageBox.Show("Error en registro","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                //    this.Close();
                //}

                nuevaPersonaTrans lapersona = new nuevaPersonaTrans();

                lapersona.IDENTIFICACION = identificacionnit.Text;
                lapersona.NOMBRE = nombrerazonsocial.Text;

                logs tmpLog2 = new logs();
                tmpLog2.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                tmpLog2.ID_USUARIO = usuarioSistema.ID_USUARIO;
                tmpLog2.OBJETO = "TT_NUEVAPERSONA";
                tmpLog2.MODULO = "TPUBLICO";
                tmpLog2.TIPO_TRANSACCION = "INSERT";
                TimeSpan TS2;
                DateTime dt12 = DateTime.Now;

                string objetoAnalizado2 = AnalizadorDeObjetos.analizarObjeto(lapersona.GetType(), new object[] { lapersona});
                tmpLog2.ESTADO_ANTERIOR = objetoAnalizado2;

                int idpersona = clienteTramitesTrans.crearNuevaPersonaTrans(lapersona);

                DateTime dt22 = DateTime.Now;
                TS2 = new TimeSpan(dt22.Ticks - dt12.Ticks);
                tmpLog2.TIEMPO_EJECUCION = TS2.Milliseconds;
                serviciosLogs.crearRegistroLog(tmpLog2);

                //if (idpersona > 0)
                //{
                //    MessageBox.Show("Registro de persona exitoso","Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
                //}
                //else
                //{
                //    MessageBox.Show("Error en registro de persona", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}

                ttResolucionesTrans newresolucion = new ttResolucionesTrans();

                newresolucion.IDTIPORESOLUCION = 2;
                newresolucion.NUMERO = resolucionseleccionada.NUMERORESOLUCION;
                newresolucion.IDVEHICULONUEVO = insnew;
                newresolucion.IDPERSONANUEVA = idpersona;

                logs tmpLog3 = new logs();
                tmpLog3.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                tmpLog3.ID_USUARIO = usuarioSistema.ID_USUARIO;
                tmpLog3.OBJETO = "TT_RESOLUCIONES";
                tmpLog3.MODULO = "TPUBLICO";
                tmpLog3.TIPO_TRANSACCION = "INSERT";
                TimeSpan TS3;
                DateTime dt13 = DateTime.Now;

                string objetoAnalizado3 = AnalizadorDeObjetos.analizarObjeto(newresolucion.GetType(), new object[] { newresolucion});
                tmpLog3.ESTADO_ANTERIOR = objetoAnalizado3;

                int insresol = clienteTramitesTrans.crearTtResolucionesTrans(newresolucion);
                
                DateTime dt23 = DateTime.Now;
                TS3 = new TimeSpan(dt23.Ticks - dt13.Ticks);
                tmpLog3.TIEMPO_EJECUCION = TS3.Milliseconds;
                serviciosLogs.crearRegistroLog(tmpLog3);

                //if (numconcept <= 1)
                //{
                numConceptosFavorablesTrans inumerconcept = new numConceptosFavorablesTrans();

                inumerconcept.NUMEROCONCEPTO = numconcept;
                inumerconcept.TT_IDRESOLUCION = insresol;

                logs tmpLog4 = new logs();
                tmpLog4.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                tmpLog4.ID_USUARIO = usuarioSistema.ID_USUARIO;
                tmpLog4.OBJETO = "T_CONCEPTOSFAVORABLES";
                tmpLog4.MODULO = "TPUBLICO";
                tmpLog4.TIPO_TRANSACCION = "INSERT";
                TimeSpan TS4;
                DateTime dt14 = DateTime.Now;

                string objetoAnalizado4 = AnalizadorDeObjetos.analizarObjeto(inumerconcept.GetType(), new object[] { inumerconcept });
                tmpLog4.ESTADO_ANTERIOR = objetoAnalizado4;

                insnumconcep = clienteTramitesTrans.crearNumConceptosFavorablesTrans(inumerconcept);
                //}
                //else
                //{
                //    numConceptosFavorablesTrans enumerconcept = new numConceptosFavorablesTrans();
                //    numConceptosFavorablesTrans numconcepto = new numConceptosFavorablesTrans();
                //    enumerconcept.NUMEROCONCEPTO = numconcept - 1;
                //    Object[] listaconcepto = clienteTramitesTrans.getSNumConceptosFavorablesTrans(enumerconcept);

                //    if (listaconcepto != null && listaconcepto.Length >= 0)
                //    {
                //        numconcepto = (numConceptosFavorablesTrans)listaconcepto[0];
                //        numconcepto.NUMEROCONCEPTO = numconcept;
                //        insnumconcep = clienteTramitesTrans.editarNumConceptosFavorablesTrans(numconcepto);
                //    }
                //}

                if (insresol > 0)
                {
                    //MessageBox.Show("Resolución Insertada","Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    generarResolucion();
                    //this.Close();
                }
                else
                {
                    funciones.mostrarMensaje("Error al Insertar Resolución", "E");
                }
            }
            else
            {
                funciones.mostrarMensaje("Ocurrió un error en el proceso", "E");
            }
        }

        private void generarResolucion()
        {
            //ServiciosDocumentosService mySerDoc = new ServiciosDocumentosService();
            //clienteAccesorias.getFechaActual();

            //transferir myTrans = new transferir();
            //mySerDoc = new ServiciosDocumentosService();

            //clienteAccesorias.getFechaActual();

            //String nombreDoc = "Concepto_Favorable_" + resolucionseleccionada.NUMERORESOLUCION;

            //ServiciosConfiguracionesService clienteConfiguracion = WS.ServiciosConfiguracionesService();
            //String RutaResoluciones = clienteConfiguracion.leerRegistroIni("RESOLUCIONES");
            //RutaResoluciones = RutaResoluciones + "\\" + nombreDoc;

            try
            {
                ServiciosConfiguracionesService serviciosConfiguraciones = WS.ServiciosConfiguracionesService();

                object fileName = serviciosConfiguraciones.leerRegistroIni("PLANTILLAS") + "\\Concepto_Favorable.dotx";
                transferir myTransferencia = new transferir();
                myTransferencia.archivoDelServerSinAbrir((String)fileName);

                ProcesadorDocumentos myProcesadorDocs = new ProcesadorDocumentos();

                Dictionary<string, string> dicVariablesValores = new Dictionary<string, string>();

                dicVariablesValores.Add("NUM_CONCEPTO", numconceptofavorable.Text);
                dicVariablesValores.Add("EMPRESA_SERVICIO", nombreempresa.Text);
                dicVariablesValores.Add("TIPO_VEHICULO", resolucionseleccionada.NOMTIPOVEHICULO);
                dicVariablesValores.Add("PROPIETARIO", resolucionseleccionada.NOMBRESPERSONA + " " + resolucionseleccionada.APELLIDO1 + " " + resolucionseleccionada.APELLIDO2);
                dicVariablesValores.Add("TIPO_DOCUMENTO", resolucionseleccionada.IDDOCUMENTO);
                dicVariablesValores.Add("NUMERO_DOCUMENTO", resolucionseleccionada.IDENTIFICACION.Trim());
                dicVariablesValores.Add("NUM_CUPO", numercupo.Text);
                dicVariablesValores.Add("MARCA_VEHICULO", resolucionseleccionada.MARCAVEHICULO);
                dicVariablesValores.Add("NUMERO_MOTOR", resolucionseleccionada.NROMOTOR);
                dicVariablesValores.Add("NUMERO_CHASIS", resolucionseleccionada.CHASIS);
                dicVariablesValores.Add("MODELO_VEHICULO", resolucionseleccionada.MODELO.ToString());
                dicVariablesValores.Add("PLACA", txtPlaca.Text);
                dicVariablesValores.Add("FECHA_ACTUAL", clienteAccesorias.getFechaActual());
                dicVariablesValores.Add("MARCA_NV", marcavehiculo.Text);
                dicVariablesValores.Add("MODELO_NV", modelovehiculo.Text);
                dicVariablesValores.Add("MOTOR_NV", numeromotor.Text);
                dicVariablesValores.Add("NUEVO_PROPIETARIO", nombrerazonsocial.Text);
                dicVariablesValores.Add("IDENTIFICACION_NP", identificacionnit.Text);
                dicVariablesValores.Add("NUMERO_RESOLUCION", resolucionseleccionada.NUMERORESOLUCION);

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

                if (contenido != null)
                {
                    FrmGeneradorDocumentos myformGenerarDoc = new FrmGeneradorDocumentos(fileName.ToString(), misDocumentos + "\\Siatt\\ResolConceptoFavorable" + DateTime.Now.ToString("yyyyMMdd"), contenido, true, false, false, true, true, true, Modulo.Transporte_Publico);

                    DialogResult dr = myformGenerarDoc.ShowDialog(this);

                    if (dr == DialogResult.OK)
                    {
                        String rutaguardar = myformGenerarDoc.rutaG;
                    }
                }
                else
                    funciones.mostrarMensaje("Error al generar la resolución", "E");
            }
            catch (Exception exp)
            {
                funciones.mostrarMensaje("Error inesperado al generar la resolución", "E");
            }

            funciones.mostrarMensaje("Resolución Concepto favorable generada con éxito", "I");

            //try
            //{
            //    //mySerDoc.subirArchivo(myTrans.archivoToBytes(RutaResoluciones + ".docx"), RutaResoluciones + ".docx");
            //}
            //catch (Exception exce)
            //{
            //    funciones.mostrarMensaje("Error al subir el documento al servidor", "E");
            //}

            //this.Close();
            //myTrans.archivoAlServer(nombreDoc + ".pdf");
        }

        private void numeroresolucion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones myFun = new Funciones();
            myFun.lanzarTapConEnter(e);
        }

        private void placavehiculo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones myFun = new Funciones();
            myFun.lanzarTapConEnter(e);
        }

        private void numresolucion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones myFun = new Funciones();
            myFun.lanzarTapConEnter(e);
        }

        private void numercupo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones myFun = new Funciones();
            myFun.lanzarTapConEnter(e);
        }

        private void numconceptofavorable_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones myFun = new Funciones();
            myFun.lanzarTapConEnter(e);
        }

        private void nombreempresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones myFun = new Funciones();
            myFun.lanzarTapConEnter(e);
        }

        private void identificacionnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones myFun = new Funciones();
            myFun.esNit(e);
            myFun.lanzarTapConEnter(e);
        }

        private void nombrerazonsocial_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones myFun = new Funciones();
            myFun.lanzarTapConEnter(e);
        }

        private void clasevehiculo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones myFun = new Funciones();
            myFun.lanzarTapConEnter(e);
        }

        private void numerochasis_KeyPress(object sender, KeyPressEventArgs e)
        {
            funciones.lanzarTapConEnter(e);
        }

        private void numeromotor_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones myFun = new Funciones();
            myFun.lanzarTapConEnter(e);
        }

        private void txtPlaca_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones myFun = new Funciones();
            myFun.lanzarTapConEnter(e);
        }
    }
}
