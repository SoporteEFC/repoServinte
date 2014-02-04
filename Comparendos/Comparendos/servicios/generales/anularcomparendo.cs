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
using LibreriasSintrat.ServiciosUsuarios;
using LibreriasSintrat.ServiciosGeneralesComp;
using LibreriasSintrat.ServiciosComparendos;
using Comparendos.utilidades; using LibreriasSintrat.utilidades; using LibreriasSintrat;



namespace Comparendos.servicios.generales
{
    public partial class anularcomparendo : Form
    {
        ServiciosAccesoriasCompService clienteAccesoriasComp;
        ServiciosGeneralesCompService clienteGeneralesComp;
        Object[] myComparendos;
        usuarios myusu = new usuarios();
        Funciones myFnc;
        infractorComp myInfractor;
        Log log = new Log();

        public anularcomparendo(usuarios usuari,ServiciosAccesoriasCompService serAcc)
        {
            InitializeComponent();
            clienteGeneralesComp = WS.ServiciosGeneralesCompService();
            myusu = usuari;
            myFnc = new Funciones();
            clienteAccesoriasComp = serAcc;
            btnSave.Enabled = false;
            log = new Log();
        }

        private void numerocomparendo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones funciones = new Funciones();
            funciones.esNumero(e);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows != null && dataGridView1.SelectedRows.Count>0)
            {
                if (!txtNumResolucionMotivo.Text.Equals(""))
                {
                    viewComparendosInfractor myViewCompa;
                    DataGridViewSelectedRowCollection mySeleccionados = dataGridView1.SelectedRows;
                    historicoEstadosComp myHistorico;
                    infracionComparendoComp myInfracComp;
                    bool anulo = false;
                    for (int i = 0; i < mySeleccionados.Count; i++)
                    {
                        myViewCompa = (viewComparendosInfractor)myFnc.listToViewComparInfractor(mySeleccionados[i]);
                        myInfracComp = new infracionComparendoComp();
                        myInfracComp.IDCOMPARENDO = myViewCompa.IDCOMPARENDO;
                        myInfracComp = clienteGeneralesComp.getInfraccionComparendo(myInfracComp);
                        if (myInfracComp != null && myInfracComp.ID > 0)
                        {
                            /*if (myInfracComp.IDESTADO != 15)
                            {
                                myHistorico = new historicoEstadosComp();
                                myHistorico.ID_ESTADO = 15;
                                myHistorico.DESCRIPCION = txtNumResolucionMotivo.Text;                                
                                myHistorico.FECHA = funciones.convFormatoFecha(dtpFecha.Text, "MM/dd/yyyy");
                                myHistorico.ID_INFRACCIONCOMPARENDO = myInfracComp.ID;
                                myHistorico.IDUSUARIO = myusu.ID_USUARIO;
                                clienteGeneralesComp.insertarHistoricoEstadosComp(myHistorico);
                                myInfracComp.IDESTADO = 15;
                                clienteGeneralesComp.cambiarEstadoComp(myInfracComp, myusu.ID_USUARIO, myFnc.obtenerDirIp(), myFnc.obtenerHostName());
                                myInfracComp = new infracionComparendoComp();
                                myInfracComp.IDCOMPARENDO = myViewCompa.IDCOMPARENDO;
                                myInfracComp = clienteGeneralesComp.getInfraccionComparendo(myInfracComp);
                                if (myInfracComp != null && myInfracComp.ID > 0)
                                {
                                    if (myInfracComp.IDESTADO == 15)
                                    {
                                        MessageBox.Show("Anulación Exitosa", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                        anulo = true;
                                    }
                                }                                
                            }
                            else
                                {
                                    MessageBox.Show("El comparendo numero: " + myViewCompa.ANUMEROCOMPARENDO + " ya esta en estado anulado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                             */

                            //changeState

                            if (myInfracComp.IDESTADO != 3)
                            {
                                myHistorico = new historicoEstadosComp();
                                myHistorico.ID_ESTADO = 3;
                                myHistorico.DESCRIPCION = txtNumResolucionMotivo.Text;
                                Funciones funciones = new LibreriasSintrat.utilidades.Funciones();
                                myHistorico.FECHA = funciones.convFormatoFecha(dtpFecha.Text, "MM/dd/yyyy");
                                myHistorico.ID_INFRACCIONCOMPARENDO = myInfracComp.ID;
                                myHistorico.IDUSUARIO = myusu.ID_USUARIO;
                                clienteGeneralesComp.insertarHistoricoEstadosComp(myHistorico);
                                myInfracComp.IDESTADO = 3;
                                clienteGeneralesComp.cambiarEstadoComp(myInfracComp, myusu.ID_USUARIO, myFnc.obtenerDirIp(), myFnc.obtenerHostName());
                                myInfracComp = new infracionComparendoComp();
                                myInfracComp.IDCOMPARENDO = myViewCompa.IDCOMPARENDO;
                                myInfracComp = clienteGeneralesComp.getInfraccionComparendo(myInfracComp);
                                if (myInfracComp != null && myInfracComp.ID > 0)
                                {
                                    if (myInfracComp.IDESTADO == 3)
                                    {
                                        MessageBox.Show("Anulación Exitosa", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                        anulo = true;
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("El comparendo numero: " + myViewCompa.ANUMEROCOMPARENDO + " ya esta en estado anulado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }

                            //endChangeState
                        }
                    }
                    if (anulo)
                    {
                        cargarComparendosInfractor();
                    }
                }
                else
                {
                    MessageBox.Show("Debe ingresar un motivo o numero de resolucion", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtNumResolucionMotivo.Focus();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar uno o mas comparendos, recuerde hacerlo sobre el borde izquierdo", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtNumDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            myFnc.esNumero(e);
        }

        private void buscarInfractor()
        {
            myInfractor = new infractorComp();
            myInfractor.ID_DOCTO = (int)cmbTipoIdentificacion.SelectedValue;
            myInfractor.NROIDENTIFICACION = txtNumDocumento.Text;
            myInfractor = clienteGeneralesComp.buscarInfractor(myInfractor);
            if (myInfractor == null)
                MessageBox.Show("Verifique la informacion ingresada!!!", "Infractor no encontrado");
            else
            {
                mostrarInfoInfractor();
                cargarComparendosInfractor();
                txtNumResolucionMotivo.Focus();
            }
        }

        private void cargarComparendosInfractor()
        {
            ServiciosComparendosService mySerComp = WS.ServiciosComparendosService();
            viewComparendosInfractor myViewCompa = new viewComparendosInfractor();
            myViewCompa.CIDENTIFICACION = myInfractor.NROIDENTIFICACION;
            myComparendos = mySerComp.getSViewComparendosInfractor(myViewCompa);
            if (myComparendos != null)
            {
                eliminarAnulados();
                mostrarComparendos();
                btnSave.Enabled = true;
            }
            else
            {
                MessageBox.Show("No existen comparendos que se puedan anular para este infractor", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = null;
                btnSave.Enabled = false;
            }
        }

        void eliminarAnulados()
        {
            viewComparendosInfractor myViewCompa;
            infracionComparendoComp myInfracComp;
            Object[] tmp=null;
            Object[] aux;
            for (int i = 0; i < myComparendos.Length; i++)
            {
                myViewCompa = (viewComparendosInfractor)myComparendos[i];
                myInfracComp = new infracionComparendoComp();
                myInfracComp.IDCOMPARENDO = myViewCompa.IDCOMPARENDO;
                myInfracComp = clienteGeneralesComp.getInfraccionComparendo(myInfracComp);

                /*
                if (myInfracComp!=null&&myInfracComp.IDESTADO != 15)
                {
                    aux = new Object[1];
                    aux[0] = myViewCompa;
                    tmp=myFnc.unirArrayObject(tmp,aux);
                }
                */

                //changeState

                if (myInfracComp != null && myInfracComp.IDESTADO != 3)
                {
                    aux = new Object[1];
                    aux[0] = myViewCompa;
                    tmp = myFnc.unirArrayObject(tmp, aux);
                }

                //endChangeState
            }

            myComparendos = tmp;
        }

        private void mostrarComparendos()
        {
            DataTable dt = new DataTable();
            ArrayList Campos = new ArrayList();
            Funciones funciones = new Funciones();
            Campos.Add("ANUMEROCOMPARENDO = NUMERO COMPARENDO");
            Campos.Add("BFECHACOMPARENDO = FECHA");
            Campos.Add("DNOMBRESINFRACTOR = NOMBRES");
            Campos.Add("EAPELLIDINFRACTOR = APELLIDOS APELLIDOS");
            try
            {
                dt = funciones.ToDataTable(funciones.ObjectToArrayList(myComparendos));
            }
            catch (Exception e) {
                log.escribirError(e.ToString(), this.GetType());
            }
            dataGridView1.DataSource = dt;
            if (dt.Rows.Count > 0)
                funciones.configurarGrilla(dataGridView1, Campos);
            dt = null;
            Campos = null;
        }

        private void mostrarInfoInfractor()
        {
            txtNombre.Text = myInfractor.NOMBRES;
            txtApellido.Text = myInfractor.APELLIDOS;
            txtDireccion.Text = myInfractor.DIRECCION;
            txtTelefono.Text = myInfractor.TELEFONO;
        }

        private void anularcomparendo_Load(object sender, EventArgs e)
        {
            cargarCombos();
            cmbTipoIdentificacion.Focus();
        }

        private void cargarCombos()
        {
            myFnc.llenarCombo(cmbTipoIdentificacion, clienteAccesoriasComp.obtenerTiposDocumento());
        }

        private void txtNumDocumento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cmbTipoIdentificacion.SelectedIndex > -1)
                {
                    if (txtNumDocumento.Text != "")
                        buscarInfractor();
                    else
                        MessageBox.Show("Debe ingresar el documento del infractor", "Informacion faltante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("Debe seleccionar el tipo de documento del infractor", "Informacion faltante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        void dataGridView1_Click(object sender, System.EventArgs e)
        {

        }

        private void cmbTipoIdentificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones myFun = new Funciones();
            myFun.lanzarTapConEnter(e);
        }

        private void txtNumResolucionMotivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones myFun = new Funciones();
            myFun.lanzarTapConEnter(e);
        }

        private void dtpFecha_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones myFun = new Funciones();
            myFun.lanzarTapConEnter(e);
        }
    }
}
