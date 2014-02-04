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
using LibreriasSintrat.ServiciosVehiculos;
using LibreriasSintrat.ServiciosViewVehiculo;
using LibreriasSintrat.ServiciosMedidasCautelares;
using LibreriasSintrat.ServiciosPropietarios;
using LibreriasSintrat.ServiciosPersonas;
using LibreriasSintrat.ServiciosAccesorias;
using LibreriasSintrat.ServiciosEmpresas;
using TransportePublico;
using LibreriasSintrat.utilidades;
using TransitoPrincipal;
using LibreriasSintrat.ServiciosLogs;
using LibreriasSintrat.ServiciosUsuarios;
using TransportePublico.utilidades;

namespace TransportePublico.servicios.cupos
{
    public partial class editarcupo : Form
    {
        ServiciosCuposTransService clienteCuposTrans;
        ServiciosVehiculosService clienteVehiculos;
        ServiciosViewVehiculoService clienteViewVehiculos;
        ServiciosMedidasCautelaresService clienteCautelares;
        ServiciosPropietariosService clientePropietarios;
        ServiciosPersonasService clientePersonas;
        ServiciosAccesoriasService clienteAccesorias;
        ServiciosEmpresasService clienteEmpresas;
        ServiciosCuposTransService mySerCuposTrans;
        ServiciosLogsService serviciosLogs;
        usuarios usuarioSistema;

        viewCupos vistaseleccionada = new viewCupos();
        Object[] listacupos = null;
        Object[] listapropietariosaaa;
        empresasdeServicioTrans newempresa;
        vehiculo vehiculoAsociado = new vehiculo();
        Log log = new Log();

        Funciones funciones;

        int numpropietario = 0, quees = 0, idp = 0;
        //bool inicial = false;

        bool editable = false;

        public editarcupo(usuarios user)
        {
            InitializeComponent();
            log = new Log();
            usuarioSistema = user;
            serviciosLogs = WS.ServiciosLogsService();
        }

        private void editarcupo_Load(object sender, EventArgs e)
        {
            contenedorvehiculo.Enabled = false;
            contenedorpropietarios.Enabled = false;
            btnSave.Enabled = false;
            btnprimero.Enabled = false;
            btnanterior.Enabled = false;
            btnsiguiente.Enabled = false;
            btnultimo.Enabled = false;
            tipoVehiculoTrans tipo = new tipoVehiculoTrans();
            clienteCuposTrans = WS.ServiciosCuposTransService();
            clienteViewVehiculos = WS.ServiciosViewVehiculoService();
            clienteVehiculos = WS.ServiciosVehiculosService();
            clienteCautelares = WS.ServiciosMedidasCautelaresService();
            clientePropietarios = WS.ServiciosPropietariosService();
            clienteAccesorias = WS.ServiciosAccesoriasService();
            clientePersonas = WS.ServiciosPersonasService();
            clienteEmpresas = WS.ServiciosEmpresasService();
            mySerCuposTrans = WS.ServiciosCuposTransService();

            funciones = WS.Funciones();

            logs tmpLog1 = new logs();
            tmpLog1.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
            tmpLog1.ID_USUARIO = usuarioSistema.ID_USUARIO;
            tmpLog1.OBJETO = "TIPOVEHICULO";
            tmpLog1.MODULO = "TPUBLICO";
            tmpLog1.TIPO_TRANSACCION = "SELECT";
            TimeSpan TS1;
            DateTime dt11 = DateTime.Now;

            string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(tipo.GetType(), new object[] { tipo});
            tmpLog1.ESTADO_ANTERIOR = objetoAnalizado;


            Object[] listat = (Object[])clienteCuposTrans.getTipoVehiculoTrans(tipo);

            DateTime dt21 = DateTime.Now;
            TS1 = new TimeSpan(dt21.Ticks - dt11.Ticks);
            tmpLog1.TIEMPO_EJECUCION = TS1.Milliseconds;
            serviciosLogs.crearRegistroLog(tmpLog1);

            if (listat != null)
            {
                cmbTipoVehiculo.DataSource = null;
                cmbTipoVehiculo.DisplayMember = "NOMBRE";
                cmbTipoVehiculo.ValueMember = "ID";
                funciones.llenarCombo(cmbTipoVehiculo, listat);
            }

            rdBuscarNumero.Checked = true;
            contenedordatoscupo.Enabled = false;
        }

        private void btnbuscarempresa_Click(object sender, EventArgs e)
        {
            buscarEmpresa();
        }

        public void buscarEmpresa()
        {
            empresasdeServicioTrans empresa = new empresasdeServicioTrans();
            newempresa = new empresasdeServicioTrans();
            Funciones funciones = WS.Funciones();
            ArrayList Campos = new ArrayList();

            Campos.Add("NIT = NIT");
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


            buscador buscador = new buscador(Empresas, Campos, "Empresas", null);

            if (buscador.ShowDialog() == DialogResult.OK)
            {
                newempresa = (empresasdeServicioTrans)funciones.listToEmpresaServicio(buscador.Seleccion);
                siglaempresa.Text = newempresa.NIT;
                nombreempresa.Text = newempresa.NOMBRE;
            }
        }

        private void tipovehiculo_SelectedValueChanged(object sender, EventArgs e)
        {
            verificarCupos();
        }

        private void verificarCupos()
        {
            if (siglaempresa.Text != "" || nombreempresa.Text != "")
            {
                //inicial = true;

                detalleRangoCupoTrans cuposdisp = new detalleRangoCupoTrans();
                Funciones funciones = WS.Funciones();

                if (newempresa != null)
                {
                    if (cmbTipoVehiculo.SelectedIndex >= 0)
                    {
                        viewCupos vistacupos = new viewCupos();
                        vistacupos.EMPRESAS = newempresa.NOMBRE;
                        vistacupos.TIPOVEHI = cmbTipoVehiculo.Text;

                        if (numcupo.Text != "")
                        {
                            vistacupos.NUMERO = Int32.Parse(numcupo.Text);
                        }

                        logs tmpLog = new logs();
                        tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                        tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
                        tmpLog.OBJETO = "VIEW_CUPOS";
                        tmpLog.MODULO = "TPUBLICO";
                        tmpLog.TIPO_TRANSACCION = "SELECT";
                        TimeSpan TS;
                        DateTime dt1 = DateTime.Now;

                        string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(vistacupos.GetType(), new object[] { vistacupos});
                        tmpLog.ESTADO_ANTERIOR = objetoAnalizado;

                        listacupos = clienteCuposTrans.getSViewCupos(vistacupos);

                        DateTime dt2 = DateTime.Now;
                        TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
                        tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;
                        serviciosLogs.crearRegistroLog(tmpLog);


                        if (listacupos != null && listacupos.Length >= 0)
                        {
                            contenedorvehiculo.Enabled = true;
                            contenedorpropietarios.Enabled = true;
                            btnSave.Enabled = true;
                            btnprimero.Enabled = true;
                            btnanterior.Enabled = true;
                            btnsiguiente.Enabled = true;
                            btnultimo.Enabled = true;

                            mostrarCupos(listacupos);
                        }
                        else
                        {
                            contenedorvehiculo.Enabled = false;
                            contenedorpropietarios.Enabled = false;
                            btnSave.Enabled = false;
                            btnprimero.Enabled = false;
                            btnanterior.Enabled = false;
                            btnsiguiente.Enabled = false;
                            btnultimo.Enabled = false;
                            MessageBox.Show("No se encontraron cupos");
                            grillacupos.DataSource = null;
                            limpiarCampos();
                        }
                    }
                }
                else
                {
                    buscarEmpresa();
                }

                //inicial = false;
            }
        }

        private void mostrarCupos(Object[] lista)
        {
            Funciones funciones = WS.Funciones();
            DataTable dt = new DataTable();
            ArrayList Campos = new ArrayList();

            Campos.Add("NUMERO = NUMERO CUPO");
            Campos.Add("EMPRESAS = EMPRESA DE SERVICIO");
            Campos.Add("TIPOVEHI = TIPO DE VEHICULO");
            Campos.Add("PLACA = PLACA");
            Campos.Add("NOMBRE = PERSONA PROPIETARIA");
            Campos.Add("RAZONSOCIAL = EMPRESA PROPIETARIA");

            try
            {
                dt = funciones.ToDataTable(funciones.ObjectToArrayList(lista));
            }
            catch (Exception e)
            {
                log.escribirError(e.ToString(), this.GetType());
            }

            grillacupos.DataSource = dt;

            if (dt.Rows.Count > 0)
            {
                funciones.configurarGrilla(grillacupos, Campos);
            }

            dt = null;
            Campos = null;

            grillacupos.Select();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones funciones = WS.Funciones();
            funciones.esNumero(e);
            funciones.lanzarTapConEnter(e);
        }

        private void btnSearchCupo_Click(object sender, EventArgs e)
        {

        }

        public void buscarCupos()
        {
            if (listacupos != null)
            {
                //cupo
                //buscador search = new buscador(listacupos,);
            }
            else
                MessageBox.Show("No existen cupos disponibles.");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnbuscarvehiculo_Click(object sender, EventArgs e)
        {
            if (placavehiculo.Text == "")
            {
                MessageBox.Show("Debe ingresar el número de Placa del Vehículo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                placavehiculo.Focus();
            }
            else
            {
                buscarPendientes();
            }
        }

        private void buscarPendientes()
        {
            vehiculo vehicul = new vehiculo();
            jPendiente pendiente = new jPendiente();

            vehicul.PLACA = placavehiculo.Text;

            logs tmpLog = new logs();
            tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
            tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
            tmpLog.OBJETO = "VEHICULO";
            tmpLog.MODULO = "TPUBLICO";
            tmpLog.TIPO_TRANSACCION = "SELECT";
            TimeSpan TS;
            DateTime dt1 = DateTime.Now;

            string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(vehicul.GetType(), new object[] { vehicul});
            tmpLog.ESTADO_ANTERIOR = objetoAnalizado;

            DateTime dt2 = DateTime.Now;
            TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
            tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;
            serviciosLogs.crearRegistroLog(tmpLog);

            vehiculoAsociado = clienteVehiculos.getVehiculo(vehicul);
            pendiente.JP_V_ID = vehiculoAsociado.ID_VEHICULO;
            pendiente.JP_ACTIVO = 1;

            logs tmpLog1 = new logs();
            tmpLog1.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
            tmpLog1.ID_USUARIO = usuarioSistema.ID_USUARIO;
            tmpLog1.OBJETO = "J_PENDIENTE";
            tmpLog1.MODULO = "TPUBLICO";
            tmpLog1.TIPO_TRANSACCION = "SELECT";
            TimeSpan TS1;
            DateTime dt11 = DateTime.Now;

            string objetoAnalizado1 = AnalizadorDeObjetos.analizarObjeto(pendiente.GetType(), new object[] { pendiente});
            tmpLog.ESTADO_ANTERIOR = objetoAnalizado;

            Object[] listapendientes = clienteCautelares.ListarMedidasCautelares(pendiente);

            DateTime dt21 = DateTime.Now;
            TS1 = new TimeSpan(dt21.Ticks - dt11.Ticks);
            tmpLog1.TIEMPO_EJECUCION = TS1.Milliseconds;
            serviciosLogs.crearRegistroLog(tmpLog1);

            if (listapendientes != null && listapendientes.Length >= 0)
            {
                MessageBox.Show("El vehiculo tiene Pendiente Judiciales Activos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                buscarVehiculo();
            }
        }

        private void grillacupos_SelectionChanged(object sender, EventArgs e)
        {
            if (grillacupos.CurrentRow != null && listacupos != null)
            {
                vistaseleccionada = (viewCupos)listacupos[grillacupos.CurrentRow.Index];

                buscarVehiculo();
            }
            else
            {
                grillacupos.DataSource = null;
                limpiarCampos();
            }
        }

        public void buscarVehiculo()
        {
            //placavehiculo.Text = "";

            //if(inicial)
            if(!editable)
                placavehiculo.Text = vistaseleccionada.PLACA;

            viewVehiculo vehiculobusca = new viewVehiculo();
            viewVehiculo encontrado;

            vehiculobusca.PLACA = placavehiculo.Text;

            logs tmpLog = new logs();
            tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
            tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
            tmpLog.OBJETO = "VIEW_VEHICULO";
            tmpLog.MODULO = "TPUBLICO";
            tmpLog.TIPO_TRANSACCION = "SELECT";
            TimeSpan TS;
            DateTime dt1 = DateTime.Now;

            string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(vehiculobusca.GetType(), new object[] { vehiculobusca});
            tmpLog.ESTADO_ANTERIOR = objetoAnalizado;

            encontrado = clienteViewVehiculos.consultarInformacionVehiculoPorPlaca(vehiculobusca);

            DateTime dt2 = DateTime.Now;
            TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
            tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;
            serviciosLogs.crearRegistroLog(tmpLog);

            if (encontrado != null && encontrado.IDVEHICULO > 0)
            {
                if ((encontrado.CLASEVEH == "AUTOMOVIL" && cmbTipoVehiculo.Text == "TAXI") || (encontrado.CLASEVEH == cmbTipoVehiculo.Text))
                {
                    marcavehiculo.Text = encontrado.MARCAVEH;
                    lineavehiculo.Text = encontrado.LINEAVEH;
                    clasevehiculo.Text = encontrado.CLASEVEH;
                    numerochasis.Text = encontrado.NUMEROCHASIS;
                    tipocarroseria.Text = encontrado.TIPOCARROCERIA;
                    numeromotor.Text = encontrado.NUMEROMOTOR;
                    buscarPropietarios();

                    editable = true;

                    btnSave.Enabled = true;
                }
                else
                {
                    editable = false;

                    btnSave.Enabled = false;
                    MessageBox.Show("El vehiculo no se ajusta a las caracteristicas del cupo");
                }
            }
            else
            {
                editable = false;

                btnSave.Enabled = true;

                MessageBox.Show("No se encontraron datos del Vehículo ", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buscarPropietarios()
        {
            propietarioDeVehiculo propietariosss = new propietarioDeVehiculo();
            propietariosss.ID_VEHICULO = vehiculoAsociado.ID_VEHICULO;
            propietariosss.PROPIETARIOACTUAL = "T";

            logs tmpLog = new logs();
            tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
            tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
            tmpLog.OBJETO = "PROPIETARIODEVEHICULO";
            tmpLog.MODULO = "TPUBLICO";
            tmpLog.TIPO_TRANSACCION = "SELECT";
            TimeSpan TS;
            DateTime dt1 = DateTime.Now;

            string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(propietariosss.GetType(), new object[] { propietariosss});
            tmpLog.ESTADO_ANTERIOR = objetoAnalizado;

            listapropietariosaaa = (Object[])clientePropietarios.getPropietariosDeVehiculos(propietariosss);

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
                MessageBox.Show("No se encontraron propietarios", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            Funciones funciones = WS.Funciones();

            logs tmpLog = new logs();
            tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
            tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
            tmpLog.OBJETO = "DOCUMENTO";
            tmpLog.MODULO = "TPUBLICO";
            tmpLog.TIPO_TRANSACCION = "SELECT";
            TimeSpan TS;
            DateTime dt1 = DateTime.Now;

            Object[] listad = (Object[])clienteAccesorias.getDocumentos();

            DateTime dt2 = DateTime.Now;
            TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
            tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;
            serviciosLogs.crearRegistroLog(tmpLog);

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

            logs tmpLog1 = new logs();
            tmpLog1.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
            tmpLog1.ID_USUARIO = usuarioSistema.ID_USUARIO;
            tmpLog1.OBJETO = "PERSONA";
            tmpLog1.MODULO = "TPUBLICO";
            tmpLog1.TIPO_TRANSACCION = "SELECT";
            TimeSpan TS1;
            DateTime dt11 = DateTime.Now;

            string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(person.GetType(), new object[] { person});
            tmpLog.ESTADO_ANTERIOR = objetoAnalizado;

            lapersona = clientePersonas.getPersona(person);

            DateTime dt21 = DateTime.Now;
            TS1 = new TimeSpan(dt21.Ticks - dt11.Ticks);
            tmpLog1.TIEMPO_EJECUCION = TS1.Milliseconds;
            serviciosLogs.crearRegistroLog(tmpLog1);

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

                logs tmpLog2 = new logs();
                tmpLog2.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                tmpLog2.ID_USUARIO = usuarioSistema.ID_USUARIO;
                tmpLog2.OBJETO = "CIUDAD";
                tmpLog2.MODULO = "TPUBLICO";
                tmpLog2.TIPO_TRANSACCION = "SELECT";
                TimeSpan TS2;
                DateTime dt12 = DateTime.Now;

                string objetoAnalizado2 = AnalizadorDeObjetos.analizarObjeto(ciuda.GetType(), new object[] { ciuda });
                tmpLog2.ESTADO_ANTERIOR = objetoAnalizado2;

                laciudad = clienteAccesorias.getCiudadporID(ciuda);

                DateTime dt22 = DateTime.Now;
                TS2 = new TimeSpan(dt22.Ticks - dt12.Ticks);
                tmpLog2.TIEMPO_EJECUCION = TS2.Milliseconds;
                serviciosLogs.crearRegistroLog(tmpLog2);

                if (laciudad != null)
                {
                    codigociudad.Text = laciudad.CODCIUDAD;
                    nombreciudad.Text = laciudad.NOMBRE;
                }
            }
        }

        private void cargarEmpresa(int idempres)
        {

            empresa empres = new empresa();
            empresa laempresa = new empresa();
            empres.ID_EMPRESA = idempres;


            logs tmpLog = new logs();
            tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
            tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
            tmpLog.OBJETO = "EMPRESASDESERVICIO";
            tmpLog.MODULO = "TPUBLICO";
            tmpLog.TIPO_TRANSACCION = "SELECT";
            TimeSpan TS;
            DateTime dt1 = DateTime.Now;

            string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(empres.GetType(), new object[] { empres });
            tmpLog.ESTADO_ANTERIOR = objetoAnalizado;

            Object[] lempres = (Object[])clienteEmpresas.getEmpresa(empres);

            DateTime dt2 = DateTime.Now;
            TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
            tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;
            serviciosLogs.crearRegistroLog(tmpLog);

            if (lempres != null && lempres.Length >= 0)
            {
                laempresa = (empresa)lempres[0];
                nit.Text = laempresa.NIT;
                nombreempresa.Text = laempresa.RAZONSOCIAL;
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

            if (quees == 1)
            {
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
            }
            else if (quees == 2)
            {
                nit.Text = "";
                nombreempresa.Text = "";
            }

            editable = false;
            btnSave.Enabled = false;
            chkHabilitarBuscarPlaca.Checked = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (placavehiculo.Text != "" && placavehiculo.ReadOnly.Equals(false) && vehiculoAsociado != null && vehiculoAsociado.ID_VEHICULO > 0)
            {
                editarCupo();
            }
            else 
            {
                funciones.mostrarMensaje("Debe buscar primero el Vehículo", "I");
                btnSave.Enabled = false;
            }
        }   

        private void editarCupo()
        {
            Object[] tmp;
            cuposTaxisTrans myCupo = new cuposTaxisTrans();
            cuposTaxisTrans myCupoTmp = new cuposTaxisTrans();

            myCupo.TT_IDCUPOTAXI = vistaseleccionada.ID;


            logs tmpLog = new logs();
            tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
            tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
            tmpLog.OBJETO = "T_CUPOSTAXIS";
            tmpLog.MODULO = "TPUBLICO";
            tmpLog.TIPO_TRANSACCION = "SELECT";
            TimeSpan TS;
            DateTime dt1 = DateTime.Now;

            string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(myCupo.GetType(), new object[] { myCupo });
            tmpLog.ESTADO_ANTERIOR = objetoAnalizado;

            myCupo = clienteCuposTrans.getCuposTaxisTransPorId(myCupo);

            DateTime dt2 = DateTime.Now;
            TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
            tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;
            serviciosLogs.crearRegistroLog(tmpLog);

            if (vehiculoAsociado != null && vehiculoAsociado.ID_VEHICULO > 0)
            {
                myCupoTmp.TT_ID_VEHICULO = vehiculoAsociado.ID_VEHICULO;

                logs tmpLog1 = new logs();
                tmpLog1.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                tmpLog1.ID_USUARIO = usuarioSistema.ID_USUARIO;
                tmpLog1.OBJETO = "T_CUPOSTAXI";
                tmpLog1.MODULO = "TPUBLICO";
                tmpLog1.TIPO_TRANSACCION = "SELECT";
                TimeSpan TS1;
                DateTime dt11 = DateTime.Now;

                string objetoAnalizado1 = AnalizadorDeObjetos.analizarObjeto(myCupoTmp.GetType(), new object[] { myCupoTmp });
                tmpLog1.ESTADO_ANTERIOR = objetoAnalizado;

                tmp = (Object[])clienteCuposTrans.getSCupos(myCupoTmp);

                DateTime dt21 = DateTime.Now;
                TS1 = new TimeSpan(dt21.Ticks - dt11.Ticks);
                tmpLog1.TIEMPO_EJECUCION = TS1.Milliseconds;
                serviciosLogs.crearRegistroLog(tmpLog1);

                if (tmp != null && tmp.Length > 0)
                {
                    funciones.mostrarMensaje("Este Vehículo ya tiene cupos asignados", "I");
                    placavehiculo.Focus();
                    return;
                }
                else
                {
                    if (myCupo != null)
                    {
                        myCupo.TT_ID_VEHICULO = vehiculoAsociado.ID_VEHICULO;

                        logs tmpLog2 = new logs();
                        tmpLog2.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                        tmpLog2.ID_USUARIO = usuarioSistema.ID_USUARIO;
                        tmpLog2.OBJETO = "T_CUPOSTAXIS";
                        tmpLog2.MODULO = "TPUBLICO";
                        tmpLog2.TIPO_TRANSACCION = "UPDATE";
                        TimeSpan TS2;
                        DateTime dt12 = DateTime.Now;

                        tmpLog2.ESTADO_ANTERIOR = objetoAnalizado1;


                        bool editado = clienteCuposTrans.editarCuposTaxis(myCupo);

                        string objetoAnalizado2 = AnalizadorDeObjetos.analizarObjeto(myCupo.GetType(), new object[] { myCupo });
                        tmpLog2.ESTADO_FINAL = objetoAnalizado2;                        

                        DateTime dt22 = DateTime.Now;
                        TS2 = new TimeSpan(dt22.Ticks - dt12.Ticks);
                        tmpLog2.TIEMPO_EJECUCION = TS2.Milliseconds;
                        serviciosLogs.crearRegistroLog(tmpLog2);


                        if (editado)
                        {
                            funciones.mostrarMensaje("Cupo Actualizado Correctamente", "I");

                            limpiarCampos();
                            //buscarVehiculo();
                            btnSave.Enabled = false;
                        }
                        else
                        {
                            funciones.mostrarMensaje("No fue posible realizar la actualizacion", "I");

                            limpiarCampos();
                        }
                    }
                    else
                    { 
                        funciones.mostrarMensaje("No fue posible realizar la actualización", "I");

                        limpiarCampos();
                    }
                }
            }
            else
            {
                funciones.mostrarMensaje("Se debe Definir el Vehículo", "E");
            }
        }

        private void placavehiculo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (placavehiculo.Text == "")
                {
                    MessageBox.Show("Debe ingresar el numero de Placa del Vehiculo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    placavehiculo.Focus();
                }
                else
                {
                    buscarPendientes();
                }
            }
        }

        private void numcupo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                verificarCupos();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            busquedaCupos();
        }

        private void busquedaCupos()
        {
            Funciones func = WS.Funciones();

            grillacupos.DataSource = null;

            limpiarCampos();

            if (rdBuscarNumero.Checked)
            {
                if (!txtNroCupo.Text.Equals(""))
                {
                    cuposTaxisTrans myCuposTax = new cuposTaxisTrans();
                    myCuposTax.TT_NUMCUPO = int.Parse(txtNroCupo.Text);

                    logs tmpLog = new logs();
                    tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                    tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
                    tmpLog.OBJETO = "T_CUPOSTAXIS";
                    tmpLog.MODULO = "TPUBLICO";
                    tmpLog.TIPO_TRANSACCION = "SELECT";
                    TimeSpan TS;
                    DateTime dt1 = DateTime.Now;

                    string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(myCuposTax.GetType(), new object[] { myCuposTax});
                    tmpLog.ESTADO_ANTERIOR = objetoAnalizado;

                    object[] listaCuposTax = mySerCuposTrans.getSCupos(myCuposTax);

                    DateTime dt2 = DateTime.Now;
                    TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
                    tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;
                    serviciosLogs.crearRegistroLog(tmpLog);

                    if (listaCuposTax != null && listaCuposTax.Length > 0)
                    {
                        myCuposTax = (cuposTaxisTrans)listaCuposTax[0];
                        viewCupos myViewCupos = new viewCupos();
                        myViewCupos.ID = myCuposTax.TT_IDCUPOTAXI;

                        logs tmpLog1 = new logs();
                        tmpLog1.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                        tmpLog1.ID_USUARIO = usuarioSistema.ID_USUARIO;
                        tmpLog1.OBJETO = "VIEW_CUPOS";
                        tmpLog1.MODULO = "TPUBLICO";
                        tmpLog1.TIPO_TRANSACCION = "SELECT";
                        TimeSpan TS1;
                        DateTime dt11 = DateTime.Now;

                        string objetoAnalizado1 = AnalizadorDeObjetos.analizarObjeto(myCuposTax.GetType(), new object[] { myCuposTax });
                        tmpLog1.ESTADO_ANTERIOR = objetoAnalizado1;

                        object[] listaViewCupos = mySerCuposTrans.getSViewCupos(myViewCupos);

                        DateTime dt21 = DateTime.Now;
                        TS1 = new TimeSpan(dt21.Ticks - dt11.Ticks);
                        tmpLog1.TIEMPO_EJECUCION = TS1.Milliseconds;
                        serviciosLogs.crearRegistroLog(tmpLog1);

                        if (listaViewCupos != null && listaViewCupos.Length > 0)
                        {
                            myViewCupos = (viewCupos)listaViewCupos[0];
                            vehiculo myVehiculo = new vehiculo();

                            myVehiculo.PLACA = myViewCupos.PLACA;
                            clienteVehiculos = WS.ServiciosVehiculosService();

                            logs tmpLog3 = new logs();
                            tmpLog3.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                            tmpLog3.ID_USUARIO = usuarioSistema.ID_USUARIO;
                            tmpLog3.OBJETO = "VEHICULO";
                            tmpLog3.MODULO = "TPUBLICO";
                            tmpLog3.TIPO_TRANSACCION = "SELECT";
                            TimeSpan TS3;
                            DateTime dt13 = DateTime.Now;

                            string objetoAnalizado3 = AnalizadorDeObjetos.analizarObjeto(myVehiculo.GetType(), new object[] { myVehiculo });
                            tmpLog.ESTADO_ANTERIOR = objetoAnalizado;

                            myVehiculo = clienteVehiculos.getVehiculo(myVehiculo);

                            DateTime dt23 = DateTime.Now;
                            TS3 = new TimeSpan(dt23.Ticks - dt13.Ticks);
                            tmpLog3.TIEMPO_EJECUCION = TS3.Milliseconds;
                            serviciosLogs.crearRegistroLog(tmpLog3);

                            if (myVehiculo != null && myVehiculo.ID_VEHICULO > 0)
                            {
                                llenarCamposVehiculo(myVehiculo.ID_VEHICULO);
                            }

                            empresasdeServicioTrans myEmpresa = new empresasdeServicioTrans();
                            myEmpresa.NOMBRE = myViewCupos.EMPRESAS;
                            myEmpresa.DIGVERIF = -2;

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

                            object[] listaEmpresa = mySerCuposTrans.getEmpresaServicio(myEmpresa);

                            DateTime dt24 = DateTime.Now;
                            TS4 = new TimeSpan(dt24.Ticks - dt14.Ticks);
                            tmpLog4.TIEMPO_EJECUCION = TS4.Milliseconds;
                            serviciosLogs.crearRegistroLog(tmpLog4);


                            if (listaEmpresa != null && listaEmpresa.Length > 0)
                            {
                                myEmpresa = (empresasdeServicioTrans)listaEmpresa[0];

                                //Se asigna la empresa
                                newempresa = myEmpresa;
                                siglaempresa.Text = myEmpresa.NIT;
                                nombreempresa.Text = myEmpresa.NOMBRE;
                            }
                            else 
                            {
                                buscarEmpresa();
                            }

                            tipoVehiculoTrans myTipoVeh = new tipoVehiculoTrans();
                            myTipoVeh.NOMBRE = myViewCupos.TIPOVEHI;

                            logs tmpLog2 = new logs();
                            tmpLog2.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                            tmpLog2.ID_USUARIO = usuarioSistema.ID_USUARIO;
                            tmpLog2.OBJETO = "TIPOVEHICULO";
                            tmpLog2.MODULO = "TPUBLICO";
                            tmpLog2.TIPO_TRANSACCION = "SELECT";
                            TimeSpan TS2;
                            DateTime dt12 = DateTime.Now;

                            string objetoAnalizado2 = AnalizadorDeObjetos.analizarObjeto(myTipoVeh.GetType(), new object[] { myTipoVeh });
                            tmpLog2.ESTADO_ANTERIOR = objetoAnalizado2;

                            object[] listaTipo = mySerCuposTrans.buscarTipoVehiculoTrans(myTipoVeh);

                            DateTime dt22 = DateTime.Now;
                            TS2 = new TimeSpan(dt22.Ticks - dt12.Ticks);
                            tmpLog2.TIEMPO_EJECUCION = TS2.Milliseconds;
                            serviciosLogs.crearRegistroLog(tmpLog2);

                            if (listaTipo != null && listaTipo.Length > 0)
                            {
                                myTipoVeh = (tipoVehiculoTrans)listaTipo[0];
                                cmbTipoVehiculo.SelectedValue = myTipoVeh.ID;
                            }
                        }

                        contenedordatoscupo.Enabled = true;
                        numcupo.Text = txtNroCupo.Text;

                        verificarCupos();
                    }
                    else
                    {
                        func.mostrarMensaje("No se encontró un cupo con ese número", "W");
                    }

                    /*detalleRangoCupoTrans myDetalleRanCupo = new detalleRangoCupoTrans();
                    myDetalleRanCupo.NROCUPO = numcupo.Text;
                    myDetalleRanCupo.ASIGNADO = "T";
                    object[] listaDetalle = mySerCuposTrans.getSInventarioCuposEmpresa(myDetalleRanCupo);
                    if (listaDetalle != null && listaDetalle.Length > 0)
                    {
                        myDetalleRanCupo = (detalleRangoCupoTrans)listaDetalle[0];
                        rangoCuposVehiculoPublicoTrans myRangoCupo = new rangoCuposVehiculoPublicoTrans();
                        myRangoCupo.ID_RANGOCUPO = myDetalleRanCupo.IDRANGOCUPO;
                        object[] listaRangos = mySerCuposTrans.getSRangoCuposVehiculo(myRangoCupo);
                        if (listaRangos != null && listaRangos.Length > 0)
                        {
                            myRangoCupo = (rangoCuposVehiculoPublicoTrans)listaRangos[0];
                            tipovehiculo.SelectedValue = myRangoCupo.IDTIPOVEHICULO;
                            empresasdeServicioTrans myEmpresaServicio = new empresasdeServicioTrans();
                            myEmpresaServicio.ID_EMPSERVICIO = myRangoCupo.IDEMPRESATRANSP;
                            object[] listaEmpresa = mySerCuposTrans.getEmpresaServicio(myEmpresaServicio);
                            if (listaEmpresa != null && listaEmpresa.Length > 0)
                            {
                                myEmpresaServicio = (empresasdeServicioTrans)listaEmpresa[0];
                                siglaempresa.Text = myEmpresaServicio.NIT;
                                nombreempresa.Text = myEmpresaServicio.NOMBRE;
                                newempresa = myEmpresaServicio;
                                //verificarCupos();
                                viewCupos viewCupos = new viewCupos();
                                viewCupos.NUMERO = int.Parse(myDetalleRanCupo.NROCUPO);
                                object[] listaViewC = mySerCuposTrans.getSViewCupos(viewCupos);
                                if (listaViewC != null && listaViewC.Length > 0)
                                {
                                    viewCupos = (viewCupos)listaViewC[0];
                                    inicial = true;
                                    buscarVehiculo();
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron cupos con ese número", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }*/
                }
                else
                {
                    MessageBox.Show("El campo número de cupo no puede ser vacio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            if (rdPlaca.Checked)
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
                        cuposTaxisTrans myCuposTaxi = new cuposTaxisTrans();
                        myCuposTaxi.TT_ID_VEHICULO = myVehiculo.ID_VEHICULO;

                        logs tmpLog2 = new logs();
                        tmpLog2.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                        tmpLog2.ID_USUARIO = usuarioSistema.ID_USUARIO;
                        tmpLog2.OBJETO = "T_CUPOSTAXIS";
                        tmpLog2.MODULO = "TPUBLICO";
                        tmpLog2.TIPO_TRANSACCION = "SELECT";
                        TimeSpan TS2;
                        DateTime dt12 = DateTime.Now;

                        string objetoAnalizado2 = AnalizadorDeObjetos.analizarObjeto(myCuposTaxi.GetType(), new object[] { myCuposTaxi });
                        tmpLog2.ESTADO_ANTERIOR = objetoAnalizado2;

                        object[] listaCupos = mySerCuposTrans.getSCupos(myCuposTaxi);

                        DateTime dt22 = DateTime.Now;
                        TS2 = new TimeSpan(dt22.Ticks - dt12.Ticks);
                        tmpLog2.TIEMPO_EJECUCION = TS2.Milliseconds;
                        serviciosLogs.crearRegistroLog(tmpLog2);

                        if (listaCupos != null && listaCupos.Length > 0)
                        {
                            myCuposTaxi = (cuposTaxisTrans)listaCupos[0];
                            numcupo.Text = myCuposTaxi.TT_NUMCUPO.ToString();
                            llenarCamposVehiculo(myVehiculo.ID_VEHICULO);
                            viewCupos myViewCupos = new viewCupos();
                            myViewCupos.ID = myCuposTaxi.TT_IDCUPOTAXI;
                            myViewCupos.NUMERO = myCuposTaxi.TT_NUMCUPO;

                            logs tmpLog3 = new logs();
                            tmpLog3.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                            tmpLog3.ID_USUARIO = usuarioSistema.ID_USUARIO;
                            tmpLog3.OBJETO = "VIEW_CUPOS";
                            tmpLog3.MODULO = "TPUBLICO";
                            tmpLog3.TIPO_TRANSACCION = "SELECT";
                            TimeSpan TS3;
                            DateTime dt13 = DateTime.Now;

                            string objetoAnalizado3 = AnalizadorDeObjetos.analizarObjeto(myViewCupos.GetType(), new object[] { myViewCupos });
                            tmpLog3.ESTADO_ANTERIOR = objetoAnalizado;


                            object[] listaViewCupos = mySerCuposTrans.getSViewCupos(myViewCupos);

                            DateTime dt23 = DateTime.Now;
                            TS3 = new TimeSpan(dt23.Ticks - dt13.Ticks);
                            tmpLog3.TIEMPO_EJECUCION = TS3.Milliseconds;
                            serviciosLogs.crearRegistroLog(tmpLog3);

                            if (listaViewCupos != null && listaViewCupos.Length > 0)
                            {
                                myViewCupos = (viewCupos)listaViewCupos[0];
                                empresasdeServicioTrans myEmpresa = new empresasdeServicioTrans();
                                myEmpresa.NOMBRE = myViewCupos.EMPRESAS;

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

                                object[] listaEmpresa = mySerCuposTrans.getEmpresaServicio(myEmpresa);

                                DateTime dt24 = DateTime.Now;
                                TS4 = new TimeSpan(dt24.Ticks - dt14.Ticks);
                                tmpLog4.TIEMPO_EJECUCION = TS4.Milliseconds;
                                serviciosLogs.crearRegistroLog(tmpLog4);


                                if (listaEmpresa != null && listaEmpresa.Length > 0)
                                {
                                    myEmpresa = (empresasdeServicioTrans)listaEmpresa[0];
                                    //Se asigna la empresa
                                    newempresa = myEmpresa;
                                    nombreempresa.Text = myEmpresa.NOMBRE;
                                    siglaempresa.Text = myEmpresa.NIT;
                                }

                                tipoVehiculoTrans myTipoVeh = new tipoVehiculoTrans();
                                myTipoVeh.NOMBRE = myViewCupos.TIPOVEHI;

                                logs tmpLog5 = new logs();
                                tmpLog5.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                                tmpLog5.ID_USUARIO = usuarioSistema.ID_USUARIO;
                                tmpLog5.OBJETO = "TIPOVEHICULO";
                                tmpLog5.MODULO = "TPUBLICO";
                                tmpLog5.TIPO_TRANSACCION = "SELECT";
                                TimeSpan TS5;
                                DateTime dt15 = DateTime.Now;

                                string objetoAnalizado5 = AnalizadorDeObjetos.analizarObjeto(myTipoVeh.GetType(), new object[] { myTipoVeh });
                                tmpLog.ESTADO_ANTERIOR = objetoAnalizado;

                                object[] listaTipoCupo = mySerCuposTrans.buscarTipoVehiculoTrans(myTipoVeh);

                                DateTime dt25 = DateTime.Now;
                                TS5 = new TimeSpan(dt25.Ticks - dt15.Ticks);
                                tmpLog5.TIEMPO_EJECUCION = TS5.Milliseconds;
                                serviciosLogs.crearRegistroLog(tmpLog5);


                                if (listaTipoCupo != null && listaTipoCupo.Length > 0)
                                {
                                    myTipoVeh = (tipoVehiculoTrans)listaTipoCupo[0];
                                    cmbTipoVehiculo.SelectedValue = myTipoVeh.ID;
                                }
                            }

                            contenedordatoscupo.Enabled = true;

                            verificarCupos();
                        }
                        else
                        {
                            func.mostrarMensaje("El Vehículo no tiene un cupo asociado", "W");
                        }
                    }
                    else
                    {
                        func.mostrarMensaje("No se encontró el Vehículo", "W");
                    }
                }
                else
                {
                    func.mostrarMensaje("El campo placa no puede ser vacio!", "W");
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
                    tmpLog1.OBJETO = "VIEW_VEHICULO";
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

                        //placavehiculo.Text = myViewVehiculo.PLACA;
                        marcavehiculo.Text = myViewVehiculo.MARCAVEH;
                        lineavehiculo.Text = myViewVehiculo.LINEAVEH;
                        clasevehiculo.Text = myViewVehiculo.CLASEVEH;
                        numerochasis.Text = myViewVehiculo.NUMEROCHASIS;
                        tipocarroseria.Text = myViewVehiculo.TIPOCARROCERIA;
                        numeromotor.Text = myViewVehiculo.NUMEROMOTOR;
                    }

                    clientePropietarios = WS.ServiciosPropietariosService();
                    propietarioDeVehiculo myPropietariosVehi = new propietarioDeVehiculo();
                    myPropietariosVehi.ID_VEHICULO = myVehi.ID_VEHICULO;
                    myPropietariosVehi.PROPIETARIOACTUAL = "T";

                    logs tmpLog2 = new logs();
                    tmpLog2.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                    tmpLog2.ID_USUARIO = usuarioSistema.ID_USUARIO;
                    tmpLog2.OBJETO = "TIPOVEHICULO";
                    tmpLog2.MODULO = "TPUBLICO";
                    tmpLog2.TIPO_TRANSACCION = "SELECT";
                    TimeSpan TS2;
                    DateTime dt12 = DateTime.Now;

                    string objetoAnalizado2 = AnalizadorDeObjetos.analizarObjeto(myPropietariosVehi.GetType(), new object[] { myPropietariosVehi });
                    tmpLog2.ESTADO_ANTERIOR = objetoAnalizado;


                    object[] listaProp = clientePropietarios.getPropietariosDeVehiculos(myPropietariosVehi);

                    DateTime dt22 = DateTime.Now;
                    TS2 = new TimeSpan(dt2.Ticks - dt12.Ticks);
                    tmpLog2.TIEMPO_EJECUCION = TS2.Milliseconds;
                    serviciosLogs.crearRegistroLog(tmpLog2);

                    if (listaProp != null && listaProp.Length > 0)
                    {
                        contenedorpropietarios.Enabled = true;
                        btnSave.Enabled = true;

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

        private void limpiarEmpresa()
        {
            siglaempresa.Text = "";
            nombreempresa.Text = "";
            cmbTipoVehiculo.SelectedIndex = -1;
            numcupo.Text = "";
            contenedordatoscupo.Enabled = false;
        }

        private void rdBuscarNumero_CheckedChanged(object sender, EventArgs e)
        {
            if (rdBuscarNumero.Checked)
            {
                txtNroCupo.Enabled = true;
                txtPlaca.Enabled = false;
            }
            else
            {
                txtNroCupo.Enabled = false;
                txtPlaca.Enabled = false;
            }
        }

        private void rdPlaca_CheckedChanged(object sender, EventArgs e)
        {
            if (rdPlaca.Checked)
            {
                txtPlaca.Enabled = true;
                txtNroCupo.Enabled = false;
            }
            else
            {
                txtPlaca.Enabled = false;
                txtNroCupo.Enabled = false;
            }
        }

        private void txtNroCupo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones fun = WS.Funciones();
            fun.esNumero(e);
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                busquedaCupos();
            }
        }

        private void txtPlaca_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones fun = new Funciones();
            fun.esAlfanumerico(e);
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                busquedaCupos();
            }
        }

        private void rdBuscarNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones myFun = new Funciones();
            myFun.lanzarTapConEnter(e);
        }

        private void rdPlaca_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones myFun = new Funciones();
            myFun.lanzarTapConEnter(e);
        }

        private void cmbTipoVehiculo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones myFun = new Funciones();
            myFun.lanzarTapConEnter(e);
        }

        private void chkHabilitarBuscarPlaca_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHabilitarBuscarPlaca.Checked)
            {
                if (editable)
                {
                    funciones.mostrarMensaje("Edite el cupo buscando la información del nuevo vehículo a asociar", "I");

                    btnbuscarvehiculo.Enabled = true;
                    placavehiculo.ReadOnly = false;
                }
            }
            else 
            {
                btnbuscarvehiculo.Enabled = false;
                placavehiculo.ReadOnly = true;
            }
        }

        private void placavehiculo_KeyPress(object sender, KeyPressEventArgs e)
        {
            btnSave.Enabled = false;
        }
    }
}
