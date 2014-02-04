using System;
using TransitoPrincipal; 

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Word = Microsoft.Office.Interop.Word;

using Comparendos;
using LibreriasSintrat.ServiciosDocumentos;
using LibreriasSintrat.ServiciosConfiguraciones;
using LibreriasSintrat.utilidades;
using System.IO;
using TransportePublico.servicios.documentos;

namespace Comparendos.servicios.documentos
{
    public partial class fPlantilla : Form
    {
        Object[] campos;
        Object[] consultas;
        Object[] myPlantillas;
        Object[] mySqlPlantillas;

        plantilla myPlantilla;        
        
        Funciones myFnc;
        ServiciosDocumentosService mySerDoc;        
        
        int posicionActual;        


        public fPlantilla()
        {
            InitializeComponent();
        }

        private void fPlantilla_Load(object sender, EventArgs e)
        {
            myPlantilla = new plantilla();            
            
            myFnc = WS.Funciones();
            mySerDoc = WS.ServiciosDocumentosService();

            cargarCombos();

            ricTxtContenido.Text = "";
            
            refrescar();        
        }              
        

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //refrescar();
            
            buscarPlantilla();            
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            //Generar vista previa plantilla
            string ENCABEZADO = ricTxtEncabezado.Text;
            string CONTENIDO = ricTxtContenido.Text;

            if (txtNomPlantilla.Text != "")
            {                
                generarPlantilla(ENCABEZADO, CONTENIDO);
            }
            else MessageBox.Show("El nombre es requisito para ver la plantilla");
        }

        
        public void generarPlantilla(string EncabezadoPlant, string ContenidoPlant)
        {            
            //plantillaAPDF myPlToPdf = new plantillaAPDF();
            //transferir myTrans = new transferir();
            

            plantilla nuevaPlantilla = new plantilla();
            //Object[] parametros = new Object[2];

            //param = "ENCABEZADO = " + EncabezadoPlant;
            //parametros[0] = param;

            //param = "CONTENIDO = " + ContenidoPlant;
            //parametros[1] = param;

            nuevaPlantilla.ENCABEZADO = EncabezadoPlant;
            nuevaPlantilla.CONTENIDO = ContenidoPlant;

            // String nombreDoc = myResComp.NOMBRE;
            String nombreDoc = "DOCUMENTO RESOLUCION VISTA PREVIA";
            /*myPlToPdf.creaPdfPlantilla(myPlantilla, nombreDoc);
            ServiciosConfiguracionesService mySerConf = WS.ServiciosConfiguracionesService();
            String ruta;
            ruta = mySerConf.directorioResoluciones();
            nombreDoc+=".pdf";
            myTrans.archivoAlServer("D:\\" + nombreDoc,ruta+nombreDoc);*/
            imprimirWord(nuevaPlantilla, nombreDoc);
        }

        private void imprimirWord(plantilla myPlantillaTemp, string nombreDoc)
        {
            try
            {
                //GENERACION DE DOCUMENTO EN WORD
                ServiciosConfiguracionesService serviciosConfiguraciones = WS.ServiciosConfiguracionesService();
                ServiciosDocumentosService serviciosDocumentos = WS.ServiciosDocumentosService();

                //Leer la ruta en el servidor
                string ruta = serviciosConfiguraciones.leerRegistroIni("PLANTILLAS") + "\\ResolucionInfractor.dotx";


                if (!File.Exists(ruta))
                {
                    //Transferir el archivo de plantilla desde el servidor a una carpeta local (en una ruta igual a la que está en el servidor)
                    transferir myTransferencia = new transferir();
                    myTransferencia.archivoDelServerSinAbrir(ruta);
                }

                // Objetos de word
                Word.Application oWord = new Word.Application();
                Word.Document oDoc;

                object fileName = ruta;
                object newTmp = System.Reflection.Missing.Value;
                object DocType = false;
                object visible = true;

                // Ubicación de la plantilla en el disco duro (Crear un documento a partir de la plantilla)
                oDoc = oWord.Documents.Add(ref fileName, ref newTmp, ref DocType, ref visible);

                // Llenar los bookmarks de la plantilla (ENCABEZADO Y CONTENIDO en este caso) con los datos actuales
                if (myPlantillaTemp.ENCABEZADO != null)
                {
                    object objTmp;
                    objTmp = "ENCABEZADO";
                    myPlantillaTemp.ENCABEZADO = myPlantillaTemp.ENCABEZADO.Replace("<t>", "");
                    oDoc.Bookmarks.get_Item(ref objTmp).Range.Text = myPlantillaTemp.ENCABEZADO.Replace("<->", "");
                }
                if (myPlantillaTemp.CONTENIDO != null)
                {
                    object objTmp;
                    objTmp = "CONTENIDO";
                    myPlantillaTemp.CONTENIDO = myPlantillaTemp.CONTENIDO.Replace("<t>", "");
                    oDoc.Bookmarks.get_Item(ref objTmp).Range.Text = myPlantillaTemp.CONTENIDO.Replace("<->", "");
                }


                //Crear el directorio de previsualizaciones si no existe
                string directorio = ruta.Substring(0, (ruta.Length - (ruta.Length - ruta.LastIndexOf('\\')))) + "\\previsualizaciones\\";

                if (!Directory.Exists(directorio))
                    Directory.CreateDirectory(directorio);
                if (Directory.Exists(directorio))
                {
                    object FileNamea = directorio + nombreDoc + ".doc";
                    object FileFormata = Word.WdSaveFormat.wdFormatDocument;
                    object no = System.Reflection.Missing.Value;
                    object AddToRecentFilesa = System.Reflection.Missing.Value;
                    object SaveNativePictureFormata = System.Reflection.Missing.Value;
                    object Encodinga = System.Reflection.Missing.Value;
                    object LineEndinga = System.Reflection.Missing.Value;

                    
                    //Cerrar el archivo
                    System.Diagnostics.Process[] procesos;
                    procesos = System.Diagnostics.Process.GetProcessesByName((string)FileNamea);
                    if (procesos != null)
                        foreach (var item in procesos)
                        {
                            System.Diagnostics.Process procesoActual = (System.Diagnostics.Process)item;
                            procesoActual.Kill();
                        }


                    //oWord.ActiveDocument.Save();
                    oWord.ActiveDocument.SaveAs(ref FileNamea, ref FileFormata, ref no, ref no, ref AddToRecentFilesa, ref no, ref no, ref no, ref SaveNativePictureFormata, ref no,
                                    ref no, ref Encodinga, ref no, ref no, ref LineEndinga, ref no);
                    //Abrir el archivo                    
                    System.Diagnostics.Process.Start((string)FileNamea);
                    
                    ////oWord.ShowMe();
                    //object doNotSaveChanges = Word.WdSaveOptions.wdDoNotSaveChanges;
                    ////oWord.ActiveDocument.Close(ref doNotSaveChanges, ref no, ref no);
                    //oDoc.Close(ref doNotSaveChanges, ref no, ref no);
                    //oWord.ShowMe();
                    //Abrir el archivo
                    //System.Diagnostics.Process.GetCurrentProcess().Kill();// ((string)FileNamea);
                    //System.Diagnostics.Process.Start((string)FileNamea);
                }
                else
                {
                    MessageBox.Show("No se pudo crear el directorio para visualizar el archivo.");
                }        
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo abrir el archivo de visualización. Compruebe que no haya un documento de vista previa abierto.");
            }    
        }
        
        #region Eventos formulario Gestión plantillas

            #region Botones de Navegación                        

                //Ir al primero
                private void btnFirst_Click(object sender, EventArgs e)
                {
                    posicionActual = 0;
                    actualizarPlantillaPosicionActual(posicionActual);            
                }

                //Ir al anterior
                private void btnPrevious_Click(object sender, EventArgs e)
                {
                    if (posicionActual > 0)
                    {
                        posicionActual--;

                        actualizarPlantillaPosicionActual(posicionActual);             
                    }            
                }

                //Ir al siguiente 
                private void btnNext_Click(object sender, EventArgs e)
                {
                    if (posicionActual < myPlantillas.Length - 1)
                    {
                        posicionActual++;

                        actualizarPlantillaPosicionActual(posicionActual);
                    }
                }

                //Ir al último 
                private void btnLast_Click(object sender, EventArgs e)
                {
                    posicionActual = myPlantillas.Length - 1;

                    actualizarPlantillaPosicionActual(posicionActual);              
                }
            #endregion

            #region Botones de Edición
                //Adicionar 
                private void btnAdd_Click(object sender, EventArgs e)
                {
                    myPlantilla = new plantilla();
            
                    txtNomPlantilla.Text = "";
                    txtQuery.Text = "";
                    ricTxtContenido.Text = "";
                    ricTxtEncabezado.Text = "";           
                    lblNroRelacionPlantillas.Text = "";            

                    lstVieCampos.Clear();

                    habilitarEdicion(true);
                    habilitarControles(false);            
                    habilitarBotonesNavegacion(false);
                }

                //Editar 
                private void btnEditar_Click(object sender, EventArgs e)
                {
                    habilitarEdicion(true);
                    habilitarControles(false);
                    habilitarBotonesNavegacion(false);
                }

                //Eliminar 
                private void btnDelete_Click(object sender, EventArgs e)
                {
                    if (MessageBox.Show("¿Esta seguro de eliminar el registro?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (posicionActual >= 0)
                        {                    
                            myPlantilla = (plantilla)myPlantillas[posicionActual];

                            bool eliminado = mySerDoc.eliminarPlantilla(myPlantilla);
                            if (eliminado)
                            {
                                if (eliminarSqlPlantillas(myPlantilla.ID))
                                    MessageBox.Show("¡Acción realizada!");
                                else
                                    MessageBox.Show("¡Ocurrió un error al eliminar las consultas SQL de la plantilla!");
                            }
                            else
                                MessageBox.Show("¡Ocurrió un error al eliminar la plantilla!");

                            refrescar();
                        }
                    }
                }                        

                //Refrescar, volver a estado inicial
                private void btnRefresh_Click(object sender, EventArgs e)
                {
                    refrescar();
                }            
        
            #endregion

            #region Botones de Confirmación
                //Guardar - confirma la edición o adición de una plantilla
                private void btnPost_Click(object sender, EventArgs e)
                {
                    //Valida, prepara y procesa las consultas
                    if (validarProcesarConsultas())
                    {
                        if (validarCampos())
                        {
                            myPlantilla.ENCABEZADO = ricTxtEncabezado.Text;
                            myPlantilla.CONTENIDO = ricTxtContenido.Text;
                            myPlantilla.IDTIPORESOLUCION = (int)cmbBoxTipoResol.SelectedValue;

                            if (!(myPlantilla.ID > 0))
                            {
                                myPlantilla.NOMBRE = txtNomPlantilla.Text;
                                myPlantilla = mySerDoc.insertarPlantilla(myPlantilla);
                                guardarSqlPlantillas();
                            }
                            else
                            {
                                myPlantilla = mySerDoc.actualizarPlantilla(myPlantilla);
                                actualizarSqlPlantillas();
                            }

                            MessageBox.Show("¡Acción realizada!");

                            habilitarControles(true);

                            refrescar();
                        }                        
                    }
                    else
                        MessageBox.Show("Consultas NO válidas. Recuerde: las consultas deben ir separadas por punto y coma (;).", "Error en las consultas");
                }

                //Valida que los campos tengan datos
                private bool validarCampos()
                {
                    if (string.IsNullOrEmpty(txtNomPlantilla.Text))
                    {
                        MessageBox.Show("El nombre es requisito para almacenar la plantilla");
                        txtNomPlantilla.Focus();
                        return false;
                    }

                    if (string.IsNullOrEmpty(ricTxtEncabezado.Text))
                    {
                        MessageBox.Show("El encabezado es requisito para almacenar la plantilla");
                        ricTxtEncabezado.Focus();
                        return false;
                    }

                    if (string.IsNullOrEmpty(ricTxtContenido.Text))
                    {
                        MessageBox.Show("El contenido es requisito para almacenar la plantilla");
                        ricTxtContenido.Focus();
                        return false;
                    }

                    if (cmbBoxTipoResol.SelectedIndex == -1)
                    {
                        MessageBox.Show("Debe seleccionar un tipo de resolución!");
                        cmbBoxTipoResol.Focus();
                        return false;
                    }

                    return true;
                }

                //Cancela una acción de edición: editar o agregar plantilla
                private void btnCancelar_Click(object sender, EventArgs e)
                {
                    refrescar();                    
                }

            #endregion

            
            private void cmbBoxTipoResol_SelectedValueChanged(object sender, EventArgs e)
            {
                refrescar();
            }

            //Inserta el campo en el texto del contenido
            private void lstVieCampos_DoubleClick(object sender, EventArgs e)
            {
                string contenido = "*" + lstVieCampos.SelectedItems[0].Text + "*";
                int pos = ricTxtContenido.SelectionStart;
                ricTxtContenido.Text = ricTxtContenido.Text.Insert(pos, contenido);
            }

            //Obtener los campos
            private void btnQuery_Click(object sender, EventArgs e)
            {
                if (!string.IsNullOrEmpty(txtQuery.Text))
                {
                    if (!validarProcesarConsultas())
                        MessageBox.Show("Consultas NO válidas. Recuerde: las consultas deben ir separadas por punto y coma (;).", "Error en las consultas");
                }
                else
                {
                    MessageBox.Show("Debe escribir consultas para obtener los campos!", "No hay consultas");
                    txtQuery.Focus();
                }

            }

        #endregion        

        #region Funciones utilitarias
            
            //Permite la edición de los campos de una plantilla
            private void habilitarEdicion(bool habilitar)
            {
                txtNomPlantilla.Enabled = habilitar;

                ricTxtEncabezado.Enabled = habilitar;
                ricTxtContenido.Enabled = habilitar;

                btnQuery.Enabled = habilitar;
                lstVieCampos.Enabled = habilitar;

                txtQuery.Enabled = habilitar;
            }
        
            //Si se habilita la edición, se deshabilita la confirmación y viceverza
            private void habilitarControles(Boolean estado)
            {
                habilitarBotonesEdicion(estado);
                habilitarBotonesConfirmacion(!estado);
            }

            //Habilita/Deshabilita los botones de confirmación
            private void habilitarBotonesConfirmacion(bool habilitar)
            {
                btnPost.Enabled = habilitar;
                btnCancelar.Enabled = habilitar;
            }

            //Habilita/Deshabilita los botones de navegación
            private void habilitarBotonesNavegacion(bool habilitar)
            {
                btnFirst.Enabled = habilitar;
                btnLast.Enabled = habilitar;
                btnNext.Enabled = habilitar;
                btnPrevious.Enabled = habilitar;
            }

            //Habilita/Deshabilita los botones de edición, según existan o no 
            //plantillas para el tipo de resolución actual
            private void habilitarBotonesEdicion(Boolean estado)
            {
                btnRefresh.Enabled = estado;
                btnAdd.Enabled = estado;

                //Si no hay plantillas, no se deben habilitar los botones editar, eliminar y vista previa
                if (myPlantillas == null)
                    estado = false;

                btnEditar.Enabled = estado;
                btnDelete.Enabled = estado;
                //btnPreview.Enabled = estado;
            }

            //Vuelve al estado inicial para el tipo de resolución seleccionado
            private void refrescar()
            {
                cargarPlantillas();
                
                habilitarEdicion(false);
                habilitarControles(true);
            }

            public void limpiarCampos()
            {
                ricTxtContenido.Clear();
                txtNomPlantilla.Clear();
                txtQuery.Clear();
                ricTxtEncabezado.Clear();
                lstVieCampos.Clear();
            }

            //Actualiza la información de la plantilla actual
            private void actualizarPlantillaPosicionActual(int pos)
            {
                //Actualizar info de plantilla
                mostrarPlantilla(pos);

                //Actualizar info de navegación
                actualizarInformacionNavegacion(pos);
            }

            //Actualiza el estado de los botones de navegación y la información 
            //de plantilla actual y número total de plantillas
            private void actualizarInformacionNavegacion(int pos)
            {
                if (myPlantillas != null)
                {
                    lblNroRelacionPlantillas.Text = (pos + 1) + " de " + myPlantillas.Length + " plantillas";

                    habilitarBotonesNavegacion(true);

                    //Deshabilitar primero y anterior si está en la primera posición
                    if (pos == 0)
                        btnPrevious.Enabled = btnFirst.Enabled = false;

                    //Deshabilitar siguiente y último si está en la última posición
                    if (pos == (myPlantillas.Length - 1))
                        btnNext.Enabled = btnLast.Enabled = false;
                }
                else
                {
                    lblNroRelacionPlantillas.Text = "_";
                    habilitarBotonesNavegacion(false);
                }
            }

            //Carga las plantillas creadas para el tipo de resolución actual
            public void cargarPlantillas()
            {
                limpiarCampos();

                if (cmbBoxTipoResol.SelectedIndex > -1)
                    myPlantillas = (Object[])mySerDoc.buscarPlantillas(new plantilla() { IDTIPORESOLUCION = int.Parse(cmbBoxTipoResol.SelectedValue.ToString()) });
                
                //Carga la plantilla en la posición 0
                actualizarPlantillaPosicionActual(0);                
            }

            //Carga las plantillas SQL (consultas) de la plantilla actual
            public void cargarSqlPlantillas()
            {
                sqlPlantilla mySqlPlantilla = new sqlPlantilla();
                mySqlPlantilla.IDPLANTILLA = myPlantilla.ID;
                mySqlPlantillas = (Object[])mySerDoc.buscarSqlPlantillas(mySqlPlantilla);

                if (mySqlPlantillas != null)
                {
                    for (int i = 0; i < mySqlPlantillas.Length; i++)
                    {
                        sqlPlantilla tmp = (sqlPlantilla)mySqlPlantillas[i];

                        txtQuery.Text += tmp.QUERY;

                        if (i < mySqlPlantillas.Length - 1)
                            txtQuery.Text += ";";
                    }
                }

                validarProcesarConsultas();
            }

            //Muestra los datos de la plantilla en la posicion indicada
            public void mostrarPlantilla(int posicion)
            {
                if (myPlantillas != null && posicion < myPlantillas.Length)
                {
                    posicionActual = posicion;
                    myPlantilla = (plantilla)myPlantillas[posicionActual];

                    txtNomPlantilla.Text = myPlantilla.NOMBRE;
                    ricTxtEncabezado.Text = myPlantilla.ENCABEZADO;
                    ricTxtContenido.Text = myPlantilla.CONTENIDO;

                    if (myPlantilla.IDTIPORESOLUCION > 0)
                        cmbBoxTipoResol.SelectedValue = myPlantilla.IDTIPORESOLUCION;

                    txtQuery.Text = "";

                    cargarSqlPlantillas();
                }
            }

            //Valida (si existen) las consultas SQL asociadas a la plantilla y las procesa (obtiene los campos)
            public bool validarProcesarConsultas()
            {
                //La consulta no es obligatoria, si no existe se toma como válida
                if (!string.IsNullOrEmpty(txtQuery.Text))
                {
                    lstVieCampos.Clear();

                    //Preparar consultas
                    String sql;
                    sql = txtQuery.Text;
                    consultas = (Object[])sql.Split(new char[] {';'}, StringSplitOptions.RemoveEmptyEntries);

                    bool consultasValidas = false;

                    if (consultas != null)
                    {
                        for (int i = 0; i < consultas.Length; i++)
                        {
                            string consultaTmp = (String)consultas[i];
                            if (!string.IsNullOrWhiteSpace(consultaTmp))
                                consultasValidas = validarEjecutarQuery(consultaTmp);

                            //Si alguna consulta no es válida se toman todas como inválidas
                            if (!consultasValidas) return false;
                        }
                    }

                    return consultasValidas;
                }
                else
                    return true;
            }
        
            //Valida y ejecuta una consulta (obtiene los campos)
            public bool validarEjecutarQuery(String query)
            {
                bool val = validarQuery(query);

                if (val)
                {
                    query = query.Replace("SELECT", "SELECT FIRST 1");                    
                    campos = (Object[])mySerDoc.verificarConsulta(query);

                    if (campos != null)
                    {
                        //Actualiza la lista de campos en el formulario
                        String campo;

                        if (campos != null)
                            for (int i = 0; i < campos.Length; i++)
                            {
                                campo = campos[i].ToString().ToUpper();
                                lstVieCampos.Items.Add(campo);
                            }

                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Alguna de las consultas no retorna datos!", "Error en la consulta");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Recuerde que solo se permiten consultas tipo SELECT", "Error en la consulta");
                    return false;
                }
            }
        

        /*
            //Valida y ejecuta una consulta (obtiene los campos)
            public bool validarEjecutarQuery(String query)
            {
                if (validarQuery(query))
                {
                    mySerDoc.verificarConsultaAsync(query);
                    mySerDoc.verificarConsultaCompCompleted += new verificarConsultaCompCompletedEventHandler(mySerDoc_verificarConsultaCompCompleted);

                    return true; //NO TIENE SENTIDO
                }
                else
                {
                    MessageBox.Show("Recuerde que solo se permiten consultas tipo SELECT", "Error en la consulta");
                    return false;
                }
            }

            void mySerDoc_verificarConsultaCompCompleted(object sender, verificarConsultaCompCompletedEventArgs e)
            {
                try
                {
                    campos = (Object[])e.Result;
                    if (campos != null)
                    {
                        //Actualiza la lista de campos en el formulario
                        String campo;
                        if (campos != null)
                            for (int i = 0; i < campos.Length; i++)
                            {
                                campo = campos[i].ToString().ToUpper();
                                lstVieCampos.Items.Add(campo);
                            }

                        //return true;
                    }
                    else
                    {
                        MessageBox.Show("Alguna de las consultas no retorna datos!", "Error en la consulta");
                        //return false;
                    }
                }
                catch (Exception ex)
                {                    
                    
                }
            }
        */

            //Verifica que la consulta sólo tenga instrucciones SELECT
            bool validarQuery(String sql)
            {
                if (sql.Contains("GRANT") || sql.Contains("DROP") || sql.Contains("DELETE") || sql.Contains("UPDATE") || sql.Contains("INSERT") || sql.Contains("--"))
                    return false;
                if (sql.Contains("USUARIO"))
                    return false;
                return true;
            }

            //Guarda las plantillas SQL (consultas) para la plantilla actual
            public void guardarSqlPlantillas()
            {
                sqlPlantilla mySqlPlantilla;

                if (consultas != null)
                    for (int i = 0; i < consultas.Length; i++)
                    {
                        mySqlPlantilla = new sqlPlantilla();
                        mySqlPlantilla.IDPLANTILLA = myPlantilla.ID;
                        mySqlPlantilla.QUERY = (String)consultas[i];
                        mySerDoc.insertarSqlPlantilla(mySqlPlantilla);
                    }
            }

            //Actualiza las plantillas SQL (consultas) de la plantilla actual
            public void actualizarSqlPlantillas()
            {
                if (mySqlPlantillas != null)
                {
                    foreach (var item in mySqlPlantillas)
                    {
                        sqlPlantilla mySqlPlantilla = (sqlPlantilla)item;
                        mySerDoc.eliminarSqlPlantilla(mySqlPlantilla);
                    }
                    mySqlPlantillas = null;
                }

                if (consultas != null)
                    for (int i = 0; i < consultas.Length; i++)
                    {
                        sqlPlantilla mySqlPlantilla = new sqlPlantilla();
                        mySqlPlantilla.IDPLANTILLA = myPlantilla.ID;
                        mySqlPlantilla.QUERY = (String)consultas[i];
                        mySerDoc.insertarSqlPlantilla(mySqlPlantilla);
                    }
            }

            //Elimina las plantillas SQL de la plantilla indicada
            public bool eliminarSqlPlantillas(int idPlantilla)
            {
                try
                {
                    sqlPlantilla mySqlPlantilla = new sqlPlantilla();

                    mySqlPlantilla.IDPLANTILLA = idPlantilla;

                    object[] listaSqlPlantillas = mySerDoc.buscarSqlPlantillas(mySqlPlantilla);

                    bool eliminado = true;

                    if (listaSqlPlantillas != null)
                    {
                        foreach (var item in listaSqlPlantillas)
                        {
                            sqlPlantilla tmpSqlPlantilla = (sqlPlantilla)item;
                            eliminado = mySerDoc.eliminarSqlPlantilla(tmpSqlPlantilla);
                        }
                    }

                    return eliminado;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            //Carga los tipos de resoluciones en el combo
            public void cargarCombos()
            {
                Object[] myTipos;
                myTipos = (Object[])mySerDoc.ListarTipoResolucion();

                myFnc.llenarCombo(cmbBoxTipoResol, myTipos);
            }

            //Busca una plantilla en la lista de plantillas actuales
            public void buscarPlantilla()
            {
                ArrayList Campos = new ArrayList();
                Campos.Add("NOMBRE = NOMBRE");

                if (myPlantillas != null)
                {
                    buscador buscador = new buscador(myPlantillas, Campos, "Plantillas de Documentos", null);
                    Funciones funciones = WS.Funciones();
                    if (buscador.ShowDialog() == DialogResult.OK)
                    {
                        plantilla myPlantillaTemp = (plantilla)funciones.listToPlantilla(buscador.Seleccion);
                        
                        int posicion = getPosicionPlantillaEnArray(myPlantillaTemp);
                        actualizarPlantillaPosicionActual(posicion);
                    }

                    buscador.Dispose();
                }
                else
                {
                    MessageBox.Show("No hay plantillas creadas para el tipo de resolución seleccionado.", "No hay registros");
                }
            }

            //Obtiene la posicion de la una plantilla en el array de plantillas
            private int getPosicionPlantillaEnArray(plantilla myPlantilla)
            {
                int i = -1;
                if (myPlantillas != null)
                    for (i = 0; i < myPlantillas.Length; i++)
                    {
                        plantilla myPlantillaTemp = (plantilla)myPlantillas[i];
                        if (myPlantillaTemp.ID == myPlantilla.ID)
                            return i;
                    }

                return -1;
            }

        #endregion
    }
}
