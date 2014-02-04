using System; using TransitoPrincipal; using LibreriasSintrat.utilidades;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibreriasSintrat.ServiciosUsuarios;
using LibreriasSintrat.ServiciosAccesoriasComp;
using System.Collections;
using LibreriasSintrat.ServiciosDocumentos;
using LibreriasSintrat.ServiciosConfiguraciones;
using LibreriasSintrat.ServiciosLiquidadorComparendos;
using LibreriasSintrat.ServiciosGeneralesComp;
using LibreriasSintrat.ServiciosReciboscomparendo;
using LibreriasSintrat.ServiciosLiquidacionComp;
using Comparendos.utilidades; using LibreriasSintrat.utilidades; using LibreriasSintrat;

using System.Globalization;

namespace Comparendos.servicios.liquidacion
{
    public partial class BuscarFactura : Form
    {
        //servicios
        ServiciosAccesoriasCompService serviciosAccesorias;
        ServiciosDocumentosService serviciosDocumentos;
        ServiciosConfiguracionesService serviciosConfiguraciones;
        ServiciosLiquidacionCompService serviciosLiquidacion;
        //objetos
        Funciones funciones;
        usuarios myUsuario;
        DataTable dtInfractor;
        
        Log log = new Log();
        CultureInfo culturaEspaniolCol = new CultureInfo("es-CO", false);

        public BuscarFactura(usuarios usuario)
        {
            log = new Log();
            try
            {
                InitializeComponent();
                myUsuario = usuario;
                InicializarObjetos();
                LlenarFormulario();
                InicializarControles();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                funciones.mostrarMensaje("Error inicializando el formulario. " + exp.Message, "E");
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void InicializarObjetos()
        {
            serviciosAccesorias = WS.ServiciosAccesoriasCompService();
            serviciosDocumentos = WS.ServiciosDocumentosService();
            serviciosConfiguraciones = WS.ServiciosConfiguracionesService();
            serviciosLiquidacion = WS.ServiciosLiquidacionCompService();
            funciones = new Funciones();
        }

        private void InicializarControles()
        {
            chkEstado.Checked = false;
            chkFecha.Checked = false;
            chkIdentifiacion.Checked = false;
            chkNroComparendo.Checked = false;
            chkNroRecibo.Checked = false;
            btnAnularPago.Enabled = false;
            btnEliminarLiquidacion.Enabled = false;
            btnPagar.Enabled = false;
            btnReimprimir.Enabled = false;
            HabilitarTextBox(txtIdentificacion, false);
            HabilitarTextBox(txtNroComparendo, false);
            HabilitarTextBox(txtNumeroRecibo, false);
            cmbEstado.Enabled = false;
            cmbTipoDocumento.Enabled = false;
            dtpFechaFinal.Enabled = false;
            dtpFechaInicial.Enabled = false;
            //info
            txtApellido.Text = "";
            txtCantidadRegistros.Text = "";
            txtDireccion.Text = "";
            txtIdentificacionRes.Text = "";
            txtNombre.Text = "";
            txtRecibido.Text = "";
            txtSaldo.Text = "";
            txtTelefono.Text = "";
            txtTotalDeuda.Text = "";
            txtValorFactura.Text = "";
        }

        // Funciones de formato o logica grafica

        private void HabilitarTextBox(TextBox txt, bool habilitar)
        {
            txt.ReadOnly = !habilitar;
            txt.BorderStyle = habilitar ? BorderStyle.Fixed3D : BorderStyle.FixedSingle;
            txt.Focus();
        }

        private void chkNroRecibo_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                HabilitarTextBox(txtNumeroRecibo, chkNroRecibo.Checked);
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                funciones.mostrarMensaje("Error cambiando el criterio de busqueda. " + exp.Message, "E");
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void chkNroComparendo_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                HabilitarTextBox(txtNroComparendo, chkNroComparendo.Checked);
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                funciones.mostrarMensaje("Error cambiando el criterio de busqueda. " + exp.Message, "E");
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void chkIdentifiacion_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                cmbTipoDocumento.Enabled = chkIdentifiacion.Checked;
                HabilitarTextBox(txtIdentificacion, chkIdentifiacion.Checked);
                cmbTipoDocumento.Focus();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                funciones.mostrarMensaje("Error cambiando el criterio de busqueda. " + exp.Message, "E");
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void chkEstado_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                cmbEstado.Enabled = chkEstado.Checked;
                cmbEstado.Focus();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                funciones.mostrarMensaje("Error cambiando el criterio de busqueda. " + exp.Message, "E");
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void chkFecha_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                dtpFechaFinal.Enabled = chkFecha.Checked;
                dtpFechaInicial.Enabled = chkFecha.Checked;
                dtpFechaInicial.Focus();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                funciones.mostrarMensaje("Error cambiando el criterio de busqueda. " + exp.Message, "E");
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        // Funciones de busqueda o limpieza

        private void LlenarFormulario()
        {
            funciones.llenarCombo(cmbTipoDocumento, serviciosAccesorias.obtenerTiposDocumento());
            funciones.llenarCombo(cmbEstado, serviciosAccesorias.listarEstadosComp());
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                AccionLimpiarFormulario();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                funciones.mostrarMensaje("Error limpiando los registros ya consultados. " + exp.Message, "E");
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void AccionLimpiarFormulario()
        {
            LimpiarContenido();
            InicializarControles();
        }

        private void LimpiarContenido()
        {
            tblRecibos.DataSource = null;
            tblComparendos.DataSource = null;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                AccionBuscar();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                funciones.mostrarMensaje("Error al realizar la busqueda en la base de datos. " + exp.Message, "E");
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void AccionBuscar()
        {
            String query;
            object[] objs;
            ArrayList campos;
            query = CrearSql(GetCamposRecibo(), GetCriterios());
            if (query != "")
            {
                objs = serviciosDocumentos.verificarConsultaComp(query);
                if (objs != null)
                {
                    campos = funciones.ObjectToArrayList(objs);
                    objs = serviciosDocumentos.executeQuery(query);
                    if (objs != null)
                    {
                        txtCantidadRegistros.Text = objs.Length + "";
                        DataTable dt = funciones.getData(funciones.ObjectToArrayList(objs), campos);
                        tblRecibos.DataSource = dt;
                        string[] columnas = {"VALOR","TOTAL","SALDO"};
                        funciones.tblFormatMoney(tblRecibos, columnas);
                        LlenarInfoRecibo();
                    }
                    else
                    {
                        funciones.mostrarMensaje("No hay registros para los criterios de busqueda seleccionados", "W");
                    }
                }
            }
            else
            {
                funciones.mostrarMensaje("Ingrese un criterio de busqueda", "W");
            }
        }

        private void LlenarInfoRecibo()
        {
            if (tblRecibos.DataSource != null)
            {
                //double total = double.Parse("0" + GetValorSeleccionado(tblRecibos, "total"));
                //double valor = double.Parse("0" + GetValorSeleccionado(tblRecibos, "valor"));
                //double saldo = double.Parse("0" + GetValorSeleccionado(tblRecibos, "saldo"));
                //txtValorFactura.Text = "" + (valor == 0 ? total : valor);
                //txtSaldo.Text = "" + string.Format("{0:C}", GetValorSeleccionado(tblRecibos, "saldo"));
                //txtTotalDeuda.Text = "" + total;
                //txtRecibido.Text = "" + (total - saldo);
                
                txtValorFactura.Text = funciones.formatMoney(GetValorSeleccionado(tblRecibos, "valor"));
                txtSaldo.Text = funciones.formatMoney(GetValorSeleccionado(tblRecibos, "saldo"));
                txtTotalDeuda.Text = funciones.formatMoney(GetValorSeleccionado(tblRecibos, "total"));
                txtRecibido.Text = (funciones.strToDouble(GetValorSeleccionado(tblRecibos, "total"))-funciones.strToDouble(GetValorSeleccionado(tblRecibos, "saldo"))).ToString("C", culturaEspaniolCol);
            }
        }

        private void LlenarInfoInfractor()
        {
            if (dtInfractor != null)
            {
                txtApellido.Text = "" + GetValorSeleccionado(dtInfractor, 0, "APELLIDOS");
                txtDireccion.Text = "" + GetValorSeleccionado(dtInfractor, 0, "direccion");
                txtIdentificacionRes.Text = "" + GetValorSeleccionado(dtInfractor, 0, "NROIDENTIFICACION");
                txtNombre.Text = "" + GetValorSeleccionado(dtInfractor, 0, "NOMBRES");
                txtTelefono.Text = "" + GetValorSeleccionado(dtInfractor, 0, "telefono");
            }
        }

        private string CrearSql(string campos, string criterios)
        {
            string sql = "";
            if (chkNroRecibo.Checked || chkFecha.Checked)
            {
                sql = CrearSqlRecibo(campos, criterios);
            }
            else if (chkNroComparendo.Checked || chkEstado.Checked)
            {
                sql = CrearSqlComparendo(campos, criterios);
            }
            else if (chkIdentifiacion.Checked)
            {
                sql = CrearSqlInfractor(campos, criterios);
            }
            return sql;
        }

        private string CrearSqlInfractor(string campos, string criterios)
        {
            string sql = "SELECT DISTINCT " +
                campos + " " +
                "FROM INFRACTOR " +
                "INNER JOIN COMPARENDO ON (COMPARENDO.ID_INFRACTOR = INFRACTOR.ID_INFRACTOR) " +
                "INNER JOIN INFRACCIONCOMPARENDO ON (COMPARENDO.ID_COMPARENDO = INFRACCIONCOMPARENDO.IDCOMPARENDO) " +
                "INNER JOIN INFRACCIONES ON (INFRACCIONCOMPARENDO.IDINFRACCION = INFRACCIONES.ID_INFRACCION) " +
                "INNER JOIN ESTADOCOM ESTADOINFRACCION ON (INFRACCIONCOMPARENDO.IDESTADO = ESTADOINFRACCION.ID_ESTADO) " +
                "INNER JOIN DATOSLIQUIDACION ON (DATOSLIQUIDACION.idinfraccion = INFRACCIONCOMPARENDO.id) " +
                "INNER JOIN LIQUIDACION ON (LIQUIDACION.idliquidacion = DATOSLIQUIDACION.idliquidacion) " +
                "INNER JOIN RECIBOSCOMPARENDO ON (RECIBOSCOMPARENDO.idliquidacion = LIQUIDACION.idliquidacion) " +
                "INNER JOIN RECIBOCUOTAS ON (RECIBOSCOMPARENDO.id = RECIBOCUOTAS.idrecibo) " +
                "INNER JOIN pagoscomparendo ON (RECIBOCUOTAS.idcuota = pagoscomparendo.id) " +
                "INNER JOIN ESTADOCOM ESTADOPAGO ON (pagoscomparendo.estado = ESTADOPAGO.ID_ESTADO) " +
                "INNER JOIN ESTADOCOM ESTADORECIBO ON (RECIBOSCOMPARENDO.estado = ESTADORECIBO.ID_ESTADO) " +
                "LEFT OUTER JOIN HISTORICOESTADOSCOM ON (INFRACCIONCOMPARENDO.ID = HISTORICOESTADOSCOM.ID_INFRACCIONCOMPARENDO) " +
                "WHERE 1 = 1 " +
                criterios;
            return sql;
        }

        private string CrearSqlComparendo(string campos, string criterios)
        {
            string sql = "SELECT DISTINCT " +
                campos + " " +
                "FROM COMPARENDO " +
                "INNER JOIN INFRACTOR ON (COMPARENDO.ID_INFRACTOR = INFRACTOR.ID_INFRACTOR) " +
                "INNER JOIN INFRACCIONCOMPARENDO ON (COMPARENDO.ID_COMPARENDO = INFRACCIONCOMPARENDO.IDCOMPARENDO) " +
                "INNER JOIN INFRACCIONES ON (INFRACCIONCOMPARENDO.IDINFRACCION = INFRACCIONES.ID_INFRACCION) " +
                "INNER JOIN ESTADOCOM ESTADOINFRACCION ON (INFRACCIONCOMPARENDO.IDESTADO = ESTADOINFRACCION.ID_ESTADO) " +
                "INNER JOIN DATOSLIQUIDACION ON (DATOSLIQUIDACION.idinfraccion = INFRACCIONCOMPARENDO.id) " +
                "INNER JOIN LIQUIDACION ON (LIQUIDACION.idliquidacion = DATOSLIQUIDACION.idliquidacion) " +
                "INNER JOIN RECIBOSCOMPARENDO ON (RECIBOSCOMPARENDO.idliquidacion = LIQUIDACION.idliquidacion) " +
                "INNER JOIN RECIBOCUOTAS ON (RECIBOSCOMPARENDO.id = RECIBOCUOTAS.idrecibo) " +
                "INNER JOIN pagoscomparendo ON (RECIBOCUOTAS.idcuota = pagoscomparendo.id) " +
                "INNER JOIN ESTADOCOM ESTADOPAGO ON (pagoscomparendo.estado = ESTADOPAGO.ID_ESTADO) " +
                "INNER JOIN ESTADOCOM ESTADORECIBO ON (RECIBOSCOMPARENDO.estado = ESTADORECIBO.ID_ESTADO) " +
                "LEFT OUTER JOIN HISTORICOESTADOSCOM ON (INFRACCIONCOMPARENDO.ID = HISTORICOESTADOSCOM.ID_INFRACCIONCOMPARENDO) " +
                "WHERE 1 = 1 " +
                criterios;
            return sql;
        }

        private string CrearSqlRecibo(string campos, string criterios)
        {
            string sql = "SELECT DISTINCT " +
                campos + " " +
                "FROM RECIBOSCOMPARENDO " +
                "INNER JOIN RECIBOCUOTAS ON (RECIBOSCOMPARENDO.id = RECIBOCUOTAS.idrecibo) " +
                "INNER JOIN pagoscomparendo ON (RECIBOCUOTAS.idcuota = pagoscomparendo.id) " +
                "INNER JOIN ESTADOCOM ESTADOPAGO ON (pagoscomparendo.estado = ESTADOPAGO.ID_ESTADO) " +
                "INNER JOIN ESTADOCOM ESTADORECIBO ON (RECIBOSCOMPARENDO.estado = ESTADORECIBO.ID_ESTADO) " +
                "INNER JOIN LIQUIDACION ON (RECIBOSCOMPARENDO.idliquidacion = LIQUIDACION.idliquidacion) " +
                "INNER JOIN DATOSLIQUIDACION ON (LIQUIDACION.idliquidacion = DATOSLIQUIDACION.idliquidacion) " +
                "INNER JOIN INFRACCIONCOMPARENDO ON (DATOSLIQUIDACION.idinfraccion = INFRACCIONCOMPARENDO.id) " +
                "INNER JOIN ESTADOCOM ESTADOINFRACCION ON (INFRACCIONCOMPARENDO.IDESTADO = ESTADOINFRACCION.ID_ESTADO) " +
                "INNER JOIN INFRACCIONES ON (INFRACCIONCOMPARENDO.idinfraccion = INFRACCIONES.id_infraccion) " +
                "INNER JOIN COMPARENDO ON (COMPARENDO.ID_COMPARENDO = INFRACCIONCOMPARENDO.IDCOMPARENDO) " +
                "INNER JOIN INFRACTOR ON (COMPARENDO.ID_INFRACTOR = INFRACTOR.ID_INFRACTOR) " +
                "LEFT OUTER JOIN HISTORICOESTADOSCOM ON (INFRACCIONCOMPARENDO.ID = HISTORICOESTADOSCOM.ID_INFRACCIONCOMPARENDO) " +
                "WHERE 1 = 1 " +
                criterios;
            return sql;
        }

        private string GetCamposRecibo()
        {
            string campos = 
                "RECIBOSCOMPARENDO.NUMERO_RECIBO, " +
                "pagoscomparendo.nocuota, " +
                "pagoscomparendo.porcentaje, " +
                "pagoscomparendo.valor, " +
                "LIQUIDACION.total, " +
                "LIQUIDACION.saldo, " +
                "ESTADOPAGO.DESCRIPCION AS ESTADOPAGO, " +
                "LIQUIDACION.idliquidacion ";
            return campos;
        }

        private string GetCamposComparendo()
        {
            string campos =
                "COMPARENDO.NUMEROCOMPARENDO," +
                "LIQUIDACION.total, " +
                "ESTADOINFRACCION.DESCRIPCION AS ESTADOINFRACCION," +
                "COMPARENDO.FECHACOMPARENDO," +
                "COMPARENDO.PLACA," +
                "INFRACCIONES.COD_INFRACCION," +
                "INFRACCIONES.NUEVO_CODIGO," +
                "INFRACCIONES.DESCRIPCION AS INFRACCION ";
            return campos;
        }

        private string GetCamposInfractor()
        {
            string campos =
                "ESTADOINFRACCION.DESCRIPCION AS ESTADOINFRACCION," +
                "INFRACTOR.NOMBRES," +
                "INFRACTOR.APELLIDOS," +
                "INFRACTOR.direccion, " +
                "INFRACTOR.telefono, " +
                "INFRACTOR.NROIDENTIFICACION ";
            return campos;
        }

        private string GetCriterios()
        {
            string criterios = "";
            if (chkNroRecibo.Checked)
                criterios = criterios + " AND (RECIBOSCOMPARENDO.NUMERO_RECIBO = '" + txtNumeroRecibo.Text + "') ";
            if (chkNroComparendo.Checked)
                criterios = criterios + " AND (COMPARENDO.NUMEROCOMPARENDO = '" + txtNroComparendo.Text + "') ";
            if (chkIdentifiacion.Checked)
            {
                criterios = criterios + " AND (INFRACTOR.NROIDENTIFICACION = '" + txtIdentificacion.Text + "') ";
                criterios = criterios + " AND (INFRACTOR.ID_DOCTO =" + cmbTipoDocumento.SelectedValue + ")";
            }
            if (chkEstado.Checked)
                criterios = criterios + " AND (ESTADOINFRACCION.ID_ESTADO = " + cmbEstado.SelectedValue + ")";
            if (chkFecha.Checked)
                criterios = criterios + " AND (COMPARENDO.FECHACOMPARENDO BETWEEN '" + dtpFechaInicial.Text.ToString() + "' AND '" + dtpFechaFinal.Text.ToString() + "')";
            return criterios;
        }

        // Funciones de las acciones

        void tblRecibos_SelectionChanged(object sender, System.EventArgs e)
        {
            try
            {
                string estado = "";
                string nroRecibo = "";
                if (tblRecibos.SelectedCells.Count > 0)
                {
                    estado = GetValorSeleccionado(tblRecibos, "ESTADOPAGO");
                    nroRecibo = GetValorSeleccionado(tblRecibos, "NUMERO_RECIBO");
                    HabilitarBotones(estado, nroRecibo);
                    ActualizarTblComparendos();
                    LlenarInfoRecibo();
                }
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                funciones.mostrarMensaje("Error intentando buscar la información de los comparendos asociados al recibo", "E");
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void ActualizarTblComparendos()
        {
            String query;
            object[] objs;
            ArrayList campos;
            string idLiquidacion = GetValorSeleccionado(tblRecibos, "idliquidacion");

            if (idLiquidacion != "")
            {
                string criterio = " AND (LIQUIDACION.idliquidacion = '" + idLiquidacion + "') ";
                query = CrearSql(GetCamposComparendo(), criterio);
                if (query != "")
                {
                    objs = serviciosDocumentos.verificarConsultaComp(query);
                    if (objs != null)
                    {
                        campos = funciones.ObjectToArrayList(objs);
                        objs = serviciosDocumentos.executeQuery(query);
                        if (objs != null)
                        {
                            DataTable dt = funciones.getData(funciones.ObjectToArrayList(objs), campos);
                            tblComparendos.DataSource = dt;
                        }
                        else
                        {
                            funciones.mostrarMensaje("No hay registros para los criterios de busqueda seleccionados", "W");
                        }
                    }
                }
                else
                {
                    funciones.mostrarMensaje("Ingrese un criterio de busqueda", "W");
                }
            }
        }

        void tblComparendos_SelectionChanged(object sender, System.EventArgs e)
        {
            try
            {
                ActualizarDtInfractor();
                LlenarInfoInfractor();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                funciones.mostrarMensaje("Error intentando buscar la información del infractor", "E");
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void ActualizarDtInfractor()
        {
            String query;
            object[] objs;
            ArrayList campos;
            string nroComparendo = GetValorSeleccionado(tblComparendos, "NUMEROCOMPARENDO");

            if (nroComparendo != "")
            {
                string criterio = " AND (COMPARENDO.NUMEROCOMPARENDO = '" + nroComparendo + "') ";
                query = CrearSql(GetCamposInfractor(), criterio);
                if (query != "")
                {
                    objs = serviciosDocumentos.verificarConsultaComp(query);
                    if (objs != null)
                    {
                        campos = funciones.ObjectToArrayList(objs);
                        objs = serviciosDocumentos.executeQuery(query);
                        if (objs != null)
                        {
                            dtInfractor = funciones.getData(funciones.ObjectToArrayList(objs), campos);
                        }
                        else
                        {
                            funciones.mostrarMensaje("No hay registros para los criterios de busqueda seleccionados", "W");
                        }
                    }
                }
                else
                {
                    funciones.mostrarMensaje("Ingrese un criterio de busqueda", "W");
                }
            }
        }

        private void HabilitarBotones(string estado, string nroRecibo)
        {
            if (nroRecibo != null && nroRecibo != "" && nroRecibo.ToUpper() != "NULL")
                btnReimprimir.Enabled = true;
            else btnReimprimir.Enabled = false;
            switch (estado.ToUpper())
            {
                case "LIQUIDADO":
                    btnPagar.Enabled = true; //false; 
                    btnAnularPago.Enabled = false;
                    btnEliminarLiquidacion.Enabled = true;
                    break;
                case "PAGADO":
                    btnPagar.Enabled = false;
                    btnAnularPago.Enabled = true;
                    btnEliminarLiquidacion.Enabled = false;
                    break;
                case "NO PAGO":
                    btnPagar.Enabled = true;
                    btnAnularPago.Enabled = false;
                    btnEliminarLiquidacion.Enabled = true;
                    break;
                //case "INGRESADO":
                //    break;
                //case "ANULADO":
                //    break;
                //case "RECIBO":
                //    break;
                //case "PAGO PARCIAL":
                //    break;
                default:
                    btnPagar.Enabled = false;
                    btnAnularPago.Enabled = false;
                    btnEliminarLiquidacion.Enabled = false;
                    break;
            }
        }

        private void btnReimprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (tblRecibos.DataSource != null)
                {
                    string nroRecibo = GetValorSeleccionado(tblRecibos, "NUMERO_RECIBO");
                    if (nroRecibo != "")
                    {
                        string ruta = serviciosConfiguraciones.directorioFacturasComparendo();
                        ruta += nroRecibo + ".pdf";
                        servicios.documentos.transferir transPdf = new servicios.documentos.transferir();
                        transPdf.archivoDelServer(ruta);
                    }
                    else
                    {
                        funciones.mostrarMensaje("No hay un recibo de comparendo!", "W");
                    }
                }
            }
            catch (Exception exe)
            {
                log.escribirError(exe.ToString(), this.GetType());
                funciones.mostrarMensaje("Error intentando reimprimir el recibo de pago. " + exe.Message, "W");
                //Console.WriteLine(exe.Message);
                //Console.WriteLine(exe.StackTrace);
            }
        }

        private void btnEliminarLiquidacion_Click(object sender, EventArgs e)
        {
            try
            {
                string valor = GetValorSeleccionado(tblRecibos, "idliquidacion");
                if (valor != "")
                {
                    DialogResult dr = MessageBox.Show("Se procederá a anular la liquidación con id " + valor + ". Desea continuar?", 
                        "Anular liquidación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (dr == DialogResult.OK)
                    {
                        int idLiquidacion = int.Parse(valor);
                        int res = serviciosLiquidacion.anularLiquidacion(idLiquidacion, WS.MyUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName());
                        if (res >= 20) funciones.mostrarMensaje("Error " + res + " desconocido al intentar anular la liquidacion", "E");
                        if (res > 0) funciones.mostrarMensaje("Algunos datos no fueron actualizados. " + res + " ", "E");
                        else
                        {
                            AccionBuscar();
                            funciones.mostrarMensaje("La liquidación ha sido anulada con éxito!!", "I");
                        }
                    }
                }
                else
                {
                    funciones.mostrarMensaje("Liquidacion seleccionada no encontrada!", "E");
                }
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                funciones.mostrarMensaje("Error eliminando la liquidacion. " + exp.Message, "E");
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private string GetValorSeleccionado(DataGridView tbl, string campo)
        {
            try
            {
                if (tbl.SelectedCells.Count > 0)
                {
                    string valor = funciones.moneyToStr(tbl.Rows[tbl.SelectedCells[0].RowIndex].Cells[campo].Value + "");
                    if (valor != null && valor != "" && valor.ToUpper() != "NULL")
                        return valor;
                }
            }
            catch(Exception exp) {
                log.escribirError(exp.ToString(), this.GetType());
            }
            return "";
        }

        private string GetValorSeleccionado(DataTable dt, int index, string campo)
        {
            try
            {
                string valor = dt.Rows[index][campo] + "";
                if (valor != null && valor != "" && valor.ToUpper() != "NULL")
                    return valor;
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
            }
            return "";
        }

        private void btnAnularPago_Click(object sender, EventArgs e)
        {
            try
            {
                string nroRecibo = GetValorSeleccionado(tblRecibos, "NUMERO_RECIBO");
                if (nroRecibo != "")
                {
                    PagarFactura frm = new PagarFactura("", myUsuario, AccionBuscarFactura.Anular);
                    frm.BuscarRecibo(nroRecibo);
                    frm.ConDialogResult = true;
                    frm.AccionConsultarRecibo();
                    if (frm.ShowDialog() == DialogResult.OK)
                        AccionBuscar();
                }
                else funciones.mostrarMensaje("No se encuentra el numero de recibo para el registro seleccionado", "E");
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                funciones.mostrarMensaje("Error intentando cargar el formulario de Anular pago. " + exp.Message, "E");
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            try
            {
                string nroRecibo = GetValorSeleccionado(tblRecibos, "NUMERO_RECIBO");
                if (nroRecibo != "")
                {
                    PagarFactura frm = new PagarFactura("", myUsuario, AccionBuscarFactura.Pagar);
                    frm.BuscarRecibo(nroRecibo);
                    frm.ConDialogResult = true;
                    frm.AccionConsultarRecibo();
                    if (frm.ShowDialog() == DialogResult.OK)
                        AccionBuscar();
                }
                else funciones.mostrarMensaje("No se encuentra el numero de recibo para el registro seleccionado", "E");
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                funciones.mostrarMensaje("Error intentando cargar el formulario de Anular pago. " + exp.Message, "E");
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtNumeroRecibo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                funciones.esNumero(e);
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void txtNroComparendo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                funciones.esNumero(e);
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void txtIdentificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                funciones.esNumero(e);
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void txtNumeroRecibo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    AccionBuscar();
                }
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void txtNroComparendo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    AccionBuscar();
                }
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void txtIdentificacion_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    AccionBuscar();
                }
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void cmbTipoDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                funciones.lanzarTapConEnter(e);
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void cmbEstado_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    AccionBuscar();
                }
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void dtpFechaInicial_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                funciones.lanzarTapConEnter(e);
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void dtpFechaFinal_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    AccionBuscar();
                }
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        
    }
}
