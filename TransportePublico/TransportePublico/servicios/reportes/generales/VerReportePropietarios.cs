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
    public partial class VerReportePropietarios : Form
    {
        public VerReportePropietarios(DataGridView grilla)
        {
            InitializeComponent();
            ReportePropietarios RP = new ReportePropietarios();
            RP.SetDataSource(grilla.DataSource);
            this.viewerReportePropietarios.ReportSource = RP;
        }
    }
}
