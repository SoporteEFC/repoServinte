using System; using TransitoPrincipal; using LibreriasSintrat.utilidades;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibreriasSintrat.ServiciosConfiguraciones;
using LibreriasSintrat.ServiciosLiquidacionComp;
using LibreriasSintrat.ServiciosReciboscomparendo;
using LibreriasSintrat.ServiciosComparendos;
using LibreriasSintrat.ServiciosLiquidadorComparendos;
using LibreriasSintrat.ServiciosGeneralesComp;
using LibreriasSintrat.ServiciosAccesoriasComp;
using LibreriasSintrat.ServiciosUsuarios;
using LibreriasSintrat.utilidades;
using System.Globalization;

namespace Comparendos.servicios.liquidacion
{
    public enum AccionBuscarFactura
    {
        Pagar,
        Anular,
        Buscar
    }

    public partial class PagarFactura : Form
    {
        ServiciosConfiguracionesService serviciosConfiguraciones;
        ServiciosLiquidacionCompService serviciosLiquidacionComp;
        ServiciosReciboscomparendoService serviciosReciboscomparendo;
        ServiciosComparendosService serviciocomparendos;
        ServiciosLiquidadorComparendosService serviciosLiquidadorComparendos;
        ServiciosGeneralesCompService serviciosGenerales;
        ServiciosAccesoriasCompService serviciosAccesorias;
        liquidacionComp liquidacion;
        reciboscomparendo reciboscomparendo;
        LibreriasSintrat.ServiciosLiquidadorComparendos.comparendoComp comparendo;
        object[] comparendos;
        Funciones funciones;
        usuarios myUsuario;
        DataTable dtFormaPago;
        bool usaRunt;
        AccionBuscarFactura accionBuscarFactura;
        bool conDialogResult = false;

        CultureInfo culturaEspaniolCol = new CultureInfo("es-CO", false);


        public bool ConDialogResult
        {
            get { return conDialogResult; }
            set { conDialogResult = value; }
        }

        public PagarFactura(string numeroComparendo, usuarios myUsuario)
        {
            InitializeComponent();
            Constructor(numeroComparendo, myUsuario, AccionBuscarFactura.Pagar);
        }

        public PagarFactura(string numeroComparendo, usuarios myUsuario, AccionBuscarFactura accion)
        {
            InitializeComponent();
            Constructor(numeroComparendo, myUsuario, accion);
        }

        private void Constructor(string numeroComparendo, usuarios myUsuario, AccionBuscarFactura accion)
        {
            accionBuscarFactura = accion;
            InicializarObjetos();
            LlenarFormulario();
            LimpiarFormulario();
            BloquearFormulario();
            if (numeroComparendo != null && numeroComparendo != "")
            {
                ConsultarFacturaPorComparendo(numeroComparendo);
                txtNumeroRecibo.Enabled = false;
                AccionConsultarRecibo();
            }
            else txtNumeroRecibo.Enabled = true;
            txtNumeroOrigen.Text = txtNumeroRecibo.Text;
            this.myUsuario = myUsuario;
        }

        public void BuscarRecibo(string nroRecibo)
        {
            txtNumeroRecibo.Text = nroRecibo;
        }

        private void BloquearFormulario()
        {
            switch (accionBuscarFactura)
            {
                case AccionBuscarFactura.Pagar:
                    groupBox1.BackColor = Control.DefaultBackColor;
                    cmbOrigenPago.Enabled = true;
                    txtNumeroOrigen.Enabled = true;
                    calFechaOrigen.Enabled = true;
                    txtNroReciboEntBancaria.Enabled = true;
                    btnFormaPago.Enabled = true;
                    calFechaPago.Enabled = true;
                    groupBox1.Visible = true;
                    this.Text = "Pagar Factura";
                    btnPagar.Visible = true;
                    btnAnularPago.Visible = false;
                    break;
                case AccionBuscarFactura.Anular:
                    groupBox1.BackColor = Color.LightGray;
                    cmbOrigenPago.Enabled = false;
                    txtNumeroOrigen.Enabled = false;
                    calFechaOrigen.Enabled = false;
                    txtNroReciboEntBancaria.Enabled = false;
                    btnFormaPago.Enabled = false;
                    calFechaPago.Enabled = false;
                    groupBox1.Visible = false;
                    this.Text = "Anular Pago";
                    btnPagar.Visible = false;
                    btnAnularPago.Visible = true;
                    break;
            }
        }

        private void LlenarFormulario()
        {
            object[] objs = serviciosGenerales.listarOrigenDescargo();
            if (objs != null && objs.Length > 0)
            {
                cmbOrigenPago.ValueMember = "ID";
                cmbOrigenPago.DisplayMember = "DESCRIPCION";
                funciones.llenarCombo(cmbOrigenPago, objs);
            }
        }

        private void InicializarObjetos()
        {
            serviciosConfiguraciones = WS.ServiciosConfiguracionesService();
            serviciosReciboscomparendo = WS.ServiciosReciboscomparendoService();
            serviciocomparendos = WS.ServiciosComparendosService();
            serviciosLiquidadorComparendos = WS.ServiciosLiquidadorComparendosService();
            serviciosGenerales = WS.ServiciosGeneralesCompService();
            serviciosAccesorias = WS.ServiciosAccesoriasCompService();
            serviciosLiquidacionComp = WS.ServiciosLiquidacionCompService();
            usaRunt = serviciosConfiguraciones.UsaRunt();
            funciones = new Funciones();
        }

        private void LimpiarFormulario()
        {
            liquidacion = null;
            reciboscomparendo = null;
            comparendo = null;

            labIdenfificacion.Text = "Identificación:";
            labNumeroOrigen.Text = "Número:";
            txtApellido.Text = "";
            txtDireccion.Text = "";
            txtIdentificacion.Text = "";
            txtNombre.Text = "";
            txtNumeroRecibo.Text = "";
            txtRecibido.Text = "";
            txtSaldo.Text = "";
            txtTelefono.Text = "";
            txtTotalDeuda.Text = "";
            tblComparendos.DataSource = null;
            btnPagar.Enabled = false;
            txtNumeroRecibo.Enabled = true;
            txtValor.Text = "";
            labNumeroOrigen.Text = "Número origen:";
            calFechaOrigen.Value = DateTime.Now;
            calFechaPago.Value = DateTime.Now;
            txtFormaPago.Text = "";
            btnFormaPago.Enabled = true;
            txtNumeroOrigen.Text = "";
        }

        private void txtNumeroRecibo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones myFnc = new Funciones();
            myFnc.esNumero(e);
        }

        private void txtNumeroRecibo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AccionConsultarRecibo();
            }
        }

        public void AccionConsultarRecibo()
        {
            btnPagar.Enabled = false;
            if (txtNumeroRecibo.Text != "")
            {
                object[] objs;
                //buscamos el recibo comparendo
                if (reciboscomparendo == null)
                {
                    //buscamos el recibo comparendo
                    reciboscomparendo = new reciboscomparendo();
                    reciboscomparendo.NUMERO_RECIBO = txtNumeroRecibo.Text;
                    if (accionBuscarFactura == AccionBuscarFactura.Pagar)
                        reciboscomparendo.ESTADO = 14;
                    else if (accionBuscarFactura == AccionBuscarFactura.Anular)
                        reciboscomparendo.ESTADO = 2;
                    objs = serviciosReciboscomparendo.buscarReciboscomparendo(reciboscomparendo);
                    if (objs != null && objs.Length > 0)
                    {
                        reciboscomparendo = (reciboscomparendo)objs[0];
                    }
                    else
                    {
                        reciboscomparendo = null;
                        if (accionBuscarFactura == AccionBuscarFactura.Pagar)
                            funciones.mostrarMensaje("El recibo buscado no se encuentra o se encuentra en estado PAGADO", "W");
                        else if (accionBuscarFactura == AccionBuscarFactura.Anular)
                            funciones.mostrarMensaje("El recibo buscado no se encuentra o se encuentra en estado no PAGADO", "W");
                        return;
                    }
                }
                else
                {
                    if (reciboscomparendo.NUMERO_RECIBO != txtNumeroRecibo.Text)
                    {
                        //buscamos nuevo recibo comparendo
                        reciboscomparendo = new reciboscomparendo();
                        reciboscomparendo.NUMERO_RECIBO = txtNumeroRecibo.Text;
                        objs = serviciosReciboscomparendo.buscarReciboscomparendo(reciboscomparendo);
                        if (objs != null && objs.Length > 0)
                        {
                            reciboscomparendo = (reciboscomparendo)objs[0];
                        }
                        else
                        {
                            reciboscomparendo = null;
                            funciones.mostrarMensaje("El recibo buscado no se encuentra", "W");
                            return;
                        }
                    }
                }
                //buscamos la liquidacion
                if (liquidacion == null)
                {
                    //buscar nueva liquidacion
                    liquidacion = new liquidacionComp();
                    liquidacion.IDLIQUIDACION = reciboscomparendo.IDLIQUIDACION;
                    objs = serviciosLiquidacionComp.getLiquidaciones(liquidacion);
                    if (objs != null && objs.Length > 0)
                    {
                        liquidacion = (liquidacionComp)objs[0];
                    }
                    else
                    {
                        liquidacion = null;
                        funciones.mostrarMensaje("El recibo no tiene una liquidación enlazada", "W");
                        return;
                    }
                }
                else
                {
                    if (reciboscomparendo.IDLIQUIDACION != liquidacion.IDLIQUIDACION)
                    {
                        //buscar reemplazo de liquidacion
                        liquidacion = new liquidacionComp();
                        liquidacion.IDLIQUIDACION = reciboscomparendo.IDLIQUIDACION;
                        objs = serviciosLiquidacionComp.getLiquidaciones(liquidacion);
                        if (objs != null && objs.Length > 0)
                        {
                            liquidacion = (liquidacionComp)objs[0];
                        }
                        else
                        {
                            liquidacion = null;
                            funciones.mostrarMensaje("El recibo no tiene una liquidación enlazada", "W");
                            return;
                        }
                    }
                }

                txtNumeroOrigen.Text = txtNumeroRecibo.Text;
                txtSaldo.Text = liquidacion.SALDO.ToString("C", culturaEspaniolCol);
                txtRecibido.Text = "" + (liquidacion.TOTAL - liquidacion.SALDO).ToString("C", culturaEspaniolCol);
                txtTotalDeuda.Text = liquidacion.TOTAL.ToString("C", culturaEspaniolCol);
                txtValor.Text = reciboscomparendo.VALOR.ToString("C", culturaEspaniolCol);
                txtValorFactura.Text = reciboscomparendo.VALOR.ToString("C", culturaEspaniolCol);
                //buscamos datos liquidacion
                datosLiquidacion datosliquidacion = new datosLiquidacion();
                datosliquidacion.IDLIQUIDACION = liquidacion.IDLIQUIDACION.ToString();
                object[] objsDatosLiquidacion;
                comparendos = null;
                LibreriasSintrat.ServiciosGeneralesComp.infractorComp infractor = null;

                objsDatosLiquidacion = serviciosLiquidadorComparendos.getDatosLiquidacion(datosliquidacion);
                if (objsDatosLiquidacion != null && objsDatosLiquidacion.Length > 0)
                {
                    for (int i = 0; i < objsDatosLiquidacion.Length; i++)
                    {
                        datosliquidacion = (datosLiquidacion)objsDatosLiquidacion[i];
                        //buscamos la infraccion comparendo
                        LibreriasSintrat.ServiciosGeneralesComp.infracionComparendoComp infraccioncomparendo = new LibreriasSintrat.ServiciosGeneralesComp.infracionComparendoComp();
                        infraccioncomparendo.ID = int.Parse(datosliquidacion.IDINFRACCION);
                        infraccioncomparendo = serviciosGenerales.getInfraccionComparendo(infraccioncomparendo);
                        if (infraccioncomparendo != null && infraccioncomparendo.IDINFRACCION > 0)
                        {
                            //buscamos el comparendo
                            comparendo = new LibreriasSintrat.ServiciosLiquidadorComparendos.comparendoComp();
                            comparendo.ID_COMPARENDO = infraccioncomparendo.IDCOMPARENDO;
                            objs = serviciosLiquidadorComparendos.searchComparendo(comparendo);
                            if (!funciones.ExistenObjetosEnLista(comparendos, objs, new string[] { "ID_COMPARENDO" }, new string[] { "ID_COMPARENDO" }))
                            {
                                comparendos = funciones.unirArrayObject(comparendos, objs);
                                if (objs != null && objs.Length > 0)
                                {
                                    comparendo = (LibreriasSintrat.ServiciosLiquidadorComparendos.comparendoComp)objs[0];
                                    //buscamos el infractor
                                    if (infractor == null || infractor.ID_INFRACTOR != comparendo.ID_INFRACTOR)
                                    {
                                        infractor = new LibreriasSintrat.ServiciosGeneralesComp.infractorComp();
                                        infractor.ID_INFRACTOR = comparendo.ID_INFRACTOR;
                                        infractor = serviciosGenerales.buscarInfractor(infractor);
                                        if (infractor.ID_INFRACTOR >= 0)
                                        {
                                            //llenamos los datos del formulario
                                            txtApellido.Text = infractor.APELLIDOS;
                                            txtDireccion.Text = infractor.DIRECCION;
                                            txtIdentificacion.Text = infractor.NROIDENTIFICACION;
                                            //buscamos el documento tipo
                                            documentoComp documento = new documentoComp();
                                            documento.ID_DOCCOMP = infractor.ID_DOCTO;
                                            objs = serviciosAccesorias.obtenerTipoDocumento(documento);
                                            if (objs != null && objs.Length > 0)
                                            {
                                                documento = (documentoComp)objs[0];
                                                labIdenfificacion.Text = documento.DESCRIPCION;
                                            }
                                            else
                                            {
                                                funciones.mostrarMensaje("No se encuentra la descripcion del tipo de documento", "W");
                                            }

                                            txtNombre.Text = infractor.NOMBRES;
                                            txtTelefono.Text = infractor.TELEFONO;
                                            btnPagar.Enabled = true;
                                        }
                                        else
                                        {
                                            funciones.mostrarMensaje("No se pudo encontrar los datos del infractor", "W");
                                        }
                                    }
                                }
                                else
                                {
                                    //funciones.mostrarMensaje("La liquidación no tiene comparendos enlazados", "W");
                                    //return;
                                }
                            }
                        }
                        else
                        {
                            //funciones.mostrarMensaje("No se encontro informacion sobre las infracciones enlazadas al recibo", "W");
                        }
                    }

                    LlenarTblComparendos();
                }
                else
                {
                    funciones.mostrarMensaje("No se encontraron los datos de la liquidacion del recibo", "W");
                }
            }
            else
            {
                funciones.mostrarMensaje("Ingrese el numero de la factura", "E");
            }
        }

        private void ConsultarFacturaPorComparendo(string numeroComparendo)
        {
            object[] objs = null;
            int a = 0;
            //buscamos el comparendo
            comparendo = new LibreriasSintrat.ServiciosLiquidadorComparendos.comparendoComp();
            comparendo.NUMEROCOMPARENDO = numeroComparendo;
            objs = serviciosLiquidadorComparendos.searchComparendo(comparendo);
            if (objs != null && objs.Length > 0)
            {
                a = objs.Length - 1;
                comparendo = (LibreriasSintrat.ServiciosLiquidadorComparendos.comparendoComp)objs[a];
                //buscamos la infraccion comparendo
                LibreriasSintrat.ServiciosGeneralesComp.infracionComparendoComp infraccioncomparendo = new LibreriasSintrat.ServiciosGeneralesComp.infracionComparendoComp();
                infraccioncomparendo.IDCOMPARENDO = comparendo.ID_COMPARENDO;
                infraccioncomparendo = serviciosGenerales.getInfraccionComparendo(infraccioncomparendo);
                if (infraccioncomparendo != null && infraccioncomparendo.IDINFRACCION > 0)
                {
                    //buscamos en datos liquidacion
                    datosLiquidacion datosliquidacion = new datosLiquidacion();
                    datosliquidacion.IDINFRACCION = infraccioncomparendo.ID.ToString();
                    objs = serviciosLiquidadorComparendos.getDatosLiquidacion(datosliquidacion);
                    if (objs != null && objs.Length > 0)
                    {
                        a = objs.Length - 1;
                        datosliquidacion = (datosLiquidacion)objs[a];
                        //buscamos liquidacion
                        liquidacionComp liquidacion = new liquidacionComp();
                        liquidacion.IDLIQUIDACION = int.Parse(datosliquidacion.IDLIQUIDACION);
                        objs = serviciosLiquidacionComp.getLiquidaciones(liquidacion);
                        if (objs != null && objs.Length > 0)
                        {
                            a = objs.Length - 1;
                            liquidacion = (liquidacionComp)objs[a];
                            this.liquidacion = liquidacion;
                            //buscamos el recibo de comparendos al cual pertenece la liquidacion
                            reciboscomparendo reciboscomparendo = new reciboscomparendo();
                            reciboscomparendo.IDLIQUIDACION = liquidacion.IDLIQUIDACION;
                            objs = serviciosReciboscomparendo.buscarReciboscomparendo(reciboscomparendo);
                            if (objs != null && objs.Length > 0)
                            {
                                //cambiamos el numero de recibo del formulario para habilitar 
                                //la busqueda por num recibo y asi activar el text_changed del textbox
                                a = objs.Length - 1;
                                reciboscomparendo = (reciboscomparendo)objs[a];
                                txtNumeroRecibo.Text = reciboscomparendo.NUMERO_RECIBO;
                                this.reciboscomparendo = reciboscomparendo;
                            }
                            else
                            {
                                funciones.mostrarMensaje("La liquidación del comparendo no fue enlazada a una factura", "W");
                            }
                        }
                        else
                        {
                            funciones.mostrarMensaje("El numero de comparando enviado no contiene datos de liquidación", "W");
                        }
                    }
                    else
                    {
                        funciones.mostrarMensaje("No se encontraron datos de liquidacion para el comparendo", "W");
                    }
                }
                else
                {
                    funciones.mostrarMensaje("No se encontro datos de las infracciones para el comparendo", "W");
                }
            }
            else 
            {
                funciones.mostrarMensaje("No se pudo encontrar los datos del comparendo", "W");
            }
        }

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
            DataRow dr;
            LibreriasSintrat.ServiciosLiquidadorComparendos.comparendoComp comparendo;
            if (comparendos != null)
            {
                for (int i = 0; i < comparendos.Length; i++)
                {
                    dr = dt.NewRow();
                    comparendo = (LibreriasSintrat.ServiciosLiquidadorComparendos.comparendoComp)comparendos[i];
                    dr["#"] = "" + i;
                    dr["NUMERO COMPARENDO"] = comparendo.NUMEROCOMPARENDO;
                    dr["POLCA"] = comparendo.POLCA;
                    dr["VEHICULO"] = comparendo.PLACA;
                    dr["VALOR"] = comparendo.VALOR;
                    dr["FECHA"] = DateTime.Parse(comparendo.FECHACOMPARENDO, System.Globalization.CultureInfo.InvariantCulture).ToString("dd/MM/yyyy");
                    dr["FECHA REGISTRO"] = DateTime.Parse(comparendo.FECHAREGISTRO, System.Globalization.CultureInfo.InvariantCulture).ToString("dd/MM/yyyy");
                    dt.Rows.Add(dr);
                }
            }
            tblComparendos.DataSource = dt;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                LimpiarFormulario();
            }
            catch (Exception exp)
            {
                funciones.mostrarMensaje("Error realizando la funcionalidad. " + exp.Message, "E");
            }
        }

        private void cmbOrigenPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbOrigenPago.SelectedValue.ToString() == "2")
            {
                labNumeroOrigen.Text = "Número de oficio:";
                txtNumeroOrigen.Text = "";
                btnFormaPago.Enabled = false;
            }
            else if (cmbOrigenPago.SelectedValue.ToString() == "3")
            {
                labNumeroOrigen.Text = "Número recibo de pago:";
                txtNumeroOrigen.Text = "";
                btnFormaPago.Enabled = false;
            }
            else
            {
                labNumeroOrigen.Text = "Número origen:";
                txtNumeroOrigen.Text = txtNumeroRecibo.Text;
                btnFormaPago.Enabled = true;
            }
        }

        private void btnFormaPago_Click(object sender, EventArgs e)
        {
            try
            {
                //double valorRecibo = double.Parse(txtTotalDeuda.Text == "" ? "0" : txtTotalDeuda.Text);
                double valorRecibo = funciones.strToDouble(funciones.moneyToStr(txtValorFactura.Text));//double.Parse(txtValorFactura.Text == "" ? "0" : txtValorFactura.Text);
                FFormaPago frm = new FFormaPago(valorRecibo);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    txtFormaPago.Text = frm.ToString();
                    dtFormaPago = frm.DtFormaPago;
                }
            }
            catch (Exception exp)
            {
                funciones.mostrarMensaje("Error realizando la funcionalidad. " + exp.Message, "E");
            }
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCampos())
                {
                    bool pago;
                    //actualizamos recibo de pago
                    reciboscomparendo.ESTADO = 2;
                    reciboscomparendo.IDUSRPAGO = myUsuario.ID_USUARIO;
                    reciboscomparendo.NROCONSIGNACIONBANCO = txtNroReciboEntBancaria.Text == "" ?
                    reciboscomparendo.NUMERO_RECIBO : txtNroReciboEntBancaria.Text;
                    reciboscomparendo.IDORIGENPAGO = int.Parse(cmbOrigenPago.SelectedValue.ToString());
                    reciboscomparendo.NUMEROOFICIO = txtNumeroOrigen.Text;

                    reciboscomparendo.FECHAOFICIO = funciones.convFormatoFecha(calFechaOrigen.Text, "MM/dd/yyyy");
                    reciboscomparendo.FECHAPAGO = funciones.convFormatoFecha(calFechaPago.Text, "MM/dd/yyyy");

                    //El servidor recibe fechas en formato "MM/dd/yyyy"
                    reciboscomparendo.FECHACREACION = DateTime.Parse(reciboscomparendo.FECHACREACION, System.Globalization.CultureInfo.InvariantCulture).ToString("MM/dd/yyyy");
                    reciboscomparendo.FECHAREGISTRO = DateTime.Parse(reciboscomparendo.FECHAREGISTRO, System.Globalization.CultureInfo.InvariantCulture).ToString("MM/dd/yyyy");

                    pago = serviciosReciboscomparendo.editarReciboscomparendo(reciboscomparendo);


                    if (pago)
                    {
                        //actualizamos liquidacion
                        liquidacion.SALDO = liquidacion.SALDO - (float)reciboscomparendo.VALOR;
                        if (liquidacion.SALDO < 0) liquidacion.SALDO = 0;

                        //El servidor recibe fechas en formato "MM/dd/yyyy"
                        liquidacion.FECHA = DateTime.Parse(liquidacion.FECHA, System.Globalization.CultureInfo.InvariantCulture).ToString("MM/dd/yyyy");
                        liquidacion.FECHAREGISTRO = DateTime.Parse(liquidacion.FECHAREGISTRO, System.Globalization.CultureInfo.InvariantCulture).ToString("MM/dd/yyyy");
                        if(liquidacion.HORAREGISTRO!=null)
                            liquidacion.HORAREGISTRO = DateTime.Parse(liquidacion.HORAREGISTRO, System.Globalization.CultureInfo.InvariantCulture).ToString("HH:mm");

                        pago = serviciosLiquidacionComp.editarLiquidacion(liquidacion, WS.MyUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName());
                        if (pago)
                        {
                            if (cmbOrigenPago.SelectedValue.ToString() != "2" &&
                                cmbOrigenPago.SelectedValue.ToString() != "3")
                            {
                                formaPago formapago;
                                if (dtFormaPago != null && dtFormaPago.Rows.Count > 0)
                                {
                                    foreach (DataRow dr in dtFormaPago.Rows)
                                    {
                                        formapago = new formaPago();
                                        formapago.ID_TIPOPAGO = int.Parse(dr["IDTIPOPAGO"].ToString());
                                        formapago.IDORIGENDESCARGO = reciboscomparendo.IDORIGENPAGO;
                                        formapago.IDRECIBO = reciboscomparendo.ID;
                                        formapago.IDTRANSITOSERVICIOBANCO = dr["IDBANCO"].ToString() == "NO APLICA" ?
                                            0 : int.Parse(dr["IDBANCO"].ToString());
                                        formapago.IDUSUARIO = myUsuario.ID_USUARIO;
                                        formapago.NUMEROCHEQUE = dr["NRO. CHEQUE"].ToString() == "NO APLICA" ?
                                            "" : dr["NRO. CHEQUE"].ToString();
                                        formapago.VALOR = double.Parse(dr["VALOR"].ToString());
                                        formapago = serviciosGenerales.crearFormaPago(formapago);
                                    }
                                }
                                else
                                {
                                    formapago = new formaPago();
                                    formapago.ID_TIPOPAGO = 1;
                                    formapago.IDORIGENDESCARGO = reciboscomparendo.IDORIGENPAGO;
                                    formapago.IDRECIBO = reciboscomparendo.ID;
                                    formapago.IDUSUARIO = myUsuario.ID_USUARIO;
                                    formapago.VALOR = reciboscomparendo.VALOR;
                                    formapago = serviciosGenerales.crearFormaPago(formapago);
                                }
                            }

                            object[] objs;
                            bool edited = false;
                            //actualizar pagoscomparendo
                            //solo se actualiza el pago que corresponde al recibo
                            //buscamos el recibo cuota
                            recibocuotas reciboCuota = new recibocuotas();
                            reciboCuota.IDRECIBO = reciboscomparendo.ID;
                            objs = serviciosLiquidacionComp.getReciboCuota(reciboCuota);
                            if (objs != null && objs.Length > 0)
                            {
                                reciboCuota = (recibocuotas)objs[0];
                                //buscamos pago
                                pagosComp pagoscomp = new pagosComp();
                                pagoscomp.ID = reciboCuota.IDCUOTA;
                                objs = serviciosLiquidacionComp.getPagosComp(pagoscomp);
                                if (objs != null && objs.Length > 0)
                                {
                                    for (int i = 0; i < objs.Length; i++)
                                    {
                                        pagoscomp = (pagosComp)objs[i];
                                        pagoscomp.ESTADO = 2;

                                        //El servidor recibe fechas en formato "MM/dd/yyyy"
                                        pagoscomp.FECHAPAGO = DateTime.Parse(pagoscomp.FECHAPAGO, System.Globalization.CultureInfo.InvariantCulture).ToString("MM/dd/yyyy");
                                        edited = serviciosLiquidacionComp.editarPagosComp(pagoscomp, WS.MyUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName());
                                    }
                                }
                                else
                                {
                                    pagoscomp.ESTADO = 2;
                                    pagoscomp.NOCUOTA = 1;
                                    pagoscomp.PORCENTAJE = 100;
                                    pagoscomp.VALOR = liquidacion.TOTAL;
                                    pagoscomp = serviciosLiquidacionComp.registarConFechaPagoComp(pagoscomp, WS.MyUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName());
                                }
                            }

                            //actualizar pagoscomparendo
                            //solo se actualiza el pago que corresponde al recibo
                            //pagosComp pagoscomp = new pagosComp();
                            //pagoscomp.IDLIQUIDACION = liquidacion.IDLIQUIDACION;
                            //objs = serviciosLiquidacionComp.getPagosComp(pagoscomp);
                            //if (objs != null && objs.Length > 0)
                            //{
                            //    for (int i = 0; i < objs.Length; i++)
                            //    {
                            //        pagoscomp = (pagosComp)objs[i];
                            //        pagoscomp.ESTADO = 2;
                            //        edited = serviciosLiquidacionComp.editarPagosComp(pagoscomp);
                            //    }
                            //}
                            //else
                            //{
                            //    pagoscomp.ESTADO = 2;
                            //    pagoscomp.NOCUOTA = 1;
                            //    pagoscomp.PORCENTAJE = 100;
                            //    pagoscomp.VALOR = liquidacion.TOTAL;
                            //    pagoscomp = serviciosLiquidacionComp.registarConFechaPagoComp(pagoscomp);
                            //}
                            //actualizar infraccioncomparendo
                            for (int a = 0; a < comparendos.Length; a++)
                            {
                                comparendo = (LibreriasSintrat.ServiciosLiquidadorComparendos.comparendoComp)comparendos[a];
                                LibreriasSintrat.ServiciosGeneralesComp.infracionComparendoComp infraccioncomparendo = new LibreriasSintrat.ServiciosGeneralesComp.infracionComparendoComp();
                                infraccioncomparendo.IDCOMPARENDO = comparendo.ID_COMPARENDO;
                                objs = serviciosGenerales.getInfraccionComparendos(infraccioncomparendo);
                                if (objs != null && objs.Length > 0)
                                {
                                    for (int i = 0; i < objs.Length; i++)
                                    {
                                        infraccioncomparendo = (LibreriasSintrat.ServiciosGeneralesComp.infracionComparendoComp)objs[i];
                                        infraccioncomparendo.IDESTADO = liquidacion.SALDO <= 0 ? 2 : 20;
                                        edited = serviciosGenerales.actualizarInfraccionComparendo(infraccioncomparendo, WS.MyUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName());
                                    }
                                }
                            }
                            if (pago)
                            {
                                funciones.mostrarMensaje("La factura ha sido pagada exitósamente", "I");
                                LimpiarFormulario();
                                if (conDialogResult) DialogResult = DialogResult.OK;
                            }
                        }
                        else
                        {
                            funciones.mostrarMensaje("Error actualizando la informacion de la liquidacion", "W");
                        }
                    }
                    else
                    {
                        funciones.mostrarMensaje("Error actualizando la informacion del recibo de pago", "W");
                    }
                }
            }
            catch (Exception exp)
            {
                funciones.mostrarMensaje("Error realizando la funcionalidad. " + exp.Message, "E");
            }
        }

        private bool ValidarCampos()
        {
            if (liquidacion == null)
            {
                funciones.mostrarMensaje("No existen datos de liquidación, no se puede continuar con el pago", "E");
                return false;
            }
            else if (reciboscomparendo == null)
            {
                funciones.mostrarMensaje("No existen datos de la factura, no se puede continuar con el pago", "E");
                return false;
            }
            else if (cmbOrigenPago.SelectedIndex == -1)
            {
                funciones.mostrarMensaje("Debe seleccionar una tipo de origen del pago", "E");
                return false;
            }
            return true;
        }

        private void txtNumeroRecibo_Leave(object sender, EventArgs e)
        {
            //AccionConsultarRecibo();
        }

        private void btnAnularPago_Click(object sender, EventArgs e)
        {
            try
            {
                if (accionBuscarFactura == AccionBuscarFactura.Anular)
                {
                    object[] objs;
                    bool deleted;
                    bool edited;
                    //buscamos la forma de pago para el recibo
                    formaPago formapago = new formaPago();
                    formapago.IDRECIBO = reciboscomparendo.ID;
                    objs = serviciosGenerales.getFormaPago(formapago);
                    if (objs != null && objs.Length > 0)
                    {
                        formapago = (formaPago)objs[0];
                        //eliminamos la forma de pago
                        deleted = serviciosGenerales.eliminarFormaPago(formapago, WS.MyUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName());
                        if (deleted)
                        {
                            //editar recibo comparendo consultado previamente
                            reciboscomparendo.ESTADO = 14;
                            edited = serviciosReciboscomparendo.editarReciboscomparendo(reciboscomparendo);
                            if (edited)
                            {
                                //editar liquidacion consutlado previamente
                                liquidacion.SALDO += liquidacion.TOTAL;
                                if (liquidacion.SALDO < 0) liquidacion.SALDO = 0;
                                edited = serviciosLiquidacionComp.editarLiquidacion(liquidacion, WS.MyUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName());
                                if (edited)
                                {
                                    //actualizar pagoscomparendo
                                    //solo se actualiza el pago que corresponde al recibo
                                    //buscamos el recibo cuota
                                    recibocuotas reciboCuota = new recibocuotas();
                                    reciboCuota.IDRECIBO = reciboscomparendo.ID;
                                    objs = serviciosLiquidacionComp.getReciboCuota(reciboCuota);
                                    if (objs != null && objs.Length > 0)
                                    {
                                        reciboCuota = (recibocuotas)objs[0];
                                        //buscamos pago
                                        pagosComp pagoscomp = new pagosComp();
                                        pagoscomp.ID = reciboCuota.IDCUOTA;
                                        objs = serviciosLiquidacionComp.getPagosComp(pagoscomp);
                                        //pago completo de infraccioncomparendo
                                        int miestado = 11;
                                        if (objs != null)
                                        {
                                            //pago parcial de infraccioncomparendo
                                            if (objs.Length > 0)
                                            {
                                                miestado = 20;
                                            }
                                            for (int i = 0; i < objs.Length; i++)
                                            {
                                                pagoscomp = (pagosComp)objs[i];
                                                pagoscomp.ESTADO = 14; // 16;
                                                edited = serviciosLiquidacionComp.editarPagosComp(pagoscomp, WS.MyUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName());
                                            }
                                            if (!edited)
                                            {
                                                funciones.mostrarMensaje("Info, no se actualizaron ningun pago comparendo", "W");
                                            }
                                            //buscamos datos liquidacion
                                            datosLiquidacion datosliquidacion = new datosLiquidacion();
                                            datosliquidacion.IDLIQUIDACION = liquidacion.IDLIQUIDACION.ToString();
                                            objs = serviciosLiquidadorComparendos.getDatosLiquidacion(datosliquidacion);
                                            if (objs != null && objs.Length > 0)
                                            {
                                                for (int i = 0; i < objs.Length; i++)
                                                {
                                                    datosliquidacion = (datosLiquidacion)objs[i];
                                                    //buscar infraccionn comparendo
                                                    LibreriasSintrat.ServiciosGeneralesComp.infracionComparendoComp infraccioncomparendo = new LibreriasSintrat.ServiciosGeneralesComp.infracionComparendoComp();
                                                    infraccioncomparendo.ID = int.Parse(datosliquidacion.IDINFRACCION);
                                                    infraccioncomparendo = serviciosGenerales.getInfraccionComparendo(infraccioncomparendo);
                                                    if (infraccioncomparendo != null && infraccioncomparendo.ID > 0)
                                                    {
                                                        //actualizar infraccion comparendo
                                                        infraccioncomparendo.IDESTADO = miestado;
                                                        edited = serviciosGenerales.actualizarInfraccionComparendo(infraccioncomparendo, WS.MyUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName());

                                                    }
                                                    else
                                                    {
                                                        funciones.mostrarMensaje("Error, no se encontro ningun registro para infraccion comparendo", "W");
                                                    }
                                                }
                                                if (edited)
                                                {
                                                    funciones.mostrarMensaje("El pago de la factura ha sido anulado con exito!", "I");
                                                }
                                                else
                                                {
                                                    funciones.mostrarMensaje("Info, no se encontraron las infracciones comparendo", "W");
                                                }
                                                if (conDialogResult) DialogResult = DialogResult.OK;
                                                LimpiarFormulario();
                                            }
                                            else
                                            {
                                                funciones.mostrarMensaje("No se encontro los datos de la liquidacion", "W");
                                            }
                                        }
                                        else
                                        {
                                            funciones.mostrarMensaje("Error, no se encontro el pago asociado a la liquidacion", "W");
                                        }
                                    }
                                }
                                else
                                {
                                    funciones.mostrarMensaje("Error, no se pudo modificar el registro de liquidacion", "W");
                                }
                            }
                            else
                            {
                                funciones.mostrarMensaje("Error, no se pudo modificar el estaod del recibo a no pago", "W");
                            }
                        }
                        else
                        {
                            funciones.mostrarMensaje("Error, no se pudo eliminar el registro de forma de pago", "W");
                        }
                    }
                    else
                    {
                        funciones.mostrarMensaje("Error, el recibo no tiene forma de pago asociada", "W");
                    }
                }
            }             
            catch (Exception exp)
            {                
                funciones.mostrarMensaje("Error realizando la funcionalidad. " + exp.Message, "E");                
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                AccionConsultarRecibo();
            }
            catch (Exception exp)
            {
                funciones.mostrarMensaje("Error realizando la funcionalidad. " + exp.Message, "E");
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
