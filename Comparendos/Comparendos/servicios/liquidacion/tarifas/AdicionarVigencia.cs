using System; using TransitoPrincipal; using LibreriasSintrat.utilidades;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibreriasSintrat.ServiciosTarifas;
using LibreriasSintrat.ServiciosComparendos;
using LibreriasSintrat.ServiciosUsuarios;

namespace Comparendos
{
    public partial class AdicionarVigencia : Form
    {
        usuarios myUsuario;
        //ServiciosTarifasService clienteTarifas;
        ServiciosComparendosService clienteComparendos;
        
        public int idv = 0;
        Funciones funciones;

        public AdicionarVigencia(usuarios user)
        {
            myUsuario = user;
            InitializeComponent();            
            funciones = new Funciones();
        }

        private void AdicionarVigencia_Load(object sender, EventArgs e)
        {            
            impuesto.Visible = false;
            tipos.Height = 50;            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void llenarTipo(int tipo)
        {
            if (tipo == 1)
            {
                impuesto.Checked = true;
            }
            else if (tipo == 2)
            {
                tramite.Checked = true;
            }
        }

        public void llenarVigencia(int annio)
        {
            vigencia.Text = annio.ToString();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                //administradortarifas formp = new administradortarifas(myUsuario);
                if (string.IsNullOrWhiteSpace(vigencia.Text))
                {
                    MessageBox.Show("El campo vigencia no puede ser vacío");
                    vigencia.Focus();
                }
                else
                {                                        
                    clienteComparendos = WS.ServiciosComparendosService();
                    lVigenciasComp vigenciaconsulta = new lVigenciasComp();
                    vigenciaconsulta.LTV_VIGENCIA = Int32.Parse(vigencia.Text);

                    if (tramite.Checked == true)
                    {
                        vigenciaconsulta.LTV_TIPO = 2;
                    }
                    if (impuesto.Checked == true)
                    {
                        vigenciaconsulta.LTV_TIPO = 1;
                    }

                    Object[] listaexiste = (Object[])clienteComparendos.getLVigencias(vigenciaconsulta);

                    if (idv <= 0 || (listaexiste == null && modificar.Checked == false))
                    {
                        lVigenciasComp uvigencia = new lVigenciasComp();
                        String descrip = "";
                        if (tramite.Checked == true)
                        {
                            uvigencia.LTV_TIPO = 2;
                            descrip = "Tramites";
                        }
                        if (impuesto.Checked == true)
                        {
                            uvigencia.LTV_TIPO = 1;
                            descrip = "Impuestos";
                        }
                        uvigencia.LTV_VIGENCIA = Int32.Parse(vigencia.Text);
                        uvigencia.LTV_DESCRIPCION = descrip + " " + vigencia.Text;

                        Boolean resins = clienteComparendos.crearLVigencias(uvigencia);
                        if (resins == true)
                        {
                            MessageBox.Show("Vigencia Insertada");
                            DialogResult = DialogResult.OK;
                            this.Close();                            
                        }
                        else
                        {
                            MessageBox.Show("Error al Insertar. Verifique que la vigencia no se repita.");
                        }
                    }
                    else if (idv > 0 && modificar.Checked == true)
                    {
                        String descrip = "";
                        lVigenciasComp vigenciavieja = new lVigenciasComp();
                        lVigenciasComp vigenciaedita = new lVigenciasComp();

                        vigenciaedita.LTV_ID = idv;
                        if (tramite.Checked == true)
                        {
                            vigenciaedita.LTV_TIPO = 2;
                            descrip = "Tramites";
                        }
                        if (impuesto.Checked == true)
                        {
                            vigenciaedita.LTV_TIPO = 1;
                            descrip = "Impuestos";
                        }
                        vigenciaedita.LTV_VIGENCIA = Int32.Parse(vigencia.Text);
                        vigenciaedita.LTV_DESCRIPCION = descrip + " " + vigencia.Text;

                        Boolean resedi = clienteComparendos.editarLVigencias(vigenciaedita);
                        if (resedi == true)
                        {
                            MessageBox.Show("Vigencia Modificada");
                            DialogResult = DialogResult.OK;                            
                            this.Close();                            
                        }
                        else
                        {
                            MessageBox.Show("Error al Modificar. Verifique que la vigencia no se repita.");
                        }
                    }
                    else
                        MessageBox.Show("No se pudo modificar. Verifique que la vigencia no se repita.");
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void vigencia_TextChanged(object sender, EventArgs e)
        {
            Funciones funciones = new Funciones();
            funciones.soloNumeros(vigencia);
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

            private void vigencia_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }

            private void modificar_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }
        #endregion
    }
}
