using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TransportePublico.servicios.reportes.generales;
using LibreriasSintrat.utilidades;
using LibreriasSintrat.ServiciosLogs;
using LibreriasSintrat.ServiciosUsuarios; 

namespace TransportePublico.servicios.vehiculos
{
    public partial class VerDatos : Form
    {
        ServiciosLogsService serviciosLogs;
        usuarios usuarioSistema;

        Object[] mylista = null;
        String mytipo = "";
        Log log = new Log();

        public VerDatos(Object[] listallega, String tipollega, usuarios user)
        {
            usuarioSistema = user;
            serviciosLogs = WS.ServiciosLogsService();

            mylista = listallega;
            mytipo = tipollega;
            InitializeComponent();
            log = new Log();
        }

        private void VerDatos_Load(object sender, EventArgs e)
        {
            if (mytipo == "propietarios")
            {
                mostrarPropietarios();
            }
            else if (mytipo == "tarjetas")
            {
                mostrarTarjetas();
            }
            else if (mytipo == "documentos")
            {
                mostrarDocumentos();
            }
        }

        private void mostrarPropietarios()
        {
            Funciones funciones = WS.Funciones();
            DataTable dt = new DataTable();
            ArrayList Campos = new ArrayList();
            Campos.Add("ANUMCUPO = NÚMERO_DEL_CUPO");
            Campos.Add("BIDENTIFICACION = IDENTIFICACIÓN_ó_NIT");
            Campos.Add("CNOMBRE = TIPO_DE_PROPIETARIO/NOMBRE_ó_RAZÓN_SOCIAL");
            Campos.Add("DFECHAREGISTRO = FECHA_DE_REGISTRO_DEL_PROPIETARIO");
            try
            {
                dt = funciones.ToDataTable(funciones.ObjectToArrayList(mylista));
            }
            catch (Exception e) {
                log.escribirError(e.ToString(), this.GetType());
            }
            grillaresultante.DataSource = dt;
            if (dt.Rows.Count > 0)
                funciones.configurarGrilla(grillaresultante, Campos);
            dt = null;
            Campos = null;
        }

        private void mostrarTarjetas()
        {
            Funciones funciones = WS.Funciones();
            DataTable dt = new DataTable();
            ArrayList Campos = new ArrayList();
            Campos.Add("NUMERO = NÚMERO_TARJETA_OPERACIÓN");
            Campos.Add("ESTADO = ESTADO_TARJETA_OPERACIÓN");
            Campos.Add("FECHAREGISTRO = FECHA_REGISTRO_TARJETA_OPERACIÓN");
            Campos.Add("FECHAVENCIMIENTO = FECHA_VENCIMIENTO_TARJETA_OPERACIÓN");
            try
            {
                dt = funciones.ToDataTable(funciones.ObjectToArrayList(mylista));
            }
            catch (Exception e) {
                log.escribirError(e.ToString(), this.GetType());
            }
            grillaresultante.DataSource = dt;
            if (dt.Rows.Count > 0)
                funciones.configurarGrilla(grillaresultante, Campos);
            dt = null;
            Campos = null;
        }

        private void mostrarDocumentos()
        {
            Funciones funciones = WS.Funciones();
            DataTable dt = new DataTable();
            ArrayList Campos = new ArrayList();
            Campos.Add("ADESCRIPCION = TIPO_DE_DOCUMENTO");
            Campos.Add("NUMERORESOLUCION = NÚMERO_DE_RESOLUCIÓN");
            Campos.Add("FECHARESOLUCION = FECHA_DE_RESOLUCIÓN");
            Campos.Add("DFECHAREGISTRO = FECHA_REGISTRO_DE_RESOLUCIÓN");
            try
            {
                dt = funciones.ToDataTable(funciones.ObjectToArrayList(mylista));
            }
            catch (Exception e) {
                log.escribirError(e.ToString(), this.GetType());
            }
            grillaresultante.DataSource = dt;
            if (dt.Rows.Count > 0)
                funciones.configurarGrilla(grillaresultante, Campos);
            dt = null;
            Campos = null;
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            if (mytipo == "propietarios")
            {
                VerReportePropietarios visor = new VerReportePropietarios(grillaresultante);
                visor.ShowDialog();
            }
            else if (mytipo == "tarjetas")
            {
                VerReporteTarjetas visor = new VerReporteTarjetas(grillaresultante);
                visor.ShowDialog();    
            }
            else if (mytipo == "documentos")
            {
                VerReporteDocumentos visor = new VerReporteDocumentos(grillaresultante);
                visor.ShowDialog();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
