using System; using TransitoPrincipal; using LibreriasSintrat.utilidades;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibreriasSintrat.ServiciosAccesoriasComp;
using LibreriasSintrat.ServiciosGeneralesComp;
using LibreriasSintrat.ServiciosGenerales;
using LibreriasSintrat.ServiciosUsuarios;
using LibreriasSintrat.ServiciosComparendos;
using Comparendos.utilidades; using LibreriasSintrat.utilidades; using LibreriasSintrat;

using System.Globalization;

namespace Comparendos.servicios.generales
{
    public partial class fConsultarComparendo : Form
    {
        Boolean nuevo = false;
        Boolean existecomp;
        String encComp;
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
        LibreriasSintrat.ServiciosAccesoriasComp.infraccionesComp infraccion;
        infracionComparendoComp infraccionComparendo;
        comparendoComp comparendo;
        Funciones funciones;
        ServiciosAccesoriasCompService serviciosAccesoriasComp;
        ServiciosGeneralesCompService serviciosGeneralesComp;
        //ServiciosGeneralesService serviciosGenerales;
        ServiciosComparendosService serviciosComparendos;
        vehiculosComp myVehiulo;
        Log log = new Log();
        CultureInfo culturaEspaniolCol = new CultureInfo("es-CO", false);


        public fConsultarComparendo(Boolean modifica, usuarios myuser, ServiciosAccesoriasCompService srv)
        {
            InitializeComponent();
            serviciosAccesoriasComp = srv;
            serviciosGeneralesComp = WS.ServiciosGeneralesCompService();
            //serviciosGenerales = WS.ServiciosGeneralesService();
            serviciosComparendos = WS.ServiciosComparendosService();
            comparendo = new comparendoComp();
            infraccion = new LibreriasSintrat.ServiciosAccesoriasComp.infraccionesComp();
            funciones = new Funciones();
            infraccionComparendo = new infracionComparendoComp();
            usuario = myuser;
            ciudades = (Object[])serviciosAccesoriasComp.listarCiudadComp();
            agentes = (Object[])serviciosGeneralesComp.getAgentes(null);
            llenarCombos();
            idvehiculo = -1;
            idInfractor = -1;
            encComp = "";
            nuevo = !modifica;
            limpiarDatos();
            myVehiulo = new vehiculosComp();
            log = new Log();
        }

        private void fConsultarComparendo_Load(object sender, EventArgs e)
        {
            //evaluarPolca();
            deshabilitarCampos();
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

        
        private void mostrarDatosVehiculo()
        {
            vehiculosComp tmp = new vehiculosComp();
            tmp.IDVEHICULOCOMP = idvehiculo;
            tmp = serviciosGeneralesComp.getFirstVehiculoComp(tmp);
            txtClaseVehiculo.Text = serviciosAccesoriasComp.getDescClaseVehiculo(tmp.ID_CVEHICULO);
            txtTipoServ.Text = serviciosAccesoriasComp.getDescTipoServicioComp(tmp.ID_SERVICIO);
            txtEmpresa.Text = serviciosAccesoriasComp.getDescEmpresaComp(tmp.ID_EMPRESA);
            txtLicVeh.Text = tmp.NROLICENCIA;
            if (tmp.ID_RADIOACCION>0)
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
            txtCatLic.Text = tmp.CATEGLICENCIA;
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
            myVehiulo = tmp;
            return tmp.IDVEHICULOCOMP;
        }

        private int buscarInfractor(int tipodoc, String identificacion)
        {
            infractorComp tmp = new infractorComp();
            tmp.ID_DOCTO = tipodoc;
            tmp.NROIDENTIFICACION = identificacion;
            tmp = serviciosGeneralesComp.buscarInfractor(tmp);
            return tmp.ID_INFRACTOR;
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
                comparenderas myCompar = new comparenderas();
                myCompar.ID = myDetCom.ID_COMPARENDERA;
                tmp=(Object[])serviciosComparendos.getSComparenderas(myCompar);
                if(tmp!=null&&tmp.Length>0)
                {
                    myCompar = (comparenderas)tmp[0];
                    if(agentes!=null&&agentes.Length>0)
                    {
                        funciones.setCombo(cmbAgente, myCompar.IDAGENTE);
                        //btnSearchAgente.Enabled = false;
                    }
                }
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
            txtPlaca.Text = comparendo.PLACA;
            txtFecha.Text = DateTime.Parse(comparendo.FECHACOMPARENDO, System.Globalization.CultureInfo.InvariantCulture).ToString("dd/MM/yyyy");
            txtHora.Text = DateTime.Parse(comparendo.HORACOMPARENDO).ToString("hh-mi");
            txtDireccion.Text = comparendo.DIRECCIONINFRACCION;
            funciones.setCombo(cmbTipoInfractor, comparendo.ID_TIPOINFRACTOR);
            funciones.setCombo(cmbCiudadComp, comparendo.ID_CIUDADDIRECCION);
            txtPolca.Text = comparendo.POLCA.ToString()[0].ToString();
            funciones.setCombo(cmbAgente, comparendo.ID_AGENTE);
            txtLocComuna.Text = comparendo.LOCALIDAD_COMUNADIRECCION;
            try
            {
                if (comparendo.REPORTAINMOVILIZACION.ToString()[0] == 'S')
                    cmbInmovilizacion.SelectedIndex = 0;
                else
                    cmbInmovilizacion.SelectedIndex = 1;
            }
            catch(Exception exp) {
                log.escribirError(exp.ToString(), this.GetType());
            }
            try
            {
                if (comparendo.REPORTAGRUA.ToString()[0] == 'S')
                    cmbGrua.SelectedIndex = 0;
                else
                    cmbGrua.SelectedIndex = 1;
            }
            catch(Exception exp){
                log.escribirError(exp.ToString(), this.GetType());
            }
            try
            {
                if (comparendo.REPORTAFUGA.ToString()[0] == 'S')
                    cmbFuga.SelectedIndex = 0;
                else
                    cmbFuga.SelectedIndex = 1;
            }
            catch(Exception exp) {
                log.escribirError(exp.ToString(), this.GetType());
            }
            try
            {
                if (comparendo.REPORTAACCIDENTE.ToString()[0] == 'S')
                    cmbAccidente.SelectedIndex = 0;
                else
                    cmbAccidente.SelectedIndex = 1;
            }
            catch(Exception exp) {
                log.escribirError(exp.ToString(), this.GetType());
            }
            try
            {
                if (comparendo.PRACTICOALCOLEMIA.ToString()[0] == 'S')
                    cmbAlcoholemia.SelectedIndex = 0;
                else
                    cmbAlcoholemia.SelectedIndex = 1;
            }
            catch(Exception exp) {
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
            //txtPlaca.Clear();
            txtPlacaGrua.Clear();
            txtPolca.Clear();
            txtRadioAcc.Clear();
            txtTelefonoTest.Clear();
            txtTipoServ.Clear();
            txtValorInfraccion.Clear();
            cmbAccidente.SelectedIndex = -1;
            cmbAgente.SelectedIndex = -1;
            cmbAlcoholemia.SelectedIndex = -1;
            cmbCiudadComp.SelectedIndex = -1;
            cmbFuga.SelectedIndex = -1;
            cmbGrua.SelectedIndex = -1;
            cmbInmovilizacion.SelectedIndex = -1;
            cmbPatioInmov.SelectedIndex = -1;
            cmbTipoDocInfra.SelectedIndex = -1;
            cmbTipoDocProp.SelectedIndex = -1;
            cmbTipoDocTest.SelectedIndex = -1;
            cmbTipoInfractor.SelectedIndex = -1;
            txtNroComparendo.Clear();
        }
        
        private void txtPlaca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter&&txtPlaca.Text!="")
            {
                idvehiculo = buscarVehiculo(txtPlaca.Text);
                if (idvehiculo == -1)
                {
                    funciones.mostrarMensaje("No se encontro el vehiculo!!", "W");
                }
                else
                    buscaComparendoVehi();
            }
        }       

        private void habilitarInmoviliza(Boolean estado)
        {
            cmbGrua.Enabled = estado;
            txtConsInmov.Enabled = estado;
            txtPlacaGrua.Enabled = estado;
            txtNroGrua.Enabled = estado;
            cmbPatioInmov.Enabled = estado;
            //btnSearchPatio.Enabled = estado;
            txtDireccionPatio.Enabled = estado;
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
                    MessageBox.Show("No existe comparendo para este vehiculo!", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            buscador buscador = new buscador(Infracciones, Campos, null, null);

            if (buscador.ShowDialog() == DialogResult.OK)
            {
                infraccion = (LibreriasSintrat.ServiciosAccesoriasComp.infraccionesComp)funciones.listToInfraccion(buscador.Seleccion);
                mostrarInfraccion();
            }
            buscador.Dispose();
        }

        private void verificarInfraccion(LibreriasSintrat.ServiciosAccesoriasComp.infraccionesComp tmp)
        {
            infraccion = serviciosAccesoriasComp.getInfraccionComp(tmp);
            if (infraccion==null||infraccion.ID_INFRACCION == -1)
                buscarInfraccion();
            else
                mostrarInfraccion();
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

        private void buscadorComparendo()
        {
            if (nuevo)
            {
                if (txtNroComparendo.Text.Length < 20)
                    //txtNroComparendo.Text = calcNroComp(txtNroComparendo.Text);
                if (!serviciosComparendos.comparendoDisponibles(txtNroComparendo.Text))
                {
                    funciones.mostrarMensaje("El comparendo ya ha sido registrado o no existe en la comparendera", "E");
                    txtNroComparendo.Clear();
                    existecomp = false;
                }
                else
                    existecomp = true;
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

        private int buscarCiudad()
        {
            int res = 0;
            ArrayList Campos = new ArrayList();
            Campos.Add("CODCIUDAD = CODIGO");
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
                    catch(Exception exp) {
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
                    catch(Exception exp) {
                        log.escribirError(exp.ToString(), this.GetType());    
                    }
                }
            }
            return res;
        
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
                buscadorComparendo();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            funciones.setCombo(cmbCiudadComp, buscarCiudad());
            txtLocComuna.Focus();
        }

        private void keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("\t");
        }

        public void buscaComparendoVehi()
        {
            comparendoComp tmp = new comparendoComp();
            Object[] comparendos;
            buscador buscador;
            ArrayList Campos = new ArrayList();
            Campos.Add("NUMEROCOMPARENDO = NUMERO COMPARENDO");
            Campos.Add("FECHACOMPARENDO = FECHA COMPARENDO");

            limpiarDatos();
            if (myVehiulo.PLACA != null && myVehiulo.PLACA != "")
            {
                tmp.PLACA = myVehiulo.PLACA;
                comparendos = (Object[])serviciosGeneralesComp.searchComparendo(tmp);
                if (comparendos != null)
                    if (comparendos.GetLength(0) < 2)
                    {
                        comparendo = (comparendoComp)comparendos[0];
                        mostrarComparendo();
                    }
                    else
                    {
                        buscador = new buscador(comparendos, Campos, "Buscar Comparendo", myVehiulo.PLACA);
                        if (buscador.ShowDialog() == DialogResult.OK)
                        {
                            comparendo = funciones.listToComparendo(buscador.Seleccion);
                            mostrarComparendo();
                        }
                        buscador.Dispose();
                    }
                else
                    MessageBox.Show("No existe comparendo para este vehiculo!", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                comparendos = (Object[])serviciosGeneralesComp.getComparendo();
                buscador = new buscador(comparendos, Campos, "Buscar Comparendo", myVehiulo.PLACA);
                if (buscador.ShowDialog() == DialogResult.OK)
                {
                    comparendo = funciones.listToComparendo(buscador.Seleccion);
                    mostrarComparendo();
                }
                buscador.Dispose();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            idvehiculo = buscadorVehiculo();
            //mostrarDatosVehiculo();
            if (idvehiculo > 0)
            {
                buscaComparendoVehi();   
            }
            else
            {
                funciones.mostrarMensaje("Vehiculo no encontrado en el sistema!","W");
            }
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
                        myVehiulo = (vehiculosComp)funciones.listToVehiculo(buscadorr.Seleccion);
                    }
                    catch(Exception exp) {
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
            if(infractores == null)
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
                    catch(Exception exp){
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
                    catch(Exception exp) {
                        log.escribirError(exp.ToString(), this.GetType());
                    }
                }
                resBuscador = null;
            }

            return res;
        }

        private void btnSearchInfrac_Click(object sender, EventArgs e)
        {
            if (txtIdentInfrac.Text == "")
            {
                funciones.mostrarMensaje("El campo Identificación Infractor no puede ser vacio", "W");
            }
            else 
            {
                idInfractor = buscadorPersona();
                mostrarDatosInfractor();
            }
        }

        private void btnSearchProp_Click(object sender, EventArgs e)
        {
            if (txtIdentProp.Text == "")
            {
                funciones.mostrarMensaje("EL campo Identificación Propietario Vehículo no puede ser vacio", "W");
            }
            else 
            {
                idPropietario = buscadorPersona();
                mostrarDatosPropietario();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtIdentTest.Text == "")
            {
                funciones.mostrarMensaje("EL campo Identificación Testigo no puede ser vacio", "W");
            }
            else 
            {
                idTestigo = buscadorPersona();
                mostrarDatosTestigo();
            }
        }

        private void btnSearchPatio_Click(object sender, EventArgs e)
        {
            funciones.setCombo(cmbPatioInmov, buscadorPatio());
            txtDireccionPatio.Focus();
        }

        public void deshabilitarCampos() 
        {
            groupBox6.Enabled = false;
            groupBox5.Enabled = false;
            groupBox4.Enabled = false;
            groupBox3.Enabled = false;
            groupBox2.Enabled = false;
            groupBox8.Enabled = false;
            //txtNroComparendo.Enabled = false;
            txtFecha.Enabled = false;
            txtHora.Enabled = false;
            txtDireccion.Enabled = false;
            cmbCiudadComp.Enabled = false;
            txtLocComuna.Enabled = false;
            txtClaseVehiculo.Enabled = false;
            txtTipoServ.Enabled = false;
            txtLicVeh.Enabled = false;
            txtEmpresa.Enabled = false;
            txtRadioAcc.Enabled = false;
        }

        private void txtTipoServ_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscarNroComparendo_Click(object sender, EventArgs e)
        {
            try
            {
                buscarNroComparendo();
            }
            catch(Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                funciones.mostrarMensaje("Error al consultar el comparendo", "E");
            }
        }

        private void txtNroComparendo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                buscarNroComparendo();    
            }
        }

        void buscarNroComparendo() 
        {
            if (txtNroComparendo.Text.Equals(""))
            {
                funciones.mostrarMensaje("El campo número de comparendo no puede ser vacío", "W");
            }
            else
            {
                comparendo.NUMEROCOMPARENDO = txtNroComparendo.Text;
                comparendo = serviciosGeneralesComp.searchOneComparendo(comparendo);
                if (comparendo != null && comparendo.ID_COMPARENDO > 0)
                {
                    mostrarComparendo();
                }
                else
                {
                    funciones.mostrarMensaje("No se encontró el comparendo", "W");
                }
            }
        }

    }
}
