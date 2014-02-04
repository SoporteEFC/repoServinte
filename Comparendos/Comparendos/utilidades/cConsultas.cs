using System; using TransitoPrincipal; using LibreriasSintrat.utilidades;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriasSintrat.ServiciosVehiculos;


namespace Comparendos.utilidades
{
    class cConsultas
    {
        ServiciosVehiculosService clienteVehiculo;

        public cConsultas()
        {
            crearObjetos();     
        }

        public void crearObjetos()
        {
            clienteVehiculo = WS.ServiciosVehiculosService();
        }

        public vehiculo getVehiculo(String placa)
        {
            vehiculo runtVehiculo = new vehiculo();
            runtVehiculo.PLACA = placa;
            runtVehiculo = (vehiculo)clienteVehiculo.getVehiculo(runtVehiculo);
            return runtVehiculo;
        }

        public Boolean estaVehiculo(String placa)
        {
            vehiculo runtVehiculo = new vehiculo();
            runtVehiculo = getVehiculo(placa);
            if (runtVehiculo.ID_VEHICULO > 0)
                return true;
            else
                return false;
        }

    }
}
