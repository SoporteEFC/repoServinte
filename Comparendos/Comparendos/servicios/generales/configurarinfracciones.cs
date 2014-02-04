using System; using TransitoPrincipal; using LibreriasSintrat.utilidades;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibreriasSintrat.ServiciosAccesoriasComp;
using Comparendos.utilidades; using LibreriasSintrat.utilidades; using LibreriasSintrat;
using LibreriasSintrat.utilidades;

namespace Comparendos.servicios.generales
{
    public partial class configurarinfracciones : Form
    {
        ServiciosAccesoriasCompService clienteAccesoriasComp;
        
        Object[] listainfracciones = null;
        infraccionesComp infraccionseleccionada = new infraccionesComp();
        
        Funciones funciones = new Funciones();
        Log log = new Log();

        
        public configurarinfracciones()
        {
            InitializeComponent();
            log = new Log();
        }

        private void configurarinfracciones_Load(object sender, EventArgs e)
        {
            cargarInfraccionesGrilla();
        }


        public void cargarInfraccionesGrilla()
        {
            clienteAccesoriasComp = WS.ServiciosAccesoriasCompService();
            listainfracciones = clienteAccesoriasComp.listarInfraccionesComp();
            if (listainfracciones != null && listainfracciones.Length >= 0)
            {
                mostrarInfracciones();
                btnDel.Enabled = true;
                btnEdit.Enabled = true;
            }
            else
            {
                MessageBox.Show("No se encontraron infracciones");
                grillainfracciones.DataSource = null;
                btnDel.Enabled = false;
                btnEdit.Enabled = false;
            }
        }

        public void cargarInfraccionesGrilla2()
        {
            if (listainfracciones != null && listainfracciones.Length >= 0)
            {
                mostrarInfracciones();
                btnDel.Enabled = true;
                btnEdit.Enabled = true;
            }
            else
            {
                MessageBox.Show("No se encontraron infracciones");
                grillainfracciones.DataSource = null;
                btnDel.Enabled = false;
                btnEdit.Enabled = false;
            }
        }        

        public void mostrarInfracciones()
        {
            Funciones funciones = new Funciones();
            DataTable dt = new DataTable();
            ArrayList Campos = new ArrayList();
            Campos.Add("COD_INFRACCION = CÓDIGO");
            Campos.Add("DESCRIPCION = DESCRIPCION");
            Campos.Add("ESTADO = ESTADO");
            Campos.Add("FECHADESDE = DESDE");
            Campos.Add("FECHAHASTA = HASTA");
            Campos.Add("NUEVO_CODIGO = NUEVO CODIGO");
            Campos.Add("NUMEROSALARIO = NUMERO SALARIO");
            Campos.Add("REPORTARSIMIT = REPORTAR SIMIT");
            try
            {
                dt = funciones.ToDataTable(funciones.ObjectToArrayList(listainfracciones));
            }
            catch (Exception e) {
                log.escribirError(e.ToString(), this.GetType());
            }
            grillainfracciones.DataSource = dt;
            if (dt.Rows.Count > 0)
                funciones.configurarGrilla(grillainfracciones, Campos);
            dt = null;
            Campos = null;

            grillainfracciones.Select();
        }

        private void elimiminarInfraccion()
        {
            if (infraccionseleccionada != null)
            {
                clienteAccesoriasComp = WS.ServiciosAccesoriasCompService();
                Boolean delinfraccion = clienteAccesoriasComp.eliminarInfraccionesComp(infraccionseleccionada);

                if (delinfraccion == true)
                {
                    MessageBox.Show("Eliminación Exitosa");
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al eliminar la Infracción");
                }
            }
            cargarInfraccionesGrilla();
        }

        private void grillainfracciones_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (grillainfracciones.CurrentRow != null)
                {
                    infraccionseleccionada = (infraccionesComp)listainfracciones[grillainfracciones.CurrentRow.Index];
                }
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                funciones.mostrarMensaje("Ocurrió un error al realizar la funcionalidad: " + exp.Message, "E");
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                infraccion infracc = new infraccion(0);
                if (infracc.ShowDialog() == DialogResult.OK)
                {
                    cargarInfraccionesGrilla();
                }
                cargarInfraccionesGrilla();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                funciones.mostrarMensaje("Ocurrió un error al realizar la funcionalidad: " + exp.Message, "E");
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }        

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (infraccionseleccionada != null)
                {
                    infraccion infracc = new infraccion(infraccionseleccionada.ID_INFRACCION);
                    infracc.llenarCampos(infraccionseleccionada);
                    infracc.ShowDialog();

                    //Actualizar infracciones
                    this.Cursor = Cursors.WaitCursor;
                    cargarInfraccionesGrilla();
                    this.Cursor = Cursors.Arrow;
                }
                else
                {
                    MessageBox.Show("No existen infracciones seleccionadas.");
                }                               
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                funciones.mostrarMensaje("Ocurrió un error al realizar la funcionalidad: " + exp.Message, "E");
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }        

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (listainfracciones != null)
                {
                    ArrayList alCampos = new ArrayList();
                    alCampos.Add("COD_INFRACCION = Codigo");
                    alCampos.Add("DESCRIPCION = Descripcion");
                    alCampos.Add("FECHADESDE = Fecha Desde");
                    alCampos.Add("FECHAHASTA = Fecha Hasta");
                    alCampos.Add("NUEVO_CODIGO = Nuevo Codigo");
                    alCampos.Add("NUMEROSALARIO = Salarios");
                    alCampos.Add("REPORTARSIMIT = Reportar Simit");

                    buscador frmBuscador = new buscador(listainfracciones, alCampos, "Buscador de infracciones", null);

                    if (frmBuscador.ShowDialog() == DialogResult.OK)
                    {
                        if (frmBuscador.Seleccion != null)
                        {
                            listainfracciones = null;
                            listainfracciones = new Object[1];
                            infraccionesComp infraConsulta = new infraccionesComp();
                            infraConsulta = (infraccionesComp)funciones.listToInfraccion(frmBuscador.Seleccion);
                            listainfracciones[0] = infraConsulta;
                            cargarInfraccionesGrilla2();
                        }
                        else
                        {
                            MessageBox.Show("Debe seleccionar un registro del resultado de la busqueda.");
                        }
                    }

                    frmBuscador.Dispose();
                }
                else
                {
                    MessageBox.Show("No existen datos registrados en la base de datos");
                }
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                funciones.mostrarMensaje("Ocurrió un error al realizar la funcionalidad: " + exp.Message, "E");
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                cargarInfraccionesGrilla();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                funciones.mostrarMensaje("Ocurrió un error al realizar la funcionalidad: " + exp.Message, "E");
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(this, "Confirmar operación", "Realmente Desea", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    elimiminarInfraccion();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                funciones.mostrarMensaje("Ocurrió un error al realizar la funcionalidad: " + exp.Message, "E");
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
