using System; using TransitoPrincipal; using LibreriasSintrat.utilidades;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
//using LibreriasSintrat.ServiciosComparendos;
using LibreriasSintrat.ServiciosGeneralesComp;
using LibreriasSintrat.ServiciosConfiguraciones;
using LibreriasSintrat.ServiciosAccesoriasComp;
using Comparendos.servicios.documentos;
using LibreriasSintrat.ServiciosDocumentos;
using LibreriasSintrat.ServiciosAccesorias;
using System.Collections;
using Word = Microsoft.Office.Interop.Word;
using System.Diagnostics;
using System.IO;
using Comparendos.utilidades;
using LibreriasSintrat;



namespace Comparendos.servicios.Coativos
{
    public partial class FrmCoativos : Form
    {
       
        ServiciosGeneralesCompService mySerGenerales;
        
        DataTable DtInfractores, DtComparendos, DtComparendosInfractorTemp;
        Object[] listaInfractores;
        Funciones funcion = new Funciones();
        
        // Objetos de word
        private Word.Application oWord;
        private Word.Document oDoc;
        
        transferir Transferir = new transferir();
        Log log = new Log();        

        public FrmCoativos()
        {
            this.Cursor = Cursors.WaitCursor;

            InitializeComponent();
            mySerGenerales = WS.ServiciosGeneralesCompService();
            log = new Log();

            this.Cursor = Cursors.Arrow;
        }

        private void FrmCoativos_Load(object sender, EventArgs e)
        {            
        }

        //Realizar la busqueda de Infractores por fecha         
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                BuscarInfractores();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error realizando la funcionalidad: " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }        

        //Metodo para realizar consulta fecha
        public void BuscarInfractores()
        {
            //Obtengo el motor de la base de datos
            ServiciosConfiguracionesService myServicioConfiguracion = WS.ServiciosConfiguracionesService();
            String motor = myServicioConfiguracion.leerRegistroIni("MOTOR");
            
            //DateTime fecha1 = dateTPickFechaInicial.Value;
            //DateTime fecha2 = dateTPickFechaFinal.Value;
            String fecha1;
            String fecha2;

            if (motor.Equals("ORACLE"))
            {
                fecha1 = dateTPickFechaInicial.Value.ToString("dd/MM/yyyy"); //Oracle
                fecha2 = dateTPickFechaFinal.Value.ToString("dd/MM/yyyy"); //Oracle
            }
            else
            {
                fecha1 = dateTPickFechaInicial.Value.ToString("MM/dd/yyyy"); //Firebird
                fecha2 = dateTPickFechaFinal.Value.ToString("MM/dd/yyyy"); //Firebird
            }
            label3.Text = "Proceso de consulta iniciado. Por favor espere...";
            label3.ForeColor = Color.Red;
            ServiciosGeneralesCompService mySerGenerales = WS.ServiciosGeneralesCompService();
            mySerGenerales.getInfractoresComparendoPorFechaAsync(fecha1, fecha2, true);
            mySerGenerales.getInfractoresComparendoPorFechaCompleted += new getInfractoresComparendoPorFechaCompletedEventHandler(mySerGenerales_getInfractoresComparendoPorFechaCompleted);
        }

        void mySerGenerales_getInfractoresComparendoPorFechaCompleted(object sender, getInfractoresComparendoPorFechaCompletedEventArgs e)
        {
            label3.ForeColor = Color.Green;
            listaInfractores = e.Result;            

            if (listaInfractores != null)
            {
                label3.Text = "Proceso de consulta finalizado. Resultados: " + listaInfractores.Length + " registros.";
                
                ArrayList Camposdet = new ArrayList();
                Camposdet.Add("ID_INFRACTOR=INFRACTOR");
                Camposdet.Add("NROIDENTIFICACION=IDENTIFICACION");
                Camposdet.Add("NOMBRES=NOMBRES");
                Camposdet.Add("APELLIDOS=APELLIDOS");
                Camposdet.Add("DIRECCION=DIRECCION");
                Camposdet.Add("TELEFONO=TELEFONO");
                Camposdet.Add("ID_DOCTO=ID_DOCTO");

                DtInfractores = funcion.ToDataTableEnOrden(funcion.ObjectToArrayList(listaInfractores), Camposdet);

                grdInfractor.DataSource = DtInfractores;
                funcion.configurarGrillaEnOrden(grdInfractor, Camposdet);
                
                //Ocultar id docto
                grdInfractor.Columns["ID_DOCTO"].Visible = false;                

                DtInfractores.Select();
            }
            else
            {
                label3.Text = "Proceso de consulta finalizado. Resultados: 0 registros.";
                funcion.mostrarMensaje("No se encontraron infractores para las fechas ingresadas", "W");
            }
        }
       
        //GENERAR PLANTILLA WORD
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                if (grdInfractor.SelectedRows.Count > 0)
                {
                    //Obtener Numero de Filas Seleccionadas
                    //int fila = this.grdInfractor.CurrentRow.Index;                    
                    List<string> listWord = new List<string>();
                    
                    string pathTemp = Path.GetTempPath();
                    string pathFile = string.Empty;                    
                    string nameFile = string.Empty;

                    // string pathTemplate = string.Concat(Application.StartupPath, "\\Comparendos.dotx");


                    DataGridViewSelectedRowCollection infractoresSeleccionados = grdInfractor.SelectedRows;
                    int totalInfractores = infractoresSeleccionados.Count;
                    int inicio = grdInfractor.SelectedRows[totalInfractores-1].Index;


                    //bool seleccionoAlMenosUno = false;

                    for (int i = inicio; i < inicio + totalInfractores; i++)
                    {
                        //int idInfractor = Convert.ToInt32(infractoresSeleccionados[i].Cells["INFRACTOR"].Value.ToString());
                        int idInfractor = Convert.ToInt32(grdInfractor.Rows[i].Cells["INFRACTOR"].Value.ToString());
                        
                        DtComparendosInfractorTemp = new DataTable("Tabla Comparendos");
                        DtComparendosInfractorTemp = ObtenerComparendosInfractor(idInfractor);
                            
                        //Crea los documentos y los almacena en la carpeta temporal de windows
                        nameFile = string.Concat(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour,
                            DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond);
                        pathFile = string.Concat(pathTemp, nameFile, ".doc");
                        listWord.Add(pathFile);
                            
                        //Invocar Metodo para cargar datos plantillapathTemplate
                        ExecuteWord(pathFile, i, ref DtComparendosInfractorTemp);
                    }

                    
                    //Lista que contine los archivos generados
                    if (listWord.Count > 0)
                    {
                        nameFile = string.Concat(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour,
                            DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond);
                        pathFile = string.Concat(pathTemp, nameFile, ".doc");
                        //Invocar Metodo para  Generar Combinacion de archivos 
                        Merge(listWord, pathFile, true);
                        for (int j = 0; j < listWord.Count; j++)
                        {
                            File.Delete(listWord[j].ToString());
                        }
                        // string FileNamea = @"\\186.147.240.102\Users\Public\Notificaciones.doc";
                        ServiciosConfiguracionesService serviciosConfiguraciones = WS.ServiciosConfiguracionesService();
                        string fileName = serviciosConfiguraciones.leerRegistroIni("DOCUMENTOS") + "\\" + "Comparendos.doc";
                        Transferir.archivoAlServer(pathFile, fileName);
                        OpenFile(pathFile);
                    }
                    else
                        MessageBox.Show("No existen documentos para generar");                    
                }
                else
                {
                    //MessageBox.Show("No existen datos de infractores para esa fecha.");
                    MessageBox.Show("Debe Seleccionar al menos un Infractor para generar notificaciones");
                }
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error realizando la funcionalidad: " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }

            this.Cursor = Cursors.Arrow;
        }

        //Metodo para llenar plantilla con las tablas
        public void ExecuteWord(string pathFile,  int filaActual, ref DataTable DtClonComparendo)
        {
            try
            {
                //SERVICIO PARA OBTENER NOMBRE ALCALDIA-SECRETARIA TRANSITO
                ServiciosGeneralesCompService serviciosGenComp;
                serviciosGenComp = WS.ServiciosGeneralesCompService();
                
                transitoComp myTransito;
                myTransito = new transitoComp();
                myTransito = serviciosGenComp.getTransitoComp(myTransito);

                //SERVICIO PARA OBTENER NOMBRE CIUDAD
                ServiciosAccesoriasCompService ServAcces = WS.ServiciosAccesoriasCompService();
                ciudadComp myCity = new ciudadComp();
                myCity.ID_CIUDAD = myTransito.ID_CIUDAD;
                myCity = (ciudadComp)((object[])ServAcces.getCiudadComp(myCity))[0];
                               
               
                //Cargar dcto en servidor
                ServiciosConfiguracionesService serviciosConfiguraciones = WS.ServiciosConfiguracionesService();
                object fileName = serviciosConfiguraciones.leerRegistroIni("PLANTILLAS") + "\\" + "Comparendos.dotx";
                
                ServiciosDocumentosService mySerDocumento = WS.ServiciosDocumentosService();
                transferir myTransferencia = new transferir();
                myTransferencia.archivoDelServerSinAbrir((string)fileName);

                
                // Inicia  Word y  abre la plantilla.
                this.oWord = new Word.Application();             
               
                // Ubicación de la plantilla en el disco duro  
               // fileName pathTemplate
                object newTmp = System.Reflection.Missing.Value;
                object DocType = false;
                object visible = true;
                oDoc = oWord.Documents.Add(ref fileName, ref newTmp, ref DocType, ref visible);
            
                if (DtInfractores.Rows.Count > 0)
                {
                    // Obtengo el primer registro para llenar los textbox de cabecera
                    DataRow oCabecera = DtInfractores.Rows[filaActual];
                      
                    //SERVICIO PARA OBTENER TIPO DOCUMENTO
                    object[] objs;
                    documentoComp documento = new documentoComp();
                    documento.ID_DOCCOMP = int.Parse(oCabecera["ID_DOCTO"].ToString());
                    objs = ServAcces.obtenerTipoDocumento(documento);

                    //Servicios para obtener formato fecha
                    ServiciosAccesoriasService servicioAccesorios = WS.ServiciosAccesoriasService();
                    string fecha = servicioAccesorios.getFechaActualTexto();//revisar el formato

                    // obtener el Marcador y asignar el dato que tenga la tabla
                    object objTmp = "NOMBREALCALDIA";
                    oDoc.Bookmarks.get_Item(ref objTmp).Range.Text = myTransito.NOMBREALCALDIA;
                    objTmp = "SECRETARIOTRANSITO";
                    oDoc.Bookmarks.get_Item(ref objTmp).Range.Text = myTransito.DESCRIPCION;
                    objTmp = "NOMBREFUNCIONARIO";
                    oDoc.Bookmarks.get_Item(ref objTmp).Range.Text = myTransito.SECRETARIOTRANSITO;
                    objTmp = "CIUDAD";
                    oDoc.Bookmarks.get_Item(ref objTmp).Range.Text = myCity.NOMBRE;
                    objTmp = "DESDOCUMENTO";
                    oDoc.Bookmarks.get_Item(ref objTmp).Range.Text = ((documentoComp)objs[0]).DESCRIPCION;
                    objTmp = "DESDOCUMENTO2";
                    oDoc.Bookmarks.get_Item(ref objTmp).Range.Text = ((documentoComp)objs[0]).DESCRIPCION;
                    objTmp = "NOMBREINFRACTOR";
                    oDoc.Bookmarks.get_Item(ref objTmp).Range.Text = oCabecera["NOMBRES"].ToString();
                    objTmp = "APELLIDOS";
                    oDoc.Bookmarks.get_Item(ref objTmp).Range.Text = oCabecera["APELLIDOS"].ToString();
                    objTmp = "IDENTIFICACION";
                    oDoc.Bookmarks.get_Item(ref objTmp).Range.Text = oCabecera["IDENTIFICACION"].ToString();
                    objTmp = "DIRECCION";
                    oDoc.Bookmarks.get_Item(ref objTmp).Range.Text = oCabecera["DIRECCION"].ToString();
                    objTmp = "TELEFONOINFRACTOR";
                    oDoc.Bookmarks.get_Item(ref objTmp).Range.Text = oCabecera["TELEFONO"].ToString();
                    objTmp = "IDENTIFICACION2";
                    oDoc.Bookmarks.get_Item(ref objTmp).Range.Text = oCabecera["IDENTIFICACION"].ToString();
                    objTmp = "NOMBRE2";
                    oDoc.Bookmarks.get_Item(ref objTmp).Range.Text = oCabecera["NOMBRES"].ToString();
                    objTmp = "APELLIDO2";
                    oDoc.Bookmarks.get_Item(ref objTmp).Range.Text = oCabecera["APELLIDOS"].ToString();
                    objTmp = "FECHASISTEMA";
                    oDoc.Bookmarks.get_Item(ref objTmp).Range.Text = fecha;
                   

                    // Genero la tabla de partidas
                    Word.Table oTable;

                    objTmp = "COMPARENDO";
                    oTable = oDoc.Tables.Add(oDoc.Bookmarks.get_Item(ref objTmp).Range, this.DtComparendosInfractorTemp.Rows.Count, 5, ref newTmp, ref newTmp);

                    for (int r = 0; r <= this.DtComparendosInfractorTemp.Rows.Count - 1; r++)
                    {
                        oTable.Cell(r + 1, 1).Range.Text = this.DtComparendosInfractorTemp.Rows[r][3].ToString();
                        oTable.Cell(r + 1, 2).Range.Text = this.DtComparendosInfractorTemp.Rows[r][21].ToString();
                        oTable.Cell(r + 1, 3).Range.Text = this.DtComparendosInfractorTemp.Rows[r][26].ToString();
                        oTable.Cell(r + 1, 4).Range.Text = this.DtComparendosInfractorTemp.Rows[r][38].ToString();
                        oTable.Cell(r + 1, 5).Range.Text = String.Format("{0:c}", Convert.ToDouble(this.DtComparendosInfractorTemp.Rows[r][39].ToString()));
                    }

                    // Ajustamos un poco el tamaño de las columnas para adecuarlas al formato
                    oTable.Columns[1].Width = 80;
                    oTable.Columns[2].Width = 100;
                    oTable.Columns[3].Width = 80;
                    oTable.Columns[4].Width = 80;
                    oTable.Columns[5].Width = 80;
                    oTable.Columns[5].Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                    //Cargar y guardar archivos generados
                    object outputFile = pathFile;
                    object missing = System.Type.Missing;
                    oDoc.SaveAs(ref outputFile, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);

                    object savechange = Word.WdSaveOptions.wdDoNotSaveChanges;
                    oDoc.Close(ref savechange, ref newTmp, ref newTmp);
                }
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
            finally
            {
                object oMissing = System.Reflection.Missing.Value;
                oWord.Quit(ref oMissing, ref oMissing, ref oMissing);
            }  

        }

        //Metodo para abrir archivo
        private void OpenFile(string pathFile)
        {
            Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = pathFile;
            proc.Start();
        }

        public DataTable ObtenerComparendosInfractor(int idInfractor)
	     {                           
            try
            {                
                infractorComp InfractorComp=null;
                
                for (int i = 0; i < listaInfractores.Length; i++)
                {
                    InfractorComp = (infractorComp)listaInfractores[i];
                    if (idInfractor.Equals(InfractorComp.ID_INFRACTOR))
                    {
                        break;
                    }
                }

                ArrayList Camposdet = new ArrayList();
                Camposdet.Add("NUMEROCOMPARENDO=NUMERO");
                Camposdet.Add("PLACA= PLACA");
                Camposdet.Add("FECHACOMPARENDO=FECHA");
                Camposdet.Add("VALORINFRACCION=VALOR");
                Camposdet.Add("COD_INFRACCION=CODIGO INFRACCION");
                Camposdet.Add("NUEVO_CODIGO=CODIGO");

                if (InfractorComp.listaComparendo != null)
                {
                    DtComparendos = funcion.ToDataTable(funcion.ObjectToArrayList(InfractorComp.listaComparendo));

                    DtComparendos.Columns.Add("COD_INFRACCION", typeof(string));
                    DtComparendos.Columns.Add("VALORINFRACCION", typeof(double));
                    DtComparendos.Columns.Add("NUEVO_CODIGO", typeof(string));

                    for (int i = 0; i < InfractorComp.listaComparendo.Length; i++)
                    {
                        comparendoComp objcomparendo = (comparendoComp)InfractorComp.listaComparendo[i];
                        //objcomparendo.objInfracionComparendoComp.VALORINFRACCION
                        
                        DtComparendos.Rows[i]["COD_INFRACCION"] = objcomparendo.objInfraccionesComp != null ? 
                            objcomparendo.objInfraccionesComp.COD_INFRACCION : "";
                        DtComparendos.Rows[i]["NUEVO_CODIGO"] = objcomparendo.objInfraccionesComp != null ?
                            objcomparendo.objInfraccionesComp.NUEVO_CODIGO : "";
                        DtComparendos.Rows[i]["VALORINFRACCION"] = objcomparendo.objInfracionComparendoComp != null ?
                            objcomparendo.objInfracionComparendoComp.VALORINFRACCION : 0;
                    }

                    dgvComparendos.DataSource = DtComparendos;
                    funcion.configurarGrilla(dgvComparendos, Camposdet);
                }
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }

            return DtComparendos;
        }

        //Metodo para realizar la combinacion de Documentos generados por cada fila chekeada en la grilla
        public void Merge(List<string> filesToMerge, string outputFilename, bool insertPageBreaks)
        {
            object missing = System.Type.Missing;
            object pageBreak = Word.WdBreakType.wdPageBreak;
            object outputFile = outputFilename;

            // Create  a new Word application
            Word._Application wordApplication = new Word.Application();

            try
            {
                // Create a new file based on our template
                Word._Document wordDocument = wordApplication.Documents.Add(ref missing, ref missing, ref missing, ref missing);

                // Make a Word selection object.
                Word.Selection selection = wordApplication.Selection;

                // Loop thru each of the Word documents
                foreach (string file in filesToMerge)
                {
                    // Insert the files to our template
                    selection.InsertFile(file, ref missing, ref missing, ref missing, ref missing);

                    //Do we want page breaks added after each documents?
                    if (insertPageBreaks)
                    {
                        selection.InsertBreak(ref pageBreak);
                    }
                }

                // Save the document to it's output file.
                wordDocument.SaveAs(ref outputFile, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);

                // Clean up!
                object oMissing = System.Reflection.Missing.Value;
                object oSaveChange = Word.WdSaveOptions.wdDoNotSaveChanges;
                wordDocument.Close(ref oSaveChange, ref oMissing, ref oMissing);
                //wordDocument = null;
            }
            catch (Exception ex)
            {
                //I didn't include a default error handler so i'm just throwing the error
                log.escribirError(ex.ToString(), this.GetType());
                throw ex;
            }
            finally
            {
                // Finally, Close our Word application       
                object oMissing = System.Reflection.Missing.Value;
                wordApplication.Quit(ref oMissing, ref oMissing, ref oMissing);
            }
        }





        //validar control fecha
        private void dateTPickFechaInicial_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                funcion.lanzarTapConEnter(e);
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void dateTPickFechaFinal_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {                
                funcion.lanzarTapConEnter(e);
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void grdInfractor_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdInfractor.SelectedRows.Count > 0)
                {
                    int idInfractor = Convert.ToInt32(grdInfractor.SelectedRows[0].Cells["INFRACTOR"].Value.ToString());
                    //grdInfractor.SelectedRows[0].Cells["Seleccion"].Value = !(bool)grdInfractor.SelectedRows[0].Cells["Seleccion"].Value;
                    //Boolean seleccionado = false;
                    //Boolean.TryParse(grdInfractor.SelectedRows[0].Cells[7].Value.ToString(), out seleccionado);
                    //grdInfractor.SelectedRows[0].Cells[7].Value = !seleccionado;
                    ObtenerComparendosInfractor(idInfractor);
                }
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error realizando la funcionalidad: " + exp.Message);
            }
        }

       

       
    }
}
      