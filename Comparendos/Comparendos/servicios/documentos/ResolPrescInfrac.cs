using System; using TransitoPrincipal; using LibreriasSintrat.utilidades;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibreriasSintrat.ServiciosAccesoriasComp;
using LibreriasSintrat.ServiciosGeneralesComp;
using LibreriasSintrat.ServiciosDocumentos;
using LibreriasSintrat.ServiciosUsuarios;
using LibreriasSintrat.ServiciosConfiguraciones;
using LibreriasSintrat.ServiciosGenerales;
using Word = Microsoft.Office.Interop.Word;
using Comparendos.utilidades; 
using LibreriasSintrat;

namespace Comparendos.servicios.documentos
{
    public partial class ResolPrescInfrac : Form
    {
        private usuarios myUsuario;

        private infractorComp myInfractor;
        private Object[] myComparendos;

        private int numResolucion;
        
        private plantilla myPlantilla;
        private tipoResolucionComp myTipoResolucion;

        Funciones funciones;
        Boolean bandera;

        ServiciosGeneralesService serviciosGenerales;
        ServiciosDocumentosService serviciosDocumentos;
        ServiciosGeneralesCompService serviciosGeneralesComp;
        ServiciosConfiguracionesService serviciosConfiguraciones;
        
        Log log = new Log();

        public ResolPrescInfrac(usuarios user)
        {
            InitializeComponent();            

            serviciosGenerales = WS.ServiciosGeneralesService();
            serviciosDocumentos = WS.ServiciosDocumentosService();
            serviciosGeneralesComp = WS.ServiciosGeneralesCompService();
            serviciosConfiguraciones = WS.ServiciosConfiguracionesService();

            funciones = new Funciones();
            bandera = true;

            myUsuario = user;
            numResolucion = -1;
        }

        private void ResolPrescInfrac_Load(object sender, EventArgs e)
        {
            try
            {                
                btnGenerarResolucion.Enabled = false;
                cargarCombos();
                cmbBoxTipoDoc.SelectedIndex = 0;
                txtDocumento.Focus();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        public void cargarCombos()
        {
            ServiciosAccesoriasCompService serviciosAccesoriasComp = WS.ServiciosAccesoriasCompService();
            Object[] arreglo;

            arreglo = (Object[])serviciosAccesoriasComp.obtenerTiposDocumento();
            funciones.llenarCombo(cmbBoxTipoDoc, arreglo);

            plantilla myTmpPlantilla = new plantilla();
            myTmpPlantilla.IDTIPORESOLUCION = 6;
            arreglo = (Object[])serviciosDocumentos.buscarPlantillasComp(myTmpPlantilla);
            funciones.llenarCombo(cmbBoxPlantillas, arreglo);

            cmbBoxPlantillas.SelectedIndex = -1;
        }

        public void buscarInfractor()
        {
            myInfractor = new infractorComp();

            myInfractor.ID_DOCTO = (int)cmbBoxTipoDoc.SelectedValue;
            myInfractor.NROIDENTIFICACION = txtDocumento.Text;

            myInfractor = serviciosGeneralesComp.buscarInfractor(myInfractor);

            if (myInfractor != null && myInfractor.ID_INFRACTOR >= 0)
            {
                mostrarInfoInfractor();
                cargarComparendosInfractor();
                dtGrViewComparendos.Focus();
            }
            else
                MessageBox.Show("Verifique la informacion ingresada!!!", "Infractor no encontrado");
        }

        public void cargarComparendosInfractor()
        {
            limpiarComparendos();
            
            String filtroEstados;
            String[] estados;
            Object[] tmpComparendos;

            viewComparendosResolSancionComp myCompResoSanc = new viewComparendosResolSancionComp();
            myCompResoSanc.ID_INFRACTOR = myInfractor.ID_INFRACTOR;

            filtroEstados = serviciosGeneralesComp.obtenerEstadosResolPrescripcion();

            if (!string.IsNullOrEmpty(filtroEstados))
            {
                estados = filtroEstados.Split(',');

                for (int i = 0; i < estados.Length; i++)
                {
                    myCompResoSanc.ID_ESTADO = int.Parse(estados[i]);

                    tmpComparendos = (Object[])serviciosGeneralesComp.obtenerComparendosResolSancion(myCompResoSanc);
                    myComparendos = funciones.unirArrayObject(myComparendos, tmpComparendos);
                }

                if (myComparendos != null && myComparendos.Length > 0)
                {
                    mostrarComparendos();
                    bandera = true;
                }
                else
                {
                    if (bandera != false)
                        MessageBox.Show("El infractor no presenta comparendos", "Información no encontrada");
                    bandera = true;
                }
            }
            else
            {
                MessageBox.Show("Debe configurar los estados de resolución de sanción en la base de datos.", "Información no encontrada");
            }
        }

        public void mostrarInfoInfractor()
        {
            txtInfractor.Text = myInfractor.NOMBRES + " " + myInfractor.APELLIDOS;
            txtDireccion.Text = myInfractor.DIRECCION;
            txtTelefono.Text = myInfractor.TELEFONO;
        }

        public void mostrarComparendos()
        {
            DataTable dt = new DataTable();
            ArrayList campos = new ArrayList();

            campos.Add("NUMEROCOMPARENDO = NUMEROCOMPARENDO");
            campos.Add("FECHACOMPARENDO = FECHACOMPARENDO");
            campos.Add("NUEVO_CODIGO = NUEVO_CODIGO");
            campos.Add("ESTADO = ESTADO");
            campos.Add("PLACA = PLACA");
            campos.Add("DESCRIPCION = DESCRIPCION");
            campos.Add("COD_INFRACCION = COD_INFRACCION");

            campos.Add("ID = ID");
            campos.Add("ID_COMPARENDO = ID_COMPARENDO");
            campos.Add("ID_ESTADO = ID_ESTADO");
            campos.Add("ID_INFRACTOR = ID_INFRACTOR");
            campos.Add("ID_SERVICIO = ID_SERVICIO");
            campos.Add("IDINFRACCION = IDINFRACCION");

            dt = funciones.ToDataTableEnOrden(funciones.ObjectToArrayList(myComparendos), campos);
            dtGrViewComparendos.DataSource = dt;

            if (dt != null && dt.Rows.Count > 0)
            {
                funciones.configurarGrilla(dtGrViewComparendos, campos);

                //Ocultar campos
                dtGrViewComparendos.Columns["ID"].Visible = false;
                dtGrViewComparendos.Columns["ID_COMPARENDO"].Visible = false;
                dtGrViewComparendos.Columns["ID_ESTADO"].Visible = false;
                dtGrViewComparendos.Columns["ID_INFRACTOR"].Visible = false;
                dtGrViewComparendos.Columns["ID_SERVICIO"].Visible = false;
                dtGrViewComparendos.Columns["IDINFRACCION"].Visible = false;
            }
        }

        

        public void limpiarComparendos()
        {
            dtGrViewComparendos.DataSource = null;
            myComparendos = null;
        }

        private bool validarDatos()
        {            
            if (cmbBoxPlantillas.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar una plantilla.");
                cmbBoxPlantillas.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtNumResol.Text))
            {
                MessageBox.Show("El campo número de resolución es obligatorio.");
                txtNumResol.Focus();
                return false;
            }

            return true;
        }

        private void btnGenerarResolucion_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                if (validarDatos())
                {
                    if (dtGrViewComparendos.SelectedCells.Count > 0)
                    {
                        numResolucion = int.Parse(txtNumResol.Text);

                        DataGridViewSelectedRowCollection comparendosSeleccionados = dtGrViewComparendos.SelectedRows;

                        int totalComparendos = comparendosSeleccionados.Count;
                        int countResolucionesGeneradas = 0;

                        bool abrirArchivo = true;
                        if (totalComparendos > 1)
                            abrirArchivo = false;

                        string message = "";

                        for (int i = 0; i < totalComparendos; i++)
                        {
                            viewComparendosResolSancionComp infoComparendo = (viewComparendosResolSancionComp)funciones.listToViewCompResolSanc(comparendosSeleccionados[i]);
                            resolucionesComparendoComp myResolucionComparendo = new resolucionesComparendoComp();

                            GenerarResoluciones generarResolucion = new GenerarResoluciones();

                            string fechaResolucion = funciones.convFormatoFecha(dtPickFechaResolucion.Text, "MM/dd/yyyy");

                            myResolucionComparendo.IDUSUARIO = myUsuario.ID_USUARIO;
                            myResolucionComparendo.FECHAAUDIENCIA = funciones.convFormatoFecha(dtPickFechaAudiencia.Text, "MM/dd/yyyy");
                            myResolucionComparendo.FECHA = fechaResolucion;
                            myResolucionComparendo.MOTIVO = txtMotivo.Text;
                            myResolucionComparendo.CONSIDERACIONJURIDICA = txtConsidJurid.Text;
                            myResolucionComparendo.ID_TIPORESOLUCION = myPlantilla.IDTIPORESOLUCION;


                            
                            
                            //VALIDAR FECHA PRESCRIPCIÓN
                            if (validarPrescripcion(infoComparendo))
                            {
                                //Crear resolución Prescripción                            
                                generarResolucion.crearResolucion(abrirArchivo, "ResolucionPrescripcionInfractor.dotx", numResolucion, myInfractor, myTipoResolucion, myUsuario, fechaResolucion, myPlantilla, infoComparendo, ref myResolucionComparendo);

                                //Actualizar número de resolución y contador de generadas
                                numResolucion++;
                                countResolucionesGeneradas++;
                            }
                            else
                            {
                                message += "Algunos de los comparendos seleccionados aún no han prescrito. Por favor revise las fechas pertinentes. ";
                            }
                        }
                        
                        message += countResolucionesGeneradas + " resolucion(es) creada(s) de " + totalComparendos + " comparendo(s) seleccionado(s).";
                        if (!abrirArchivo)
                            message += " Los archivos han sido almacenados en: " + serviciosConfiguraciones.leerRegistroIni("RESOLUCIONES");

                        MessageBox.Show(message, "Terminado", 0, MessageBoxIcon.Information);
                        bandera = false;
                        cargarComparendosInfractor();
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar al menos un comparendo!");
                        dtGrViewComparendos.Focus();
                    }
                }
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message + " -Por favor cierre los documentos de resoluciones abiertos.");
            }

            this.Cursor = Cursors.Arrow;
        }

        //Valida si el comparendo actual ya prescribió
        private bool validarPrescripcion(viewComparendosResolSancionComp infoComparendo)
        {
            bool prescribio = false;

            ServiciosAccesoriasCompService serviciosAccesoriasComp = WS.ServiciosAccesoriasCompService();
            string fechaServidor = serviciosAccesoriasComp.getFechaHora("MM/dd/yyyy hh:mm:ss");
            DateTime dtFechaServidor = DateTime.Parse(fechaServidor, System.Globalization.CultureInfo.InvariantCulture);

            //Obtener las resoluciones generadas para la infracción
            int idInfraccion = infoComparendo.IDINFRACCION;
            resolucionInfraccionesComp myResolucionInfraccion = new resolucionInfraccionesComp();
            myResolucionInfraccion.IDINFRACCION = idInfraccion;

            object[] resolucionInfracciones = serviciosDocumentos.obtenerResolucionInfracciones(myResolucionInfraccion);

            if (resolucionInfracciones != null && resolucionInfracciones.Length > 0)
            {
                //Buscar una resolución de sanción entre las resoluciones encontradas
                foreach (resolucionInfraccionesComp resolucionInfraccion in resolucionInfracciones)
                {
                    int idTipoResolucion = 1; //Resolución de Sanción

                    viewResolucionesInfractorComp myResolucionInfractor = new viewResolucionesInfractorComp();
                    myResolucionInfractor.ID_RESOLUCION = resolucionInfraccion.IDRESOLUCION;
                    myResolucionInfractor.ID_TIPORESOLUCION = idTipoResolucion;

                    object[] resolucionesInfractor = serviciosDocumentos.obtenerResolucionesInfractor(myResolucionInfractor);

                    if (resolucionesInfractor != null && resolucionesInfractor.Length > 0)
                    {
                        viewResolucionesInfractorComp resolucionDeSancion = (viewResolucionesInfractorComp)resolucionesInfractor[0];
                        DateTime dtFechaResolucion = DateTime.Parse(resolucionDeSancion.FECHA, System.Globalization.CultureInfo.InvariantCulture);

                        TimeSpan diffFechas = dtFechaServidor - dtFechaResolucion;
                        int totalDias = diffFechas.Days;
                        double aniosTranscurridos = Math.Truncate(totalDias/365.242);

                        if (aniosTranscurridos > 3)
                            return true;
                        else
                            return false;
                    }
                }
            }
            
            return prescribio;
        }

        //private void btnGenerarResolucion_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        viewComparendosResolSancionComp infoComparendo = new viewComparendosResolSancionComp();
        //        resolucionesComparendoComp myResolucionComparendo = new resolucionesComparendoComp();
        //        resolucionInfraccionesComp myResolucionInfraccion = new resolucionInfraccionesComp();
        //        infracionComparendoComp myInfraccionComparendo = new infracionComparendoComp();//no uso
        //        historicoEstadosComp myHistoricoComparendos = new historicoEstadosComp();

        //        String nombreResolucion;

        //        if (validarDatos())
        //        {
        //            if (dtGrViewComparendos.SelectedCells.Count > 0)
        //            {
        //                numResolucion = int.Parse(txtNumResol.Text);
        //                nombreResolucion = "";

        //                DataGridViewSelectedRowCollection comparendosSeleccionados = dtGrViewComparendos.SelectedRows;

        //                int totalComparendos = comparendosSeleccionados.Count;
        //                int countResolucionesGeneradas = 0;

        //                for (int i = 0; i < totalComparendos; i++)
        //                {
        //                    infoComparendo = (viewComparendosResolSancionComp)funciones.listToViewCompResolSanc(comparendosSeleccionados[i]);

        //                    myResolucionComparendo = new resolucionesComparendoComp();
        //                    myResolucionInfraccion = new resolucionInfraccionesComp();

        //                    myResolucionComparendo.IDUSUARIO = myUsuario.ID_USUARIO;
        //                    myResolucionComparendo.FECHAAUDIENCIA = funciones.convFormatoFecha(dtPickFechaAudiencia.Text, "MM/dd/yyyy");
        //                    myResolucionComparendo.FECHA = funciones.convFormatoFecha(dtPickFechaResolucion.Text, "MM/dd/yyyy");
        //                    myResolucionComparendo.MOTIVO = txtMotivo.Text;
        //                    myResolucionComparendo.CONSIDERACIONJURIDICA = txtConsidJurid.Text;
        //                    myResolucionComparendo.ID_TIPORESOLUCION = myPlantilla.IDTIPORESOLUCION;

        //                    numResolucion = serviciosDocumentos.obtenerNumeroResolucionComp(numResolucion);
        //                    myResolucionComparendo.NUMERO = numResolucion.ToString();

        //                    nombreResolucion = funciones.quitarEspacios(myInfractor.NROIDENTIFICACION.ToString());
        //                    nombreResolucion += "_" + myResolucionComparendo.NUMERO + "_" + myTipoResolucion.DES_TIPORESOLUCION;
        //                    myResolucionComparendo.NOMBRE = nombreResolucion;


        //                    //SE GENERA LA RESOLUCIÓN Y SE SUBE AL SERVIDOR
        //                    generarResolucion(myResolucionComparendo, infoComparendo);


        //                    //fija el contenido de la plantilla modificada y registra la resolucion
        //                    myResolucionComparendo.CONTENIDO = "<t>" + myPlantilla.ENCABEZADO + "<->\n\n\n";
        //                    myResolucionComparendo.CONTENIDO += myPlantilla.CONTENIDO;

        //                    myResolucionComparendo = serviciosDocumentos.insertarResolucionComparendo(myResolucionComparendo, WS.MyUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName());


        //                    //ACTUALIZAR INFRACCION COMPARENDO
        //                    myInfraccionComparendo = new infracionComparendoComp();
        //                    myInfraccionComparendo.IDCOMPARENDO = infoComparendo.ID_COMPARENDO;
        //                    myInfraccionComparendo.IDINFRACCION = infoComparendo.IDINFRACCION; //Se obtiene el id de infracComp
        //                    myInfraccionComparendo = serviciosGeneralesComp.getInfraccionComparendo(myInfraccionComparendo);

        //                    //ResolucionesInfracciones
        //                    myResolucionInfraccion.IDRESOLUCION = myResolucionComparendo.ID;
        //                    myResolucionInfraccion.IDINFRACCION = myInfraccionComparendo.ID;
        //                    myResolucionInfraccion = serviciosDocumentos.insertarResolucionInfracciones(myResolucionInfraccion, WS.MyUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName());

        //                    //Se cambia el estado del comparendo en la base de datos
        //                    myInfraccionComparendo.IDESTADO = myTipoResolucion.ID_NUEVOESTADO;
        //                    serviciosGeneralesComp.cambiarEstadoComp(myInfraccionComparendo, WS.MyUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName());

        //                    //se pone el nuevo estado en historico estados
        //                    myHistoricoComparendos = new historicoEstadosComp();
        //                    myHistoricoComparendos.ID_ESTADO = myTipoResolucion.ID_NUEVOESTADO;
        //                    myHistoricoComparendos.ID_INFRACCIONCOMPARENDO = myInfraccionComparendo.ID;
        //                    myHistoricoComparendos.IDUSUARIO = myUsuario.ID_USUARIO;
        //                    myHistoricoComparendos.FECHA = funciones.convFormatoFecha(dtPickFechaResolucion.Text, "MM/dd/yyyy");
        //                    serviciosGeneralesComp.insertarHistoricoEstadosComp(myHistoricoComparendos);

        //                    numResolucion++;
        //                    countResolucionesGeneradas++;
        //                }

        //                MessageBox.Show(countResolucionesGeneradas + " resolucion(es) creada(s) de " + totalComparendos + " comparendo(s) seleccionado(s).", "Terminado", 0, MessageBoxIcon.Information);
        //                cargarComparendosInfractor();
        //            }
        //            else
        //            {
        //                MessageBox.Show("Debe seleccionar al menos un comparendo!");
        //                dtGrViewComparendos.Focus();
        //            }
        //        }
        //    }
        //    catch (Exception exp)
        //    {
        //        log.escribirError(exp.ToString(), this.GetType());
        //        MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
        //        //Console.WriteLine(exp.Message);
        //        //Console.WriteLine(exp.StackTrace);
        //    }
        //}
        
        //public void generarResolucion(resolucionesComparendoComp myResolucionesComparendo, viewComparendosResolSancionComp infoComparendo)
        //{
        //    String param;                                                
        //    Object[] parametros = new Object[3];

        //    param = "FECHARESOLUCION = " + DateTime.Parse(myResolucionesComparendo.FECHA, System.Globalization.CultureInfo.InvariantCulture).ToString("dd/MM/yyyy");
        //    parametros[0] = param;
        //    param = "NUMRESOLUCION = " + myResolucionesComparendo.NUMERO;
        //    parametros[1] = param;
        //    param = "FECHAAUDIENCIA = " + DateTime.Parse(myResolucionesComparendo.FECHAAUDIENCIA, System.Globalization.CultureInfo.InvariantCulture).ToString("dd/MM/yyyy");
        //    parametros[2] = param;
            
        //    myPlantilla = serviciosDocumentos.procesarPlantillaValores(myPlantilla, parametros);
            
        //    parametros = new Object[2];
        //    param = "ID_INFRACTOR = "+myInfractor.ID_INFRACTOR;
        //    parametros[0] = param;
        //    param = "ID_COMPARENDO = " + infoComparendo.ID_COMPARENDO;
        //    parametros[1] = param;
        //    myPlantilla = serviciosDocumentos.procesarPlantillaComp(myPlantilla, parametros);

        //    String nombreDocumento = myResolucionesComparendo.NOMBRE;
        //    generarWord(myPlantilla, nombreDocumento, "ResolucionPrescripcionInfractor.dotx");
        //}

        //private void generarWord(plantilla myPlantilla, string nombreDocumento, string nombrePlantilla)
        //{
        //    //*****///// PARTE PARA LA GENERACION DE DOCUMENTO DE RESOLUCION DE INFRACTOREN WORD
        //    //Start Word and open the document template.
        //    // Objetos de word
        //    Word.Application oWord = new Word.Application();
        //    Word.Document oDoc;
        //    transferir myTransferencia = new transferir();

        //    object rutaPlantilla = serviciosConfiguraciones.leerRegistroIni("PLANTILLAS") + "\\" + nombrePlantilla;
        //    myTransferencia.archivoDelServerSinAbrir((string)rutaPlantilla);

        //    oWord.Visible = false;

        //    object newTmp = System.Reflection.Missing.Value;
        //    object DocType = false;
        //    object visible = true;

        //    // Ubicación de la plantilla en el disco duro
        //    oDoc = oWord.Documents.Add(ref rutaPlantilla, ref newTmp, ref DocType, ref visible);

        //    // Verifico que la consulta tenga datos
        //    if (myPlantilla.ENCABEZADO != null)
        //    {
        //        object objTmp;
        //        objTmp = "ENCABEZADO";
        //        myPlantilla.ENCABEZADO = myPlantilla.ENCABEZADO.Replace("<t>", "");
        //        oDoc.Bookmarks.get_Item(ref objTmp).Range.Text = myPlantilla.ENCABEZADO.Replace("<->", "");
        //    }
        //    if (myPlantilla.CONTENIDO != null)
        //    {
        //        object objTmp;
        //        objTmp = "CONTENIDO";
        //        myPlantilla.CONTENIDO = myPlantilla.CONTENIDO.Replace("<t>", "");
        //        oDoc.Bookmarks.get_Item(ref objTmp).Range.Text = myPlantilla.CONTENIDO.Replace("<->", "");
        //    }


        //    //SUBIR ARCHIVO AL SERVIDOR
        //    string directorioResoluciones = serviciosConfiguraciones.leerRegistroIni("RESOLUCIONES");
        //    string nombreDocumentoExtension = nombreDocumento + ".doc";
        //    object rutaResolucion = directorioResoluciones + "\\" + nombreDocumentoExtension;

        //    //Specifying the format in which you want the output file 
        //    object format = Word.WdSaveFormat.wdFormatDocument;

        //    // Use for the parameter whose type are not known or  
        //    // say Missing
        //    object Unknown = Type.Missing;

        //    //Changing the format of the document
        //    oWord.ActiveDocument.SaveAs(ref rutaResolucion, ref format,
        //            ref Unknown, ref Unknown, ref Unknown,
        //            ref Unknown, ref Unknown, ref Unknown,
        //            ref Unknown, ref Unknown, ref Unknown,
        //            ref Unknown, ref Unknown, ref Unknown,
        //            ref Unknown, ref Unknown);

        //    //for closing the application
        //    oWord.Quit(ref Unknown, ref Unknown, ref Unknown);

        //    //Tiempo para que word cierre la app
        //    System.Threading.Thread.Sleep(1000);

        //    //Enviar archivo al servidor
        //    myTransferencia.archivoAlServer(rutaResolucion.ToString(), rutaResolucion.ToString());

        //    //Abrir archivo
        //    System.Diagnostics.Process.Start(rutaResolucion.ToString());
        //}

        

        private void txtNumResol_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && txtNumResol.Text != "")
                {
                    if (serviciosDocumentos.validarNumeroResolucionComp(txtNumResol.Text))
                    {
                        btnGenerarResolucion.Enabled = true;
                        numResolucion = int.Parse(txtNumResol.Text);                        
                    }
                    else
                    {
                        MessageBox.Show("El número de resolución ya existe!. Ingrese otro número.");
                        btnGenerarResolucion.Enabled = false;
                        txtNumResol.Focus();
                        numResolucion = 0;
                    }

                }
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void cmbBoxPlantillas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbBoxPlantillas.SelectedIndex > -1)
                {
                    myPlantilla = new plantilla();
                    myPlantilla.ID = (int)cmbBoxPlantillas.SelectedValue;
                    myPlantilla = (plantilla)((Object[])serviciosDocumentos.buscarPlantillasComp(myPlantilla))[0];

                    myTipoResolucion = new tipoResolucionComp();
                    myTipoResolucion.IDTIPORESOLUCION = myPlantilla.IDTIPORESOLUCION;
                    myTipoResolucion = (tipoResolucionComp)((Object[])serviciosDocumentos.buscarTipoResolucionComp(myTipoResolucion))[0];
                }
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        

        private void btn_Click(object sender, EventArgs e)
        {
            try
            {
                buscarInfractor();
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void txtDocumento_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    buscarInfractor();
                }
            }
            catch (Exception exp)
            {
                log.escribirError(exp.ToString(), this.GetType());
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        #region Eventos KeyPress
            private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
            {
                Funciones myFun = new Funciones();
                myFun.esNumero(e);
            }

            private void txtNumResol_KeyPress(object sender, KeyPressEventArgs e)
            {
                Funciones fnc = new Funciones();
                fnc.esNumero(e);
            }

            private void cmbBoxTipoDoc_KeyPress(object sender, KeyPressEventArgs e)
            {
                Funciones myFun = new Funciones();
                myFun.lanzarTapConEnter(e);
            }

            private void cmbBoxPlantillas_KeyPress(object sender, KeyPressEventArgs e)
            {
                Funciones myFun = new Funciones();
                myFun.lanzarTapConEnter(e);
            }

            private void dtPickFechaResolucion_KeyPress(object sender, KeyPressEventArgs e)
            {
                Funciones myFun = new Funciones();
                myFun.lanzarTapConEnter(e);
            }

            private void dtPickFechaAudiencia_KeyPress(object sender, KeyPressEventArgs e)
            {
                Funciones myFun = new Funciones();
                myFun.lanzarTapConEnter(e);
            }
        #endregion
    }
}
