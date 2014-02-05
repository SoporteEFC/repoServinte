using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibreriasSintrat.ServiciosCuposTrans;
using LibreriasSintrat.ServiciosPropietarios;
using LibreriasSintrat.utilidades;
using LibreriasSintrat.ServiciosLogs;
using LibreriasSintrat.ServiciosUsuarios;
 


namespace TransportePublico.servicios.vehiculos
{
    public partial class informesgenerales : Form
    {
        ServiciosCuposTransService clienteCuposTrans;
        Object[] listapropietarios = null;
        Object[] listaVehiculos = null;
        Object[] listatarjetas = null;
        Object[] listadocumentos = null;
        viewDatosCupoTrans vistaseleccionada = new viewDatosCupoTrans();
        Log log = new Log();

        ServiciosLogsService serviciosLogs;
        usuarios usuarioSistema;


        public informesgenerales(usuarios user)
        {

            usuarioSistema = user;
            serviciosLogs = WS.ServiciosLogsService();
            InitializeComponent();
            log = new Log();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void informesgenerales_Load(object sender, EventArgs e)
        {
            btnpropietarios.Enabled = false;
            btntarjetas.Enabled = false;
            btnDocumentos.Enabled = false;

            logs tmpLog = new logs();
            tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
            tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
            tmpLog.OBJETO = "TIPOVEHICULO";
            tmpLog.MODULO = "TPUBLICO";
            tmpLog.TIPO_TRANSACCION = "SELECT";
            TimeSpan TS;
            DateTime dt1 = DateTime.Now;

            tipoVehiculoTrans tipo = new tipoVehiculoTrans();
            clienteCuposTrans = WS.ServiciosCuposTransService();
            Funciones funciones = WS.Funciones();

            string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(tipo.GetType(), new object[] { tipo });
            tmpLog.ESTADO_ANTERIOR = objetoAnalizado;

            Object[] listat = (Object[])clienteCuposTrans.getTipoVehiculoTrans(tipo);

            DateTime dt2 = DateTime.Now;
            TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
            tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;
            serviciosLogs.crearRegistroLog(tmpLog);

            if (listat != null)
            {
                cmbTipoVehiculo.DataSource = null;
                cmbTipoVehiculo.DisplayMember = "NOMBRE";
                cmbTipoVehiculo.ValueMember = "ID";
                funciones.llenarCombo(cmbTipoVehiculo, listat);
            }
            cmbTipoVehiculo.Focus();
        }

        private void numerocupo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones funciones = WS.Funciones();
            funciones.esNumero(e);
            funciones.lanzarTapConEnter(e);
        }

        private void btnpropietarios_Click(object sender, EventArgs e)
        {
            Object[] mylista = buscarPropietarios();
            if (mylista != null && mylista.Length > 0)
            {
                VerDatos verD = new VerDatos(mylista, "propietarios",usuarioSistema);
                verD.Text = "[Propietarios]";
                verD.ShowDialog();
            }
            else
            {
                MessageBox.Show("No se encontraron propietarios","Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void btntarjetas_Click(object sender, EventArgs e)
        {
            Object[] mylista = buscarTarjetas();
            if (mylista != null && mylista.Length > 0)
            {
                VerDatos verD = new VerDatos(mylista, "tarjetas",usuarioSistema);
                verD.Text = "[Tarjetas de Operación]";
                verD.ShowDialog();
            }
            else
            {
                MessageBox.Show("No se encontraron Tarjetas de Operación", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDocumentos_Click(object sender, EventArgs e)
        {
            Object[] mylista = buscarDocumentos();
            if (mylista != null && mylista.Length > 0)
            {
                VerDatos verD = new VerDatos(mylista, "documentos",usuarioSistema);
                verD.Text = "[Documentos y/o Resoluciones]";
                verD.ShowDialog();
            }
            else
            {
                MessageBox.Show("No se encontraron Documentos y/o Resoluciones", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSearchVehiculos_Click(object sender, EventArgs e)
        {
            validaciones();            
        }

        private void validaciones()
        {
            if (cmbTipoVehiculo.SelectedIndex < 0)
            {
                MessageBox.Show("Debe Seleccionar un Tipo de Vehículo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbTipoVehiculo.Focus();
            }
            else if (numerocupo.Text == "")
            {
                MessageBox.Show("El Campo Número Cupo no Puede ser Vacio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numerocupo.Focus();
            }
            else
            {
                buscarVehiculos();    
            }
        }

        private void buscarVehiculos()
        {
            logs tmpLog = new logs();
            tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
            tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
            tmpLog.OBJETO = "VIEW_DATOSPORCUPO";
            tmpLog.MODULO = "TPUBLICO";
            tmpLog.TIPO_TRANSACCION = "SELECT";
            TimeSpan TS;
            DateTime dt1 = DateTime.Now;

            clienteCuposTrans = WS.ServiciosCuposTransService();
            viewDatosCupoTrans vista = new viewDatosCupoTrans();
            vista.ATT_NUMCUPO = Int32.Parse(numerocupo.Text.ToString());
            vista.TT_TIPOVEH = cmbTipoVehiculo.SelectedValue.ToString();

            string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(vista.GetType(), new object[] { vista });
            tmpLog.ESTADO_ANTERIOR = objetoAnalizado;

            listaVehiculos = clienteCuposTrans.getSViewDatosCupo(vista);

            DateTime dt2 = DateTime.Now;
            TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
            tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;
            serviciosLogs.crearRegistroLog(tmpLog);

            if (listaVehiculos != null && listaVehiculos.Length >= 0)
            {
                mostrarVehiculos(listaVehiculos);
                btnpropietarios.Enabled = true;
                btntarjetas.Enabled = true;
                btnDocumentos.Enabled = true;
            }
            else
            {
                MessageBox.Show("No se encontró información", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                grillavehiculos.DataSource = null;
                btnpropietarios.Enabled = false;
                btntarjetas.Enabled = false;
                btnDocumentos.Enabled = false;
            }
        }

        private void mostrarVehiculos(Object[] lalista)
        {
            Funciones funciones = WS.Funciones();
            DataTable dt = new DataTable();
            ArrayList Campos = new ArrayList();
            Campos.Add("ATT_NUMCUPO = NÚMERO CUPO");
            Campos.Add("CNOMBREEMPRESASERCICIO = EMPRESA DE SERVICIO");
            Campos.Add("BPLACA = PLACA");
            Campos.Add("ENOMBRES = PERSONA PROPIETARIA");
            Campos.Add("DIDENTIFICACION = IDENTIFICACION");
            Campos.Add("HNIT = NIT PROPIETARIO");
            Campos.Add("IRAZONSOCIAL = EMPRESA PROPIETARIA");
            Campos.Add("LMARCAVEHICULO = MARCA");
            Campos.Add("KMODELO = MODELO");
            Campos.Add("MNUMEROTARJETAOPERACION = TARJETA DE OPERACIÓN");
            Campos.Add("NFECHAVENCIMIENTOTARJETAOPER = FECHA DE VENCIMIENTO");
            try
            {
                dt = funciones.ToDataTable(funciones.ObjectToArrayList(lalista));
            }
            catch (Exception e) {
                log.escribirError(e.ToString(), this.GetType());
            }
            grillavehiculos.DataSource = dt;
            if (dt.Rows.Count > 0)
                funciones.configurarGrilla(grillavehiculos, Campos);
            dt = null;
            Campos = null;

            grillavehiculos.Select();
        }

        public Object[] buscarPropietarios()
        {
            logs tmpLog = new logs();
            tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
            tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
            tmpLog.OBJETO = "VIEW_PROPIETARIOSCUPO";
            tmpLog.MODULO = "TPUBLICO";
            tmpLog.TIPO_TRANSACCION = "SELECT";
            TimeSpan TS;
            DateTime dt1 = DateTime.Now;

            clienteCuposTrans = WS.ServiciosCuposTransService();
            viewPropietariosCupoTrans propietariosss = new viewPropietariosCupoTrans();
            propietariosss.IDCUPO = vistaseleccionada.TT_IDCUPOTAXI;

            string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(propietariosss.GetType(), new object[] { propietariosss});
            tmpLog.ESTADO_ANTERIOR = objetoAnalizado;

            listapropietarios = (Object[])clienteCuposTrans.getSViewPropietariosCupo(propietariosss);

            DateTime dt2 = DateTime.Now;
            TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
            tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;
            serviciosLogs.crearRegistroLog(tmpLog);


            return listapropietarios;
        }

        public Object[] buscarTarjetas()
        {
            logs tmpLog = new logs();
            tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
            tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
            tmpLog.OBJETO = "VIEW_TARJETASOPERACION";
            tmpLog.MODULO = "TPUBLICO";
            tmpLog.TIPO_TRANSACCION = "SELECT";
            TimeSpan TS;
            DateTime dt1 = DateTime.Now;

            clienteCuposTrans = WS.ServiciosCuposTransService();
            viewTarjetasCupoTrans tarjetas = new viewTarjetasCupoTrans();
            tarjetas.IDCUPO = vistaseleccionada.TT_IDCUPOTAXI;

            string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(tarjetas.GetType(), new object[] { tarjetas});
            tmpLog.ESTADO_ANTERIOR = objetoAnalizado;

            listatarjetas = (Object[])clienteCuposTrans.getSViewTarjetasCupo(tarjetas);

            DateTime dt2 = DateTime.Now;
            TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
            tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;
            serviciosLogs.crearRegistroLog(tmpLog);

            return listatarjetas;
        }

        public Object[] buscarDocumentos()
        {
            logs tmpLog = new logs();
            tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
            tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
            tmpLog.OBJETO = "VIEW_RESOLUCIONES";
            tmpLog.MODULO = "TPUBLICO";
            tmpLog.TIPO_TRANSACCION = "SELECT";
            TimeSpan TS;
            DateTime dt1 = DateTime.Now;

            clienteCuposTrans = WS.ServiciosCuposTransService();
            viewResoluciones documentos = new viewResoluciones();
            documentos.IDCUPOTAXI = vistaseleccionada.TT_IDCUPOTAXI;

            string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(documentos.GetType(), new object[] { documentos});
            tmpLog.ESTADO_ANTERIOR = objetoAnalizado;

            listadocumentos = (Object[])clienteCuposTrans.getSViewResoluciones(documentos);

            DateTime dt2 = DateTime.Now;
            TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
            tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;
            serviciosLogs.crearRegistroLog(tmpLog);

            return listadocumentos;
        }

        private void grillavehiculos_SelectionChanged(object sender, EventArgs e)
        {
            if (grillavehiculos.CurrentRow != null && listaVehiculos != null)
            {
                vistaseleccionada = (viewDatosCupoTrans)listaVehiculos[grillavehiculos.CurrentRow.Index];
            }
            else
            {
                grillavehiculos.DataSource = null;
                vistaseleccionada = null;
            }  
        }

        private void cmbTipoVehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbTipoVehiculo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones funciones = WS.Funciones();
            funciones.lanzarTapConEnter(e);
        }
    }
}
