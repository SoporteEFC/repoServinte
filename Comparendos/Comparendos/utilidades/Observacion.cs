using System; using TransitoPrincipal; using LibreriasSintrat.utilidades;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Comparendos
{
    public partial class Observacion : Form
    {
        public string texto;
        public string titulo;
        public Observacion(int maxChar)
        {
            InitializeComponent();
            txtTexto.MaxLength = maxChar;
        }

        private void Observacion_Load(object sender, EventArgs e)
        {
            lblTitulo.Text = titulo;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            texto = txtTexto.Text;
        }
    }
}
