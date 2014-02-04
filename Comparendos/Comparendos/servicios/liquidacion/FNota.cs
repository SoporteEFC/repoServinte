using System; using TransitoPrincipal; using LibreriasSintrat.utilidades;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Comparendos.servicios.liquidacion
{
    public partial class FNota : Form
    {
        public FNota()
        {
            InitializeComponent();
        }

        public String getNota()
        {
            return textBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
