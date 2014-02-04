using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TransportePublico.servicios.reportes.vehiculosActivosporEmpresa
{
    public partial class VerReporteActivos : Form
    {
        public VerReporteActivos(DataGridView grilla)
        {
            InitializeComponent();
            ReporteVehiculosActivos RP = new ReporteVehiculosActivos();
            RP.SetDataSource(grilla.DataSource);
            this.viewerActivosporEmpresa.ReportSource = RP;
        }
    }
}
