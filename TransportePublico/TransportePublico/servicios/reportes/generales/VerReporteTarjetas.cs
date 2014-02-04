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
    public partial class VerReporteTarjetas : Form
    {
        public VerReporteTarjetas(DataGridView grilla)
        {
            InitializeComponent();
            ReporteTarjetas RP = new ReporteTarjetas();
            RP.SetDataSource(grilla.DataSource);
            this.viewerTarjetas.ReportSource = RP;
        }
    }
}
