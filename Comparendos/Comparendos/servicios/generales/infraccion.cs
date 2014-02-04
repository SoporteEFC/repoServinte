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
using LibreriasSintrat.utilidades;

namespace Comparendos.servicios.generales
{
    public partial class infraccion : Form
    {
        ServiciosAccesoriasCompService clienteAccesoriasComp;
        Funciones funciones;
        int idinfraccion = 0;

        public infraccion(int idllega)
        {
            InitializeComponent();
            idinfraccion = idllega;
            funciones = new Funciones();
        }

        public void llenarCampos(infraccionesComp lainfraccion)
        {
            codigoinfraccion.Text = lainfraccion.COD_INFRACCION;
            numerosalarios.Text = lainfraccion.NUMEROSALARIO.ToString();
            descripcion.Text = lainfraccion.DESCRIPCION;
            cmbEstado.SelectedItem = lainfraccion.ESTADO;
            nuevocodigo.Text = lainfraccion.NUEVO_CODIGO;

            if (lainfraccion.FECHADESDE != null && !string.IsNullOrWhiteSpace(lainfraccion.FECHADESDE))
                fechadesde.Text = DateTime.Parse(lainfraccion.FECHADESDE, System.Globalization.CultureInfo.InvariantCulture).ToString("dd/MM/yyyy");
            if (lainfraccion.FECHAHASTA != null && !string.IsNullOrWhiteSpace(lainfraccion.FECHAHASTA))
                fechahasta.Text = DateTime.Parse(lainfraccion.FECHAHASTA, System.Globalization.CultureInfo.InvariantCulture).ToString("dd/MM/yyyy"); ;
            
            if (lainfraccion.REPORTARSIMIT == "S")
            {
                reportarsimit.Checked = true;
            }
            else
            {
                reportarsimit.Checked = false;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                if (validarCampos())
                    guardarDatos();
            }
            catch (Exception exp)
            {
                funciones.mostrarMensaje("Ocurrió un error al realizar la funcionalidad: " + exp.Message, "E");
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }

            this.Cursor = Cursors.Arrow;
        }

        private bool validarCampos()
        {
            if (string.IsNullOrWhiteSpace(codigoinfraccion.Text))
            {
                funciones.mostrarMensaje("El campo Código no puede ser vacío", "W");
                codigoinfraccion.Focus();
                return false;
            }
            
            if (string.IsNullOrWhiteSpace(numerosalarios.Text))
            {
                funciones.mostrarMensaje("El campo Número Salarios no puede ser vacío", "W");
                numerosalarios.Focus();
                return false;
            }
            else if (float.Parse(numerosalarios.Text)<=0)
            {
                funciones.mostrarMensaje("El campo Número Salarios no puede ser cero ni negativo", "W");
                numerosalarios.Focus();
                return false;
            }
            
            if (string.IsNullOrWhiteSpace(descripcion.Text))
            {
                funciones.mostrarMensaje("El campo Descripción no puede ser vacío", "W");
                descripcion.Focus();
                return false;
            }                       

            if (cmbEstado.SelectedIndex < 0)
            {
                funciones.mostrarMensaje("El campo Estado no puede ser vacío", "W");
                cmbEstado.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(nuevocodigo.Text))
            {
                funciones.mostrarMensaje("El campo Nuevo Código no puede ser vacío", "W");
                nuevocodigo.Focus();
                return false;
            }

            return true;
        }

        private void guardarDatos()
        {
            clienteAccesoriasComp = WS.ServiciosAccesoriasCompService();
            infraccionesComp infracci = new infraccionesComp();

            infracci.COD_INFRACCION = codigoinfraccion.Text;
            infracci.DESCRIPCION = descripcion.Text;
            infracci.ESTADO = cmbEstado.Text;
            infracci.FECHADESDE = funciones.convFormatoFecha(fechadesde.Text, "MM/dd/yyyy");
            infracci.FECHAHASTA = funciones.convFormatoFecha(fechahasta.Text, "MM/dd/yyyy");
            infracci.NUEVO_CODIGO = nuevocodigo.Text;
            infracci.NUMEROSALARIO = Double.Parse(numerosalarios.Text);
            
            if (reportarsimit.Checked == true)
            {
                infracci.REPORTARSIMIT = "S";
            }
            else
            {
                infracci.REPORTARSIMIT = "";
            }

            if (idinfraccion > 0)
            {
                infracci.ID_INFRACCION = idinfraccion;
                Boolean ediinfrac = clienteAccesoriasComp.editarInfraccionesComp(infracci);

                if (ediinfrac == true)
                {
                    MessageBox.Show("Modificación Exitosa");
                    configurarinfracciones config = new configurarinfracciones();
                    config.mostrarInfracciones();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error en Modificación");
                    this.Close();
                }
            }
            else if(idinfraccion==0)
            {
                Boolean insinfrac = clienteAccesoriasComp.crearInfraccionesComp(infracci);

                if (insinfrac == true)
                {
                    MessageBox.Show("Registro Exitoso");
                    configurarinfracciones config = new configurarinfracciones();
                    config.mostrarInfracciones();
                    this.DialogResult=DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error en Registro");
                    this.DialogResult = DialogResult.Abort;
                    this.Close();
                }
            }
        }

        #region Eventos KEYPRESS
            private void numerosalarios_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.esDecimal(e);
                funciones.lanzarTapConEnter(e);
            }

            private void codigoinfraccion_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.esNumero(e);
                funciones.lanzarTapConEnter(e);
            }            

            private void nuevocodigo_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }

            private void fechadesde_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }

            private void fechahasta_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }

            private void reportarsimit_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }
        #endregion
    }
}
