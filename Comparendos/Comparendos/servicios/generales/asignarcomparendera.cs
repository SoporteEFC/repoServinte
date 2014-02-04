using System; using TransitoPrincipal; using LibreriasSintrat.utilidades;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibreriasSintrat.ServiciosGeneralesComp;
using LibreriasSintrat.ServiciosComparendos;
using LibreriasSintrat.ServiciosGenerales;
using LibreriasSintrat.ServiciosAccesoriasComp;
using Comparendos.utilidades; using LibreriasSintrat.utilidades; using LibreriasSintrat;
using TransitoPrincipal;

namespace Comparendos.servicios.generales
{
    public partial class asignarcomparendera : Form
    {
        ServiciosGeneralesCompService clienteGeneralesComp;
        ServiciosComparendosService clienteComparendos;

        rangosdeComparendosComp rangoComparendosTemp;
        agenteComp agenteTemp;
        
        Funciones funciones;
        Object[] listaasignadas = null;
        Log log = new Log();

        public asignarcomparendera()
        {
            InitializeComponent();
            funciones = new Funciones();
            log = new Log();
        }

        private void asignarcomparendera_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                cmbTipoComparendera.Items.Add("POLCA");
                cmbTipoComparendera.Items.Add("URBANA");

                grillacomparenderas.DataSource = null;

                clienteGeneralesComp = WS.ServiciosGeneralesCompService();
                clienteComparendos = WS.ServiciosComparendosService();                                

                buscarAsignadas();
                btnSearchAgente.Focus();
            }
            catch (Exception exp)
            {
                WS.Funciones().mostrarMensaje("Error ejecutando la función. " + exp.Message, "E");                                
            }            

            this.Cursor = Cursors.Arrow;            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Limpiar() 
        {
            txtPlacaAgente.Clear();
            txtNombreAgente.Clear();
            txtRangoComparendos.Clear();
            txtRangoInicial.Clear();
            txtRangoFinal.Clear();
            cmbTipoComparendera.SelectedIndex = -1;
            grillacomparenderas.DataSource = null;
        }

        private void btnSearchAgente_Click(object sender, EventArgs e)
        {
            try
            {
                agenteComp agen = new agenteComp();
                ArrayList Campos = new ArrayList();
                Campos.Add("PLACAAGENTE = PLACA");
                Campos.Add("NOMBRES = NOMBRES");
                Campos.Add("APELL1 = PRIMER APELLIDO");
                Campos.Add("APELL2 = SEGUNDO APELLIDO");

                Object[] Agentes = (Object[])clienteGeneralesComp.getAgentes(agen);
                if (Agentes != null)
                {
                    buscador buscador = new buscador(Agentes, Campos, null, null);

                    if (buscador.ShowDialog() == DialogResult.OK)
                    {
                        agenteTemp = (agenteComp)funciones.listToAgente(buscador.Seleccion);
                        txtPlacaAgente.Text = agenteTemp.PLACAAGENTE;
                        txtNombreAgente.Text = agenteTemp.NOMBRES + " " + agenteTemp.APELL1 + " " + agenteTemp.APELL2;                                                
                        cmbTipoComparendera.Focus();
                    }
                }
                else
                    WS.Funciones().mostrarMensaje("No se encontraron agentes.", "I");
            }
            catch (Exception exp)
            {
                WS.Funciones().mostrarMensaje("Error ejecutando la función. " + exp.Message, "E");                                
            }
        }        

        private void btnSearchrango_Click(object sender, EventArgs e)
        {            
            try
            {
                rangosdeComparendosComp rang = new rangosdeComparendosComp();
                ArrayList Camposr = new ArrayList();
                Camposr.Add("CANTIDADRANGOS = CANTIDAD");
                Camposr.Add("RANGOINICIAL = RANGO INICIAL");
                Camposr.Add("RANGOFINAL = RANGO FINAL");

                Object[] Rangos = (Object[])clienteComparendos.getRangosComparendos(rang);
                if (Rangos != null)
                {                                        
                    buscador buscadorr = new buscador(Rangos, Camposr, null, null);
                    if (buscadorr.ShowDialog() == DialogResult.OK)
                    {
                        rangoComparendosTemp = (rangosdeComparendosComp)funciones.listToRango(buscadorr.Seleccion);
                        txtRangoComparendos.Text = rangoComparendosTemp.RANGOINICIAL + " - " + rangoComparendosTemp.RANGOFINAL;                        
                        txtRangoInicial.Focus();
                    }
                }
                else
                    WS.Funciones().mostrarMensaje("No se encontraron rangos creados.", "I");
            }
            catch (Exception exp)
            {
                WS.Funciones().mostrarMensaje("Error ejecutando la función. " + exp.Message, "E");
            }
        }        

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (validaciones())
                {
                    comparenderas nuevacomparendera = new comparenderas();
                    nuevacomparendera.FECHAREGISTRO = funciones.convFormatoFecha(txtFechaRegistro.Text, "MM/dd/yyyy");
                    nuevacomparendera.ID_RANGOCOMPARENDOS = rangoComparendosTemp.ID_RANGOCOMPARENDO;
                    nuevacomparendera.IDAGENTE = agenteTemp.ID_AGENTE;
                    nuevacomparendera.IDESTADO = 1;
                    nuevacomparendera.RANGOFINAL = txtRangoFinal.Text;
                    nuevacomparendera.RANGOINICIAL = txtRangoInicial.Text;

                    if (cmbTipoComparendera.SelectedIndex == 0)
                    {
                        nuevacomparendera.TIPOCOMPARENDERA = "POLCA";
                    }
                    else if (cmbTipoComparendera.SelectedIndex == 1)
                    {
                        nuevacomparendera.TIPOCOMPARENDERA = "URBANA";
                    }

                    comparenderas inscomparendera = clienteComparendos.crearComparendera(nuevacomparendera, WS.MyUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName());
                    if (inscomparendera != null && inscomparendera.ID>0)
                    {
                        crearDetalle(inscomparendera);
                    }
                    else
                    {
                        MessageBox.Show("Error en registro");
                    }

                    buscarAsignadas();
                }
            }
            catch (Exception exp)
            {
                WS.Funciones().mostrarMensaje("Error ejecutando la función. " + exp.Message, "E");
            }            
        }

        private bool validaciones()
        {
            if(string.IsNullOrWhiteSpace(txtNombreAgente.Text))
            {
                MessageBox.Show("Debe seleccionar un agente");
                btnSearchAgente.Focus();
                return false;
            }
            
            if (cmbTipoComparendera.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un tipo de comparendera");
                cmbTipoComparendera.Focus();
                return false;
            }
            
            if (string.IsNullOrWhiteSpace(txtRangoComparendos.Text))
            {
                MessageBox.Show("Debe seleccionar un rango de comparendos");
                btnSearchrango.Focus();
                return false;
            }
            
            if(string.IsNullOrWhiteSpace(txtRangoInicial.Text))
            {
                MessageBox.Show("Debe ingresar un valor para el rango inicial");
                txtRangoInicial.Focus();
                return false;
            }
            
            if(string.IsNullOrWhiteSpace(txtRangoFinal.Text))
            {
                MessageBox.Show("Debe ingresar un valor para el rango final");
                txtRangoFinal.Focus();
                return false;
            }
            
            
            if (txtRangoInicial.Text.Length != 20)
            {
                MessageBox.Show("El rango inicial debe contener 20 caracteres.");
                txtRangoInicial.Focus();
                return false;
            }
            if (txtRangoFinal.Text.Length != 20)
            {
                MessageBox.Show("El rango final debe contener 20 caracteres.");
                txtRangoFinal.Focus();
                return false;
            }

            string rinicialActual = txtRangoInicial.Text;
            string rfinalActual = txtRangoFinal.Text;
            string rinicialComparendera = rangoComparendosTemp.RANGOINICIAL;
            string rfinalComparendera = rangoComparendosTemp.RANGOFINAL;


            if (!Funciones.menorOIgual(rinicialActual, rfinalActual))
            {
                MessageBox.Show("El rango inicial no puede ser superior al rango final");
                txtRangoInicial.Focus();
                return false;
            }

            if (!(Funciones.menorOIgual(rinicialComparendera, rinicialActual) && Funciones.menorOIgual(rinicialActual, rfinalComparendera)))
            {
                MessageBox.Show("El rango inicial ingresado se encuentra por fuera de los valores permitidos respecto al rango de comparendera seleccionado.");
                txtRangoInicial.Focus();
                return false;
            }

            if (!(Funciones.menorOIgual(rinicialComparendera, rfinalActual) && Funciones.menorOIgual(rfinalActual, rfinalComparendera)))
            {
                MessageBox.Show("El rango final ingresado se encuentra por fuera de los valores permitidos del rango de comparendera seleccionado");
                txtRangoFinal.Focus();
                return false;
            }

            if (!verificarConflictoRango())
            {
                //MessageBox.Show("El rango a asignar esta en conflicto con otro o ya ha sido asignado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            
            //else if (fecharegistro.Text != null)
            //{
            //    clienteGenerales = WS.ServiciosGeneralesService();
            //    //DateTime fecha1 = Convert.ToDateTime(clienteGenerales.getFechaServidor());
            //    DateTime fecha1 = Convert.ToDateTime(clienteAccesoriasComp.getFechaHora("dd/MM/yyyy hh:mm:ss"));
            //    DateTime fecha2 = Convert.ToDateTime(fecharegistro.Text);
            //    if (fecha1 < fecha2)
            //    {
            //        MessageBox.Show("La fecha de registro no puede ser superior a: " + clienteGenerales.getFechaServidor());
            //        fecharegistro.Focus();
            //    }
            //    else
            //    {
            //        DialogResult dialogResult = MessageBox.Show("¿Desea registrar la comparendera?", "Confirmación", MessageBoxButtons.YesNo);
            //        if (dialogResult == DialogResult.Yes)
            //        {
                        //guardarComparendera();
            //        }                    
            //    }
                //guardarComparendera();
            //}
            //else
            //{
            //    MessageBox.Show("Debe seleccionar una fecha de registro");
            //    fecharegistro.Focus();
            //}
            return true;
        }

        public bool verificarConflictoRango()
        {
            Object[] listaComparenderasTemp;
            viewComparenderas myViewComp;
            listaComparenderasTemp = (Object[])clienteComparendos.getTViewComparenderas();
            if (listaComparenderasTemp != null && listaComparenderasTemp.Length > 0)
            {
                Funciones myFnc = new Funciones();
                for(int i=0;i<listaComparenderasTemp.Length;i++)
                {
                    myViewComp=(viewComparenderas)listaComparenderasTemp[i];

                    //Verificar si el rango inicial o el final a insertar se encuentra en medio de otro rango anteriormente asignado
                    string rangoInicial = txtRangoInicial.Text;
                    string rangoFinal = txtRangoFinal.Text;
                    string rangoInicialTemp = myViewComp.ERANGOINICIAL;
                    string rangoFinalTemp = myViewComp.FRANGOFINAL;

                    if (
                            (Funciones.menorOIgual(rangoInicial, rangoInicialTemp) && Funciones.menorOIgual(rangoInicialTemp, rangoFinal)) ||
                            (Funciones.menorOIgual(rangoInicial, rangoFinalTemp) && Funciones.menorOIgual(rangoFinalTemp, rangoFinal)) ||
                            (Funciones.menorOIgual(rangoInicialTemp, rangoInicial) && Funciones.menorOIgual(rangoInicial, rangoFinalTemp))
                            )
                    {
                        funciones.mostrarMensaje("El rango a ingresar se interseca (o cruza) con el rango asignado al agente: " + myViewComp.ANOMBRES + " " + myViewComp.BAPELLIDO1 + ", el cual inicia en: " + myViewComp.ERANGOINICIAL + " y finaliza en: " + myViewComp.FRANGOFINAL + ".", "W");
                        txtRangoInicial.Focus();
                        return false;
                    }
                }
            }

            return true;
        }

        private void crearDetalle(comparenderas new_comparendera)
        {            
            int inserciones = 0;
            float cant = 0;
            String numcompa = "";
            cant = float.Parse(funciones.getnro(new_comparendera.RANGOFINAL, new_comparendera.RANGOINICIAL)) - float.Parse(funciones.getnro(new_comparendera.RANGOINICIAL, new_comparendera.RANGOFINAL));
            for (int d =0 ; d <= cant;d++ )
            {

                numcompa = funciones.incCadena(new_comparendera.RANGOINICIAL,d);
                
                detalleComparendera nuevodetalle = new detalleComparendera();
                nuevodetalle.ESTADOCOMP = "F";
                nuevodetalle.FECHAANULACION = "";
                nuevodetalle.HORAANULACION = "";
                nuevodetalle.ID_COMPARENDERA = new_comparendera.ID;
                nuevodetalle.ID_USUARIOANULA = 0;
                nuevodetalle.MOTIVOANULACION = "";
                
                if (numcompa.Length < 8)
                {
                    int tamnum = numcompa.Length-8;
                    String nit = "";
                    String minit = "";
                    String numcomp = "";
                    minit = numcompa.Substring(1, 8);                    
                    nit = clienteGeneralesComp.getNITTransito();

                    if (nit == minit)
                    {
                        numcomp = numcompa.Substring(9, tamnum);
                        nuevodetalle.NROCOMPARENDO = numcompa;
                        nuevodetalle.PREFIJOCOMPARENDERA = nit;
                    }
                    else
                    {
                        nuevodetalle.NROCOMPARENDO = numcompa;
                        nuevodetalle.PREFIJOCOMPARENDERA = "";
                    }
                }
                else
                {
                    nuevodetalle.NROCOMPARENDO = numcompa;
                    nuevodetalle.PREFIJOCOMPARENDERA = "";
                }

                Boolean insdetalle = clienteComparendos.crearDetalleComparendera(nuevodetalle, WS.MyUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName());
                if (insdetalle == true)
                {
                    inserciones++;
                }
            }

            if (inserciones > 0)
            {
                MessageBox.Show("Registro Exitoso");
            }
            else
            {
                MessageBox.Show("Error en el Registro");
            }
        }

        private void buscarAsignadas()
        {            
            //if (agenteTemp == null)
            //{
                listaasignadas = clienteComparendos.getTViewComparenderas();                
            //}
            //else
            //{
            //    viewComparenderas vistaasig=new viewComparenderas();
            //    vistaasig.IDAGENTE = agenteTemp.ID_AGENTE;
            //    listaasignadas = clienteComparendos.getSViewComparenderas(vistaasig);
            //}

            if (listaasignadas != null && listaasignadas.Length > 0)
            {                
                DataTable dt = new DataTable();
                ArrayList Campos = new ArrayList();
                Campos.Add("ANOMBRES = AGENTE");
                Campos.Add("BAPELLIDO1 = PRIMER APELLIDO");
                Campos.Add("CAPELLIDO2 = SEGUNDO APELLIDO");
                //Campos.Add("DESTADOCOMPARENDERA = ESTADO DE COMPARENDERA");
                Campos.Add("ERANGOINICIAL = RANGO INICIAL");
                Campos.Add("FRANGOFINAL = RANGO FINAL");
                try
                {
                    dt = funciones.ToDataTable(funciones.ObjectToArrayList(listaasignadas));
                }
                catch (Exception e)
                {
                    log.escribirError(e.ToString(), this.GetType());
                }
                grillacomparenderas.DataSource = dt;
                if (dt.Rows.Count > 0)
                    funciones.configurarGrilla(grillacomparenderas, Campos);                

                grillacomparenderas.Select();
            }
            else
            {
                grillacomparenderas.DataSource = null;
            }
        }


        #region Eventos KeyPress
            private void rangoinicial_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.esNumero(e);
                funciones.lanzarTapConEnter(e);
            }

            private void rangofinal_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.esNumero(e);
                funciones.lanzarTapConEnter(e);
            }

            private void tipocomparendera_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }

            private void fecharegistro_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }
        #endregion
    }
}
