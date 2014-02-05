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
using LibreriasSintrat.ServiciosEmpresas;
using LibreriasSintrat.ServiciosPropietarios;
using LibreriasSintrat.ServiciosCuposTrans;
using LibreriasSintrat.ServiciosVehiculos;
using LibreriasSintrat.ServiciosViewVehiculo;
using LibreriasSintrat.ServiciosMedidasCautelares;
using LibreriasSintrat.ServiciosPersonas;
using LibreriasSintrat.ServiciosAccesorias;
using LibreriasSintrat.utilidades;
using TransitoPrincipal;
using LibreriasSintrat.ServiciosLogs;
using LibreriasSintrat.ServiciosUsuarios;

using LibreriasSintrat.utilidades;

namespace TransportePublico.servicios.cupos
{
    public partial class gestioncupos : Form
    {
        ServiciosCuposTransService clienteCuposTrans;
        ServiciosVehiculosService clienteVehiculos;
        ServiciosViewVehiculoService clienteViewVehiculos;
        ServiciosMedidasCautelaresService clienteCautelares;
        ServiciosPropietariosService clientePropietarios;
        ServiciosPersonasService clientePersonas;
        ServiciosAccesoriasService clienteAccesorias;
        ServiciosEmpresasService clienteEmpresas;
        empresasdeServicioTrans newempresa;
        ServiciosLogsService serviciosLogs;
        usuarios usuarioSistema;

        Object[] listaPropietarios;

        vehiculo elvehi = new vehiculo();
        int bandera = 0;

        bool vehiculoAsociado = false;
        
        //Datos propietario de Vehiculo
        int numpropietario = 0;
        int tipoProp = 0;//idtipoPropietario
        int idp = 0; //idpropietario

        public gestioncupos(usuarios user)
        {
            InitializeComponent();
            usuarioSistema = user;
            serviciosLogs = WS.ServiciosLogsService();
        }

        private void gestioncupos_Load(object sender, EventArgs e)
        {
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
            tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;;
            serviciosLogs.crearRegistroLog(tmpLog);


            if (listat != null && listat.Length > 0)
            {
                tipovehiculo.DataSource = null;
                tipovehiculo.DisplayMember = "NOMBRE";
                tipovehiculo.ValueMember = "ID";
                funciones.llenarCombo(tipovehiculo, listat);

                // new
                //if (tipovehiculo.SelectedIndex > -1)
                //{
                //    verificarCupos();
                //}

                tipovehiculo.SelectedIndex = -1;
            }

            contenedorvehiculo.Enabled = false;
            contenedorpropietarios.Enabled = false;
            btnSave.Enabled = false;
            btnprimero.Enabled = false;
            btnanterior.Enabled = false;
            btnsiguiente.Enabled = false;
            btnultimo.Enabled = false;
            //bandera = 0;
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

                //new
                //if (numerocupo.Items.Count > 0)
                //{
                    numerocupo.DataSource = null;
                    numerocupo.ValueMember = "IDDETALLERANGO";
                    numerocupo.DisplayMember = "NROCUPO";
                    verificarCupos();
                //}
                //new
                //tipovehiculo.SelectedIndex = -1;
                //tipovehiculo.SelectedIndex = 0;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tipovehiculo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (tipovehiculo.SelectedIndex > -1 && bandera>1)
            {
                verificarCupos();
                bandera = 2;
            }
            else
                bandera++;
        }

        private void verificarCupos()
        {
            clienteCuposTrans = WS.ServiciosCuposTransService();
            detalleRangoCupoTrans cuposdisp = new detalleRangoCupoTrans();
            Funciones funciones = WS.Funciones();

            Object[] mysCupos;
            mysCupos = null;

            if (newempresa != null)
            {
                if (tipovehiculo.SelectedIndex > -1)
                {
                    String cupsdisp = "";

                    rangoCuposVehiculoPublicoTrans rangocuposvehi = new rangoCuposVehiculoPublicoTrans();
                    rangocuposvehi.IDEMPRESATRANSP = newempresa.ID_EMPSERVICIO;
                    rangocuposvehi.IDTIPOVEHICULO = Int32.Parse(tipovehiculo.SelectedValue.ToString());
                    //T_RANGOCUPOSVEHPUBLICO

                    logs tmpLog = new logs();
                    tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                    tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
                    tmpLog.OBJETO = "T_RANGOCUPOSVEHPUBLICO";
                    tmpLog.MODULO = "TPUBLICO";
                    tmpLog.TIPO_TRANSACCION = "SELECT";
                    TimeSpan TS;
                    DateTime dt1 = DateTime.Now;

                    string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(rangocuposvehi.GetType(), new object[] { rangocuposvehi });
                    tmpLog.ESTADO_ANTERIOR = objetoAnalizado;

                    Object[] listarangocupos = clienteCuposTrans.getSRangoCuposVehiculo(rangocuposvehi);
                    Object[] tmp;

                    DateTime dt2 = DateTime.Now;
                    TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
                    tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;
                    serviciosLogs.crearRegistroLog(tmpLog);

                    if (listarangocupos != null && listarangocupos.Length >= 0)
                    {
                        rangoCuposVehiculoPublicoTrans rang;

                        for (int f = 0; f < listarangocupos.Length; f++)
                        {
                            rang = (rangoCuposVehiculoPublicoTrans)listarangocupos[f];
                            cuposdisp.ASIGNADO = "F";
                            cuposdisp.IDRANGOCUPO = rang.ID_RANGOCUPO;

                            if (mysCupos == null)
                            {
                                logs tmpLog1 = new logs();
                                tmpLog1.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                                tmpLog1.ID_USUARIO = usuarioSistema.ID_USUARIO;
                                tmpLog1.OBJETO = "T_INVENTARIOCUPOS";
                                tmpLog1.MODULO = "TPUBLICO";
                                tmpLog1.TIPO_TRANSACCION = "SELECT";
                                TimeSpan TS1;
                                DateTime dt11 = DateTime.Now;

                                string objetoAnalizado1 = AnalizadorDeObjetos.analizarObjeto(cuposdisp.GetType(), new object[] { cuposdisp });
                                tmpLog1.ESTADO_ANTERIOR = objetoAnalizado1;

                                mysCupos = (Object[])clienteCuposTrans.getSInventarioCuposEmpresa(cuposdisp);

                                DateTime dt21 = DateTime.Now;
                                TS1 = new TimeSpan(dt21.Ticks - dt11.Ticks);
                                tmpLog1.TIEMPO_EJECUCION = TS1.Milliseconds;
                                serviciosLogs.crearRegistroLog(tmpLog1);

                            }
                            else
                            {

                                logs tmpLog1 = new logs();
                                tmpLog1.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                                tmpLog1.ID_USUARIO = usuarioSistema.ID_USUARIO;
                                tmpLog1.OBJETO = "T_INVENTARIOCUPOS";
                                tmpLog1.MODULO = "TPUBLICO";
                                tmpLog1.TIPO_TRANSACCION = "SELECT";
                                TimeSpan TS1;
                                DateTime dt11 = DateTime.Now;

                                tmp = (Object[])clienteCuposTrans.getSInventarioCuposEmpresa(cuposdisp);

                                DateTime dt21 = DateTime.Now;
                                TS1 = new TimeSpan(dt21.Ticks - dt11.Ticks);
                                tmpLog1.TIEMPO_EJECUCION = TS1.Milliseconds;
                                serviciosLogs.crearRegistroLog(tmpLog1);

                                mysCupos = funciones.unirArrayObject(mysCupos, tmp);
                            }

                            /*Object[] listadisp = (Object[])clienteCuposTrans.getSRangoCuposVehiculo(rang);
                            if (listadisp != null && listadisp.Length >= 0)
                            {
                                rangoCuposVehiculoPublicoTrans elrango = new rangoCuposVehiculoPublicoTrans();
                                elrango = (rangoCuposVehiculoPublicoTrans)listadisp[0];
                                if (cupsdisp == "")
                                {
                                    cupsdisp = elrango.CUPOSASIGNADOS;
                                }
                                else
                                {
                                    cupsdisp = cupsdisp + "," + elrango.CUPOSASIGNADOS;
                                }
                            }*/
                        }

                        if (mysCupos!=null && mysCupos.Length > 0)
                        {
                            numerocupo.Enabled = true;
                            btnSave.Enabled = true;
                            btnBuscarCupo.Enabled = true;
                        }
                        else
                        {
                            numerocupo.Enabled = false;
                            btnSave.Enabled = false;
                            btnBuscarCupo.Enabled = false;
                            MessageBox.Show("No existen cupos disponibles para este tipo de vehículo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //limpiarCampos();
                        }
                    }
                    
                    //MessageBox.Show(cupsdisp);
                    /*
                    if (cupsdisp != "")
                    {
                        numerocupo.DataSource = null;
                        numerocupo.Enabled = true;
                        btnSave.Enabled = true;
                        ArrayList listadecupos = funciones.getRow(cupsdisp, ',');
                        if (listadecupos.Count >= 0)
                        {
                            for (int w = 0; w < listadecupos.Count; w++)
                            {
                                numerocupo.Items.Add(listadecupos[w]);
                            }
                        }
                        else
                        {
                            contenedorvehiculo.Enabled = false;
                            contenedorpropietarios.Enabled = false;
                            numerocupo.Enabled = false;
                            btnSave.Enabled = false;
                            numerocupo.Items.Clear();
                            MessageBox.Show("No existen cupos disponibles para este tipo de vehículo","Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            limpiarCampos();
                        }
                    }*/
                    else
                    {
                        numerocupo.Enabled = false;
                        btnSave.Enabled = false;
                        btnBuscarCupo.Enabled = false;
                        MessageBox.Show("No existen cupos disponibles para este tipo de vehículo","Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        //limpiarCampos();
                    }
                }
                //new
                funciones.llenarCombo(numerocupo, mysCupos);
            }
            else
            {
                buscarEmpresa();
            }
            //new
            //funciones.llenarCombo(numerocupo, mysCupos);
        }
        
        private void btnbuscarvehiculo_Click(object sender, EventArgs e)
        {
            if (placavehiculo.Text == "")
            {
                MessageBox.Show("Debe ingresar el numero de Placa del Vehiculo","Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
                placavehiculo.Focus();
                limpiarCampos();
            }
            else
            {
                buscarPendientes();
            }
            
        }

        private void buscarPendientes()
        {
            clienteVehiculos = WS.ServiciosVehiculosService();
            clienteCautelares = WS.ServiciosMedidasCautelaresService();
            cuposTaxisTrans cupoVehiculo = new cuposTaxisTrans();
            ServiciosCuposTransService wsCupos = WS.ServiciosCuposTransService();

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

            string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(vehicul.GetType(), new object[] { vehicul });
            tmpLog.ESTADO_ANTERIOR = objetoAnalizado;

            elvehi = clienteVehiculos.getVehiculo(vehicul);

            DateTime dt2 = DateTime.Now;
            TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
            tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;
            serviciosLogs.crearRegistroLog(tmpLog);

            
            pendiente.JP_V_ID = elvehi.ID_VEHICULO;
            pendiente.JP_ACTIVO = 1;
            cupoVehiculo.TT_ID_VEHICULO = elvehi.ID_VEHICULO;

            logs tmpLog1 = new logs();
            tmpLog1.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
            tmpLog1.ID_USUARIO = usuarioSistema.ID_USUARIO;
            tmpLog1.OBJETO = "J_PENDIENTE";
            tmpLog1.MODULO = "TPUBLICO";
            tmpLog1.TIPO_TRANSACCION = "SELECT";
            TimeSpan TS1;
            DateTime dt11 = DateTime.Now;

            string objetoAnalizado1 = AnalizadorDeObjetos.analizarObjeto(pendiente.GetType(), new object[] { pendiente });
            tmpLog1.ESTADO_ANTERIOR = objetoAnalizado1;

            Object[]listapendientes = clienteCautelares.ListarMedidasCautelares(pendiente);

            DateTime dt21 = DateTime.Now;
            TS1 = new TimeSpan(dt2.Ticks - dt1.Ticks);
            tmpLog1.TIEMPO_EJECUCION = TS1.Milliseconds;
            serviciosLogs.crearRegistroLog(tmpLog1);

            logs tmpLog2 = new logs();
            tmpLog2.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
            tmpLog2.ID_USUARIO = usuarioSistema.ID_USUARIO;
            tmpLog2.OBJETO = "T_CUPOSTAXIS";
            tmpLog2.MODULO = "TPUBLICO";
            tmpLog2.TIPO_TRANSACCION = "SELECT";
            TimeSpan TS2;
            DateTime dt12 = DateTime.Now;

            string objetoAnalizado2 = AnalizadorDeObjetos.analizarObjeto(cupoVehiculo.GetType(), new object[] { cupoVehiculo });
            tmpLog.ESTADO_ANTERIOR = objetoAnalizado;

            object []listaCuposActivos = wsCupos.getSCuposAsignados(cupoVehiculo);

            DateTime dt22 = DateTime.Now;
            TS2 = new TimeSpan(dt22.Ticks - dt12.Ticks);
            tmpLog2.TIEMPO_EJECUCION = TS2.Milliseconds;
            serviciosLogs.crearRegistroLog(tmpLog2);

            if (listapendientes != null && listapendientes.Length >= 0 )
            {
                MessageBox.Show("El vehiculo tiene Pendiente Judiciales Activos","Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Warning);

                limpiarCampos();              
            }
            else
            {
                if (listaCuposActivos != null && listaCuposActivos.Count() > 0)
                {
                    MessageBox.Show("El vehículo ya tiene un cupo activo asignado.");

                    limpiarCampos();
                }
                else
                {
                    buscarVehiculo();
                }
            }
        }

        private void buscarVehiculo()
        {
            Funciones funciones = new Funciones();
            
            clienteViewVehiculos = WS.ServiciosViewVehiculoService();
            viewVehiculo vehiculobusca = new viewVehiculo();
            viewVehiculo encontrado;
            vehiculobusca.PLACA = placavehiculo.Text;
            vehiculobusca.SERVICIOVEH = "PUBLICO";

            clienteCuposTrans = WS.ServiciosCuposTransService();
            tipoVehiculoTrans eltipo = new tipoVehiculoTrans();
            eltipo.ID = Int32.Parse(tipovehiculo.SelectedValue.ToString());
            tipoVehiculoTrans tipodevehiculo = new tipoVehiculoTrans();

            logs tmpLog = new logs();
            tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
            tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
            tmpLog.OBJETO = "TIPOVEHICULO";
            tmpLog.MODULO = "TPUBLICO";
            tmpLog.TIPO_TRANSACCION = "SELECT";
            TimeSpan TS;
            DateTime dt1 = DateTime.Now;

            string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(eltipo.GetType(), new object[] { eltipo });
            tmpLog.ESTADO_ANTERIOR = objetoAnalizado;

            tipodevehiculo = clienteCuposTrans.getTipoVehiculoTransPorId(eltipo);
            
            if (tipodevehiculo.NOMBRE == "TAXI")
            {
                vehiculobusca.CLASEVEH = "AUTOMOVIL";
            }
            else
            {
                vehiculobusca.CLASEVEH = tipodevehiculo.NOMBRE;
            }

            logs tmpLog1 = new logs();
            tmpLog1.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
            tmpLog1.ID_USUARIO = usuarioSistema.ID_USUARIO;
            tmpLog1.OBJETO = "TIPOVEHICULO";
            tmpLog1.MODULO = "TPUBLICO";
            tmpLog1.TIPO_TRANSACCION = "SELECT";
            TimeSpan TS1;
            DateTime dt11 = DateTime.Now;

            string objetoAnalizado1 = AnalizadorDeObjetos.analizarObjeto(vehiculobusca.GetType(), new object[] { vehiculobusca });
            tmpLog1.ESTADO_ANTERIOR = objetoAnalizado1;

            encontrado = clienteViewVehiculos.consultarInformacionVehiculoPorPlaca(vehiculobusca);

            DateTime dt21 = DateTime.Now;
            TS1 = new TimeSpan(dt21.Ticks - dt11.Ticks);
            tmpLog1.TIEMPO_EJECUCION = TS1.Milliseconds;
            serviciosLogs.crearRegistroLog(tmpLog1);
            
            //Object[] listavehi = clienteViewVehiculos.getSViewVehiculo(vehiculobusca);

            //if (listavehi != null && listavehi.Length>=0)
            if(encontrado != null && encontrado.IDVEHICULO > 0)
            {                              
                Object[] encontrados;
                cuposTaxisTrans myCupTaxis = new cuposTaxisTrans();

                myCupTaxis.TT_ID_VEHICULO = encontrado.IDVEHICULO;

                logs tmpLog2 = new logs();
                tmpLog2.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                tmpLog2.ID_USUARIO = usuarioSistema.ID_USUARIO;
                tmpLog2.OBJETO = "TIPOVEHICULO";
                tmpLog2.MODULO = "TPUBLICO";
                tmpLog2.TIPO_TRANSACCION = "SELECT";
                TimeSpan TS2;
                DateTime dt12 = DateTime.Now;

                string objetoAnalizado2 = AnalizadorDeObjetos.analizarObjeto(myCupTaxis.GetType(), new object[] { myCupTaxis});
                tmpLog2.ESTADO_ANTERIOR = objetoAnalizado2;

                encontrados=(Object[])clienteCuposTrans.getSCupos(myCupTaxis);

                DateTime dt22 = DateTime.Now;
                TS2 = new TimeSpan(dt22.Ticks - dt12.Ticks);
                tmpLog2.TIEMPO_EJECUCION = TS2.Milliseconds;
                serviciosLogs.crearRegistroLog(tmpLog2);

                if (encontrados != null && encontrados.Length > 0)
                {
                    MessageBox.Show("El vehículo de placas: " + placavehiculo.Text + " ya tiene asignado un cupo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    limpiarCampos();
                }
                else
                {
                    vehiculoAsociado = true;
                    
                    //encontrado = (viewVehiculo)listavehi[0];
                    marcavehiculo.Text = encontrado.MARCAVEH;
                    lineavehiculo.Text = encontrado.LINEAVEH;
                    clasevehiculo.Text = encontrado.CLASEVEH;
                    numerochasis.Text = encontrado.NUMEROCHASIS;
                    tipocarroseria.Text = encontrado.TIPOCARROCERIA;
                    numeromotor.Text = encontrado.NUMEROMOTOR;
                    buscarPropietarios();
                }
            }
            else
            {
                //MessageBox.Show("No se encontró ningún vehículo de placa: " + placavehiculo.Text + ", que pertenezca al tipo de vehículo: " + tipodevehiculo.NOMBRE,"Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
                funciones.mostrarMensaje("No se encontró ningún Vehículo de placa: " + placavehiculo.Text + ", que pertenezca al tipo de vehículo: " + tipodevehiculo.NOMBRE + " " +
                                        "o el Vehículo no es de servicio Público", "I");
                limpiarCampos();
            }
        }

        private void buscarPropietarios()
        {
            clientePropietarios = WS.ServiciosPropietariosService();
            propietarioDeVehiculo propietarioAsociado = new propietarioDeVehiculo();

            propietarioAsociado.ID_VEHICULO = elvehi.ID_VEHICULO;
            propietarioAsociado.PROPIETARIOACTUAL = "T";

            logs tmpLog = new logs();
            tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
            tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
            tmpLog.OBJETO = "PROPIETARIODEVEHICULO";
            tmpLog.MODULO = "TPUBLICO";
            tmpLog.TIPO_TRANSACCION = "SELECT";
            TimeSpan TS;
            DateTime dt1 = DateTime.Now;

            string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(propietarioAsociado.GetType(), new object[] { propietarioAsociado });
            tmpLog.ESTADO_ANTERIOR = objetoAnalizado;

            listaPropietarios = (Object[])clientePropietarios.getPropietariosDeVehiculos(propietarioAsociado);

            DateTime dt2 = DateTime.Now;
            TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
            tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;
            serviciosLogs.crearRegistroLog(tmpLog);

            if (listaPropietarios != null && listaPropietarios.Length > 0)
            {
                btnSave.Enabled = true;

                if (listaPropietarios.Length > 0)
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

                cargarPropietario(listaPropietarios,0);
            }
            else
            {
                limpiarCampos();
                btnSave.Enabled = false;
                MessageBox.Show("No puede continuar con el proceso, puesto que no se encontraron propietarios para este vehículo","Alto",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                this.Close();
            }
        }

        private void cargarPropietario(Object[] listadopropietarios,int npropietario)
        {
            propietarioDeVehiculo elpropietario = new propietarioDeVehiculo();
            elpropietario = (propietarioDeVehiculo)listadopropietarios[npropietario];

            if (elpropietario.EMPPER != "" && elpropietario.EMPPER == "PER")
            {
                tipoProp = 1;
                idp = elpropietario.ID_PROPIETARIO;
                cargarPersona(elpropietario.ID_PROPIETARIO);
                contenedorpersona.Visible = true;
                contenedorempresa.Visible = false;
            }
            else if (elpropietario.EMPPER != "" && elpropietario.EMPPER == "EMP")
            {
                tipoProp = 2;
                idp = elpropietario.ID_PROPIETARIO;
                cargarEmpresa(elpropietario.ID_PROPIETARIO);
                contenedorpersona.Visible = false;
                contenedorempresa.Visible = true;
            }
        }

        private void cargarPersona(int idperson)
        {
            clienteAccesorias = WS.ServiciosAccesoriasService();
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

            clientePersonas = WS.ServiciosPersonasService();
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

            string objetoAnalizado1 = AnalizadorDeObjetos.analizarObjeto(person.GetType(), new object[] { person });
            tmpLog1.ESTADO_ANTERIOR = objetoAnalizado1;

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

                logs tmpLog3 = new logs();
                tmpLog3.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                tmpLog3.ID_USUARIO = usuarioSistema.ID_USUARIO;
                tmpLog3.OBJETO = "CIUDAD";
                tmpLog3.MODULO = "TPUBLICO";
                tmpLog3.TIPO_TRANSACCION = "SELECT";
                TimeSpan TS3;
                DateTime dt13 = DateTime.Now;

                string objetoAnalizado3 = AnalizadorDeObjetos.analizarObjeto(ciuda.GetType(), new object[] { ciuda});
                tmpLog3.ESTADO_ANTERIOR = objetoAnalizado3;

                laciudad = clienteAccesorias.getCiudadporID(ciuda);

                DateTime dt23 = DateTime.Now;
                TS3 = new TimeSpan(dt23.Ticks - dt13.Ticks);
                tmpLog3.TIEMPO_EJECUCION = TS3.Milliseconds;
                serviciosLogs.crearRegistroLog(tmpLog3);

                if (laciudad!=null)
                {
                    codigociudad.Text = laciudad.CODCIUDAD;
                    nombreciudad.Text = laciudad.NOMBRE;
                }
            }
        }

        private void cargarEmpresa(int idempres)
        {
            clienteEmpresas = WS.ServiciosEmpresasService();
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

            string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(empres.GetType(), new object[] { empres});
            tmpLog.ESTADO_ANTERIOR = objetoAnalizado;


            Object[] lempres = (Object[])clienteEmpresas.getEmpresa(empres);

            DateTime dt2 = DateTime.Now;
            TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
            tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;
            serviciosLogs.crearRegistroLog(tmpLog);

            if (lempres != null && lempres.Length>=0)
            {
                laempresa=(empresa)lempres[0];
                nit.Text = laempresa.NIT;
                nombreempresa.Text = laempresa.RAZONSOCIAL;
            }
        }

        private void btnprimero_Click(object sender, EventArgs e)
        {
            cargarPropietario(listaPropietarios, 0);
        }

        private void btnultimo_Click(object sender, EventArgs e)
        {
            int fin = listaPropietarios.Length - 1;
            cargarPropietario(listaPropietarios, fin);
        }

        private void btnsiguiente_Click(object sender, EventArgs e)
        {
            if (numpropietario < listaPropietarios.Length-1)
            {
                numpropietario = numpropietario + 1;
                cargarPropietario(listaPropietarios, numpropietario);
            }
        }

        private void btnanterior_Click(object sender, EventArgs e)
        {
            if (numpropietario > 0)
            {
                numpropietario = numpropietario - 1;
                cargarPropietario(listaPropietarios, numpropietario);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Funciones funciones = new Funciones();

            if (vehiculoAsociado)
            {
                limpiarCampos();
                verificarCupos();
                guardarCupoT();                
            }
            else 
            {
                funciones.mostrarMensaje("Debe estar asociado un Vehículo al Registro del cupo", "W");
                limpiarCampos();
            }           
        }

        private void limpiarCampos()
        {
            btnprimero.Enabled = false;
            btnanterior.Enabled = false;
            btnsiguiente.Enabled = false;
            btnultimo.Enabled = false;
            listaPropietarios = null;
            placavehiculo.Text = "";
            marcavehiculo.Text = "";
            lineavehiculo.Text = "";
            clasevehiculo.Text = "";
            numerochasis.Text = "";
            tipocarroseria.Text = "";
            numeromotor.Text = "";

            if (tipoProp == 1)
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
            else if (tipoProp == 2)
            {
                nit.Text = "";
                nombreempresa.Text = "";
            }

            vehiculoAsociado = false;
        }

        private void guardarCupoT()
        {
            clienteCuposTrans = WS.ServiciosCuposTransService();
            cuposTaxisTrans cupotaxi = new cuposTaxisTrans();
            cupotaxi.TT_ID_EMPSERVICIO = newempresa.ID_EMPSERVICIO;

            if (tipoProp == 1)
            {
                cupotaxi.TT_ID_PERSONA = idp;
                cupotaxi.TT_IDEMPRESA = 0;
            }
            else if(tipoProp == 2)
            {
                cupotaxi.TT_IDEMPRESA = idp;
                cupotaxi.TT_ID_PERSONA = 0;
            }

            cupotaxi.TT_ID_VEHICULO = elvehi.ID_VEHICULO;
            cupotaxi.TT_IDTARJETA = 0;
            cupotaxi.TT_IDUSUARIOREG = 215;

            if (numerocupo.SelectedIndex >= 0)
            {
                cupotaxi.TT_NUMCUPO = Int32.Parse(numerocupo.Text);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un número de cupo","Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
                numerocupo.Focus();
            }

            cupotaxi. TT_TIPOVEH = tipovehiculo.SelectedValue.ToString();
            cupotaxi.t_IDDETALLERANGOCUPO = cupotaxi.t_IDDETALLERANGOCUPO;

            logs tmpLog = new logs();
            tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
            tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
            tmpLog.OBJETO = "T_CUPOSTAXIS";
            tmpLog.MODULO = "TPUBLICO";
            tmpLog.TIPO_TRANSACCION = "INSERT";
            TimeSpan TS;
            DateTime dt1 = DateTime.Now;

            string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(cupotaxi.GetType(), new object[] { cupotaxi});
            tmpLog.ESTADO_ANTERIOR = objetoAnalizado;

            int idnuevocupo = clienteCuposTrans.crearCuposTaxis(cupotaxi);

            DateTime dt2 = DateTime.Now;
            TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
            tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;
            serviciosLogs.crearRegistroLog(tmpLog);

            if (idnuevocupo > 0)
            {
                Funciones funciones = WS.Funciones();

                historicoCupoTrans historico = new historicoCupoTrans();
                historico.IDCUPO = idnuevocupo;
                historico.IDEMPRESASERVICIO = newempresa.ID_EMPSERVICIO;

                if (tipoProp == 1)
                {
                    historico.IDPERSONA = idp;
                    historico.TT_IDEMPRESA = 0;
                }
                else if (tipoProp == 2)
                {
                    historico.IDPERSONA = 0;
                    historico.TT_IDEMPRESA = idp;
                }

                historico.IDRESOLUCION = 0;
                historico.IDUSUARIO = 215;
                historico.IDVEHICULO = elvehi.ID_VEHICULO;
                historico.DESCRIPCION = "Asignacion de Cupo";

                //
                logs tmpLog2 = new logs();
                tmpLog2.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                tmpLog2.ID_USUARIO = usuarioSistema.ID_USUARIO;
                tmpLog2.OBJETO = "TT_HISTORICOCUPO";
                tmpLog2.MODULO = "TPUBLICO";
                tmpLog2.TIPO_TRANSACCION = "INSERT";
                TimeSpan TS2;
                DateTime dt12 = DateTime.Now;

                string objetoAnalizado2 = AnalizadorDeObjetos.analizarObjeto(historico.GetType(), new object[] { historico});
                tmpLog2.ESTADO_ANTERIOR = objetoAnalizado2;

                Boolean inshisto = clienteCuposTrans.crearHistoricoCuposTaxis(historico);

                DateTime dt22 = DateTime.Now;
                TS2 = new TimeSpan(dt22.Ticks - dt12.Ticks);
                tmpLog2.TIEMPO_EJECUCION = TS2.Milliseconds;
                serviciosLogs.crearRegistroLog(tmpLog2);

                rangoCuposVehiculoPublicoTrans rangoed = new rangoCuposVehiculoPublicoTrans();
                rangoed.IDEMPRESATRANSP = newempresa.ID_EMPSERVICIO;
                rangoed.IDTIPOVEHICULO = Int32.Parse(tipovehiculo.SelectedValue.ToString());

                logs tmpLog3 = new logs();
                tmpLog3.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                tmpLog3.ID_USUARIO = usuarioSistema.ID_USUARIO;
                tmpLog3.OBJETO = "T_RANGOCUPOSVEHPUBLICO";
                tmpLog3.MODULO = "TPUBLICO";
                tmpLog3.TIPO_TRANSACCION = "SELECT";
                TimeSpan TS3;
                DateTime dt13 = DateTime.Now;

                string objetoAnalizado3 = AnalizadorDeObjetos.analizarObjeto(rangoed.GetType(), new object[] { rangoed });
                tmpLog3.ESTADO_ANTERIOR = objetoAnalizado3;
                
                Object[] listrang = clienteCuposTrans.getSRangoCuposVehiculo(rangoed);

                DateTime dt23 = DateTime.Now;
                TS3 = new TimeSpan(dt23.Ticks - dt13.Ticks);
                tmpLog3.TIEMPO_EJECUCION = TS3.Milliseconds;
                serviciosLogs.crearRegistroLog(tmpLog3);

                if (listrang!=null)
                {
                    for (int u = 0; u < listrang.Count();u++ )
                    {
                        rangoCuposVehiculoPublicoTrans mirango = new rangoCuposVehiculoPublicoTrans();
                        mirango=(rangoCuposVehiculoPublicoTrans)listrang[u];

                        if(mirango.CUPOSASIGNADOS!="")
                        {
                            detalleRangoCupoTrans eldeta = new detalleRangoCupoTrans();
                            detalleRangoCupoTrans detaenc = new detalleRangoCupoTrans();

                            ArrayList listaasign = new ArrayList();
                            if (mirango.CUPOSASIGNADOS != null) 
                                listaasign = funciones.getRow(mirango.CUPOSASIGNADOS.ToString(), ',');

                            for (int z = 0; z < listaasign.Count;z++ )
                            {
                                if(Int32.Parse(listaasign[z].ToString()) == Int32.Parse(numerocupo.Text))
                                {
                                    detaenc.ASIGNADO = "F";
                                    detaenc.IDRANGOCUPO = mirango.ID_RANGOCUPO;
                                    detaenc.NROCUPO = listaasign[z].ToString();

                                    logs tmpLog4 = new logs();
                                    tmpLog4.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                                    tmpLog4.ID_USUARIO = usuarioSistema.ID_USUARIO;
                                    tmpLog4.OBJETO = "TIPOVEHICULO";
                                    tmpLog4.MODULO = "TPUBLICO";
                                    tmpLog4.TIPO_TRANSACCION = "SELECT";
                                    TimeSpan TS4;
                                    DateTime dt14 = DateTime.Now;

                                    string objetoAnalizado4 = AnalizadorDeObjetos.analizarObjeto(detaenc.GetType(), new object[] { detaenc });
                                    tmpLog4.ESTADO_ANTERIOR = objetoAnalizado4;

                                    Object[] listadetll = (Object[])clienteCuposTrans.getSInventarioCuposEmpresa(detaenc);

                                    DateTime dt24 = DateTime.Now;
                                    TS4 = new TimeSpan(dt24.Ticks - dt14.Ticks);
                                    tmpLog4.TIEMPO_EJECUCION = TS4.Milliseconds;
                                    serviciosLogs.crearRegistroLog(tmpLog4);

                                    if (listadetll!=null)
                                    {
                                        eldeta=(detalleRangoCupoTrans)listadetll[0];
                                        
                                        //
                                        logs tmpLog5 = new logs();
                                        tmpLog5.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                                        tmpLog5.ID_USUARIO = usuarioSistema.ID_USUARIO;
                                        tmpLog5.OBJETO = "T_DETALLERANGOCUPO";
                                        tmpLog5.MODULO = "TPUBLICO";
                                        tmpLog5.TIPO_TRANSACCION = "UPDATE";
                                        TimeSpan TS5;
                                        DateTime dt15 = DateTime.Now;

                                        string objetoAnalizado55 = AnalizadorDeObjetos.analizarObjeto(eldeta.GetType(), new object[] { eldeta });
                                        tmpLog5.ESTADO_ANTERIOR = objetoAnalizado55;

                                        eldeta.ASIGNADO = "T";

                                        bool upddet = clienteCuposTrans.editarDetalleRangoCupos(eldeta);

                                        string objetoAnalizado5 = AnalizadorDeObjetos.analizarObjeto(eldeta.GetType(), new object[] { eldeta });
                                        tmpLog5.ESTADO_FINAL = objetoAnalizado5;

                                        DateTime dt25 = DateTime.Now;
                                        TS5 = new TimeSpan(dt25.Ticks - dt15.Ticks);
                                        tmpLog5.TIEMPO_EJECUCION = TS5.Milliseconds;
                                        serviciosLogs.crearRegistroLog(tmpLog5);


                                        logs tmpLog6 = new logs();
                                        tmpLog6.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                                        tmpLog6.ID_USUARIO = usuarioSistema.ID_USUARIO;
                                        tmpLog6.OBJETO = "TIPOVEHICULO";
                                        tmpLog6.MODULO = "TPUBLICO";
                                        tmpLog6.TIPO_TRANSACCION = "SELECT";
                                        TimeSpan TS6;
                                        DateTime dt16 = DateTime.Now;

                                        string objetoAnalizado6 = AnalizadorDeObjetos.analizarObjeto(cupotaxi.GetType(), new object[] { cupotaxi});
                                        tmpLog6.ESTADO_ANTERIOR = objetoAnalizado6;

                                        cupotaxi.t_IDDETALLERANGOCUPO = eldeta.IDDETALLERANGO;
                                        cupotaxi.TT_IDCUPOTAXI = idnuevocupo;

                                        bool edito = clienteCuposTrans.editarCuposTaxis(cupotaxi);

                                        string objetoAnalizado66 = AnalizadorDeObjetos.analizarObjeto(cupotaxi.GetType(), new object[] { cupotaxi });
                                        tmpLog6.ESTADO_FINAL = objetoAnalizado6;

                                        DateTime dt26 = DateTime.Now;
                                        TS6 = new TimeSpan(dt26.Ticks - dt16.Ticks);
                                        tmpLog6.TIEMPO_EJECUCION = TS6.Milliseconds;
                                        serviciosLogs.crearRegistroLog(tmpLog6);

                                    }                                    
                                }
                            }
                        }
                    }
                }
                
                MessageBox.Show("Registro Exitoso","Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
                btnSave.Enabled = false;
            }
            else
            {
                MessageBox.Show("Error en el Registro","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            verificarCupos();
        }

        private void numerocupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (numerocupo.SelectedIndex > -1 && numerocupo.Items.Count > 0)
            {
                contenedorvehiculo.Enabled = true;
                contenedorpropietarios.Enabled = true;
            }
            else
            {
                contenedorvehiculo.Enabled = false;
                contenedorpropietarios.Enabled = false;
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

        private void btnBuscarCupo_Click(object sender, EventArgs e)
        {
            Funciones funciones = WS.Funciones();
            detalleRangoCupoTrans cuposdisp = new detalleRangoCupoTrans();
            rangoCuposVehiculoPublicoTrans rangocuposvehi = new rangoCuposVehiculoPublicoTrans();

            if(newempresa != null && newempresa.ID_EMPSERVICIO > 0)
                rangocuposvehi.IDEMPRESATRANSP = newempresa.ID_EMPSERVICIO;
            else
                MessageBox.Show("Debe seleccionar una empresa");
            if (tipovehiculo.SelectedIndex > -1)
                rangocuposvehi.IDTIPOVEHICULO = Int32.Parse(tipovehiculo.SelectedValue.ToString());
            else
                MessageBox.Show("Debe seleccionar un tipo de vehiculo.");

            Object[] listarangocupos = clienteCuposTrans.getSRangoCuposVehiculo(rangocuposvehi);
            Object[] mysCupos = null;
            Object[] tmp;

            if (listarangocupos != null && listarangocupos.Length > 0)
            {
                rangoCuposVehiculoPublicoTrans rang;
                for (int f = 0; f < listarangocupos.Length; f++)
                {
                    rang = (rangoCuposVehiculoPublicoTrans)listarangocupos[f];
                    cuposdisp.ASIGNADO = "F";
                    cuposdisp.IDRANGOCUPO = rang.ID_RANGOCUPO;
                    if (mysCupos == null)
                        mysCupos = (Object[])clienteCuposTrans.getSInventarioCuposEmpresa(cuposdisp);
                    else
                    {
                        tmp = (Object[])clienteCuposTrans.getSInventarioCuposEmpresa(cuposdisp);
                        mysCupos = funciones.unirArrayObject(mysCupos, tmp);
                    }                    
                }                
            }

            if (mysCupos != null && mysCupos.Length > 0)
            {
                ArrayList Campos = new ArrayList();
                Campos.Add("NROCUPO = Numero Cupo");
                buscador buscador = new buscador(mysCupos, Campos, "Cupos", null);
                if (buscador.ShowDialog() == DialogResult.OK)
                {
                    detalleRangoCupoTrans newCupo = (detalleRangoCupoTrans)funciones.listToDetalleRangoCupoTrans(buscador.Seleccion);
                    numerocupo.SelectedValue = newCupo.IDDETALLERANGO;                        
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

        private void placavehiculo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones fun = new Funciones();
            fun.esAlfanumerico(e);
        }

        public object[] listapropietarios { get; set; }

        public object[] listapropietariosa { get; set; }
    }
}
