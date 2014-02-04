using System;
using TransitoPrincipal;
using LibreriasSintrat.utilidades;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibreriasSintrat.ServiciosGeneralesComp;
using LibreriasSintrat.ServiciosGenerales;
using LibreriasSintrat.ServiciosUsuarios;
using LibreriasSintrat.ServiciosComparendos;
using LibreriasSintrat.ServiciosAccesoriasComp;
using LibreriasSintrat.ServiciosCuposTrans;

using Comparendos.utilidades;
using LibreriasSintrat;

using System.Globalization;
using System.Runtime.InteropServices; //PARA PERSONALIZAR EL MENSAJE DE LOS BOTONES DEL MESSAGEBOX

namespace Comparendos.servicios.generales
{
    public partial class fGestionComparendo : Form
    {
        Boolean nuevo = false;
        Boolean existecomp;
        String encComp;
        int idComparendera;
        int idvehiculo;
        int idInfractor;
        int idComparendo;
        int idPropietario;
        int idPropietarioVeh;
        int idTestigo;
        int idTestigoVeh;
        Object[] ciudades;
        Object[] agentes;
        Object[] resBuscador;
        Object[] infractores;
        usuarios usuario;
        Log log = new Log();
        CultureInfo culturaEspaniolCol = new CultureInfo("es-CO", false);

        bool realizarValidacionNumComparendo = true;

        LibreriasSintrat.ServiciosAccesoriasComp.infraccionesComp infraccion;
        infracionComparendoComp infraccionComparendo;
        comparendoComp comparendo;
        Funciones funciones;
        ServiciosAccesoriasCompService serviciosAccesoriasComp;
        ServiciosGeneralesCompService serviciosGeneralesComp;
        ServiciosGeneralesService serviciosGenerales;
        ServiciosComparendosService serviciosComparendos;

        public fGestionComparendo(Boolean modifica, usuarios myuser, ServiciosAccesoriasCompService srv)
        {
            InitializeComponent();
            serviciosAccesoriasComp = srv;
            serviciosGeneralesComp = WS.ServiciosGeneralesCompService();
            serviciosGenerales = WS.ServiciosGeneralesService();
            serviciosComparendos = WS.ServiciosComparendosService();
            comparendo = new comparendoComp();
            infraccion = new LibreriasSintrat.ServiciosAccesoriasComp.infraccionesComp();
            funciones = new Funciones();
            infraccionComparendo = new infracionComparendoComp();
            usuario = myuser;
            ciudades = (Object[])serviciosAccesoriasComp.listarCiudadComp();
            agentes = (Object[])serviciosGeneralesComp.getAgentes(null);
            nuevo = !modifica;
            llenarCombos();
            idvehiculo = -1;
            idInfractor = -1;
            encComp = "";
            limpiarDatos();
            log = new Log();

        }


        /*
         * CÓDIGO PARA PERSONALIZAR EL TEXTO DE LOS BOTONES DEL MESSAGEBOX
         */
        [DllImport("kernel32.dll")]
        static extern uint GetCurrentThreadId();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int CallNextHookEx(int idHook, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool UnhookWindowsHookEx(int idHook);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);

        [DllImport("user32.dll")]
        private static extern bool SetDlgItemText(IntPtr hWnd, int nIDDlgItem, string lpString);

        delegate int HookProc(int nCode, IntPtr wParam, IntPtr lParam);

        static HookProc dlgHookProc;

        private const long WH_CBT = 5;
        private const long HCBT_ACTIVATE = 5;

        //private const int ID_BUT_OK = 1;
        //private const int ID_BUT_CANCEL = 2;
        //private const int ID_BUT_ABORT = 3;
        //private const int ID_BUT_RETRY = 4;
        //private const int ID_BUT_IGNORE = 5;
        private const int ID_BUT_YES = 6;
        private const int ID_BUT_NO = 7;

        //private const string BUT_OK = "Save";
        //private const string BUT_CANCEL = "Cancel";
        //private const string BUT_ABORT = "Stop";
        //private const string BUT_RETRY = "Continue";
        //private const string BUT_IGNORE = "Ignore";
        private const string BUT_YES = "Agente Urbano";
        private const string BUT_NO = "Agente Polca";

        private static int _hook = 0;

        private static int DialogHookProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode < 0)
            {
                return CallNextHookEx(_hook, nCode, wParam, lParam);
            }

            if (nCode == HCBT_ACTIVATE)
            {
                //SetDlgItemText(wParam, ID_BUT_OK, BUT_OK);
                //SetDlgItemText(wParam, ID_BUT_CANCEL, BUT_CANCEL);
                //SetDlgItemText(wParam, ID_BUT_ABORT, BUT_ABORT);
                //SetDlgItemText(wParam, ID_BUT_RETRY, BUT_RETRY);
                //SetDlgItemText(wParam, ID_BUT_IGNORE, BUT_IGNORE);
                SetDlgItemText(wParam, ID_BUT_YES, BUT_YES);
                SetDlgItemText(wParam, ID_BUT_NO, BUT_NO);
            }

            return CallNextHookEx(_hook, nCode, wParam, lParam);
        }
        /*
         * FIN CÓDIGO PERSONALIZACIÓN MESSAGEBOX
         */


        private void evaluarPolca()
        {
            if (nuevo)
                //PARA PERSONALIZAR EL MENSAJE DE LOS BOTONES DEL MESSAGEBOX
                dlgHookProc = new HookProc(DialogHookProc);
            _hook = SetWindowsHookEx((int)WH_CBT, dlgHookProc, (IntPtr)0, (int)GetCurrentThreadId());

            //if (MessageBox.Show("Es Comparendo Urbano?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            if (MessageBox.Show("¿Comparendo atendido por?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                encComp = serviciosGeneralesComp.getPrefijoPol();
                txtPolca.Text = "S";
                cmbAgente.Enabled = true;
            }
            else
            {
                encComp = serviciosGeneralesComp.getNITTransito();
                txtPolca.Text = "N";
                cmbAgente.Enabled = false;
            }

            txtNroComparendo.Focus();

            //PARA DESACTIVAR LA PERSONALIZACIÓN DE LOS BOTONES DEL MESSAGEBOX    
            UnhookWindowsHookEx(_hook);

        }

        private void fGestionComparendo_Load(object sender, EventArgs e)
        {
            evaluarPolca();
            if (nuevo)
            {
                cmbTipoInfractor.SelectedValue = 1;
                transitoComp otc = new transitoComp();
                btnBuscarComparendo.Enabled = false;
                //object[] listaOrganismos = serviciosAccesorias.getOneOrganismoTransito(otc);
                //if(listaOrganismos != null && listaOrganismos.Count() > 0)
                //{
                //otc = (organismoTransito)listaOrganismos[0];
                //}
                otc = serviciosGeneralesComp.getTransitoComp(otc);
                if (otc != null && otc.ID_CIUDAD > 0)
                    cmbCiudadComp.SelectedValue = otc.ID_CIUDAD;
            }
            if (cmbInmovilizacion.Items.Count > 1)
                cmbInmovilizacion.SelectedIndex = 1;
            else if (cmbInmovilizacion.Items.Count > 0)
                cmbInmovilizacion.SelectedIndex = 0;

            if (cmbAlcoholemia.Items.Count > 1)
                cmbAlcoholemia.SelectedIndex = 1;
            else if (cmbAlcoholemia.Items.Count > 0)
                cmbAlcoholemia.SelectedIndex = 0;

            if (cmbFuga.Items.Count > 0 && cmbFuga.Items.Count > 1)
                cmbFuga.SelectedIndex = 1;
            else if (cmbFuga.Items.Count > 0)
                cmbFuga.SelectedIndex = 0;

            if (cmbAccidente.Items.Count > 1)
                cmbAccidente.SelectedIndex = 1;
            else if (cmbAccidente.Items.Count > 0)
                cmbAccidente.SelectedIndex = 0;

            if (cmbGrua.Items.Count > 1)
                cmbGrua.SelectedIndex = 1;
            else if (cmbGrua.Items.Count > 0)
                cmbGrua.SelectedIndex = 0;
        }

        private void llenarCombos()
        {
            funciones.llenarCombo(cmbCiudadComp, ciudades);
            funciones.llenarCombo(cmbTipoDocInfra, serviciosAccesoriasComp.obtenerTiposDocumento());
            funciones.llenarCombo(cmbTipoDocProp, serviciosAccesoriasComp.obtenerTiposDocumento());
            funciones.llenarCombo(cmbTipoDocTest, serviciosAccesoriasComp.obtenerTiposDocumento());
            funciones.llenarCombo(cmbAgente, agentes);
            funciones.llenarCombo(cmbTipoInfractor, serviciosAccesoriasComp.listarTipoInfractorComp());
            funciones.llenarCombo(cmbPatioInmov, serviciosAccesoriasComp.listarPatioInmovilizacion());
        }

        private String calcNroComp(String nro)
        {
            int i;
            for (i = (encComp.Length + nro.Length); i < 20; i++)
                encComp = encComp + "0";
            return encComp + nro;
        }

        private void mostrarDatosVehiculo()
        {
            vehiculosComp tmp = new vehiculosComp();

            tmp.IDVEHICULOCOMP = idvehiculo;
            tmp = serviciosGeneralesComp.getFirstVehiculoComp(tmp);

            txtPlaca.Clear();
            txtClaseVehiculo.Clear();
            txtTipoServ.Clear();
            txtEmpresa.Clear();
            txtLicVeh.Clear();
            txtRadioAcc.Clear();

            txtPlaca.Text = tmp.PLACA;
            txtClaseVehiculo.Text = serviciosAccesoriasComp.getDescClaseVehiculo(tmp.ID_CVEHICULO);
            txtTipoServ.Text = serviciosAccesoriasComp.getDescTipoServicioComp(tmp.ID_SERVICIO);

            //txtEmpresa.Text = serviciosAccesoriasComp.getDescEmpresaComp(tmp.ID_EMPRESA);
            ServiciosCuposTransService serviciosCupos = WS.ServiciosCuposTransService();
            empresasdeServicioTrans empresaServicio = new empresasdeServicioTrans();

            empresaServicio.ID_EMPSERVICIO = tmp.ID_EMPRESA;
            empresaServicio.DIGVERIF = -2; //Para no tener en cuenta en la búsq.

            object[] empresas = serviciosCupos.getEmpresaServicio(empresaServicio);
            if (empresas != null && empresas.Length > 0)
            {
                empresaServicio = (empresasdeServicioTrans)empresas[0];
                txtEmpresa.Text = empresaServicio.NOMBRE;
            }

            txtLicVeh.Text = tmp.NROLICENCIA;
            if (tmp.ID_RADIOACCION > 0)
                txtRadioAcc.Text = serviciosAccesoriasComp.getDescRadioAccionComp(tmp.ID_RADIOACCION);
        }

        private void mostrarDatosInfractor()
        {
            infractorComp tmp = new infractorComp();

            txtApellidos.Clear();
            txtNombres.Clear();
            txtDirInfrac.Clear();
            txtNroLicencia.Clear();
            txtCatLic.Clear();
            txtOrgExpideLic.Clear();

            tmp.ID_INFRACTOR = idInfractor;
            tmp = serviciosGeneralesComp.buscarInfractor(tmp);

            funciones.setCombo(cmbTipoDocInfra, tmp.ID_DOCTO);
            txtIdentInfrac.Text = tmp.NROIDENTIFICACION;
            txtApellidos.Text = tmp.APELLIDOS;
            txtNombres.Text = tmp.NOMBRES;
            txtDirInfrac.Text = tmp.DIRECCION;
            txtNroLicencia.Text = tmp.NROLICCONDUCCION;

            categoriaLicTransitoComp categoriaLic = new categoriaLicTransitoComp();
            categoriaLic.COD_CATEGORIA = tmp.CATEGLICENCIA;
            object[] listaCategorias = serviciosAccesoriasComp.getCategoriaLicTransitoComp(categoriaLic);
            if (listaCategorias != null && listaCategorias.Length > 0)
                categoriaLic = (categoriaLicTransitoComp)listaCategorias[0];

            txtCatLic.Text = categoriaLic.NUEVA_CATEGORIA;

            txtOrgExpideLic.Text = serviciosAccesoriasComp.getNombreOrganismo(tmp.ID_TRANSITO);
        }

        private void mostrarDatosPropietario()
        {
            infractorComp tmp = new infractorComp();
            tmp.ID_INFRACTOR = idPropietario;
            tmp = serviciosGeneralesComp.buscarInfractor(tmp);
            txtNombresProp.Clear();
            txtApellidosProp.Clear();

            funciones.setCombo(cmbTipoDocProp, tmp.ID_DOCTO);
            txtIdentProp.Text = tmp.NROIDENTIFICACION;
            txtNombresProp.Text = tmp.NOMBRES;
            txtApellidosProp.Text = tmp.APELLIDOS;
        }

        private void mostrarDatosTestigo()
        {
            infractorComp tmp = new infractorComp();
            tmp.ID_INFRACTOR = idTestigo;
            tmp = serviciosGeneralesComp.buscarInfractor(tmp);
            txtNombreTest.Clear();
            txtApellidoTest.Clear();
            txtDireccionTest.Clear();
            txtTelefonoTest.Clear();

            funciones.setCombo(cmbTipoDocTest, tmp.ID_DOCTO);
            txtIdentTest.Text = tmp.NROIDENTIFICACION;
            txtNombreTest.Text = tmp.NOMBRES;
            txtApellidoTest.Text = tmp.APELLIDOS;
            txtDireccionTest.Text = tmp.DIRECCION;
            txtTelefonoTest.Text = tmp.TELEFONO;
        }

        private int buscarVehiculo(String placa)
        {
            vehiculosComp tmp = new vehiculosComp();
            tmp.PLACA = placa;
            tmp = serviciosGeneralesComp.getFirstVehiculoComp(tmp);

            int idVehiculoTemp = tmp.IDVEHICULOCOMP;

            //SI EL VEHÍCULO NO EXISTE EN LA BD COMPARENDOS, BUSCARLO EN PPAL            
            if (idVehiculoTemp == -1)
            {
            //Buscarlo en Principal
            LibreriasSintrat.ServiciosVehiculos.ServiciosVehiculosService serviciosVehiculosPpal = WS.ServiciosVehiculosService();
            LibreriasSintrat.ServiciosVehiculos.vehiculo vehiculoPpal = new LibreriasSintrat.ServiciosVehiculos.vehiculo();
            vehiculoPpal.PLACA = placa;

            vehiculoPpal = serviciosVehiculosPpal.getVehiculo(vehiculoPpal);

            //SI EXISTE, HOMOLOGAR LOS DATOS E INSERTAR EL VEHÍCULO
            if (vehiculoPpal != null && vehiculoPpal.ID_VEHICULO > 0)
            {
                vehiculosComp vehiculoTemp = new vehiculosComp();

                int tipoServicio = int.Parse(vehiculoPpal.ID_SERVICIO);
                if (tipoServicio == 2) // SI EL TIPO DE SERVICIO ES PÚBLICO
                {
                    if (vehiculoPpal.ID_EMPSERVIPUBLICO != null)
                        vehiculoTemp.ID_EMPRESA = int.Parse(vehiculoPpal.ID_EMPSERVIPUBLICO);

                    //Valores quemados, cambiar (si es posible esto en el futuro)
                    //Homologar radio Acción del vehículo en Tpte Principal con el de comparendos
                    int idRuntRadioAccion = 0;
                    int.TryParse(vehiculoPpal.ID_RUNTRADIOACCION, out idRuntRadioAccion);
                    if (idRuntRadioAccion == 2)
                        vehiculoTemp.ID_RADIOACCION = 1;
                    else if (idRuntRadioAccion == 1)
                        vehiculoTemp.ID_RADIOACCION = 2;

                    //Valores quemados, cambiar (si es posible esto en el futuro)
                    //Homologar Modalidad del vehículo en Tpte Principal con la de comparendos
                    int idModalidad = 0;
                    int.TryParse(vehiculoPpal.ID_MODALIDADSERVICIO, out idModalidad);
                    switch (idModalidad)
                    {
                        case 2:
                            vehiculoTemp.ID_MODALIDADTRANSPORTE = 1;
                            break;
                        case 3:
                            vehiculoTemp.ID_MODALIDADTRANSPORTE = 2;
                            break;
                        case 4:
                            vehiculoTemp.ID_MODALIDADTRANSPORTE = 3;
                            break;
                    }

                    vehiculoTemp.TARJETAOPERACION = vehiculoPpal.TARJETAOPERACION;
                }
                else
                {
                    vehiculoTemp.ID_EMPRESA = -1;
                    vehiculoTemp.ID_RADIOACCION = -1;
                    vehiculoTemp.ID_MODALIDADTRANSPORTE = -1;
                    vehiculoTemp.TARJETAOPERACION = null;
                }

                //Este campo no tiene homologación con vehículo de principal
                vehiculoTemp.ID_TIPOTRANSPORTEPASAJERO = -1;

                if (vehiculoPpal.IDORG_EXPIDE != null)
                    vehiculoTemp.ID_ORGTRANSITODEMATRICULA = int.Parse(vehiculoPpal.IDORG_EXPIDE);

                if (vehiculoPpal.ID_SERVICIO != null)
                    vehiculoTemp.ID_SERVICIO = int.Parse(vehiculoPpal.ID_SERVICIO);

                if (vehiculoPpal.ID_CVEHICULO != null)
                    vehiculoTemp.ID_CVEHICULO = int.Parse(vehiculoPpal.ID_CVEHICULO);

                //Buscar la Licencia más reciente del Vehículo
                LibreriasSintrat.ServiciosLicenciaDeTransito.ServiciosLicenciaDeTransitoService clienteLicenciasTransito = WS.ServiciosLicenciaDeTransitoService();
                LibreriasSintrat.ServiciosLicenciaDeTransito.licenciaDeTransito tmpLicencia = new LibreriasSintrat.ServiciosLicenciaDeTransito.licenciaDeTransito();
                tmpLicencia.ID_VEHICULO = vehiculoPpal.ID_VEHICULO;
                tmpLicencia = clienteLicenciasTransito.getLicenciaDeTransito(tmpLicencia);

                if (tmpLicencia != null && tmpLicencia.GEN_IDTRANSITO > 0)
                {
                    vehiculoTemp.NROLICENCIA = tmpLicencia.ID_LICTRANSITO;
                }

                vehiculoTemp.PLACA = vehiculoPpal.PLACA;

                //ENVIAR DATOS AL SERVIDOR

                //si se le ha quitado unique en Bd, este no permite el ingreso masivo de vehiculos con la misma placa
                if (serviciosGeneralesComp.getFirstVehiculoComp(tmp) != null)
                {
                    idVehiculoTemp = serviciosGeneralesComp.crearVehiculoComp(vehiculoTemp, WS.MyUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName());
                }
                
            }
            }

            return idVehiculoTemp;
        }

        private int buscarInfractor(string tipodoc, String identificacion)
        {
            infractorComp tmp = new infractorComp();
            tmp.ID_DOCTO = int.Parse(tipodoc);
            tmp.NROIDENTIFICACION = identificacion;
            tmp = serviciosGeneralesComp.buscarInfractor(tmp);
            //return tmp.ID_INFRACTOR;

            int idInfractorTemp = tmp.ID_INFRACTOR;

            //SI NO ESTÁ EN COMPARENDOS, BUSCARLO EN PRINCIPAL
            if (idInfractorTemp == -1)
            {
                LibreriasSintrat.ServiciosPersonas.ServiciosPersonasService serviciosPersona = WS.ServiciosPersonasService();
                LibreriasSintrat.ServiciosPersonas.persona myPersona = new LibreriasSintrat.ServiciosPersonas.persona();

                documentoComp myTipoDocumento = new documentoComp();
                myTipoDocumento.ID_DOCCOMP = int.Parse(tipodoc);

                object[] documentos = serviciosAccesoriasComp.obtenerTipoDocumento(myTipoDocumento);

                if (documentos != null && documentos.Length > 0)
                {
                    myTipoDocumento = (documentoComp)documentos[0];

                    myPersona.ID_DOCTO = myTipoDocumento.ID_DOCTO;
                    myPersona.IDENTIFICACION = identificacion;

                    myPersona = serviciosPersona.getPersona(myPersona);
                    if (myPersona != null && myPersona.ID_PERSONAS > 0)
                    {
                        infractorComp infractorTemp = new infractorComp();

                        infractorTemp.ID_DOCTO = myTipoDocumento.ID_DOCCOMP;

                        //Homologar a Sexo de BDComparendos
                        if (myPersona.ID_SEXO == 1)
                            infractorTemp.ID_SEXO = 2;
                        if (myPersona.ID_SEXO == 2)
                            infractorTemp.ID_SEXO = 1;

                        infractorTemp.NROIDENTIFICACION = identificacion;
                        infractorTemp.NOMBRES = myPersona.NOMBRES;
                        infractorTemp.APELLIDOS = myPersona.APELLIDO1 + " " + myPersona.APELLIDO2;

                        infractorTemp.NROLICCONDUCCION = txtNroLicencia.Text;
                        infractorTemp.TELEFONO = myPersona.TELEFONO;
                        infractorTemp.DIRECCION = myPersona.DIRECCION;
                        infractorTemp.EDAD = "0";
                        infractorTemp.EMAIL = myPersona.EMAIL;


                        //ENVIAR DATOS AL SERVIDOR
                        if (serviciosGeneralesComp.buscarInfractor(tmp) != null)
                        {
                            idInfractorTemp = serviciosGeneralesComp.crearInfractorComp(infractorTemp, WS.MyUsuario.ID_USUARIO, funciones.obtenerDirIp(), funciones.obtenerHostName());
                        }
                    }
                }
            }

            return idInfractorTemp;
        }

        private void txtNroComparendo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    validarNumeroComparendo();
                }
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                funciones.mostrarMensaje("Error realizando la funcionalidad. " + exp.Message, "E");
            }
        }

        private void validarNumeroComparendo()
        {
            if (nuevo)
            {
                if (realizarValidacionNumComparendo && !string.IsNullOrWhiteSpace(txtNroComparendo.Text))
                {
                    if (txtNroComparendo.Text.Length < 20)
                        txtNroComparendo.Text = calcNroComp(txtNroComparendo.Text);
                    if (!serviciosComparendos.comparendoDisponibles(txtNroComparendo.Text))
                    {
                        comparendoComp myCompTmp = new comparendoComp();
                        myCompTmp.NUMEROCOMPARENDO = txtNroComparendo.Text;
                        object[] listaComp = serviciosGeneralesComp.searchComparendo(myCompTmp);
                        if (listaComp != null && listaComp.Length > 0)
                        {
                            funciones.mostrarMensaje("El comparendo ya ha sido registrado", "E");
                            txtNroComparendo.Clear();
                            existecomp = false;
                        }
                        else if (txtPolca.Text == "N") //aumento:  if(txtPolca.Text=="N")
                        {
                            MessageBox.Show("El comparendo no se encuentra asociado a una comparendera. Por favor creela, y vuelva a intentarlo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnGuardar.Enabled = false;
                            existecomp = false;
                            //if (MessageBox.Show("El comparendo no se encuentra asociado a una comparendera. Desea ingresarlo?", "Pregunta?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            //{
                                //funciones.setCombo(cmbAgente, buscarAgente());
                                //btnSearchAgente.Enabled = true;
                                //realizarValidacionNumComparendo = false;
                                //txtFecha.Focus();
                            //}
                        }
                    }
                    else
                    {
                        //MessageBox.Show("¡Comparendo asociado satisfactoriamente!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        existecomp = true;
                        btnGuardar.Enabled = true;
                    }
                }
            }
            else
            {
                //txtNroComparendo.Text = calcNroComp(txtNroComparendo.Text);
                buscarComparendo(txtNroComparendo.Text);
            }
            if (existecomp)
            {
                txtFecha.Focus();
                cargarAgente();
            }
        }

        public void cargarAgente()
        {
            detalleComparendera myDetCom = new detalleComparendera();
            myDetCom.NROCOMPARENDO = txtNroComparendo.Text;
            Object[] tmp;
            tmp = (Object[])serviciosComparendos.getSDetalleComparendera(myDetCom);
            if (tmp != null && tmp.Length > 0)
            {
                myDetCom = (detalleComparendera)tmp[0];
                idComparendera = myDetCom.ID_COMPARENDERA;
                comparenderas myCompar = new comparenderas();
                myCompar.ID = myDetCom.ID_COMPARENDERA;
                tmp = (Object[])serviciosComparendos.getSComparenderas(myCompar);
                if (tmp != null && tmp.Length > 0)
                {
                    myCompar = (comparenderas)tmp[0];
                    if (agentes != null && agentes.Length > 0)
                    {
                        funciones.setCombo(cmbAgente, myCompar.IDAGENTE);
                        btnSearchAgente.Enabled = false;
                    }
                }
            }
        }

        private void txtFecha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtHora.Focus();
            }
        }

        private void mostrarComparendo()
        {
            infractorComp inftmp;
            txtNroComparendo.Text = comparendo.NUMEROCOMPARENDO;
            idInfractor = comparendo.ID_INFRACTOR;
            mostrarDatosInfractor();
            idvehiculo = comparendo.IDVEHICULOCOMP;
            mostrarDatosVehiculo();
            idComparendera = comparendo.IDCOMPARENDERA;
            txtPlaca.Text = comparendo.PLACA;
            txtFecha.Text = DateTime.Parse(comparendo.FECHACOMPARENDO, System.Globalization.CultureInfo.InvariantCulture).ToString("dd/MM/yyyy");
            txtHora.Text = DateTime.Parse(comparendo.HORACOMPARENDO).ToString("HH:mm");
            //txtFecha.Enabled = false;
            //txtHora.Enabled = false;
            txtDireccion.Text = comparendo.DIRECCIONINFRACCION;
            funciones.setCombo(cmbTipoInfractor, comparendo.ID_TIPOINFRACTOR);
            funciones.setCombo(cmbCiudadComp, comparendo.ID_CIUDADDIRECCION);
            txtPolca.Text = comparendo.POLCA.ToString()[0].ToString();
            funciones.setCombo(cmbAgente, comparendo.ID_AGENTE);
            txtLocComuna.Text = comparendo.LOCALIDAD_COMUNADIRECCION;
            idComparendera = comparendo.IDCOMPARENDERA;
            try
            {
                if (comparendo.REPORTAINMOVILIZACION.ToString()[0] == 'S')
                {
                    cmbInmovilizacion.SelectedIndex = 0;
                    txtDireccionPatio.Text = comparendo.DIRECCIONPATIO_INMOVILIZA;
                    txtConsInmov.Text = comparendo.CONSECUTIVOINMOVILIZACION;
                    txtPlacaGrua.Text = comparendo.PLACAGRUA;
                    txtNroGrua.Text = comparendo.NUMEROGRUA;
                    cmbPatioInmov.SelectedValue = comparendo.ID_PATIOINMOVILIZACION;
                }
                else
                    cmbInmovilizacion.SelectedIndex = 1;
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
            }
            try
            {
                if (comparendo.REPORTAGRUA.ToString()[0] == 'S')
                    cmbGrua.SelectedIndex = 0;
                else
                    cmbGrua.SelectedIndex = 1;
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
            }
            try
            {
                if (comparendo.REPORTAFUGA.ToString()[0] == 'S')
                    cmbFuga.SelectedIndex = 0;
                else
                    cmbFuga.SelectedIndex = 1;
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
            }
            try
            {
                if (comparendo.REPORTAACCIDENTE.ToString()[0] == 'S')
                    cmbAccidente.SelectedIndex = 0;
                else
                    cmbAccidente.SelectedIndex = 1;
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
            }
            try
            {
                if (comparendo.PRACTICOALCOLEMIA.ToString()[0] == 'S')
                    cmbAlcoholemia.SelectedIndex = 0;
                else
                    cmbAlcoholemia.SelectedIndex = 1;
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
            }
            txtGradoAl.Text = comparendo.VALORALCOLEMIA.ToString();
            txtConsInmov.Text = comparendo.CONSECUTIVOINMOVILIZACION;
            txtPlacaGrua.Text = comparendo.PLACAGRUA;
            txtNroGrua.Text = comparendo.NUMEROGRUA;
            funciones.setCombo(cmbPatioInmov, comparendo.ID_PATIOINMOVILIZACION);
            txtDireccionPatio.Text = serviciosAccesoriasComp.getDireccionPatio(comparendo.ID_PATIOINMOVILIZACION);
            txtObservacion.Text = comparendo.OBSERVACION;
            propietarioVehComp proptmp = new propietarioVehComp();
            proptmp.ID_COMPARENDO = comparendo.ID_COMPARENDO;
            proptmp.ID_VEHICULO = comparendo.IDVEHICULOCOMP;
            proptmp = serviciosGeneralesComp.searchPropietarioVehiculo(proptmp);
            if (proptmp != null)
            {
                inftmp = new infractorComp();
                inftmp.NROIDENTIFICACION = proptmp.NROIDENTIFICACION;

                inftmp = serviciosGeneralesComp.buscarInfractor(inftmp);
                idPropietario = inftmp.ID_INFRACTOR;
                idPropietarioVeh = proptmp.ID_PROPIETARIOVEH;
                mostrarDatosPropietario();
            }
            testigoComp testtmp = new testigoComp();
            testtmp.ID_COMPARENDO = comparendo.ID_COMPARENDO;
            testtmp = serviciosGeneralesComp.getTestigo(testtmp);
            if (testtmp != null)
            {
                inftmp = null;
                inftmp = new infractorComp();
                inftmp.NROIDENTIFICACION = testtmp.NROIDENTIFICACION;
                inftmp = serviciosGeneralesComp.buscarInfractor(inftmp);
                idTestigo = inftmp.ID_INFRACTOR;
                idTestigoVeh = testtmp.ID_TESTIGO;
                mostrarDatosTestigo();
            }
            infracionComparendoComp tmp = new infracionComparendoComp();
            tmp.IDCOMPARENDO = comparendo.ID_COMPARENDO;
            infraccionComparendo = serviciosGeneralesComp.getInfraccionComparendo(tmp);
            LibreriasSintrat.ServiciosAccesoriasComp.infraccionesComp infractmp = new LibreriasSintrat.ServiciosAccesoriasComp.infraccionesComp();
            infractmp.ID_INFRACCION = infraccionComparendo.IDINFRACCION;
            infraccion = serviciosAccesoriasComp.getInfraccionComp(infractmp);
            mostrarInfraccion();
        }

        public void limpiarDatos()
        {
            txtApellidos.Clear();
            txtApellidosProp.Clear();
            txtApellidoTest.Clear();
            txtCatLic.Clear();
            txtClaseVehiculo.Clear();
            txtCodInfrac.Clear();
            txtCodNuevo.Clear();
            txtConsInmov.Clear();
            txtDireccion.Clear();
            txtDireccionPatio.Clear();
            txtDireccionTest.Clear();
            txtDirInfrac.Clear();
            txtEmpresa.Clear();
            txtGradoAl.Clear();
            txtHora.Clear();
            txtIdentInfrac.Clear();
            txtIdentProp.Clear();
            txtIdentTest.Clear();
            txtInfraccion.Clear();
            txtLicVeh.Clear();
            txtLocComuna.Clear();
            txtNombres.Clear();
            txtNombresProp.Clear();
            txtNombreTest.Clear();
            txtNroGrua.Clear();
            txtNroLicencia.Clear();
            txtObservacion.Clear();
            txtOrgExpideLic.Clear();
            txtPlaca.Clear();
            txtPlacaGrua.Clear();
            txtPolca.Clear();
            txtRadioAcc.Clear();
            txtTelefonoTest.Clear();
            txtTipoServ.Clear();
            txtValorInfraccion.Clear();
            if (cmbAccidente.Items.Count > 1) cmbAccidente.SelectedIndex = 1;
            cmbAgente.SelectedIndex = -1;
            if (cmbAlcoholemia.Items.Count > 1) cmbAlcoholemia.SelectedIndex = 1;
            cmbCiudadComp.SelectedIndex = -1;
            if (cmbFuga.Items.Count > 1) cmbFuga.SelectedIndex = 1;
            if (cmbGrua.Items.Count > 1) cmbGrua.SelectedIndex = 1;
            if (cmbInmovilizacion.Items.Count > 1) cmbInmovilizacion.SelectedIndex = 1;
            cmbPatioInmov.SelectedIndex = -1;
            cmbTipoDocInfra.SelectedIndex = -1;
            cmbTipoDocProp.SelectedIndex = -1;
            cmbTipoDocTest.SelectedIndex = -1;
            cmbTipoInfractor.SelectedIndex = -1;
        }

        private void txtPlaca_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    AccionBuscarPlaca();
                }
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                funciones.mostrarMensaje("Error realizando la funcionalidad. " + exp.Message, "E");
            }
        }

        private void AccionBuscarPlaca()
        {
            if (string.IsNullOrWhiteSpace(txtPlaca.Text))
            {
                fVehiculos gestionveh = new fVehiculos(txtPlaca.Text);
                gestionveh.ShowDialog();

                if (gestionveh.idvehiculo > 0)
                {
                    idvehiculo = gestionveh.idvehiculo;
                    mostrarDatosVehiculo();
                    //cmbTipoDocInfra.Focus();
                }
            }
            else
            {
                //Buscar Vehículo en Base Comparendos
                idvehiculo = buscarVehiculo(txtPlaca.Text);
                if (idvehiculo == -1)
                {
                    if (MessageBox.Show("No se encontro el vehículo, deseas almacenar un nuevo vehículo en la base de datos?", "Pregunta?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        fVehiculos gestionveh = new fVehiculos(txtPlaca.Text);
                        if (gestionveh.ShowDialog() == DialogResult.OK)
                        {
                            idvehiculo = gestionveh.idvehiculo;
                            mostrarDatosVehiculo();
                            cmbTipoDocInfra.Focus();
                        }
                    }
                    else
                    {
                        cmbTipoInfractor.Focus();
                    }
                }
                else
                {
                    mostrarDatosVehiculo();
                    cmbTipoInfractor.Focus();
                }
            }
        }



        private void AccionBuscarInfractor()
        {
            if (cmbTipoDocInfra.SelectedIndex > -1)
            {
                if (txtIdentInfrac.Text == "")
                {
                    fInfractor frmInfractor = new fInfractor((int)cmbTipoDocInfra.SelectedIndex, txtIdentInfrac.Text, "Infractor");
                    frmInfractor.ShowDialog();

                    if (frmInfractor.idInfractor > 0)
                    {
                        idInfractor = frmInfractor.idInfractor;
                        mostrarDatosInfractor();
                        cmbTipoInfractor.Focus();
                    }
                }
                else
                {
                    idInfractor = buscarInfractor(cmbTipoDocInfra.SelectedValue.ToString(), txtIdentInfrac.Text);

                    if (idInfractor == -1)
                    {
                        if (MessageBox.Show("No se encontro el infractor, deseas almacenar un nuevo infractor en la base de datos?", "Pregunta?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            fInfractor frmInfractor = new fInfractor((int)cmbTipoDocInfra.SelectedIndex, txtIdentInfrac.Text, "Infractor");

                            if (frmInfractor.ShowDialog() == DialogResult.OK)
                            {
                                idInfractor = frmInfractor.idInfractor;
                                mostrarDatosInfractor();
                                cmbTipoInfractor.Focus();
                            }
                        }
                        else
                        {
                            cmbTipoInfractor.Focus();
                        }
                    }
                    else
                    {
                        mostrarDatosInfractor();
                        cmbTipoInfractor.Focus();
                    }
                }
            }
            else
            {
                funciones.mostrarMensaje("Debe seleccionar el tipo de documento.", "I");
                cmbTipoDocInfra.Focus();
            }
        }

        private void habilitarInmoviliza(Boolean estado)
        {
            if (estado)
            {
                int consecutivoInmovilizacion = 1;
                consecutivoInmovilizacion = serviciosComparendos.getConsecutivoInmovilizacion();
                consecutivoInmovilizacion++;
                txtConsInmov.Text = consecutivoInmovilizacion.ToString();
            }

            cmbGrua.Enabled = estado;
            txtConsInmov.Enabled = estado;
            //if (estado.Equals(false))
            //{
            //    cmbGrua.SelectedIndex = 1;
            //    habilitarDeshabilitarInfoGrua(true);
            //}
            cmbPatioInmov.Enabled = estado;
            btnSearchPatio.Enabled = estado;
            txtDireccionPatio.Enabled = estado;
            //txtConsInmov.Enabled = estado;
            //txtPlacaGrua.Enabled = estado;
            //txtNroGrua.Enabled = estado;
        }

        private void cmbInmovilizacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbInmovilizacion.SelectedIndex > 0)
            {
                //NO
                habilitarInmoviliza(false);
            }
            else
            {
                //SI
                habilitarInmoviliza(true);
            }
        }

        //new

        private void cmbGrua_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGrua.SelectedIndex > 0)
            {
                //opcion NO
                habilitarDeshabilitarInfoGrua(false);
            }
            else
            {
                //opcion SI
                habilitarDeshabilitarInfoGrua(true);
            }
        }

        private void habilitarDeshabilitarInfoGrua(bool estado)
        {
            txtPlacaGrua.Enabled = estado;
            txtNroGrua.Enabled = estado;
            //txtConsInmov.Enabled = estado;
            //txtPlacaGrua.Enabled = estado;
            //txtNroGrua.Enabled = estado;
            //cmbPatioInmov.Enabled = estado;
            //btnSearchPatio.Enabled = estado;
            //txtDireccionPatio.Enabled = estado;
        }

        //endnew

        private void cmbAlcoholemia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAlcoholemia.SelectedIndex == 0)
                txtGradoAl.Enabled = true;
            else
                txtGradoAl.Enabled = false;
        }

        private void buscarComparendo(String nro)
        {
            comparendoComp tmp = new comparendoComp();
            Object[] comparendos;
            buscador buscador;
            ArrayList Campos = new ArrayList();
            Campos.Add("NUMEROCOMPARENDO = NUMERO COMPARENDO");
            Campos.Add("FECHACOMPARENDO = FECHA COMPARENDO");

            limpiarDatos();
            if (nro != null && nro != "")
            {
                tmp.NUMEROCOMPARENDO = nro;
                comparendos = (Object[])serviciosGeneralesComp.searchComparendo(tmp);
                if (comparendos != null)
                    if (comparendos.GetLength(0) < 2)
                    {
                        comparendo = (comparendoComp)comparendos[0];
                        mostrarComparendo();
                    }
                    else
                    {
                        buscador = new buscador(comparendos, Campos, "Buscar Comparendo", nro);
                        if (buscador.ShowDialog() == DialogResult.OK)
                        {
                            comparendo = funciones.listToComparendo(buscador.Seleccion);
                            mostrarComparendo();
                        }
                        buscador.Dispose();
                    }
                else
                    MessageBox.Show("Comparendo no Existe", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                comparendos = (Object[])serviciosGeneralesComp.getComparendo();
                buscador = new buscador(comparendos, Campos, "Buscar Comparendo", nro);
                if (buscador.ShowDialog() == DialogResult.OK)
                {
                    comparendo = funciones.listToComparendo(buscador.Seleccion);
                    mostrarComparendo();
                }
                buscador.Dispose();
            }
        }

        private void buscarInfraccion()
        {
            ArrayList Campos = new ArrayList();
            Campos.Add("COD_INFRACCION = CODIGO");
            Campos.Add("NUEVO_CODIGO = NUEVO CODIGO");
            Campos.Add("DESCRIPCION = DESCRIPCION");

            Object[] Infracciones = (Object[])serviciosAccesoriasComp.listarInfraccionesComp();
            if (Infracciones != null)
            {
                Infracciones = filtrarInfraccionesFecha(Infracciones);
                buscador buscador = new buscador(Infracciones, Campos, null, null);
                if (buscador.ShowDialog() == DialogResult.OK)
                {
                    if (buscador.Seleccion != null)
                    {
                        infraccion = (LibreriasSintrat.ServiciosAccesoriasComp.infraccionesComp)funciones.listToInfraccion(buscador.Seleccion);
                        mostrarInfraccion();
                    }
                }
                buscador.Dispose();
            }
            else
            {
                funciones.mostrarMensaje("No se encontraron infracciones", "W");
            }
        }

        private object[] filtrarInfraccionesFecha(object[] Infracciones)
        {
            ArrayList infraccionesFiltradas = new ArrayList();
            string fechaDesde, fechaHasta;
            foreach (LibreriasSintrat.ServiciosAccesoriasComp.infraccionesComp infrac in Infracciones)
            {
                if (infrac.FECHADESDE == null && infrac.FECHAHASTA == null)
                {
                    infraccionesFiltradas.Add(infrac);
                }
                else
                {
                    if (infrac.FECHAHASTA == null)
                    {
                        infraccionesFiltradas.Add(infrac);
                    }
                    else
                    {
                        char[] delimiterChar1 = { '-' };
                        string[] datos;
                        fechaDesde = infrac.FECHADESDE;
                        fechaHasta = infrac.FECHAHASTA;
                        DateTime fechaComparendo = new DateTime();
                        DateTime fechades = new DateTime();
                        DateTime fechahas = new DateTime();
                        datos = fechaDesde.Split(delimiterChar1, StringSplitOptions.RemoveEmptyEntries);
                        if (datos.Length > 0)
                        {
                            fechades = DateTime.Parse(datos[0] + "/" + datos[1] + "/" + datos[2]);
                        }
                        datos = fechaHasta.Split(delimiterChar1, StringSplitOptions.RemoveEmptyEntries);
                        if (datos.Length > 0)
                        {
                            fechahas = DateTime.Parse(datos[0] + "/" + datos[1] + "/" + datos[2]);
                        }
                        fechaComparendo = DateTime.Parse(txtFecha.Value.Year + "/" + txtFecha.Value.Month + "/" + txtFecha.Value.Day);
                        if (fechades <= fechaComparendo && fechahas >= fechaComparendo)
                        {
                            infraccionesFiltradas.Add(infrac);
                        }
                    }
                }
            }
            return infraccionesFiltradas.ToArray();
        }

        private void verificarInfraccion(LibreriasSintrat.ServiciosAccesoriasComp.infraccionesComp tmp)
        {
            infraccion = serviciosAccesoriasComp.getInfraccionComp(tmp);
            if (infraccion == null || infraccion.ID_INFRACCION == -1)
                buscarInfraccion();
            else
            {
                if (infraccion.FECHADESDE == null && infraccion.FECHAHASTA == null)
                {
                    mostrarInfraccion();
                }
                else
                {
                    if (infraccion.FECHAHASTA == null)
                    {
                        mostrarInfraccion();
                    }
                    else
                    {
                        string fechaDesde, fechaHasta;
                        char[] delimiterChar1 = { '-' };
                        string[] datos;
                        fechaDesde = infraccion.FECHADESDE;
                        fechaHasta = infraccion.FECHAHASTA;
                        DateTime fechaComparendo = new DateTime();
                        DateTime fechades = new DateTime();
                        DateTime fechahas = new DateTime();
                        datos = fechaDesde.Split(delimiterChar1, StringSplitOptions.RemoveEmptyEntries);
                        if (datos.Length > 0)
                        {
                            fechades = DateTime.Parse(datos[0] + "/" + datos[1] + "/" + datos[2]);
                        }
                        datos = fechaHasta.Split(delimiterChar1, StringSplitOptions.RemoveEmptyEntries);
                        if (datos.Length > 0)
                        {
                            fechahas = DateTime.Parse(datos[0] + "/" + datos[1] + "/" + datos[2]);
                        }
                        fechaComparendo = DateTime.Parse(txtFecha.Value.Year + "/" + txtFecha.Value.Month + "/" + txtFecha.Value.Day);
                        if (fechades <= fechaComparendo && fechahas >= fechaComparendo)
                        {
                            mostrarInfraccion();
                        }
                        else
                        {
                            buscarInfraccion();
                        }
                    }
                }
            }
        }

        private void mostrarInfraccion()
        {
            txtCodInfrac.Clear();
            txtCodNuevo.Clear();
            txtInfraccion.Clear();
            txtValorInfraccion.Text = "0";

            txtCodNuevo.Text = infraccion.NUEVO_CODIGO;
            txtCodInfrac.Text = infraccion.COD_INFRACCION;
            txtInfraccion.Text = infraccion.DESCRIPCION;
            txtValorInfraccion.Text = (serviciosAccesoriasComp.getSalario(txtFecha.Value.Year) / 30 * infraccion.NUMEROSALARIO).ToString("C", culturaEspaniolCol);
        }

        private void txtCodInfrac_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AccionBuscarInfraccionCodigo();
            }
        }

        private void AccionBuscarInfraccionCodigo()
        {
            if (txtCodInfrac.Text.Equals(""))
                buscarInfraccion();
            else
            {
                LibreriasSintrat.ServiciosAccesoriasComp.infraccionesComp tmp = new LibreriasSintrat.ServiciosAccesoriasComp.infraccionesComp();
                tmp.COD_INFRACCION = txtCodInfrac.Text;
                verificarInfraccion(tmp);
            }
        }

        private void txtCodNuevo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AccionBuscarInfraccionNuevoCodigo();
            }
        }

        private void AccionBuscarInfraccionNuevoCodigo()
        {
            if (string.IsNullOrWhiteSpace(txtCodNuevo.Text))
                buscarInfraccion();
            else
            {
                LibreriasSintrat.ServiciosAccesoriasComp.infraccionesComp tmp = new LibreriasSintrat.ServiciosAccesoriasComp.infraccionesComp();
                tmp.NUEVO_CODIGO = txtCodNuevo.Text;
                verificarInfraccion(tmp);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (validarCampos())
                {
                    Boolean guardado = true;
                    comparendo.IDCOMPARENDERA = idComparendera;
                    comparendo.CONSECUTIVOINMOVILIZACION = txtConsInmov.Text;
                    comparendo.DIRECCIONINFRACCION = txtDireccion.Text;
                    comparendo.DIRECCIONPATIO_INMOVILIZA = txtDireccionPatio.Text;
                    comparendo.FECHACOMPARENDO = funciones.convFormatoFecha(txtFecha.Text, "MM/dd/yyyy");
                    comparendo.FECHAREGISTRO = serviciosGenerales.getFechaServidor();//revisar el formato
                    comparendo.HORACOMPARENDO = txtHora.Text + ":00";

                    try
                    {
                        if (cmbAgente.SelectedValue != null)
                            comparendo.ID_AGENTE = int.Parse(cmbAgente.SelectedValue.ToString());
                        else comparendo.ID_AGENTE = 0;
                    }
                    catch (Exception exp)
                    {
                        log.escribirError(exp.ToString(), this.GetType());
                    }
                    try
                    {
                        comparendo.ID_CIUDAD = int.Parse(cmbCiudadComp.SelectedValue.ToString());
                    }
                    catch (Exception exp)
                    {
                        log.escribirError(exp.ToString(), this.GetType());
                    }
                    try
                    {
                        comparendo.ID_CIUDADDIRECCION = int.Parse(cmbCiudadComp.SelectedValue.ToString());
                    }
                    catch (Exception exp)
                    {
                        log.escribirError(exp.ToString(), this.GetType());
                    }
                    comparendo.ID_INFRACTOR = idInfractor;
                    try
                    {
                        if (cmbPatioInmov.SelectedValue != null)
                            comparendo.ID_PATIOINMOVILIZACION = int.Parse(cmbPatioInmov.SelectedValue.ToString());
                        else comparendo.ID_PATIOINMOVILIZACION = 0;
                    }
                    catch (Exception exp)
                    {
                        log.escribirError(exp.ToString(), this.GetType());
                    }
                    try
                    {
                        comparendo.ID_TIPOINFRACTOR = int.Parse(cmbTipoInfractor.SelectedValue.ToString());
                    }
                    catch (Exception exp)
                    {
                        log.escribirError(exp.ToString(), this.GetType());
                    }
                    //comparendo.ID_TRANSITO =
                    //comparendo.IDCOMPARENDERA =
                    comparendo.IDUSUARIO = usuario.ID_USUARIO;
                    comparendo.IDVEHICULOCOMP = idvehiculo;
                    comparendo.LOCALIDAD_COMUNADIRECCION = txtLocComuna.Text;
                    //comparendo.LUGAR = 
                    comparendo.NUMEROCOMPARENDO = txtNroComparendo.Text;
                    comparendo.NUMEROGRUA = txtNroGrua.Text;
                    comparendo.OBSERVACION = txtObservacion.Text;
                    comparendo.PLACA = txtPlaca.Text;
                    comparendo.PLACAGRUA = txtPlacaGrua.Text;
                    comparendo.POLCA = txtPolca.Text[0].ToString();
                    try
                    {
                        comparendo.PRACTICOALCOLEMIA = cmbAlcoholemia.SelectedItem.ToString()[0].ToString();
                    }
                    catch (Exception exp)
                    {
                        log.escribirError(exp.ToString(), this.GetType());
                    }
                    try
                    {
                        comparendo.REPORTAACCIDENTE = cmbAccidente.SelectedItem.ToString()[0].ToString();
                    }
                    catch (Exception exp)
                    {
                        log.escribirError(exp.ToString(), this.GetType());
                    }
                    try
                    {
                        comparendo.REPORTAFUGA = cmbFuga.SelectedItem.ToString()[0].ToString();
                    }
                    catch (Exception exp)
                    {
                        log.escribirError(exp.ToString(), this.GetType());
                    }
                    try
                    {
                        comparendo.REPORTAGRUA = cmbGrua.SelectedItem.ToString()[0].ToString();
                    }
                    catch (Exception exp)
                    {
                        log.escribirError(exp.ToString(), this.GetType());
                    }
                    try
                    {
                        comparendo.REPORTAINMOVILIZACION = cmbInmovilizacion.SelectedItem.ToString()[0].ToString();
                    }
                    catch (Exception exp)
                    {
                        log.escribirError(exp.ToString(), this.GetType());
                    }
                    //comparendo.TIENEAUDIENCIA =
                    try
                    {
                        comparendo.VALORALCOLEMIA = double.Parse(txtGradoAl.Text, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.GetCultureInfo("Es-co"));
                    }
                    catch (Exception exp)
                    {
                        log.escribirError(exp.ToString(), this.GetType());
                    }

                    if (nuevo)
                    {
                        idComparendo = serviciosGeneralesComp.crearComparendo(comparendo, WS.MyUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName());
                        //HISTORIAL COMPARENDO ***********************************************
                        historialcomparendo myhistorial = new historialcomparendo();


                    }

                    

                        //FIN HISTORAIL COMPARENDO *******************************************
                    else
                    {
                        if (guardado)
                            guardado = serviciosGeneralesComp.actualizarComparendo(comparendo, WS.MyUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName());
                        idComparendo = comparendo.ID_COMPARENDO;
                        if (guardado)
                        {
                            funciones.mostrarMensaje("Se ha actualizado el comparendo con éxito...", "W");
                        }
                        else
                        {
                            funciones.mostrarMensaje("No se pudo actualizar el comparendo", "W");
                        }
                    }

                    if (idComparendo != 0)
                    {
                        Boolean tmp;

                        infraccionComparendo.IDCOMPARENDO = idComparendo;
                        infraccionComparendo.IDINFRACCION = infraccion.ID_INFRACCION;
                        try
                        {
                            infraccionComparendo.VALORINFRACCION = funciones.strToDouble((funciones.moneyToStr(txtValorInfraccion.Text)));
                        }
                        catch (Exception exp)
                        {
                            log.escribirError(exp.ToString(), this.GetType());
                        }
                        if (nuevo)
                            serviciosGeneralesComp.crearInfraccionComparendo(infraccionComparendo, WS.MyUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName());
                        else
                            serviciosGeneralesComp.actualizarInfraccionComparendo(infraccionComparendo, WS.MyUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName());
                        tmp = guardarPropVehiculo(idPropietarioVeh);
                        if (guardado)
                            guardado = tmp;
                        tmp = guardarTestigoComp(idTestigoVeh);
                        if (guardado)
                           guardado = tmp;
                        if (MessageBox.Show("¡Comparendo creado satisfactoriamente! Desea ingresar otro comparendo?", "Otro comparendo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            == DialogResult.Yes)
                        {
                            if (guardado && nuevo)
                            {
                                limpiarDatos();
                                txtNroComparendo.Clear();
                                idComparendo = 0;
                                idvehiculo = 0;
                                idTestigo = 0;
                                idPropietario = 0;

                                evaluarPolca();
                                transitoComp otc = new transitoComp();
                                //object[] listaOrganismos = serviciosAccesorias.getOneOrganismoTransito(otc);
                                //if(listaOrganismos != null && listaOrganismos.Count() > 0)
                                //{
                                //otc = (organismoTransito)listaOrganismos[0];
                                //}
                                otc = serviciosGeneralesComp.getTransitoComp(otc);
                                if (otc != null && otc.ID_CIUDAD > 0)
                                    cmbCiudadComp.SelectedValue = otc.ID_CIUDAD;
                            }
                        }
                        else
                        {
                            DialogResult = DialogResult.Cancel;
                            this.Close();
                        }
                    }
                    else MessageBox.Show("No se pudo crear el comparendo, es posible que el número de comparendo no se haya validado. Verifique también el formato de hora.", "Crear comparendo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                funciones.mostrarMensaje("Error al insertar comparendo, intente nuevamente", "E");
            }
        }

        bool validarCampos()
        {
            bool validar = true;

            if (idvehiculo <= 0)
            {
                AccionBuscarPlaca();
            }
            if (idInfractor <= 0)
            {
                AccionBuscarInfractor();
            }
            if (idPropietario <= 0)
            {
                AccionBuscarPropietario();
            }
            if (string.IsNullOrWhiteSpace(txtCodInfrac.Text))
            {
                AccionBuscarInfraccionCodigo();
            }
            else if (string.IsNullOrWhiteSpace(txtCodNuevo.Text))
            {
                AccionBuscarInfraccionNuevoCodigo();
            }

            if (txtNroComparendo.Text.Equals(""))
            {
                funciones.mostrarMensaje("El número de comparendo no puede ser vacio", "W");
                txtNroComparendo.Focus();
                return false;
            }
            if (txtFecha.Text.Equals(""))
            {
                funciones.mostrarMensaje("El campo fecha no puede ser vacio", "W");
                txtFecha.Focus();
                return false;
            }
            else
            {
                if (nuevo)
                {
                    string fecha = txtFecha.Text;
                    char[] delimitarChar = { '/' };
                    string[] datos;
                    int meses = 0, dias = 0, anos = 0;
                    datos = fecha.Split(delimitarChar, StringSplitOptions.RemoveEmptyEntries);
                    if (datos.Length != 3)
                    {
                        funciones.mostrarMensaje("El formato de fecha es incorrecto", "");
                        txtFecha.Focus();
                        return false;
                    }
                    dias = int.Parse(datos[0]);
                    meses = int.Parse(datos[1]);
                    anos = int.Parse(datos[2]);
                    string fehaActual = serviciosAccesoriasComp.getFechaHora("MM/dd/yyyy");
                    int mesesActual = 0, diasActual = 0, anosActual = 0;
                    datos = fehaActual.Split(delimitarChar, StringSplitOptions.RemoveEmptyEntries);
                    mesesActual = int.Parse(datos[0]);
                    diasActual = int.Parse(datos[1]);
                    anosActual = int.Parse(datos[2]);
                    if (anos > anosActual)
                    {
                        funciones.mostrarMensaje("El año ingresado es superior al año actual", "W");
                        txtFecha.Focus();
                        return false;
                    }
                    else if (anos == anosActual && meses > mesesActual)
                    {
                        funciones.mostrarMensaje("El mes ingresado es superior al mes actual", "W");
                        txtFecha.Focus();
                        return false;
                    }
                    else if (anos == anosActual && meses == mesesActual && dias > diasActual)
                    {
                        funciones.mostrarMensaje("El día ingresado es superior al dia actual", "W");
                        txtFecha.Focus();
                        return false;
                    }
                }
            }
            if (txtHora.Text.Equals("  :"))
            {
                funciones.mostrarMensaje("El campo hora no puede ser vacio", "W");
                txtHora.Focus();
                return false;
            }
            else
            {
                string horaCompleta = txtHora.Text;
                char[] delimitarChar = { ':' };
                string[] datos;
                int hora = 0, minutos = 0;
                datos = horaCompleta.Split(delimitarChar, StringSplitOptions.RemoveEmptyEntries);
                if (datos.Length != 2)
                {
                    funciones.mostrarMensaje("El formato del campo hora no es valido", "W");
                    txtHora.Focus();
                    return false;
                }
                hora = int.Parse(datos[0]);
                minutos = int.Parse(datos[1]);
                if (hora > 24)
                {
                    funciones.mostrarMensaje("La hora no puede ser mayor de 24", "W");
                    txtHora.Focus();
                    return false;
                }
                if (minutos > 59)
                {
                    funciones.mostrarMensaje("Los minutos no pueden ser mayores a 59", "W");
                    txtHora.Focus();
                    return false;
                }
            }

            //COMPARAR FECHA DEL COMPARENDO CON LA FECHA DEL SERVIDOR
            string fechaServidor = serviciosAccesoriasComp.getFechaHora("MM/dd/yyyy hh:mm:ss");
            //DateTime dtFechaServidor = DateTime.Parse(fechaServidor, System.Globalization.CultureInfo.InvariantCulture);
            DateTime dtFechaServidor = DateTime.Parse(fechaServidor, System.Globalization.CultureInfo.InvariantCulture);
            DateTime dtFechaComparendo = DateTime.Parse(funciones.convFormatoFecha(txtFecha.Text, "MM/dd/yyyy") + " " + txtHora.Text + ":00", System.Globalization.CultureInfo.InvariantCulture);

            if (DateTime.Compare(dtFechaServidor, dtFechaComparendo) < 0)
            {
                funciones.mostrarMensaje("La fecha y hora del comparendo debe ser menor a " + dtFechaServidor.ToString("dd/MM/yyyy hh:mm:ss") + " (fecha y hora del servidor)", "W");
                txtFecha.Focus();
                return false;
            }

            if (txtDireccion.Text.Equals(""))
            {
                funciones.mostrarMensaje("El campo dirección no puede ser vacio", "W");
                txtDireccion.Focus();
                return false;
            }
            //if (txtLocComuna.Text.Equals(""))
            //{
            //    funciones.mostrarMensaje("El campo de localidad o comuna no puede ser vacio","W");
            //    return false;
            //}

            if (txtPlaca.Text.Equals(""))
            {
                funciones.mostrarMensaje("El campo placa no puede ser vacio", "W");
                txtPlaca.Focus();
                return false;
            }
            if (txtIdentInfrac.Text.Equals(""))
            {
                funciones.mostrarMensaje("La identificación del infractor no puede ser vacio", "W");
                txtIdentInfrac.Focus();
                return false;
            }
            if (txtIdentProp.Text.Equals(""))
            {
                funciones.mostrarMensaje("La identificación del propietario no puede ser vacio", "W");
                txtIdentProp.Focus();
                return false;
            }
            if (txtInfraccion.Text.Length <= 0)
            {
                funciones.mostrarMensaje("El campo infraccion es obligatorio", "W");
                txtCodNuevo.Focus();
                return false;
            }

            if (cmbCiudadComp.SelectedIndex < 0)
            {
                funciones.mostrarMensaje("Debe seleccionar una ciudad.", "W");
                cmbCiudadComp.Focus();
                return false;
            }
            //if (!validar)
            //    funciones.mostrarMensaje("El comparendo no pudo ser procesado, vuelva a intentar ", "W");
            return validar;
        }

        public Boolean guardarPropVehiculo(int id)
        {
            Boolean res = false;
            propietarioVehComp tmp = new propietarioVehComp();
            tmp.APELLIDOS = txtApellidosProp.Text;
            tmp.ID_COMPARENDO = idComparendo;
            try
            {
                tmp.ID_DOCTO = serviciosAccesoriasComp.getCodTipoDoc(int.Parse(cmbTipoDocProp.SelectedValue.ToString()));
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
            }
            tmp.ID_VEHICULO = idvehiculo;
            tmp.NOMBRES = txtNombresProp.Text;
            tmp.NROIDENTIFICACION = txtIdentProp.Text;
            if (nuevo)
            {
                idPropietario = serviciosGeneralesComp.crearPropietarioVehiculo(tmp);
                if (idPropietario != -1)
                    res = true;
            }
            else
            {
                tmp.ID_PROPIETARIOVEH = id;
                res = serviciosGeneralesComp.actualizarPropietarioVehiculo(tmp, WS.MyUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName());
            }


            return res;
        }

        public Boolean guardarTestigoComp(int id)
        {
            Boolean res = false;
            testigoComp tmp = new testigoComp();
            tmp.APELLIDOS = txtApellidoTest.Text;
            tmp.DIRECCION = txtDireccionTest.Text;
            tmp.ID_COMPARENDO = idComparendo;
            try
            {
                tmp.ID_DOCTO = serviciosAccesoriasComp.getCodTipoDoc(int.Parse(cmbTipoDocTest.SelectedValue.ToString()));
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
            }
            tmp.NOMBRES = txtNombreTest.Text;
            tmp.NROIDENTIFICACION = txtIdentTest.Text;
            tmp.NROTELEFONO = txtTelefonoTest.Text;

            if (nuevo)
            {
                idTestigo = serviciosGeneralesComp.crearTestigo(tmp);
                if (idTestigo != -1)
                    res = true;
            }
            else
            {
                tmp.ID_TESTIGO = id;
                res = serviciosGeneralesComp.actualizarTestigo(tmp);
            }
            return res;
        }

        private void txtIdentProp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AccionBuscarPropietario();
            }
        }

        private void AccionBuscarPropietario()
        {
            if (cmbTipoDocProp.SelectedIndex > -1)
            {
                if (txtIdentProp.Text == "")
                {
                    //funciones.mostrarMensaje("El Campo Identificación Propietario Vehículo no puede ser Vacio", "W");
                    /*fGestionInfractor gestioninf = new fGestionInfractor((int)cmbTipoDocProp.SelectedIndex, txtIdentProp.Text, "P");
                    if (gestioninf.ShowDialog() == DialogResult.OK)
                    {
                        idPropietario = gestioninf.idInfractor;
                        mostrarDatosPropietario();
                    }*/
                    fInfractor frmInfractor = new fInfractor((int)cmbTipoDocProp.SelectedIndex, txtIdentProp.Text, "Propietario");

                    //new

                    frmInfractor.ShowDialog();

                    //endnew

                    //if (frmInfractor.ShowDialog() == DialogResult.OK)
                    if (frmInfractor.idInfractor > 0)
                    {
                        idPropietario = frmInfractor.idInfractor;
                        mostrarDatosPropietario();
                    }
                }
                else
                {
                    try
                    {
                        idPropietario = buscarInfractor(cmbTipoDocProp.SelectedValue.ToString(), txtIdentProp.Text);
                    }
                    catch (Exception exp)
                    {
                        log.escribirError(exp.ToString(), this.GetType());
                        idPropietario = -1;
                    }

                    if (idPropietario == -1)
                    {
                        if (MessageBox.Show("No se encontro el propietario, desea agregar un nuevo propietario?", "Pregunta?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            /*fGestionInfractor gestioninf = new fGestionInfractor((int)cmbTipoDocProp.SelectedIndex, txtIdentProp.Text, "P");
                            if (gestioninf.ShowDialog() == DialogResult.OK)
                            {
                                idPropietario = gestioninf.idInfractor;
                                mostrarDatosPropietario();
                                cmbTipoDocTest.Focus();
                            }*/

                            fInfractor frmInfractor = new fInfractor((int)cmbTipoDocProp.SelectedIndex, txtIdentProp.Text, "Propietario");

                            frmInfractor.ShowDialog();

                            //if (frmInfractor.ShowDialog() == DialogResult.OK)
                            if (frmInfractor.idInfractor > 0)
                            {
                                idPropietario = frmInfractor.idInfractor;
                                mostrarDatosPropietario();
                                cmbTipoDocTest.Focus();
                            }
                        }
                        else
                        {
                            txtIdentProp.Focus();
                        }
                    }
                    else
                    {
                        mostrarDatosPropietario();
                        cmbTipoDocTest.Focus();
                    }
                }
            }
            else
            {
                funciones.mostrarMensaje("Debe seleccionar el tipo de documento.", "I");
                cmbTipoDocProp.Focus();
            }
        }

        //private void buscadorComparendo()
        //{
        //    if (nuevo)
        //    {
        //        if (txtNroComparendo.Text.Length < 20)
        //            txtNroComparendo.Text = calcNroComp(txtNroComparendo.Text);
        //        if (!serviciosComparendos.comparendoDisponibles(txtNroComparendo.Text))
        //        {
        //            comparendoComp myCompTmp = new comparendoComp();
        //            myCompTmp.NUMEROCOMPARENDO = txtNroComparendo.Text;
        //            object[] listaComp = serviciosGeneralesComp.searchComparendo(myCompTmp);
        //            if (listaComp != null && listaComp.Length > 0)
        //            {
        //                funciones.mostrarMensaje("El comparendo ya ha sido registrado", "E");
        //                txtNroComparendo.Clear();
        //                existecomp = false;
        //            }
        //            else
        //            {
        //                if (MessageBox.Show("El comparendo no se encuentra asociado a una comparendera. ¿Desea ingresarlo?", "Pregunta?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //                {
        //                    buscarAgente();
        //                    btnSearchAgente.Enabled = true;
        //                }
        //            }
        //        }
        //        else
        //            existecomp = true;
        //    }
        //    else
        //    {
        //        //txtNroComparendo.Text = calcNroComp(txtNroComparendo.Text);
        //        buscarComparendo(txtNroComparendo.Text);
        //    }
        //    if (existecomp)
        //    {
        //        txtFecha.Focus();
        //        cargarAgente();
        //    }
        //}

        private int buscarCiudad()
        {
            int res = 0;
            ArrayList Campos = new ArrayList();
            //Campos.Add("CODCIUDAD = CODIGO");
            Campos.Add("NOMBRE = NOMBRE");
            if (ciudades != null)
            {
                buscador buscadorr = new buscador(ciudades, Campos, "Buscar Ciudades", null);
                funciones = new Funciones();

                if (buscadorr.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        res = int.Parse(buscadorr.Seleccion.Cells["ID_CIUDAD"].Value.ToString());
                    }
                    catch (Exception exp)
                    {
                        log.escribirError(exp.ToString(), this.GetType());
                    }
                }
            }
            return res;
        }

        private int buscarAgente()
        {
            int res = 0;
            ArrayList Campos = new ArrayList();
            Campos.Add("PLACAAGENTE = PLACA");
            Campos.Add("NOMBRES = NOMBRES");
            Campos.Add("APELL1 = PRIMER APELLIDO");
            Campos.Add("APELL2 = SEGUNDO APELLIDO");
            if (agentes != null)
            {
                buscador buscadorr = new buscador(agentes, Campos, "Buscar Agentes", null);
                funciones = new Funciones();

                if (buscadorr.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        res = int.Parse(buscadorr.Seleccion.Cells["ID_AGENTE"].Value.ToString());
                    }
                    catch (Exception exp)
                    {
                        log.escribirError(exp.ToString(), this.GetType());
                    }
                }
            }
            return res;

        }

        private void txtIdentTest_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AccionBuscarTestigo();
            }
        }

        private void AccionBuscarTestigo()
        {
            if (cmbTipoDocTest.SelectedIndex > -1)
            {
                if (txtIdentTest.Text == "")
                {
                    //funciones.mostrarMensaje("EL campo Identificación Testigo no pude ser Vacio", "W");
                    /*fGestionInfractor gestioninf = new fGestionInfractor((int)cmbTipoDocTest.SelectedIndex, txtIdentTest.Text, "T");
                    if (gestioninf.ShowDialog() == DialogResult.OK)
                    {
                        idTestigo = gestioninf.idInfractor;
                        mostrarDatosTestigo();
                    }*/

                    fInfractor frmInfractor = new fInfractor((int)cmbTipoDocTest.SelectedIndex, txtIdentTest.Text, "Testigo");

                    //new

                    frmInfractor.ShowDialog();

                    //endnew

                    //if (frmInfractor.ShowDialog() == DialogResult.OK)
                    if (frmInfractor.idInfractor > 0)
                    {
                        idTestigo = frmInfractor.idInfractor;
                        mostrarDatosTestigo();
                    }
                }
                else
                {
                    try
                    {
                        idTestigo = buscarInfractor(cmbTipoDocTest.SelectedValue.ToString(), txtIdentTest.Text);
                    }
                    catch (Exception exp)
                    {
                        log.escribirError(exp.ToString(), this.GetType());
                        idTestigo = -1;
                    }
                    if (idTestigo == -1)
                    {
                        if (MessageBox.Show("No se encontro el testigo, deseas almacenar uno nuevo?", "Pregunta?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            /*fGestionInfractor gestioninf = new fGestionInfractor((int)cmbTipoDocTest.SelectedIndex, txtIdentTest.Text, "T");
                            if (gestioninf.ShowDialog() == DialogResult.OK)
                            {
                                idTestigo = gestioninf.idInfractor;
                                mostrarDatosTestigo();
                            }*/

                            fInfractor frmInfractor = new fInfractor((int)cmbTipoDocTest.SelectedIndex, txtIdentTest.Text, "Testigo");

                            frmInfractor.ShowDialog();

                            //if (frmInfractor.ShowDialog() == DialogResult.OK)
                            if (frmInfractor.idInfractor > 0)
                            {
                                idTestigo = frmInfractor.idInfractor;
                                mostrarDatosTestigo();
                            }
                        }
                        else
                        {
                            txtIdentTest.Focus();
                        }
                    }
                    else
                        mostrarDatosTestigo();
                    /*if (MessageBox.Show("Deseas buscar el agente de transito?", "Pregunta?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        funciones.setCombo(cmbAgente, buscarAgente());
                        cmbInmovilizacion.Focus();
                    }
                    else
                    {
                        btnSearchAgente.Focus();
                    }*/
                    //funciones.setCombo(cmbAgente, buscarAgente());
                    cmbInmovilizacion.Focus();
                }
            }
            else
            {
                funciones.mostrarMensaje("Debe seleccionar el tipo de documento.", "I");
                cmbTipoDocTest.Focus();
            }
        }

        private void fGestionComparendo_Shown(object sender, EventArgs e)
        {
            txtNroComparendo.Focus();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBuscarComparendo_Click(object sender, EventArgs e)
        {
            //if (nuevo)
            try
            {
                //buscadorComparendo();                
                validarNumeroComparendo();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                funciones.mostrarMensaje("Error al consultar comparendo, intente nuevamente", "E");
            }
        }

        private void txtHora_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtDireccion.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            funciones.setCombo(cmbCiudadComp, buscarCiudad());
            txtLocComuna.Focus();
        }

        private void txtLocComuna_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtPlaca.Focus();
        }

        private void cmbTipoDocInfra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtIdentInfrac.Focus();
        }

        private void cmbTipoInfractor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbTipoDocProp.Focus();
        }

        private void cmbTipoDocProp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtIdentProp.Focus();
        }

        private void cmbTipoDocTest_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtIdentTest.Focus();
        }

        private void btnSearchAgente_Click(object sender, EventArgs e)
        {
            try
            {
                funciones.setCombo(cmbAgente, buscarAgente());
                cmbInmovilizacion.Focus();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                funciones.mostrarMensaje("Error realizando la funcionalidad. " + exp.Message, "E");
            }
        }

        private void cmbInmovilizacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("\t");
        }

        private void cmbGrua_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("\t");
        }

        private void cmbFuga_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("\t");
        }

        private void cmbAccidente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("\t");
        }

        private void cmbAlcoholemia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("\t");
        }

        private void txtGradoAl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("\t");
        }

        private void keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("\t");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private int buscadorVehiculo()
        {
            int res = 0;
            ArrayList Campos = new ArrayList();
            Campos.Add("PLACA = PLACA");
            resBuscador = serviciosGeneralesComp.listarVehiculoComp();
            if (resBuscador != null)
            {
                buscador buscadorr = new buscador(resBuscador, Campos, "Buscar Vehiculos", null);
                funciones = new Funciones();

                if (buscadorr.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        res = int.Parse(buscadorr.Seleccion.Cells["IDVEHICULOCOMP"].Value.ToString());
                    }
                    catch (Exception exp)
                    {
                        log.escribirError(exp.ToString(), this.GetType());
                    }
                }
                resBuscador = null;
            }

            return res;

        }

        private int buscadorPersona()
        {
            int res = 0;
            ArrayList Campos = new ArrayList();
            Campos.Add("NROIDENTIFICACION = IDENTIFICACION");
            Campos.Add("NOMBRES = NOMBRES");
            Campos.Add("APELLIDOS = APELLIDOS");
            Campos.Add("NROLICCONDUCCION = NROLICCONDUCCION");
            if (infractores == null)
                infractores = serviciosGeneralesComp.listarInfractorComp();
            if (infractores != null)
            {
                buscador buscadorr = new buscador(infractores, Campos, "Buscar Infractor", null);
                funciones = new Funciones();

                if (buscadorr.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        res = int.Parse(buscadorr.Seleccion.Cells["ID_INFRACTOR"].Value.ToString());
                    }
                    catch (Exception exp)
                    {
                        log.escribirError(exp.ToString(), this.GetType());
                    }
                }
            }

            return res;
        }

        private int buscadorPatio()
        {
            int res = 0;
            ArrayList Campos = new ArrayList();
            Campos.Add("DESCRIPCIONPATIO = PATIO");
            resBuscador = serviciosAccesoriasComp.listarPatioInmovilizacion();
            if (resBuscador != null)
            {
                buscador buscadorr = new buscador(resBuscador, Campos, "Buscar Patios", null);
                funciones = new Funciones();

                if (buscadorr.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        res = int.Parse(buscadorr.Seleccion.Cells["ID_PATIO"].Value.ToString());
                    }
                    catch (Exception exp)
                    {
                        log.escribirError(exp.ToString(), this.GetType());
                    }
                }
                resBuscador = null;
            }

            return res;
        }

        private void btnSearchInfrac_Click(object sender, EventArgs e)
        {
            try
            {
                AccionBuscarInfractor();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                funciones.mostrarMensaje("Error realizando la funcionalidad. " + exp.Message, "E");
                idInfractor = -1;
            }
        }


        private void btnSearchProp_Click(object sender, EventArgs e)
        {
            if (cmbTipoDocProp.SelectedIndex > -1)
            {
                if (txtIdentProp.Text == "")
                {
                    //funciones.mostrarMensaje("EL campo Identificación Propietario Vehículo no puede ser vacio", "W");
                    fInfractor frmInfractor = new fInfractor((int)cmbTipoDocInfra.SelectedIndex, txtIdentProp.Text, "Propietario");
                    if (frmInfractor.ShowDialog() == DialogResult.OK)
                    {
                        idPropietario = frmInfractor.idInfractor;
                        mostrarDatosPropietario();
                    }
                }
                else
                {
                    try
                    {
                        idPropietario = buscarInfractor(cmbTipoDocProp.SelectedValue.ToString(), txtIdentProp.Text);
                    }
                    catch (Exception exp)
                    {
                        log.escribirError(exp.ToString(), this.GetType());
                        idPropietario = -1;
                    }

                    if (idPropietario == -1)
                    {
                        if (MessageBox.Show("No se encontro el propietario, desea agregar un nuevo propietario?", "Pregunta?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            /*fGestionInfractor gestioninf = new fGestionInfractor((int)cmbTipoDocProp.SelectedIndex, txtIdentProp.Text, "P");
                            if (gestioninf.ShowDialog() == DialogResult.OK)
                            {
                                idPropietario = gestioninf.idInfractor;
                                mostrarDatosPropietario();
                                cmbTipoDocTest.Focus();
                            }*/

                            fInfractor frmInfractor = new fInfractor((int)cmbTipoDocInfra.SelectedIndex, txtIdentProp.Text, "");

                            //new

                            frmInfractor.ShowDialog();

                            //endnew

                            //if (frmInfractor.ShowDialog() == DialogResult.OK)
                            if (frmInfractor.idInfractor > 0)
                            {
                                idPropietario = frmInfractor.idInfractor;
                                mostrarDatosPropietario();
                                cmbTipoDocTest.Focus();
                            }
                        }
                        else
                        {
                            txtIdentProp.Focus();
                        }
                    }
                    else
                    {
                        mostrarDatosPropietario();
                        cmbTipoDocTest.Focus();
                    }
                    //idPropietario = buscadorPersona();
                    //mostrarDatosPropietario();
                }
            }
            else
            {
                funciones.mostrarMensaje("Debe seleccionar el tipo de documento.", "I");
                cmbTipoDocProp.Focus();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (cmbTipoDocTest.SelectedIndex > -1)
            {
                if (txtIdentTest.Text == "")
                {
                    //funciones.mostrarMensaje("EL campo Identificación Testigo no puede ser vacio", "W");
                    fInfractor frmInfractor = new fInfractor((int)cmbTipoDocInfra.SelectedIndex, txtIdentTest.Text, "Testigo");

                    //new

                    frmInfractor.ShowDialog();

                    //endnew

                    //if (frmInfractor.ShowDialog() == DialogResult.OK)
                    if (frmInfractor.idInfractor > 0)
                    {
                        idTestigo = frmInfractor.idInfractor;
                        mostrarDatosTestigo();
                    }
                }
                else
                {
                    try
                    {
                        idTestigo = buscarInfractor(cmbTipoDocTest.SelectedValue.ToString(), txtIdentTest.Text);
                    }
                    catch (Exception exp)
                    {
                        log.escribirError(exp.ToString(), this.GetType());
                        idTestigo = -1;
                    }
                    if (idTestigo == -1)
                    {
                        if (MessageBox.Show("No se encontro el testigo, deseas almacenar uno nuevo?", "Pregunta?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            /*fGestionInfractor gestioninf = new fGestionInfractor((int)cmbTipoDocTest.SelectedIndex, txtIdentTest.Text, "T");
                            if (gestioninf.ShowDialog() == DialogResult.OK)
                            {
                                idTestigo = gestioninf.idInfractor;
                                mostrarDatosTestigo();
                            }*/

                            fInfractor frmInfractor = new fInfractor((int)cmbTipoDocInfra.SelectedIndex, txtIdentTest.Text, "Testigo");

                            //new

                            frmInfractor.ShowDialog();

                            //endnew

                            //if (frmInfractor.ShowDialog() == DialogResult.OK)
                            if (frmInfractor.idInfractor > 0)
                            {
                                idTestigo = frmInfractor.idInfractor;
                                mostrarDatosTestigo();
                            }
                        }
                        else
                        {
                            txtIdentTest.Focus();
                        }
                    }
                    else
                        mostrarDatosTestigo();
                    /*if (MessageBox.Show("Deseas buscar el agente de transito?","Pregunta?",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        funciones.setCombo(cmbAgente, buscarAgente());
                        cmbInmovilizacion.Focus();
                    }
                    else
                    {
                        btnSearchAgente.Focus();
                    }*/
                    //idTestigo = buscadorPersona();
                    //mostrarDatosTestigo();

                    cmbInmovilizacion.Focus();
                }
            }
            else
            {
                funciones.mostrarMensaje("Debe seleccionar el tipo de documento.", "I");
                cmbTipoDocTest.Focus();
            }
        }

        private void btnSearchPatio_Click(object sender, EventArgs e)
        {
            funciones.setCombo(cmbPatioInmov, buscadorPatio());
            txtDireccionPatio.Focus();
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void txtGradoAl_KeyPress(object sender, KeyPressEventArgs e)
        {
            funciones.esDecimal(e);
        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            funciones.moverFoco(txtDireccion, e, txtLocComuna);
        }

        private void btnCrearAgente_Click(object sender, EventArgs e)
        {
            fGestionAgentes fagentes = new fGestionAgentes(serviciosAccesoriasComp);
            if (fagentes.ShowDialog() == DialogResult.OK)
            {
                agentes = (Object[])serviciosGeneralesComp.getAgentes(null);
                funciones.llenarCombo(cmbAgente, agentes);
                if (cmbAgente.Items.Count > 0)
                    cmbAgente.SelectedIndex = cmbAgente.Items.Count - 1;
            }
        }

        private void btnBuscarVehiculo_Click(object sender, EventArgs e)
        {
            try
            {
                AccionBuscarPlaca();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                funciones.mostrarMensaje("Error realizando la funcionalidad. " + exp.Message, "E");
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void txtIdentInfrac_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    AccionBuscarInfractor();
                }
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                funciones.mostrarMensaje("Error realizando la funcionalidad. " + exp.Message, "E");
                idInfractor = -1;
            }
        }

        private void txtNroComparendo_Leave(object sender, EventArgs e)
        {
            try
            {
                //buscadorComparendo();
                validarNumeroComparendo();
                realizarValidacionNumComparendo = true;
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                funciones.mostrarMensaje("Error al consultar comparendo, intente nuevamente", "E");
            }
        }

        private void txtPlaca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                cmbTipoDocInfra.Focus();
        }

        private void txtIdentInfrac_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtIdentProp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                cmbTipoDocTest.Focus();
        }

    }
}
