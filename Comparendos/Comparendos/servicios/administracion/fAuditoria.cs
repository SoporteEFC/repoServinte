using System; using TransitoPrincipal; using LibreriasSintrat.utilidades;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibreriasSintrat.ServiciosAuditoria;
using LibreriasSintrat.ServiciosUsuarios;
using Comparendos.utilidades; using LibreriasSintrat.utilidades; using LibreriasSintrat;

namespace Comparendos.servicios.administracion
{
    public partial class fAuditoria : Form
    {
        private Boolean cambiofecha;
        private Object[] myInformacion;
        Log log = new Log();

        public fAuditoria()
        {
            InitializeComponent();
            cambiofecha = false;
            log = new Log();
        }

        private void fAuditoria_Load(object sender, EventArgs e)
        {
            cargarCombos();
            cmbBoxTabla.SelectedIndex = -1;
            cmbBoxUsuarios.SelectedIndex = -1;
            cmbBoxTabla.Focus();
        }

        public void cargarCombos()
        {
            Object[] myDatos;
            Funciones myFnc = new Funciones();
            ServiciosAuditoriaService mySerAudit = WS.ServiciosAuditoriaService();
            ServiciosUsuariosService mySerUsu = WS.ServiciosUsuariosService();
            myDatos = mySerAudit.obtenerTablasComp();
            myFnc.llenarCombo(cmbBoxTabla, myDatos);
            myDatos = mySerUsu.listarUsuarios();
            myFnc.llenarCombo(cmbBoxUsuarios,myDatos);

        }

        private void dtPickFechaInicial_ValueChanged(object sender, EventArgs e)
        {
            if(dtPickFechaInicial.Value<=dtPickFechaFinal.Value)
                chckBoxFecha.Checked = true;
            else
                chckBoxFecha.Checked = false;
        }

        private void dtPickFechaFinal_ValueChanged(object sender, EventArgs e)
        {
            if (dtPickFechaInicial.Value <= dtPickFechaFinal.Value)
                chckBoxFecha.Checked = true;
            else
                chckBoxFecha.Checked = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                myInformacion = null;
                ServiciosAuditoriaService mySerAud = WS.ServiciosAuditoriaService();
                auditoriaSystem myAuditSx = new auditoriaSystem();
                if (cmbBoxTabla.SelectedIndex > -1)
                    myAuditSx.TABLAAFECTADA = cmbBoxTabla.SelectedValue.ToString();
                if (cmbBoxUsuarios.SelectedIndex > -1)
                    myAuditSx.ID_USUARIO = int.Parse(cmbBoxUsuarios.SelectedValue.ToString());
                if (txtValor.Text != "")
                    myAuditSx.VLRCAMPOCLAVE = txtValor.Text;
                if (!chckBoxFecha.Checked)
                {
                    myInformacion = mySerAud.obtenerAuditoriaComp(myAuditSx);
                }
                else
                {
                    Funciones funciones = new Funciones();
                    if (dtPickFechaInicial.Value <= dtPickFechaFinal.Value)
                        myInformacion = mySerAud.obtenerAuditoriaFechaComp(myAuditSx, funciones.convFormatoFecha(dtPickFechaInicial.Text, "MM/dd/yyyy"), funciones.convFormatoFecha(dtPickFechaFinal.Text, "MM/dd/yyyy"));
                    else
                    {
                        MessageBox.Show("La fecha inicial no puede ser mayor a la final", "Fechas Inconsistentes");
                        chckBoxFecha.Checked = false;
                        return;
                    }
                }
                if (myInformacion != null && myInformacion.Length > 0)
                {
                    mostrarInformacion();
                }
                else
                {
                    dtGrdViewAuditorias.DataSource = null;
                    MessageBox.Show("Ningun registro corresponde a los criterios de busqueda", "No hay registros");
                }
            }
            catch (Exception exp)
            {
                WS.Funciones().mostrarMensaje("Error realizando la funcionalidad. " + exp.Message, "E");                
            }
        }

        private void mostrarInformacion()
        {
            Funciones funciones = new Funciones();
            DataTable dt = new DataTable();
            ArrayList Campos = new ArrayList();
            Campos.Add("CAMPOCLAVE = CAMPOPRINCIPAL");
            Campos.Add("TIPOPERACION = OPERACION");
            Campos.Add("ID_USUARIO = ID USUARIO MODIFICA");
            Campos.Add("FECHAOPERACION = FECHA");
            Campos.Add("HORAOPERACION = HORA");
            Campos.Add("TABLAAFECTADA = TABLA");
            Campos.Add("DESCRIPOPERACION = DESCRIPCION");
            Campos.Add("VLRCAMPOCLAVE = VALOR PRINCIPAL");
            Campos.Add("NOMBREEQUIPO = EQUIPO");
            Campos.Add("IP = DIR IP");
            try
            {
                dt = funciones.ToDataTable(funciones.ObjectToArrayList(myInformacion));
            }
            catch (Exception e) {
                log.escribirError(e.ToString(), this.GetType());
            }
            dtGrdViewAuditorias.DataSource = dt;
            if (dt.Rows.Count > 0)
                funciones.configurarGrilla(dtGrdViewAuditorias, Campos);
            dt = null;
            Campos = null;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                Funciones myFnc = new Funciones();
                saveFileDialog1.ShowDialog();
                if (saveFileDialog1.FileName != "")
                    myFnc.exportarDataGridViewAExcel(saveFileDialog1.FileName, "Reporte Auditoria", dtGrdViewAuditorias);
            }
            catch (Exception exp)
            {
                WS.Funciones().mostrarMensaje("Error realizando la funcionalidad. " + exp.Message, "E");                
            }
        }

        private void cmbBoxTabla_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones myFun = new Funciones();
            myFun.lanzarTapConEnter(e);
        }

        private void cmbBoxUsuarios_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones myFun = new Funciones();
            myFun.lanzarTapConEnter(e);
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones myFun = new Funciones();
            myFun.lanzarTapConEnter(e);
            myFun.esNumero(e);
        }

        private void dtPickFechaInicial_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones myFun = new Funciones();
            myFun.lanzarTapConEnter(e);
        }

        private void dtPickFechaFinal_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones myFun = new Funciones();
            myFun.lanzarTapConEnter(e);
        }

        private void chckBoxFecha_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones myFun = new Funciones();
            myFun.lanzarTapConEnter(e);
        }
    }
}
