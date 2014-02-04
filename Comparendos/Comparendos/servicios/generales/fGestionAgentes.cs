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
using LibreriasSintrat.ServiciosGeneralesComp;
using Comparendos.utilidades; 
using LibreriasSintrat;


namespace Comparendos.servicios.generales
{
    public partial class fGestionAgentes : Form
    {
        ServiciosAccesoriasCompService serviciosAccesorias;
        ServiciosGeneralesCompService serviciosGenerales;
        Funciones funciones;
        agenteComp newagen;
        
        Object[] listaAgentes;
        Object[] myTransito;

        agenteComp agente;
        Boolean nuevo;
        Log log = new Log();
        int posicionActual;

        public fGestionAgentes(ServiciosAccesoriasCompService srv)
        {
            InitializeComponent();
            
            serviciosAccesorias = srv;
            serviciosGenerales = WS.ServiciosGeneralesCompService();
            
            funciones = new Funciones();
            agente = new agenteComp();

            llenarCombos();

            myTransito = (Object[])serviciosAccesorias.ListarOrganismoTransitoComp();

            listaAgentes = (Object[])serviciosGenerales.getAgentes(null);
            posicionActual = 0;
            mostrarDatosAgenteActual();
            
            nuevo = false;
            
            habilitarCampos(false);
            log = new Log();
        }

        private void llenarCombos()
        {
            funciones.llenarCombo(cmbTipoDoc,serviciosAccesorias.obtenerTiposDocumento());
            funciones.llenarCombo(cmbTransito, serviciosAccesorias.ListarOrganismoTransitoComp());
        }

        private void mostrarDatosAgenteActual()
        {
            if (listaAgentes != null && posicionActual<listaAgentes.Length)
            {                
                agente = (agenteComp)listaAgentes[posicionActual];
                                
                funciones.setCombo(cmbTipoDoc, int.Parse(agente.ID_DOCTO.ToString()));                                    

                if (!String.IsNullOrEmpty(agente.PLACAAGENTE))
                    txtPlaca.Text = agente.PLACAAGENTE.ToString();
                else
                    txtPlaca.Text = "";


                if (!String.IsNullOrEmpty(agente.NOMBRES))
                    txtNombres.Text = agente.NOMBRES.ToString();
                else
                    txtNombres.Text = "";


                if (!String.IsNullOrEmpty(agente.NROIDENTIFICACION))
                    txtNroIdentificacion.Text = agente.NROIDENTIFICACION.ToString();
                else
                    txtNroIdentificacion.Text = "";

                if (!String.IsNullOrEmpty(agente.APELL1))
                    txtPrimerApellido.Text = agente.APELL1.ToString();
                else
                    txtPrimerApellido.Text = "";

                if (!String.IsNullOrEmpty(agente.APELL2))
                    txtSegundoApellido.Text = agente.APELL2.ToString();
                else
                    txtSegundoApellido.Text = "";
                
                funciones.setCombo(cmbTransito, int.Parse(agente.ID_ORGDETRANSITO.ToString()));                
            }
        }

        private void limpiarDatos()
        {
            txtPlaca.Clear();
            cmbTipoDoc.SelectedIndex = -1;
            txtNroIdentificacion.Clear();
            txtNombres.Clear();
            txtPrimerApellido.Clear();
            txtSegundoApellido.Clear();
            cmbTransito.SelectedIndex = -1;
        }

        private void habilitarControles(Boolean estado)
        {
            btnAdd.Enabled = estado;
            btnEditar.Enabled = estado;
            btnDelete.Enabled = estado;

            btnRefresh.Enabled = estado;

            btnFirst.Enabled = estado;
            btnLast.Enabled = estado;
            btnNext.Enabled = estado;
            btnPrevious.Enabled = estado;
        }

        private void habilitarCampos(bool estado)
        {
            cmbTipoDoc.Enabled = estado;
            txtNombres.Enabled = estado;
            txtNroIdentificacion.Enabled = estado;
            txtPrimerApellido.Enabled = estado;
            txtSegundoApellido.Enabled = estado;
            cmbTransito.Enabled = estado;

            btnPost.Enabled = estado;
            btnCancelar.Enabled = estado;
        }

        #region Botones de Navegación

            private void btnFirst_Click(object sender, EventArgs e)
            {
                try
                {
                    posicionActual = 0;
                    mostrarDatosAgenteActual();
                    //btnPrevious.Enabled = false;
                    //btnNext.Enabled = true;
                }
                catch (Exception exp)
                {
                    log.escribirError(exp.ToString(), this.GetType());
                    WS.Funciones().mostrarMensaje("Error ejecutando la función. " + exp.Message, "E");                    
                }
                
            }

            private void btnLast_Click(object sender, EventArgs e)
            {
                try
                {
                    if (listaAgentes != null)
                    {
                        posicionActual = listaAgentes.Length - 1;
                        mostrarDatosAgenteActual();
                        //btnNext.Enabled = false;
                        //btnPrevious.Enabled = true;
                    }
                }
                catch (Exception exp)
                {
                    log.escribirError(exp.ToString(), this.GetType());
                    WS.Funciones().mostrarMensaje("Error ejecutando la función. " + exp.Message, "E");
                    //Console.WriteLine(exp.Message);
                    //Console.WriteLine(exp.StackTrace);
                }
            }            

            private void btnPrevious_Click(object sender, EventArgs e)
            {
                try
                {
                    if (posicionActual > 0)
                    {
                        posicionActual--;
                        mostrarDatosAgenteActual();
                        //btnNext.Enabled = true;
                        //btnFirst.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Se encuentra en el primer registro, no hay registros anteriores", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //btnPrevious.Enabled = false;
                    }                    
                }
                catch (Exception exp)
                {
                    log.escribirError(exp.ToString(), this.GetType());
                    WS.Funciones().mostrarMensaje("Error ejecutando la función. " + exp.Message, "E");
                    //Console.WriteLine(exp.Message);
                    //Console.WriteLine(exp.StackTrace);
                }                
            }

            private void btnNext_Click(object sender, EventArgs e)
            {
                try
                {
                    if (listaAgentes != null && (posicionActual < listaAgentes.Length - 1))                    
                    {
                        posicionActual++;
                        mostrarDatosAgenteActual();
                        //btnPrevious.Enabled = true;
                        //btnLast.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Se encuentra en el ultimo registro, no hay registros posteriores", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //btnNext.Enabled = false;
                    }
                }
                catch (Exception exp)
                {
                    log.escribirError(exp.ToString(), this.GetType());
                    WS.Funciones().mostrarMensaje("Error ejecutando la función. " + exp.Message, "E");
                }
            }

        #endregion


        private void btnAdd_Click(object sender, EventArgs e)
        {
            limpiarDatos();            
            habilitarControles(false);
            habilitarCampos(true);
            
            nuevo = true;            
        }        

        private int buscarOT()
        {
            int res = 0;
            ArrayList Campos = new ArrayList();
            Campos.Add("NIT = NIT");
            Campos.Add("NOMBRESECRETARIA = NOMBRE OT");
            if (myTransito != null)
            {
                buscador buscadorr = new buscador(myTransito, Campos, null, null);
                funciones = new Funciones();

                if (buscadorr.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        res = int.Parse(buscadorr.Seleccion.Cells["IDORGTRANSITO"].Value.ToString());
                    }
                    catch(Exception exp) {
                        log.escribirError(exp.ToString(), this.GetType());
                    }
                }
            }
            return res;
        }

        public void buscarAgente()
        {
            serviciosGenerales = WS.ServiciosGeneralesCompService();
            agenteComp agen = new agenteComp();
            ArrayList Campos = new ArrayList();
            Campos.Add("PLACAAGENTE = PLACA");
            Campos.Add("NOMBRES = NOMBRES");
            Campos.Add("APELL1 = PRIMER APELLIDO");
            Campos.Add("APELL2 = SEGUNDO APELLIDO");
            Object[] Agentes = (Object[])serviciosGenerales.getAgentes(agen);
            if (Agentes != null)
            {
                buscador buscador = new buscador(Agentes, Campos, null, null);
                funciones = new Funciones();

                if (buscador.ShowDialog() == DialogResult.OK)
                {
                    newagen = (agenteComp)funciones.listToAgente(buscador.Seleccion);
                    txtPlaca.Text = newagen.PLACAAGENTE;
                    txtNombres.Text = newagen.NOMBRES;
                    txtPrimerApellido.Text = newagen.APELL1;
                    txtSegundoApellido.Text = newagen.APELL2;
                    txtNroIdentificacion.Text = newagen.NROIDENTIFICACION;
                    funciones.setCombo(cmbTransito, int.Parse(agente.ID_ORGDETRANSITO.ToString()));
                    funciones.setCombo(cmbTipoDoc, int.Parse(agente.ID_DOCTO.ToString()));
                }
            }
        }

        private Boolean validarDatos()
        {
           
            if (txtNombres.Text.Trim() == "")
            {
                funciones.mostrarMensaje("Debe digitar el nombre", "E");
                txtNombres.Focus();
                return false;
            }
            if (txtNroIdentificacion.Text.Trim() == "")
            {
                funciones.mostrarMensaje("Debe digitar el numero de identificación", "E");
                txtNroIdentificacion.Focus();
                return false;
            }
            if (txtPlaca.Text.Trim() == "")
            {
                funciones.mostrarMensaje("Debe digitar la placa", "E");
                txtPlaca.Focus();
                return false;
            }
            if (txtPrimerApellido.Text.Trim() == "")
            {
                funciones.mostrarMensaje("Debe digitar el primer apellido", "E");
                txtPrimerApellido.Focus();
                return false;
            }
            if (cmbTipoDoc.SelectedIndex == -1)
            {                
                funciones.mostrarMensaje("Debe seleccionar un tipo de documento", "E");
                cmbTipoDoc.Focus();
                return false;
            }
            if (cmbTransito.SelectedIndex == -1)
            {
                funciones.mostrarMensaje("Debe seleccionar un Organismo de Transito", "E");
                cmbTransito.Focus();
                return false;
            }
            return true;
        }        

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                listaAgentes = serviciosGenerales.getAgentes(null);
                posicionActual = 0;
                limpiarDatos();
                mostrarDatosAgenteActual();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                WS.Funciones().mostrarMensaje("Error ejecutando la función. " + exp.Message, "E");
            }            
        }

        private void btnSearchTransito_Click(object sender, EventArgs e)
        {
            funciones.setCombo(cmbTransito, buscarOT());
        }

        private void btnSearchPlaca_Click(object sender, EventArgs e)
        {
            buscarAgente();
        }        

        private void btnPost_Click(object sender, EventArgs e)
        {
            try
            {
                if (validarDatos())
                {
                    if (nuevo)
                    {
                        agenteComp agenteTmp = new agenteComp();
                        agenteTmp.APELL1 = txtPrimerApellido.Text;
                        if (txtPrimerApellido.Text != null && !txtPrimerApellido.Text.Equals(""))
                        {
                            agenteTmp.APELL2 = txtSegundoApellido.Text;
                        }
                        else
                        {
                            agenteTmp.APELL2 = "";
                        }
                        agenteTmp.ID_DOCTO = int.Parse(cmbTipoDoc.SelectedValue.ToString());
                        agenteTmp.ID_ORGDETRANSITO = int.Parse(cmbTransito.SelectedValue.ToString());
                        agenteTmp.NOMBRES = txtNombres.Text;
                        agenteTmp.NROIDENTIFICACION = txtNroIdentificacion.Text;
                        agenteTmp.PLACAAGENTE = txtPlaca.Text;

                        if (!serviciosGenerales.crearAgenteTto(agenteTmp))
                            funciones.mostrarMensaje("No fue posible agregar el registro. Verifique que no haya otro agente con el mismo número de placa o identificación.", "E");
                        else
                        {
                            MessageBox.Show("El agente de placa " + agenteTmp.PLACAAGENTE + " fue guardado exitosamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            

                            //Actualizar Datos Interfaz
                            listaAgentes = serviciosGenerales.getAgentes(null);
                            if(listaAgentes!=null) posicionActual = listaAgentes.Length-1;                            
                        }
                    }
                    else
                    {
                        if (listaAgentes!=null)
                        {
                            agente = (agenteComp)listaAgentes[posicionActual];
                            
                            agente.APELL1 = txtPrimerApellido.Text;
                            agente.APELL2 = txtSegundoApellido.Text;
                            agente.ID_DOCTO = int.Parse(cmbTipoDoc.SelectedValue.ToString());
                            agente.ID_ORGDETRANSITO = int.Parse(cmbTransito.SelectedValue.ToString());
                            agente.NOMBRES = txtNombres.Text;
                            agente.NROIDENTIFICACION = txtNroIdentificacion.Text;
                            agente.PLACAAGENTE = txtPlaca.Text;

                            if (!serviciosGenerales.actualizarAgenteTto(agente))
                                funciones.mostrarMensaje("No fue posible actualizar el registro. Verifique que no haya otro agente con el mismo número de placa e identificación.", "E");
                            else
                                MessageBox.Show("El agente de placa " + agente.PLACAAGENTE + " fue actualizado exitosamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            listaAgentes = serviciosGenerales.getAgentes(null);
                        }                        
                    }
                    
                    limpiarDatos();
                    mostrarDatosAgenteActual();

                    habilitarCampos(false);
                    habilitarControles(true);
                }
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                WS.Funciones().mostrarMensaje("Error ejecutando la función. " + exp.Message, "E");
            }
        }        

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                habilitarCampos(true);
                habilitarControles(false);

                nuevo = false;
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                WS.Funciones().mostrarMensaje("Error ejecutando la función. " + exp.Message, "E");
            } 
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                habilitarCampos(false);
                habilitarControles(true);
                mostrarDatosAgenteActual();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                WS.Funciones().mostrarMensaje("Error ejecutando la función. " + exp.Message, "E");
            }            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }


        #region Eventos KEYPRESS
            private void txtNroIdentificacion_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.esNumero(e);
                funciones.lanzarTapConEnter(e);
            }

            private void txtNombres_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.esAlfanumerico(e);
                funciones.lanzarTapConEnter(e);
            }

            private void txtPrimerApellido_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.esAlfanumerico(e);
                funciones.lanzarTapConEnter(e);
            }

            private void txtSegundoApellido_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.esAlfanumerico(e);
                funciones.lanzarTapConEnter(e);
            }

            private void cmbTipoDoc_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }

            private void cmbTransito_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }
        #endregion            

            private void txtPlaca_KeyPress(object sender, KeyPressEventArgs e)
            {
                Funciones myFun = new Funciones();
                myFun.esAlfanumerico(e);
            }

            private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (Char.IsDigit(e.KeyChar) || Char.IsLetter(e.KeyChar) || (e.KeyChar == '\b'))
                    MessageBox.Show("Aja");
            }
    }
}