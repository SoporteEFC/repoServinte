using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class ClaveIni
{
    public ClaveIni()
    {

    }

    public ClaveIni(string campo)
    {
        this.campo = campo;
    }

    public ClaveIni(string campo, string valor)
    {
        this.campo = campo;
        this.valor = valor;
    }

    string campo;

    public string Campo
    {
        get { return campo; }
        set { campo = value; }
    }

    string valor;

    public string Valor
    {
        get { return valor; }
        set { valor = value; }
    }

    public string ToString()
    {
        return campo + " = " + valor;
    }
}
