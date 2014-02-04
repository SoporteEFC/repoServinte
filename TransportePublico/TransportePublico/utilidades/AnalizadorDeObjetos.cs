using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TransportePublico.utilidades
{
    public class AnalizadorDeObjetos
    {
        public static string analizarObjeto(Type tipoObjeto, object[] objetos)
        {
            object x = objetos[0];

            string lista = "";

            foreach (MemberInfo mi in tipoObjeto.GetMembers())
            {
                if (mi.MemberType == MemberTypes.Property)
                {
                    PropertyInfo pi = mi as PropertyInfo;
                    if (pi != null)
                    {
                        string valor1 = pi.Name;

                        string valor2 = "";
                        Type tipoDato;

                        try
                        {
                            tipoDato = tipoObjeto.GetProperty(pi.Name).GetValue(x, null).GetType();
                        }
                        catch (Exception exce)
                        {
                            tipoDato = typeof(string);
                        }

                        try
                        {
                            valor2 = tipoObjeto.GetProperty(pi.Name).GetValue(x, null).ToString();
                        }
                        catch (Exception exce)
                        {
                            valor2 = "";
                        }
                        if(!valor2.Equals("") && !valor1.Equals(""))
                        lista += valor1 + "=" + valor2+",";
                    }
                }
            }

            return lista.Substring(0, lista.Length - 2);
        }
    }
}