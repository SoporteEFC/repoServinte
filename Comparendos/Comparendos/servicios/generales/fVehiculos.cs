using System; using TransitoPrincipal; using LibreriasSintrat.utilidades;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibreriasSintrat.ServiciosAccesoriasComp;
using LibreriasSintrat.ServiciosGeneralesComp;
using LibreriasSintrat.ServiciosCuposTrans;
//using LibreriasSintrat.ServiciosVehiculos;
using System.Collections;
using Comparendos.utilidades; using LibreriasSintrat;

namespace Comparendos.servicios.generales
{
    public partial class fVehiculos : Form
    {
        ServiciosAccesoriasCompService serviciosAccesoriasComp;
        ServiciosGeneralesCompService serviciosGeneralesComp;
        ServiciosCuposTransService serviciosCupos;


        vehiculosComp vehiculo = new vehiculosComp();
        public int idvehiculo = -1;
        
        Boolean nuevo = false; 
        
        Funciones funciones = new Funciones();
        Log log = new Log();

        public fVehiculos()
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                InitializeComponent();

                habilitarEdicion(false);
                habilitarControles(true);
                habilitarBusqueda(true);

                serviciosAccesoriasComp = WS.ServiciosAccesoriasCompService();
                serviciosGeneralesComp = WS.ServiciosGeneralesCompService();
                serviciosCupos = WS.ServiciosCuposTransService();

                llenarCombos();                                             
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                funciones.mostrarMensaje("Error al cargar el formulario: " + exp.Message, "E");
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }

            this.Cursor = Cursors.Arrow;
        }

        public fVehiculos(string placa)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                InitializeComponent();
                
                habilitarEdicion(false);
                habilitarControles(true);
                habilitarBusqueda(true);                                               

                serviciosAccesoriasComp = WS.ServiciosAccesoriasCompService();
                serviciosGeneralesComp = WS.ServiciosGeneralesCompService();

                llenarCombos();

                //Si se invoca este constructor, es para crear un nuevo vehículo
                btnNuevo_Click(null, null);

                if (!string.IsNullOrWhiteSpace(placa))
                {
                    txtPlacaBusq.Text = placa;
                    txtPlaca.Text = placa;
                }
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                funciones.mostrarMensaje("Error al cargar el formulario: " + exp.Message, "E");
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }

            this.Cursor = Cursors.Arrow;
        }

        private void habilitarEdicion(bool habilitar)
        {
            txtPlaca.Enabled = habilitar;
            txtNroLicencia.Enabled = habilitar;            
            cmbCVehiculo.Enabled = habilitar;
            cmbTServicio.Enabled = habilitar;
            cmbLugarMatricula.Enabled = habilitar;

            cmbEmpresa.Enabled = habilitar;
            cmbRadioAccion.Enabled = habilitar;            
            cmbModalidad.Enabled = habilitar;
            cmbTransPas.Enabled = habilitar;
            txtTOperacion.Enabled = habilitar;

            btnPost.Enabled = habilitar;
            btnCancelar.Enabled = habilitar;
        }

        private void habilitarControles(bool habilitar)
        {
            btnNuevo.Enabled = habilitar;
            btnEdit.Enabled = habilitar;
        }

        private void habilitarBusqueda(bool habilitar)
        {
            txtPlacaBusq.Enabled = habilitar;
            btnSearchVehi.Enabled = habilitar;
        }        

        private void llenarCombos()
        {
            serviciosCupos = WS.ServiciosCuposTransService();

            funciones.llenarCombo(cmbCVehiculo, serviciosAccesoriasComp.ListarClaseVehiculo());
            funciones.llenarCombo(cmbTServicio, serviciosAccesoriasComp.ListarTipoServicioComp());
            funciones.llenarCombo(cmbLugarMatricula, serviciosAccesoriasComp.ListarOrganismoTransitoComp());
            
            funciones.llenarCombo(cmbEmpresa, serviciosCupos.getTEmpresasServicio(null));
            //funciones.llenarCombo(cmbEmpresa, serviciosAccesoriasComp.listarEmpresaComp());

            funciones.llenarCombo(cmbRadioAccion, serviciosAccesoriasComp.listarRadioAccionComp());   
            funciones.llenarCombo(cmbModalidad, serviciosAccesoriasComp.listarModalidadTransComp());            
            funciones.llenarCombo(cmbTransPas, serviciosAccesoriasComp.listarTransPasajeros());
        }

        public void limpiarCampos()
        {
            cmbCVehiculo.SelectedIndex = -1;
            cmbEmpresa.SelectedIndex = -1;
            cmbLugarMatricula.SelectedIndex = -1;
            cmbModalidad.SelectedIndex = -1;
            cmbRadioAccion.SelectedIndex = -1;
            cmbTransPas.SelectedIndex = -1;
            cmbTServicio.SelectedIndex = -1;

            txtNroLicencia.Clear();
            txtPlaca.Clear();
            txtTOperacion.Clear();
        }

        public void mostrarDatos()
        {
            //vehComp = (vehiculosComp)vehiculoComp[pos];
            if (vehiculo != null && vehiculo.IDVEHICULOCOMP > 0)
            {
                txtPlaca.Text = vehiculo.PLACA;
                txtNroLicencia.Text = vehiculo.NROLICENCIA;
                txtTOperacion.Text = vehiculo.TARJETAOPERACION;

                funciones.setCombo(cmbCVehiculo, vehiculo.ID_CVEHICULO);
                funciones.setCombo(cmbEmpresa, vehiculo.ID_EMPRESA);
                funciones.setCombo(cmbLugarMatricula, vehiculo.ID_ORGTRANSITODEMATRICULA);
                funciones.setCombo(cmbModalidad, vehiculo.ID_MODALIDADTRANSPORTE);
                funciones.setCombo(cmbRadioAccion, vehiculo.ID_RADIOACCION);
                funciones.setCombo(cmbTransPas, vehiculo.ID_TIPOTRANSPORTEPASAJERO);
                funciones.setCombo(cmbTServicio, vehiculo.ID_SERVICIO);
            }
        }                                                           
        
        

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                nuevo = true;                
                limpiarCampos();
                habilitarEdicion(true);
                habilitarBusqueda(false);
                habilitarControles(false);
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                funciones.mostrarMensaje("Error realizando la funcionalidad. " + exp.Message, "E");
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (vehiculo != null && vehiculo.IDVEHICULOCOMP > 0)
                {                    
                    nuevo = false;
                    habilitarEdicion(true);
                    habilitarBusqueda(false);
                    habilitarControles(false);
                }
                else
                {
                    funciones.mostrarMensaje("Debe buscar un vehículo para editar.", "E");
                }                
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                funciones.mostrarMensaje("Error realizando la funcionalidad. " + exp.Message, "E");
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                if (validarCampos())
                {
                    if (nuevo)
                    {
                        vehiculosComp vehiculoTemp = new vehiculosComp();

                        int tipoServicio = (int)cmbTServicio.SelectedValue;
                        if (tipoServicio == 2) // SI EL TIPO DE SERVICIO ES PÚBLICO
                        {
                            vehiculoTemp.ID_EMPRESA = (int)cmbEmpresa.SelectedValue;
                            vehiculoTemp.ID_RADIOACCION = (int)cmbRadioAccion.SelectedValue;
                            vehiculoTemp.ID_MODALIDADTRANSPORTE = (int)cmbModalidad.SelectedValue;
                            vehiculoTemp.ID_TIPOTRANSPORTEPASAJERO = (int)cmbTransPas.SelectedValue;
                            vehiculoTemp.TARJETAOPERACION = txtTOperacion.Text;
                        }
                        else
                        {
                            vehiculoTemp.ID_EMPRESA = -1;
                            vehiculoTemp.ID_RADIOACCION = -1;
                            vehiculoTemp.ID_MODALIDADTRANSPORTE = -1;
                            vehiculoTemp.ID_TIPOTRANSPORTEPASAJERO = -1;
                            vehiculoTemp.TARJETAOPERACION = null;
                        }

                        vehiculoTemp.ID_ORGTRANSITODEMATRICULA = (int)cmbLugarMatricula.SelectedValue;
                        vehiculoTemp.ID_SERVICIO = (int)cmbTServicio.SelectedValue;
                        vehiculoTemp.ID_CVEHICULO = (int)cmbCVehiculo.SelectedValue;
                        vehiculoTemp.NROLICENCIA = txtNroLicencia.Text;
                        vehiculoTemp.PLACA = txtPlaca.Text;

                        //ENVIAR DATOS AL SERVIDOR
                        idvehiculo = serviciosGeneralesComp.crearVehiculoComp(vehiculoTemp, WS.MyUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName());
                        if (idvehiculo == -1)
                        {
                            MessageBox.Show("No fue posible guardar el vehiculo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            btnPost.DialogResult = DialogResult.None;
                            limpiarCampos();
                        }
                        else
                        {
                            MessageBox.Show("Vehículo almacenado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            vehiculo = vehiculoTemp;
                            vehiculo.IDVEHICULOCOMP = idvehiculo;
                            DialogResult = DialogResult.OK;
                        }
                    }
                    else
                    {
                        int tipoServicio = (int)cmbTServicio.SelectedValue;
                        if (tipoServicio == 2) // SI EL TIPO DE TRANSPORTE ES DE PASAJERO
                        {
                            vehiculo.ID_EMPRESA = (int)cmbEmpresa.SelectedValue;
                            vehiculo.ID_RADIOACCION = (int)cmbRadioAccion.SelectedValue;
                            vehiculo.ID_MODALIDADTRANSPORTE = (int)cmbModalidad.SelectedValue;
                            vehiculo.ID_TIPOTRANSPORTEPASAJERO = (int)cmbTransPas.SelectedValue;
                            vehiculo.TARJETAOPERACION = txtTOperacion.Text;
                        }
                        else
                        {
                            vehiculo.ID_EMPRESA = -1;
                            vehiculo.ID_RADIOACCION = -1;
                            vehiculo.ID_MODALIDADTRANSPORTE = -1;
                            vehiculo.ID_TIPOTRANSPORTEPASAJERO = -1;
                            vehiculo.TARJETAOPERACION = null;
                        }

                        vehiculo.ID_ORGTRANSITODEMATRICULA = (int)cmbLugarMatricula.SelectedValue;
                        vehiculo.ID_SERVICIO = (int)cmbTServicio.SelectedValue;
                        vehiculo.ID_CVEHICULO = (int)cmbCVehiculo.SelectedValue;
                        vehiculo.NROLICENCIA = txtNroLicencia.Text;
                        vehiculo.PLACA = txtPlaca.Text;

                        //ENVIAR DATOS AL SERVIDOR
                        if (!serviciosGeneralesComp.actualizarVehiculoComp(vehiculo, WS.MyUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName()))
                        {
                            MessageBox.Show("No fue posible guardar el vehiculo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            btnPost.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            MessageBox.Show("Vehiculo actualizado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DialogResult = DialogResult.OK;
                        }

                        idvehiculo = vehiculo.IDVEHICULOCOMP;
                    }

                    mostrarDatos();
                    habilitarEdicion(false);
                    habilitarControles(true);
                    habilitarBusqueda(true);
                }
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                funciones.mostrarMensaje("Error realizando la funcionalidad. " + exp.Message, "E");
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }

            this.Cursor = Cursors.Arrow;
        }


        #region Eventos de Búsqueda
            private void btnBuscarlugar_Click(object sender, EventArgs e)
            {
                try
                {
                    object[] listaOrganismos = serviciosAccesoriasComp.ListarOrganismoTransitoComp();
                    if (listaOrganismos != null)
                    {
                        organismoTransitoComp organismoTran = new organismoTransitoComp();
                        ArrayList campos = new ArrayList();
                        campos.Add("NOMBRESECRETARIA = Nombre");
                        campos.Add("NIT = Nit");
                        buscador buscador = new buscador(listaOrganismos, campos, "Buscador de Organismos de Transito", "");
                        if (buscador.ShowDialog() == DialogResult.OK)
                        {
                            organismoTran = (organismoTransitoComp)funciones.listToOrganismoTransitoComp(buscador.Seleccion);
                            cmbLugarMatricula.SelectedValue = organismoTran.IDORGTRANSITO;
                        }
                        buscador.Dispose();
                    }
                }
                catch (Exception exp)
                {
                    log.escribirError(exp.ToString(), this.GetType());
                    funciones.mostrarMensaje("Error realizando la funcionalidad. " + exp.Message, "E");
                    //Console.WriteLine(exp.Message);
                    //Console.WriteLine(exp.StackTrace);
                }
            }

            private void btnBuscarEmpresa_Click(object sender, EventArgs e)
            {
                try
                {
                    //object[] listaEmpresa = serviciosAccesoriasComp.listarEmpresaComp();
                    object[] listaEmpresa = serviciosCupos.getTEmpresasServicio(null);
                    
                    if (listaEmpresa != null)
                    {
                        empresasdeServicioTrans empresa = new empresasdeServicioTrans();
                        //empresaComp empresa = new empresaComp();
                        ArrayList campos = new ArrayList();
                        campos.Add("NOMBRE = Razon Social");
                        campos.Add("NIT = Nit");
                        buscador buscador = new buscador(listaEmpresa, campos, "Buscador de Empresa", "");
                        if (buscador.ShowDialog() == DialogResult.OK)
                        {
                            //empresa = (empresaComp)funciones.listToEmpresa(buscador.Seleccion);
                            empresa = (empresasdeServicioTrans)funciones.listToEmpresaServicio(buscador.Seleccion);
                            cmbEmpresa.SelectedValue = empresa.ID_EMPSERVICIO;
                        }
                        buscador.Dispose();
                    }
                }
                catch (Exception exp)
                {
                    log.escribirError(exp.ToString(), this.GetType());
                    funciones.mostrarMensaje("Error realizando la funcionalidad. " + exp.Message, "E");
                    //Console.WriteLine(exp.Message);
                    //Console.WriteLine(exp.StackTrace);
                }
            }

            private void btnSearchVehi_Click(object sender, EventArgs e)
            {
                try
                {
                    buscarVehiculo();
                }
                catch (Exception exp)
                {
                    log.escribirError(exp.ToString(), this.GetType());
                    funciones.mostrarMensaje("Error realizando la funcionalidad. " + exp.Message, "E");
                    //Console.WriteLine(exp.Message);
                    //Console.WriteLine(exp.StackTrace);
                }
            }

            private void txtPlacaBusq_KeyDown(object sender, KeyEventArgs e)
            {
                try
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        buscarVehiculo();
                    }
                }
                catch (Exception exp)
                {
                    log.escribirError(exp.ToString(), this.GetType());
                    funciones.mostrarMensaje("Error realizando la funcionalidad. " + exp.Message, "E");
                    //Console.WriteLine(exp.Message);
                    //Console.WriteLine(exp.StackTrace);
                }
            }

            private void buscarVehiculo()
            {
                if (!txtPlacaBusq.Text.Equals(""))
                {
                    String placa = txtPlacaBusq.Text;
                    vehiculo = new vehiculosComp();
                    vehiculo.PLACA = placa;
                    vehiculo = serviciosGeneralesComp.getFirstVehiculoComp(vehiculo);

                    int idVehiculoTemp = vehiculo.IDVEHICULOCOMP;

                    if (vehiculo != null && vehiculo.IDVEHICULOCOMP > 0)
                    {
                        mostrarDatos();
                    }
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
                            vehiculo = vehiculoTemp;
                            mostrarDatos();

                            //ENVIAR DATOS AL SERVIDOR
                            idVehiculoTemp = serviciosGeneralesComp.crearVehiculoComp(vehiculoTemp, WS.MyUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName());
                        }
                    }
                    //else
                    //{
                    //    funciones.mostrarMensaje("El vehículo no se encontró en el sistema!", "W");
                    //    limpiarCampos();
                    //}
                }
                else
                {
                    funciones.mostrarMensaje("El campo placa no puede ser vacío!", "W");
                    txtPlacaBusq.Focus();
                }
            }
        #endregion

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                nuevo = false;

                limpiarCampos();
                habilitarEdicion(false);
                habilitarControles(true);
                habilitarBusqueda(true);
                mostrarDatos();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                funciones.mostrarMensaje("Error realizando la funcionalidad. " + exp.Message, "E");
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool validarCampos() 
        {          
            //Obligatorios
            if (string.IsNullOrWhiteSpace(txtPlaca.Text))
            {
                funciones.mostrarMensaje("El campo placa no puede ser vacío","W");
                txtPlaca.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtNroLicencia.Text))
            {
                funciones.mostrarMensaje("El campo número de licencia no puede ser vacío", "W");
                txtNroLicencia.Focus();
                return false;
            }
            if (cmbCVehiculo.SelectedIndex == -1)
            {
                funciones.mostrarMensaje("Debe seleccionar la clase de vehículo", "W");
                cmbCVehiculo.Focus();
                return false;
            }
            if (cmbTServicio.SelectedIndex == -1)
            {
                funciones.mostrarMensaje("Debe seleccionar el tipo de servicio", "W");
                cmbTServicio.Focus();
                return false;
            }
            if (cmbLugarMatricula.SelectedIndex == -1)
            {
                funciones.mostrarMensaje("Debe seleccionar el lugar de matrícula", "W");
                cmbLugarMatricula.Focus();
                return false;
            }

            //Si es servicio público, los campos correspondientes son obligatorios
            if (cmbTServicio.SelectedValue != null)
            {
                if (cmbTServicio.SelectedValue.ToString().Equals("2"))  //Servicio Público
                {
                    if (cmbEmpresa.SelectedIndex == -1)
                    {
                        funciones.mostrarMensaje("Debe seleccionar la empresa.", "W");
                        cmbEmpresa.Focus();
                        return false;
                    }
                    if (cmbRadioAccion.SelectedIndex == -1)
                    {
                        funciones.mostrarMensaje("Debe seleccionar el radio de acción.", "W");
                        cmbRadioAccion.Focus();
                        return false;
                    }
                    if (cmbModalidad.SelectedIndex == -1)
                    {
                        funciones.mostrarMensaje("Debe seleccionar la modalidad.", "W");
                        cmbModalidad.Focus();
                        return false;
                    }
                    if (cmbTransPas.SelectedIndex == -1)
                    {
                        funciones.mostrarMensaje("Debe seleccionar el tipo de transporte.", "W");
                        cmbTransPas.Focus();
                        return false;
                    }
                    if (string.IsNullOrWhiteSpace(txtTOperacion.Text))
                    {
                        funciones.mostrarMensaje("El campo Tarjeta de Operación no puede ser vacío", "W");
                        txtTOperacion.Focus();
                        return false;
                    }
                    
                }
            }

            return true;
        }



        private void cmbTServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Si es servicio público, habilitar los campos correspondientes
            if (cmbTServicio.SelectedValue != null)
            {
                if (cmbTServicio.SelectedValue.ToString().Equals("2"))
                {
                    grbInfoPublicos.Enabled = true;
                }
                else
                {
                    grbInfoPublicos.Enabled = false;
                }
            }
        }

        #region Eventos KEYPRESS

            private void txtNroLicencia_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.validarCampoObligatorio(txtNroLicencia, e);
            }

            private void cmbCVehiculo_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }

            private void cmbTServicio_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }

            private void cmbLugarMatricula_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }

            private void cmbEmpresa_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }

            private void cmbRadioAccion_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }

            private void cmbModalidad_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }

            private void cmbTransPas_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }

            private void txtTOperacion_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }
        #endregion
    }
}
