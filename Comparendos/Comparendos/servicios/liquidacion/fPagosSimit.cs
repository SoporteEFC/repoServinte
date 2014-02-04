using System; using TransitoPrincipal; using LibreriasSintrat.utilidades;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Comparendos.utilidades; 
using LibreriasSintrat;
using LibreriasSintrat.ServiciosGeneralesComp;
using LibreriasSintrat.ServiciosAccesoriasComp;
using LibreriasSintrat.ServiciosUsuarios;
using LibreriasSintrat.ServiciosPagosSimit;
using System.Collections;

namespace Comparendos.servicios.liquidacion
{
    public partial class fPagosSimit : Form
    {
        Funciones funcionesGenerales;
        ServiciosGeneralesCompService mySerGen;
        ServiciosAccesoriasCompService mySerAccComp;
        usuarios myUsuario;
        
        object[] comparendos;

        public fPagosSimit(usuarios user)
        {
            InitializeComponent();
            funcionesGenerales = new Funciones();
            mySerGen = WS.ServiciosGeneralesCompService();
            mySerAccComp = WS.ServiciosAccesoriasCompService();
            funcionesGenerales.llenarCombo(cmbTipoDocumento, mySerAccComp.obtenerTiposDocumento());
            myUsuario = user;
        }

        //Buscar infractor y comparendos en estado liquidado o ingresado de ese infractor
        private void actualizarInfractorComparendos()
        {            
            comparendos = null;
            tblComparendos.DataSource = null;

            infractorComp infractor = new infractorComp();
            infractor.NROIDENTIFICACION = txtIdentificacion.Text;
            infractor.ID_DOCTO = int.Parse(cmbTipoDocumento.SelectedValue.ToString());
            infractor = mySerGen.buscarInfractor(infractor);
            if (infractor != null && infractor.ID_INFRACTOR > 0)
            {
                txtApellido.Text = infractor.APELLIDOS;
                txtNombre.Text = infractor.NOMBRES;

                comparendoComp myComparendo = new comparendoComp();
                object[] listaComp;

                myComparendo.ID_INFRACTOR = infractor.ID_INFRACTOR;
                listaComp = mySerGen.searchComparendo(myComparendo);

                if (listaComp != null)
                {
                    for (int i = 0; i < listaComp.Length; i++)
                    {
                        myComparendo = (comparendoComp)listaComp[i];

                        infracionComparendoComp infraccion = new infracionComparendoComp();
                        infraccion.IDCOMPARENDO = myComparendo.ID_COMPARENDO;
                        infraccion = mySerGen.getInfraccionComparendo(infraccion);

                        if (infraccion != null && infraccion.ID > 0)
                        {
                            //Si el comparendo esta liquidado o ingresado
                            if (infraccion.IDESTADO == 11 || infraccion.IDESTADO == 10)
                            {
                                ArrayList compa = new ArrayList();
                                compa.Add(myComparendo);
                                comparendos = funcionesGenerales.unirArrayObject(comparendos, compa.ToArray());
                            }
                        }
                    }
                    //comparendos = listaComp;
                    if (comparendos != null)
                    {
                        LlenarTblComparendos();
                        btnRegistrar.Enabled = true;
                        txtNumeroReciboSimit.Enabled = true;
                        txtValor.Enabled = true;
                        dtpFechaPagoSimit.Enabled = true;
                    }
                    else
                    {
                        funcionesGenerales.mostrarMensaje("No se encontraron Comparendos en estado liquidado o ingresado para ese infractor!", "W");
                        btnRegistrar.Enabled = false;
                        txtNumeroReciboSimit.Enabled = false;
                        txtValor.Enabled = false;
                        dtpFechaPagoSimit.Enabled = false;
                        tblComparendos.DataSource = null;
                    }
                }
                else
                {
                    funcionesGenerales.mostrarMensaje("No se enontraron comparendos para ese infractor!", "W");
                }
            }
            else
            {
                funcionesGenerales.mostrarMensaje("No se encontro al infractor!", "W");
            }
        }

        //Llenar grilla con los comparendos encontrados
        private void LlenarTblComparendos()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("#");
            dt.Columns.Add("NUMERO COMPARENDO");
            dt.Columns.Add("POLCA");
            dt.Columns.Add("VEHICULO");
            dt.Columns.Add("VALOR");
            dt.Columns.Add("FECHA");
            dt.Columns.Add("FECHA REGISTRO");
            dt.Columns.Add("ID_COMPARENDO");

            DataRow dr;
            comparendoComp comparendo;
            for (int i = 0; i < comparendos.Length; i++)
            {
                dr = dt.NewRow();
                comparendo = (comparendoComp)comparendos[i];
                dr["#"] = "" + i;
                dr["NUMERO COMPARENDO"] = comparendo.NUMEROCOMPARENDO;
                dr["POLCA"] = comparendo.POLCA;
                dr["VEHICULO"] = comparendo.PLACA;
                dr["VALOR"] = comparendo.VALOR;
                dr["FECHA"] = DateTime.Parse(comparendo.FECHACOMPARENDO, System.Globalization.CultureInfo.InvariantCulture).ToString("dd/MM/yyyy");
                dr["FECHA REGISTRO"] = DateTime.Parse(comparendo.FECHAREGISTRO, System.Globalization.CultureInfo.InvariantCulture).ToString("dd/MM/yyyy");
                dr["ID_COMPARENDO"] = comparendo.ID_COMPARENDO;
                dt.Rows.Add(dr);
            }

            tblComparendos.DataSource = dt;
            tblComparendos.Columns["ID_COMPARENDO"].Visible = false;
        }   

        private bool validarDatosBusqueda()
        {
            if (string.IsNullOrWhiteSpace(txtIdentificacion.Text))
            {
                funcionesGenerales.mostrarMensaje("El campo de identificación no puede ser vacío!", "W");
                txtIdentificacion.Focus();
                return false;
            }
            if (cmbTipoDocumento.SelectedIndex < 0)
            {
                funcionesGenerales.mostrarMensaje("Debe seleccionar un tipo de documento!!", "W");
                cmbTipoDocumento.Focus();
                return false;
            }
            return true;
        }

        private bool validarDatosRegistro()
        {
            if (string.IsNullOrWhiteSpace(txtNumeroReciboSimit.Text))
            {
                funcionesGenerales.mostrarMensaje("El campo número de recibo no puede ser vacío!", "W");
                txtNumeroReciboSimit.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtValor.Text))
            {
                funcionesGenerales.mostrarMensaje("El campo valor no puede ser vacío!", "W");
                txtValor.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(dtpFechaPagoSimit.Text))
            {
                funcionesGenerales.mostrarMensaje("Debe indicar la fecha de pago!!", "W");
                dtpFechaPagoSimit.Focus();
                return false;
            }
            return true;
        }
     


        private void btnBucar_Click(object sender, EventArgs e)
        {
            try
            {
                if (validarDatosBusqueda())
                {
                    actualizarInfractorComparendos();
                }
            }
            catch (Exception exp)
            {                
                WS.Funciones().mostrarMensaje("Error ejecutando la función. " + exp.Message, "E");
            }
        }
        
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                if (validarDatosRegistro())
                {
                    if (tblComparendos.SelectedCells.Count > 0)
                    {
                        ServiciosPagosSimitService mySerPagosSimit = WS.ServiciosPagosSimitService();
                        pagosSimit pagoSimit = new pagosSimit();
                        
                        int idComparendo = int.Parse(tblComparendos.SelectedRows[0].Cells["ID_COMPARENDO"].Value.ToString());

                        comparendoComp myComparendo = new comparendoComp();
                        myComparendo.ID_COMPARENDO = idComparendo;
                        object[] listaComparendo = mySerGen.searchComparendo(myComparendo);

                        if (listaComparendo != null)
                        {
                            myComparendo = (comparendoComp)listaComparendo[0];

                            //Se asigna el pago del simit
                            pagoSimit.NUMEROCOMPARENDO = myComparendo.NUMEROCOMPARENDO;

                            //Se almacena la fecha del comparendo
                            pagoSimit.FECHACOMPARENDO = myComparendo.FECHACOMPARENDO;

                            infracionComparendoComp infraccionComp = new infracionComparendoComp();
                            infraccionComp.IDCOMPARENDO = myComparendo.ID_COMPARENDO;
                            infraccionComp = mySerGen.getInfraccionComparendo(infraccionComp);

                            if (infraccionComp != null && infraccionComp.ID > 0)
                            {
                                pagoSimit.IDINFRACCION = infraccionComp.IDINFRACCION;
                                
                                infractorComp infractor = new infractorComp();
                                infractor.ID_INFRACTOR = myComparendo.ID_INFRACTOR;
                                infractor = mySerGen.buscarInfractor(infractor);

                                if (infractor != null && infractor.ID_INFRACTOR > 0)
                                {
                                    pagoSimit.IDENTIFICACION = infractor.NROIDENTIFICACION;
                                    pagoSimit.IDUSUARIO = myUsuario.ID_USUARIO;
                                    pagoSimit.NUMERORECIBO = txtNumeroReciboSimit.Text;
                                    pagoSimit.VALOR = double.Parse(txtValor.Text);
                                    pagoSimit.FECHAPAGO = funcionesGenerales.convFormatoFecha(dtpFechaPagoSimit.Text, "MM/dd/yyyy");

                                    if (mySerPagosSimit.createPagosSimit(pagoSimit, WS.MyUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName()))
                                    {
                                        funcionesGenerales.mostrarMensaje("Se registro correctamente el pago!", "I");
                                        //Actualizar el estado del comparendo
                                        //Se cambia el estado del comparendo a pagado
                                        infraccionComp.IDESTADO = 2;                                        
                                        if (!mySerGen.actualizarInfraccionComparendo(infraccionComp, WS.MyUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName()))
                                            funcionesGenerales.mostrarMensaje("No se pudo actualizar el estado del comparendo!. Consulte con el administrador.", "E");
                                        else
                                            //Actualizar grilla comparendos
                                            actualizarInfractorComparendos();
                                    }
                                    else                                    
                                        funcionesGenerales.mostrarMensaje("No se pudo registrar el pago!", "E");                                    
                                }
                                else
                                    funcionesGenerales.mostrarMensaje("Ocurrió un error al buscar el infractor asociado al comparendo!", "E");                                                                    
                            }
                            else
                                funcionesGenerales.mostrarMensaje("Ocurrió un error al buscar la infracción asociada al comparendo!", "E");
                        }
                        else
                            funcionesGenerales.mostrarMensaje("Comparendo no encontrado en la Base de Datos", "I");
                    }
                    else
                        MessageBox.Show("Debe seleccionar un comparendo!");
                }
            }
            catch (Exception exp)
            {
                WS.Funciones().mostrarMensaje("Error ejecutando la función. " + exp.Message, "E");                    
            }

            this.Cursor = Cursors.Arrow;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #region Eventos KeyPress

            private void txtIdentificacion_KeyPress(object sender, KeyPressEventArgs e)
            {
                try
                {
                    funcionesGenerales.esNumero(e);
                    if (e.KeyChar == Convert.ToChar(Keys.Enter))
                    {
                        actualizarInfractorComparendos();
                    }
                }
                catch (Exception exp)
                {
                    WS.Funciones().mostrarMensaje("Error ejecutando la función. " + exp.Message, "E");
                }
            }

            private void txtNumeroReciboSimit_KeyPress(object sender, KeyPressEventArgs e)
            {
                //funcionesGenerales.e(e);
                funcionesGenerales.lanzarTapConEnter(e);
            }

            private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
            {
                funcionesGenerales.esDecimal(e);
            }

            private void cmbTipoDocumento_KeyPress(object sender, KeyPressEventArgs e)
            {
                funcionesGenerales.lanzarTapConEnter(e);
            }

            private void dtpFechaPagoSimit_KeyPress(object sender, KeyPressEventArgs e)
            {
                funcionesGenerales.lanzarTapConEnter(e);
            }
        #endregion
    }
}
