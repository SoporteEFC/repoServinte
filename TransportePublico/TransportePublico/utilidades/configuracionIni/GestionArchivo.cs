using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibreriasSintrat.utilidades; 

class GestionArchivo
{
    
    public static System.Collections.ArrayList Leer(string nombreArchivo)
    {
        System.Collections.ArrayList res = new System.Collections.ArrayList();
        try
        {
            using (System.IO.TextReader reader = new System.IO.StreamReader(nombreArchivo))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    res.Add(line);
                }
            }
        }
        catch (Exception)
        {
            throw new Exception("Archivo no disponible, " + nombreArchivo);
        }
        return res;
    }

    public static void Escribir(string nombreArchivo, System.Collections.ArrayList valores, bool adding)
    {
        try
        {
            using (System.IO.TextWriter writer = new System.IO.StreamWriter(nombreArchivo, adding))
            {
                for (int i = 0; i < valores.Count; i++)
                {
                    writer.WriteLine(valores[i]);
                }
            }
        }
        catch (Exception) { }
    }
}
