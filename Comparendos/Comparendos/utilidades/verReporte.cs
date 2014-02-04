using System; using TransitoPrincipal; using LibreriasSintrat.utilidades;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Comparendos.utilidades
{
    public partial class verReporte : Form
    {
        public verReporte(Object RP)
        {
            InitializeComponent();
            viewer.ReportSource = RP;
        }
    }
}
