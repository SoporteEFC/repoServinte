using System; using TransitoPrincipal; using LibreriasSintrat.utilidades;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using LibreriasSintrat.ServiciosDocumentos;
using System.Windows.Forms;
using LibreriasSintrat.utilidades;


namespace Comparendos.servicios.documentos
{
    class transferir
    {
        public Byte[] archivoToBytes(String ruta)
        { 
            return File.ReadAllBytes(ruta);
        }

        public bool byteToarchivo(Byte[] bytes, String ruta)
        {
            if (bytes != null)
            {
                File.WriteAllBytes(ruta, bytes);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void archivoAlServer(String rutaLocal,String rutaRemota)
        {
            ServiciosDocumentosService mySerDoc = WS.ServiciosDocumentosService();
            mySerDoc.subirArchivo(archivoToBytes(rutaLocal), rutaRemota);
        }

        public void archivoDelServer(String ruta)
        {
            string nombre = ruta.Substring(0, (ruta.Length -(ruta.Length - ruta.LastIndexOf('\\')))); 
            ServiciosDocumentosService mySerDoc = WS.ServiciosDocumentosService();
            if(!Directory.Exists(nombre))
                Directory.CreateDirectory(nombre);
            if (Directory.Exists(nombre))
            {
                bool descargo = byteToarchivo(mySerDoc.bajarArchivo(ruta), ruta);
                if (descargo)
                    System.Diagnostics.Process.Start(ruta);
                else
                    MessageBox.Show("No se encontro el archivo en el servidor");
            }
            else
            {
                MessageBox.Show("No se pudo crear el directorio para descargar el archivo.");
            }
        }

        public void archivoDelServerSinAbrir(String ruta)
        {
            string directorio = "";
            directorio = ruta.Substring(0, (ruta.Length - (ruta.Length - ruta.LastIndexOf('\\'))));
            
            ServiciosDocumentosService mySerDoc = WS.ServiciosDocumentosService();
            
            if (!Directory.Exists(directorio))
                Directory.CreateDirectory(directorio);
            if (Directory.Exists(directorio))
            {
                bool descargo = byteToarchivo(mySerDoc.bajarArchivo(ruta), ruta);
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
