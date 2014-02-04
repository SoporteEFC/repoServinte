using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Word = Microsoft.Office.Interop.Word;
using LibreriasSintrat.ServiciosDocumentos;
using LibreriasSintrat;
using LibreriasSintrat.utilidades;
using LibreriasSintrat.ServiciosGeneralesComp;
using LibreriasSintrat.ServiciosConfiguraciones;
using LibreriasSintrat.ServiciosUsuarios;


namespace Comparendos.servicios.documentos
{
    public class GenerarResoluciones
    {
        ServiciosDocumentosService serviciosDocumentos;
        ServiciosGeneralesCompService serviciosGeneralesComp;
        ServiciosConfiguracionesService serviciosConfiguraciones;

        Funciones funciones;


        public GenerarResoluciones()
        {
            serviciosDocumentos = WS.ServiciosDocumentosService();
            serviciosGeneralesComp = WS.ServiciosGeneralesCompService();
            serviciosConfiguraciones = WS.ServiciosConfiguracionesService();
            
            funciones = new Funciones();

        }

        public void crearResolucion(bool abrirDoc, string nombrePlantilla, int numResolucion, infractorComp myInfractor, tipoResolucionComp myTipoResolucion, usuarios myUsuario, string fechaResolucion, plantilla myPlantillaActual, viewComparendosResolSancionComp infoComparendo, ref resolucionesComparendoComp myResolucionComparendo)
        {
            numResolucion = serviciosDocumentos.obtenerNumeroResolucionComp(numResolucion);
            myResolucionComparendo.NUMERO = numResolucion.ToString();

            String nombreResolucion = funciones.quitarEspacios(myInfractor.NROIDENTIFICACION.ToString());
            nombreResolucion += "_" + myResolucionComparendo.NUMERO + "_" + myTipoResolucion.DES_TIPORESOLUCION;
            myResolucionComparendo.NOMBRE = nombreResolucion;


            //SE GENERA LA RESOLUCIÓN Y SE SUBE AL SERVIDOR
            generarResolucion(abrirDoc, nombrePlantilla, myInfractor, ref myPlantillaActual, myResolucionComparendo, infoComparendo);


            //fija el contenido de la plantilla modificada y registra la resolucion
            myResolucionComparendo.CONTENIDO = "<t>" + myPlantillaActual.ENCABEZADO + "<->\n\n\n";
            myResolucionComparendo.CONTENIDO += myPlantillaActual.CONTENIDO;

            myResolucionComparendo = serviciosDocumentos.insertarResolucionComparendo(myResolucionComparendo, WS.MyUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName());


            //ACTUALIZAR INFRACCION COMPARENDO
            infracionComparendoComp myInfraccionComparendo = new infracionComparendoComp();            
            myInfraccionComparendo.IDCOMPARENDO = infoComparendo.ID_COMPARENDO;
            myInfraccionComparendo.IDINFRACCION = infoComparendo.IDINFRACCION; //Se obtiene el id de infracComp
            myInfraccionComparendo = serviciosGeneralesComp.getInfraccionComparendo(myInfraccionComparendo);

            //ResolucionesInfracciones
            resolucionInfraccionesComp myResolucionInfraccion = new resolucionInfraccionesComp();
            myResolucionInfraccion.IDRESOLUCION = myResolucionComparendo.ID;
            myResolucionInfraccion.IDINFRACCION = myInfraccionComparendo.ID;
            myResolucionInfraccion = serviciosDocumentos.insertarResolucionInfracciones(myResolucionInfraccion, WS.MyUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName());

            //Se cambia el estado del comparendo en la base de datos
            myInfraccionComparendo.IDESTADO = myTipoResolucion.ID_NUEVOESTADO;
            serviciosGeneralesComp.cambiarEstadoComp(myInfraccionComparendo, WS.MyUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName());

            //se pone el nuevo estado en historico estados
            historicoEstadosComp myHistoricoComparendos = new historicoEstadosComp();            
            myHistoricoComparendos.ID_ESTADO = myTipoResolucion.ID_NUEVOESTADO;
            myHistoricoComparendos.ID_INFRACCIONCOMPARENDO = myInfraccionComparendo.ID;
            myHistoricoComparendos.IDUSUARIO = myUsuario.ID_USUARIO;
            myHistoricoComparendos.FECHA = fechaResolucion;
            serviciosGeneralesComp.insertarHistoricoEstadosComp(myHistoricoComparendos);
        }

        private void generarResolucion(bool abrirDoc, string nombrePlantilla, infractorComp myInfractor, ref plantilla myPlantillaActual, resolucionesComparendoComp myResolucionesComparendo, viewComparendosResolSancionComp infoComparendo)
        {
            String param;
            
            Object[] parametros = new Object[14];

            param = "FECHARESOLUCION = " + DateTime.Parse(myResolucionesComparendo.FECHA, System.Globalization.CultureInfo.InvariantCulture).ToString("dd/MM/yyyy");
            parametros[0] = param;

            param = "NUMRESOLUCION = " + myResolucionesComparendo.NUMERO;
            parametros[1] = param;

            param = "FECHAAUDIENCIA = " + DateTime.Parse(myResolucionesComparendo.FECHAAUDIENCIA, System.Globalization.CultureInfo.InvariantCulture).ToString("dd/MM/yyyy");
            parametros[2] = param;

            param = "MOTIVO = " + myResolucionesComparendo.MOTIVO;
            parametros[3] = param;

            param = "CONSIDERACIONJURIDICO = " + myResolucionesComparendo.CONSIDERACIONJURIDICA;
            parametros[4] = param;

            param = "MOTIVORESOLUCION = " + myResolucionesComparendo.MOTIVORESOLUCION;
            parametros[5] = param;

            param = "HECHOS = " + myResolucionesComparendo.HECHOS;
            parametros[6] = param;

            param = "SOLICITUD = " + myResolucionesComparendo.SOLICITUDRESOLUCION;
            parametros[7] = param;

            param = "NOMBRES = " + myInfractor.NOMBRES;
            parametros[8] = param;

            param = "APELLIDOS = " + myInfractor.APELLIDOS;
            parametros[9] = param;

            param = "NROIDENTIFICACION = " + myInfractor.NROIDENTIFICACION;
            parametros[10] = param;

            param = "NUMEROCOMPARENDO = " + infoComparendo.NUMEROCOMPARENDO;
            parametros[11] = param;

            param = "FECHACOMPARENDO = " + infoComparendo.FECHACOMPARENDO;
            parametros[12] = param;

            param = "DESCRIPCION = " + "CEDULA";
            parametros[13] = param;


            myPlantillaActual = serviciosDocumentos.procesarPlantillaValores(myPlantillaActual, parametros);

            parametros = new Object[2];

            param = "ID_INFRACTOR = " + myInfractor.ID_INFRACTOR;
            parametros[0] = param;

            param = "ID_COMPARENDO = " + infoComparendo.ID_COMPARENDO;
            parametros[1] = param;

            myPlantillaActual = serviciosDocumentos.procesarPlantillaComp(myPlantillaActual, parametros);

            String nombreDocumento = myResolucionesComparendo.NOMBRE;
            generarWord(abrirDoc, ref myPlantillaActual, nombreDocumento, nombrePlantilla);
        }

        private void generarWord(bool abrirDoc, ref plantilla myPlantillaActual, string nombreDocumento, string nombrePlantilla)
        {
            //*****///// PARTE PARA LA GENERACION DE DOCUMENTO DE RESOLUCION DE INFRACTOR EN WORD
            //Start Word and open the document template.
            // Objetos de word
            Word.Application oWord = new Word.Application();
            Word.Document oDoc;
            transferir myTransferencia = new transferir();

            object rutaPlantilla = serviciosConfiguraciones.leerRegistroIni("PLANTILLAS") + "\\" + nombrePlantilla;
            myTransferencia.archivoDelServerSinAbrir((string)rutaPlantilla);

            oWord.Visible = false;

            object newTmp = System.Reflection.Missing.Value;
            object DocType = false;
            object visible = true;

            // Ubicación de la plantilla en el disco duro
            oDoc = oWord.Documents.Add(ref rutaPlantilla, ref newTmp, ref DocType, ref visible);

            // Verifico que la consulta tenga datos
            if (myPlantillaActual.ENCABEZADO != null)
            {
                object objTmp;
                objTmp = "ENCABEZADO";
                myPlantillaActual.ENCABEZADO = myPlantillaActual.ENCABEZADO.Replace("<t>", "");
                oDoc.Bookmarks.get_Item(ref objTmp).Range.Text = myPlantillaActual.ENCABEZADO.Replace("<->", "");
            }
            if (myPlantillaActual.CONTENIDO != null)
            {
                object objTmp;
                objTmp = "CONTENIDO";
                myPlantillaActual.CONTENIDO = myPlantillaActual.CONTENIDO.Replace("<t>", "");

                if (myPlantillaActual.CONTENIDO.Contains("*MOTIVO*"))
                {
                    myPlantillaActual.CONTENIDO = myPlantillaActual.CONTENIDO.Replace("*MOTIVO*", "");
                    myPlantillaActual.CONTENIDO = myPlantillaActual.CONTENIDO.Replace("MOTIVO", "");
                }

                if (myPlantillaActual.NOMBRE.Equals("REVOCATORIA DIRECTA"))
                {
                    if (myPlantillaActual.CONTENIDO.Contains("*HECHOS*"))
                    {
                        myPlantillaActual.CONTENIDO = myPlantillaActual.CONTENIDO.Replace("*HECHOS*", "");
                        myPlantillaActual.CONTENIDO = myPlantillaActual.CONTENIDO.Replace("HECHOS", "");
                    }
                    if (myPlantillaActual.CONTENIDO.Contains("*SOLICITUD*"))
                    {
                        myPlantillaActual.CONTENIDO = myPlantillaActual.CONTENIDO.Replace("DE LA SOLICITUD", "");
                        myPlantillaActual.CONTENIDO = myPlantillaActual.CONTENIDO.Replace("*SOLICITUD*", "");
                    }
                    if (myPlantillaActual.CONTENIDO.Contains("*MOTIVORESOLUCION*"))
                    {
                        myPlantillaActual.CONTENIDO = myPlantillaActual.CONTENIDO.Replace("por *MOTIVORESOLUCION*", "");
                    }
                }

                oDoc.Bookmarks.get_Item(ref objTmp).Range.Text = myPlantillaActual.CONTENIDO.Replace("<->", "");
            }


            //SUBIR ARCHIVO AL SERVIDOR
            string directorioResoluciones = serviciosConfiguraciones.leerRegistroIni("RESOLUCIONES");
            string nombreDocumentoExtension = nombreDocumento + ".doc";
            object rutaResolucion = directorioResoluciones + "\\" + nombreDocumentoExtension;

            //Specifying the format in which you want the output file 
            object format = Word.WdSaveFormat.wdFormatDocument;

            // Use for the parameter whose type are not known or  
            // say Missing
            object Unknown = Type.Missing;

            //Changing the format of the document
            oWord.ActiveDocument.SaveAs(ref rutaResolucion, ref format,
                    ref Unknown, ref Unknown, ref Unknown,
                    ref Unknown, ref Unknown, ref Unknown,
                    ref Unknown, ref Unknown, ref Unknown,
                    ref Unknown, ref Unknown, ref Unknown,
                    ref Unknown, ref Unknown);

            //for closing the application
            oWord.Quit(ref Unknown, ref Unknown, ref Unknown);

            //Tiempo para que word cierre la app
            System.Threading.Thread.Sleep(1000);

            //Enviar archivo al servidor
            myTransferencia.archivoAlServer(rutaResolucion.ToString(), rutaResolucion.ToString());

            //Abrir archivo
            if (abrirDoc)
                System.Diagnostics.Process.Start(rutaResolucion.ToString());
        }
    }
}
