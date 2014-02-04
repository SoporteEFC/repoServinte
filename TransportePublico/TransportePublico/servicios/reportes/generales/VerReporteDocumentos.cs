using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TransportePublico.servicios.reportes.generales
{
    public partial class VerReporteDocumentos : Form
    {
        public VerReporteDocumentos(DataGridView grilla)
        {
            InitializeComponent();
            ReporteDocumentos RP = new ReporteDocumentos();
            RP.SetDataSource(grilla.DataSource);
            this.viewerDocumentos.ReportSource = RP;
        }
    }
}
