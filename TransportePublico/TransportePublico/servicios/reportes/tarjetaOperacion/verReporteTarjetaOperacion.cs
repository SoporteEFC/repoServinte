using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TransportePublico.servicios.reportes.tarjetaOperacion;

namespace TransportePublico
{
    public partial class visor : Form
    {
        public visor(DataTable datosTarjetaOperacion)
        {
            InitializeComponent();
            ReporteTarjetaOperacion myReporteOpe = new ReporteTarjetaOperacion();
            myReporteOpe.SetDataSource(datosTarjetaOperacion);
            viewercrystalReportTarjetaO.ReportSource = myReporteOpe;
        }
    }
}
