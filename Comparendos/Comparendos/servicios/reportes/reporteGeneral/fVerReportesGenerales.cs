using System; using TransitoPrincipal; using LibreriasSintrat.utilidades;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Comparendos.servicios.reportes.reporteGeneral
{
    public partial class fVerReportesGenerales : Form
    {
        public fVerReportesGenerales(datosRepGenerales dt)
        {
            InitializeComponent();
            repGenerales myRep = new repGenerales();
            myRep.SetDataSource(dt);
            crystalReportViewer1.ReportSource = myRep;
        }
    }
}
