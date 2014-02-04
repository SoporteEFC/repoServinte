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
using LibreriasSintrat.ServiciosTarifasComp;
using LibreriasSintrat.ServiciosEmpresas;
using LibreriasSintrat.ServiciosAccesoriasComp;

namespace Comparendos
{
    public partial class adicionarconcepto : Form
    {
        ServiciosTarifasService clienteTarifas;
        ServiciosComparendosService clienteComparendos;
        ServiciosTarifasCompService clienteTarifasComp;
        //ServiciosEmpresasService clienteEmpresas;
        ServiciosAccesoriasCompService clienteAccesoriasComp;

        Funciones funciones;
        lconceptosCobro conceptoseleccionado;

        int idTarifa = 0, idDetalleTarifa = 0, guardar = 0;
        bool editarConcepto = false;

        public adicionarconcepto(int idTarif, int idDetalleTarif, bool editar)
        {
            InitializeComponent();
            crearObjetos();
            this.idTarifa = idTarif;
            this.idDetalleTarifa = idDetalleTarif;
            editarConcepto = editar;

        }

        private void llenarDatosConcepto()
        {
            viewDetalleTarifaComp viewDetalleTarifa = new viewDetalleTarifaComp();
            viewDetalleTarifa.LTD_ID = idDetalleTarifa;
            
            viewDetalleTarifa = clienteTarifasComp.getLtarifaDetId(viewDetalleTarifa);

            if (viewDetalleTarifa != null && viewDetalleTarifa.LTD_ID > 0)
            {
                cmbItemLiquidacion.SelectedValue = viewDetalleTarifa.LITEM_ID;
                cmbTipoConcepto.SelectedValue = viewDetalleTarifa.LTD_TIPO;

                if (viewDetalleTarifa.LTD_DESCONTADLE == 1)
                {
                    chkDescontable.Checked = true;
                }

                txtValor.Text = viewDetalleTarifa.LTD_VALOR.ToString();
                txtDatoBase.Text = viewDetalleTarifa.LTD_DATOBASE;
                txtFactor.Text = viewDetalleTarifa.LTD_FACTOR.ToString();
                txtFormula.Text = viewDetalleTarifa.LTD_CALCULO;
            }
        }

        public void crearObjetos()
        {
            funciones = WS.Funciones();
            clienteTarifas = WS.ServiciosTarifasService();
            clienteTarifasComp = WS.ServiciosTarifasCompService();
            clienteComparendos = WS.ServiciosComparendosService();
            clienteAccesoriasComp = WS.ServiciosAccesoriasCompService();
        }

        private void adicionarconcepto_Load(object sender, EventArgs e)
        {
            try
            {
                datostabla.Visible = false;

                if (editarConcepto == false)                
                    btndatos.Enabled = false;

                itemsLiquidacionComp itemliq = new itemsLiquidacionComp();
                Object[] listaitemsliq = clienteTarifasComp.getTItemsLiquidacion(itemliq);
                funciones.llenarCombo(cmbItemLiquidacion, listaitemsliq);

                ltipoConcepto tipconcepto = new ltipoConcepto();
                Object[] listatipos = clienteTarifas.getLtipoConceptos(tipconcepto);
                funciones.llenarCombo(cmbTipoConcepto, listatipos);
                
                cmbItemLiquidacion.Focus();

                //Llenar datos detalle tarifa                
                if (this.idDetalleTarifa > 0)
                    llenarDatosConcepto();//Detalle tarifa
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                Console.WriteLine(exp.Message);
                Console.WriteLine(exp.StackTrace);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (editarConcepto == false)
                {
                    guardar = 0;
                    if (idTarifa > 0)
                    {
                        ltarifasDetComp dettarifaComp = new ltarifasDetComp();
                        dettarifaComp.LTD_LT_ID = idTarifa;
                        dettarifaComp.LTD_LCC_ID = Int32.Parse(cmbItemLiquidacion.SelectedValue.ToString());
                        if (chkDescontable.Checked == true)
                        {
                            dettarifaComp.LTD_DESCONTABLE = 1;
                        }
                        else
                        {
                            dettarifaComp.LTD_DESCONTABLE = 0;
                        }
                        dettarifaComp.LTD_TIPO = Int32.Parse(cmbTipoConcepto.SelectedValue.ToString());

                        if (Int32.Parse(cmbTipoConcepto.SelectedValue.ToString()) == 1)
                        {
                            if (txtValor.Text == "")
                            {
                                guardar = 0;
                                MessageBox.Show("El campo Valor no puede ser vacío");
                                txtValor.Focus();
                            }
                            else
                            {
                                guardar = 1;
                                dettarifaComp.LTD_VALOR = Int32.Parse(txtValor.Text);
                            }
                            dettarifaComp.LTD_DATO_BASE = txtDatoBase.Text;
                            dettarifaComp.LTD_FACTOR = 0;
                            dettarifaComp.LTD_CALCULO = txtFormula.Text;
                        }
                        else if (Int32.Parse(cmbTipoConcepto.SelectedValue.ToString()) == 2 || Int32.Parse(cmbTipoConcepto.SelectedValue.ToString()) == 3)
                        {
                            dettarifaComp.LTD_VALOR = 0;
                            if (txtDatoBase.Text == "")
                            {
                                guardar = 0;
                                MessageBox.Show("El campo Dato Base no puede ser vacío");
                                txtDatoBase.Focus();
                            }
                            else if (txtFactor.Text == "")
                            {
                                guardar = 0;
                                MessageBox.Show("El campo Factor no puede ser vacío");
                                txtFactor.Focus();
                            }
                            else
                            {
                                guardar = 1;
                                dettarifaComp.LTD_DATO_BASE = txtDatoBase.Text;
                                dettarifaComp.LTD_FACTOR = Int32.Parse(txtFactor.Text);
                            }
                            dettarifaComp.LTD_CALCULO = txtFormula.Text;
                        }
                        else if (Int32.Parse(cmbTipoConcepto.SelectedValue.ToString()) == 4)
                        {
                            dettarifaComp.LTD_VALOR = 0;
                            dettarifaComp.LTD_DATO_BASE = txtDatoBase.Text;
                            dettarifaComp.LTD_FACTOR = 0;
                            if (txtFormula.Text == "")
                            {
                                guardar = 0;
                                MessageBox.Show("El campo Formula no puede ser vacío");
                                txtFormula.Focus();
                            }
                            else
                            {
                                guardar = 1;
                                dettarifaComp.LTD_CALCULO = txtFormula.Text;
                            }
                        }

                        if (guardar == 1)
                        {
                            Boolean resdet = clienteTarifasComp.crearDetTarifasComp(dettarifaComp, WS.MyUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName());
                            if (resdet == true)
                            {
                                MessageBox.Show("Registro Exitoso");
                                DialogResult = DialogResult.OK;
                            }
                            else
                            {
                                MessageBox.Show("Error en el Registro");
                            }
                        }
                    }
                }
                else if (editarConcepto)
                {
                    guardar = 0;
                    ltarifasDetComp editdettarifaComp = new ltarifasDetComp();
                    editdettarifaComp.LTD_ID = idDetalleTarifa;
                    editdettarifaComp.LTD_LT_ID = idTarifa;
                    editdettarifaComp.LTD_LCC_ID = Int32.Parse(cmbItemLiquidacion.SelectedValue.ToString());
                    if (chkDescontable.Checked == true)
                    {
                        editdettarifaComp.LTD_DESCONTABLE = 1;
                    }
                    else
                    {
                        editdettarifaComp.LTD_DESCONTABLE = 0;
                    }
                    editdettarifaComp.LTD_TIPO = Int32.Parse(cmbTipoConcepto.SelectedValue.ToString());

                    if (Int32.Parse(cmbTipoConcepto.SelectedValue.ToString()) == 1)
                    {
                        if (txtValor.Text == "")
                        {
                            guardar = 0;
                            MessageBox.Show("El campo Valor no puede ser vacío");
                            txtValor.Focus();
                        }
                        else
                        {
                            guardar = 1;
                            editdettarifaComp.LTD_VALOR = Int32.Parse(txtValor.Text);
                        }
                        editdettarifaComp.LTD_DATO_BASE = txtDatoBase.Text;
                        editdettarifaComp.LTD_FACTOR = 0;
                        editdettarifaComp.LTD_CALCULO = txtFormula.Text;
                    }
                    else if (Int32.Parse(cmbTipoConcepto.SelectedValue.ToString()) == 2 || Int32.Parse(cmbTipoConcepto.SelectedValue.ToString()) == 3)
                    {
                        editdettarifaComp.LTD_VALOR = 0;
                        if (txtDatoBase.Text == "")
                        {
                            guardar = 0;
                            MessageBox.Show("El campo Dato Base no puede ser vacío");
                            txtDatoBase.Focus();
                        }
                        else if (txtFactor.Text == "")
                        {
                            guardar = 0;
                            MessageBox.Show("El campo Factor no puede ser vacío");
                            txtFactor.Focus();
                        }
                        else
                        {
                            guardar = 1;
                            editdettarifaComp.LTD_DATO_BASE = txtDatoBase.Text;
                            editdettarifaComp.LTD_FACTOR = Int32.Parse(txtFactor.Text);
                        }

                        editdettarifaComp.LTD_CALCULO = txtFormula.Text;
                    }
                    else if (Int32.Parse(cmbTipoConcepto.SelectedValue.ToString()) == 4)
                    {
                        editdettarifaComp.LTD_VALOR = 0;
                        editdettarifaComp.LTD_DATO_BASE = txtDatoBase.Text;
                        editdettarifaComp.LTD_FACTOR = 0;

                        if (txtFormula.Text == "")
                        {
                            guardar = 0;
                            MessageBox.Show("El campo Formula no puede ser vacío");
                            txtFormula.Focus();
                        }
                        else
                        {
                            guardar = 1;
                            editdettarifaComp.LTD_CALCULO = txtFormula.Text;
                        }
                    }

                    if (guardar == 1)
                    {
                        Boolean resedit = clienteTarifasComp.editarDetTarifaComp(editdettarifaComp, WS.MyUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName());
                        if (resedit == true)
                        {
                            MessageBox.Show("Detalle Modificado");
                            DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            MessageBox.Show("Error al Modificar");
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                Console.WriteLine(exp.Message);
                Console.WriteLine(exp.StackTrace);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = DialogResult.Cancel;
                this.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                Console.WriteLine(exp.Message);
                Console.WriteLine(exp.StackTrace);
            }
        }

        


        private void btndatos_Click(object sender, EventArgs e)
        {
            try
            {
                this.Width = 1020;
                datostabla.Visible = true;

                Object[] listaconcept = clienteTarifas.getLconceptos();
                if (listaconcept != null)
                {
                    funciones = WS.Funciones();
                    DataTable dtconc = new DataTable();
                    ArrayList Camposconcep = new ArrayList();
                    Camposconcep.Add("LCC_ID = ID");
                    Camposconcep.Add("LCC_NOMBRE = NOMBRE");
                    Camposconcep.Add("LCC_DESCRIPCION = DESCRIPCION");
                    Camposconcep.Add("LCC_ACTIVO = ACTIVO");
                    Camposconcep.Add("LCC_DETLIQUIDACION = DETLIQUIDACION");
                    Camposconcep.Add("LCC_IDCTABANCARIA = IDCTABANCARIA");
                    Camposconcep.Add("LCC_OTRONOMBRE = OTRO NOMBRE");
                    Camposconcep.Add("LCC_TASA_INTERES = TASA INTERES");
                    Camposconcep.Add("LCC_EDITABLE = EDITABLE");
                    
                    dtconc = funciones.ToDataTable(funciones.ObjectToArrayList(listaconcept));
                    
                    grdConceptosCobro.DataSource = dtconc;
                    if (dtconc.Rows.Count > 0)
                        funciones.configurarGrilla(grdConceptosCobro, Camposconcep);
                    
                    dtconc = null;
                    Camposconcep = null;

                    grdConceptosCobro.Select();
                    if (grdConceptosCobro.CurrentRow != null && grdConceptosCobro.CurrentRow.Index >= 0)
                        conceptoseleccionado = (lconceptosCobro)listaconcept[grdConceptosCobro.CurrentRow.Index];
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }



        private void btnocultar_Click(object sender, EventArgs e)
        {
            try
            {
                datostabla.Visible = false;
                this.Width = 348;
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                Console.WriteLine(exp.Message);
                Console.WriteLine(exp.StackTrace);
            }
        }

        private void valor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Funciones funciones = WS.Funciones();
                funciones.soloNumeros(txtValor);
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                Console.WriteLine(exp.Message);
                Console.WriteLine(exp.StackTrace);
            }
        }

        private void factor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Funciones funciones = WS.Funciones();
                funciones.soloNumeros(txtFactor);
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                Console.WriteLine(exp.Message);
                Console.WriteLine(exp.StackTrace);
            }
        }

        private void tipoconcepto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbTipoConcepto.SelectedValue != null)
                {
                    if (Int32.Parse(cmbTipoConcepto.SelectedValue.ToString()) == 1)
                    {
                        txtValor.Enabled = true;
                        txtFactor.Enabled = false;
                        txtDatoBase.Enabled = false;
                        txtFormula.Enabled = false;

                        txtFactor.Text = "";
                        txtDatoBase.Text = "";
                        txtFormula.Text = "";
                    }
                    else if (Int32.Parse(cmbTipoConcepto.SelectedValue.ToString()) == 2 || Int32.Parse(cmbTipoConcepto.SelectedValue.ToString()) == 3)
                    {
                        txtValor.Enabled = false;
                        txtFactor.Enabled = true;
                        txtDatoBase.Enabled = true;
                        txtFormula.Enabled = false;

                        txtValor.Text = "";
                        txtFormula.Text = "";
                    }
                    else if (Int32.Parse(cmbTipoConcepto.SelectedValue.ToString()) == 4)
                    {
                        txtValor.Enabled = false;
                        txtFactor.Enabled = false;
                        txtDatoBase.Enabled = false;
                        txtFormula.Enabled = true;

                        txtValor.Text = "";
                        txtFactor.Text = "";
                        txtDatoBase.Text = "";
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                Console.WriteLine(exp.Message);
                Console.WriteLine(exp.StackTrace);
            }
        }


        #region Eventos KeyPress

            private void claseconcepto_KeyPress(object sender, KeyPressEventArgs e)
            {
                try
                {
                    funciones.lanzarTapConEnter(e);
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                    Console.WriteLine(exp.Message);
                    Console.WriteLine(exp.StackTrace);
                }
            }

            private void empresaasigna_KeyPress(object sender, KeyPressEventArgs e)
            {
                try
                {
                    funciones.lanzarTapConEnter(e);
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                    Console.WriteLine(exp.Message);
                    Console.WriteLine(exp.StackTrace);
                }
            }

            private void tipoconcepto_KeyPress(object sender, KeyPressEventArgs e)
            {
                try
                {
                    funciones.lanzarTapConEnter(e);
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                    Console.WriteLine(exp.Message);
                    Console.WriteLine(exp.StackTrace);
                }
            }

            private void descontable_KeyPress(object sender, KeyPressEventArgs e)
            {
                try
                {
                    funciones.lanzarTapConEnter(e);
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                    Console.WriteLine(exp.Message);
                    Console.WriteLine(exp.StackTrace);
                }
            }

            private void valor_KeyPress(object sender, KeyPressEventArgs e)
            {
                try
                {
                    funciones.lanzarTapConEnter(e);
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                    Console.WriteLine(exp.Message);
                    Console.WriteLine(exp.StackTrace);
                }
            }

            private void datobase_KeyPress(object sender, KeyPressEventArgs e)
            {
                try
                {
                    funciones.lanzarTapConEnter(e);
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                    Console.WriteLine(exp.Message);
                    Console.WriteLine(exp.StackTrace);
                }
            }

            private void factor_KeyPress(object sender, KeyPressEventArgs e)
            {
                try
                {
                    funciones.lanzarTapConEnter(e);
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                    Console.WriteLine(exp.Message);
                    Console.WriteLine(exp.StackTrace);
                }
            }
        #endregion
    }
}
