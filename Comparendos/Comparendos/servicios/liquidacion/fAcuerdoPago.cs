using System; using TransitoPrincipal; using LibreriasSintrat.utilidades;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibreriasSintrat.ServiciosAccesoriasComp;
using LibreriasSintrat.ServiciosUsuarios;
using LibreriasSintrat.ServiciosLiquidacionComp;
using LibreriasSintrat.ServiciosGeneralesComp;
using LibreriasSintrat.ServiciosLiquidadorComparendos;
using Comparendos.utilidades; using LibreriasSintrat.utilidades; using LibreriasSintrat;
using LibreriasSintrat.ServiciosConfiguraciones;
using LibreriasSintrat.ServiciosReciboscomparendo;
using System.Globalization;

namespace Comparendos.servicios.liquidacion
{
    public partial class fAcuerdoPago : Form
    {
        usuarios myUsuario;
        Funciones funciones;
        Object[] myLiquidaciones;
        Object[] myAcuerdos;    //variable usada para cargar los acuerdos de pago de un infractor
        Object[] myPagosComp;
        Object[] detalles;
        float myInteresFinanc;
        float saldoTotal;
        liquidacionComp myLiquidacion;
        LibreriasSintrat.ServiciosGeneralesComp.infractorComp myInfractor;
        acuerdosPagoComp myAcuerdo;
        int posicion;
        string numRecibo = "";


        CultureInfo culturaEspaniolCol = new CultureInfo("es-CO", false);
        Log log = new Log();

        ArrayList listaIdLiquidacion;
        
        public fAcuerdoPago(usuarios myUser)
        {
            myUsuario = myUser;
            InitializeComponent();
            funciones = new Funciones();
            myAcuerdo = new acuerdosPagoComp();
            posicion = -1;
            pnlDireccion.Visible = false;
            inicializarCampos();
            log = new Log();
        }

        public void inicializarCampos()
        {
            txtNumero.Enabled = false;
            txtDeudor.Enabled = false;
            txtDireccion.Enabled = false;
            txtTelefono.Enabled = false;
            txtComparendos.Enabled = false;
            txtTotalDeu.ReadOnly = true;
            txtCuotas.Enabled = false;
            txtInicial.Enabled = false;
            txtSaldo.Enabled = false;
            txtValLiqui.ReadOnly = true;
        }

        private void fAcuerdoPago_Load(object sender, EventArgs e)
        {
            try
            {
                cargarCombos();
                cmbBoxTipoDocumento.SelectedValue = 1;
                btnImpFinanc.Enabled = false;
                btnImprAcuePag.Enabled = false;
                btnGuardar.Enabled = false;
                btnAExcel.Visible = false;
                dataGridView1.Visible = false;
                btnRefinanciar.Enabled = false;
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                funciones.mostrarMensaje("Error desconocido realizando la funcionalidad. " + exp.Message, "E");
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void txtCeduDeu_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnCrearAcuerdo.Focus();
                    pnlDireccion.Visible = false;
                    btnBuscarAcuerdo.Visible = true;
                    btnBuscarAcuerdo.Enabled = true;
                }
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                funciones.mostrarMensaje("Error desconocido realizando la funcionalidad. " + exp.Message, "E");
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        public void guardar()
        {
            ServiciosLiquidacionCompService mySerLiqCom = WS.ServiciosLiquidacionCompService();
            myAcuerdo.CODEUDOR = txtNombCodeu.Text;
            myAcuerdo.CONCEPTO = txtConcepto.Text;
            myAcuerdo.DESCRIPCION = txtDescripcion.Text;
            myAcuerdo.DOCUMENTOCODEUDOR = txtCedCodeu.Text;
            myAcuerdo.FECHA = funciones.convFormatoFecha(dtpFechaCompr.Text, "MM/dd/yyyy");
            myAcuerdo.ID_USUARIO = myUsuario.ID_USUARIO;
            myAcuerdo.IDLIQUIDACION = myLiquidacion.IDLIQUIDACION;
            myAcuerdo.INTERESFINANCIACION = myInteresFinanc;
            myAcuerdo.NOTA = txtNota.Text;
            myAcuerdo.NROCOMP = myLiquidacion.NROCOMP;
            myAcuerdo = mySerLiqCom.crearAcuerdoPago(myAcuerdo, WS.MyUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName());

            if (myAcuerdo != null && myAcuerdo.ID > 0) //Se buscan todos los comparendos relacionados con el acuerdo para cambiar el estado 
            {
                //actualizar liquidacion
                liquidacionComp objLiquidacion = new liquidacionComp();
                objLiquidacion.IDLIQUIDACION = myLiquidacion.IDLIQUIDACION;
                object[] objs = mySerLiqCom.getLiquidaciones(objLiquidacion);
                if (objs != null && objs.Length > 0)
                {
                    objLiquidacion = (liquidacionComp)objs[0];
                    objLiquidacion.TOTAL = funciones.strToFloat(funciones.moneyToStr(txtTotalDeu.Text));
                    objLiquidacion.SALDO = myLiquidacion.TOTAL;
                    bool edited = mySerLiqCom.editarLiquidacion(objLiquidacion, WS.MyUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName());
                }

                viewLiquidacionComparendo liqComparendo = new viewLiquidacionComparendo();
                object[] listaLiq;
                liqComparendo.IDLIQUIDACION = myAcuerdo.IDLIQUIDACION;
                ServiciosGeneralesCompService mySerComp = WS.ServiciosGeneralesCompService();
                listaLiq = mySerComp.getViewLiquiComprendo(liqComparendo);
                if (listaLiq != null)
                {
                    for (int j = 0; j < listaLiq.Length; j++)
                    {
                        liqComparendo = (viewLiquidacionComparendo)listaLiq[j];
                        LibreriasSintrat.ServiciosGeneralesComp.comparendoComp compa = new LibreriasSintrat.ServiciosGeneralesComp.comparendoComp();
                        compa.ID_COMPARENDO = liqComparendo.ID_COMPARENDO;
                        object[]listacomp = mySerComp.searchComparendo(compa);
                        if (listacomp != null)
                        {
                            compa = (LibreriasSintrat.ServiciosGeneralesComp.comparendoComp)listacomp[0];
                            LibreriasSintrat.ServiciosGeneralesComp.infracionComparendoComp infraccion = new LibreriasSintrat.ServiciosGeneralesComp.infracionComparendoComp();
                            infraccion.IDCOMPARENDO = compa.ID_COMPARENDO;
                            infraccion = mySerComp.getInfraccionComparendo(infraccion);
                            if (infraccion != null && infraccion.ID > 0)
                            {
                                infraccion.IDESTADO = 6; //Se cambia el estado del comparendo a acuerdo de pago
                                bool actualizar = mySerComp.actualizarInfraccionComparendo(infraccion, WS.MyUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName());
                                if (!actualizar)
                                {
                                    funciones.mostrarMensaje("Ocurrio un error actualizando los comparendos","E");
                                }
                            }
                        }
                    }
                }
            }
        }

        public void eliminarPagos(int idLiquidacion)
        {
            ServiciosLiquidacionCompService mySerLiqComp = WS.ServiciosLiquidacionCompService();
            
            pagosComp tempPagos = new pagosComp();
            tempPagos.IDLIQUIDACION = myLiquidacion.IDLIQUIDACION;

            object[] pagos = mySerLiqComp.getPagosComp(tempPagos);
            if(pagos!=null)
                foreach (pagosComp item in pagos)
                {
                    mySerLiqComp.eliminarPagoComp(item, WS.MyUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName());
                }            
        }

        public void guardarPagos()
        {
            ServiciosLiquidacionCompService mySerLiqComp = WS.ServiciosLiquidacionCompService();
            pagosComp myTmp;
            for (int i = 0; i < myPagosComp.Length; i++)
            {
                myTmp = (pagosComp)myPagosComp[i];
                mySerLiqComp.registarPagoComp(myTmp, WS.MyUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName());
            }
        }

        public void cargarDetalles()
        {
            if (myLiquidacion != null)
            {
                viewPagosComp myDetalle = new viewPagosComp();
                ServiciosLiquidacionCompService myServLiqComp = WS.ServiciosLiquidacionCompService();
                myDetalle.IDLIQUIDACION = myLiquidacion.IDLIQUIDACION;
                detalles = (Object[])myServLiqComp.getDetallesPagosComp(myDetalle);
                if (detalles != null && detalles.Length > 0)
                    mostrarDetalles(detalles);
                else
                    MessageBox.Show("no hay detalles", "No se encontraron cuotas asociadas a este Acuerdo de Pago");
            }
        }

        public void mostrarDetalles(Object[] datos)
        {
            Funciones funciones = new Funciones();
            DataTable dt = new DataTable();
            ArrayList Campos = new ArrayList();
            viewPagosComp tmp;
            float total=0;
            float saldo;
            float capital;
            float primera=0;
            for (int i = 0; i < datos.Length; i++)
            {
                tmp = (viewPagosComp)datos[i];
                total+=tmp.VALOR;
                if (i == 0)
                    primera = tmp.VALOR;
                viewLiquidacionComparendo liqComparendo = new viewLiquidacionComparendo();
                object[] listaLiq;
                liqComparendo.IDLIQUIDACION = tmp.IDLIQUIDACION;
                ServiciosGeneralesCompService mySerComp = WS.ServiciosGeneralesCompService();
                listaLiq = mySerComp.getViewLiquiComprendo(liqComparendo);
                if (listaLiq != null)
                {
                    for (int j = 0; j < listaLiq.Length; j++)
                    {
                        liqComparendo = (viewLiquidacionComparendo)listaLiq[j];
                        txtComparendos.Text = liqComparendo.NUMEROCOMPARENDO + ", ";
                    }
                }
            }
            capital = total;
            saldo = total;
            for (int i = 0; i < datos.Length; i++)
            {
                tmp = (viewPagosComp)datos[i];
                tmp.CAPITAL = capital;
                capital -= tmp.VALOR;
                datos[i] = (Object)tmp;
                if (tmp.DESCRIPCION == "PAGADO")
                    saldo -= tmp.VALOR;
            }
            Campos.Add("NOCUOTA = CUOTA");
            Campos.Add("DESCRIPCION = ESTADO");
            Campos.Add("VALOR = VALOR");
            Campos.Add("CAPITAL = CAPITAL");
            try
            {
                dt = funciones.ToDataTable(funciones.ObjectToArrayList(datos));
            }
            catch (Exception e) {
                log.escribirError(e.ToString(), this.GetType());
            }
            dtGrdDetalle.DataSource = dt;
            if (dt.Rows.Count > 0)
                funciones.configurarGrilla(dtGrdDetalle, Campos);
            dt = null;
            
            
       
            
            txtTotalDeu.Text = total.ToString("C", culturaEspaniolCol);
            txtCuotas.Text = datos.Length.ToString();
            txtInicial.Text = primera.ToString("C", culturaEspaniolCol);
            txtSaldo.Text = saldo.ToString("C", culturaEspaniolCol);
            //Se esta modificando para que apareca los comparendos que se estan registrando!
            /*liquidacionComp liqui = new liquidacionComp();
            object[] listaliq;
            liqui.IDLIQUIDACION = tmp.IDLIQUIDACION;
            ServiciosLiquidacionCompService mySerLiq = WS.ServiciosLiquidacionCompService();
            listaliq = mySerLiq.getLiquidaciones(liqui);
            if (listaliq != null)
            {
                foreach (liquidacionComp liquidacion in listaliq)
                {
                    txtComparendos.Text = liquidacion.NROCOMP + " ";
                }
            }*/
        }

        public float calcularSaldo()
        { 
            float valor=0;
            pagosComp tmp;
            for (int i = 0; i < myPagosComp.Length; i++)
            {
                tmp=(pagosComp)myPagosComp[i];
                valor += tmp.VALOR;
            }
            return valor;
        }

        public void cargarCombos()
        {
            ServiciosAccesoriasCompService MySerAccComp = WS.ServiciosAccesoriasCompService();
            funciones.llenarCombo(cmbBoxTipoDocumento, MySerAccComp.obtenerTiposDocumento());
        }

        public void cargarInfractor()
        { 
            ServiciosGeneralesCompService mySerGenComp = WS.ServiciosGeneralesCompService();
            if (txtCeduDeu.Text == "")
                return;
            myInfractor = new LibreriasSintrat.ServiciosGeneralesComp.infractorComp();
            myInfractor.ID_DOCTO=int.Parse(cmbBoxTipoDocumento.SelectedValue.ToString());
            myInfractor.NROIDENTIFICACION=txtCeduDeu.Text;
            myInfractor = mySerGenComp.buscarInfractor(myInfractor);
        }

        public void cargarLiquidaciones()
        {
            cargarInfractor();
            if(myInfractor==null||myInfractor.ID_INFRACTOR<=0)
            {
                MessageBox.Show("No se encontro ningun registro de infractores con ese documento","Infractor");
                txtCeduDeu.Text = "";
                txtCeduDeu.Focus();
                return;
            }
            ServiciosLiquidacionCompService mySerLiqComp = WS.ServiciosLiquidacionCompService();
            myLiquidaciones = (Object[])mySerLiqComp.listarLiquidacionesDeudor(myInfractor.NROIDENTIFICACION,myInfractor.ID_DOCTO);
            if (!(myLiquidaciones != null && myLiquidaciones.Length > 0))
            {
                MessageBox.Show("No se encontro informacion de liquidaciones asociadas al documento ingresado", "Acuerdo de Pago");
                txtCeduDeu.Text = "";
                txtCeduDeu.Focus();
            }
            else
            {
                ServiciosGeneralesCompService mySerGenComp = WS.ServiciosGeneralesCompService();
                ArrayList liquidaciones = new ArrayList();
                for (int i = 0; i < myLiquidaciones.Length; i++)
                {
                    liquidacionComp tmp = (liquidacionComp)myLiquidaciones[i];
                    viewLiquidacionComparendo viewLiq = new viewLiquidacionComparendo();
                    viewLiq.IDLIQUIDACION = tmp.IDLIQUIDACION;
                    object[] listaLiq = mySerGenComp.getViewLiquiComprendo(viewLiq);
                    if (listaLiq != null)
                    {
                        string nroComps = "";
                        for (int j = 0; j < listaLiq.Length; j++)
                        {
                            nroComps += ((viewLiquidacionComparendo)listaLiq[j]).NUMEROCOMPARENDO;
                            if (j < listaLiq.Length - 1) nroComps += ", ";
                        }
                        viewLiq = (viewLiquidacionComparendo)listaLiq[0];
                        LibreriasSintrat.ServiciosGeneralesComp.infracionComparendoComp infraccion = new LibreriasSintrat.ServiciosGeneralesComp.infracionComparendoComp();
                        infraccion.IDCOMPARENDO = viewLiq.ID_COMPARENDO;
                        infraccion = mySerGenComp.getInfraccionComparendo(infraccion);
                        if (infraccion != null && infraccion.ID > 0)
                        {
                            if (infraccion.IDESTADO == 11)//VERIFICAMOS QUE EL COMPARENDO SE ENCUENTRE EN ESTADO INGRESADO
                            {
                                tmp.NROCOMP = nroComps;
                                liquidaciones.Add(tmp);
                            }
                        }
                    }
                }

                myLiquidaciones = liquidaciones.ToArray();
                buscarLiquidacion();
            }
        }

        public void buscarLiquidacion()
        {
            liquidacionComp newreq = new liquidacionComp();
            ArrayList Campos = new ArrayList();
            Campos.Add("FECHA = FECHA");
            //Campos.Add("IDLIQUIDACION = IDLIQUIDACION");
            Campos.Add("TOTAL = TOTAL");
            Campos.Add("NROCOMP = COMPARENDO"); //esa columna hay puros null //llenarla previamente con 
            //los nro comp que abarca la liquidacion
            if (myLiquidaciones != null && myLiquidaciones.Length > 0)
            {
                buscador buscador = new buscador(myLiquidaciones, Campos, null, null);
                Funciones funciones = new Funciones();
                if (buscador.ShowDialog() == DialogResult.OK)
                {
                    myLiquidacion = (liquidacionComp)funciones.listToLiquidacionComp(buscador.Seleccion);
                    mostrarDetallesInfractor();
                }
                buscador.Dispose();
            }
            else
            {
                MessageBox.Show("No se Encontro ninguna Liquidacion", "No se cargaron los datos");
            }
        }

        public void mostrarDetallesInfractor()
        {
            if (myLiquidacion != null)
            {
                txtDeudor.Text = myInfractor.NOMBRES + " " + myInfractor.APELLIDOS;
                txtDireccion.Text = myInfractor.DIRECCION;
                txtTelefono.Text = myInfractor.TELEFONO;
                txtComparendos.Text = myLiquidacion.NROCOMP;
                txtTotalDeu.Text = myLiquidacion.TOTAL.ToString("C", culturaEspaniolCol);
                txtSaldo.Text = myLiquidacion.SALDO.ToString("C", culturaEspaniolCol);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                guardar();
                txtNumero.Text = myAcuerdo.NUMERO.ToString();
                txtValLiqui.Text = myLiquidacion.TOTAL.ToString("C", culturaEspaniolCol);
                btnImpFinanc.Enabled = true;
                btnImprAcuePag.Enabled = true;
                btnGuardar.Enabled = false;
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                funciones.mostrarMensaje("Error desconocido realizando la funcionalidad. " + exp.Message, "E");
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void btnCrearAcuerdo_Click(object sender, EventArgs e)
        {
            try
            {
                fFinanciar myfrmFinanc;
                if (txtCeduDeu.Text != "")
                {
                    txtNumero.Text = "";
                    cargarLiquidaciones();
                    if (myLiquidacion != null && myLiquidacion.IDLIQUIDACION > 0)
                    {
                        myfrmFinanc = new fFinanciar(myLiquidacion);
                        if (myfrmFinanc.ShowDialog() == DialogResult.OK)
                        {
                            //ELIMINAR PAGOS COMP ANTERIORES
                            eliminarPagos(myLiquidacion.IDLIQUIDACION);

                            myPagosComp = myfrmFinanc.myCuotas;
                            txtCuotas.Text = myPagosComp.Length.ToString();
                            myInteresFinanc = myfrmFinanc.interesFinanc;
                            txtTotalDeu.Text = (myLiquidacion.TOTAL * myInteresFinanc / 100).ToString("C", culturaEspaniolCol);
                            txtInicial.Text = ((pagosComp)myPagosComp[0]).VALOR.ToString("C", culturaEspaniolCol);
                            saldoTotal = calcularSaldo();
                            txtSaldo.Text = saldoTotal.ToString("C", culturaEspaniolCol);
                            guardarPagos();
                            cargarDetalles();
                            btnGuardar.Enabled = true;
                            btnAExcel.Visible = false;
                        }
                        else
                        {
                            MessageBox.Show("No se financió la liquidación!!!", "Financiación Fallida");
                            if (posicion != -1)
                                mostrarAcuerdoPago();
                        }
                    }
                    else
                    {
                        if (posicion != -1)
                            mostrarAcuerdoPago();
                    }
                }
                else
                {
                    MessageBox.Show("Por favor digite el numero de Documento!!!", "Informacion Faltante");
                }
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                funciones.mostrarMensaje("Error desconocido realizando la funcionalidad. " + exp.Message, "E");
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        
        private void btnBuscarAcuerdo_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCeduDeu.Text != "")
                {
                    bool retorno;
                    retorno = cargarAcuerdosDePago();
                    if (retorno)
                    {
                        btnImpFinanc.Enabled = true;
                        btnImprAcuePag.Enabled = true;
                        btnAExcel.Visible = true;
                    }
                }
                else
                {
                    MessageBox.Show("Por favor digite el numero de Documento!!!", "Informacion Faltante");
                }
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                funciones.mostrarMensaje("Error desconocido realizando la funcionalidad. " + exp.Message, "E");
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        public bool cargarAcuerdosDePago()
        {
            cargarInfractor();
            bool retorno = true;
            if (myInfractor == null)
            {
                MessageBox.Show("No se encontro ningun registro de infractores con ese documento", "Infractor");
                txtCeduDeu.Text = "";
                txtCeduDeu.Focus();
                return false;
            }
            ServiciosLiquidacionCompService mySerLiqComp = WS.ServiciosLiquidacionCompService();
            myAcuerdos = (Object[])mySerLiqComp.ListarAcuerdosInfractor(myInfractor.NROIDENTIFICACION, myInfractor.ID_DOCTO);
            if (myAcuerdos != null && myAcuerdos.Length > 0)
            {
                myLiquidaciones = (Object[])mySerLiqComp.listarLiquidacionesDeudor(myInfractor.NROIDENTIFICACION, myInfractor.ID_DOCTO);
                posicion = 0;
                myLiquidacion = (liquidacionComp)myLiquidaciones[posicion]; //new
                //btnCrearAcuerdo.Enabled = false;
                btnBuscarAcuerdo.Enabled = false;
                btnBuscarAcuerdo.Visible = false;
                if(myAcuerdos.Length>1)
                    pnlDireccion.Visible = true;
                mostrarAcuerdoPago();
            }
            else
            {
                MessageBox.Show("No se encontro informacion de Acuerdos de Pago asociados al documento ingresado", "Acuerdo de Pago");
                txtCeduDeu.Text = "";
                txtCeduDeu.Focus();
                retorno = false;
            }
            return retorno;
        }

        public void seleccionarAcuerdo()
        {
            myAcuerdo = (acuerdosPagoComp)myAcuerdos[posicion];
            liquidacionComp tmp;
            if (myLiquidacion != null)
            {
                for (int i = 0; i < myLiquidaciones.Length; i++)
                {
                    tmp = (liquidacionComp)myLiquidaciones[i];
                    if (tmp.IDLIQUIDACION == myAcuerdo.IDLIQUIDACION)
                    {
                        myLiquidacion = tmp;
                    }
                }
            }
        }

        public void mostrarAcuerdoPago()
        {
            seleccionarAcuerdo();
            mostrarDetallesInfractor();
            txtNumero.Text = myAcuerdo.NUMERO.ToString();
            txtNombCodeu.Text = myAcuerdo.CODEUDOR;
            txtConcepto.Text = myAcuerdo.CONCEPTO;
            txtDescripcion.Text = myAcuerdo.DESCRIPCION;
            txtCedCodeu.Text = myAcuerdo.DOCUMENTOCODEUDOR;
            dtpFechaCompr.Text = DateTime.Parse(myAcuerdo.FECHA, System.Globalization.CultureInfo.InvariantCulture).ToString("dd/MM/yyyy");
            txtNota.Text = myAcuerdo.NOTA;
            txtComparendos.Text = myAcuerdo.NROCOMP;
            if (myLiquidacion != null)
            {
                txtValLiqui.Text = myLiquidacion.TOTAL.ToString("C", culturaEspaniolCol);
            }
                cargarDetalles();
                btnRefinanciar.Enabled = true;
            btnImpFinanc.Enabled = true;
            btnImprAcuePag.Enabled = true;
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            try
            {
                posicion = 0;
                mostrarAcuerdoPago();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                funciones.mostrarMensaje("Error desconocido realizando la funcionalidad. " + exp.Message, "E");
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                if (posicion > 0)
                    posicion--;
                else
                    MessageBox.Show("No hay acuerdos de pago Previos", "llego al limite");
                mostrarAcuerdoPago();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                funciones.mostrarMensaje("Error desconocido realizando la funcionalidad. " + exp.Message, "E");
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (posicion < myAcuerdos.Length - 1)
                    posicion++;
                else
                    MessageBox.Show("No hay acuerdos de pago Posteriores", "llego al limite");
                mostrarAcuerdoPago();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                funciones.mostrarMensaje("Error desconocido realizando la funcionalidad. " + exp.Message, "E");
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            try
            {
                posicion = myAcuerdos.Length - 1;
                mostrarAcuerdoPago();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                funciones.mostrarMensaje("Error desconocido realizando la funcionalidad. " + exp.Message, "E");
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (myAcuerdos != null && myAcuerdos.Length > 0)
                {
                    Funciones funciones = new Funciones();
                    DataTable dt = new DataTable();
                    ArrayList Campos = new ArrayList();
                    Campos.Add("NUMERO = No ACUERDO");
                    Campos.Add("FECHA = FECHA");
                    Campos.Add("DESCRIPCION = MOTIVO");
                    Campos.Add("CONCEPTO = CONCEPTO");
                    try
                    {
                        dt = funciones.ToDataTable(funciones.ObjectToArrayList(myAcuerdos));
                    }
                    catch (Exception eX) {
                        log.escribirError(eX.ToString(), this.GetType());
                    }
                    dataGridView1.DataSource = dt;
                    if (dt.Rows.Count > 0)
                        funciones.configurarGrilla(dataGridView1, Campos);
                    dt = null;
                    String nombreArchivo = myInfractor.NOMBRES + " " + myInfractor.APELLIDOS;
                    String titulo = "Acuerdos de pago del señor: " + nombreArchivo;
                    funciones.exportarDataGridViewAExcelToDocuments(nombreArchivo, titulo, dataGridView1);
                }
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                funciones.mostrarMensaje("Error desconocido realizando la funcionalidad. " + exp.Message, "E");
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void btnRefinanciar_Click(object sender, EventArgs e)
        {
            try
            {
                float saldo;
                int ultima;
                saldo = funciones.strToFloat(funciones.moneyToStr(txtSaldo.Text));
                liquidacionComp tmp = myLiquidacion;
                tmp.TOTAL = saldo;
                ultima = buscarUltimaPaga();
                fFinanciar myfrmFinanc = new fFinanciar(tmp, ultima);
                if (myfrmFinanc.ShowDialog() == DialogResult.OK)
                {
                    myPagosComp = myfrmFinanc.myCuotas;
                    eliminarAnteriores();
                    guardarPagos();
                    mostrarAcuerdoPago();
                }
                else
                {
                    MessageBox.Show("No se financio la liquidacion!!!", "Financiacion Fallida");
                    if (posicion != -1)
                        mostrarAcuerdoPago();
                }
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                funciones.mostrarMensaje("Error desconocido realizando la funcionalidad. " + exp.Message, "E");
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        public int buscarUltimaPaga()
        {
            int cuota = 0;
            viewPagosComp detTmp;
            for (int i = 0; i < detalles.Length; i++)
            {
                detTmp = (viewPagosComp)detalles[i];
                if (detTmp.DESCRIPCION == "PAGADO")
                    cuota = detTmp.NOCUOTA;
            }
            return cuota;
        }

        public void eliminarAnteriores()
        {
            viewPagosComp detTmp;
            for (int i = 0; i < detalles.Length; i++)
            {
                detTmp = (viewPagosComp)detalles[i];
                if (detTmp.DESCRIPCION != "PAGADO")
                    eliminarCuota(detTmp.ID);
            }
        }

        public void eliminarCuota(int id)
        {
            ServiciosLiquidacionCompService myServLiqCom = WS.ServiciosLiquidacionCompService();
            pagosComp tmp = new pagosComp();
            tmp.ID = id;
            if (!myServLiqCom.eliminarPagoComp(tmp, WS.MyUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName()))
                MessageBox.Show("Error eliminacion", "Se produjo un error eliminando");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImpFinanc_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtGrdDetalle.DataSource != null)
                {
                    int nroCuota = -1;
                    int idLiquidacion = -1;
                    int idInfractor = -1;
                    DataTable dt = (DataTable)dtGrdDetalle.DataSource;
                    if (dtGrdDetalle.SelectedCells != null && dtGrdDetalle.SelectedCells.Count > 0)
                    {
                        nroCuota = int.Parse(dt.Rows[dtGrdDetalle.SelectedCells[0].RowIndex]["NOCUOTA"].ToString());
                        idLiquidacion = myLiquidacion.IDLIQUIDACION;
                        idInfractor = myInfractor.ID_INFRACTOR;
                        //crear registros bd
                        string numRecibo = FacturarCuotaPago(idInfractor, idLiquidacion, nroCuota);
                        cargarDetalles();

                        if (numRecibo != null && numRecibo != "" && numRecibo != "-1")
                        {
                            //crear reporte
                            ServiciosLiquidacionCompService servicio = WS.ServiciosLiquidacionCompService();
                            String fileName;
                            fileName = servicio.crearReporteReciboCuotasPago(nroCuota, -1, myInfractor.ID_INFRACTOR, myLiquidacion.IDLIQUIDACION, WS.MyUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName());
                            //mostrar reporte
                            ServiciosConfiguracionesService serviciosConfiguraciones = WS.ServiciosConfiguracionesService();
                            string path = serviciosConfiguraciones.directorioFacturasComparendo();
                            Comparendos.servicios.documentos.transferir t = new Comparendos.servicios.documentos.transferir();
                            t.archivoDelServer(path + fileName + ".pdf");
                        }
                        else
                        {
                            funciones.mostrarMensaje("Ocurrio un error al intentar crear la facturacion del acuerdo de pago", "E");
                        }
                    }
                    else
                    {
                        funciones.mostrarMensaje("Seleccione una cuota de la lista", "W");
                    }
                }
                else
                {
                    funciones.mostrarMensaje("No hay datos de cuotas configuradas para el acuerdo de pago", "W");
                }
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                funciones.mostrarMensaje("Error desconocido realizando la funcionalidad. " + exp.Message, "E");
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private string FacturarCuotaPago(int idInfractor, int idLiquidacion, int nroCuota)
        {
            ServiciosLiquidacionCompService servicio = WS.ServiciosLiquidacionCompService();
            String numFactura = servicio.facturarCuotaPago(idInfractor, idLiquidacion, nroCuota, WS.MyUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName());
            return numFactura;
        }

        private void btnImprAcuePag_Click(object sender, EventArgs e)
        {
            try
            {
                ServiciosLiquidacionCompService servicio = WS.ServiciosLiquidacionCompService();
                String fileName;
                fileName = servicio.crearReporteCuotasPago(myAcuerdo, -1, myInfractor.ID_INFRACTOR, myLiquidacion.IDLIQUIDACION, WS.MyUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName());

                ServiciosConfiguracionesService serviciosConfiguraciones = WS.ServiciosConfiguracionesService();
                string path = serviciosConfiguraciones.directorioFacturasComparendo();
                Comparendos.servicios.documentos.transferir t = new Comparendos.servicios.documentos.transferir();
                t.archivoDelServer(path + fileName + ".pdf");
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                funciones.mostrarMensaje("Error intentando crear el reporte en el servidor. " + exp.Message, "E");
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            funciones.lanzarTapConEnter(e);
        }

        private void dtpFechaCompr_KeyPress(object sender, KeyPressEventArgs e)
        {
            funciones.lanzarTapConEnter(e);
        }

        private void cmbBoxTipoDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            funciones.lanzarTapConEnter(e);
        }

    }
}
