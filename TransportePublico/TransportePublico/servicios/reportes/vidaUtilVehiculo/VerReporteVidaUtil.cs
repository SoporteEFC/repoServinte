using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TransportePublico.servicios.reportes.vidaUtilVehiculo
{
    public partial class VerReporteVidaUtil : Form
    {
        public VerReporteVidaUtil(DataGridView grilla)
        {
            InitializeComponent();
            reporteVidaUtil RP = new reporteVidaUtil();
            RP.SetDataSource(grilla.DataSource);
            this.viewerReporteVidaUtil.ReportSource = RP;
        }
    }
}
