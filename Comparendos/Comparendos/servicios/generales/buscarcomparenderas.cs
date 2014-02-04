using System; using TransitoPrincipal; using LibreriasSintrat.utilidades;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibreriasSintrat.ServiciosUsuarios;
using LibreriasSintrat.ServiciosGeneralesComp;
using LibreriasSintrat.ServiciosComparendos;
using LibreriasSintrat.ServiciosGenerales;
using Comparendos.utilidades; using LibreriasSintrat.utilidades; using LibreriasSintrat;
using LibreriasSintrat.utilidades;
using TransitoPrincipal;

namespace Comparendos.servicios.generales
{
    public partial class buscarcomparenderas : Form
    {
        ServiciosGeneralesCompService clienteGeneralesComp;
        ServiciosComparendosService clienteComparendos;
        viewComparenderas comparenderaseleccionada = new viewComparenderas();
        agenteComp newagen;
        Funciones funciones;
        Object[] listaasignadas = null;
        Object[] listaimpuestos = null;
        Object[] listanoimpuestos = null;
        usuarios myusu = new usuarios();
        String elmensaje = "";
        double compImpuestos = 0;
        double compNoImpuestos = 0;
        double totalComparendosComparendera;
        double porcentajeUsoComparendera;
        Log log = new Log();

        public buscarcomparenderas(usuarios usuari)
        {
            InitializeComponent();
            myusu = usuari;
            log = new Log();
        }
        public void Limpiar() 
        {
            codigoagente.Clear();
            nombreagente.Clear();
            lblDetalleCOmparenderas.Text = "Detalle Comparenderas";
            grillacomparenderas.DataSource = null;
            btnAnular.Enabled = false;
            noregistrados.Clear();
            grillaasignadas.DataSource = null;
            lblResumen1.Text = " ";
        }

        private void buscarcomparenderas_Load(object sender, EventArgs e)
        {
            btnAnular.Enabled = false;
            btnSearchAgente.Focus();
        }

        private void btnSearchAgente_Click(object sender, EventArgs e)
        {
            buscarAgente();
        }

        public void buscarAgente()
        {
            clienteGeneralesComp = WS.ServiciosGeneralesCompService();
            agenteComp agen = new agenteComp();
            ArrayList Campos = new ArrayList();
            Campos.Add("PLACAAGENTE = CODIGO");
            Campos.Add("NOMBRES = NOMBRES");
            Campos.Add("APELL1 = PRIMER APELLIDO");
            Campos.Add("APELL2 = SEGUNDO APELLIDO");
            Object[] Agentes = (Object[])clienteGeneralesComp.getAgentes(agen);
            if (Agentes != null)
            {
                buscador buscador = new buscador(Agentes, Campos, null, null);
                funciones = new Funciones();

                if (buscador.ShowDialog() == DialogResult.OK)
                {
                    newagen = (agenteComp)funciones.listToAgente(buscador.Seleccion);
                    codigoagente.Text = newagen.PLACAAGENTE;
                    nombreagente.Text = newagen.NOMBRES + " " + newagen.APELL1 + " " + newagen.APELL2;
                    Limpiar();
                    buscarAsignadas();
                }
            }
        }

        private void buscarAsignadas()
        {
            clienteComparendos = WS.ServiciosComparendosService();
            if (newagen == null)
            {
                MessageBox.Show("Debe selecionar un agente");
                buscarAgente();
            }
            else
            {
               
                viewComparenderas vistaasig = new viewComparenderas();
                vistaasig.IDAGENTE = newagen.ID_AGENTE;
                listaasignadas = clienteComparendos.getSViewComparenderas(vistaasig);
                if (listaasignadas == null)
                {
                    funciones.mostrarMensaje("No se encontraron comparenderas para el agente: " + newagen.NOMBRES + " " + newagen.APELL1 + " " + newagen.APELL2,"I");
                }
                else
                {
                    if (listaasignadas != null && listaasignadas.Length >= 0)
                    {
                        mostrarAsignacion();
                        lblDetalleCOmparenderas.Text = "Número de comparenderas asignadas al agente encontradas:" + listaasignadas.Count().ToString();
                    }
                }
            } 
        }

        private void mostrarAsignacion()
        {
            Funciones funciones = new Funciones();
            DataTable dt = new DataTable();
            ArrayList Campos = new ArrayList();
            Campos.Add("ANOMBRES = AGENTE");
            Campos.Add("BAPELLIDO1 = PRIMER APELLIDO");
            Campos.Add("CAPELLIDO2 = SEGUNDO APELLIDO");
            Campos.Add("DESTADOCOMPARENDERA = ESTADO DE COMPARENDERA");
            Campos.Add("ERANGOINICIAL = RANGO INICIAL");
            Campos.Add("FRANGOFINAL = RANGO FINAL");
            try
            {
                dt = funciones.ToDataTable(funciones.ObjectToArrayList(listaasignadas));
            }
            catch (Exception e) {
                log.escribirError(e.ToString(), this.GetType());
            }
            grillacomparenderas.DataSource = dt;
            if (dt.Rows.Count > 0)
                funciones.configurarGrilla(grillacomparenderas, Campos);
            dt = null;
            Campos = null;

            grillacomparenderas.Select();
        }

        private void grillacomparenderas_SelectionChanged(object sender, EventArgs e)
        {
            if (grillacomparenderas.CurrentRow != null)
            {
                try
                {
                    comparenderaseleccionada = (viewComparenderas)listaasignadas[grillacomparenderas.CurrentRow.Index];
                    comparendosImpuestos();
                }
                catch (Exception exce){
                    log.escribirError(exce.ToString(), this.GetType());
                }
            }
        }

        private void comparendosImpuestos()
        {
            lblResumen1.Text = "Comparendos Impuesto: -";
            lblResumen2.Text = "Comparendos No Impuestos: -";
            lblResumen3.Text = "Porcentaje de uso comparendera: -";

            noregistrados.Text = "";
            clienteComparendos = WS.ServiciosComparendosService();
            viewComparendosInfractor compainfrac = new viewComparendosInfractor();
            viewComparendosInfractor compainfrac2 = new viewComparendosInfractor();
            compainfrac2.IDAGENTE = newagen.ID_AGENTE;
            compainfrac2.IDCOMPARENDERA = comparenderaseleccionada.IDCOMPARENDERA;
            listaimpuestos = clienteComparendos.getSViewComparendosInfractor(compainfrac2);
            if (listaimpuestos != null && listaimpuestos.Length >= 0)
            {
                mostrarImpuestos();
                compImpuestos = listaimpuestos.Count();
            }
            else
            {
                grillaasignadas.DataSource = null;
            }

            detalleComparendera comparend = new detalleComparendera();
            comparend.ID_COMPARENDERA = comparenderaseleccionada.IDCOMPARENDERA;
            comparend.ESTADOCOMP = "F";
            listanoimpuestos = clienteComparendos.getSDetalleComparendera(comparend);
            if (listanoimpuestos != null && listanoimpuestos.Length >= 0)
            {
                compNoImpuestos = listanoimpuestos.Count();
            }
            else
            {
                compNoImpuestos = 0;
                noregistrados.Text = "";
                btnAnular.Enabled = false;
            }

                totalComparendosComparendera = compImpuestos + compNoImpuestos;
                porcentajeUsoComparendera = Math.Round((compImpuestos * 100) / totalComparendosComparendera,1);

                for (int r = 0; r < compNoImpuestos;r++ )
                {
                    detalleComparendera nuevodet = new detalleComparendera();
                    nuevodet = (detalleComparendera)listanoimpuestos[r];
                    if (noregistrados.Text == "")
                    {
                        noregistrados.Text = nuevodet.NROCOMPARENDO.ToString();
                    }
                    else
                    {
                        noregistrados.Text = noregistrados.Text + " ," + nuevodet.NROCOMPARENDO.ToString();
                    }
                }
                btnAnular.Enabled = true;
            
            lblResumen1.Text = "Comparendos Impuesto: " + compImpuestos.ToString(); 
            lblResumen2.Text = "Comparendos No Impuestos: " + compNoImpuestos.ToString();
            lblResumen3.Text = "Porcentaje de uso comparendera: " + porcentajeUsoComparendera.ToString()+" %";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mostrarImpuestos()
        {
            Funciones funciones = new Funciones();
            DataTable dt = new DataTable();
            ArrayList Campos = new ArrayList();
            Campos.Add("ANUMEROCOMPARENDO = NRO. COMPARENDO");
            Campos.Add("BFECHACOMPARENDO = FECHA");
            Campos.Add("CIDENTIFICACION = IDENTIFICACIÓN");
            Campos.Add("DNOMBRESINFRACTOR = NOMBRES");
            Campos.Add("EAPELLIDINFRACTOR = APELLIDOS");
            try
            {
                dt = funciones.ToDataTable(funciones.ObjectToArrayList(listaimpuestos));
            }
            catch (Exception e) {
                log.escribirError(e.ToString(), this.GetType());
            }
            grillaasignadas.DataSource = dt;
            if (dt.Rows.Count > 0)
                funciones.configurarGrilla(grillaasignadas, Campos);
            dt = null;
            Campos = null;

            grillaasignadas.Select();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            anularComparendos();
        }

        private void anularComparendos()
        {
            elmensaje = comparenderaseleccionada.ERANGOINICIAL + " y " + comparenderaseleccionada.FRANGOFINAL;
            //anularcomparendo anula = new anularcomparendo(myusu,cl);
            //anula.llenarViewComparendera(comparenderaseleccionada);
            //anula.llenarMensaje(elmensaje);
            //anula.ShowDialog();
        }
    }
}
