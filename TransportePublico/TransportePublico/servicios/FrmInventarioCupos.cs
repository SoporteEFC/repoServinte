﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibreriasSintrat.ServiciosCuposTrans;
using LibreriasSintrat.ServiciosAccesorias;
using LibreriasSintrat.utilidades;
using System.Collections;
using TransitoPrincipal;
using LibreriasSintrat.ServiciosLogs;
using LibreriasSintrat.ServiciosUsuarios;


namespace TransportePublico.servicios
{
    public partial class FrmInventarioCupos : Form
    {
        ServiciosCuposTransService clienteCupos;
        ServiciosAccesoriasService clienteAccesorias;
        Funciones funciones;
        object[] listaEmpresasServicio;
        object[] listaTipoVehiculo;
        ServiciosLogsService serviciosLogs;
        usuarios usuarioSistema;


        public FrmInventarioCupos(usuarios user)
        {
            usuarioSistema = user;
            serviciosLogs = WS.ServiciosLogsService();
            InitializeComponent();
            clienteCupos = WS.ServiciosCuposTransService();
            clienteAccesorias = WS.ServiciosAccesoriasService();
            funciones = new Funciones();

            lblInfoEstadoAsignado.Text = "¡Nota Importante!: ASIGNADO y DISPONIBLE corresponden a la disponibilidad de cupos respecto a Vehículos.";

            logs tmpLog = new logs();
            tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
            tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
            tmpLog.OBJETO = "EMPRESASDESERVICIO";
            tmpLog.MODULO = "TPUBLICO";
            tmpLog.TIPO_TRANSACCION = "SELECT";
            TimeSpan TS;
            DateTime dt1 = DateTime.Now;

            listaEmpresasServicio = clienteCupos.getTEmpresasServicio(new empresasdeServicioTrans());

            DateTime dt2 = DateTime.Now;
            TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
            tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;
            serviciosLogs.crearRegistroLog(tmpLog);

            funciones.llenarCombo(cmbEmpresa, listaEmpresasServicio);

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool validarBusqueda()
        {
            if (chkEmpresa.Checked && cmbEmpresa.SelectedIndex == -1)
            {
                MessageBox.Show("Si filtra por Empresa de servicio debe definir un valor");
                return false;
            }
            else
            {
                if (chkEstado.Checked && cmbEstado.SelectedIndex == -1)
                {
                    MessageBox.Show("Si filtra por Estado debe definir un valor");
                    return false;
                }
                else
                {
                    if (chkTipoVehiculo.Checked && cmbTipoVehiculo.SelectedIndex == -1)
                    {
                        MessageBox.Show("Si filtra por Tipo de vehículo debe definir un valor");
                        return false;
                    }
                }
            }
            return true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            viewinventariocupos inventariorango =  new viewinventariocupos();

            inventariorango.DISPONIBLE = cmbEstado.Text;
            inventariorango.RAZON_SOCIAL = cmbEmpresa.Text;
            inventariorango.TIPO_VEHICULO = cmbTipoVehiculo.Text;

            logs tmpLog = new logs();
            tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
            tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
            tmpLog.OBJETO = "VIEW_INVENTARIO_CUPOS";
            tmpLog.MODULO = "TPUBLICO";
            tmpLog.TIPO_TRANSACCION = "SELECT";
            TimeSpan TS;
            DateTime dt1 = DateTime.Now;
            string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(inventariorango.GetType(), new object[] { inventariorango});
            tmpLog.ESTADO_ANTERIOR = objetoAnalizado;


            object[] listaInventario = clienteCupos.getViewinventariocupos(inventariorango);

            if (listaInventario == null || listaInventario.Length == 0)
            {
                DateTime dt2 = DateTime.Now;
                TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
                tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;
                serviciosLogs.crearRegistroLog(tmpLog);

                MessageBox.Show("No se encontraron resultados");
                label1.Text ="No se encontraron resultados.";
            }
            else
                label1.Text = "Se encontraron: "+ listaInventario.Length + " resultados.";

            DataTable dt = new DataTable();
            ArrayList Campos = new ArrayList();
            Campos.Add("NUMERO_CUPO = NÚMERO CUPO");
            Campos.Add("DISPONIBLE = ESTADO CUPO");
            Campos.Add("TIPO_VEHICULO = TIPO DE VEHÍCULO");
            Campos.Add("NIT_EMPRESA_SERVICIO = NIT EMPRESA SERVICIO");
            Campos.Add("RAZON_SOCIAL = RAZON_SOCIAL");
            
            try
            {                             
                dt = funciones.ToDataTable(funciones.ObjectToArrayList(listaInventario));

                dt.Columns.Remove("ID_DETALLERANGOCUPO");
            }
            catch(Exception exce)
            {
            
            }

            dgwResultados.DataSource = dt;

        }

        private void btnBuscarEmpresa_Click(object sender, EventArgs e)
        {
            empresasdeServicioTrans empresa = new empresasdeServicioTrans();
            empresasdeServicioTrans newempresa = new empresasdeServicioTrans();

            ArrayList Campos = new ArrayList();
            Campos.Add("NOMBRE = NOMBRE");
            Campos.Add("SIGLA = SIGLA");
            Campos.Add("NIT = NIT");
            
            buscador buscador = new buscador(listaEmpresasServicio, Campos, "Empresas", null);

            if (buscador.ShowDialog() == DialogResult.OK)
            {
                newempresa = (empresasdeServicioTrans)funciones.listToEmpresaServicio(buscador.Seleccion);
                cmbEmpresa.SelectedValue = newempresa.ID_EMPSERVICIO;
            }
        }

        private void chkEstado_CheckedChanged(object sender, EventArgs e)
        {
            validarSelecciones();
        }

        private void chkTipoVehiculo_CheckedChanged(object sender, EventArgs e)
        {
            validarSelecciones();
        }

        public void validarSelecciones()
        {
            if (chkEmpresa.Checked)
            {
                cmbEmpresa.Enabled = true;
                cmbEmpresa.SelectedIndex = 0;
            }
            else
            {
                cmbEmpresa.Enabled = false;
                cmbEmpresa.SelectedIndex = -1;
            }

            if (chkTipoVehiculo.Checked)
            {
                cmbTipoVehiculo.Enabled = true;
                cmbTipoVehiculo.SelectedIndex = 0;
            }
            else
            {
                cmbTipoVehiculo.Enabled = false;
                cmbTipoVehiculo.SelectedIndex = -1;
            }

            if (chkEstado.Checked)
            {
                cmbEstado.Enabled = true;
                cmbEstado.SelectedIndex = 0;
            }
            else
            {
                cmbEstado.Enabled = false;
                cmbEstado.SelectedIndex = -1;
            }
        }

        private void chkEmpresa_CheckedChanged(object sender, EventArgs e)
        {
            validarSelecciones();
        }

        private void FrmInventarioRango_Load(object sender, EventArgs e)
        {
            validarSelecciones();
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog ofd = new FolderBrowserDialog();
                ofd.ShowNewFolderButton = true;
                ofd.Description = "Seleccione el directorio de destino para el reporte.";

                if (ofd.ShowDialog() == DialogResult.OK)
                    funciones.exportarDataGridViewAExcel(ofd.SelectedPath, "Reporte de rangos", dgwResultados);
            }
            catch(Exception)
            {
                funciones.mostrarMensaje("No se pudo generar el documento de reportes", "W");
            }
        }
    }
}
