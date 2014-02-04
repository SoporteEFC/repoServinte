using System; using TransitoPrincipal; using LibreriasSintrat.utilidades;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibreriasSintrat.ServiciosLiquidacionComp;
using LibreriasSintrat.ServiciosGeneralesComp;
using LibreriasSintrat.utilidades;

namespace Comparendos.servicios.generales
{
    public partial class FrmEliminarAcuerdoPago : Form
    {
        Funciones funciones;
        ServiciosLiquidacionCompService mySerLiquidacionComp;
        acuerdosPagoComp myAcuerdo;
        public FrmEliminarAcuerdoPago()
        {
            InitializeComponent();
            funciones = new Funciones();
            mySerLiquidacionComp = WS.ServiciosLiquidacionCompService();
            myAcuerdo = new acuerdosPagoComp();
        }

        private void txtNumAcuerdoPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            funciones.esNumero(e);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtNumAcuerdoPago.Text == "")
            {
                funciones.mostrarMensaje("El campo número de acuerdo no puede ser vacio", "W");
            }
            else 
            {
                object[] listaAcuerdo;
                myAcuerdo.NUMERO = txtNumAcuerdoPago.Text;
                listaAcuerdo = mySerLiquidacionComp.getAcuerdoPagoComp(myAcuerdo);
                if (listaAcuerdo != null)
                {
                    myAcuerdo = (acuerdosPagoComp)listaAcuerdo[0];
                    liquidacionComp liquidacion = new liquidacionComp();
                    bool eliminado = false;
                    liquidacion.IDLIQUIDACION = myAcuerdo.IDLIQUIDACION;
                    object[] listaLiquidaciones = mySerLiquidacionComp.getLiquidaciones(liquidacion);
                    if (listaLiquidaciones != null)
                    {
                        liquidacion = (liquidacionComp)listaLiquidaciones[0];
                        ServiciosGeneralesCompService mySerGenComp = WS.ServiciosGeneralesCompService();
                        viewLiquidacionComparendo myViewLiquidacionComp = new viewLiquidacionComparendo();
                        myViewLiquidacionComp.IDLIQUIDACION = liquidacion.IDLIQUIDACION;
                        object[] listaViewComparendos = mySerGenComp.getViewLiquiComprendo(myViewLiquidacionComp);
                        if (listaViewComparendos != null)
                        {
                            for (int i = 0; i < listaViewComparendos.Length; i++)
                            {
                                myViewLiquidacionComp = (viewLiquidacionComparendo)listaViewComparendos[i];
                                comparendoComp myComparendo = new comparendoComp();
                                myComparendo.ID_COMPARENDO = myViewLiquidacionComp.ID_COMPARENDO;
                                object[] listaComparendo = mySerGenComp.searchComparendo(myComparendo);
                                if (listaComparendo != null)
                                {
                                    myComparendo = (comparendoComp)listaComparendo[0];
                                    infracionComparendoComp infraccion = new infracionComparendoComp();
                                    infraccion.IDCOMPARENDO = myComparendo.ID_COMPARENDO;
                                    infraccion = mySerGenComp.getInfraccionComparendo(infraccion);
                                    if (infraccion != null && infraccion.ID > 0)
                                    {
                                        //Se coloca el estado del comparendo en estado resolucion
                                        infraccion.IDESTADO = 4;
                                        if (mySerGenComp.actualizarInfraccionComparendo(infraccion, WS.MyUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName()))
                                        {
                                            eliminado = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (mySerLiquidacionComp.eliminarAcuerdoPagoComp(myAcuerdo, WS.MyUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName()) && eliminado == true)
                    {
                        funciones.mostrarMensaje("Acuerdo de pago eliminado correctamente","I");
                    }
                    else
                    {
                        funciones.mostrarMensaje("No se puedo eliminar el acuerdo de pago","E");
                    }
                }
                else
                {
                    funciones.mostrarMensaje("No se encontro acuerdo de pago","W");
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
