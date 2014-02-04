using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibreriasSintrat.ServiciosErroresSW;
using LibreriasSintrat.ServiciosLogs;
using LibreriasSintrat.ServiciosUsuarios;
using LibreriasSintrat.utilidades;

namespace TransportePublico.utilidades
{
    public partial class FrmGestionErroresSW : Form
    {
        ServiciosErroresSWService serviciosErroresSW;
        ServiciosLogsService serviciosLogs;
        usuarios usuarioSistema;
        Funciones funciones;

        public FrmGestionErroresSW(usuarios user)
        {
            InitializeComponent();
            usuarioSistema = user;
            serviciosLogs = WS.ServiciosLogsService();
            serviciosErroresSW = WS.ServiciosErroresSWService();
            funciones = new Funciones();
        }

        public void consultarErrores(erroresSW error) 
        {
            LibreriasSintrat.ServiciosLogs.logs tmpLog = new LibreriasSintrat.ServiciosLogs.logs();
            tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
            tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
            tmpLog.OBJETO = "ERRORES_SW";
            tmpLog.MODULO = "TPUBLICO";
            tmpLog.TIPO_TRANSACCION = "SELECT";
            TimeSpan TS;
            DateTime dt1 = DateTime.Now;

            string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(error.GetType(), new object[] { error });
            tmpLog.ESTADO_ANTERIOR = objetoAnalizado;

            object[] listaErrores = serviciosErroresSW.buscarErroresSW(error);

            dgvResultado.DataSource = funciones.ToDataTable(funciones.ObjectToArrayList(listaErrores));

            DateTime dt2 = DateTime.Now;
            TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
            tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;
            serviciosLogs.crearRegistroLog(tmpLog);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            BuscarErroresSW();
        }

        private void BuscarErroresSW()
        {
            erroresSW error = new erroresSW();
            error.DESCRIPCION = txtDescripcion.Text;
            error.NOMBRE = txtNombre.Text;
            error.ERROR = txtExcepcion.Text;
            error.SUGERENCIA = txtSolucion.Text;
            consultarErrores(error);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataGridViewRow seleccion;
            seleccion = dgvResultado.CurrentRow;

            if (seleccion == null)
                MessageBox.Show("Para eliminar un registro primero debe seleccionarlo de la grilla resultados");
            else
            {
                FrmMostrarErrorSW frm = new FrmMostrarErrorSW(usuarioSistema, false, "", int.Parse(seleccion.Cells["ID_ERRORES_SW"].Value.ToString()));
                frm.ShowDialog();
            }
            BuscarErroresSW();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FrmMostrarErrorSW frm = new FrmMostrarErrorSW(usuarioSistema,true,"",-1);
            frm.ShowDialog(); 
            BuscarErroresSW();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataGridViewRow seleccion;
            seleccion = dgvResultado.CurrentRow;

            if (seleccion == null)
                MessageBox.Show("Para editar un registro primero debe seleccionarlo de la grilla resultados");
            else
            {
                FrmMostrarErrorSW frm = new FrmMostrarErrorSW(usuarioSistema, true, "", int.Parse(seleccion.Cells["ID_ERRORES_SW"].Value.ToString()));
                frm.ShowDialog();
            }
            BuscarErroresSW();
        }

        private void btnVistaPrevia_Click(object sender, EventArgs e)
        {
        }
    }
}
