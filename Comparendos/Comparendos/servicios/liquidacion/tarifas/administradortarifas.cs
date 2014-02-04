using System; using TransitoPrincipal; using LibreriasSintrat.utilidades;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibreriasSintrat.ServiciosTarifas;
using LibreriasSintrat.ServiciosAccesorias;
using LibreriasSintrat.ServiciosComparendos;
using LibreriasSintrat.ServiciosTarifasComp;
using LibreriasSintrat.ServiciosUsuarios;
using System.Web.UI.WebControls;

namespace Comparendos
{
    public partial class administradortarifas : Form
    {
        usuarios myUsuario;
        
        ServiciosTarifasService clienteTarifas;        
        ServiciosComparendosService clienteComparendos;
        ServiciosTarifasCompService clienteTarifasComp;

        Funciones funciones;
                      
        bool editarConcepto = false;

        Object[] listaVigencias = null;
        Object[] listaTarifasComp = null;
        Object[] listaConceptos = null;               

        public administradortarifas(usuarios user)
        {
            myUsuario = user;
            
            InitializeComponent();
        
            clienteTarifasComp = WS.ServiciosTarifasCompService();
            clienteTarifas = WS.ServiciosTarifasService();
            clienteComparendos = WS.ServiciosComparendosService();            

            funciones = new Funciones();

        }

        private void administradortarifas_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {                                
                llenarCombos();                                
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }            
            this.Cursor = Cursors.Arrow;
        }

        private void llenarCombos()
        {
            //Tipo tarifa
            cmbTipoTarifa.Items.Add(new ListItem("IMPUESTO", "1"));
            cmbTipoTarifa.Items.Add(new ListItem("TRAMITE", "2"));
            
            //Vigencias
            actualizarComboVigencias();            

            //LLENAR COMBO DE TRÁMITES
            tramiteContravencionalComp sTramiteComp = new tramiteContravencionalComp();
            Object[] slistatramitesComp = (Object[])clienteTarifasComp.getTramitesContravencional(sTramiteComp);
            cmbTramite.DataSource = null;
            funciones.llenarCombo(cmbTramite, slistatramitesComp);

            //LLENAR COMBO DE ÍTEMS DE LIQUIDACIÓN
            itemsLiquidacionComp itemLiquidacion = new itemsLiquidacionComp();
            Object[] itemsliq = (Object[])clienteTarifasComp.getTItemsLiquidacion(itemLiquidacion);
            cmbItemLiquidacion.DataSource = null;
            funciones.llenarCombo(cmbItemLiquidacion, itemsliq);

            //LLENAR COMBO DE TIPO CONCEPTOS
            ltipoConcepto tipsconcepto = new ltipoConcepto();
            Object[] listatips = (Object[])clienteTarifas.getLtipoConceptos(tipsconcepto);
            cmbTipoConcepto.DataSource = null;
            funciones.llenarCombo(cmbTipoConcepto, listatips);
        }


                      


        //TARIFAS
        private void btnAddtarifa_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            
            try
            {                
                lVigenciasComp vigenciaSeleccionada = (lVigenciasComp)listaVigencias[cmbVigencias.SelectedIndex];

                ltarifasComp tarifa = new ltarifasComp();
                tarifa.LT_VIGENCIA = vigenciaSeleccionada.LTV_VIGENCIA;
                tarifa.LT_TIPO = vigenciaSeleccionada.LTV_TIPO;
                
                AdicionarTarifa formu = new AdicionarTarifa(tarifa.LT_VIGENCIA, myUsuario);
                DialogResult dr = formu.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    actualizarGrillaTarifas();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
            this.Cursor = Cursors.Arrow;
        }

        private void btnEditTarifa_Click(object sender, EventArgs e)
        {
            habilitarEdicionTarifa(true);
            habilitarBotonesTarifa(false);
        }
        
        private void btnGuardarTarifa_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            
            try
            {                
                if (validarDatosTarifa())
                {                    
                    int idTarifaSeleccionada = int.Parse(grdTarifas.CurrentRow.Cells["LT_ID"].Value.ToString());
                    
                    ltarifasComp tarifaeditarComp = new ltarifasComp();
                    tarifaeditarComp.LT_ID = idTarifaSeleccionada;

                    if (chkActiva.Checked == true)
                        tarifaeditarComp.LT_ACTIVA = 1;
                    else
                        tarifaeditarComp.LT_ACTIVA = 0;

                    tarifaeditarComp.LT_CONDICIONES = txtCondiciones.Text;
                    tarifaeditarComp.LT_DESCRIPCION = txtDescripcion.Text;
                    tarifaeditarComp.LT_IDTRAM_CONTRAV = Int32.Parse(cmbTramite.SelectedValue.ToString());

                    if (chkMultipleliquidacion.Checked == true)
                        tarifaeditarComp.LT_LIQMULTIPLE = 1;
                    else
                        tarifaeditarComp.LT_LIQMULTIPLE = 0;

                    if (chkMultiplegrupo.Checked == true)
                        tarifaeditarComp.LT_MULTGRUPOLIQ = "T";
                    else
                        tarifaeditarComp.LT_MULTGRUPOLIQ = "F";

                    tarifaeditarComp.LT_NOMBRE = txtTarifa.Text;

                    if (cmbTipoTarifa.SelectedIndex == 0)
                        tarifaeditarComp.LT_TIPO = 1;
                    else if (cmbTipoTarifa.SelectedIndex == 1)
                        tarifaeditarComp.LT_TIPO = 2;

                    
                    //tarifaeditarComp.LT_VIGENCIA = int.Parse(cmbVigencias.SelectedValue.ToString());
                    lVigenciasComp vigenciaSeleccionada = (lVigenciasComp)listaVigencias[cmbVigencias.SelectedIndex];

                    ltarifasComp tarifa = new ltarifasComp();
                    tarifa.LT_VIGENCIA = vigenciaSeleccionada.LTV_VIGENCIA;
                    tarifa.LT_TIPO = vigenciaSeleccionada.LTV_TIPO;
                    tarifaeditarComp.LT_VIGENCIA = vigenciaSeleccionada.LTV_VIGENCIA;


                    //Enviar datos al servidor
                    Boolean editaTarifa = clienteTarifasComp.editarTarifaComp(tarifaeditarComp, WS.MyUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName());

                    if (editaTarifa)
                    {
                        MessageBox.Show("Tarifa Modificada");
                    }
                    else
                    {
                        MessageBox.Show("Error al Modificar");
                    }

                    actualizarGrillaTarifas();
                    //actualizarDatosTarifa();
                    habilitarEdicionTarifa(false);
                    habilitarBotonesTarifa(true);
                }
                this.Cursor = Cursors.Arrow;        
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }
        
        private void btnQuittarifa_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            
            try
            {                
                if (grdTarifas.SelectedCells.Count>0)
                {                    
                    int idTarifaSeleccionada = int.Parse(grdTarifas.CurrentRow.Cells["LT_ID"].Value.ToString());

                    ltarifasComp borrartarifacomp = new ltarifasComp();
                    borrartarifacomp.LT_ID = idTarifaSeleccionada;

                    Boolean borraTarifa = clienteTarifasComp.eliminarTarifas(borrartarifacomp, WS.MyUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName());
                    if (borraTarifa)
                    {
                        MessageBox.Show("Registro eliminado");
                        actualizarGrillaTarifas();
                    }
                    else
                    {
                        MessageBox.Show("Error en eliminación");
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una tarifa!.");
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
            this.Cursor = Cursors.Arrow;
        }

        private void btnCancelTarifa_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                actualizarDatosTarifa();
                habilitarEdicionTarifa(false);
                habilitarBotonesTarifa(true);
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }

            this.Cursor = Cursors.Arrow;
        }
        

        private void btnSearchTarifa_Click(object sender, EventArgs e)
        {
            try
            {
                lVigenciasComp vigenciaSeleccionada = (lVigenciasComp)listaVigencias[cmbVigencias.SelectedIndex];

                ltarifasComp tarifa = new ltarifasComp();
                tarifa.LT_VIGENCIA = vigenciaSeleccionada.LTV_VIGENCIA;
                tarifa.LT_TIPO = vigenciaSeleccionada.LTV_TIPO;

                object[] listaTarifasTemp = (Object[])clienteTarifasComp.getLtarifas(tarifa);
                if (listaTarifasTemp != null)
                {
                    ArrayList campos = new ArrayList();
                    campos.Add("LT_NOMBRE = Nombre");
                    campos.Add("LT_VIGENCIA = Vigencia");
                    campos.Add("LT_ACTIVA = Activa");

                    buscador myBuscador = new buscador(listaTarifasTemp, campos, "Buscador de tarifas", "");
                    if (myBuscador.ShowDialog() == DialogResult.OK)
                    {
                        DataTable dt = new DataTable();
                        dt = (DataTable)grdTarifas.DataSource;
                        dt.DefaultView.Sort = "LT_ID";
                        grdTarifas.CurrentCell = grdTarifas.Rows[dt.DefaultView.Find(myBuscador.Seleccion.Cells["LT_ID"].Value)].Cells[0];
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }


        private void habilitarEdicionTarifa(bool habilitar)
        {
            cmbTipoTarifa.Enabled = habilitar;
            txtTarifa.Enabled = habilitar;
            cmbTramite.Enabled = habilitar;
            txtDescripcion.Enabled = habilitar;

            chkMultiplegrupo.Enabled = habilitar;
            chkMultipleliquidacion.Enabled = habilitar;
            chkActiva.Enabled = habilitar;

            txtCondiciones.Enabled = habilitar;

            btnGuardarTarifa.Enabled = habilitar;
            btnCancelTarifa.Enabled = habilitar;
        }

        private void limpiarCamposTarifa()
        {
            cmbTipoTarifa.SelectedIndex = -1;
            txtTarifa.Clear();
            cmbTramite.SelectedIndex = -1;
            txtDescripcion.Clear();

            chkMultiplegrupo.Checked = false;
            chkMultipleliquidacion.Checked = false;
            chkActiva.Checked = false;

            txtCondiciones.Clear();            
        }

        private void habilitarBotonesTarifa(bool habilitar)
        {
            btnAddtarifa.Enabled = habilitar;
            btnEditTarifa.Enabled = habilitar;
            btnQuittarifa.Enabled = habilitar;

            btnSearchTarifa.Enabled = habilitar;
        }
        
        private bool validarDatosTarifa()
        {
            if (txtTarifa.Text == "")
            {
                txtTarifa.Focus();
                MessageBox.Show("Debe ingresar un nombre para la tarifa");
                return false;
            }

            if (cmbTipoTarifa.SelectedIndex < 0)
            {
                cmbTipoTarifa.Focus();
                MessageBox.Show("Debe seleccionar un tipo de tarifa");
                return false;
            }

            if (cmbTramite.SelectedIndex < 0)
            {
                cmbTramite.Focus();
                MessageBox.Show("Debe seleccionar un trámite");
                return false;
            }

            if (cmbVigencias.SelectedIndex < 0)
            {
                cmbVigencias.Focus();
                MessageBox.Show("Debe seleccionar una vigencia");
                return false;
            }

            return true;
        }


        private void grdTarifas_SelectionChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (grdTarifas.CurrentRow != null && listaTarifasComp!=null)            
                {                    
                    actualizarDatosTarifa();
                }

                actualizarGrillaConceptos();
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
            this.Cursor = Cursors.Arrow;
        }
        
        private void actualizarDatosTarifa()
        {            
            ltarifasComp tarifaSeleccionada = (ltarifasComp)listaTarifasComp[grdTarifas.CurrentRow.Index];

            //DATOS TARIFA
            if (tarifaSeleccionada.LT_TIPO == 1)
                cmbTipoTarifa.SelectedIndex = 0;
            if (tarifaSeleccionada.LT_TIPO == 2)
                cmbTipoTarifa.SelectedIndex = 1;

            txtTarifa.Text = tarifaSeleccionada.LT_NOMBRE;            
            txtDescripcion.Text = tarifaSeleccionada.LT_DESCRIPCION;

            if (tarifaSeleccionada.LT_MULTGRUPOLIQ == "T")
                chkMultiplegrupo.Checked = true;

            if (tarifaSeleccionada.LT_LIQMULTIPLE == 1)
                chkMultipleliquidacion.Checked = true;

            if (tarifaSeleccionada.LT_ACTIVA == 1)
                chkActiva.Checked = true;

            txtCondiciones.Text = tarifaSeleccionada.LT_CONDICIONES;            
        }        

        private void actualizarGrillaTarifas()
        {
            if (cmbVigencias.SelectedIndex >= 0)
            {
                lVigenciasComp vigenciaSeleccionada = (lVigenciasComp)listaVigencias[cmbVigencias.SelectedIndex];

                ltarifasComp tarifa = new ltarifasComp();
                tarifa.LT_VIGENCIA = vigenciaSeleccionada.LTV_VIGENCIA;
                tarifa.LT_TIPO = vigenciaSeleccionada.LTV_TIPO;

                //Buscar tarifas para la vigencia seleccionada
                listaTarifasComp = (Object[])clienteTarifasComp.getLtarifas(tarifa);

                if (listaTarifasComp != null)
                {
                    DataTable dtTarifas = new DataTable();

                    ArrayList campos = new ArrayList();
                    campos.Add("LT_ID = ID");
                    campos.Add("LT_NOMBRE = NOMBRE");
                    campos.Add("LT_DESCRIPCION = DESCRIPCIÓN");
                    campos.Add("LT_VIGENCIA = VIGENCIA");
                    campos.Add("LT_LIQMULTIPLE = LIQMULTIPLE");
                    campos.Add("LT_ACTIVA = ACTIVA");

                    dtTarifas = funciones.ToDataTable(funciones.ObjectToArrayList(listaTarifasComp));
                    grdTarifas.DataSource = dtTarifas;

                    if (dtTarifas != null && dtTarifas.Rows.Count > 0)
                    {
                        funciones.configurarGrilla(grdTarifas, campos);
                        //grdTarifas.Select();
                    }                    

                    //HABILITAR-DESHABILITAR CAMPOS
                    habilitarEdicionTarifa(false);
                    habilitarBotonesTarifa(true);
                    grbDatosTarifa.Enabled = true;
                    btnSearchTarifa.Enabled = true;
                    btnQuittarifa.Enabled = true;
                }
                else
                {         
                    //Tarifas
                    grdTarifas.DataSource = null;

                    //HABILITAR-DESHABILITAR CAMPOS                    
                    grbDatosTarifa.Enabled = false;
                    btnSearchTarifa.Enabled = false;
                    btnQuittarifa.Enabled = false;
                    limpiarCamposTarifa();

                    //Conceptos
                    grdConceptos.DataSource = null;
                    
                    //HABILITAR-DESHABILITAR CAMPOS
                    grbConceptos.Enabled = false;
                    grbDatosConcepto.Enabled = false;
                    habilitarBotonesConcepto(false);                    
                    limpiarCamposConcepto();

                    MessageBox.Show("No se encontraron registros de tarifas.", "No hay tarifas");
                }                
            }
        }




        //VIGENCIAS
        public void actualizarComboVigencias()
        {
            listaVigencias = (Object[])clienteComparendos.getLTvigencias(null);
            if (listaVigencias != null)
            {
                funciones.llenarCombo(cmbVigencias, listaVigencias);
            }
        }                            
        
        private void cmbVigencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            
            try
            {
                actualizarGrillaTarifas();
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
            this.Cursor = Cursors.Arrow;
        }

        private void btnAgregarVigencia_Click(object sender, EventArgs e)
        {
            try
            {                
                AdicionarVigencia formAdicionarVigencia = new AdicionarVigencia(myUsuario);
                
                lVigenciasComp vigenciaSeleccionada = (lVigenciasComp)listaVigencias[cmbVigencias.SelectedIndex];
                formAdicionarVigencia.llenarTipo(vigenciaSeleccionada.LTV_TIPO);
                formAdicionarVigencia.llenarVigencia(vigenciaSeleccionada.LTV_VIGENCIA);
                formAdicionarVigencia.idv = vigenciaSeleccionada.LTV_ID;

                if (formAdicionarVigencia.ShowDialog() == DialogResult.OK)
                {
                    //ACTUALIZAR VIGENCIAS
                    actualizarComboVigencias();
                }                       
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }





        //CONCEPTOS
        private void btnAddconcepto_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (grdTarifas.SelectedCells.Count > 0)
                {
                    editarConcepto = false;

                    int idTarifaSeleccionada = int.Parse(grdTarifas.CurrentRow.Cells["LT_ID"].Value.ToString());

                    if (idTarifaSeleccionada > 0)
                    {
                        adicionarconcepto form = new adicionarconcepto(idTarifaSeleccionada, -1, editarConcepto);
                        form.Width = 348;
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            actualizarGrillaConceptos();
                        }
                    }
                }
                else
                {
                    //MessageBox.Show("Debe seleccionar una tarifa!");
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void btnEditconcepto_Click(object sender, EventArgs e)
        {
            if (grdConceptos.SelectedCells.Count > 0)
            {
                habilitarEdicionConcepto(true);
                habilitarBotonesConcepto(false);
            }
        }

        private void btnEditConceptoForm_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdTarifas.SelectedCells.Count > 0)
                {
                    editarConcepto = true;

                    DataGridViewRow filaSeleccionada = grdConceptos.CurrentRow;
                    int idTarifaSeleccionada = int.Parse(filaSeleccionada.Cells["LT_ID"].Value.ToString());
                    int idDetalleTarifaSeleccionada = int.Parse(filaSeleccionada.Cells["LTD_ID"].Value.ToString());


                    if (idDetalleTarifaSeleccionada > 0)
                    {
                        adicionarconcepto formedit = new adicionarconcepto(idTarifaSeleccionada, idDetalleTarifaSeleccionada, editarConcepto);
                        formedit.Text = "[Modificar Concepto]";
                        formedit.Width = 348;

                        if (formedit.ShowDialog() == DialogResult.OK)
                        {
                            actualizarGrillaConceptos();
                        }
                    }
                }
                
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void btnOkconcepto_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            
            try
            {
                if (grdConceptos.SelectedCells.Count > 0)
                {
                    if (validarDatosConcepto())
                    {
                        DataGridViewRow filaSeleccionada = grdConceptos.CurrentRow;
                        int idTarifaSeleccionada = int.Parse(filaSeleccionada.Cells["LT_ID"].Value.ToString());
                        int idDetalleTarifaSeleccionada = int.Parse(filaSeleccionada.Cells["LTD_ID"].Value.ToString());

                        if (idDetalleTarifaSeleccionada > 0)
                        {
                            ltarifasDetComp editdettarifasComp = new ltarifasDetComp();
                            editdettarifasComp.LTD_ID = idDetalleTarifaSeleccionada;
                            editdettarifasComp.LTD_LT_ID = idTarifaSeleccionada;
                            editdettarifasComp.LTD_LCC_ID = Int32.Parse(cmbItemLiquidacion.SelectedValue.ToString());

                            if (chkConceptdescontable.Checked == true)
                                editdettarifasComp.LTD_DESCONTABLE = 1;
                            else
                                editdettarifasComp.LTD_DESCONTABLE = 0;

                            editdettarifasComp.LTD_TIPO = Int32.Parse(cmbTipoConcepto.SelectedValue.ToString());

                            //Fórmula y Valor
                            if (Int32.Parse(cmbTipoConcepto.SelectedValue.ToString()) == 1)
                            {
                                editdettarifasComp.LTD_VALOR = Int32.Parse(txtValor.Text);
                                editdettarifasComp.LTD_DATO_BASE = txtDatobase.Text;
                                editdettarifasComp.LTD_FACTOR = 0;
                                editdettarifasComp.LTD_CALCULO = txtCalculo.Text;
                            }
                            else if (Int32.Parse(cmbTipoConcepto.SelectedValue.ToString()) == 2 || Int32.Parse(cmbTipoConcepto.SelectedValue.ToString()) == 3)
                            {
                                editdettarifasComp.LTD_VALOR = 0;
                                editdettarifasComp.LTD_DATO_BASE = txtDatobase.Text;
                                editdettarifasComp.LTD_FACTOR = Int32.Parse(txtFactor.Text);
                                editdettarifasComp.LTD_CALCULO = txtCalculo.Text;
                            }
                            else if (Int32.Parse(cmbTipoConcepto.SelectedValue.ToString()) == 4)
                            {
                                editdettarifasComp.LTD_VALOR = 0;
                                editdettarifasComp.LTD_DATO_BASE = txtDatobase.Text;
                                editdettarifasComp.LTD_FACTOR = 0;
                                editdettarifasComp.LTD_CALCULO = txtCalculo.Text;
                            }


                            Boolean editaConcepto = clienteTarifasComp.editarDetTarifaComp(editdettarifasComp, WS.MyUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName());
                            if (editaConcepto == true)
                            {
                                MessageBox.Show("Detalle Modificado");
                            }
                            else
                            {
                                MessageBox.Show("Error al Modificar");
                            }
                        }

                        //Deshabilitar edición
                        actualizarDatosConceptoItemLiquidacion();
                        habilitarEdicionConcepto(false);
                        habilitarBotonesConcepto(true);
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
            this.Cursor = Cursors.Arrow;
        }

        private void btnQuitconcepto_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            
            try
            {                
                if (grdConceptos.SelectedCells.Count > 0)
                {                    
                    int idDetalleTarifaSeleccionada = int.Parse(grdConceptos.CurrentRow.Cells["LTD_ID"].Value.ToString());

                    ltarifasDetComp borrartarifadetcomp = new ltarifasDetComp();
                    borrartarifadetcomp.LTD_ID = idDetalleTarifaSeleccionada;

                    Boolean elimtarifadet = clienteTarifasComp.eliminarDetTarifaComp(borrartarifadetcomp, WS.MyUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName());
                    if (elimtarifadet == true)
                    {
                        MessageBox.Show("Item Eliminado");
                        actualizarDatosTarifa();
                    }
                    else
                    {
                        MessageBox.Show("Error al Eliminar");
                    }

                    //Actualizar grilla
                    actualizarGrillaConceptos();                    
                }
                else
                    MessageBox.Show("Debe seleccionar un concepto");                
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
            this.Cursor = Cursors.Arrow;
        }        
        
        private void btnCancelconcepto_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            
            try
            {
                if (grdConceptos.SelectedCells.Count > 0)
                {
                    actualizarDatosConceptoItemLiquidacion();
                    habilitarEdicionConcepto(false);
                    habilitarBotonesConcepto(true);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
            this.Cursor = Cursors.Arrow;
        }        
                

        private void tipoconcepto_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;            
            try
            {
                if (cmbTipoConcepto.Enabled)
                    habilitarCamposSegunTipoConcepto();
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
            this.Cursor = Cursors.Arrow;
        }
        

        private void grdConceptos_SelectionChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            
            try
            {
                if (grdConceptos.CurrentRow != null && listaConceptos != null)
                {
                    actualizarDatosConceptoItemLiquidacion();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }

            this.Cursor = Cursors.Arrow;
        }


        private void actualizarGrillaConceptos()
        {
            if (grdTarifas.CurrentRow != null && listaTarifasComp != null)
            {
                int idTarifaSeleccionada = int.Parse(grdTarifas.CurrentRow.Cells["LT_ID"].Value.ToString());

                //LLENAR GRID DE CONCEPTOS
                viewDetalleTarifaComp viewdetallesComp = new viewDetalleTarifaComp();
                viewdetallesComp.LT_ID = idTarifaSeleccionada;
                listaConceptos = (Object[])clienteTarifasComp.getLtarifasDet(viewdetallesComp);
            }
            else
            { listaConceptos = null; }

            if (listaConceptos != null)
            {
                DataTable dtDetalles = new DataTable();

                ArrayList Camposdet = new ArrayList();
                Camposdet.Add("LTD_ID = IDDETTARIFA");
                Camposdet.Add("LITEM_ID = IDCONCEPTO");
                Camposdet.Add("LITEM_NOMBRE = CONCEPTO");

                dtDetalles = funciones.ToDataTable(funciones.ObjectToArrayList(listaConceptos));
                grdConceptos.DataSource = dtDetalles;

                if (dtDetalles != null && dtDetalles.Rows.Count > 0)
                {
                    funciones.configurarGrilla(grdConceptos, Camposdet);
                    grdConceptos.Select();
                }

                //HABILITAR-DESHABILITAR CAMPOS                    
                grbConceptos.Enabled = true;
                grbDatosConcepto.Enabled = true;

                habilitarEdicionConcepto(false);
                habilitarBotonesConcepto(true);
            }
            else
            {
                //HABILITAR-DESHABILITAR CAMPOS                
                grdConceptos.DataSource = null;
                grbConceptos.Enabled = false;
                grbDatosConcepto.Enabled = false;

                habilitarBotonesConcepto(false);
                btnAddconcepto.Enabled = true;

                limpiarCamposConcepto();

                //MessageBox.Show("No se encontraron registros de conceptos para la tarifa seleccionada.", "No hay conceptos");
            }
        }
        
        private void actualizarDatosConceptoItemLiquidacion()
        {
            if (grdTarifas.CurrentRow != null)
            {
                int idTarifaSeleccionada = int.Parse(grdTarifas.CurrentRow.Cells["LT_ID"].Value.ToString());
                viewDetalleTarifaComp viewdetallesComp = new viewDetalleTarifaComp();
                viewdetallesComp.LT_ID = idTarifaSeleccionada;
                listaConceptos = (Object[])clienteTarifasComp.getLtarifasDet(viewdetallesComp);
            }

            viewDetalleTarifaComp detalleTarifaSeleccionada;
            detalleTarifaSeleccionada = (viewDetalleTarifaComp)listaConceptos[grdConceptos.CurrentRow.Index];

            if (detalleTarifaSeleccionada.LTD_DESCONTADLE == 1)
                chkConceptdescontable.Checked = true;
            else
                chkConceptdescontable.Checked = false;

            cmbItemLiquidacion.SelectedValue = detalleTarifaSeleccionada.LITEM_ID;
            cmbTipoConcepto.SelectedValue = detalleTarifaSeleccionada.LTD_TIPO;

            txtValor.Text = detalleTarifaSeleccionada.LTD_VALOR.ToString();
            txtFactor.Text = detalleTarifaSeleccionada.LTD_FACTOR.ToString();
            txtDatobase.Text = detalleTarifaSeleccionada.LTD_DATOBASE;
            txtCalculo.Text = detalleTarifaSeleccionada.LTD_CALCULO;            
        }


        private void habilitarEdicionConcepto(bool habilitar)
        {
            chkConceptdescontable.Enabled = habilitar;

            cmbTipoConcepto.Enabled = habilitar;
            cmbItemLiquidacion.Enabled = habilitar;

            //Deshabilitar y habilitar según el tipo de concepto seleccionado
            txtValor.Enabled = txtFactor.Enabled = txtDatobase.Enabled = txtCalculo.Enabled = false;
            if (habilitar)
                habilitarCamposSegunTipoConcepto();

            btnOkconcepto.Enabled = habilitar;
            btnCancelconcepto.Enabled = habilitar;
        }

        private void limpiarCamposConcepto()
        {
            chkConceptdescontable.Checked = false;

            cmbTipoConcepto.SelectedIndex = -1;
            cmbItemLiquidacion.SelectedIndex = -1;

            txtValor.Clear();
            txtFactor.Clear();
            txtDatobase.Clear();
            txtCalculo.Clear();
        }

        private void habilitarBotonesConcepto(bool habilitar)
        {
            //HABILITAR BOTONES
            btnEditConceptoForm.Enabled = habilitar;
            btnEditconcepto.Enabled = habilitar;

            btnAddconcepto.Enabled = habilitar;
            btnQuitconcepto.Enabled = habilitar;
        }

        private void habilitarCamposSegunTipoConcepto()
        {
            if (cmbTipoConcepto.SelectedValue != null)
            {
                if (Int32.Parse(cmbTipoConcepto.SelectedValue.ToString()) == 1)
                {
                    txtValor.Enabled = true;
                    txtFactor.Enabled = false;
                    txtDatobase.Enabled = false;
                    txtCalculo.Enabled = false;

                    txtFactor.Text = "";
                    txtDatobase.Text = "";
                    txtCalculo.Text = "";
                }
                else if (Int32.Parse(cmbTipoConcepto.SelectedValue.ToString()) == 2 || Int32.Parse(cmbTipoConcepto.SelectedValue.ToString()) == 3)
                {
                    txtValor.Enabled = false;
                    txtFactor.Enabled = true;
                    txtDatobase.Enabled = true;
                    txtCalculo.Enabled = false;

                    txtValor.Text = "";
                    txtCalculo.Text = "";
                }
                else if (Int32.Parse(cmbTipoConcepto.SelectedValue.ToString()) == 4)
                {
                    txtValor.Enabled = false;
                    txtFactor.Enabled = false;
                    txtDatobase.Enabled = false;
                    txtCalculo.Enabled = true;

                    txtValor.Text = "";
                    txtFactor.Text = "";
                    txtDatobase.Text = "";
                }
            }
        }

        private bool validarDatosConcepto()
        {
            if (Int32.Parse(cmbTipoConcepto.SelectedValue.ToString()) == 1)
            {
                if (txtValor.Text == "")
                {
                    MessageBox.Show("El campo valor no puede ser vacío");
                    txtValor.Focus();
                    return false;
                }
            }
            else if (Int32.Parse(cmbTipoConcepto.SelectedValue.ToString()) == 2 || Int32.Parse(cmbTipoConcepto.SelectedValue.ToString()) == 3)
            {
                if (txtFactor.Text == "")
                {
                    MessageBox.Show("El campo factor no puede ser vacío");
                    txtFactor.Focus();
                    return false;
                }
                else if (txtDatobase.Text == "")
                {
                    MessageBox.Show("El campo dato base no puede ser vacío");
                    txtDatobase.Focus();
                    return false;
                }
            }
            else if (Int32.Parse(cmbTipoConcepto.SelectedValue.ToString()) == 4)
            {
                if (txtCalculo.Text == "")
                {
                    MessageBox.Show("El campo cálculo no puede ser vacío");
                    txtCalculo.Focus();
                    return false;
                }
            }

            return true;
        }






        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void valor_TextChanged(object sender, EventArgs e)
        {
            funciones = new Funciones();
            funciones.soloNumeros(txtValor);
        }

        private void factor_TextChanged(object sender, EventArgs e)
        {
            funciones = new Funciones();
            funciones.soloNumeros(txtFactor);
        }

        #region Eventos KEY PRESS
            private void listatarifastram_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }

            private void tipo_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }

            private void tarifa_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }

            private void grupoliquidacion_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }

            private void tramiteas_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }

            private void descripcion_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }

            private void multiplegrupo_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }

            private void multipleliquidacion_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }

            private void activa_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }

            private void liquidaciontotal_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }

            private void hastadia_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }

            private void desdedia_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }

            private void conceptdescontable_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }

            private void tipoconcepto_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }

            private void concepto_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }

            private void valor_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }

            private void factor_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }

            private void datobase_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }
        #endregion                        

            

            

            

            

            
        
    }
}
