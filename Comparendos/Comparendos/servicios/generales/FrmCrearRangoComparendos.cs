using System; using TransitoPrincipal; using LibreriasSintrat.utilidades;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibreriasSintrat.ServiciosRangosDeComparendos;
using LibreriasSintrat.ServiciosComparendos;
using LibreriasSintrat.ServiciosAccesoriasComp;
using LibreriasSintrat.ServiciosGeneralesComp;
using Comparendos.utilidades; using LibreriasSintrat;


//using elGuille.Developer.LibTomMath;
//using elGuille.Developer.FSharp;

namespace Comparendos.servicios.generales
{
    public partial class FrmCrearRangoComparendos : Form
    {
        ServiciosRangosDeComparendosService clienteRangoComp;
        ServiciosAccesoriasCompService SerAccComp;
        rangosDeComparendos rangoComparendos;
        Funciones funciones;
        Object[] listaRangosComparendos;
        Boolean nuevo = false;
        int posicionActual;
        Log log = new Log();
        

        public FrmCrearRangoComparendos(ServiciosAccesoriasCompService clienteAccesoriasComp)
        {
            InitializeComponent();
            SerAccComp = clienteAccesoriasComp;
            clienteRangoComp = WS.ServiciosRangosDeComparendosService();
            funciones = new Funciones();
            log = new Log();
        }

        private void FrmCrearRangoComparendos_Load(object sender, EventArgs e)
        {
            try
            {
                cargarDatos();
                posicionActual = 0;
                mostrarDatosRangoActual();
                habilitarCampos(false);
                habilitarControles(true);
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

    #region Funciones Utilitarias
        public void cargarDatos()
        {            
            listaRangosComparendos = (Object[])clienteRangoComp.getRangosDeComparendos();
            if (listaRangosComparendos != null && listaRangosComparendos.Length > 0)
            {
                habilitarCampos(false);
            }
            else
            {
                MessageBox.Show("No hay Rangos Registrados", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
        }

        public void mostrarDatosRangoActual()
        {
            if (listaRangosComparendos != null && posicionActual < listaRangosComparendos.Length)
            {
                rangoComparendos = (rangosDeComparendos)listaRangosComparendos[posicionActual];
                txtRangoInicial.Text = rangoComparendos.RANGOINICIAL;
                txtRangoFinal.Text = rangoComparendos.RANGOFINAL;
                txtNumeroDocumentoAsignacion.Text = rangoComparendos.NRORESOLASIGNACION;
                dtpFechaAsignacion.Text = DateTime.Parse(rangoComparendos.FECHAASIGNACIONRANGOS, System.Globalization.CultureInfo.InvariantCulture).ToString("dd/MM/yyyy");
                txtCantidadRango.Text = rangoComparendos.CANTIDADRANGOS.ToString();
            }
        }

        public void Limpiar() 
        {
            txtRangoInicial.Clear();
            txtRangoFinal.Clear();
            txtNumeroDocumentoAsignacion.Clear();
            txtCantidadRango.Clear();
        }

        private void habilitarCampos(bool habilitar)
        {
            txtRangoInicial.Enabled = habilitar;
            txtRangoFinal.Enabled = habilitar;
            txtNumeroDocumentoAsignacion.Enabled = habilitar;
            dtpFechaAsignacion.Enabled = habilitar;

            btnSave.Enabled = habilitar;
            btnCancel.Enabled = habilitar;
        }

        private void habilitarControles(bool estado)
        {
            btnAdd.Enabled = estado;
            btnEdit.Enabled = estado;
            btnDelete.Enabled = estado;

            btnFirst.Enabled = estado;
            btnLast.Enabled = estado;
            btnNext.Enabled = estado;
            btnPrevious.Enabled = estado;
        }

        private void calcularCantidadRango()
        {
            ////BigNum cantidadRangos = 0;
            ////BigNum rangoInicial = txtRangoInicial.Text;
            ////BigNum rangoFinal = txtRangoFinal.Text;

            //BigFloat cantidadRangos = 0;
            //BigFloat rangoInicial = txtRangoInicial.Text;
            //BigFloat rangoFinal = txtRangoFinal.Text;

            ////BigInt cantidadRangos = 0;
            ////BigInt rangoInicial = txtRangoInicial.Text;
            ////BigInt rangoFinal = txtRangoFinal.Text;

            //cantidadRangos = (rangoFinal - rangoInicial) + 1;
            //txtCantidadRango.Text = cantidadRangos.ToString();
                        
            
            float cantidadRangos = float.Parse(funciones.getnro(txtRangoFinal.Text, txtRangoInicial.Text)) - float.Parse(funciones.getnro(txtRangoInicial.Text, txtRangoFinal.Text)) + 1;            
            txtCantidadRango.Text = cantidadRangos.ToString();
            

            //int cantidadRangos = 0;
            //int rangoInicial = 0;
            //int rangoFinal = 0;

            //int.TryParse(txtRangoFinal.Text, out rangoFinal);
            //int.TryParse(txtRangoInicial.Text, out rangoInicial);

            //cantidadRangos = (rangoFinal - rangoInicial) + 1;
            //txtCantidadRango.Text = cantidadRangos.ToString();
        }

        public bool validar()
        {
            //Obligatorios
            if (txtRangoInicial.Text == "")
            {
                funciones.mostrarMensaje("Se debe digitar un Rango Inicial", "W");
                txtRangoInicial.Focus();
                return false;
            }
            if (txtRangoFinal.Text == "") 
            {
                funciones.mostrarMensaje("Se debe digitar un Rango Final", "W");
                txtRangoFinal.Focus();
                return false;
            }
            

            //Longitud Rangos
            if (txtRangoInicial.Text.Length != 20)
            {
                funciones.mostrarMensaje("El Rango Inicial debe contener exactamente 20 caracteres", "W");
                txtRangoInicial.Focus();
                return false;
            }

            if (txtRangoFinal.Text.Length != 20)
            {
                funciones.mostrarMensaje("El Rango Final debe contener exactamente 20 caracteres", "W");
                txtRangoFinal.Focus();
                return false;
            }
            
            //Rango inicial menor            
            if(!Funciones.menorOIgual(txtRangoInicial.Text, txtRangoFinal.Text))
            {
                funciones.mostrarMensaje("El Rango Inicial debe ser menor que el Rango Final", "W");
                txtRangoInicial.Focus();                
                return false;
            }

            //Obligatorios
            if (txtNumeroDocumentoAsignacion.Text == "")
            {
                funciones.mostrarMensaje("Se debe digitar el Numero de Documento de Asignación", "W");
                txtNumeroDocumentoAsignacion.Focus();
                return false;
            }

            if (txtCantidadRango.Text == "")
            {
                funciones.mostrarMensaje("Se debe digitar la Cantidad de Rango", "W");
                txtCantidadRango.Focus();
                return false;
            }

            //Validar intersección de los rangos
            if (listaRangosComparendos != null)
            {
                for (int i = 0; i < listaRangosComparendos.Length; i++)
                {
                    rangosDeComparendos rangoTmp = (rangosDeComparendos)listaRangosComparendos[i];

                    //Se excluye de la comparación el rango actual (por razones obvias)
                    if (rangoComparendos.ID_RANGOCOMPARENDO != rangoTmp.ID_RANGOCOMPARENDO)
                    {
                        //Verificar si el rango inicial o el final a insertar se encuentra en medio de otro rango existente
                        string rangoInicial = txtRangoInicial.Text;
                        string rangoFinal = txtRangoFinal.Text;
                        string rangoInicialTemp = rangoTmp.RANGOINICIAL;
                        string rangoFinalTemp = rangoTmp.RANGOFINAL;

                        ////Tiempo para que librerias realice la comparación
                        System.Threading.Thread.Sleep(1000);

                        //El rango a crear contiene a un rango inicial creado
                        bool caso1 = Funciones.menorOIgual(rangoInicial, rangoInicialTemp) && Funciones.menorOIgual(rangoInicialTemp, rangoFinal);
                        ////Tiempo para que librerias realice la comparación
                        //System.Threading.Thread.Sleep(1000);
                        
                        //El rango a crear contiene a un rango final creado
                        bool caso2 = Funciones.menorOIgual(rangoInicial, rangoFinalTemp) && Funciones.menorOIgual(rangoFinalTemp, rangoFinal);
                        ////Tiempo para que librerias realice la comparación
                        //System.Threading.Thread.Sleep(1000);
                        
                        //El rango a crear está contenido en un rango creado
                        bool caso3 = Funciones.menorOIgual(rangoInicialTemp, rangoInicial) && Funciones.menorOIgual(rangoInicial, rangoFinalTemp);
                        ////Tiempo para que librerias realice la comparación
                        //System.Threading.Thread.Sleep(1000);

                        if ( caso1 || caso2 || caso3)                            
                        {                            
                            funciones.mostrarMensaje("El rango a ingresar se interseca (o cruza) con el rango existente con número de asignación = " + rangoTmp.NRORESOLASIGNACION + ", el cual inicia en: " + rangoTmp.RANGOINICIAL + " y finaliza en: " + rangoTmp.RANGOFINAL + ".", "W");
                            txtRangoInicial.Focus();
                            return false;
                        }
                    }
                }
            }
                
            return true;
            
        }

    #endregion
        
                
        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                nuevo = true;
                
                Limpiar();
                habilitarCampos(true);
                habilitarControles(false);

                //Obtener Prefijo
                ServiciosGeneralesCompService mySerGen = WS.ServiciosGeneralesCompService();
                if (MessageBox.Show("El tipo de comparendo a ingresar es de policia urbana?", "Pregunta?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //txtRangoInicial.Text = "19001000000000";
                    //txtRangoFinal.Text = "19001000000000";
                    txtRangoInicial.Text = mySerGen.getNITTransito() + "000000";
                    txtRangoFinal.Text = mySerGen.getNITTransito() + "000000";
                }
                else
                {
                    //txtRangoInicial.Text = "99999999000000";
                    //txtRangoFinal.Text = "99999999000000";
                    txtRangoInicial.Text = mySerGen.getPrefijoPol() + "000000";
                    txtRangoFinal.Text = mySerGen.getPrefijoPol() + "000000";
                }
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error realizando la funcionalidad: " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
            
            this.Cursor = Cursors.Arrow;
        }        

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                nuevo = false;
                habilitarCampos(true);
                habilitarControles(false);
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }        

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                if (listaRangosComparendos != null)
                {
                    if (MessageBox.Show("¿Esta completamente seguro(a) de eliminar este Rango de Comparendos?", "Confirmación", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {

                        rangoComparendos = new rangosDeComparendos();
                        rangoComparendos = (rangosDeComparendos)listaRangosComparendos[posicionActual];

                        bool borrado = clienteRangoComp.eliminarRangosdecomparendos(rangoComparendos);

                        if (borrado)
                            MessageBox.Show("El Rango se ha eliminado correctamente", "Operación Completada");
                        else
                            throw new Exception();

                        cargarDatos();
                        posicionActual = 0;
                        mostrarDatosRangoActual();
                    }                
                }
                else
                { MessageBox.Show("No hay rangos creados", "Información"); }
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                WS.Funciones().mostrarMensaje("Error al borrar el rango de comparendos. El rango sólo se puede borrar si no ha sido asignado a una comparendera", "E");
            }

            this.Cursor = Cursors.Arrow;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                if (validar())
                {
                    if (nuevo)
                    {
                        rangoComparendos = new rangosDeComparendos();
                        rangoComparendos.RANGOINICIAL = txtRangoInicial.Text;
                        rangoComparendos.RANGOFINAL = txtRangoFinal.Text;
                        rangoComparendos.NRORESOLASIGNACION = txtNumeroDocumentoAsignacion.Text;
                        rangoComparendos.FECHAASIGNACIONRANGOS = funciones.convFormatoFecha(dtpFechaAsignacion.Text, "MM/dd/yyyy");
                        rangoComparendos.CANTIDADRANGOS = int.Parse(txtCantidadRango.Text);

                        rangoComparendos = clienteRangoComp.createRangosDeComparendos(rangoComparendos);
                        if (rangoComparendos!=null && rangoComparendos.ID_RANGOCOMPARENDO > 0)
                        {
                            MessageBox.Show("Se creo el rango desde: " + rangoComparendos.RANGOINICIAL + " Hasta: " + rangoComparendos.RANGOFINAL, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            //Actualizar Datos Interfaz
                            cargarDatos();
                            if (listaRangosComparendos != null)
                                posicionActual = listaRangosComparendos.Length - 1;
                            Limpiar();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo crear el rango de comparendos!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        if (listaRangosComparendos != null)
                        {
                            rangoComparendos = (rangosDeComparendos)listaRangosComparendos[posicionActual];
                            rangoComparendos.RANGOINICIAL = txtRangoInicial.Text;
                            rangoComparendos.RANGOFINAL = txtRangoFinal.Text;
                            rangoComparendos.NRORESOLASIGNACION = txtNumeroDocumentoAsignacion.Text;
                            rangoComparendos.FECHAASIGNACIONRANGOS = funciones.convFormatoFecha(dtpFechaAsignacion.Text, "MM/dd/yyyy");
                            rangoComparendos.CANTIDADRANGOS = int.Parse(txtCantidadRango.Text);

                            if (clienteRangoComp.saveRangosDeComparendos(rangoComparendos))
                            {
                                MessageBox.Show("Modificación realizada con éxito!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("No se pudo realizar la modificación!. El rango sólo se puede editar si NO ha sido asignado a una comparendera.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            cargarDatos();
                        }
                    }
                    /*if (listaInicial != null && listaInicial.Length > 0 || listaFinal != null && listaFinal.Length > 0)
                    {
                        MessageBox.Show("El rango desde: " + rangoComparendos.RANGOINICIAL + "Hasta: " + rangoComparendos.RANGOFINAL + "Ya fue Creado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtRangoInicial.Clear();
                        txtRangoFinal.Clear();
                        txtNumeroDocumentoAsignacion.Clear();
                        txtCantidadRango.Clear();
                    }*/
                    habilitarCampos(false);
                    habilitarControles(true);
                    mostrarDatosRangoActual();

                    nuevo = false;
                }
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }

            this.Cursor = Cursors.Arrow;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Limpiar();
                habilitarControles(true);
                habilitarCampos(false);

                mostrarDatosRangoActual();
                
                //cargarDatos();                
                //btnFirst.Enabled = true;
                //btnLast.Enabled = true;
                //btnNext.Enabled = true;
                //btnPrevious.Enabled = true;

            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }
        


        #region EVENTOS KEYPRESS

            private void txtNumeroDocumentoAsignacion_KeyPress(object sender, KeyPressEventArgs e)
            {
                try
                {
                    funciones.lanzarTapConEnter(e);
                }
                catch (Exception exp)
                {
                    log.escribirError(exp.ToString(), this.GetType());
                    MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                    //Console.WriteLine(exp.Message);
                    //Console.WriteLine(exp.StackTrace);
                }
            }

            private void dtpFechaAsignacion_KeyPress(object sender, KeyPressEventArgs e)
            {
                try
                {
                    funciones.lanzarTapConEnter(e);
                }
                catch (Exception exp)
                {
                    log.escribirError(exp.ToString(), this.GetType());
                    MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                    //Console.WriteLine(exp.Message);
                    //Console.WriteLine(exp.StackTrace);
                }
            }

            private void txtRangoInicial_KeyPress(object sender, KeyPressEventArgs e)
            {
                try
                {
                    funciones.esNumero(e);                    

                    ////Actualizar cantidad rango
                    //calcularCantidadRango();

                    funciones.validarCampoObligatorio(txtRangoFinal, e);
                }
                catch (Exception exp)
                {
                    log.escribirError(exp.ToString(), this.GetType());
                    MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                    //Console.WriteLine(exp.Message);
                    //Console.WriteLine(exp.StackTrace);
                }
            }

            private void txtRangoFinal_KeyPress(object sender, KeyPressEventArgs e)
            {
                try
                {
                    funciones.esNumero(e);

                    ////Actualizar cantidad rango
                    //calcularCantidadRango();

                    funciones.lanzarTapConEnter(e);                    
                }
                catch (Exception exp)
                {
                    log.escribirError(exp.ToString(), this.GetType());
                    MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                    //Console.WriteLine(exp.Message);
                    //Console.WriteLine(exp.StackTrace);
                }
            }            

        #endregion

        #region Botones de Navegación

            private void btnFirst_Click(object sender, EventArgs e)
            {
                try
                {
                    posicionActual = 0;
                    mostrarDatosRangoActual();
                }
                catch (Exception exp)
                {
                    log.escribirError(exp.ToString(), this.GetType());
                    MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                    //Console.WriteLine(exp.Message);
                    //Console.WriteLine(exp.StackTrace);
                }
            }

            private void btnLast_Click(object sender, EventArgs e)
            {
                try
                {
                    if (listaRangosComparendos != null)
                    {
                        posicionActual = listaRangosComparendos.Length - 1;
                        mostrarDatosRangoActual();
                    }
                }
                catch (Exception exp)
                {
                    log.escribirError(exp.ToString(), this.GetType());
                    MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                    //Console.WriteLine(exp.Message);
                    //Console.WriteLine(exp.StackTrace);
                }
            }

            private void btnPrevious_Click(object sender, EventArgs e)
            {
                try
                {
                    if (posicionActual > 0)
                    {
                        posicionActual--;
                        mostrarDatosRangoActual();
                    }
                    else
                        MessageBox.Show("No hay Rango previos a este", "Esta en el Límite", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception exp)
                {
                    log.escribirError(exp.ToString(), this.GetType());
                    MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                    //Console.WriteLine(exp.Message);
                    //Console.WriteLine(exp.StackTrace);
                }
            }

            private void btnNext_Click(object sender, EventArgs e)
            {
                try
                {
                    if (listaRangosComparendos != null)
                    {
                        if (posicionActual < listaRangosComparendos.Length - 1)
                        {
                            posicionActual++;
                            mostrarDatosRangoActual();
                        }
                        else
                            MessageBox.Show("No hay Rangos posteriores a este", "Esta en el Limite", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception exp)
                {
                    log.escribirError(exp.ToString(), this.GetType());
                    MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                    //Console.WriteLine(exp.Message);
                    //Console.WriteLine(exp.StackTrace);
                }
            }

        #endregion                        

        private void txtRangoInicial_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                //Actualizar cantidad rango
                calcularCantidadRango();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }            
        }

        private void txtRangoFinal_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                //Actualizar cantidad rango
                calcularCantidadRango();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

    }
}
