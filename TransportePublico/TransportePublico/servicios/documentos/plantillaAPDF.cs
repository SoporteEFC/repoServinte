using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Windows.Forms;
using LibreriasSintrat.ServiciosDocumentos;
using LibreriasSintrat.ServiciosConfiguraciones;
  using LibreriasSintrat.utilidades;
using System.IO; 

namespace TransportePublico.servicios.documentos
{
    class plantillaAPDF
    {
        private Document document;
        Log log = new Log();

        public plantillaAPDF()
        {
            log = new Log();
        }

        public void creaPdfPlantilla(plantilla myPlantilla,String nombre)
        {
            if (myPlantilla != null)
            {
                plantillaAPDF myDoc = new plantillaAPDF();
                myDoc.crear(myPlantilla, nombre);
            }
        }

        /*---De aki para abajo es el codigo mortal del procesamiento---*/
        
        public void crear(plantilla myPlantilla, String nombre)
        {
            ServiciosConfiguracionesService myConf = WS.ServiciosConfiguracionesService();
            string ruta = myConf.directorioResoluciones();
            document = new Document(iTextSharp.text.PageSize.LETTER);
            document.PageSize.Rotate();
            //...definimos el autor del documento.
            document.AddAuthor("S&P Solutions");
            //...el creador, que será el mismo eh!
            document.AddCreator("SINTRAT");
            //hacemos que se inserte la fecha de creación para el documento
            document.AddCreationDate();
            //...título
            document.AddTitle("Generación de un pdf con itextSharp");
            //... el asunto
            document.AddSubject("Este es un paso muy important");
            //... palabras claves
            document.AddKeywords("pdf, PdfWriter; Documento; iTextSharp");
            if (!Directory.Exists(ruta))
                Directory.CreateDirectory(ruta);
            //creamos un instancia del objeto escritor de documento
            PdfWriter writer = PdfWriter.GetInstance(document, new System.IO.FileStream
            //("D:\\"+nombre+".pdf", System.IO.FileMode.Create));
            (ruta + nombre + ".pdf", System.IO.FileMode.Create));
            //writer.SetEncryption(PdfWriter.STRENGTH40BITS,"key","owner", PdfWriter.CenterWindow);
            //definimos la manera de inicialización de abierto del documento.
            //esto, hará que veamos al inicio, todas la páginas del documento
            //en la parte izquierda
            writer.ViewerPreferences = PdfWriter.PageModeUseThumbs;
            //con esto conseguiremos que el documento sea presentada de dos en dos 
            writer.ViewerPreferences = PdfWriter.PageLayoutTwoColumnLeft;
            //con esto podemos oculta las barras de herramienta y de menú respectivamente.
            //(quite las dos barras de comentario de la siguiente línea para ver los efectos)
            //PdfWriter.HideToolbar | PdfWriter.HideMenubar
            iTextSharp.text.Font myfont = new iTextSharp.text.Font(
            FontFactory.GetFont(FontFactory.COURIER, 14, iTextSharp.text.Font.BOLD));
            //abrimos el documento para agregarle contenido
            document.Open();
            if (myPlantilla.ENCABEZADO != null)
            {
                if (myPlantilla.ENCABEZADO.Contains("http") && !myPlantilla.ENCABEZADO.Contains('"'))
                {
                    Image imagen = prepararImagen(myPlantilla.ENCABEZADO);
                    if (imagen != null)
                        document.Add(imagen);
                    else
                    {
                        MessageBox.Show("Puede haber problemas con la url: " + myPlantilla.ENCABEZADO + " \nSi la url hace parte del texto poner la misma entre comillas" + '(' + '"' + '"' + ')', "Verifique la url del encabezado");
                        encabezado(myPlantilla.ENCABEZADO);
                    }
                }
                else
                    encabezado(myPlantilla.ENCABEZADO);
            }
            procesarContenido(myPlantilla.CONTENIDO);
            //esto es importante, pues si no cerramos el document entonces no se creara el pdf.
            document.Close();
            //esto es para abrir el documento y verlo inmediatamente después de su creación
            //System.Diagnostics.Process.Start("D:\\"+nombre+".pdf");
            System.Diagnostics.Process.Start(ruta + nombre + ".pdf");
        }

        private Image prepararImagen(String url)
        {
            iTextSharp.text.Image jpg;
            try
            {
                jpg = iTextSharp.text.Image.GetInstance(@url);
                jpg.Alignment = iTextSharp.text.Image.MIDDLE_ALIGN;
            }
            catch(Exception e)
            {
                log.escribirError(e.ToString(), this.GetType());
                jpg=null;
            }
            return jpg;
        }
        
        private void procesarContenido(String texto)
        {
            String[] cadenas;
            cadenas = texto.Split('<');
            String tmp;
            Boolean procesado;
            for (int i = 0; i < cadenas.Length; i++)
            {
                procesado = false;
                tmp = cadenas[i];
                if (tmp.Length > 0)
                {
                    if (tmp.Contains("n>"))
                    {
                        tmp = cortarEtiqueta(tmp, 2);
                        textoNegrita(tmp);
                        procesado = true;
                    }
                    if (tmp.Contains("t>"))
                    {
                        tmp = cortarEtiqueta(tmp, 2);
                        titulo(tmp);
                        procesado = true;
                    }
                    if (tmp.Contains("img>"))
                    {
                        tmp = cortarEtiqueta(tmp, 4);
                        imagen(tmp);
                        procesado = true;
                    }
                    if (tmp.Contains("tabla>"))
                    {
                        i++;
                        tmp = cortarEtiqueta(tmp, 6);
                        ArrayList contenido = new ArrayList();
                        ArrayList fila;
                        while (!tmp.Contains("-tabla>"))
                        {
                            tmp = cadenas[i];
                            if (tmp.Contains("-td>")) //termina fila
                                tmp = "";
                            else if (tmp != null && tmp.Contains("td>"))
                            {
                                i++;
                                tmp = cadenas[i];
                                fila = new ArrayList();
                                while (!tmp.Contains("-td>"))
                                {
                                    if (tmp.Contains("-tr>"))
                                        tmp = "";
                                    else if (tmp.Contains("tr>"))
                                    {
                                        tmp = cortarEtiqueta(tmp, 3);
                                        fila.Add(tmp);
                                    }
                                    else if (tmp.Contains("img>"))
                                    {
                                        tmp = cortarEtiqueta(tmp, 4);
                                        fila.Add(imagenParaInsertar(tmp));
                                    }
                                    i++;
                                    tmp = cadenas[i];
                                }
                                contenido.Add(fila);
                            }
                            i++;
                        }
                        crearTabla(contenido);
                        procesado = true;
                        i--;
                    }
                    if(!procesado)
                    {
                        if (tmp.Contains("->"))
                        {
                            tmp = cortarEtiqueta(tmp, 2);
                        }
                        if (tmp.Length > 0)
                            textoNormal(tmp);
                    }
                }
            }
        }

        private String cortarEtiqueta(String texto, int numero)
        {
            String tmp;
            tmp = texto.Substring(numero);
            return tmp;
        }

        private void encabezado(String texto)
        {
            iTextSharp.text.Font myfont = new iTextSharp.text.Font(
            FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, iTextSharp.text.Font.BOLD));
            Paragraph myParagraph = new Paragraph(texto+"\n", myfont);
            document.Add(myParagraph);
        }

        private void imagen(String url)
        {
            Image imagen = prepararImagen(url);
            if (imagen != null)
                document.Add(imagen);
        }

        private Image imagenParaInsertar(String url)
        {
            Image imagen = prepararImagen(url);
            return imagen;
        }

        private void titulo(String texto)
        {
            iTextSharp.text.Font myfont = new iTextSharp.text.Font(
            FontFactory.GetFont(FontFactory.TIMES_ROMAN,12, iTextSharp.text.Font.BOLD));
            Paragraph myParagraph = new Paragraph(texto, myfont);
            document.Add(myParagraph);
        }

        private void textoNormal(String texto)
        {
            iTextSharp.text.Font myfont = new iTextSharp.text.Font(
            FontFactory.GetFont(FontFactory.TIMES_ROMAN, 12, iTextSharp.text.Font.NORMAL));
            Paragraph myParagraph = new Paragraph(texto, myfont);
            document.Add(myParagraph);
        }

        private void textoNegrita(String texto)
        {
            iTextSharp.text.Font myfont = new iTextSharp.text.Font(
            FontFactory.GetFont(FontFactory.TIMES_ROMAN, 12, iTextSharp.text.Font.BOLD));
            Paragraph myParagraph = new Paragraph(texto, myfont);
            document.Add(myParagraph);
        }

        private void crearTabla(ArrayList valuesTable)
        {
            iTextSharp.text.Font myfont = new iTextSharp.text.Font(
            FontFactory.GetFont(FontFactory.TIMES_ROMAN, 12, iTextSharp.text.Font.BOLD));
            ArrayList filas;
            String tmp;
            int col;
            col = ((ArrayList)valuesTable[0]).Count;
            PdfPTable table = new PdfPTable(col);
            for (int i = 0; i < valuesTable.Count; i++)
            { 
                filas = (ArrayList)valuesTable[i];
                for (int j = 0; j < filas.Count; j++)
                {
                    if (filas[j].GetType().Name=="String")
                    {
                        tmp = (String)filas[j];
                        if (i == 0)
                        {
                            table.AddCell(new Paragraph(tmp, myfont));
                        }
                        else
                        {
                            myfont = new iTextSharp.text.Font(
                                FontFactory.GetFont(FontFactory.TIMES_ROMAN, 11, iTextSharp.text.Font.NORMAL));
                            table.AddCell(new Paragraph(tmp, myfont));
                        }
                    }
                    else
                    {
                            table.AddCell((Image)filas[j]);
                    }
                }
                table.CompleteRow();
            }
            document.Add(table);
        }
    }
}
