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
using System.Collections;
using Comparendos.utilidades;

namespace Comparendos.servicios.generales
{
    public partial class fInfractor : Form
    {        
        ServiciosAccesoriasCompService serviciosAccesoriasComp;
        ServiciosGeneralesCompService serviciosGeneralesComp;
        
        infractorComp infractor = new infractorComp();        
        public int idInfractor;

        Boolean nuevo = false;

        Funciones funciones = new Funciones();        
        Log log = new Log();


        //new
        //static string TIPOUSUARIO = "Infractor";
        static string TIPOUSUARIO = "";
        //endnew



        public fInfractor()
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

        public fInfractor(int tipodoc, String identificacion, string tipoUsuario)
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

                //new
                this.Text = "[Gestión Datos " + tipoUsuario + "]";
                //this.Text = "[Gestión Datos " + TIPOUSUARIO + "]";
                TIPOUSUARIO = tipoUsuario;
                //endnew                

                //Si se invoca este constructor, es para crear un nuevo usuario
                btnNuevo_Click(null, null);

                funciones.setCombo(cmbTipoDocBusq, tipodoc);
                txtIdentificacionBusq.Text = identificacion;

                funciones.setCombo(cmbTipoDoc, tipodoc);
                txtIdentificacion.Text = identificacion;
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

        private void fInfractor_Load(object sender, EventArgs e)
        {
            try
            {
                cmbTipoDocBusq.SelectedIndex = 0;
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                funciones.mostrarMensaje("Error al cargar el formulario: " + exp.Message, "E");
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }


        public void habilitarEdicion(bool habilitar)
        {
            cmbCatLicencia.Enabled = habilitar;
            cmbCiudadRes.Enabled = habilitar;
            cmbOrgExpide.Enabled = habilitar;
            cmbSexo.Enabled = habilitar;
            cmbTipoDoc.Enabled = habilitar;
            txtApellidos.Enabled = habilitar;
            txtDireccion.Enabled = habilitar;
            txtEdad.Enabled = habilitar;
            txtEmail.Enabled = habilitar;
            txtFecVenLic.Enabled = habilitar;
            txtIdentificacion.Enabled = habilitar;
            txtNombres.Enabled = habilitar;
            txtNroLicencia.Enabled = habilitar;
            txtTelefono.Enabled = habilitar;

            btnBuscarInfractor.Enabled = habilitar;
            btnBuscarCiudad.Enabled = habilitar;
            btnBuscarlugar.Enabled = habilitar;

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
            cmbTipoDocBusq.Enabled = habilitar;
            txtIdentificacionBusq.Enabled = habilitar;
            btnBuscarInfractor.Enabled = habilitar;
        }        

        private void llenarCombos()
        {
            funciones.llenarCombo(cmbCatLicencia, serviciosAccesoriasComp.listarCategoriaLicTransComp());
            funciones.llenarCombo(cmbCiudadRes, serviciosAccesoriasComp.listarCiudadComp());            
            funciones.llenarCombo(cmbOrgExpide, serviciosAccesoriasComp.ListarOrganismoTransitoComp());
            funciones.llenarCombo(cmbSexo, serviciosAccesoriasComp.listarSexoComp());
            funciones.llenarCombo(cmbTipoDocBusq, serviciosAccesoriasComp.obtenerTiposDocumento());
            funciones.llenarCombo(cmbTipoDoc, serviciosAccesoriasComp.obtenerTiposDocumento());
        }

        private void limpiarDatos()
        {
            cmbCatLicencia.SelectedIndex = -1;
            cmbCiudadRes.SelectedIndex = -1;
            cmbOrgExpide.SelectedIndex = -1;
            cmbSexo.SelectedIndex = -1;
            cmbTipoDoc.SelectedIndex = -1;

            txtApellidos.Clear();
            txtDireccion.Clear();
            txtEdad.Clear();
            txtEmail.Clear();
            txtFecVenLic.Text = DateTime.Today.ToString();
            txtIdentificacion.Clear();
            txtNombres.Clear();
            txtNroLicencia.Clear();
            txtTelefono.Clear();
        }        


        #region Eventos de Búsqueda
            private void btnBuscarlugar_Click(object sender, EventArgs e)
            {
                try
                {
                    object[] listaTransito = serviciosAccesoriasComp.ListarOrganismoTransitoComp();
                    if (listaTransito != null)
                    {
                        organismoTransitoComp organismo = new organismoTransitoComp();
                        ArrayList campos = new ArrayList();
                        campos.Add("NIT = Nit");
                        campos.Add("NOMBRESECRETARIA = Nombre");
                        buscador buscador = new buscador(listaTransito, campos, "Buscador de Organismos", "");
                        if (buscador.ShowDialog() == DialogResult.OK)
                        {
                            organismo = (organismoTransitoComp)funciones.listToOrganismoTransitoComp(buscador.Seleccion);
                            cmbOrgExpide.SelectedValue = organismo.IDORGTRANSITO;
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

            private void btnBuscarCiudad_Click(object sender, EventArgs e)
            {
                try
                {
                    object[] listaciudad = serviciosAccesoriasComp.listarCiudadComp();
                    if (listaciudad != null)
                    {
                        ciudadComp ciudad = new ciudadComp();
                        ArrayList campos = new ArrayList();
                        campos.Add("NOMBRE = Nombre");
                        buscador buscador = new buscador(listaciudad, campos, "Buscador de Ciudades", "");
                        if (buscador.ShowDialog() == DialogResult.OK)
                        {
                            ciudad = (ciudadComp)funciones.listToCiudadCom(buscador.Seleccion);
                            cmbCiudadRes.SelectedValue = ciudad.ID_CIUDAD;
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

            private void btnBuscarInfractor_Click(object sender, EventArgs e)
            {
                try
                {
                    BuscarInfractor();
                }
                catch (Exception exp)
                {
                    log.escribirError(exp.ToString(), this.GetType());
                    funciones.mostrarMensaje("Error realizando la funcionalidad. " + exp.Message, "E");
                    //Console.WriteLine(exp.Message);
                    //Console.WriteLine(exp.StackTrace);
                } 
            }

            private void txtIdentificacionBusq_KeyDown(object sender, KeyEventArgs e)
            {
                try
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        BuscarInfractor();
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

            private void BuscarInfractor()
            {
                if (!string.IsNullOrWhiteSpace(txtIdentificacionBusq.Text) && cmbTipoDocBusq.SelectedIndex > -1)
                {
                    infractor = new infractorComp();

                    infractor.ID_DOCTO = int.Parse(cmbTipoDocBusq.SelectedValue.ToString());
                    infractor.NROIDENTIFICACION = txtIdentificacionBusq.Text;

                    infractor = serviciosGeneralesComp.buscarInfractor(infractor);

                    if (infractor != null && infractor.ID_INFRACTOR > 0)
                    {
                        //new 
                        limpiarDatos();
                        idInfractor = infractor.ID_INFRACTOR;
                        //endnew

                        mostrarDatos();
                    }
                    else
                    {
                        string mensaje = "No se encontró un usuario " + TIPOUSUARIO + " en el sistema con los datos especificados.";
                        funciones.mostrarMensaje(mensaje, "W");
                    }

                }
                else
                {
                    funciones.mostrarMensaje("Debe seleccionar el tipo y número de identificación a buscar.", "W");
                    txtIdentificacionBusq.Focus();
                }
            }
    #endregion

        private void mostrarDatos()
        {
            if (infractor != null && infractor.ID_INFRACTOR > 0)
            {
                funciones.setCombo(cmbTipoDocBusq, infractor.ID_DOCTO);
                funciones.setCombo(cmbTipoDoc, infractor.ID_DOCTO);

                txtIdentificacionBusq.Text = infractor.NROIDENTIFICACION;
                txtIdentificacion.Text = infractor.NROIDENTIFICACION;

                funciones.setCombo(cmbSexo, infractor.ID_SEXO);
                txtNombres.Text = infractor.NOMBRES;
                txtApellidos.Text = infractor.APELLIDOS;

                txtEdad.Text = infractor.EDAD;
                txtDireccion.Text = infractor.DIRECCION;
                txtTelefono.Text = infractor.TELEFONO;
                txtEmail.Text = infractor.EMAIL;

                funciones.setCombo(cmbCiudadRes, infractor.ID_CIUDAD);
                txtNroLicencia.Text = infractor.NROLICCONDUCCION;
                funciones.setCombo(cmbCatLicencia, infractor.CATEGLICENCIA);

                funciones.setCombo(cmbOrgExpide, infractor.ID_TRANSITO);
                txtFecVenLic.Text = DateTime.Parse(infractor.FECHAVENCELICCONDUCCION, System.Globalization.CultureInfo.InvariantCulture).ToString("dd/MM/yyyy");
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                nuevo = true;           
                limpiarDatos();
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
                if (infractor != null && infractor.ID_INFRACTOR>0)
                {
                    nuevo = false;
                    habilitarEdicion(true);
                    habilitarBusqueda(false);
                    habilitarControles(false);
                }
                else
                {
                    funciones.mostrarMensaje("Debe buscar un usuario para editar.", "E");
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
                        infractorComp infractorTemp = new infractorComp();                                               
                        
                        infractorTemp.ID_DOCTO = (int)cmbTipoDoc.SelectedValue;
                        infractorTemp.ID_SEXO = (int)cmbSexo.SelectedValue;
                        infractorTemp.NROIDENTIFICACION = txtIdentificacion.Text;
                        infractorTemp.NOMBRES = txtNombres.Text;
                        infractorTemp.APELLIDOS = txtApellidos.Text;

                        if(cmbCiudadRes.SelectedIndex > -1)
                            infractorTemp.ID_CIUDAD = (int)cmbCiudadRes.SelectedValue;
                        if (cmbOrgExpide.SelectedIndex > -1)                        
                            infractorTemp.ID_TRANSITO = (int)cmbOrgExpide.SelectedValue;
                        
                        infractorTemp.NROLICCONDUCCION = txtNroLicencia.Text;
                        infractorTemp.TELEFONO = txtTelefono.Text;
                        infractorTemp.DIRECCION = txtDireccion.Text;
                        infractorTemp.EDAD = txtEdad.Text;
                        infractorTemp.EMAIL = txtEmail.Text;

                        if(cmbCatLicencia.SelectedIndex > -1)
                            infractorTemp.CATEGLICENCIA = (String)cmbCatLicencia.SelectedValue;

                        infractorTemp.FECHAVENCELICCONDUCCION = funciones.convFormatoFecha(txtFecVenLic.Text, "MM/dd/yyyy");
                        
                        //ENVIAR DATOS AL SERVIDOR
                        idInfractor = serviciosGeneralesComp.crearInfractorComp(infractorTemp, WS.MyUsuario.ID_USUARIO, funciones.obtenerDirIp(), funciones.obtenerHostName());
                        if (idInfractor == -1)
                        {
                            string mensaje = "No fue posible guardar el usuario " + TIPOUSUARIO;
                            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            btnPost.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            string mensaje = "Usuario " + TIPOUSUARIO + " almacenado correctamente";
                            MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.DialogResult = DialogResult.OK;

                            //Actualizar registro infractor
                            infractor = infractorTemp;
                            infractor.ID_INFRACTOR = idInfractor;
                        }
                    }
                    else
                    {
                        infractor.ID_DOCTO = (int)cmbTipoDoc.SelectedValue;
                        infractor.ID_SEXO = (int)cmbSexo.SelectedValue;
                        infractor.NROIDENTIFICACION = txtIdentificacion.Text;
                        infractor.NOMBRES = txtNombres.Text;
                        infractor.APELLIDOS = txtApellidos.Text;

                        if (cmbCiudadRes.SelectedIndex > -1)
                            infractor.ID_CIUDAD = (int)cmbCiudadRes.SelectedValue;
                        if (cmbOrgExpide.SelectedIndex > -1)
                            infractor.ID_TRANSITO = (int)cmbOrgExpide.SelectedValue;

                        infractor.NROLICCONDUCCION = txtNroLicencia.Text;
                        infractor.TELEFONO = txtTelefono.Text;
                        infractor.DIRECCION = txtDireccion.Text;
                        infractor.EDAD = txtEdad.Text;
                        infractor.EMAIL = txtEmail.Text;

                        if (cmbCatLicencia.SelectedIndex > -1)
                            infractor.CATEGLICENCIA = (String)cmbCatLicencia.SelectedValue;

                        infractor.FECHAVENCELICCONDUCCION = funciones.convFormatoFecha(txtFecVenLic.Text, "MM/dd/yyyy");

                        //ENVIAR DATOS AL SERVIDOR
                        if (!serviciosGeneralesComp.actualizarInfractorComp(infractor, WS.MyUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName()))
                        {
                            string mensaje = "No fue posible guardar el usuario " + TIPOUSUARIO;
                            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            btnPost.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            string mensaje = "Usuario " + TIPOUSUARIO + " actualizado correctamente";
                            MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.DialogResult = DialogResult.OK;
                        }

                        idInfractor = infractor.ID_INFRACTOR;
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


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                nuevo = false;

                limpiarDatos();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #region Eventos KEYPRESS


        private void txtNombres_KeyPress(object sender, KeyPressEventArgs e)
            {
                //funciones.esLetra(e);
                funciones.lanzarTapConEnter(e);
            }

            private void txtApellidos_KeyPress(object sender, KeyPressEventArgs e)
            {
                //funciones.esLetra(e);
                funciones.lanzarTapConEnter(e);
            }

            private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.esNumero(e);
                funciones.lanzarTapConEnter(e);
            }

            private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.esNumero(e);
                funciones.lanzarTapConEnter(e);
            }

            private void txtNroLicencia_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.esNumero(e);
                funciones.lanzarTapConEnter(e);
            }

            private void cmbTipoDoc_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }

            private void cmbSexo_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }

            private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }

            private void cmbCiudadRes_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }

            private void cmbCatLicencia_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }

            private void cmbOrgExpide_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }

            private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);

            }
        #endregion

        private bool validarCampos()
        {
            //Obligatorios
            if (cmbTipoDoc.SelectedIndex == -1)
            {
                funciones.mostrarMensaje("Debe seleccionar un tipo de identificación", "W");
                cmbTipoDoc.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtIdentificacion.Text))
            {
                funciones.mostrarMensaje("El campo número de identificacion no pueder ser vacio", "W");
                txtIdentificacion.Focus();
                return false;
            }
            if (cmbSexo.SelectedIndex == -1)
            {
                funciones.mostrarMensaje("Debe seleccionar un sexo", "W");
                cmbSexo.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtNombres.Text))
            {
                funciones.mostrarMensaje("El campo nombre no puede ser vacio", "W");
                txtNombres.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtApellidos.Text))
            {
                funciones.mostrarMensaje("El campo apellido no puede ser vacio", "W");
                txtApellidos.Focus();
                return false;
            }

            //Validar Formato
            if (!string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                if (!funciones.validarCampoEmail(txtEmail))
                {
                    txtEmail.Focus();
                    return false;
                }
            }

            if (cmbCatLicencia.SelectedIndex == -1 && !string.IsNullOrWhiteSpace(txtNroLicencia.Text))
            {
                funciones.mostrarMensaje("Debe seleccionar una categoria para la licencia de transito", "W");
                cmbCatLicencia.Focus();
                return false;
            }

            return true;
        }        



    }
}
