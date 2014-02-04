using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using LibreriasSintrat.ServiciosDocumentos;
using System.Windows.Forms;
using LibreriasSintrat.utilidades;


namespace TransportePublico.servicios.documentos
{
    class transferir
    {
        public Byte[] archivoToBytes(String ruta)
        {
            return File.ReadAllBytes(ruta);
        }

        public bool byteToarchivo(Byte[] cont, String ruta)
        {
            if (cont != null)
            {
                try
                {
                    File.WriteAllBytes(ruta, cont);
                    return true;
                }
                catch (Exception exce) { MessageBox.Show("No se puede generar el documento, debe cerrar el archivo actual."); return false; }
            }
            else
            {
                return false;
            }
        }

        public void archivoAlServer(String ruta)
        {
            ServiciosDocumentosService mySerDoc = WS.ServiciosDocumentosService();
            mySerDoc.subirArchivo(archivoToBytes("E:\\" + ruta), ruta);
        }

        public void archivoDelServerSinAbrir(String ruta)
        {
            string nombre = ruta; //new
            //if (ruta.LastIndexOf('\\') > 0)
            nombre = ruta.Substring(0, (ruta.Length - (ruta.Length - ruta.LastIndexOf('\\'))));
            ServiciosDocumentosService mySerDoc = WS.ServiciosDocumentosService();
            if (!Directory.Exists(nombre))
                Directory.CreateDirectory(nombre);
            if (Directory.Exists(nombre))
            {
                bool descargo = byteToarchivo(mySerDoc.bajarArchivo(ruta), ruta);

                byteToarchivo(mySerDoc.bajarArchivo(ruta), ruta);

                if (!descargo)
                   MessageBox.Show("No se encontro el archivo en el servidor");
            }
            else
            {
                MessageBox.Show("No se pudo crear el directorio para descargar el archivo.");
            }
        }
    }
}
