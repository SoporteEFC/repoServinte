using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using Comparendos.servicios.generales.importarSimit;
using LibreriasSintrat.ServiciosGeneralesComp;
using LibreriasSintrat.ServiciosAccesorias;
using LibreriasSintrat.utilidades;
using LibreriasSintrat.ServiciosAccesoriasComp;
using LibreriasSintrat.ServiciosGeneralesComp;
using LibreriasSintrat.ServiciosUsuarios;
using LibreriasSintrat.ServiciosDocumentos;
using LibreriasSintrat.ServiciosReciboscomparendo;
using LibreriasSintrat.ServiciosLiquidacionComp;


namespace Comparendos.servicios.generales
{
    public partial class fCargarPlanosSimit : Form
    {
        private String fileComparendos = "Comp.txt";
        private String fileRecaudos = "rec.txt";
        private String fileResoluciones = "Resol.txt";
        StreamWriter infoLog;
        String fileLog = "logImportacionDatosSimit.txt";
        String ubicacionLog;
        usuarios myUsuario;

        public fCargarPlanosSimit(usuarios usuario)
        {
            InitializeComponent();
            myUsuario = usuario;
        }

        private void searchFiles()
        {
            lstFiles.Items.Clear();
            DialogResult response = directory.ShowDialog();
            if (response == DialogResult.OK)
            {
                string[] files = Directory.GetFiles(directory.SelectedPath);
                lstFiles.Items.AddRange(files);
                //getNameFile(lstFiles.Items[1].ToString());
                if (verificarArchivos())
                    btnCargarInfo.Enabled = true;
                else
                    btnCargarInfo.Enabled = false;
            }
        }

        private string getNameFile(string pathFile)
        {
            string nameFile = "";
            //string[] tmpSplit = Regex.Split(pathFile, '/');//pathFile.Split(new Char[]{'\'});
            String[] tmpSplit = pathFile.Split('\\');
            if (!String.IsNullOrEmpty(tmpSplit[tmpSplit.Length - 1]))
                nameFile = tmpSplit[tmpSplit.Length - 1];
            return nameFile;
        }

        private void cargarPlanosSimit(int opcion)
        {
            for (int i = 0; i < lstFiles.Items.Count; i++)
            {
                String path = lstFiles.Items[i].ToString();
                string file = getNameFile(lstFiles.Items[i].ToString());
                file = file.ToUpper();
                if (file.Contains(fileComparendos.ToUpper()) && opcion == 1)
                {
                    //cPlanoComparendo tmp = new cPlanoComparendo();
                    cargarComparendos(path);
                }
                else
                    if (file.Contains(fileRecaudos.ToUpper()) && opcion == 2)
                    {
                        cargarRecaudos(path);
                    }
                    else
                        if (file.Contains(fileResoluciones.ToUpper()) && opcion == 3)
                        {
                            cargarResoluciones(path);
                        }
            }
        }

        private ArrayList getTextToFile(String tmpPath)
        {
            StreamReader objectReader = new StreamReader(tmpPath);
            String sLine = "";
            ArrayList lstText = new ArrayList();
            while (sLine != null)
            {
                sLine = objectReader.ReadLine();
                if (sLine != null && sLine.Length > 0)
                    lstText.Add(sLine);
            }
            objectReader.Close();
            return lstText;
        }

        private void cargarComparendos(String tmpPath)
        {
            ArrayList lstText = getTextToFile(tmpPath);//Se leen todas las lineas del archivo de comparendos
            barComparendos.Value = 0;
            barComparendos.Maximum = lstText.Count - 1;
            hiloComparendos.RunWorkerAsync(lstText);
        }

        private void cargarResoluciones(String tmpPath)
        {
            ArrayList lstText = getTextToFile(tmpPath);//Se leen todas las lineas del archivo de resoluciones
            barResoluciones.Value = 0;
            barResoluciones.Maximum = lstText.Count - 1;
            hiloResoluciones.RunWorkerAsync(lstText);
        }

        private void cargarRecaudos(String tmpPath)
        {
            ArrayList lstText = getTextToFile(tmpPath);//Se leen todos las lineas del archivo de recaudos
            barRecaudos.Value = 0;
            barRecaudos.Maximum = lstText.Count - 1;
            hiloRecaudos.RunWorkerAsync(lstText);
        }

        private void setLog(String lineString)
        {
            if (infoLog != null)
                infoLog.Close();

            infoLog = new StreamWriter(ubicacionLog, true);
            infoLog.WriteLine(lineString);
            infoLog.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Escoga una ruta para generar el reporte de importación Simit","Ruta para el reporte",MessageBoxButtons.OK,MessageBoxIcon.Information);
                if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ubicacionLog = folderBrowserDialog.SelectedPath;
                    ubicacionLog = ubicacionLog.Replace("\\", "/");
                    ubicacionLog = ubicacionLog + "/" + fileLog;
                }

                if (ubicacionLog != "")
                {
                    ServiciosAccesoriasService servicioAccesorias = WS.ServiciosAccesoriasService();
                    String fechaActual = servicioAccesorias.getFechaActual();
                    //Funciones myFunc = new Funciones();
                    //fechaActual = myFunc.convFormatoFecha(fechaActual, "MM/dd/yyyy");
                    fechaActual = getFechaNormal(fechaActual);
                    //fechaActual = DateTime.Parse(fechaActual).ToString("dd/MM/yyyy");//servicioAccesorias.getFechaActual()).ToString("d' de 'MMMM' de 'yyyy");//"dd/MM/yyyy");
                    setLog("________________________________________________________________________________________________");
                    setLog(" ");
                    setLog("INFORME DE CARGUE");
                    setLog("PLANOS SIMIT - " + fechaActual);
                    setLog("________________________________________________________________________________________________");
                    setLog(" ");
                    cargarPlanosSimit(1);
                }
                //bgrworker.RunWorkerAsync();
                else MessageBox.Show("Debe escoger una ruta para el reporte de importación Simit", "La ruta del reporte es obligatoria", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exp)
            {
            }

            //cargarPlanosSimit();
        }

        private String getFechaNormal(String fecha)
        {
            String tmpFecha = "";
            String dia, mes, year;

            if (!String.IsNullOrWhiteSpace(fecha))
            {
                String[] datosFecha = fecha.Split('/');
                if (datosFecha != null && datosFecha.Length > 0)
                {
                    dia = datosFecha[1];
                    mes = datosFecha[0];
                    year = datosFecha[2];
                    tmpFecha = dia + "/" + mes + "/" + year;
                }
                else
                {
                    datosFecha = fecha.Split('-');
                    if (datosFecha != null && datosFecha.Length > 0)
                    {
                        dia = datosFecha[1];
                        mes = datosFecha[0];
                        year = datosFecha[2];
                        tmpFecha = dia + "/" + mes + "/" + year;                        
                    }
                }

            }
            return tmpFecha;
        }

        private void btnBuscarArchivos_Click(object sender, EventArgs e)
        {
            searchFiles();
        }

        private bool verificarArchivos() //0. si estan correctos 
                                        //1. si faltan archivos 
                                        //2. si hay mas de un archivo del mismo tipo 
                                        //3. si se cumple 1 y 2
        {
            bool resultado = true;
            //int file1 = 0;
            //int file2 = 0;
            //int file3 = 0;
            //for (int i = 0; i < lstFiles.Items.Count; i++)
            //{
            //    String path = lstFiles.Items[i].ToString();
            //    string file = getNameFile(lstFiles.Items[i].ToString());
            //    if (file.Contains(fileComparendos))
            //    {
            //        file1++;
            //    }
            //    else
            //        if (file.Contains(fileRecaudos))
            //        {
            //            file2++;
            //        }
            //        else
            //            if (file.Contains(fileResoluciones))
            //            {
            //                file3++;
            //            }
            //}
            //if (file1 == 1 && file2 == 1 && file3 == 1)
            //    resultado = true;
            //else
            //    if (file1 == 0 || file2 == 0 || file3 == 0)
            //    {
            //        if (file1 > 1 || file2 > 1 || file3 > 1)
            //        {
            //            MessageBox.Show("Faltan archivos obligatorios para la carga y ademas existe mas de un archivo de comparendos y/o de recaudos y/o de resoluciones", "Error en numero de archivos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            resultado = false;
            //        }
            //        else
            //        {
            //            MessageBox.Show("Faltan archivos obligatorios para la carga (comparendos y/o recaudos y/o resoluciones", "Error en numero de archivos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            resultado = false;
            //        }
            //    }
            //    else
            //        if (file1 > 1 || file2 > 1 || file3 > 1)
            //        {
            //            MessageBox.Show("Existe mas de un archivo de comparendos y/o de recaudos y/o de resoluciones", "Error en numero de archivos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            resultado = false;
            //        }
            return resultado;
        }

        private void hiloComparendos_DoWork(object sender, DoWorkEventArgs e)
        {
            ArrayList lstText = (ArrayList)e.Argument;
            for (int i = 0; i < lstText.Count - 1; i++)
            {
                #region Cargar linea
                agenteComp agente = null;
                if (lstText[i] != null && lstText[i].ToString().Length > 0)
                {
                    //cPlanoComparendo tmpPlanoComparendo = new cPlanoComparendo();
                    String[] splitLine = lstText[i].ToString().Split(',');

                    //Se llena el comparendo
                    comparendoComp comparendo = new comparendoComp();
                    if (!String.IsNullOrWhiteSpace(splitLine[1].ToString()))
                        comparendo.NUMEROCOMPARENDO = splitLine[1].ToString();
                    else setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL COMPARENDO REPORTADO NO TIENE NUMERO]");

                    if (!String.IsNullOrWhiteSpace(splitLine[2].ToString()))
                    {
                        try
                        {
                            comparendo.FECHACOMPARENDO = DateTime.Parse(splitLine[2].ToString()).ToString("dd/MM/yyyy");
                        }
                        catch (Exception exp)
                        {
                            setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL FORMATO DE LA FECHA DEL COMPARENDO NO ES CORRECTO]");    
                        }
                    }
                    else setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [SIN FECHA DE COMPARENDO]");

                    if (!String.IsNullOrWhiteSpace(splitLine[3].ToString()))
                    {
                        comparendo.HORACOMPARENDO = splitLine[3].ToString() + ":00";
                    }
                    else setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [NO HAY HORA DEL COMPARENDO]");

                    if (!String.IsNullOrWhiteSpace(splitLine[4].ToString()))
                    {
                        comparendo.DIRECCIONINFRACCION = splitLine[4].ToString();
                    }
                    else setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [NO HAY DIRECCION DEL COPARENDO]");

                    //Split[5] Divipo Municipio
                    if (!String.IsNullOrWhiteSpace(splitLine[5].ToString()))
                    {
                        ServiciosAccesoriasCompService serviciosAccesoriasComp = WS.ServiciosAccesoriasCompService(); 
                        Object[] ciudades;
                        ciudades = (Object[])serviciosAccesoriasComp.listarCiudadComp();
                        int id_ciudad;
                        id_ciudad = getIdCiudad(ciudades,splitLine[5].ToString());
                        if (id_ciudad > 0)
                            comparendo.ID_CIUDAD = id_ciudad;
                    }



                    if (!String.IsNullOrWhiteSpace(splitLine[6].ToString()))
                    {
                        comparendo.LOCALIDAD_COMUNADIRECCION = splitLine[6].ToString();
                    }
                    else setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [NO HAY LOCALIDAD O COMUNA DE LA DIRECCION DEL COMPARENDO]");

                    vehiculosComp vehiculo = new vehiculosComp();

                    if (!String.IsNullOrWhiteSpace(splitLine[7].ToString()))
                    {
                        comparendo.PLACA = splitLine[7].ToString();
                        vehiculo.PLACA = splitLine[7].ToString();
                    }
                    else setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [NO HAY PLACA DEL VEHICULO]");


                    //Se llena el vehiculo

                    //Split[8] Divipo Matriculado en

                    if (!String.IsNullOrWhiteSpace(splitLine[9].ToString()))
                    {
                        //ServiciosAccesoriasService servicioAccesorias = WS.ServiciosAccesoriasService();
                        //claseVehiculo clase_vehiculo = new claseVehiculo();
                        //clase_vehiculo.ID_CVEHICULORUNT = splitLine[9].ToString();
                        //Object[] lstClases = servicioAccesorias.getClaseVehiculo(clase_vehiculo);
                        //if (lstClases != null && lstClases.Length > 0)
                        //{
                        //clase_vehiculo = (claseVehiculo)lstClases[0];
                        //vehiculo.ID_CVEHICULO = clase_vehiculo.ID_CVEHICULO;
                        //}
                        try
                        {
                            vehiculo.ID_CVEHICULO = int.Parse(splitLine[9].ToString());
                        }
                        catch (Exception exp)
                        {
                            setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL ID DE LA CLASE DE VEHICULO NO ES UN VALOR CORRECTO]");
                        }

                    }
                    else setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [NO HAY CLASE DE VEHICULO]");

                    if (!String.IsNullOrWhiteSpace(splitLine[10].ToString()))
                    {
                        //ServiciosAccesoriasService servicioAccesorias = WS.ServiciosAccesoriasService();
                        //servicio tmpServicio = new servicio();
                        //tmpServicio.ID_SERVICIORUNT = splitLine[10].ToString();
                        //Object[] lstServicios = servicioAccesorias.getServiciosValidos(tmpServicio);
                        //if (lstServicios != null && lstServicios.Length > 0)
                        //{
                        //    tmpServicio = (servicio)lstServicios[0];
                        //    vehiculo.ID_SERVICIO = tmpServicio.ID_SERVICIO;
                        //}
                        try
                        {
                            vehiculo.ID_SERVICIO = int.Parse(splitLine[10].ToString());
                        }
                        catch (Exception exp)
                        {
                            setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL ID DEL TIPO DE SERVICIO NO ES UN VALOR VALIDO]");//log el id del tipo del servicio no es un valor valido
                        }
                    }
                    else setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [NO HAY TIPO DE SERVICIO]");


                    if (!String.IsNullOrWhiteSpace(splitLine[11].ToString()))
                    {
                        try
                        {
                            vehiculo.ID_RADIOACCION = int.Parse(splitLine[11].ToString());
                        }
                        catch (Exception exp)
                        {
                            setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL RADIO DE ACCION ES ERRONEO]");
                        }
                    }
                    else setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL VEHICULO NO TIENE RADIO DE ACCION]");

                    if (!String.IsNullOrWhiteSpace(splitLine[12].ToString()))
                    {
                        try
                        {
                            vehiculo.ID_MODALIDADTRANSPORTE = int.Parse(splitLine[12].ToString());
                        }
                        catch (Exception exp)
                        {
                            setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [LA MODALIDAD DE TRANSPORTE DEL VEHICULO ES INCORRECTA]");
                        }
                    }
                    else setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL VEHICULO NO TIENE MODALIDAD DE TRANSPORTE]");

                    if (!String.IsNullOrWhiteSpace(splitLine[13].ToString()))
                    {
                        try
                        {
                            vehiculo.ID_TIPOTRANSPORTEPASAJERO = int.Parse(splitLine[13].ToString());
                        }
                        catch (Exception exp)
                        {
                            setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL TIPO DE TRANSPORTE DE PASAJEROS ES INCORRECTO]");//log el tipo de transporte de pasajeros es incorrecto  
                        }
                    }
                    else setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL VEHICULO NO TIENE TIPO DE TRANSPORTE DE PASAJEROS]");

                    //infractor
                    infractorComp infractor = new infractorComp();

                    if (!String.IsNullOrWhiteSpace(splitLine[14].ToString()))
                    {
                        infractor.NROIDENTIFICACION = splitLine[14].ToString();
                    }
                    else setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL INFRACTOR NO TIENE NUMERO DE IDENTIFICACION]");

                    if (!String.IsNullOrWhiteSpace(splitLine[15].ToString()))
                    {
                        ServiciosAccesoriasCompService servicioAccesoriasComp = WS.ServiciosAccesoriasCompService();
                        documentoComp tipoDocumentoComp = new documentoComp();
                        tipoDocumentoComp.IDCONSULTASIMIT = splitLine[15].ToString();
                        Object[] lstTipoDocumento = servicioAccesoriasComp.obtenerTipoDocumento(tipoDocumentoComp);
                        if (lstTipoDocumento != null && lstTipoDocumento.Length > 0)
                        {
                            tipoDocumentoComp = (documentoComp)lstTipoDocumento[0];
                            try
                            {
                                infractor.ID_DOCTO = tipoDocumentoComp.IDREPORTECOMPARENDO;
                            }
                            catch (Exception exp)
                            {
                                setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL TIPO DE DOCUMENTO DEL INFRACTOR NO ES CORRECTO]");//log el tipo de documento del infractor no es correcto
                            }
                        }
                        else setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL TIPO DE DOCUMENTO DEL INFRACTOR NO EXISTE]");
                    }
                    else setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [NO HAY TIPO DE DOCUMENTO DEL INFRACTOR]");

                    if (!String.IsNullOrWhiteSpace(splitLine[16].ToString()))
                    {
                        infractor.NOMBRES = splitLine[16].ToString();
                    }
                    else setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL INFRACTOR NO TIENE NOMBRE]");

                    if (!String.IsNullOrWhiteSpace(splitLine[17].ToString()))
                    {
                        infractor.APELLIDOS = splitLine[17].ToString();
                    }
                    else setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL INFRACTOR NO TIENE APELLIDO]");

                    if (!String.IsNullOrWhiteSpace(splitLine[18].ToString()))
                    {
                        infractor.EDAD = splitLine[18].ToString();
                    }
                    else setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL INFRACTOR NO TIENE EDAD]");

                    if (!String.IsNullOrWhiteSpace(splitLine[19].ToString()))
                    {
                        infractor.DIRECCION = splitLine[19].ToString();
                    }
                    else setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL INFRACTOR NO TIENE DIRECCION]");

                    if (!String.IsNullOrWhiteSpace(splitLine[20].ToString()))
                    {
                        infractor.EMAIL = splitLine[20].ToString();
                    }
                    else setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL INFRACTOR NO TIENE CORREO ELECTROICO]");

                    if (!String.IsNullOrWhiteSpace(splitLine[21].ToString()))
                    {
                        infractor.TELEFONO = splitLine[21].ToString();
                    }
                    else setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL INFRACTOR NO TIENE TELEFONO]");

                    //DIVIPO de la ciudad de residencia del infractor splitLine[22]

                    if (!String.IsNullOrWhiteSpace(splitLine[23].ToString()))
                    {
                        infractor.NROLICCONDUCCION = splitLine[23].ToString();
                    }
                    else setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL INFRACTOR NO TIENE NUMERO DE LICENCIA DE CONDUCCION]");

                    if (!String.IsNullOrWhiteSpace(splitLine[24].ToString()))
                    {
                        infractor.CATEGLICENCIA = splitLine[24].ToString();
                    }
                    else setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL INFRACTOR NO TIENE CATEGORIA DE LA LICENCIA DE CONDUCCION]");

                    //Divipo organismo expide licencia. splitLine[25]

                    if (!String.IsNullOrWhiteSpace(splitLine[26].ToString()))
                    {
                        infractor.FECHAVENCELICCONDUCCION = splitLine[26].ToString();
                    }
                    else setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL INFRACTOR NO TIENE FECHA DE VENCIMIENTO DE LA LICENCIA DE CONDUCCION]");

                    if (!String.IsNullOrWhiteSpace(splitLine[27].ToString()))
                    {
                        //ServiciosAccesoriasCompService servicioAccesoriasComp = WS.ServiciosAccesoriasCompService();
                        //tipoInfractorComp tipoInfractorComp = new tipoInfractorComp();
                        //tipoInfractorComp.CODTIPOINFRACTOR = splitLine[27].ToString();
                        //Object[] lstTipoDocumento = servicioAccesoriasComp.obtenerTipoDocumento(tipoDocumentoComp);
                        //if (lstTipoDocumento != null && lstTipoDocumento.Length > 0)
                        //{
                        //    tipoDocumentoComp = (documentoComp)lstTipoDocumento[0];
                        //    try
                        //    {
                        //        infractor.ID_DOCTO = tipoDocumentoComp.IDREPORTECOMPARENDO;
                        //    }
                        //    catch (Exception exp)
                        //    {
                        //        //log el tipo de documento del infractor no es correcto
                        //    }
                        //}
                        try
                        {
                            ServiciosAccesoriasCompService servicioAccesoriasComp = WS.ServiciosAccesoriasCompService();
                            tipoInfractorComp tipoInfractor = new tipoInfractorComp();
                            tipoInfractor.CODTIPOINFRACTOR = splitLine[27].ToString();
                            Object[] lstTiposInfractor = servicioAccesoriasComp.getTipoInfractorComp(tipoInfractor);
                            if (lstTiposInfractor != null && lstTiposInfractor.Length > 0)
                            {
                                tipoInfractor = (tipoInfractorComp)lstTiposInfractor[0];
                                comparendo.ID_TIPOINFRACTOR = tipoInfractor.ID_TIPOINFRACTOR;
                            }
                            else setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL TIPO DE INFRACTOR NO FUE ENCONTRADO EN LA BASE DE DATOS]");
                        }
                        catch (Exception exp)
                        {
                            setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL TIPO DE INFRACTOR TIENE UNA VALOR INCORRECTO]");
                        }
                    }
                    else setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [NO SE REPOPRTA EL TIPO DE INFRACTOR]");

                    if (!String.IsNullOrWhiteSpace(splitLine[28].ToString()))
                    {
                        vehiculo.NROLICENCIA = splitLine[28].ToString();
                    }
                    else setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL VEHICULO NO TIENE NUMERO DE LICENCIA DE TRANSITO]");


                    //Divipo licencia de tránsito splitLine[29]

                    //propietario

                    propietarioVehComp propietario = new propietarioVehComp();

                    if (!String.IsNullOrWhiteSpace(splitLine[30].ToString()))
                    {
                        propietario.NROIDENTIFICACION = splitLine[30].ToString();
                    }
                    else setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL PROPIETARIO NO TIENE NUMERO DE IDENTIFICACION]");

                    if (!String.IsNullOrWhiteSpace(splitLine[31].ToString()))
                    {
                        ServiciosAccesoriasCompService servicioAccesoriasComp = WS.ServiciosAccesoriasCompService();
                        documentoComp tipoDocumentoComp = new documentoComp();
                        tipoDocumentoComp.IDCONSULTASIMIT = splitLine[31].ToString();
                        Object[] lstTipoDocumento = servicioAccesoriasComp.obtenerTipoDocumento(tipoDocumentoComp);
                        if (lstTipoDocumento != null && lstTipoDocumento.Length > 0)
                        {
                            tipoDocumentoComp = (documentoComp)lstTipoDocumento[0];
                            try
                            {
                                propietario.ID_DOCTO = tipoDocumentoComp.ID_DOCTO;
                            }
                            catch (Exception exp)
                            {
                                setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL TIPO DE DOCUMENTO DEL PROPIETARIO NO ES CORRECTO]");
                            }
                        }
                        else setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL TIPO DE DOCUMENTO DEL PROPIETARIO NO EXISTE]");
                    }
                    else setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL PROPIETARIO NO TIENE TIPO DE DOCUMENTO]");

                    if (!String.IsNullOrWhiteSpace(splitLine[32].ToString()))
                    {
                        String[] nombresApellidos = splitLine[32].ToString().Split(' ');
                        if (nombresApellidos != null)
                        {
                            if (nombresApellidos.Length == 1)
                                propietario.NOMBRES = nombresApellidos[0].ToString();
                            else if (nombresApellidos.Length == 2)
                            {
                                propietario.NOMBRES = nombresApellidos[0].ToString();
                                propietario.APELLIDOS = nombresApellidos[1].ToString();
                            }
                            else if (nombresApellidos.Length == 3)
                            {
                                propietario.NOMBRES = nombresApellidos[0].ToString();
                                propietario.APELLIDOS = nombresApellidos[1].ToString() + " " + nombresApellidos[2].ToString();
                            }
                            else if (nombresApellidos.Length >= 4)
                            {
                                propietario.NOMBRES = nombresApellidos[0].ToString() + " " + nombresApellidos[1].ToString();
                                propietario.APELLIDOS = nombresApellidos[2].ToString() + " " + nombresApellidos[3].ToString();
                            }
                        }
                        
                    }
                    else setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL PROPIETARIO NO TIENE NOMBRES]");

                    //nombres de la empresa splitLine[33].ToString();
                    //nit de la empresa splitLine[34].ToString();


                    if (!String.IsNullOrWhiteSpace(splitLine[35].ToString()))
                    {
                        vehiculo.TARJETAOPERACION = splitLine[35].ToString();
                    }
                    else setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL VEHICULO NO TIENE TARJETA DE OPERACION]");

                    if (!String.IsNullOrWhiteSpace(splitLine[36].ToString()))
                    {
                        ServiciosGeneralesCompService serviciosGeneralesComp = WS.ServiciosGeneralesCompService();
                        agente = new agenteComp();
                        agente.PLACAAGENTE = splitLine[36].ToString();
                        Object[] lstAgentes = serviciosGeneralesComp.buscarAgentes(agente);
                        if (lstAgentes != null && lstAgentes.Length > 0)
                        {
                            agente = (agenteComp)lstAgentes[0];
                            comparendo.ID_AGENTE = agente.ID_AGENTE;
                        }
                        else setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL AGENTE NO ESTA EN LA BASE DE DATOS]");
                    }
                    else setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL COMPARENDO NO TIENE AGENTE DE TRANSITO]");

                    if (!String.IsNullOrWhiteSpace(splitLine[37].ToString()))
                    {
                        comparendo.OBSERVACION = splitLine[37].ToString();
                    }
                    else setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL COMPARENDO NO TIENE OBSERVACIONES]");

                    if (!String.IsNullOrWhiteSpace(splitLine[38].ToString()))
                    {
                        comparendo.REPORTAFUGA = splitLine[38].ToString();
                    }
                    else setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL COMPARENDO NO REPORTA SI HAY FUGA O NO]");

                    if (!String.IsNullOrWhiteSpace(splitLine[39].ToString()))
                    {
                        comparendo.REPORTAACCIDENTE = splitLine[39].ToString();
                    }
                    else setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL COMPARENDO NO REPORTA SI HAY ACCIDENTE O NO]");

                    if (!String.IsNullOrWhiteSpace(splitLine[40].ToString()))
                    {
                        comparendo.REPORTAINMOVILIZACION = splitLine[40].ToString();
                    }
                    else setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL COMPARENDO NO REPORTA SI HAY INMOBILIZACION O NO]");

                    //Patio inmobilizacion splitLine[41]

                    if (!String.IsNullOrWhiteSpace(splitLine[42].ToString()))
                    {
                        comparendo.DIRECCIONPATIO_INMOVILIZA = splitLine[42].ToString();
                    }
                    else setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [NO SE REPORTA LA DIRECCION DEL PATIO DE INMOBILIZACION]");

                    if (!String.IsNullOrWhiteSpace(splitLine[43].ToString()))
                    {
                        comparendo.NUMEROGRUA = splitLine[43].ToString();
                    }
                    else setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [NO SE REPORTA EL NUMERO DE LA GRUA]");

                    if (!String.IsNullOrWhiteSpace(splitLine[44].ToString()))
                    {
                        comparendo.PLACAGRUA = splitLine[44].ToString();
                    }
                    else setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [NO SE REPORTA LA PLACA DE LA GRUA]");

                    if (!String.IsNullOrWhiteSpace(splitLine[45].ToString()))
                    {
                        comparendo.CONSECUTIVOINMOVILIZACION = splitLine[45].ToString();
                    }
                    else setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [NO SE REPORTA CONSECUTIVO DE INMOBILIZACION]");

                    testigoComp testigo = new LibreriasSintrat.ServiciosGeneralesComp.testigoComp();

                    if (!String.IsNullOrWhiteSpace(splitLine[46].ToString()))
                    {
                        testigo.NROIDENTIFICACION = splitLine[46].ToString();
                    }
                    else setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL TESTIGO NO TIENE NUMERO DE IDENTIFICACION]");

                    if (!String.IsNullOrWhiteSpace(splitLine[47].ToString()))
                    {
                        testigo.NOMBRES = splitLine[47].ToString();
                    }
                    else setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL TESTIGO NO TIENE NOMBRES]");

                    if (!String.IsNullOrWhiteSpace(splitLine[48].ToString()))
                    {
                        testigo.DIRECCION = splitLine[48].ToString();
                    }
                    else setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL TESTIGO NO TIENE DIRECCION]");

                    if (!String.IsNullOrWhiteSpace(splitLine[49].ToString()))
                    {
                        testigo.NROTELEFONO = splitLine[49].ToString();
                    }
                    else setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL TESTIGO NO TIENE NUMERO DE TELEFONO]");

                    if (!String.IsNullOrWhiteSpace(splitLine[50].ToString()))
                    {
                        try
                        {
                            comparendo.VALOR = double.Parse(splitLine[50].ToString());
                        }
                        catch (Exception exp)
                        {
                            setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL VALOR DEL COMPARENDO NO ES CORRECTO]");
                        }
                    }
                    else setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL COMPARENDO NO TIENE VALOR]");

                    //DIVIPO de la ciudad donde se ubica la secretaria splitLine[52]

                    infracionComparendoComp infraccionComparendo = null;

                    if (!String.IsNullOrWhiteSpace(splitLine[53].ToString()))
                    {
                        ServiciosAccesoriasCompService servicioAccesoriasComp = WS.ServiciosAccesoriasCompService();
                        estadoComp estado_comp = new estadoComp();
                        estado_comp.COD_ESTADO = splitLine[53].ToString();
                        estado_comp = servicioAccesoriasComp.searchOneEstadosComp(estado_comp);
                        if (estado_comp != null && estado_comp.ID_ESTADO > 0)
                        {
                            try
                            {
                                infraccionComparendo = new LibreriasSintrat.ServiciosGeneralesComp.infracionComparendoComp();
                                infraccionComparendo.IDESTADO = estado_comp.ID_ESTADO;
                                infraccionComparendo.VALORINFRACCION = comparendo.VALOR;
                                if (!String.IsNullOrWhiteSpace(splitLine[55].ToString()))
                                {
                                    LibreriasSintrat.ServiciosAccesoriasComp.infraccionesComp tmpInfraccion = new LibreriasSintrat.ServiciosAccesoriasComp.infraccionesComp();
                                    tmpInfraccion.NUEVO_CODIGOCORREGIDO = splitLine[55].ToString();
                                    tmpInfraccion = servicioAccesoriasComp.getInfraccionComp(tmpInfraccion);
                                    if (tmpInfraccion != null && tmpInfraccion.ID_INFRACCION > 0)
                                    {
                                        infraccionComparendo.IDINFRACCION = tmpInfraccion.ID_INFRACCION;
                                    }
                                    else setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [LA INFRACCION DEL COMPARENDO NO EXISTE EN LA BASE DE DATOS]");
                                }
                                else
                                    setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [NO SE REPORTA EL CODIGO DE LA INFRACCION]");
                            }
                            catch (Exception exp)
                            {
                                setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL ESTADO DEL COMPARENDO TIENE UN VALOR INCORRECTO]");
                            }
                        }
                        else setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL ESTADO DEL COMPARENDO NO EXISTE EN LA BASE DE DATOS]");
                    }
                    else setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL COMPARENDO NO TIENE ESTADO]");

                    if (!String.IsNullOrWhiteSpace(splitLine[54].ToString()))
                    {
                        comparendo.POLCA = splitLine[54].ToString();
                    }
                    else setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL COMPARENDO NO REPORTA SI ES POLCA O NO]");

                    //_________________________________________
                    //
                    //      PERSISTENCIA
                    //_________________________________________

                    //Vehiculo
                    vehiculosComp tmpVehiculo = new LibreriasSintrat.ServiciosGeneralesComp.vehiculosComp();
                    if (vehiculo != null)
                    {
                        tmpVehiculo.PLACA = vehiculo.PLACA;
                        ServiciosGeneralesCompService serviciosGeneralesComp = WS.ServiciosGeneralesCompService();
                        Object[] lstVehiculos = serviciosGeneralesComp.getVehiculoComp(tmpVehiculo);
                        if (lstVehiculos != null && lstVehiculos.Length > 0)
                        {
                            tmpVehiculo = (vehiculosComp)lstVehiculos[0];
                            vehiculo.IDVEHICULOCOMP = tmpVehiculo.IDVEHICULOCOMP;
                            if (vehiculo.PLACA != null && vehiculo.PLACA.Length > 0)
                                tmpVehiculo.PLACA = vehiculo.PLACA;
                            if (vehiculo.ID_CVEHICULO != null && vehiculo.ID_CVEHICULO > 0)
                                tmpVehiculo.ID_CVEHICULO = vehiculo.ID_CVEHICULO;
                            if (vehiculo.ID_SERVICIO != null && vehiculo.ID_SERVICIO > 0)
                                tmpVehiculo.ID_SERVICIO = vehiculo.ID_SERVICIO;
                            if (vehiculo.ID_RADIOACCION != null && vehiculo.ID_RADIOACCION > 0)
                                tmpVehiculo.ID_RADIOACCION = vehiculo.ID_RADIOACCION;
                            if (vehiculo.ID_MODALIDADTRANSPORTE != null && vehiculo.ID_MODALIDADTRANSPORTE > 0)
                                tmpVehiculo.ID_MODALIDADTRANSPORTE = vehiculo.ID_MODALIDADTRANSPORTE;
                            if (vehiculo.ID_TIPOTRANSPORTEPASAJERO != null && vehiculo.ID_TIPOTRANSPORTEPASAJERO > 0)
                                tmpVehiculo.ID_TIPOTRANSPORTEPASAJERO = vehiculo.ID_TIPOTRANSPORTEPASAJERO;
                            if (vehiculo.NROLICENCIA != null && vehiculo.NROLICENCIA.Length > 0)
                                tmpVehiculo.NROLICENCIA = vehiculo.NROLICENCIA;
                            if (vehiculo.TARJETAOPERACION != null && vehiculo.TARJETAOPERACION.Length > 0)
                                tmpVehiculo.TARJETAOPERACION = vehiculo.TARJETAOPERACION;
                            if (serviciosGeneralesComp.actualizarVehiculoComp(tmpVehiculo, myUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName()))
                            {
                                setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Confirmación [EL VEHICULO DE PLACAS " + tmpVehiculo.PLACA + " FUE ACTUALIZADO]");
                                comparendo.IDVEHICULOCOMP = tmpVehiculo.IDVEHICULOCOMP;
                            }
                            else
                                setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL VEHICULO DE PLACAS " + tmpVehiculo.PLACA + " NO PUDO SER ACTUALIZADO]");
                        }
                        else
                        {
                            if (!String.IsNullOrWhiteSpace(vehiculo.PLACA))
                            {
                                vehiculo.IDVEHICULOCOMP = serviciosGeneralesComp.crearVehiculoComp(vehiculo, myUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName());
                                if (vehiculo.IDVEHICULOCOMP > 0)
                                {
                                    setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Confirmación [VEHICULO DE PLACAS " + vehiculo.PLACA + " FUE CREADO CORRECTAMENTE]");
                                    comparendo.IDVEHICULOCOMP = vehiculo.IDVEHICULOCOMP;
                                }
                                else
                                    setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL VEHICULO DE PLACAS " + vehiculo.PLACA + " NO FUE CREADO]");
                            }
                            else
                                setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL VEHICULO " + vehiculo.PLACA + " NO FUE CREADO PORQUE NO TIENE PLACAS]");
                        }
                    }

                    //infractor
                    infractorComp tmpInfractor = new LibreriasSintrat.ServiciosGeneralesComp.infractorComp();
                    if (infractor != null)
                    {
                        tmpInfractor.ID_DOCTO = infractor.ID_DOCTO;
                        tmpInfractor.NROIDENTIFICACION = infractor.NROIDENTIFICACION;
                        ServiciosGeneralesCompService serviciosGeneralesComp = WS.ServiciosGeneralesCompService();
                        tmpInfractor = serviciosGeneralesComp.buscarInfractor(tmpInfractor);
                        if (tmpInfractor != null && tmpInfractor.ID_INFRACTOR > 0)
                        {
                            infractor.ID_INFRACTOR = tmpInfractor.ID_INFRACTOR;
                            if (infractor.NROIDENTIFICACION != null && infractor.NROIDENTIFICACION.Length > 0)
                                tmpInfractor.NROIDENTIFICACION = infractor.NROIDENTIFICACION;
                            if (infractor.ID_DOCTO != null && infractor.ID_DOCTO > 0)
                                tmpInfractor.ID_DOCTO = infractor.ID_DOCTO;
                            if (infractor.NOMBRES != null && infractor.NOMBRES.Length > 0)
                                tmpInfractor.NOMBRES = infractor.NOMBRES;
                            if (infractor.APELLIDOS != null && infractor.APELLIDOS.Length > 0)
                                tmpInfractor.APELLIDOS = infractor.APELLIDOS;
                            if (infractor.EDAD != null && infractor.EDAD.Length > 0)
                                tmpInfractor.EDAD = infractor.EDAD;
                            if (infractor.DIRECCION != null && infractor.DIRECCION.Length > 0)
                                tmpInfractor.DIRECCION = infractor.DIRECCION;
                            if (infractor.EMAIL != null && infractor.EMAIL.Length > 0)
                                tmpInfractor.EMAIL = infractor.EMAIL;
                            if (infractor.TELEFONO != null && infractor.TELEFONO.Length > 0)
                                tmpInfractor.TELEFONO = infractor.TELEFONO;
                            if (infractor.NROLICCONDUCCION != null && infractor.NROLICCONDUCCION.Length > 0)
                                tmpInfractor.NROLICCONDUCCION = infractor.NROLICCONDUCCION;
                            if (infractor.CATEGLICENCIA != null && infractor.CATEGLICENCIA.Length > 0)
                                tmpInfractor.CATEGLICENCIA = infractor.CATEGLICENCIA;
                            if (infractor.FECHAVENCELICCONDUCCION != null && infractor.FECHAVENCELICCONDUCCION.Length > 0)
                                tmpInfractor.FECHAVENCELICCONDUCCION = infractor.FECHAVENCELICCONDUCCION;
                            if (serviciosGeneralesComp.actualizarInfractorComp(tmpInfractor, myUsuario.ID_USUARIO,WS.Funciones().obtenerDirIp(),WS.Funciones().obtenerHostName()))
                            {
                                setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Confirmación [EL INFRACTOR CON NUMERO DE IDENTIFICACION #" + infractor.NROIDENTIFICACION + " FUE ACTUALIZADO CORRECTAMENTE]");
                                comparendo.ID_INFRACTOR = tmpInfractor.ID_INFRACTOR;
                            }
                            else
                                setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL INFRACTOR CON NUMERO DE IDENTIFICACION #" + infractor.NROIDENTIFICACION + " NO FUE ACTUALIZADO]");
                        }
                        else
                        {
                            infractor.ID_INFRACTOR = serviciosGeneralesComp.crearInfractorComp(infractor, myUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName());
                            if (infractor.ID_INFRACTOR > 0)
                            {
                                setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Confirmación [EL INFRACTOR CON NUMERO DE IDENTIFICACION #" + infractor.NROIDENTIFICACION + " FUE CREADO CORRECTAMENTE]");
                                comparendo.ID_INFRACTOR = infractor.ID_INFRACTOR;
                            }
                            else
                                setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL INFRACTOR CON NUMERO DE IDENTIFICACION #" + infractor.NROIDENTIFICACION + " NO FUE CREADO]");
                        }
                    }

                    //Agente
                    if (agente != null && agente.PLACAAGENTE.Length > 0)
                    {
                        ServiciosGeneralesCompService serviciosGeneralesComp = WS.ServiciosGeneralesCompService();
                        Object[] lstAgentes = serviciosGeneralesComp.getAgentes(agente);
                        if (lstAgentes != null && lstAgentes.Length > 0)
                        {
                            agente = (agenteComp)lstAgentes[0];
                            comparendo.ID_AGENTE = agente.ID_AGENTE;
                        }
                        else
                            setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL AGENTE DE PLACA #" + agente.PLACAAGENTE + " NO FUE ENCONTRADO EN LA BASE DE DATOS]");
                    }
               
                    
                    //Comparendo
                    if (comparendo != null)
                    {
                        ServiciosGeneralesCompService serviciosGeneralesComp = WS.ServiciosGeneralesCompService();
                        comparendoComp tmpComparendo = new LibreriasSintrat.ServiciosGeneralesComp.comparendoComp();
                        tmpComparendo.NUMEROCOMPARENDO = comparendo.NUMEROCOMPARENDO;
                        Object[] lstComparendos = serviciosGeneralesComp.searchComparendo(tmpComparendo);
                        if (lstComparendos != null && lstComparendos.Length > 0)
                        {
                            //setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL COMPARENDO #" + tmpComparendo.NUMEROCOMPARENDO + " YA EXISTE EN LA BASE DE DATOS]");
                            tmpComparendo = (comparendoComp)lstComparendos[0];
                            comparendo.ID_COMPARENDO = tmpComparendo.ID_COMPARENDO;
                            if (comparendo.FECHACOMPARENDO != null && comparendo.FECHACOMPARENDO.Length > 0)
                                tmpComparendo.FECHACOMPARENDO = comparendo.FECHACOMPARENDO;
                            if (comparendo.HORACOMPARENDO != null && comparendo.HORACOMPARENDO.Length > 0)
                                tmpComparendo.HORACOMPARENDO = comparendo.HORACOMPARENDO;
                            if (comparendo.DIRECCIONINFRACCION != null && comparendo.DIRECCIONINFRACCION.Length > 0)
                                tmpComparendo.DIRECCIONINFRACCION = comparendo.DIRECCIONINFRACCION;
                            if (comparendo.LOCALIDAD_COMUNADIRECCION != null && comparendo.LOCALIDAD_COMUNADIRECCION.Length > 0)
                                tmpComparendo.LOCALIDAD_COMUNADIRECCION = comparendo.LOCALIDAD_COMUNADIRECCION;
                            if (comparendo.IDVEHICULOCOMP != null && comparendo.IDVEHICULOCOMP > 0)
                                tmpComparendo.IDVEHICULOCOMP = comparendo.IDVEHICULOCOMP;
                            if (comparendo.ID_INFRACTOR != null && comparendo.ID_INFRACTOR > 0)
                                tmpComparendo.ID_INFRACTOR = comparendo.ID_INFRACTOR;
                            if (comparendo.ID_AGENTE != null && comparendo.ID_AGENTE > 0)
                                tmpComparendo.ID_AGENTE = comparendo.ID_AGENTE;
                            if (comparendo.REPORTAFUGA != null && comparendo.REPORTAFUGA.Length > 0)
                                tmpComparendo.REPORTAFUGA = comparendo.REPORTAFUGA;
                            if (comparendo.REPORTAACCIDENTE != null && comparendo.REPORTAACCIDENTE.Length > 0)
                                tmpComparendo.REPORTAACCIDENTE = comparendo.REPORTAACCIDENTE;
                            if (comparendo.REPORTAINMOVILIZACION != null && comparendo.REPORTAINMOVILIZACION.Length > 0)
                                tmpComparendo.REPORTAINMOVILIZACION = comparendo.REPORTAINMOVILIZACION;
                            if (comparendo.DIRECCIONPATIO_INMOVILIZA != null && comparendo.DIRECCIONPATIO_INMOVILIZA.Length > 0)
                                tmpComparendo.DIRECCIONPATIO_INMOVILIZA = comparendo.DIRECCIONPATIO_INMOVILIZA;
                            if (comparendo.NUMEROGRUA != null && comparendo.NUMEROGRUA.Length > 0)
                                tmpComparendo.NUMEROGRUA = comparendo.NUMEROGRUA;
                            if (comparendo.PLACAGRUA != null && comparendo.PLACAGRUA.Length > 0)
                                tmpComparendo.PLACAGRUA = comparendo.PLACAGRUA;
                            if (comparendo.CONSECUTIVOINMOVILIZACION != null && comparendo.CONSECUTIVOINMOVILIZACION.Length > 0)
                                tmpComparendo.CONSECUTIVOINMOVILIZACION = comparendo.CONSECUTIVOINMOVILIZACION;
                            if (comparendo.VALOR != null && comparendo.VALOR > 0)
                                tmpComparendo.VALOR = comparendo.VALOR;
                            if (comparendo.POLCA != null && comparendo.POLCA.Length > 0)
                                tmpComparendo.POLCA = comparendo.POLCA;
                            if (comparendo.ID_CIUDAD > 0)
                                tmpComparendo.ID_CIUDAD = comparendo.ID_CIUDAD;

                            if (serviciosGeneralesComp.actualizarComparendo(tmpComparendo, myUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName()))
                                setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Confirmación [EL COMPARENDO #" + comparendo.NUMEROCOMPARENDO + " FUE ACTUALIZADO CORRECTAMENTE]");
                            else
                                setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Confirmación [EL COMPARENDO #" + comparendo.NUMEROCOMPARENDO + " NO FUE ACTUALIZADO CORRECTAMENTE]");

                            infracionComparendoComp tmpInfraccionComparendo = new LibreriasSintrat.ServiciosGeneralesComp.infracionComparendoComp();
                            infraccionComparendo.IDCOMPARENDO = comparendo.ID_COMPARENDO;
                            tmpInfraccionComparendo.IDCOMPARENDO = infraccionComparendo.IDCOMPARENDO;
                            
                            tmpInfraccionComparendo = serviciosGeneralesComp.getInfraccionComparendo(tmpInfraccionComparendo);
                            if (tmpInfraccionComparendo != null && tmpInfraccionComparendo.ID != null && tmpInfraccionComparendo.ID > 0)
                            {
                                if (infraccionComparendo.IDESTADO != null && infraccionComparendo.IDESTADO > 0)
                                    tmpInfraccionComparendo.IDESTADO = infraccionComparendo.IDESTADO;
                                if (infraccionComparendo.IDINFRACCION != null && infraccionComparendo.IDINFRACCION > 0)
                                    tmpInfraccionComparendo.IDINFRACCION = infraccionComparendo.IDINFRACCION;
                                if (infraccionComparendo.VALORINFRACCION != null && infraccionComparendo.VALORINFRACCION > 0)
                                    tmpInfraccionComparendo.VALORINFRACCION = infraccionComparendo.VALORINFRACCION;

                                if (serviciosGeneralesComp.actualizarInfraccionComparendo(tmpInfraccionComparendo, myUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName()))
                                    setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Confirmación [LA INFRACCIONCOMPARENDO DEL COMPARENDO #" + comparendo.NUMEROCOMPARENDO + " FUE ACTUALIZADA CORRECTAMENTE]");
                                else
                                    setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [LA INFRACCIONCOMPARENDO DEL COMPARENDO #" + comparendo.NUMEROCOMPARENDO + " NO FUE ACTUALIZADA]");
                            }
                            else
                                setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - ERROR [LA INFRACCIONCOMPARENDO DEL COMPARENDO #" + comparendo.NUMEROCOMPARENDO + " NO FUE ENCONTRADA]");
                        }
                        else
                        {
                            if (!String.IsNullOrWhiteSpace(comparendo.NUMEROCOMPARENDO))
                            {
                                comparendo.ID_COMPARENDO = serviciosGeneralesComp.crearComparendo(comparendo, myUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName());
                                if (comparendo.ID_COMPARENDO > 0)
                                {
                                    setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Confirmación [EL COMPARENDO #" + comparendo.NUMEROCOMPARENDO + " FUE CREADO CORRECTAMENTE]");
                                    if (infraccionComparendo != null)
                                    {
                                        infraccionComparendo.IDCOMPARENDO = comparendo.ID_COMPARENDO;
                                        if (serviciosGeneralesComp.crearInfraccionComparendoDesdePlanos(infraccionComparendo, myUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName()))
                                            setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Confirmación [SE CREO EL REGISTRO INFRACCIONCOMPARENDO PARA EL COMPARENDO #" + comparendo.NUMEROCOMPARENDO + " FUE CREADO CORRECTAMENTE]");
                                        else
                                            setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [NO SE CREO EL REGISTRO INFRACCIONCOMPARENDO PARA EL COMPARENDO #" + comparendo.NUMEROCOMPARENDO + " POR LO TANTO ESTE COMPARENDO NO VA A FUNCIONAR CORRECTAMENTE]");
                                    }
                                    else
                                        setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [NO SE CREO EL REGISTRO INFRACCIONCOMPARENDO PARA EL COMPARENDO #" + comparendo.NUMEROCOMPARENDO + " POR LO TANTO EL COMPARENDO NO VA A FUNCIONAR CORRECTAMENTE]");
                                }
                                else
                                    setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL COMPARENDO #" + comparendo.NUMEROCOMPARENDO + " NO FUE CREADO]");
                            }
                            else
                                setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL COMPARENDO NO FUE CREADO PORQUE NO TIENE NUMERO DE COMPARENDO]");
                        }


                        //Testigo necesita el comparendo
                        if (testigo != null && comparendo.ID_COMPARENDO != null && comparendo.ID_COMPARENDO > 0)
                        {
                            testigoComp tmpTestigo = new LibreriasSintrat.ServiciosGeneralesComp.testigoComp();
                            tmpTestigo.ID_DOCTO = testigo.ID_DOCTO;
                            tmpTestigo.NROIDENTIFICACION = testigo.NROIDENTIFICACION;
                            tmpTestigo.ID_COMPARENDO = comparendo.ID_COMPARENDO;
                            if (!String.IsNullOrWhiteSpace(testigo.NROIDENTIFICACION) && !testigo.NROIDENTIFICACION.Equals("0"))
                            {
                                 if (serviciosGeneralesComp.crearTestigo(tmpTestigo) > 0)
                                    setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Confirmación [EL TESTIGO CON IDENTIFICACION #" + tmpTestigo.NROIDENTIFICACION + " FUE CREADO CORRECTAMENTE]");
                                 else
                                    setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL TESTIGO CON IDENTIFICACION #" + tmpTestigo.NROIDENTIFICACION + " NO FUE CREADO]");
                            }
                            else
                                setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL TESTIGO NO FUE CREADO PORQUE NO TIENE NUMERO DE IDENTIFICACION");

                        }

                        if (propietario != null)
                        {
                            if (comparendo.ID_COMPARENDO != null && comparendo.ID_COMPARENDO > 0)
                                propietario.ID_COMPARENDO = comparendo.ID_COMPARENDO;
                            if (vehiculo.IDVEHICULOCOMP != null && vehiculo.IDVEHICULOCOMP > 0)
                                propietario.ID_VEHICULO = vehiculo.IDVEHICULOCOMP;

                            propietarioVehComp tmpPropietario = new LibreriasSintrat.ServiciosGeneralesComp.propietarioVehComp();

                            if (propietario.ID_DOCTO != null && propietario.ID_DOCTO.Length > 0)
                                tmpPropietario.ID_DOCTO = propietario.ID_DOCTO;
                            if (propietario.NROIDENTIFICACION != null && propietario.NROIDENTIFICACION.Length > 0)
                                tmpPropietario.NROIDENTIFICACION = propietario.NROIDENTIFICACION;
                            if (propietario.ID_VEHICULO != null && propietario.ID_VEHICULO > 0)
                                tmpPropietario.ID_VEHICULO = propietario.ID_VEHICULO;
                            if (propietario.ID_COMPARENDO != null && propietario.ID_COMPARENDO > 0)
                                tmpPropietario.ID_COMPARENDO = propietario.ID_COMPARENDO;

                            tmpPropietario = serviciosGeneralesComp.searchPropietarioVehiculo(tmpPropietario);

                            if (tmpPropietario != null && tmpPropietario.ID_PROPIETARIOVEH != null && tmpPropietario.ID_PROPIETARIOVEH > 0)
                                setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Confirmación [EL PROPIETARIO CON IDENTIFICACION #" + propietario.NROIDENTIFICACION + " YA EXISTE EN LA BASE DE DATOS]");
                            else
                            {
                                if (propietario != null)
                                {
                                    if (!String.IsNullOrWhiteSpace(propietario.NROIDENTIFICACION) && !propietario.NROIDENTIFICACION.Equals("0"))
                                    {
                                        propietario.ID_PROPIETARIOVEH = serviciosGeneralesComp.crearPropietarioVehiculo(propietario);
                                        if (propietario.ID_PROPIETARIOVEH > 0)
                                            setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Confirmación [EL PROPIETARIO CON IDENTIFICACION #" + propietario.NROIDENTIFICACION + " FUE CREADO CORRECTAMENTE]");
                                        else
                                            setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL PROPIETARIO CON IDENTIFICACION #" + propietario.NROIDENTIFICACION + " NO FUE CREADO]");
                                    }
                                    else
                                        setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL PROPIETARIO NO FUE CREADO PORQUE NO TIENE NUMERO DE IDENTIFICACION]");
                                }
                                else
                                    setLog("Archivo [COMPARENDOS] - Linea [" + (i + 1).ToString() + "] - Error [NO HAY PROPIETARIO DE VEHICULO]");
                            }
                        }

                        
                    
                    }

                } 
                #endregion
                hiloComparendos.ReportProgress(1);
            }
        }

        private static int getIdCiudad(Object[] ciudades, String divipo)
        {
            int id = -1;
            foreach (ciudadComp ciudad in ciudades)
            {
                String tmpDivipo;
                tmpDivipo = ciudad.ID_DEPTO + ciudad.CODCIUDAD;
                tmpDivipo = completarCeros(tmpDivipo, 8);
                if (divipo.Equals(tmpDivipo))
                    id = ciudad.ID_CIUDAD;
            }
            return id;
        }

        private static String completarCeros(String valor, int size)
        {
            valor = valor.Trim();
            if (!String.IsNullOrWhiteSpace(valor))
                while (valor.Length < size)
                {
                    valor = valor + "0";
                }
            else
                return "0";
            return valor;
        }

        private void hiloComparendos_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            barComparendos.Value++;
            lblComparendosCargue.Text = "Comparendos " + ((barComparendos.Value * 100) / barComparendos.Maximum).ToString() + "%";
            //MessageBox.Show(e.ProgressPercentage.ToString());
        }

        private void hiloComparendos_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("El cargue del archivo de comparendos a terminado correctamente", "Proceso finalizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cargarPlanosSimit(3);
        }

        private void hiloResoluciones_DoWork(object sender, DoWorkEventArgs e)
        {
            Funciones myFun = new Funciones();
            ArrayList lstText = (ArrayList)e.Argument;
            for (int i = 0; i < lstText.Count - 1; i++)
            {
                #region Cargar linea
                if (lstText[i] != null && lstText[i].ToString().Length > 0)
                {
                    //cPlanoComparendo tmpPlanoComparendo = new cPlanoComparendo();
                    String[] splitLine = lstText[i].ToString().Split(',');

                    //Se llena el comparendo
                    //comparendoComp comparendo = new comparendoComp();
                    //if (!String.IsNullOrWhiteSpace(splitLine[1].ToString()))
                    //    comparendo.NUMEROCOMPARENDO = splitLine[1].ToString();
                    //else log sin numero de comparendo

                    //Se llena la resolucion
                    resolucionesComparendoComp resolucion = new resolucionesComparendoComp();

                    if (!String.IsNullOrWhiteSpace(splitLine[1].ToString()))
                        resolucion.NUMERO = splitLine[1].ToString();
                    else
                        setLog("Archivo [RESOLUCIONES] - Linea [" + (i + 1).ToString() + "] - Error [LA RESOLUCION NO TIENE NUMERO]");

                    //NUMERO DE RESOLUCION ANTERIOR splitLine[2]

                    if (!String.IsNullOrWhiteSpace(splitLine[3].ToString()))
                    {
                        try
                        {
                            resolucion.FECHA = DateTime.Parse(splitLine[3].ToString()).ToString("dd/MM/yyyy");
                        }
                        catch (Exception exp)
                        {
                            setLog("Archivo [RESOLUCIONES] - Linea [" + (i + 1).ToString() + "] - Error [LA FECHA DE LA RESOLUCION TIENE UN FORMATO INCORRECTO]");
                        }
                    }

                    //TIPO DE RESOLUCION PENDIENTE PORQUE LA TABLA TIPO RESOLUCION LOS ID NO CUADRAN splitLine[4]
                    if (!String.IsNullOrWhiteSpace(splitLine[4].ToString()))
                    {
                        tipoResolucionComp tipoResolucion = new tipoResolucionComp();
                        ServiciosDocumentosService servicioDocumentos = WS.ServiciosDocumentosService();
                        tipoResolucion.CODTIPORESOLUCION = splitLine[4].ToString();
                        Object[] lstTiposResolucion = servicioDocumentos.buscarTipoResolucion(tipoResolucion,1);
                        if (lstTiposResolucion != null && lstTiposResolucion.Length > 0)
                        {
                            tipoResolucion = (tipoResolucionComp)lstTiposResolucion[0];
                            resolucion.ID_TIPORESOLUCION = tipoResolucion.IDTIPORESOLUCION;
                        }
                        else
                            setLog("Archivo [RESOLUCIONES] - Linea [" + (i + 1).ToString() + "] - Error [LA RESOLUCION #" + resolucion.NUMERO + " TIENE UN TIPO DE RESOLUCION QUE NO SE ENCONTRO EN LA BASE DE DATOS]");
                    }

                    //Tiempo de suspension
                    if (!String.IsNullOrWhiteSpace(splitLine[5].ToString()))
                    {
                        if (!String.IsNullOrWhiteSpace(resolucion.FECHA))
                        {
                            String fechaSuspencion = splitLine[5].ToString();
                            try
                            {
                                if (DateTime.Parse(resolucion.FECHA) <= DateTime.Parse(fechaSuspencion))
                                    resolucion.TIEMPOSUSPENSIONLIC = getNumMeses(fechaSuspencion, resolucion.FECHA);
                            }
                            catch (Exception EXP)
                            {
                                setLog("Archivo [RESOLUCIONES] - Linea [" + (i + 1).ToString() + "] - Error [LA FECHA DE RESOLUCION O DE SUSPENSION TIENEN UN FORMATO INCORRECTO]");
                            }
                        }
                    }
                    else
                        setLog("Archivo [RESOLUCIONES] - Linea [" + (i + 1).ToString() + "] - Información [LA RESOLUCION NO TIENE FECHA DE SUSPENCION DE LA LICENCIA]");

                    resolucionInfraccionesComp resolucionInfracciones = null;
                    infracionComparendoComp tmpInfraccionComparendo = null;

                    if (!String.IsNullOrWhiteSpace(splitLine[6].ToString()))
                    {
                        comparendoComp tmpComparendo = new LibreriasSintrat.ServiciosGeneralesComp.comparendoComp();
                        tmpComparendo.NUMEROCOMPARENDO = splitLine[6].ToString();
                        ServiciosGeneralesCompService serviciosGeneralesComparendos = WS.ServiciosGeneralesCompService();
                        Object[] lstComparendos = serviciosGeneralesComparendos.searchComparendo(tmpComparendo);

                        if (lstComparendos != null && lstComparendos.Length > 0)
                        {
                            tmpComparendo = (comparendoComp)lstComparendos[0];
                            tmpInfraccionComparendo = new LibreriasSintrat.ServiciosGeneralesComp.infracionComparendoComp();

                            if (tmpComparendo != null && tmpComparendo.ID_COMPARENDO != null && tmpComparendo.ID_COMPARENDO > 0)
                            {
                                tmpInfraccionComparendo.IDCOMPARENDO = tmpComparendo.ID_COMPARENDO;
                                tmpInfraccionComparendo = serviciosGeneralesComparendos.getInfraccionComparendo(tmpInfraccionComparendo);
                                if (tmpInfraccionComparendo != null && tmpInfraccionComparendo.ID > 0)
                                {
                                    resolucionInfracciones = new resolucionInfraccionesComp();
                                    resolucionInfracciones.IDINFRACCION = tmpInfraccionComparendo.ID;
                                }
                                else
                                    setLog("Archivo [RESOLUCIONES] - Linea [" + (i + 1).ToString() + "] - Error [EL COMPARENDO #" + splitLine[6].ToString() + ", DE LA RESOLUCION #" + resolucion.NUMERO + ", NO TIENE UN REGISTRO EN LA TABLA INFRACCIONCOMPARENDO]");
                            }
                            else
                                setLog("Archivo [RESOLUCIONES] - Linea [" + (i + 1).ToString() + "] - Error [EL COMPARENDO #" + splitLine[6].ToString() + ", DE LA RESOLUCION #" + resolucion.NUMERO + ", NO TIENE UN IDENTIFICADOR VALIDO EN LA BASE DE DATOS]");
                        }
                        else
                            setLog("Archivo [RESOLUCIONES] - Linea [" + (i + 1).ToString() + "] - Error [EL COMPARENDO #" + splitLine[6].ToString() + ", DE LA RESOLUCION #" + resolucion.NUMERO + ", NO EXISTE EN LA BASE DE DATOS]");

                    }
                    else
                        setLog("Archivo [RESOLUCIONES] - Linea [" + (i + 1).ToString() + "] - Error [LA RESOLUCION #" + resolucion.NUMERO + " NO TIENE EL NUMERO DEL COMPARENDO]");

                    if (resolucion != null)
                    {
                        resolucion.IDUSUARIO = myUsuario.ID_USUARIO;
                    
                    
                        //PERSISTENCIA
                        ServiciosDocumentosService servicioDocumentos = WS.ServiciosDocumentosService();
                        resolucionesComparendoComp tmpResolucion = new resolucionesComparendoComp();
                    
                        if (!String.IsNullOrWhiteSpace(resolucion.NUMERO))
                            tmpResolucion.NUMERO = resolucion.NUMERO;

                        //Funciones myFun = new Funciones();

                        //if (!String.IsNullOrWhiteSpace(resolucion.FECHA))
                        //    tmpResolucion.FECHA =  myFun.convFormatoFecha(resolucion.FECHA, "MM/dd/yyyy");

                        if (resolucion.TIEMPOSUSPENSIONLIC != null && resolucion.TIEMPOSUSPENSIONLIC > 0)
                            tmpResolucion.TIEMPOSUSPENSIONLIC = resolucion.TIEMPOSUSPENSIONLIC;

                        //Se busca la resolucion para ver si ya existe
                        tmpResolucion = servicioDocumentos.buscarResolucionComparendoComp(tmpResolucion);

                        //Si la resolucion existe
                        if (tmpResolucion != null && tmpResolucion.ID > 0)
                        {
                            if (!String.IsNullOrWhiteSpace(resolucion.FECHA))
                                tmpResolucion.FECHA = resolucion.FECHA;

                            if (resolucion.TIEMPOSUSPENSIONLIC != null && resolucion.TIEMPOSUSPENSIONLIC > 0)
                                tmpResolucion.TIEMPOSUSPENSIONLIC = resolucion.TIEMPOSUSPENSIONLIC;

                            if (resolucion.ID_TIPORESOLUCION != null && resolucion.ID_TIPORESOLUCION > 0)
                                tmpResolucion.ID_TIPORESOLUCION = resolucion.ID_TIPORESOLUCION;

                            if (!String.IsNullOrWhiteSpace(resolucion.FECHA))
                                resolucion.FECHA = myFun.convFormatoFecha(resolucion.FECHA, "MM/dd/yyyy");

                            //Se actualiza la resolucion
                           if (servicioDocumentos.actualizarResolucionComparendo(tmpResolucion))
                                setLog("Archivo [RESOLUCIONES] - Linea [" + (i + 1).ToString() + "] - Información [LA RESOLUCION #" + resolucion.NUMERO + " FUE ACTUALIZADA CORRECTAMENTE]");
                            else
                                setLog("Archivo [RESOLUCIONES] - Linea [" + (i + 1).ToString() + "] - Error [LA RESOLUCION #" + resolucion.NUMERO + " NO FUE ACTUALIZADA]");
                        }
                        else //Si la resolucion no existe
                        {
                            //Si se encontro el comparendo de la resolucion que se va a crear
                            if (tmpInfraccionComparendo != null && tmpInfraccionComparendo.ID > 0)
                            {

                                //Se crea la resolucion
                                resolucion = servicioDocumentos.insertarResolucionComparendo(resolucion, myUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName());

                                //Si se creo la resolucion
                                if (resolucion != null && resolucion.ID > 0)
                                {
                                    setLog("Archivo [RESOLUCIONES] - Linea [" + (i + 1).ToString() + "] - Información [LA RESOLUCION #" + resolucion.NUMERO + " FUE CREADA CORRECTAMENTE]");

                                    if (resolucionInfracciones != null && resolucionInfracciones.IDINFRACCION != null && resolucionInfracciones.IDINFRACCION > 0)
                                    {
                                        resolucionInfracciones.IDRESOLUCION = resolucion.ID;
                                        resolucionInfracciones.IDINFRACCION = tmpInfraccionComparendo.ID;

                                        //Se crea la resolucionInfracciones
                                        resolucionInfracciones = servicioDocumentos.insertarResolucionInfracciones(resolucionInfracciones, myUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName());

                                        //Si se crea la resolucionInfraccion correctamente
                                        if (resolucionInfracciones != null && resolucionInfracciones.ID != null && resolucionInfracciones.ID > 0)
                                            setLog("Archivo [RESOLUCIONES] - Linea [" + (i + 1).ToString() + "] - Información [SE CREO UN REGISTRO EN LA TABLE RESOLUCIONINFRACCIONES PARA LA RESOLUCION #" + resolucion.NUMERO);
                                        else// Si no se creo la resolucionInfraccion
                                            setLog("Archivo [RESOLUCIONES] - Linea [" + (i + 1).ToString() + "] - Error [PARA LA RESOLUCION #" + resolucion.NUMERO + " NO FUE CREADO UN REGISTRO EN LA TABLA RESOLUCIONINFRACCIONES POR LO TANTO LA RESOLUCION NO VA A FUNCIONAR]");
                                    }
                                    else
                                        setLog("Archivo [RESOLUCIONES] - Linea [" + (i + 1).ToString() + "] - Error [PARA LA RESOLUCION #" + resolucion.NUMERO + " NO FUE CREADO UN REGISTRO EN LA TABLA RESOLUCIONINFRACCIONES POR LO TANTO LA RESOLUCION NO VA A FUNCIONAR]");
                                }
                                else //Si no se creo la resolucion
                                    setLog("Archivo [RESOLUCIONES] - Linea [" + (i + 1).ToString() + "] - Error [LA RESOLUCION #" + resolucion.NUMERO + " NO FUE CREADA]");
                            }
                            else //Si no se encontro el comparendo de la resolucion que se va a crear
                                setLog("Archivo [RESOLUCIONES] - Linea [" + (i + 1).ToString() + "] - Error [EL COMPARENDO #" + splitLine[6].ToString() + ", DE LA RESOLUCION #" + resolucion.NUMERO + ", NO EXISTE EN LA BASE DE DATOS, POR LO TANTO LA RESOLUCION NO SE PUEDO CREAR]");
                        }
                    }
                }
                #endregion
                hiloResoluciones.ReportProgress(1);
            }
        }

        private void hiloResoluciones_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            barResoluciones.Value++;
            lblResolucionesCargue.Text = "Resoluciones " + ((barResoluciones.Value * 100) / barResoluciones.Maximum).ToString() + "%";
        }

        private void hiloResoluciones_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("El cargue del archivo de resoluciones a terminado correctamente", "Proceso finalizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cargarPlanosSimit(2);
        }

        private void lblResolucionesCargue_Click(object sender, EventArgs e)
        {
        }

        private void hiloRecaudos_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            barRecaudos.Value++;
            lblRecaudosCargue.Text = "Recaudos " + ((barRecaudos.Value * 100) / barRecaudos.Maximum).ToString() + "%";
        }

        private void hiloRecaudos_DoWork(object sender, DoWorkEventArgs e)
        {
            ArrayList lstText = (ArrayList)e.Argument;
            for (int i = 1; i < lstText.Count - 1; i++)
            {
                #region Cargar linea
                if (lstText[i] != null && lstText[i].ToString().Length > 0)
                {
                    //cPlanoComparendo tmpPlanoComparendo = new cPlanoComparendo();
                    String[] splitLine = lstText[i].ToString().Split(',');

                    String fechaContable = String.Empty;
                    String horaTransaccion = String.Empty;
                    String fechaReal = String.Empty;
                    String codigoCanalOrigen = String.Empty;
                    String descripcionOrigen = String.Empty;
                    String totalEfectivo = String.Empty;
                    String totalCheque = String.Empty;
                    String totalRecaudo = String.Empty;
                    String numeroComparendo = String.Empty;
                    String polca = String.Empty;
                    String identificacionInfractor = String.Empty;
                    String tipoRecaudo = String.Empty;
                    String divipoSecretaria = String.Empty;
                    String numeroConsignacion = String.Empty;

                    if (!String.IsNullOrWhiteSpace(splitLine[1].ToString()))
                        fechaContable = splitLine[1].ToString();

                    if (!String.IsNullOrWhiteSpace(splitLine[2].ToString()))
                        horaTransaccion = splitLine[2].ToString();

                    if (!String.IsNullOrWhiteSpace(splitLine[3].ToString()))
                        fechaReal = splitLine[3].ToString();

                    if (!String.IsNullOrWhiteSpace(splitLine[4].ToString()))
                        codigoCanalOrigen = splitLine[4].ToString();

                    if (!String.IsNullOrWhiteSpace(splitLine[5].ToString()))
                        descripcionOrigen = splitLine[5].ToString();

                    if (!String.IsNullOrWhiteSpace(splitLine[6].ToString()))
                        totalEfectivo = splitLine[6].ToString();

                    if (!String.IsNullOrWhiteSpace(splitLine[7].ToString()))
                        totalCheque = splitLine[7].ToString();

                    if (!String.IsNullOrWhiteSpace(splitLine[8].ToString()))
                        totalRecaudo = splitLine[8].ToString();

                    if (!String.IsNullOrWhiteSpace(splitLine[9].ToString()))
                        numeroComparendo = splitLine[9].ToString();

                    if (!String.IsNullOrWhiteSpace(splitLine[10].ToString()))
                        polca = splitLine[10].ToString();

                    if (!String.IsNullOrWhiteSpace(splitLine[11].ToString()))
                        identificacionInfractor = splitLine[11].ToString();

                    if (!String.IsNullOrWhiteSpace(splitLine[12].ToString()))
                        tipoRecaudo = splitLine[12].ToString();

                    if (!String.IsNullOrWhiteSpace(splitLine[13].ToString()))
                        divipoSecretaria = splitLine[13].ToString();

                    if (!String.IsNullOrWhiteSpace(splitLine[14].ToString()))
                        numeroConsignacion = splitLine[14].ToString();

                    reciboscomparendo reciboComparendo = new reciboscomparendo();

                    //1. verificar si el comparendo ya se encuentra pago.
                    comparendoComp tmpComparendo = new LibreriasSintrat.ServiciosGeneralesComp.comparendoComp();

                    if (!String.IsNullOrWhiteSpace(numeroComparendo))
                    {
                        ServiciosGeneralesCompService serviciosGeneralesComp = WS.ServiciosGeneralesCompService();
                        tmpComparendo.NUMEROCOMPARENDO = numeroComparendo.Trim();
                        Object[] lstComparendos = serviciosGeneralesComp.searchComparendo(tmpComparendo);

                        //Si el comparendo si existe se sigue el proceso de lo contrario no
                        if (lstComparendos != null && lstComparendos.Length > 0)
                        {
                            tmpComparendo = (comparendoComp)lstComparendos[0];

                            infracionComparendoComp tmpInfraccionComparendo = new LibreriasSintrat.ServiciosGeneralesComp.infracionComparendoComp();
                            tmpInfraccionComparendo.IDCOMPARENDO = tmpComparendo.ID_COMPARENDO;
                            tmpInfraccionComparendo = serviciosGeneralesComp.getInfraccionComparendo(tmpInfraccionComparendo);

                            //Si existe el registro en infraccionComparendo
                            if (tmpInfraccionComparendo != null && tmpInfraccionComparendo.ID > 0)
                            {
                                if (tmpInfraccionComparendo.IDESTADO == 2)
                                    setLog("Archivo [RECAUDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL COMPARENDO #" + tmpComparendo.NUMEROCOMPARENDO + ", YA SE ENCUENTRA EN ESTADO PAGADO]");
                                else
                                {
                                    viewLiquidacionComparendo liquidacionComparendo = new LibreriasSintrat.ServiciosGeneralesComp.viewLiquidacionComparendo();
                                    liquidacionComparendo.ID_COMPARENDO = tmpComparendo.ID_COMPARENDO;

                                    //Obtengo el id de laliquidacion
                                    Object[] lst = serviciosGeneralesComp.getViewLiquiComprendo(liquidacionComparendo);

                                    //Si tiene liquidacion
                                    if (lst != null && lst.Length > 0)
                                    {
                                        liquidacionComparendo = (viewLiquidacionComparendo)lst[0];

                                        reciboscomparendo tmpReciboComparendo = new reciboscomparendo();
                                        tmpReciboComparendo.IDLIQUIDACION = liquidacionComparendo.IDLIQUIDACION;

                                        ServiciosReciboscomparendoService servicioRecibosComparendo = WS.ServiciosReciboscomparendoService();
                                        Object[] lstRecibosComparendo = servicioRecibosComparendo.buscarReciboscomparendo(tmpReciboComparendo);

                                        //Cuando tiene un recibo
                                        if (lstRecibosComparendo != null && lstRecibosComparendo.Length > 0)
                                        {
                                            tmpReciboComparendo = (reciboscomparendo)lstRecibosComparendo[0];
                                            tmpReciboComparendo.ESTADO = 2;
                                            tmpReciboComparendo.IDUSRPAGO = myUsuario.ID_USUARIO;
                                            tmpReciboComparendo.NROCONSIGNACIONBANCO = numeroConsignacion;

                                            //Estas lineas estan pendientes hay que hacerles un seguimiento
                                            //tmpReciboComparendo.FECHAREGISTRO = DateTime.Parse(tmpReciboComparendo.FECHAREGISTRO, System.Globalization.CultureInfo.InvariantCulture).ToString("MM/dd/yyyy");
                                            //tmpReciboComparendo.FECHAPAGO = DateTime.Parse(fechaContable, System.Globalization.CultureInfo.InvariantCulture).ToString("MM/dd/yyyy");

                                            //Se actualiza el recibo
                                            if (servicioRecibosComparendo.editarReciboscomparendo(tmpReciboComparendo))
                                            {
                                                setLog("Archivo [RECAUDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL COMPARENDO #" + numeroComparendo + ", DEL RECAUDO AL QUE SE HACE REFERENCIA EN ESTA LINEA, SE ACTUALIZO CON EXITO EL REGISTRO EN LA TABLA RECIBOS COMPAQRENDO, DEL RECIBO #" + tmpReciboComparendo.NUMERO_RECIBO + "]");
                                                
                                                //actualizamos liquidacion
                                                liquidacionComp tmpLiquidacion = new liquidacionComp();
                                                tmpLiquidacion.IDLIQUIDACION = liquidacionComparendo.IDLIQUIDACION;

                                                ServiciosLiquidacionCompService servicioLiquidacion = WS.ServiciosLiquidacionCompService();
                                                Object[] lstLiquidaciones = servicioLiquidacion.getLiquidaciones(tmpLiquidacion);

                                                if (lstLiquidaciones != null && lstLiquidaciones.Length > 0)
                                                {
                                                    tmpLiquidacion = (liquidacionComp)lstLiquidaciones[0];
                                                    tmpLiquidacion.SALDO = tmpLiquidacion.SALDO - (float)tmpReciboComparendo.VALOR;

                                                    if (tmpLiquidacion.SALDO < 0)
                                                        tmpLiquidacion.SALDO = 0;

                                                    if (servicioLiquidacion.editarLiquidacion(tmpLiquidacion, myUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName()))
                                                    {
                                                        setLog("Archivo [RECAUDOS] - Linea [" + (i + 1).ToString() + "] - Información [EL COMPARENDO #" + numeroComparendo + ", DEL RECAUDO AL QUE SE HACE REFERENCIA EN ESTA LINEA, FUE ACTUALIZADA CORRECTAMENTE LA LIQUIDACION DEL RECIBO #" + tmpReciboComparendo.NUMERO_RECIBO + "]");

                                                        //actualizar pagoscomparendo
                                                        //solo se actualiza el pago que corresponde al recibo
                                                        //buscamos el recibo cuota
                                                        recibocuotas tmpReciboCuotas = new recibocuotas();
                                                        tmpReciboCuotas.IDRECIBO = tmpReciboComparendo.ID;
                                                        Object[] lstRecibosCuotas = servicioLiquidacion.getReciboCuota(tmpReciboCuotas);

                                                        if (lstRecibosCuotas != null && lstRecibosCuotas.Length > 0)
                                                        {
                                                            tmpReciboCuotas = (recibocuotas)lstRecibosCuotas[0];

                                                            //Buscamos el pago
                                                            pagosComp tmpPagosComp = new pagosComp();
                                                            tmpPagosComp.ID = tmpReciboCuotas.IDCUOTA;
                                                            Object[] lstPagosComp = servicioLiquidacion.getPagosComp(tmpPagosComp);
                                                            if (lstPagosComp != null && lstPagosComp.Length > 0)
                                                            {
                                                                //Recorremos los pagos y les cambiamos el estado
                                                                foreach (pagosComp pagos in lstPagosComp)
                                                                {
                                                                    pagos.ESTADO = 2;

                                                                    //El servidor recibe fechas en formato "MM/dd/yyyy"
                                                                    try
                                                                    {
                                                                        pagos.FECHAPAGO = DateTime.Parse(pagos.FECHAPAGO, System.Globalization.CultureInfo.InvariantCulture).ToString("MM/dd/yyyy");
                                                                    }
                                                                    catch 
                                                                    { 
                                                                        setLog("Archivo [RECAUDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL COMPARENDO #" + numeroComparendo + ", DEL RECAUDO AL QUE SE HACE REFERENCIA EN ESTA LINEA, LA FECHA DE PAGO NO ES UN DATO VALIDO]"); 
                                                                    }

                                                                    if (servicioLiquidacion.editarPagosComp(pagos, myUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName()))
                                                                    {
                                                                        setLog("Archivo [RECAUDOS] - Linea [" + (i + 1).ToString() + "] - Información [EL COMPARENDO #" + numeroComparendo + ", DEL RECAUDO AL QUE SE HACE REFERENCIA EN ESTA LINEA, LA CUOTA (PAGO) #" + pagos.NOCUOTA.ToString() + " FUE ACTUALIZADA CORRECTAMENTE]");

                                                                    }
                                                                    else
                                                                        setLog("Archivo [RECAUDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL COMPARENDO #" + numeroComparendo + ", DEL RECAUDO AL QUE SE HACE REFERENCIA EN ESTA LINEA, LA CUOTA (PAGO) #" + pagos.NOCUOTA.ToString() + " NO FUE ACTUALIZADA]");
                                                                }

                                                            }
                                                            else //Si no hay pagos
                                                            {
                                                                tmpPagosComp = new pagosComp();
                                                                tmpPagosComp.ESTADO = 2;
                                                                tmpPagosComp.NOCUOTA = 1;
                                                                tmpPagosComp.PORCENTAJE = 100;
                                                                tmpPagosComp.VALOR = tmpLiquidacion.TOTAL;
                                                                tmpPagosComp = servicioLiquidacion.registarConFechaPagoComp(tmpPagosComp, myUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName());
                                                                if (tmpPagosComp != null && tmpPagosComp.ID > 0)
                                                                    setLog("Archivo [RECAUDOS] - Linea [" + (i + 1).ToString() + "] - Información [EL COMPARENDO #" + numeroComparendo + ", DEL RECAUDO AL QUE SE HACE REFERENCIA EN ESTA LINEA, SE LE CREO EL PAGO EN LA TABLA PAGOS COMPARENDO CORRECTAMENTE]");
                                                                else
                                                                    setLog("Archivo [RECAUDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL COMPARENDO #" + numeroComparendo + ", DEL RECAUDO AL QUE SE HACE REFERENCIA EN ESTA LINEA, NO SE LE CREO EL PAGO EN LA TABLA PAGOS COMPARENDO CORRECTAMENTE]");
                                                            }
                                                        }
                                                        else
                                                            setLog("Archivo [RECAUDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL COMPARENDO #" + numeroComparendo + ", DEL RECAUDO AL QUE SE HACE REFERENCIA EN ESTA LINEA, FUE ACTUALIZADA CORRECTAMENTE LA LIQUIDACION DEL RECIBO #" + tmpReciboComparendo.NUMERO_RECIBO + "]");

                                                        //Actualizo la Infraccion Comparendo
                                                        tmpInfraccionComparendo.IDESTADO = tmpLiquidacion.SALDO <= 0 ? 2 : 20;

                                                        if (serviciosGeneralesComp.actualizarInfraccionComparendo(tmpInfraccionComparendo, myUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName()))
                                                            setLog("Archivo [RECAUDOS] - Linea [" + (i + 1).ToString() + "] - Información [EL COMPARENDO #" + numeroComparendo + ", DEL RECAUDO AL QUE SE HACE REFERENCIA EN ESTA LINEA, FUE ACTUALIZADA LA INFRACCION COMPARENDO CORRECTAMENTE]");
                                                        else
                                                            setLog("Archivo [RECAUDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL COMPARENDO #" + numeroComparendo + ", DEL RECAUDO AL QUE SE HACE REFERENCIA EN ESTA LINEA, NO FUE ACTUALIZADA LA INFRACCION COMPARENDO]");
                                                    }
                                                    else
                                                        setLog("Archivo [RECAUDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL COMPARENDO #" + numeroComparendo + ", DEL RECAUDO AL QUE SE HACE REFERENCIA EN ESTA LINEA, NO PUDO SER EDITADA LA LIQUIDACION DEL RECIBO #" + tmpReciboComparendo.NUMERO_RECIBO + "]");
                                                }
                                                else
                                                    setLog("Archivo [RECAUDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL COMPARENDO #" + numeroComparendo + ", DEL RECAUDO AL QUE SE HACE REFERENCIA EN ESTA LINEA, NO PUDO SER EDITADO EL REGISTRO EN LA TABLA RECIBOS COMPAQRENDO, DEL RECIBO #" + tmpReciboComparendo.NUMERO_RECIBO + "]");

                                            }
                                            else //Cundo las actualizacion del recibo dio error
                                                setLog("Archivo [RECAUDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL COMPARENDO #" + numeroComparendo + ", DEL RECAUDO AL QUE SE HACE REFERENCIA EN ESTA LINEA, NO PUDO SER EDITADO EL RECIBO #" + tmpReciboComparendo.NUMERO_RECIBO + "]");
                                        }
                                        else //Cuando no tiene un recibo pero si una liquidacion
                                        {
                                        }
                                    }
                                    else //Si la liquidacion no existe entonces se debe crear todo
                                    {
                                        liquidacionComp liquidacion = new liquidacionComp();
                                        liquidacion.IDUSUARIO = myUsuario.ID_USUARIO;
                                        liquidacion.NROCOMP = tmpComparendo.NUMEROCOMPARENDO;
                                        liquidacion.TOTAL = float.Parse(totalRecaudo);
                                        liquidacion.SALDO = 0;
                                        liquidacion.FECHAREGISTRO = DateTime.Parse(fechaContable).ToString("MM/dd/yyyy");
                                        ServiciosLiquidacionCompService servicioLiquidacion = WS.ServiciosLiquidacionCompService();

                                        //Se crea la liquidacion
                                        liquidacion = servicioLiquidacion.insertarLiquidacionCom(liquidacion, myUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName());
                                        if (liquidacion != null && liquidacion.IDLIQUIDACION > 0)
                                        {
                                            reciboscomparendo recibo_comparendo = new reciboscomparendo();
                                            recibo_comparendo.IDLIQUIDACION = liquidacion.IDLIQUIDACION;

                                            if (!String.IsNullOrWhiteSpace(identificacionInfractor))
                                            {
                                                infractorComp infractor = new LibreriasSintrat.ServiciosGeneralesComp.infractorComp();
                                                infractor.NROIDENTIFICACION = identificacionInfractor;
                                                serviciosGeneralesComp = WS.ServiciosGeneralesCompService();

                                                //Se obtiene el infractor
                                                infractor = serviciosGeneralesComp.buscarInfractor(infractor);
                                                if (infractor != null && infractor.ID_INFRACTOR > 0)
                                                {
                                                    recibo_comparendo.IDINFRACTOR = infractor.ID_INFRACTOR;
                                                }
                                                else //Si no se encontro el infractor
                                                    setLog("Archivo [RECAUDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL COMPARENDO #" + numeroComparendo + ", NO SE ENCONTRO EL INFRACTOR EN LA BASE DE DATOS]");
                                            }

                                            //Se gurada el id del usuario
                                            recibo_comparendo.IDUSUARIO = myUsuario.ID_USUARIO;

                                            if (!String.IsNullOrWhiteSpace(numeroComparendo))
                                            {
                                                comparendoComp comparendo = new LibreriasSintrat.ServiciosGeneralesComp.comparendoComp();
                                                comparendo.NUMEROCOMPARENDO = numeroComparendo;
                                                serviciosGeneralesComp = WS.ServiciosGeneralesCompService();
                                                Object[] comparendos = serviciosGeneralesComp.searchComparendo(comparendo);
                                                if (comparendos != null && comparendos.Length > 0)
                                                {
                                                    comparendo = (comparendoComp)comparendos[0];
                                                    infracionComparendoComp infraccionComparendo = new LibreriasSintrat.ServiciosGeneralesComp.infracionComparendoComp();
                                                    infraccionComparendo.IDCOMPARENDO = comparendo.ID_COMPARENDO;
                                                    infraccionComparendo = serviciosGeneralesComp.getInfraccionComparendo(infraccionComparendo);
                                                    if (infraccionComparendo != null && infraccionComparendo.ID > 0)
                                                        recibo_comparendo.ESTADO = infraccionComparendo.IDESTADO;
                                                    else //No existe la infraccion comparendo 
                                                    {
                                                    }

                                                    //Se guarda ReciboComparendo
                                                    ServiciosReciboscomparendoService servicioReciboComparendo = WS.ServiciosReciboscomparendoService();
                                                    int idReciboComparendo = servicioReciboComparendo.crearReciboscomparendo(recibo_comparendo);

                                                    if (idReciboComparendo > 0)
                                                    {
                                                        pagosComp pagoComparendo = new pagosComp();
                                                        pagoComparendo.IDLIQUIDACION = liquidacion.IDLIQUIDACION;
                                                        pagoComparendo.NOCUOTA = 1;
                                                        if (!String.IsNullOrWhiteSpace(totalRecaudo))
                                                        {
                                                            try
                                                            {
                                                                pagoComparendo.VALOR = float.Parse(totalRecaudo);
                                                            }
                                                            catch 
                                                            { 
                                                                setLog("Archivo [RECAUDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL COMPARENDO #" + numeroComparendo + ", EL VALOR PAGADO NO ES UN DATO VALIDO]"); 
                                                            }
                                                        }
                                                        else
                                                            setLog("Archivo [RECAUDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL COMPARENDO #" + numeroComparendo + ", NO SE ENCONTRO EL VALOR PAGADO]");

                                                        if (!String.IsNullOrWhiteSpace(fechaContable))
                                                        {
                                                            try
                                                            {
                                                                pagoComparendo.FECHAPAGO = DateTime.Parse(fechaContable).ToString("MM/dd/yyyy");
                                                            }
                                                            catch
                                                            {
                                                                setLog("Archivo [RECAUDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL COMPARENDO #" + numeroComparendo + ", LA FECHA DE PAGO ES UN DATO NO VALIDO]");
                                                            }
                                                        }
                                                        else
                                                            setLog("Archivo [RECAUDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL COMPARENDO #" + numeroComparendo + ", NO SE ENCONTRO LA FECHA DE PAGO]");

                                                        pagoComparendo.ESTADO = 2;
                                                        pagoComparendo.PORCENTAJE = 100;

                                                        if (servicioLiquidacion == null)
                                                            servicioLiquidacion = WS.ServiciosLiquidacionCompService();



                                                        //Creo el pago
                                                        pagoComparendo = servicioLiquidacion.registarPagoComp(pagoComparendo, myUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName());

                                                        if (pagoComparendo != null && pagoComparendo.ID > 0)
                                                        {
                                                            setLog("Archivo [RECAUDOS] - Linea [" + (i + 1).ToString() + "] - Información [EL COMPARENDO #" + numeroComparendo + ", SE REGISTRO EL PAGO EN LA TABLA PAGOSCOMPARENDO]");

                                                            recibocuotas reciboCuota = new recibocuotas();
                                                            reciboCuota.IDRECIBO = idReciboComparendo;
                                                            reciboCuota.IDCUOTA = pagoComparendo.ID;
                                                            reciboCuota.FECHAREGISTRO = pagoComparendo.FECHAPAGO;
                                                            reciboCuota = servicioLiquidacion.crearReciboCuota(reciboCuota, myUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName());

                                                            if (reciboCuota.ID > 0)
                                                                setLog("Archivo [RECAUDOS] - Linea [" + (i + 1).ToString() + "] - Información [EL COMPARENDO #" + numeroComparendo + ", SE CREO UN REGISTRO EN LA TABLA RECIBOCUOTAS]");
                                                            else
                                                                setLog("Archivo [RECAUDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL COMPARENDO #" + numeroComparendo + ", NO FUE POSIBLE CREAR UN REGISTRO EN LA TABLA RECIBOCUOTAS]");
                                                        }
                                                        else
                                                            setLog("Archivo [RECAUDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL COMPARENDO #" + numeroComparendo + ", EL PAGO NO PUDO SER REGISTRADO EN LA TABLA PAGOSCOMPARENDO]");
                                                    }
                                                    else
                                                        setLog("Archivo [RECAUDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL COMPARENDO #" + numeroComparendo + ", NO SE PUDO CREAR EL REGISTRO EN LA TABLA RECIBOSCOMPARENDO]");

                                                }
                                                else //Si el comparendo no existe
                                                    setLog("Archivo [RECAUDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL COMPARENDO #" + numeroComparendo + ", NO EXISTE EN LA BASE DE DATOS]");
                                            }
                                            else //No se tiene el numero de comparendo
                                                setLog("Archivo [RECAUDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL COMPARENDO NO TIENE NUMERO]");

                                        }
                                        else //Si la liquidacion no puedo ser creada
                                            setLog("Archivo [RECAUDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL COMPARENDO #" + numeroComparendo + ", DEL RECAUDO AL QUE SE HACE REFERENCIA EN ESTA LINEA, NO SE PUDO CREAR LA LIQUIDACION PARA ESTE REGISTRO]");
                                    }
                                }
                            }
                            else //Si la infraccionComparendo no existe
                            {
                                setLog("Archivo [RECAUDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL COMPARENDO #" + numeroComparendo + ", DEL RECAUDO AL QUE SE HACE REFERENCIA EN ESTA LINEA, NO TIENE UN REGISTRO EN LA TABLA INFRACCIONCOMPARENDO]");
                            }
                        }
                        else // Si el comparendo no existe
                        {
                            setLog("Archivo [RECAUDOS] - Linea [" + (i + 1).ToString() + "] - Error [EL COMPARENDO #" + numeroComparendo + ", DEL RECAUDO AL QUE SE HACE REFERENCIA EN ESTA LINEA, NO EXISTE EN LA BASE DE DATOS]");
                        }

                    }
                #endregion
                    hiloRecaudos.ReportProgress(1);
                }
            }
        }

        private void hiloRecaudos_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("El cargue del archivo de recaudos a terminado correctamente", "Proceso finalizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        }

        private int getNumMeses(String fecha1, String fecha2)
        {
            TimeSpan tiempoTranscurrido;

            tiempoTranscurrido = DateTime.Parse(fecha2).Subtract(DateTime.Parse(fecha1));
            return tiempoTranscurrido.Days / 30;
        }
    }
}
 