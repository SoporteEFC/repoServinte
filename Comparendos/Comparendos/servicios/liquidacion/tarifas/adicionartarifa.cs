using System; using TransitoPrincipal; using LibreriasSintrat.utilidades;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibreriasSintrat.ServiciosTarifas;
using LibreriasSintrat.ServiciosAccesorias;
using LibreriasSintrat.ServiciosComparendos;
using LibreriasSintrat.ServiciosTarifasComp;
using LibreriasSintrat.ServiciosUsuarios;

namespace Comparendos
{
    public partial class AdicionarTarifa : Form
    {
        usuarios myUsuario;
        //ServiciosTarifasService clienteTarifas;
        //ServiciosAccesoriasService clienteAccesorias;
        ServiciosTarifasCompService clienteTarifasComp;
        Funciones funciones;
        int vigenciaActual = 0;

        public AdicionarTarifa(int vigenc, usuarios user)
        {
            myUsuario = user;
            vigenciaActual = vigenc;
            InitializeComponent();
        }

        private void AdicionarTarifa_Load(object sender, EventArgs e)
        {
            rbtImpuesto.Visible = false;
            tipotarifa.Height = 50;            

            //clienteAccesorias = WS.ServiciosAccesoriasService();
            clienteTarifasComp = WS.ServiciosTarifasCompService();
            funciones = new Funciones();
            rbtTramite.Checked = true;

            tramiteContravencionalComp tramitecontravenc = new tramiteContravencionalComp();
            Object[] listacontravencionales = (Object[])clienteTarifasComp.getTramitesContravencional(tramitecontravenc);

            if (listacontravencionales != null)
            {
                Object[] nlistacontravencionales = new Object[listacontravencionales.Length + 1];

                tramitecontravenc.IDTRAMITE_CONTRAVENCIONAL = 0;
                tramitecontravenc.DESC_TRAMITECONTRAVENCIONAL = "NO ASOCIADO A TRAMITE";
                nlistacontravencionales[0] = tramitecontravenc;
                int y = 0;
                for (int w = 1; w < listacontravencionales.Length + 1; w++)
                {
                    nlistacontravencionales[w] = listacontravencionales[y];
                    y++;
                }

                cmbTramiteAsociado.DataSource = null;
                cmbTramiteAsociado.DisplayMember = "DESC_TRAMITECONTRAVENCIONAL";
                cmbTramiteAsociado.ValueMember = "IDTRAMITE_CONTRAVENCIONAL";

                funciones.llenarCombo(cmbTramiteAsociado, nlistacontravencionales);

                txtVigencia.Text = vigenciaActual.ToString();
            }            
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                clienteTarifasComp = WS.ServiciosTarifasCompService();

                ltarifasComp nuevatarifacomp = new ltarifasComp();
                
                nuevatarifacomp.LT_ACTIVA = 1;
                nuevatarifacomp.LT_CONDICIONES = "";
                nuevatarifacomp.LT_DESCRIPCION = txtDescripcion.Text;
                if (cmbTramiteAsociado.SelectedIndex > -1)
                    nuevatarifacomp.LT_IDTRAM_CONTRAV = Int32.Parse(cmbTramiteAsociado.SelectedValue.ToString());
                else
                    nuevatarifacomp.LT_IDTRAM_CONTRAV = 0;
                
                if (chkLiquidacionMultiple.Checked == true)
                {
                    nuevatarifacomp.LT_LIQMULTIPLE = 1;
                }
                else
                {
                    nuevatarifacomp.LT_LIQMULTIPLE = 0;
                }
                
                nuevatarifacomp.LT_MULTGRUPOLIQ = "";                
                nuevatarifacomp.LT_NOMBRE = txtNombreTarifa.Text;
                nuevatarifacomp.LT_VIGENCIA = Int32.Parse(txtVigencia.Text);                
                nuevatarifacomp.LT_TIPO = 2;
                
                Boolean restarcomp = clienteTarifasComp.crearTarifas(nuevatarifacomp, WS.MyUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName());
                if (restarcomp == true)
                {
                    MessageBox.Show("Registro Exitoso");
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error en el Registro");
                }
                
            }
        }

        private bool validarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombreTarifa.Text))
            {
                MessageBox.Show("El campo Nombre no puede ser vacío");
                txtNombreTarifa.Focus();
                return false;
            }
            
            if (string.IsNullOrWhiteSpace(txtVigencia.Text))
            {                
                MessageBox.Show("El campo Vigencia no puede ser vacío");
                txtVigencia.Focus();
                return false;
            }            

            if (cmbTramiteAsociado.SelectedIndex < 0)
            {
                cmbTramiteAsociado.Focus();
                MessageBox.Show("Debe seleccionar un trámite");
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void vigentarifa_TextChanged(object sender, EventArgs e)
        {
            funciones = new Funciones();
            funciones.soloNumeros(txtVigencia);
        }

        #region Eventos KeyPress
            private void tramite_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }

            private void impuesto_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }

            private void nombretarifa_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }

            private void vigentarifa_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }

            private void tramiteasoc_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }

            private void clasevehiculo_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }

            private void variasliquidaciones_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }
        #endregion
    }
}
