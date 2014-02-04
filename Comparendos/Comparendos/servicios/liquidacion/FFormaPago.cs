using System; using TransitoPrincipal; using LibreriasSintrat.utilidades;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibreriasSintrat.ServiciosGeneralesComp;
using LibreriasSintrat.ServiciosAccesoriasComp;
using Comparendos.utilidades; using LibreriasSintrat.utilidades; using LibreriasSintrat;
using LibreriasSintrat.utilidades;

using System.Globalization;

namespace Comparendos.servicios.liquidacion
{
    public partial class FFormaPago : Form
    {
        ServiciosGeneralesCompService serviciosGenerales;
        DataTable dtFormaPago;
        Funciones funciones;
        Log log = new Log();
        CultureInfo culturaEspaniolCol = new CultureInfo("es-CO", false);

        public DataTable DtFormaPago
        {
            get { return dtFormaPago; }
            set { dtFormaPago = value; }
        }

        public FFormaPago(double valorRecibo)
        {
            InitializeComponent();
            InicializarObjetos();
            LlenarFormulario();
            LimpiarFormulario();
            txtValorRecibo.Text = "" + valorRecibo.ToString("C", culturaEspaniolCol);
            log = new Log();
        }

        private void InicializarObjetos()
        {
            serviciosGenerales = WS.ServiciosGeneralesCompService();
            funciones = new Funciones();
        }

        private void LlenarFormulario()
        {
            object[] objs;
            //tipo pago
            objs = serviciosGenerales.listarTipoPago();
            cmbFormaPago.DisplayMember = "NOMBRE";
            cmbFormaPago.ValueMember = "ID";
            funciones.llenarCombo(cmbFormaPago, objs);
            //tarjeta credito
            objs = serviciosGenerales.listarTarjetasCredito();
            cmbTipoTarjeta.DisplayMember = "NOMBRE";
            cmbTipoTarjeta.ValueMember = "ID";
            funciones.llenarCombo(cmbTipoTarjeta, objs);
            //bancos
            objs = serviciosGenerales.listarBanco();
            cmbBanco.DisplayMember = "DESCRIPCION";
            cmbBanco.ValueMember = "ID_BANCO";
            funciones.llenarCombo(cmbBanco, objs);

        }

        private void LimpiarFormulario()
        {
            dtFormaPago = CrearTablaTipoPago();
            tblTipoPago.DataSource = dtFormaPago;
            tblTipoPago.Columns["IDTIPOPAGO"].Visible = false;
            tblTipoPago.Columns["IDBANCO"].Visible = false;
            tblTipoPago.Columns["IDTIPOTARJETA"].Visible = false;
            txtAcumulado.Text = "$0.00";
            txtNroCheque.Text = "";
            txtValor.Text = "";
            if (cmbFormaPago.Items.Count > 0)
                cmbFormaPago.SelectedIndex = 0;
            if (cmbBanco.Items.Count > 0) 
                cmbBanco.SelectedIndex = 0;
            if (cmbTipoTarjeta.Items.Count > 0) 
                cmbTipoTarjeta.SelectedIndex = 0;
            txtValor.Focus();
        }

        private DataTable CrearTablaTipoPago()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("IDTIPOPAGO");
            dt.Columns.Add("TIPO PAGO");
            dt.Columns.Add("VALOR");
            dt.Columns.Add("IDBANCO");
            dt.Columns.Add("BANCO");
            dt.Columns.Add("NRO. CHEQUE");
            dt.Columns.Add("IDTIPOTARJETA");
            dt.Columns.Add("TIPO TARJETA");
            return dt;
        }

        private void cmbFormaPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFormaPago.SelectedIndex >= 0)
            {
                if (cmbFormaPago.SelectedValue.ToString() == "1")
                {
                    //efectivo
                    txtNroCheque.Enabled = false;
                    cmbTipoTarjeta.Enabled = false;
                    cmbBanco.Enabled = false;
                    txtNroCheque.BackColor = Color.DarkGray;
                    cmbTipoTarjeta.BackColor = Color.DarkGray;
                    cmbBanco.BackColor = Color.DarkGray;
                }
                else if (cmbFormaPago.SelectedValue.ToString() == "2")
                {
                    //cheque
                    txtNroCheque.Enabled = true;
                    cmbTipoTarjeta.Enabled = false;
                    cmbBanco.Enabled = true;
                    txtNroCheque.BackColor = Color.White;
                    cmbTipoTarjeta.BackColor = Color.DarkGray;
                    cmbBanco.BackColor = Color.White;
                }
                else if (cmbFormaPago.SelectedValue.ToString() == "3")
                {
                    //tarjeta credito
                    txtNroCheque.Enabled = false;
                    cmbTipoTarjeta.Enabled = true;
                    cmbBanco.Enabled = true;
                    txtNroCheque.BackColor = Color.DarkGray;
                    cmbTipoTarjeta.BackColor = Color.White;
                    cmbBanco.BackColor = Color.White;
                }
            }
            else
            {
                //otro
                txtNroCheque.Enabled = false;
                cmbTipoTarjeta.Enabled = false;
                cmbBanco.Enabled = false;
                txtNroCheque.BackColor = Color.DarkGray;
                cmbTipoTarjeta.BackColor = Color.DarkGray;
                cmbBanco.BackColor = Color.DarkGray;
            }
        }

        private void btnMas_Click(object sender, EventArgs e)
        {
            if (ValidarIngreso())
            {
                DataRow dr = BuscarFila(cmbFormaPago.SelectedValue.ToString());
                bool nuevo = false;
                if (dr == null) { dr = dtFormaPago.NewRow(); nuevo = true; }
                dr["IDTIPOPAGO"] = cmbFormaPago.SelectedValue.ToString();
                dr["TIPO PAGO"] = ((DataTable)cmbFormaPago.DataSource).Rows[cmbFormaPago.SelectedIndex]["NOMBRE"].ToString();
                ActualizarValor();
                if (txtValor.Text != "0")
                {
                    if (nuevo) dr["VALOR"] = txtValor.Text;
                    else if (dr["VALOR"].ToString() != "")
                        dr["VALOR"] = double.Parse(dr["VALOR"].ToString()) + double.Parse(txtValor.Text);
                    dr["IDBANCO"] = (cmbFormaPago.SelectedValue.ToString() == "2" || cmbFormaPago.SelectedValue.ToString() == "3") ?
                        cmbBanco.SelectedValue : "NO APLICA";
                    dr["BANCO"] = (cmbFormaPago.SelectedValue.ToString() == "2" || cmbFormaPago.SelectedValue.ToString() == "3") ?
                        ((DataTable)cmbBanco.DataSource).Rows[cmbBanco.SelectedIndex]["DESCRIPCION"].ToString() : "NO APLICA";
                    dr["NRO. CHEQUE"] = cmbFormaPago.SelectedValue.ToString() == "2" ? txtNroCheque.Text : "NO APLICA";
                    dr["IDTIPOTARJETA"] = cmbFormaPago.SelectedValue.ToString() == "3" ?
                        cmbTipoTarjeta.SelectedValue.ToString() : "NO APLICA";
                    dr["TIPO TARJETA"] = cmbFormaPago.SelectedValue.ToString() == "3" ?
                        ((DataTable)cmbTipoTarjeta.DataSource).Rows[cmbTipoTarjeta.SelectedIndex]["NOMBRE"].ToString() : "NO APLICA";
                    if (nuevo) dtFormaPago.Rows.Add(dr);
                    if (funciones.strToDouble(funciones.moneyToStr(txtAcumulado.Text)) == funciones.strToDouble(funciones.moneyToStr(txtValorRecibo.Text)))
                        btnAceptar.Enabled = true;
                }
            }
        }

        private DataRow BuscarFila(string idTipoPago)
        {
            if (dtFormaPago != null)
            {
                for (int i = 0; i < dtFormaPago.Rows.Count; i++)
                {
                    if (dtFormaPago.Rows[i]["IDTIPOPAGO"].ToString() == idTipoPago)
                        return dtFormaPago.Rows[i];
                }
            }
            return null;
        }

        private void ActualizarValor()
        {
            double valorRecibo = funciones.strToDouble(funciones.moneyToStr(txtValorRecibo.Text));
            double valorAcumulado = funciones.strToDouble(funciones.moneyToStr(txtAcumulado.Text));
            double valor = double.Parse(txtValor.Text);
            if (valor + valorAcumulado > valorRecibo)
            {
                valor = valorRecibo - valorAcumulado;
                txtValor.Text = "" + valor;
            }
            valorAcumulado += valor;
            txtAcumulado.Text = "" + valorAcumulado.ToString("C", culturaEspaniolCol);
        }

        private void CalcularValores(string valorReciboText, string valorAcumuladoText)
        {
            double valorRecibo = double.Parse(valorReciboText);
            double valorAcumulado = double.Parse(valorAcumuladoText);
            double valor = valorRecibo - valorAcumulado;
            txtValor.Text = "" + valor;
        }

        private bool ValidarIngreso()
        {
            if (txtValor.Text == "")
            {
                MessageBox.Show("Ingrese el valor correspondiente al tipo de pago seleccionado");
                return false;
            }
            else if (cmbFormaPago.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione la forma de pago");
                return false;
            }
            else if (cmbFormaPago.SelectedValue.ToString() == "2")
            {
                //cheque
                if (cmbBanco.SelectedIndex < 0)
                {
                    MessageBox.Show("Seleccione el banco del cual proviene el cheque");
                    return false;
                }
                else if (txtNroCheque.Text == "")
                {
                    MessageBox.Show("Ingrese el número del cheque");
                    return false;
                }
            }
            else if (cmbFormaPago.SelectedValue.ToString() == "3")
            {
                //tarjeta credito
                if (cmbTipoTarjeta.SelectedIndex < 0)
                {
                    MessageBox.Show("Seleccione el tipo de tarjeta de crédito");
                    return false;
                }
                if (cmbBanco.SelectedIndex < 0)
                {
                    MessageBox.Show("Seleccione el banco del cual proviene el cheque");
                    return false;
                }
            }
            return true;
        }

        private void btnTomarValorFaltante_Click(object sender, EventArgs e)
        {
            try
            {
                CalcularValores(funciones.strToDouble(funciones.moneyToStr(txtValorRecibo.Text)).ToString(), funciones.strToDouble(funciones.moneyToStr(txtAcumulado.Text)).ToString());
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
            }
        }

        private void btnMenos_Click(object sender, EventArgs e)
        {
            if (tblTipoPago.SelectedRows.Count > 0)
            {
                DataGridViewRow dgvr = tblTipoPago.SelectedRows[0];
                double valor = double.Parse(dgvr.Cells["VALOR"].Value.ToString());
                double acumulado = funciones.strToDouble(funciones.moneyToStr(txtAcumulado.Text));
                txtAcumulado.Text = "" + (acumulado - valor).ToString("C", culturaEspaniolCol);
                tblTipoPago.Rows.Remove(dgvr);
                if (funciones.strToDouble(funciones.moneyToStr(txtAcumulado.Text)) == funciones.strToDouble(funciones.moneyToStr(txtValorRecibo.Text)))
                    btnAceptar.Enabled = true;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        public override string ToString()
        {
            string res = "";
            if (dtFormaPago != null)
            {
                for (int i = 0; i < dtFormaPago.Rows.Count; i++)
                {
                    res += "" + dtFormaPago.Rows[i]["TIPO PAGO"].ToString() + " [" +
                        dtFormaPago.Rows[i]["VALOR"].ToString() + "], ";
                }
            }
            return res;
        }

        private void txtValor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnTomarValorFaltante.Focus();
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            funciones.esDecimal(e);
        }

        private void txtNroCheque_KeyPress(object sender, KeyPressEventArgs e)
        {
            funciones.esDecimal(e);
            funciones.lanzarTapConEnter(e);
        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtValor.Text != "")
                {
                    if (double.Parse(txtValor.Text) + funciones.strToDouble(funciones.moneyToStr(txtAcumulado.Text)) > funciones.strToDouble(funciones.moneyToStr(txtValorRecibo.Text)))
                        txtValor.Text = "" + (funciones.strToDouble(funciones.moneyToStr(txtValorRecibo.Text)) - funciones.strToDouble(funciones.moneyToStr(txtAcumulado.Text)));
                }
            }
            catch (Exception exp) {
                log.escribirError(exp.ToString(), this.GetType());
            }
        }

        private void cmbFormaPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            funciones.lanzarTapConEnter(e);
        }

        private void cmbTipoTarjeta_KeyPress(object sender, KeyPressEventArgs e)
        {
            funciones.lanzarTapConEnter(e);
        }

        private void cmbBanco_KeyPress(object sender, KeyPressEventArgs e)
        {
            funciones.lanzarTapConEnter(e);
        }
    }
}
