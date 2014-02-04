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
using LibreriasSintrat.ServiciosLiquidacionComp;
using LibreriasSintrat.ServiciosAccesorias;
using System.Collections;
using LibreriasSintrat.utilidades;

namespace Comparendos.servicios.generales
{
    public partial class FrmAcuerdoPagoPorInfractor : Form
    {
        Funciones funciones;
        ServiciosAccesoriasCompService serviciosAccesorias;
        ServiciosGeneralesCompService serviciosGenerales;
        ServiciosLiquidacionCompService serviciosLiquidacion;
        ServiciosAccesoriasCompService serviciosAccesoriasComp;
        object[] acuerdos;

        public FrmAcuerdoPagoPorInfractor()
        {
            InitializeComponent();
            funciones = new Funciones();
            serviciosAccesorias = WS.ServiciosAccesoriasCompService();
            serviciosGenerales = WS.ServiciosGeneralesCompService();
            serviciosLiquidacion = WS.ServiciosLiquidacionCompService();
            serviciosAccesoriasComp = WS.ServiciosAccesoriasCompService();
            funciones.llenarCombo(cmbTipoIdentificacion, serviciosAccesorias.obtenerTiposDocumento());
        }

        private void txtNumIdentificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            funciones.esNumero(e);
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                tblAcuerdos.DataSource = null;
                if (cbObtenerAcuerdoPagoMora.Checked)
                {
                    buscarAcuerdosMora();
                }
                else
                {
                    buscarAcuerdos();
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            tblAcuerdos.DataSource = null;
            if (cbObtenerAcuerdoPagoMora.Checked)
            {
                buscarAcuerdosMora();
            }
            else
            {
                buscarAcuerdos();
            }
        }

        private void buscarAcuerdosMora()
        {
            if (validarCampos())
            {
                infractorComp myInfractor = new infractorComp();
                myInfractor.ID_DOCTO = int.Parse(cmbTipoIdentificacion.SelectedValue.ToString());
                myInfractor.NROIDENTIFICACION = txtNumIdentificacion.Text;
                myInfractor = serviciosGenerales.buscarInfractor(myInfractor);
                ArrayList Acuerdos = new ArrayList();
                if (myInfractor != null && myInfractor.ID_INFRACTOR > 0)
                {
                    txtNombre.Text = myInfractor.NOMBRES;
                    txtApeliidos.Text = myInfractor.APELLIDOS;
                    txtDireccionResidencia.Text = myInfractor.DIRECCION;
                    ServiciosLiquidacionCompService mySerLiqComp = WS.ServiciosLiquidacionCompService();
                    acuerdos = mySerLiqComp.ListarAcuerdosInfractor(myInfractor.NROIDENTIFICACION, myInfractor.ID_DOCTO);
                    if (acuerdos != null)
                    {
                        //llenarTblAcuerdos();
                        foreach (acuerdosPagoComp acuerdo in acuerdos)
                        {
                            pagosComp pagoComparendo = new pagosComp();
                            pagoComparendo.IDLIQUIDACION = acuerdo.IDLIQUIDACION;
                            object[] listaPagos = serviciosLiquidacion.getPagosComp(pagoComparendo);
                            if (listaPagos != null)
                            {
                                int pos = 0;
                                string fechaactual = serviciosAccesorias.getFechaHora("MM/dd/yyyy");
                                foreach (pagosComp pagos in listaPagos)
                                {
                                    if (pos == 0)
                                    {
                                        string fechapag = funciones.convFormatoFecha(pagos.FECHAPAGO, "MM/dd/yyyy");
                                        char[] delimiterchar = { '/' };
                                        string[] datos;
                                        datos = fechapag.Split(delimiterchar, StringSplitOptions.RemoveEmptyEntries);
                                        int anoPago = 0, mesPago = 0, diaPago = 0;
                                        if (datos != null)
                                        {
                                            anoPago = int.Parse(datos[2]);
                                            mesPago = int.Parse(datos[0]);
                                            diaPago = int.Parse(datos[1]);
                                        }
                                        datos = fechaactual.Split(delimiterchar, StringSplitOptions.RemoveEmptyEntries);
                                        int anoactual = 0, mesactual = 0, diaactual = 0;
                                        if (datos != null)
                                        {
                                            anoactual = int.Parse(datos[2]);
                                            mesactual = int.Parse(datos[0]);
                                            diaactual = int.Parse(datos[1]);
                                        }
                                        if (anoactual > anoPago)
                                        {
                                            //atrasado
                                            if (pagos.ESTADO == 14) //Si el estado del pago es no pago
                                            {
                                                Acuerdos.Add(acuerdo);
                                                pos++;
                                            }
                                        }
                                        else
                                        {
                                            if (mesactual > mesPago)
                                            {
                                                //atrasado
                                                if (pagos.ESTADO == 14) //Si el estado del pago es no pago
                                                {
                                                    Acuerdos.Add(acuerdo);
                                                    pos++;
                                                }
                                            }
                                            else
                                            {
                                                if (diaactual > diaPago)
                                                {
                                                    //atrasado
                                                    if (pagos.ESTADO == 14) //Si el estado del pago es no pago
                                                    {
                                                        Acuerdos.Add(acuerdo);
                                                        pos++;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (Acuerdos.Count > 0)
                                        {
                                            acuerdosPagoComp tmpAcuerdoPagos = new acuerdosPagoComp();
                                            object tmp = Acuerdos[pos-1];
                                            tmpAcuerdoPagos = (acuerdosPagoComp)tmp;
                                            if (tmpAcuerdoPagos != null && tmpAcuerdoPagos.ID > 0)
                                            {
                                                if (tmpAcuerdoPagos.IDLIQUIDACION != pagos.IDLIQUIDACION)
                                                {
                                                    string fechapag = funciones.convFormatoFecha(pagos.FECHAPAGO, "MM/dd/yyyy");
                                                    char[] delimiterchar = { '/' };
                                                    string[] datos;
                                                    datos = fechapag.Split(delimiterchar, StringSplitOptions.RemoveEmptyEntries);
                                                    int anoPago = 0, mesPago = 0, diaPago = 0;
                                                    if (datos != null)
                                                    {
                                                        anoPago = int.Parse(datos[2]);
                                                        mesPago = int.Parse(datos[0]);
                                                        diaPago = int.Parse(datos[1]);
                                                    }
                                                    datos = fechaactual.Split(delimiterchar, StringSplitOptions.RemoveEmptyEntries);
                                                    int anoactual = 0, mesactual = 0, diaactual = 0;
                                                    if (datos != null)
                                                    {
                                                        anoactual = int.Parse(datos[2]);
                                                        mesactual = int.Parse(datos[0]);
                                                        diaactual = int.Parse(datos[1]);
                                                    }
                                                    if (anoactual > anoPago)
                                                    {
                                                        //atrasado
                                                        if (pagos.ESTADO == 14) //Si el estado del pago es no pago
                                                        {
                                                            Acuerdos.Add(acuerdo);
                                                            pos++;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (mesactual > mesPago)
                                                        {
                                                            //atrasado
                                                            if (pagos.ESTADO == 14) //Si el estado del pago es no pago
                                                            {
                                                                Acuerdos.Add(acuerdo);
                                                                pos++;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (diaactual > diaPago)
                                                            {
                                                                //atrasado
                                                                if (pagos.ESTADO == 14) //Si el estado del pago es no pago
                                                                {
                                                                    Acuerdos.Add(acuerdo);
                                                                    pos++;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            string fechapag = funciones.convFormatoFecha(pagos.FECHAPAGO, "MM/dd/yyyy");
                                            char[] delimiterchar = { '/' };
                                            string[] datos;
                                            datos = fechapag.Split(delimiterchar, StringSplitOptions.RemoveEmptyEntries);
                                            int anoPago = 0, mesPago = 0, diaPago = 0;
                                            if (datos != null)
                                            {
                                                anoPago = int.Parse(datos[2]);
                                                mesPago = int.Parse(datos[0]);
                                                diaPago = int.Parse(datos[1]);
                                            }
                                            datos = fechaactual.Split(delimiterchar, StringSplitOptions.RemoveEmptyEntries);
                                            int anoactual = 0, mesactual = 0, diaactual = 0;
                                            if (datos != null)
                                            {
                                                anoactual = int.Parse(datos[2]);
                                                mesactual = int.Parse(datos[0]);
                                                diaactual = int.Parse(datos[1]);
                                            }
                                            if (anoactual > anoPago)
                                            {
                                                //atrasado
                                                if (pagos.ESTADO == 14) //Si el estado del pago es no pago
                                                {
                                                    Acuerdos.Add(acuerdo);
                                                    pos++;
                                                }
                                            }
                                            else
                                            {
                                                if (mesactual > mesPago)
                                                {
                                                    //atrasado
                                                    if (pagos.ESTADO == 14) //Si el estado del pago es no pago
                                                    {
                                                        Acuerdos.Add(acuerdo);
                                                        pos++;
                                                    }
                                                }
                                                else
                                                {
                                                    if (diaactual > diaPago)
                                                    {
                                                        //atrasado
                                                        if (pagos.ESTADO == 14) //Si el estado del pago es no pago
                                                        {
                                                            Acuerdos.Add(acuerdo);
                                                            pos++;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    
                                }
                            }
                        }
                        if (Acuerdos != null && Acuerdos.Count > 0)
                        {
                            acuerdos = Acuerdos.ToArray();
                            llenarTblAcuerdos();
                        }
                        else
                        {
                            funciones.mostrarMensaje("La persona no tiene acuerdos en mora","I");
                        }
                    }
                    else
                    {
                        funciones.mostrarMensaje("No se encontraron acuerdos para la persona en el sistema", "W");
                    }
                }
                else
                {
                    funciones.mostrarMensaje("No se encontro a la persona en el sistema", "W");
                }
            }
        }

        public void buscarAcuerdos()
        {
            if (validarCampos())
            {
                infractorComp myInfractor = new infractorComp();
                myInfractor.ID_DOCTO = int.Parse(cmbTipoIdentificacion.SelectedValue.ToString());
                myInfractor.NROIDENTIFICACION = txtNumIdentificacion.Text;
                myInfractor = serviciosGenerales.buscarInfractor(myInfractor);
                if (myInfractor != null && myInfractor.ID_INFRACTOR > 0)
                {
                    txtNombre.Text = myInfractor.NOMBRES;
                    txtApeliidos.Text = myInfractor.APELLIDOS;
                    txtDireccionResidencia.Text = myInfractor.DIRECCION;
                    ServiciosLiquidacionCompService mySerLiqComp = WS.ServiciosLiquidacionCompService();
                    acuerdos = mySerLiqComp.ListarAcuerdosInfractor(myInfractor.NROIDENTIFICACION, myInfractor.ID_DOCTO);
                    if (acuerdos != null)
                    {
                        llenarTblAcuerdos();
                    }
                    else
                    {
                        funciones.mostrarMensaje("No se encontraron acuerdos para la persona", "W");
                    }
                }
                else
                {
                    funciones.mostrarMensaje("No se encontro a la persona en el sistema", "W");
                }        
            }
        }

        private void llenarTblAcuerdos()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("NUMERO ACUERDO");
            dt.Columns.Add("DESCRIPCION");
            dt.Columns.Add("CONCEPTO");
            dt.Columns.Add("FECHA");
            dt.Columns.Add("CODEUDOR");
            dt.Columns.Add("INTERES FINANCIACION");
            DataRow dr;
            acuerdosPagoComp acuerdo;
            for (int i = 0; i < acuerdos.Length; i++)
            {
                dr = dt.NewRow();
                acuerdo = (acuerdosPagoComp)acuerdos[i];
                dr["ID"] = acuerdo.ID;
                dr["NUMERO ACUERDO"] = acuerdo.NUMERO;
                dr["DESCRIPCION"] = acuerdo.DESCRIPCION;
                dr["CONCEPTO"] = acuerdo.CONCEPTO;
                dr["FECHA"] = DateTime.Parse(acuerdo.FECHA, System.Globalization.CultureInfo.InvariantCulture).ToString("dd/MM/yyyy");
                dr["INTERES FINANCIACION"] = acuerdo.INTERESFINANCIACION;
                dt.Rows.Add(dr);
            }
            tblAcuerdos.DataSource = dt;
            tblAcuerdos.Columns["ID"].Visible = false;
            tblAcuerdos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            tblAcuerdos.Select();
            btnExprotarExcel.Enabled = true;
        }

        public bool validarCampos()
        {
            bool validar = true;
            if (txtNumIdentificacion.Text.Equals(""))
	        {
		        funciones.mostrarMensaje("El campo de identificacón no pude ser vacio","W");
                return false;
	        }
            if (cmbTipoIdentificacion.SelectedIndex < 0)
	        {
                funciones.mostrarMensaje("Debe selecionar un tipo de documento","W");
                return false;
	        }
            return validar;
        }

        private void btnExprotarExcel_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
                funciones.exportarDataGridViewAExcel(saveFileDialog1.FileName, "Reporte Acuerdos de Pago", tblAcuerdos);
        }

        private void cmbTipoIdentificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            funciones.lanzarTapConEnter(e);
        }

        private void btnVerDocumento_Click(object sender, EventArgs e)
        {

        }
    }
}
