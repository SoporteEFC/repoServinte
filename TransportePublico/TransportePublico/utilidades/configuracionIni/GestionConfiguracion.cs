using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
  using LibreriasSintrat.utilidades; 

class GestionConfiguracion
{
  
    public static string NombreArchivoIni()
    {
        string fileName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + 
            "\\SypSolutions\\Sintrat\\configure.ini";
        fileName = "configure.ini";
        return fileName;
    }

    public static ClaveIni ConsultarValor(string nombreArchivo, ClaveIni clave)
    {
        ClaveIni res = new ClaveIni();
        res.Campo = clave.Campo;
        using (TextReader reader = new StreamReader(nombreArchivo))
        {
            string line;
            string[] valores;
            while ((line = reader.ReadLine()) != null)
            {
                try
                {
                    line = line.Trim();
                    if (!line.StartsWith(";"))
                    {
                        valores = DividirValores(line);
                        if (valores[0] == clave.Campo)
                        {
                            res.Valor = valores[1];
                            return res;
                        }
                    }
                }
                catch { }
            }
        }
        return res;
    }

    public static void ActualizarValor(string nombreArchivo, ClaveIni clave)
    {
        ArrayList valores = GestionArchivo.Leer(nombreArchivo);
        string[] campos;
        for (int i = 0; i < valores.Count; i++)
        {
            campos = DividirValores("" + valores[i]);
            if (campos != null && campos[0] == clave.Campo)
            {
                valores[i] = clave.ToString();
            }
        }
        GestionArchivo.Escribir(nombreArchivo, valores, false);
    }

    public static void ActualizarValores(string nombreArchivo, List<ClaveIni> listaClave)
    {
        ArrayList valores = GestionArchivo.Leer(nombreArchivo);
        string[] campos;
        for (int i = 0; i < valores.Count; i++)
        {
            campos = DividirValores("" + valores[i]);
            ClaveIni clave;
            for (int j = 0; j < listaClave.Count; j++)
            {
                clave = listaClave[j];
                if (campos != null && campos[0] == clave.Campo)
                {
                    valores[i] = clave.ToString();
                }
            }
        }
        GestionArchivo.Escribir(nombreArchivo, valores, false);
    }

    private static string[] DividirValores(string line)
    {
        string[] res = null;
        if (line.Contains(" = "))
            res = line.Split(new string[] { " = " }, StringSplitOptions.RemoveEmptyEntries);
        else if (line.Contains("= "))
            res = line.Split(new string[] { "= " }, StringSplitOptions.RemoveEmptyEntries);
        else if (line.Contains(" ="))
            res = line.Split(new string[] { " =" }, StringSplitOptions.RemoveEmptyEntries);
        else if (line.Contains("="))
            res = line.Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
        return res;
    }
}
