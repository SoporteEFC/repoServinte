using System; using TransitoPrincipal;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibreriasSintrat.ServiciosLiquidacionComp;
using LibreriasSintrat.ServiciosConfiguraciones;
using LibreriasSintrat.ServiciosGeneralesComp;
using LibreriasSintrat.ServiciosAccesoriasComp;
using LibreriasSintrat.ServiciosAccesorias;
using Comparendos.utilidades;
using LibreriasSintrat.utilidades; 
using LibreriasSintrat;
using System.Globalization;

namespace Comparendos.servicios.liquidacion
{
    public partial class fFinanciar : Form
    {
        private liquidacionComp myliq;
        public Object[] myCuotas;
        private float deudaTotal;
        public float interesFinanc;
        private int cuotas;
        private int por1a;
        private bool calculoInicial;
        DateTime myFecha;
        int ultimaCuota;

        Log log = new Log();
        CultureInfo culturaEspaniolCol = new CultureInfo("es-CO", false);


        Funciones funciones;

        int minValor;
        ServiciosConfiguracionesService serviciosConfiguraciones;
        ServiciosGeneralesCompService serviciosGeneralesComp;
        
        float[] pagos;

        public fFinanciar(liquidacionComp myLiquid)
        {
            InitializeComponent();
            myliq = myLiquid;
            deudaTotal = myliq.TOTAL;
            interesFinanc = 0;
            cuotas = 0;
            por1a = 0;
            calculoInicial = true;
            //myFecha = DateTime.Today.AddMonths(1);
            myFecha = DateTime.Today;
            btnGuardar.Enabled = false;
            ultimaCuota = 0;
            serviciosConfiguraciones = WS.ServiciosConfiguracionesService();
            serviciosGeneralesComp = WS.ServiciosGeneralesCompService();
            minValor = serviciosConfiguraciones.redondeoValorUnidad();
            funciones = new Funciones();
        }

        public fFinanciar(liquidacionComp myLiquid,int ultimaPaga)
        {
            InitializeComponent();
            myliq = myLiquid;
            deudaTotal = myliq.TOTAL;
            interesFinanc = 0;
            cuotas = 0;
            por1a = 0;
            calculoInicial = true;
            //myFecha = DateTime.Today.AddMonths(1);
            myFecha = DateTime.Today;
            btnGuardar.Enabled = false;
            ultimaCuota = ultimaPaga;
            serviciosConfiguraciones = WS.ServiciosConfiguracionesService();
            minValor = serviciosConfiguraciones.redondeoValorUnidad();
            funciones = new Funciones();
        }

        private void fFinanciar_Load(object sender, EventArgs e)
        {
            try
            {
                mostrarInfo();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        public void mostrarInfo()
        {
            txtDeuda.Text = myliq.TOTAL.ToString("C", culturaEspaniolCol);
            lblDeudaTotal.Text = "Total Deuda: " + ((int)deudaTotal).ToString("C", culturaEspaniolCol);
            lblTotalRedondeado.Text = "Deuda Total Real: " + (pagos != null ? "" + pagos.Sum().ToString("C", culturaEspaniolCol) : "0");
        }

        public void cargarDatos()
        {
            if (txtIntFinan.Text == "")
                txtIntFinan.Text = "0";
            interesFinanc = float.Parse(txtIntFinan.Text);
            if (txtCuotas.Text == "")
                txtCuotas.Text = "1";
            cuotas = int.Parse(txtCuotas.Text);
            if (cuotas == 1)
            {
                txtPorc1a.Text = "100";
                txtPorc1a.Enabled = false;
            }
            else
            {
                txtPorc1a.Enabled = true;
                if (txtPorc1a.Text == "")
                    txtPorc1a.Text = "50";
            }
            por1a = int.Parse(txtPorc1a.Text);
        }

        public void calcularTotal()
        {
            float deuda= funciones.strToFloat(funciones.moneyToStr(txtDeuda.Text));
            float porc = (float)interesFinanc / 100;
            deudaTotal = deuda + (deuda * porc)*cuotas;
        }

        private void txtIntFinan_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    AccionCalcularTodo();
                }
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void txtIntFinan_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Funciones myFunc = new Funciones();
                myFunc.esDecimal(e);
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void txtCuotas_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    AccionCalcularTodo();
                }
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        public void calcularCuotas()
        {
            Funciones fnc = new Funciones();
            float[] porcent = new float[cuotas];
            pagos = new float[cuotas];
            float saldo=0;
            float pagoCuota=0;
            int cuotRest =cuotas;
            float porComun;
            float sumPorc=0;
            porcent[0] = (float)por1a;
            sumPorc = porcent[0];
            //pagos[0] = fnc.redondear(deudaTotal * porcent[0]/100);
            pagos[0] = float.Parse("" + fnc.RedondeoArriba(deudaTotal * porcent[0]/100, minValor));
            saldo = deudaTotal - pagos[0];
            if (cuotRest>1)
                cuotRest--;
            pagoCuota=saldo/cuotRest;
            porComun = (100 - porcent[0])/cuotRest;
            for (int i = 1; i < cuotas-1; i++)
            {
                porcent[i] = porComun;
                sumPorc += porcent[i];
                //pagos[i] = fnc.redondear(pagoCuota);
                pagos[i] = float.Parse("" + fnc.RedondeoArriba(pagoCuota, minValor));
            }
            if (cuotas > 1)
            {
                porcent[cuotas - 1] = 100 - sumPorc;
                //pagos[cuotas - 1] = fnc.redondear(deudaTotal * porcent[cuotas - 1] / 100);
                pagos[cuotas - 1] = float.Parse("" + fnc.RedondeoArriba(deudaTotal * porcent[cuotas - 1] / 100, minValor));
            }
            crearCuotas(pagos, porcent);
        }

        public void crearCuotas(float[] pagos, float[] porc)
        {
            pagosComp myPago;
            DateTime myFechaAux;
            bool bandera = false;
            String formatofecha = "";
            String formatoBusquedaDiaFestivo = "";

            ServiciosConfiguracionesService myServicioConfiguracion = WS.ServiciosConfiguracionesService();
            String motor = myServicioConfiguracion.leerRegistroIni("MOTOR");

            if (motor.Equals("ORACLE"))
            {
                //formatofecha = "MM/dd/yyyy";
                formatoBusquedaDiaFestivo = "yyyy-MM-dd 00:00:00";
            }
            else
            {
                //formatofecha = "MM/dd/yyyy";
                formatoBusquedaDiaFestivo = "yyyy-MM-dd";
            }

            if (myCuotas != null && myCuotas.Length > 0)
            {
                myPago = (pagosComp)myCuotas[0];
                myFecha = DateTime.ParseExact(myPago.FECHAPAGO, "MM/dd/yyyy", System.Globalization.CultureInfo.CurrentCulture);
            }

            myCuotas = new Object[cuotas];
            for (int i = 0; i < cuotas; i++)
            {
                myPago = new pagosComp();
                myPago.VALOR = pagos[i];
                myPago.PORCENTAJE = porc[i];
                myPago.ESTADO = 14;
                myFechaAux = myFecha;
                while (esFestivo(myFechaAux.ToString(formatoBusquedaDiaFestivo)))
                {
                    bandera = true;
                    myFechaAux = myFechaAux.AddDays(1);
                }

                if (bandera == true)
                {
                    myPago.FECHAPAGO = String.Format("{0:MM/dd/yyyy}", myFechaAux);
                    bandera = false;
                }
                else
                {
                    myPago.FECHAPAGO = String.Format("{0:MM/dd/yyyy}", myFecha);
                }

                myPago.NOCUOTA = i + 1 + ultimaCuota;
                myPago.IDLIQUIDACION = myliq.IDLIQUIDACION;
                myCuotas[i] = (Object)myPago;
                myFecha = myFecha.AddMonths(1);
            }
        }

        public Boolean esFestivo(String fecha)
        {
            Boolean esFestivo = false;
            Object[] listaDiasFestivos = serviciosGeneralesComp.obtenerDiasFestivos(null);

            foreach (diasfestivos item in listaDiasFestivos)
            {
                if (item.fecha.Equals(fecha))
                {
                    esFestivo = true;
                    break;
                }
            }
            return esFestivo;
        }

        private void txtCuotas_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Funciones myFunc = new Funciones();
                myFunc.esNumero(e);
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void txtPorc1a_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Funciones myFunc = new Funciones();
                myFunc.esNumero(e);
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void txtPorc1a_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    AccionCalcularTodo();
                }
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        public void mostrarCuotas()
        {
            Funciones funciones = new Funciones();
            DataTable dt = new DataTable();
            ArrayList Campos = new ArrayList();
            Campos.Add("NOCUOTA = CUOTA");
            Campos.Add("PORCENTAJE = PORCENTAJE");
            Campos.Add("VALOR = VALOR");
            Campos.Add("FECHAPAGO = FECHA");
            try
            {
                dt = funciones.ToDataTable(funciones.ObjectToArrayList(myCuotas));
            }
            catch (Exception e) {
                log.escribirError(e.ToString(), this.GetType());
            }
            dtGrdDetalle.DataSource = dt;
            if (dt.Rows.Count > 0)
                funciones.configurarGrilla(dtGrdDetalle, Campos);
            dt = null;
            calculoInicial = false;
            btnGuardar.Enabled = true;
        }


        private void dtGrdDetalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (!calculoInicial)
                {
                    Object myMod;
                    int cambio;
                    Funciones myfunc = new Funciones();
                    if (ValidarModificacion(dtGrdDetalle.CurrentRow))
                    {
                        myMod = myfunc.listToPagosComp(dtGrdDetalle.CurrentRow);
                        cambio = buscarModificado(myMod);
                        if (cambio > 0 && cambio < (myCuotas.Length - 1))
                        {
                            recalcularDesde(cambio, (pagosComp)myMod);
                            if (((pagosComp)myMod).FECHAPAGO != ((pagosComp)myCuotas[cambio]).FECHAPAGO)
                                cambiarFechasDesde(cambio, (pagosComp)myMod);
                            mostrarCuotas();
                        }
                        else if (cambio == 0 || cambio == myCuotas.Length - 1)
                        {
                            if (((pagosComp)myMod).FECHAPAGO != ((pagosComp)myCuotas[cambio]).FECHAPAGO)
                                cambiarFechasDesde(cambio, (pagosComp)myMod);
                            mostrarCuotas();
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private bool ValidarModificacion(DataGridViewRow dgvr)
        {
            bool res = true;
            DateTime date;
            float valor;
            float[] totales = CalcularTotales(dgvr.Index, true);
            dgvr.Cells["NOCUOTA"].Value = dgvr.Index + 1;
            res = DateTime.TryParse(dgvr.Cells["FECHAPAGO"].Value.ToString(), out date);
            if (!res) { dgvr.Cells["FECHAPAGO"].Value = DateTime.Now.ToString("MM/dd/yyyy");  }
            res = float.TryParse(dgvr.Cells["PORCENTAJE"].Value.ToString(), out valor);
            if (!res) { dgvr.Cells["PORCENTAJE"].Value = 1;  }
            if (valor < 1) dgvr.Cells["PORCENTAJE"].Value = 1;
            if (valor > 100 - totales[0] - 1) dgvr.Cells["PORCENTAJE"].Value = 100 - totales[0] - 1;
            //if (valor > 99 - por1a) dgvr.Cells["PORCENTAJE"].Value = 99 - por1a;
            res = float.TryParse(dgvr.Cells["VALOR"].Value.ToString(), out valor);
            if (!res) { dgvr.Cells["VALOR"].Value = 50;  }
            if (valor < 50) dgvr.Cells["VALOR"].Value = 50;
            if (valor > deudaTotal - totales[1] - 50) dgvr.Cells["VALOR"].Value = deudaTotal - totales[1] - 50;
            return res;
        }

        private float[] CalcularTotales(int posIgnorar, bool hasta) //enviar -1 para calcular todo
        {
            float[] res = new float[2];
            res[0] = 0; //porcentajes
            res[1] = 0; //valores
            pagosComp obj;
            Funciones funciones = new Funciones();
            for (int i = 0; i < dtGrdDetalle.Rows.Count; i++)
            {
                if (i != posIgnorar)
                {
                    obj = (pagosComp)funciones.listToPagosComp(dtGrdDetalle.Rows[i]);
                    res[0] += obj.PORCENTAJE;
                    res[1] += obj.VALOR;
                }
                else if (hasta) return res;
            }
            return res;
        }

        public void cambiarFechasDesde(int item,pagosComp cambiar)
        {
            pagosComp tmp;
            DateTime dt = DateTime.Parse(cambiar.FECHAPAGO);
            calculoInicial = true;
            if (item == 0)
                myFecha = DateTime.Parse(cambiar.FECHAPAGO);
            for (int i = item ; i < myCuotas.Length; i++)
            {
                tmp = (pagosComp)myCuotas[i];
                tmp.FECHAPAGO = String.Format("{0:MM/dd/yyyy}", dt); ;
                myCuotas[i] = (Object)tmp;
                dt = dt.AddMonths(1);
            }
            calculoInicial = false;
        }

        public void recalcularDesde(int item,pagosComp cambiar)
        {
            Funciones fnc = new Funciones();
            float[] porcent = new float[cuotas];
            float[] pagos = new float[cuotas];
            float saldo = 0;
            float pagoCuota = 0;
            int cuotRest = cuotas;
            float porComun;
            float sumPorc = 0;
            pagosComp myTmp;
            saldo = deudaTotal;
            for (int i = 0; i <= item; i++)
            {
                myTmp=(pagosComp)myCuotas[i];
                if (i != item)
                {
                    pagos[i] = myTmp.VALOR;
                    porcent[i] = myTmp.PORCENTAJE;
                }
                else
                {
                    if (myTmp.PORCENTAJE != cambiar.PORCENTAJE)
                    {
                        porcent[i] = cambiar.PORCENTAJE;
                        //pagos[i] = fnc.redondear(deudaTotal * porcent[i] / 100);
                        pagos[i] = float.Parse("" + fnc.RedondeoArriba(deudaTotal * porcent[i] / 100, minValor));
                    }
                    else
                    {
                        if (myTmp.VALOR != cambiar.VALOR)
                        {
                            pagos[i] = cambiar.VALOR;
                            porcent[i] = (pagos[i] / deudaTotal)*100;
                        }
                        else
                        {
                            porcent[i] = myTmp.PORCENTAJE;
                            pagos[i] = myTmp.VALOR;
                        }

                    }
                }
                saldo -= pagos[i];
                sumPorc += porcent[i];
                cuotRest--;
            }
            if (saldo > 0)
            {
                pagoCuota = saldo / cuotRest;
                porComun = (100 - sumPorc) / cuotRest;
            }
            else
            {
                pagoCuota = 0;
                porComun = 0;
            }
            for (int i = item+1; i < cuotas - 1; i++)
            {
                porcent[i] = porComun;
                sumPorc += porcent[i];
                pagos[i] = fnc.redondear(pagoCuota);
                pagos[i] = float.Parse("" + fnc.RedondeoArriba(pagoCuota, minValor));
            }
            if (cuotas > 1)
            {
                porcent[cuotas - 1] = 100 - sumPorc;
                //pagos[cuotas - 1] = fnc.redondear(deudaTotal * porcent[cuotas - 1] / 100);
                pagos[cuotas - 1] = float.Parse("" + fnc.RedondeoArriba(deudaTotal * porcent[cuotas - 1] / 100, minValor));
            }
            crearCuotas(pagos, porcent);
        }

        public int buscarModificado(Object myMod)
        {
            pagosComp mod=(pagosComp)myMod;
            pagosComp act;
            int aCambiar = -1;
            for (int i = 0; i < myCuotas.Length; i++)
            {
                act = (pagosComp)myCuotas[i];
                if (mod.NOCUOTA == act.NOCUOTA)
                {
                    aCambiar = i;
                    return aCambiar;
                }
            }
            return aCambiar;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                AccionCalcularTodo();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void AccionCalcularTodo()
        {
            int valor;
            if (int.TryParse(txtCuotas.Text, out valor))
            {
                if (valor < 2) txtCuotas.Text = "2";
                if (valor > 100) txtCuotas.Text = "100";
            }
            if (int.TryParse(txtIntFinan.Text, out valor))
            {
                if (valor < 0) txtIntFinan.Text = "0";
                if (valor > 100) txtIntFinan.Text = "100";
            }
            if (int.TryParse(txtPorc1a.Text, out valor))
            {
                if (valor < 1) txtPorc1a.Text = "1";
                if (valor > 99) txtPorc1a.Text = "99";
            }
            cargarDatos();
            calcularTotal();
            calcularCuotas();
            mostrarInfo();
            mostrarCuotas();
        }

        private void txtDeuda_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones myFun = new Funciones();
            myFun.lanzarTapConEnter(e);
            myFun.esAlfanumerico(e);
        }
    }
}
