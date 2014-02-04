using System; using TransitoPrincipal; using LibreriasSintrat.utilidades;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibreriasSintrat.ServiciosAccesoriasComp;
using Comparendos.utilidades; using LibreriasSintrat.utilidades; using LibreriasSintrat;
using System.IO;
using LibreriasSintrat.ServiciosRangosDeComparendos;
using LibreriasSintrat.ServiciosViewComparendosFechas;
using LibreriasSintrat.ServiciosViewVehiculoComparendo;
using LibreriasSintrat.ServiciosGeneralesComp;
using LibreriasSintrat.ServiciosViewPropVehiculoComparendo;
using LibreriasSintrat.ServiciosPlanosSimit;
using LibreriasSintrat.ServiciosGenerales;
using LibreriasSintrat.ServiciosViewInfractorComparendo;
using LibreriasSintrat.ServiciosViewResoluciones;
using LibreriasSintrat.ServiciosViewPagosSimit;
using LibreriasSintrat.ServiciosPlanoComparendo;
using LibreriasSintrat.ServiciosPlanoRecaudos;
using LibreriasSintrat.ServiciosPlanoResoluciones;
using LibreriasSintrat.ServiciosViewResolucionesAlcoholemia;
using LibreriasSintrat.ServiciosViewResSinAlcoholemia;
using LibreriasSintrat.ServiciosComparendosCargaSimit;
using LibreriasSintrat.ServiciosViewCompFaltantesCarga;
using LibreriasSintrat.ServiciosViewResFaltantesCarga;
using LibreriasSintrat.ServiciosViewPagosFaltantesCarga;
using LibreriasSintrat.ServiciosComparendos;
using LibreriasSintrat.ServiciosCuposTrans;

namespace Comparendos.servicios.generales
{
    public partial class 
        fArchivosPlanos : Form
    {

        ServiciosAccesoriasCompService serviciosAccesoriasComp;
        ServiciosRangosDeComparendosService serviciosRangosDeComparendos;
        ServiciosCuposTransService serviciosCuposTrans;
        Funciones funciones;
        String ubicacion;
        String fileComparendos = "SIMITCOMP.DAT";
        String fileResoluciones = "SIMITRESOL.DAT";
        String fileRecaudos = "SIMITREC.DAT";
        string rangoInicial;
        string rangoFinal;
        bool busquedaPorNroComparendo;
        bool cargaDeArchivosNroComp;
        ArrayList listaNrosComparendos = new ArrayList();

        public fArchivosPlanos()
        {
            InitializeComponent();
            serviciosAccesoriasComp = WS.ServiciosAccesoriasCompService();
            serviciosCuposTrans = WS.ServiciosCuposTransService();
            funciones = new Funciones();
            serviciosRangosDeComparendos = WS.ServiciosRangosDeComparendosService();
            funciones.llenarCombo(comTipoIdentificacion, serviciosAccesoriasComp.obtenerTiposDocumento());
            funciones.llenarCombo(comTipoDocumento2, serviciosAccesoriasComp.obtenerTiposDocumento());
            obtenerRangosDeComparendos();
            obtenerPlanosSimit();
            busquedaPorNroComparendo = false;
            cargaDeArchivosNroComp = false;
            groupBox7.Enabled = false;
            llenarlblCargadosEnvidosSimit();
        }

        private void llenarlblCargadosEnvidosSimit()
        {
            int enviadossimit = 0;
            int cargadossimit = 0;
            float porcentaje = 0;
            bool tmp;
            comparendosCargaAlSimit compCarga = new comparendosCargaAlSimit();
            ServiciosComparendosCargaSimitService mySerComCarga = WS.ServiciosComparendosCargaSimitService();
            mySerComCarga.getCantidadCompEnviadosPorCarga(compCarga, out cargadossimit, out tmp);
            mySerComCarga.getCantidadArchivosAprobadosPorCarga(compCarga, out enviadossimit, out tmp);
            labCargados.Text = cargadossimit.ToString();
            labEnviados.Text = enviadossimit.ToString();
            if (cargadossimit > 0)
            {
                porcentaje = (enviadossimit * 100) / cargadossimit;
            }
            labPorcentaje2.Text = porcentaje.ToString() + "%";
        }

        private void obtenerPlanosSimit()
        {
            ServiciosPlanosSimitService mySerPlanos = WS.ServiciosPlanosSimitService();
            object[] listaplanossimit;
            listaplanossimit = mySerPlanos.getPlanosSimit();
            if (listaplanossimit != null)
            {
                Funciones fun = new Funciones();
                ArrayList tmpArray = fun.ObjectToArrayList(listaplanossimit);
                ArrayList campos = new ArrayList();
                DataTable dt = fun.ToDataTable(tmpArray);
                campos.Add("NOMBRECARGA = NOMBRE CARGA");
                campos.Add("FECHAINIPLANOS = FECHA INICIAL PLANOS");
                campos.Add("FECHAFINPLANOS = FECHA FINAL PLANOS");
                campos.Add("OFICIO = NUMERO DE OFICIO");
                datCargasEnviadas.DataSource = dt;
                fun.configurarGrilla(datCargasEnviadas, campos);
            }
        }

        public void obtenerRangosDeComparendos()
        {
            Object[] lista = null;
            DataTable tb = new DataTable();
            ArrayList campos = new ArrayList();

            lista = serviciosRangosDeComparendos.getRangosDeComparendos();
            if (lista != null)
            {
                tb = funciones.ToDataTable(funciones.ObjectToArrayList(lista));
                campos.Add("RANGOINICIAL = RANGO INICIAL");
                campos.Add("RANGOFINAL = RANGO FINAL");
                campos.Add("FECHAASIGNACIONRANGOS = FECHA ASIGNACION");
                campos.Add("NRORESOLASIGNACION = NRO RESOLUCION");
                campos.Add("CANTIDADRANGOS = CANTIDAD RANGOS");
                datRangos.DataSource = tb;
                funciones.configurarGrilla(datRangos, campos);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void butSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void butCargarBoletin_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)datCargasEnviadas.DataSource;
            try
            {
                int indice = datCargasEnviadas.SelectedRows[0].Index;
                int idplanossimit = int.Parse(dt.Rows[indice]["ID"].ToString());

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    StreamReader archivocomp = new StreamReader(openFileDialog1.FileName, Encoding.ASCII);
                    comparendosCargaAlSimit myComparendoSimit = new comparendosCargaAlSimit();
                    myComparendoSimit.ID_PLANOSSIMIT = idplanossimit;
                    ServiciosComparendosCargaSimitService mySerCompSimit = WS.ServiciosComparendosCargaSimitService();
                    mySerCompSimit.clarearComparendosCargados(myComparendoSimit, WS.MyUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName());
                    string linea = "";
                    string nrocomparendo = "";
                    string[] datos;
                    char[] delimiterChars = { ',' };
                    while (archivocomp.Peek() >= 0)
                    {
                        linea = archivocomp.ReadLine();
                        datos = linea.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
                        if (datos != null)
                        {
                            nrocomparendo = datos[1];
                            myComparendoSimit.NROCOMPARENDO = nrocomparendo;
                            mySerCompSimit.marcarComprandosQueNoSubieron(myComparendoSimit);
                        }
                        else
                        {
                            MessageBox.Show("No se leer el archivo.", "Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    if (MessageBox.Show("Estas seguro de actualizar el estado del comparendo!", "Pregunta?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        comparendosCargaAlSimit comprueba = new comparendosCargaAlSimit();
                        comprueba.ID_PLANOSSIMIT = idplanossimit;
                        mySerCompSimit.marcarComprandosQueSubieron(comprueba);
                    }
                    obtenerPlanosSimit();
                    llenarlblCargadosEnvidosSimit();
                    MessageBox.Show("Proceso terminado!", "Carga simit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una archivo para realizar la carga!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception exp)
            {

            }
        }

        private void butGenerarArchivosPlanos_Click(object sender, EventArgs e)
        {
            try
            {
                if (cheComparendos.Checked || cheRecaudos.Checked || cheResolucionesAlcoholemia.Checked || cheResolucionesSinAlcoholemia.Checked || cheTodasResoluciones.Checked)
                {
                    this.Cursor = Cursors.WaitCursor;
                    if (chePorNumeroComparendo.Checked)
                    {
                        calFechaFin.Enabled = false;
                        calFechaIni.Enabled = false;
                        busquedaPorNroComparendo = true;
                        if (texNumeroOficio.Text.Equals(""))
                        {
                            MessageBox.Show("Falta llenar el número de oficio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                        else
                        {
                            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                            {
                                ubicacion = folderBrowserDialog1.SelectedPath;
                                if (cargaDeArchivosNroComp)
                                {
                                    if (listaNrosComparendos.Count <= 0)
                                    {
                                        MessageBox.Show("No se encontraron números de comparendos en el archivo cargado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                    else
                                    {
                                        for (int i = 0; i < listaNrosComparendos.Count; i++)
                                        {
                                            texNumeroComparendo.Text = listaNrosComparendos[i].ToString();
                                            if (!ubicacion.Equals(""))
                                            {
                                                setPlanos(1);
                                            }
                                            else
                                            {
                                                MessageBox.Show("No existe una ubicacion para la generacion de los archivos planos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (texNumeroComparendo.Text.Equals(""))
                                    {
                                        MessageBox.Show("Falta llenar el número de comparendo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    }
                                    else
                                    {
                                        if (!ubicacion.Equals(""))
                                        {
                                            setPlanos(1);
                                        }
                                        else
                                        {
                                            MessageBox.Show("No existe una ubicacion para la generacion de los archivos planos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("No se generaron archivos planos. Debe eligir una ubicacion para los archivos planos que se van a generar", "No se selecciono ninguna ubicacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                ubicacion = "";
                            }
                        }
                        this.Cursor = Cursors.Arrow;
                    }
                    if (cheInfractor.Checked)
                    {
                        if (texIdentificacion.Text.Equals(""))
                        {
                            MessageBox.Show("Falta llenar el número de identificación", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                        else
                        {
                            calFechaFin.Enabled = true;
                            calFechaIni.Enabled = true;
                            if (calFechaIni.SelectionRange.Start > calFechaFin.SelectionRange.Start)
                                MessageBox.Show("La fecha inicial debe ser menor o igual a la fecha final", "Fechas incorrectas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else
                            {
                                if (texNumeroOficio.Text.Equals(""))
                                {
                                    MessageBox.Show("Falta llenar el número de oficio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                }
                                else
                                {
                                    if (Convert.ToInt64(texNumeroOficio.Text) > 2147483646)
                                    {
                                        MessageBox.Show("El número de oficio no puede ser mayor a \"2147483646\"", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    }
                                    else
                                    {
                                        if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                                        {
                                            ubicacion = folderBrowserDialog1.SelectedPath;
                                            setPlanos(1);
                                        }
                                        else
                                        {
                                            MessageBox.Show("No se generaron archivos planos. Debe eligir una ubicacion para los archivos planos que se van a generar", "No se selecciono ninguna ubicacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            ubicacion = "";
                                        }
                                    }
                                }
                            }
                        }
                        this.Cursor = Cursors.Arrow;
                    }
                    if (!cheInfractor.Checked && !chePorNumeroComparendo.Checked)
                    {
                        calFechaFin.Enabled = true;
                        calFechaIni.Enabled = true;
                        if (calFechaIni.SelectionRange.Start > calFechaFin.SelectionRange.Start)
                            MessageBox.Show("La fecha inicial debe ser menor o igual a la fecha final", "Fechas incorrectas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                        {
                            if (texNumeroOficio.Text.Equals(""))
                            {
                                MessageBox.Show("Falta llenar el numero de oficio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }
                            else
                            {
                                if (Convert.ToInt64(texNumeroOficio.Text) > 2147483646)
                                {
                                    MessageBox.Show("El número de oficio no puede ser mayor a \"2147483646\"", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                }
                                else
                                {
                                    if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                                    {
                                        ubicacion = folderBrowserDialog1.SelectedPath;
                                        setPlanos(1);
                                    }
                                    else
                                    {
                                        MessageBox.Show("No se generaron archivos planos. Debe eligir una ubicacion para los archivos planos que se van a generar", "No se selecciono ninguna ubicacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        ubicacion = "";
                                    }
                                }
                            }
                        }
                        this.Cursor = Cursors.Arrow;
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una de las opciones para generar los planos?", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
                //Console.WriteLine(exp.Message);
                //Console.WriteLine(exp.StackTrace);
            }
        }

        private void setPlanos(int opc) //opc 1. por fechas 4.Planos faltantes de carga
        {
            bool resultado = false;
            floading frmcarga = new floading();
            if (opc == 4)
            {
                frmcarga.Show();
                if (setPlanoComparendosFaltantes())
                {
                    frmcarga.Close();
                    MessageBox.Show("Proceso terminado", "Generar archivos planos faltantes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    frmcarga.Close();
                    MessageBox.Show("Proceso terminado sin generaciones", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                frmcarga.Show();
                if (setPlanoComparendos())
                {
                    frmcarga.Close();
                    MessageBox.Show("Proceso terminado", "Generar archivos planos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    frmcarga.Close();
                    MessageBox.Show("El Proceso no pudo ser terminado terminado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool setPlanoComparendos()
        {
            String fec1, fec2, Nit;
            String nombresApellidos;
            int numRegistros = 0;
            double sumRegistros = 0;
            StreamWriter infoTramites;
            Object[] lista;
            bool resultado = false;
            ServiciosViewComparendosFechasService serviciosViewComparendosFechas;
            viewComparendosFechas viewCompPorFechas;
            transitoComp transito = new transitoComp();
            ServiciosGeneralesCompService serviciosGeneralesComp = WS.ServiciosGeneralesCompService();
            transito.NIT = serviciosGeneralesComp.getNitTransitoComp();
            transito.ID_CIUDAD = serviciosGeneralesComp.getCiudadTransitoComp();
            String linea;
            planosSimit planos_Simit;
            ServiciosGeneralesService serviciosGenerales;
            ArrayList listadatos = new ArrayList();
            int codchequeo = 0;

            fileComparendos = transito.NIT + "comp.txt";
            try
            {
                if (cheComparendos.Checked)
                {
                    if (cheComparendos.Checked)
                    {

                        serviciosViewComparendosFechas = WS.ServiciosViewComparendosFechasService();
                        viewCompPorFechas = new viewComparendosFechas();
                        fec1 = funciones.formatFecha(calFechaIni.SelectionRange.Start.ToString().Remove(10, calFechaIni.SelectionRange.Start.ToString().Length - 10));
                        fec2 = funciones.formatFecha(calFechaFin.SelectionRange.Start.ToString().Remove(10, calFechaFin.SelectionRange.Start.ToString().Length - 10));
                        if (busquedaPorNroComparendo)
                        {
                            viewCompPorFechas.NUMEROCOMPARENDO = texNumeroComparendo.Text;
                            lista = serviciosViewComparendosFechas.getViewComparendosFechas(viewCompPorFechas);
                        }
                        else
                        {
                            if (cheComparendosPagados.Checked)
                            {
                                if (cheInfractor.Checked)
                                {
                                    infractorComp infractor = buscaInfractor(int.Parse(comTipoIdentificacion.SelectedValue.ToString()), texIdentificacion.Text);
                                    if (infractor != null)
                                    {
                                        viewCompPorFechas.ID_INFRACTOR = infractor.ID_INFRACTOR;
                                        lista = (Object[])serviciosViewComparendosFechas.getComparendoPorRangoFechas(viewCompPorFechas, fec1, fec2);
                                    }
                                    else
                                    {
                                        lista = null;
                                    }
                                }
                                else
                                {
                                    lista = (Object[])serviciosViewComparendosFechas.getComparendoPorRangoFechas(viewCompPorFechas, fec1, fec2);
                                }
                            }
                            else
                            {
                                if (cheInfractor.Checked)
                                {
                                    infractorComp infractor = buscaInfractor(int.Parse(comTipoIdentificacion.SelectedValue.ToString()), texIdentificacion.Text);
                                    if (infractor != null)
                                    {
                                        viewCompPorFechas.ID_INFRACTOR = infractor.ID_INFRACTOR;
                                        lista = (Object[])serviciosViewComparendosFechas.getComparendoNoPagosPorRangoFechas(viewCompPorFechas, fec1, fec2);
                                    }
                                    else
                                    {
                                        lista = null;
                                    }
                                }
                                else
                                {
                                    lista = (Object[])serviciosViewComparendosFechas.getComparendoNoPagosPorRangoFechas(viewCompPorFechas, fec1, fec2);
                                }
                            }
                        }

                        if (lista != null)
                        {
                            resultado = true;
                            planos_Simit = new planosSimit();
                            planos_Simit.FECHAINIPLANOS = funciones.formatFecha(calFechaIni.SelectionRange.Start.ToString().Remove(10, calFechaIni.SelectionRange.Start.ToString().Length - 10));
                            planos_Simit.FECHAFINPLANOS = funciones.formatFecha(calFechaFin.SelectionRange.Start.ToString().Remove(10, calFechaFin.SelectionRange.Start.ToString().Length - 10));
                            serviciosGenerales = WS.ServiciosGeneralesService();
                            planos_Simit.FECHAREGISTRO = funciones.formatFecha(serviciosGenerales.getFechaServidor());

                            if (datRangos.CurrentRow != null)
                                planos_Simit.ID_RANGOCOMPARENDOS = Convert.ToInt32(datRangos.CurrentRow.Cells["ID_RANGOCOMPARENDO"].Value.ToString());

                            planos_Simit.NOMBRECARGA = "Planos de Oficio Numero " + texNumeroOficio.Text + " y Fecha " + planos_Simit.FECHAREGISTRO.ToString();
                            planos_Simit.OFICIO = Convert.ToInt32(texNumeroOficio.Text);
                            planos_Simit.RUTA = folderBrowserDialog1.SelectedPath;
                            createPlanosSimit(planos_Simit);
                            obtenerPlanosSimit();

                            foreach (viewComparendosFechas viewCompPorFechasTmp in lista)
                            {
                                try
                                {
                                    infoTramites = new StreamWriter(ubicacion + "/" + fileComparendos, true);
                                    numRegistros++;

                                    //1. Consecutivo longitud 5 numerico
                                    if (numRegistros > 19999)
                                        numRegistros = 1;
                                    linea = numRegistros.ToString() + ",";

                                    //2. Numero de Comparendo longitud 20 alfanumerico
                                    if (viewCompPorFechasTmp.NUMEROCOMPARENDO == null)
                                        linea = linea + ",";
                                    else
                                    {
                                        string tmp = limpiarString(viewCompPorFechasTmp.NUMEROCOMPARENDO.Trim());
                                        tmp = completarLongitudCadenas(tmp, 20, " ");
                                        linea = linea + tmp + ",";
                                    }

                                    //3. Fecha del comparendo longitud 10 alfanumerico
                                    if (viewCompPorFechasTmp.FECHACOMPARENDO == null)
                                        linea = linea + ",";
                                    else
                                    {
                                        //viewCompPorFechasTmp.FECHACOMPARENDO = viewCompPorFechasTmp.FECHACOMPARENDO.Replace("-", "/");
                                        DateTime fecha = DateTime.Parse(viewCompPorFechasTmp.FECHACOMPARENDO.Trim());
                                        string tmp = completarLongitudCadenas(fecha.ToString("dd/MM/yyyy"), 10, " ");
                                        linea = linea + tmp + ",";
                                    }

                                    //4. Hora del comparendo longitud 4  hhmm  militar numerico
                                    if (viewCompPorFechasTmp.HORACOMPARENDO == null)
                                        linea = linea + ",";
                                    else
                                    {
                                        if (viewCompPorFechasTmp.HORACOMPARENDO.Length <= 8)
                                            linea = linea + funciones.formatoHora(viewCompPorFechasTmp.HORACOMPARENDO).Trim() + ",";
                                        else
                                            linea = linea + funciones.formatoHora(viewCompPorFechasTmp.HORACOMPARENDO.Remove(5, viewCompPorFechasTmp.HORACOMPARENDO.Length - 5)).Trim() + ",";
                                    }

                                    //5. Direccion de la infraccion longitud 80 alfanumerico
                                    if (viewCompPorFechasTmp.DIRECCIONINFRACCION == null)
                                        linea = linea + ",";
                                    else
                                    {
                                        string tmp = limpiarString(viewCompPorFechasTmp.DIRECCIONINFRACCION);
                                        tmp = completarLongitudCadenas(tmp, 80, " ");
                                        linea = linea + tmp + ",";
                                    }

                                    //6. Divipo municipio longitud 8 alfanumerico
                                    if (viewCompPorFechasTmp.CODCIUDAD == null && viewCompPorFechasTmp.ID_DEPTO == null)
                                        linea = linea + ",";
                                    else
                                    {
                                        string divipo = getDivisionPolitica(viewCompPorFechasTmp.ID_DEPTO.Trim(), viewCompPorFechasTmp.CODCIUDAD.Trim());
                                        divipo = limpiarString(divipo);
                                        divipo = completarLongitudCadenas(divipo.Trim(), 8, " ");
                                        linea = linea + divipo + ",";
                                    }

                                    //7. Localidad o comuna longitud 30 alfanumerico
                                    if (viewCompPorFechasTmp.LOCALIDAD_COMUNADIRECCION == null)
                                        linea = linea + ",";
                                    else
                                    {
                                        string tmp = limpiarString(viewCompPorFechasTmp.LOCALIDAD_COMUNADIRECCION);
                                        tmp = completarLongitudCadenas(tmp, 30, " ");
                                        linea = linea + tmp + ",";
                                    }

                                    //8. Placa del vehiculo longitud 6 alfanumerico
                                    if (viewCompPorFechasTmp.PLACA == null)
                                        linea = linea + ",";
                                    else
                                    {
                                        string tmp = limpiarString(viewCompPorFechasTmp.PLACA.Trim());
                                        tmp = completarLongitudCadenas(tmp, 6, " ");
                                        linea = linea + tmp + ",";
                                    }
                                    almacenarComparendoCargadoSimit(viewCompPorFechasTmp, planos_Simit.ID);
                                    //-------------------------- VEHICULO COMPARENDO --------------------------------------------------------                            
                                    ServiciosViewVehiculoComparendoService serviciosViewVehiculoComparendo = WS.ServiciosViewVehiculoComparendoService();
                                    viewVehiculoComparendo vehiculoComparendo = new viewVehiculoComparendo();
                                    Object[] vehiculosComparendo;
                                    vehiculoComparendo.PLACA = viewCompPorFechasTmp.PLACA;
                                    vehiculosComparendo = (Object[])serviciosViewVehiculoComparendo.getViewVehiculoComparendo(vehiculoComparendo);

                                    if (vehiculosComparendo != null)
                                    {
                                        vehiculoComparendo = (viewVehiculoComparendo)vehiculosComparendo[0];
                                        //9. Municipio de la Placa longitud 8 alfanumerico
                                        if (vehiculoComparendo.NITMATRICULA == null)
                                            linea = linea + "00000000,";
                                        else
                                        {
                                            string tmp = limpiarString(vehiculoComparendo.NITMATRICULA.Trim());
                                            tmp = completarLongitudCadenas(tmp, 8, " ");
                                            linea = linea + tmp + ",";
                                        }

                                        //10. Clase de vehiculo longitud 2 numerico
                                        if (vehiculoComparendo.ID_CVEHICULO == 0)
                                            linea = linea + ",";
                                        else
                                        {
                                            string tmp = completarLongitudCadenas(vehiculoComparendo.ID_CVEHICULO.ToString().Trim(), 2, "0");
                                            linea = linea + tmp + ",";
                                        }

                                        //11. Tipo de Servicio longitud 1 numerico
                                        if (vehiculoComparendo.ID_SERVICIO <= 0)
                                            linea = linea + ",";
                                        else
                                        {
                                            string tmp = completarLongitudCadenas(vehiculoComparendo.ID_SERVICIO.ToString().Trim(), 1, "0");
                                            linea = linea + tmp + ",";
                                        }

                                        //12. Radio de accion longitud 1 numerico
                                        if (vehiculoComparendo.COD_RADIOACCION == null)
                                            linea = linea + ",";
                                        else
                                        {
                                            string tmp = limpiarString(vehiculoComparendo.COD_RADIOACCION.Trim());
                                            tmp = completarLongitudCadenas(tmp, 1, "0");
                                            linea = linea + tmp + ",";
                                        }

                                        //13. Modalidad de trasnporte longitud 1 numerico
                                        if (vehiculoComparendo.COD_MODTRANSPORTE == null)
                                            linea = linea + ",";
                                        else
                                        {
                                            string tmp = completarLongitudCadenas(vehiculoComparendo.COD_MODTRANSPORTE.Trim(), 1, "0");
                                            linea = linea + tmp + ",";
                                        }

                                        //14. Código transporte pasajeros longitud 1 numerico
                                        if (vehiculoComparendo.COD_TIPOTRANSPORTE == null)
                                            linea = linea + ",";
                                        else
                                        {
                                            string tmp = completarLongitudCadenas(vehiculoComparendo.COD_TIPOTRANSPORTE.Trim(), 1, "0");
                                            linea = linea + tmp + ",";
                                        }
                                    }
                                    else
                                        linea = linea + "," + "," + "," + "," + "," + ",";

                                    //-------------------------- INFRACTOR ------------------------------------------------------------------
                                    infractorComp infractor = new infractorComp();
                                    infractor.ID_INFRACTOR = viewCompPorFechasTmp.ID_INFRACTOR;
                                    infractor = serviciosGeneralesComp.buscarInfractor(infractor);
                                    viewInfractorComparendo infrac = new viewInfractorComparendo();
                                    infrac.ID_INFRACTOR = viewCompPorFechasTmp.ID_INFRACTOR.ToString();
                                    ServiciosViewInfractorComparendoService mySerViewCom = WS.ServiciosViewInfractorComparendoService();
                                    object [] infractorc = mySerViewCom.getViewInfractorComparendo(infrac);
                                    if (infractorc != null)
                                    {
                                        infrac = (viewInfractorComparendo)infractorc[0];

                                        //15. Identificacion del infractor longitud 15 numerico
                                        if (infractor.NROIDENTIFICACION == null)
                                            linea = linea + ",";
                                        else
                                        {
                                            string tmp = limpiarString(infractor.NROIDENTIFICACION.Trim());
                                            tmp = completarLongitudCadenas(tmp, 15, "0");
                                            linea = linea + tmp.Trim() + ",";
                                        }

                                        //16. Tipo documento infractor longitud 1 numerico
                                        if (viewCompPorFechasTmp.IDREPORTECOMPARENDO == 0)
                                            linea = linea + ",";
                                        else
                                        {
                                            string tmp = completarLongitudCadenas(viewCompPorFechasTmp.IDREPORTECOMPARENDO.ToString().Trim(), 1, "0");
                                            linea = linea + tmp + ",";
                                        }

                                        //17. Nombres infractor longitud 18 alfanumerico
                                        if (infractor.NOMBRES == null)
                                            linea = linea + ",";
                                        else
                                        {
                                            string tmp = limpiarString(infractor.NOMBRES);
                                            tmp = completarLongitudCadenas(tmp, 18, " ");
                                            linea = linea + tmp + ",";
                                        }

                                        //18. Apellidos infractor longitud 20 alfanumerico
                                        if (infractor.APELLIDOS == null)
                                            linea = linea + ",";
                                        else
                                        {
                                            string tmp = limpiarString(infractor.APELLIDOS);
                                            tmp = completarLongitudCadenas(tmp, 20, " ");
                                            linea = linea + tmp + ",";
                                        }

                                        //19. Edad infractor longitud 2 numerico
                                        if (infractor.EDAD == null)
                                            linea = linea + ",";
                                        else
                                        {
                                            string tmp = limpiarString(infractor.EDAD.Trim());
                                            tmp = completarLongitudCadenas(tmp, 2, "0");
                                            linea = linea + tmp + ",";
                                        }

                                        //20. Direccion infractor longitud 40 alfanumerico
                                        if (infractor.DIRECCION == null)
                                            linea = linea + ",";
                                        else
                                        {
                                            string tmp = limpiarString(infractor.DIRECCION);
                                            tmp = completarLongitudCadenas(tmp, 40, " ");
                                            linea = linea + tmp + ",";
                                        }

                                        //21. Correo electronico infractor longitud 20 alfanumerico
                                        if (infractor.EMAIL == null)
                                            linea = linea + ",";
                                        else
                                        {
                                            string tmp = limpiarString(infractor.EMAIL.Trim());
                                            tmp = completarLongitudCadenas(tmp, 40, " ");
                                            linea = linea + tmp + ",";
                                        }

                                        //22. Telefono infractor longitud 15 alfanumerico
                                        if (infractor.TELEFONO == null)
                                            linea = linea + ",";
                                        else
                                        {
                                            string tmp = limpiarString(infractor.TELEFONO.Trim());
                                            tmp = completarLongitudCadenas(tmp, 15, " ");
                                            linea = linea + tmp + ",";
                                        }

                                        //23. Ciudad residencia infractor longitud 8 numerico
                                        if (infractor.ID_CIUDAD <= 0)
                                            linea = linea + ",";
                                        else
                                        {
                                            Object[] ciudades;
                                            ciudadComp ciudad = new ciudadComp();
                                            ServiciosAccesoriasCompService serviciosAccesoriasComp = WS.ServiciosAccesoriasCompService();
                                            ciudad.ID_CIUDAD = infractor.ID_CIUDAD;
                                            ciudades = (Object[])serviciosAccesoriasComp.getCiudadComp(ciudad);
                                            if (ciudades == null)
                                                linea = linea + ",";
                                            else
                                            {
                                                ciudad = (ciudadComp)ciudades[0];
                                                if (ciudad.CODCIUDAD == null)
                                                    linea = linea + ",";
                                                else
                                                {
                                                    string tmp = getDivisionPolitica(ciudad.ID_DEPTO.ToString(), ciudad.CODCIUDAD.Trim());
                                                    tmp = completarLongitudCadenas(tmp, 8, "0");
                                                    linea = linea + tmp + ",";
                                                }
                                            }
                                        }

                                        //24. No. licencia de conduccion longitud 14 alfanumerico
                                        if (infractor.NROLICCONDUCCION == null)
                                            linea = linea + ",";
                                        else
                                        {
                                            string tmp = limpiarString(infractor.NROLICCONDUCCION.Trim());
                                            tmp = completarLongitudCadenas(tmp, 14, " ");
                                            linea = linea + tmp + ",";
                                        }

                                        //25. Categoria Licencia de conduccion longitud 2 alfanumerico
                                        if (infrac.NUEVA_CATEGORIA == null)
                                        {
                                            linea = linea + ",";
                                        }
                                        else
                                        {
                                            string tmp = limpiarString(infrac.NUEVA_CATEGORIA.Trim());
                                            tmp = completarLongitudCadenas(tmp, 2, " ");
                                            linea = linea + tmp + ",";
                                        }

                                        //26. Organismo Expide lic de conduccion longitud 8 alfanumerico
                                        if (infractor.ID_TRANSITO <= 0)
                                        {
                                            linea = linea + ",";
                                        }
                                        else // SE DEJA VACIO PORQUE EN LA BASE DE DATOS NO SE ALMACENA EL ORGANISMO QUE EXPIDE LA LICENCIA
                                        {
                                            //transito.ID_TRANSITO = infractor.ID_TRANSITO;
                                            //transito.ID_TRANSITO = -1;
                                            //ServiciosGeneralesCompService mySerGen = WS.ServiciosGeneralesCompService();
                                            //transito = mySerGen.getTransitoComp(transito);
                                            //if (transito.ID_CIUDAD <= 0)
                                            //{
                                            linea = linea + ",";
                                            //}
                                            //else
                                            //{
                                            //    ciudadComp ciudadtmp = new ciudadComp();
                                            //    ciudadtmp.ID_CIUDAD = transito.ID_CIUDAD;
                                            //    ciudadtmp = (ciudadComp)((object[])serviciosAccesoriasComp.getCiudadComp(ciudadtmp))[0];
                                            //    if (ciudadtmp.CODCIUDAD == null && ciudadtmp.ID_DEPTO <= 0)
                                            //    {
                                            //        linea = linea + ",";
                                            //    }
                                            //    else
                                            //    {
                                            //        string tmp = getDivisionPolitica(ciudadtmp.ID_DEPTO.ToString().Trim(), ciudadtmp.CODCIUDAD.Trim());
                                            //        tmp = completarLongitudCadenas(tmp, 8, " ");
                                            //        linea = linea + tmp + ",";
                                            //    }
                                            //}
                                        }

                                        //27. fecha vencimiento lic longitud 10 numerico
                                        if (infractor.FECHAVENCELICCONDUCCION == null)
                                            linea = linea + ",";
                                        else
                                        {
                                            if (infractor.FECHAVENCELICCONDUCCION.Length <= 10)
                                                linea = linea + funciones.formatFecha(infractor.FECHAVENCELICCONDUCCION).Trim() + ",";
                                            else
                                                linea = linea + funciones.formatFecha(infractor.FECHAVENCELICCONDUCCION.Remove(10, infractor.FECHAVENCELICCONDUCCION.Length - 10)).Trim() + ",";
                                        }


                                        //28. Tipo de infractor longitud 1 numerico
                                        if (viewCompPorFechasTmp.CODTIPOINFRACTOR == null)
                                            linea = linea + ",";
                                        else
                                        {
                                            string tmp = limpiarString(viewCompPorFechasTmp.CODTIPOINFRACTOR.Trim());
                                            tmp = completarLongitudCadenas(tmp, 1, "0");
                                            linea = linea + tmp + ",";
                                        }

                                        //29. No. Licencia de transito longitud 16 alfanumerico
                                        if (vehiculoComparendo.NROLICENCIA == null)
                                            linea = linea + ",";
                                        else
                                        {
                                            string tmp = limpiarString(vehiculoComparendo.NROLICENCIA.Trim());
                                            tmp = completarLongitudCadenas(tmp, 16, " ");
                                            linea = linea + tmp + ",";
                                        }

                                        //30. Divipo lic transito longitud 8 alfanumerico
                                        if (vehiculoComparendo.NITMATRICULA == null)
                                        {
                                            linea = linea + ",";
                                        }
                                        else
                                        {
                                            string tmp = limpiarString(vehiculoComparendo.NITMATRICULA.Trim());
                                            tmp = completarLongitudCadenas(tmp, 8, " ");
                                            linea = linea + tmp + ",";
                                        }
                                    }
                                    else
                                    {
                                        linea = linea + ",,,,,,,,,,,,,,,,,";
                                    }

                                    //-------------------------- IDENTIFICACION PROPIETARIO -------------------------------------------------
                                    ServiciosViewPropVehiculoComparendoService serviciosViewPropVehiculoComparendo = WS.ServiciosViewPropVehiculoComparendoService();
                                    viewPropVehiculoComparendo propietarioVehiculoComparendo = new viewPropVehiculoComparendo();
                                    Object[] propietarios;
                                    propietarioVehiculoComparendo.ID_COMPARENDO = viewCompPorFechasTmp.ID_COMPARENDO.ToString();
                                    propietarios = (Object[])serviciosViewPropVehiculoComparendo.getViewPropVehiculoComparendo(propietarioVehiculoComparendo);
                                    if (propietarios == null)
                                        linea = linea + "," + "," + "," + "," + "," + "," + "," + "," + "," + "," + "," + "," + "," + ",";
                                    else
                                    {
                                        propietarioVehiculoComparendo = (viewPropVehiculoComparendo)propietarios[0];

                                        //31. Identificacion propietario longitud 8 alfanumerico
                                        if (propietarioVehiculoComparendo.NROIDENTIFICACION == null)
                                            linea = linea + ",";
                                        else
                                        {
                                            string tmp = limpiarString(propietarioVehiculoComparendo.NROIDENTIFICACION.Trim());
                                            tmp = completarLongitudCadenas(tmp, 8, " ");
                                            linea = linea + tmp + ",";
                                        }

                                        //32. Tipo de documento propietario longitud 1 numerico
                                        if (propietarioVehiculoComparendo.IDREPORTECOMPARENDO == null)
                                            linea = linea + ",";
                                        else
                                        {
                                            string tmp = limpiarString(propietarioVehiculoComparendo.IDREPORTECOMPARENDO.Trim());
                                            tmp = completarLongitudCadenas(tmp, 1, "0");
                                            linea = linea + tmp + ",";
                                        }

                                        //33. Nombres y Apellidos propietario longitud 50 alfanumerico
                                        if ((propietarioVehiculoComparendo.NOMBRES == null) && (propietarioVehiculoComparendo.APELLIDOS == null))
                                            linea = linea + ",";
                                        else
                                        {
                                            string tmp1 = limpiarString(propietarioVehiculoComparendo.NOMBRES);
                                            string tmp2 = limpiarString(propietarioVehiculoComparendo.APELLIDOS);
                                            nombresApellidos = tmp1 + " " + tmp2;
                                            nombresApellidos = completarLongitudCadenas(nombresApellidos, 49, " ");
                                            linea = linea + nombresApellidos + ",";
                                        }
                                    }

                                    //-------------------------EMPRESA EN CASO DE VEHICULO DE SERVICIO PUBLICO------------------------------------------------------------------------------

                                    vehiculosComp myVehiculo = new vehiculosComp();
                                    myVehiculo.PLACA = vehiculoComparendo.PLACA;
                                    object[] vehiculos = serviciosGeneralesComp.getVehiculoComp(myVehiculo);
                                    if (vehiculos != null)
                                    {
                                        myVehiculo = (vehiculosComp)vehiculos[0];
                                        // Verifico si el vehiculo es publico
                                        if (myVehiculo.ID_EMPRESA != -1 && myVehiculo.ID_EMPRESA != 0)
                                        {
                                            empresasdeServicioTrans myEmpresa = new empresasdeServicioTrans();
                                            myEmpresa.ID_EMPSERVICIO = myVehiculo.ID_EMPRESA;
                                            object[] empresas = serviciosCuposTrans.getEmpresaServicio(myEmpresa);
                                            if (empresas != null)
                                            {
                                                //34. Empresa longitu 30 alfanumerico
                                                myEmpresa = (empresasdeServicioTrans)empresas[0];
                                                if (myEmpresa.NOMBRE == null)
                                                    linea = linea + ",";
                                                else
                                                {
                                                    string tmp = limpiarString(myEmpresa.NOMBRE);
                                                    tmp = completarLongitudCadenas(tmp, 30, " ");
                                                    linea = linea + tmp + ",";
                                                }

                                                //35. Nit Empresa longitud 15 alfanumerico
                                                if (myEmpresa.NIT == null)
                                                    linea = linea + ";";
                                                else
                                                {
                                                    string tmp = limpiarString(myEmpresa.NIT.Trim());
                                                    tmp = completarLongitudCadenas(tmp, 15, " ");
                                                    linea = linea + tmp + ",";

                                                }
                                            }
                                            else // Si no existe la empresa
                                            {
                                                linea = linea + ",";
                                                linea = linea + ",";
                                            }
                                        }
                                        else // Si el vehiculo no es publico
                                        {
                                            linea = linea + ",";
                                            linea = linea + ",";
                                        }
                                    }
                                    else // Si no encuentra el vehiculo
                                    {
                                        linea = linea + ",";
                                        linea = linea + ",";
                                    }

                                    //if (vehiculoComparendo.RAZONSOCIAL == null)
                                    //{
                                    //    linea = linea + ",";
                                    //}
                                    //else
                                    //{
                                    //    string tmp = limpiarString(vehiculoComparendo.RAZONSOCIAL);
                                    //    tmp = completarLongitudCadenas(tmp, 30, " ");
                                    //    linea = linea + tmp + ",";
                                    //}

                                    //35. Nit Empresa longitud 15 alfanumerico
                                    //if (vehiculoComparendo.NIT == null)
                                    //{
                                    //    linea = linea + ",";
                                    //}
                                    //else
                                    //{
                                    //    string tmp = limpiarString(vehiculoComparendo.NIT.Trim());
                                    //    tmp = completarLongitudCadenas(tmp, 15, " ");
                                    //    linea = linea + tmp + ",";
                                    //}

                                    //36. Tarjeta de operacion longitud 10 alfanumerico
                                    if (vehiculoComparendo.TARJETAOPERACION == null)
                                        linea = linea + ",";
                                    else
                                    {
                                        string tmp = limpiarString(vehiculoComparendo.TARJETAOPERACION.Trim());
                                        tmp = completarLongitudCadenas(tmp, 10, " ");
                                        linea = linea + tmp + ",";
                                    }

                                    //-----------------------------DATOS AGENTE--------------------------------------------------------------------------
                                    //37. Numero de la placa del agente longitud 10 alfanumerico
                                    if (viewCompPorFechasTmp.PLACAAGENTE == null)
                                        linea = linea + ",";
                                    else
                                    {
                                        string tmp = limpiarString(viewCompPorFechasTmp.PLACAAGENTE.Trim());
                                        tmp = completarLongitudCadenas(tmp, 10, " ");
                                        linea = linea + tmp + ",";
                                    }

                                    //38. Observaciones comparendo longitud 50 alfanumerico
                                    if (viewCompPorFechasTmp.OBSERVACION == null)
                                        linea = linea + ",";
                                    else
                                    {
                                        string tmp = limpiarString(viewCompPorFechasTmp.OBSERVACION);
                                        tmp = completarLongitudCadenas(tmp, 50, " ");
                                        linea = linea + tmp + ",";
                                    }

                                    //39. Reporta fuga longitud 1 alfanumerico
                                    if (viewCompPorFechasTmp.REPORTAFUGA == null)
                                        linea = linea + "N,";
                                    else
                                    {
                                        if (viewCompPorFechasTmp.REPORTAFUGA.Equals("S") || viewCompPorFechasTmp.REPORTAFUGA.Equals("N"))
                                        {
                                            if (viewCompPorFechasTmp.REPORTAFUGA.Length <= 1)
                                                linea = linea + viewCompPorFechasTmp.REPORTAFUGA.Trim() + ",";
                                            else
                                                linea = linea + viewCompPorFechasTmp.REPORTAFUGA.Remove(1, viewCompPorFechasTmp.REPORTAFUGA.Length - 1).Trim() + ",";
                                        }
                                        else
                                        {
                                            linea = linea + "N,";
                                        }
                                    }

                                    //40. Reporta accidente longitud 1 alfanumerico
                                    if (viewCompPorFechasTmp.REPORTAACCIDENTE == null)
                                        linea = linea + "N,";
                                    else
                                    {
                                        if (viewCompPorFechasTmp.REPORTAACCIDENTE.Equals("S") || viewCompPorFechasTmp.REPORTAACCIDENTE.Equals("N"))
                                        {
                                            if (viewCompPorFechasTmp.REPORTAACCIDENTE.Length <= 1)
                                                linea = linea + viewCompPorFechasTmp.REPORTAACCIDENTE.Trim() + ",";
                                            else
                                                linea = linea + viewCompPorFechasTmp.REPORTAACCIDENTE.Remove(1, viewCompPorFechasTmp.REPORTAACCIDENTE.Length - 1).Trim() + ",";
                                        }
                                        else
                                        {
                                            linea = linea + "N,";
                                        }
                                    }

                                    //41. Reporta inmovilizacion longitud 1 alfanumerico
                                    if (viewCompPorFechasTmp.REPORTAINMOVILIZACION == null)
                                        linea = linea + "N,";
                                    else
                                    {
                                        if (viewCompPorFechasTmp.REPORTAINMOVILIZACION.Equals("S") || viewCompPorFechasTmp.REPORTAINMOVILIZACION.Equals("N"))
                                        {
                                            if (viewCompPorFechasTmp.REPORTAINMOVILIZACION.Length <= 1)
                                                linea = linea + viewCompPorFechasTmp.REPORTAINMOVILIZACION.Trim() + ",";
                                            else
                                                linea = linea + viewCompPorFechasTmp.REPORTAINMOVILIZACION.Remove(1, viewCompPorFechasTmp.REPORTAINMOVILIZACION.Length - 1).Trim() + ",";
                                        }
                                        else
                                        {
                                            linea = linea + "N,";
                                        }
                                    }

                                    //42. Patio inmoviliza longitud 30 alfanumerico
                                    if (viewCompPorFechasTmp.DESCRIPCIONPATIO == null)
                                        linea = linea + ",";
                                    else
                                    {
                                        string tmp = limpiarString(viewCompPorFechasTmp.DESCRIPCIONPATIO);
                                        tmp = completarLongitudCadenas(tmp, 29, " ");
                                        linea = linea + tmp + ",";
                                    }

                                    //43. Direccion patio inmovilizacion longitud 30 alfanumerico
                                    if (viewCompPorFechasTmp.DIRECCIONPATIO_INMOVILIZA == null)
                                        linea = linea + ",";
                                    else
                                    {
                                        string tmp = limpiarString(viewCompPorFechasTmp.DIRECCIONPATIO_INMOVILIZA);
                                        tmp = completarLongitudCadenas(tmp, 30, " ");
                                        linea = linea + tmp + ",";
                                    }

                                    //44. No. Grua longitud 10 alfanumerico
                                    if (viewCompPorFechasTmp.NUMEROGRUA == null)
                                        linea = linea + ",";
                                    else
                                    {
                                        string tmp = limpiarString(viewCompPorFechasTmp.NUMEROGRUA.Trim());
                                        tmp = completarLongitudCadenas(tmp, 10, " ");
                                        linea = linea + tmp + ",";
                                    }

                                    //45. Placa Grua longitud 6 alfanumerico
                                    if (viewCompPorFechasTmp.PLACAGRUA == null)
                                        linea = linea + ",";
                                    else
                                    {
                                        string tmp = limpiarString(viewCompPorFechasTmp.PLACAGRUA.Trim());
                                        tmp = completarLongitudCadenas(tmp, 6, " ");
                                        linea = linea + tmp + ",";
                                    }

                                    //46. Consecutivo inmovilización longitud 15 numerico
                                    if (viewCompPorFechasTmp.CONSECUTIVOINMOVILIZACION == null)
                                        linea = linea + ",";
                                    else
                                    {
                                        if (viewCompPorFechasTmp.CONSECUTIVOINMOVILIZACION.Length <= 15)
                                            linea = linea + viewCompPorFechasTmp.CONSECUTIVOINMOVILIZACION.Trim() + ",";
                                        else
                                            linea = linea + viewCompPorFechasTmp.CONSECUTIVOINMOVILIZACION.Remove(15, viewCompPorFechasTmp.CONSECUTIVOINMOVILIZACION.Length - 15).Trim() + ",";
                                    }

                                    //-------------------------- TESTIGO --------------------------------------------------------------------
                                    // ServiciosGeneralesCompService serviciosGeneralesComp = WS.ServiciosGeneralesCompService();
                                    testigoComp testigo = new testigoComp();
                                    testigo.ID_COMPARENDO = viewCompPorFechasTmp.ID_COMPARENDO;
                                    testigo = serviciosGeneralesComp.getTestigo(testigo);

                                    //47. Identificación del testigo 15 alfanumerico
                                    if (testigo.NROIDENTIFICACION == null)
                                        linea = linea + ",";
                                    else
                                    {
                                        string tmp = limpiarString(testigo.NROIDENTIFICACION.Trim());
                                        tmp = completarLongitudCadenas(tmp, 15, " ");
                                        linea = linea + tmp + ",";
                                    }

                                    //48. Nombres y apellidos testigo longitud 50 alfanumerico
                                    if ((testigo.NOMBRES == null) && (testigo.APELLIDOS == null))
                                        linea = linea + ",";
                                    else
                                    {
                                        string tmp1 = limpiarString(testigo.NOMBRES);
                                        string tmp2 = limpiarString(testigo.APELLIDOS);
                                        nombresApellidos = tmp1 + " " + tmp2;
                                        nombresApellidos = completarLongitudCadenas(nombresApellidos, 50, " ");
                                        linea = linea + nombresApellidos.Trim() + ",";
                                    }

                                    //49. Direccion testigo longitud 40 alfanumerico
                                    if (testigo.DIRECCION == null)
                                        linea = linea + ",";
                                    else
                                    {
                                        string tmp = limpiarString(testigo.DIRECCION);
                                        tmp = completarLongitudCadenas(tmp, 40, " ");
                                        linea = linea + tmp + ",";
                                    }

                                    //50. Teléfono del testigo longitud 15 alfanumerico
                                    if (testigo.NROTELEFONO == null)
                                        linea = linea + ",";
                                    else
                                    {
                                        string tmp = limpiarString(testigo.NROTELEFONO.Trim());
                                        tmp = completarLongitudCadenas(tmp, 15, " ");
                                        linea = linea + tmp + ",";
                                    }

                                    //51. Valor comparendo longitud 8 numerico
                                    if (viewCompPorFechasTmp.VALORINFRACCION == null)
                                        linea = linea + ",";
                                    else
                                    {
                                        string[] aux = viewCompPorFechasTmp.VALORINFRACCION.Trim().Split('.', ',');
                                        string tmp = limpiarString(aux[0]);
                                        tmp = completarLongitudCadenas(tmp, 8, " ");
                                        linea = linea + tmp + ",";
                                        sumRegistros = sumRegistros + double.Parse(aux[0]);
                                    }

                                    //52. Valores adicionales longitud 8 numerico
                                    linea = linea + "0,";

                                    //53. Codigo organismo que reporta longitud 8 numerico
                                    //if (transito.ID_TRANSITO <= 0)
                                    if (transito.ID_CIUDAD <= 0)
                                        linea = linea + ",";
                                    else
                                    {
                                        ciudadComp ciudad = new ciudadComp();
                                        Object[] ciudades;
                                        ciudad.ID_CIUDAD = transito.ID_CIUDAD;
                                        ciudades = serviciosAccesoriasComp.getCiudadComp(ciudad);
                                        if (ciudades == null)
                                            linea = linea + ",";
                                        else
                                        {
                                            ciudad = (ciudadComp)ciudades[0];
                                            if (ciudad.CODCIUDAD == null && ciudad.ID_DEPTO <= 0)
                                                linea = linea + ",";
                                            else
                                            {
                                                string divipo = getDivisionPolitica(ciudad.ID_DEPTO.ToString().Trim(), ciudad.CODCIUDAD.Trim());
                                                divipo = completarLongitudCadenas(divipo, 8, "0");
                                                linea = linea + divipo + ",";
                                            }
                                        }
                                    }

                                    //54. Estado del comparendo longitud 1 numerico
                                    linea = linea + "1,";

                                    //55. Policia de carreteras longitud 1 alfanumerico
                                    if (viewCompPorFechasTmp.POLCA == null )
                                        linea = linea + "N,";
                                    else
                                    {
                                        if (viewCompPorFechasTmp.POLCA.Equals("No") || viewCompPorFechasTmp.POLCA.Equals(""))
                                            linea = linea + "N,";
                                        if (viewCompPorFechasTmp.POLCA.Equals("Si"))
                                        {
                                            linea = linea + "S,";
                                        }
                                        else
                                        {
                                            linea = linea + "N,";
                                        }
                                    }

                                    //56. Codigo infraccion longitud 5 numerico
                                    if (viewCompPorFechasTmp.NUEVO_CODIGOCORREGIDO == null)
                                        linea = linea + ",";
                                    else
                                    {
                                        string tmp = limpiarString(viewCompPorFechasTmp.NUEVO_CODIGOCORREGIDO.Trim());
                                        //tmp = completarLongitudCadenas(tmp, 5, "0");
                                        linea = linea + tmp + ",";
                                    }

                                    //57. Valor de la infraccion 8 numerico
                                    if (viewCompPorFechasTmp.VALORINFRACCION != null)
                                    {
                                        //double doutmp = double.Parse(viewCompPorFechasTmp.VALORINFRACCION.Trim());
                                        //string tmp = limpiarString(doutmp.ToString());
                                        string[] aux = viewCompPorFechasTmp.VALORINFRACCION.Trim().Split('.', ',');
                                        string tmp = limpiarString(aux[0]);
                                        tmp = completarLongitudCadenas(tmp, 8, " ");
                                        linea = linea + tmp;
                                    }
                                    //-------------------------------------------------------------------------------------------------------
                                    infoTramites.WriteLine(linea);
                                    infoTramites.Close();
                                    codchequeo = codchequeo + calcularASCIICadena(linea);
                                    listadatos.Add(linea);

                                }
                                catch (Exception e)
                                {
                                    MessageBox.Show(e.Message);
                                }
                            }
                            infoTramites = new StreamWriter(ubicacion + "/" + fileComparendos, true);
                            //----------------------DATOS FINALES DEL ARCHIVO---------------------------------------------------------------------------------
                            //Numero de registros longitud 5 numerico
                            string tmpfinal = completarLongitudCadenas(numRegistros.ToString(), 5, "0");
                            linea = tmpfinal + ",";

                            //Suma de registros longitud 8 numerico
                            //tmpfinal = completarLongitudCadenas(sumRegistros.ToString(), 8, "0");
                            tmpfinal = sumRegistros.ToString();
                            linea = linea + tmpfinal + ",";

                            //Numero de oficio longitud 10 alfanumerico
                            tmpfinal = completarLongitudCadenas(texNumeroOficio.Text, 10, " ");
                            linea = linea + tmpfinal + ",";

                            //Codigo de cheqeo longitud 4 numerico
                            linea = linea + completarLongitudCadenas(getCodigoChequeo(codchequeo), 4, "0");

                            infoTramites.WriteLine(linea);
                            infoTramites.Close();
                            if (MessageBox.Show("Desea almacenar los comparendos en la base de datos?", "Pregunta?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                string lineacompleta = "";
                                int countPComp = 0;

                                for (int i = 0; i < listadatos.Count; i++)
                                {
                                    lineacompleta = listadatos[i].ToString();
                                    lineacompleta = lineacompleta + linea;
                                    planoComparendo plano_comp = almacenarArchivosPlanosComparendos(lineacompleta, planos_Simit.ID);

                                    if (plano_comp != null && plano_comp.ID_PLANOCOMPARENDO > 0)
                                        countPComp++;
                                }

                                MessageBox.Show("¡ " + countPComp + " registros almacenados correctamente!...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se encontraron comparendos en el rango de fechas!!");
                        }
                    }

                }
                if (cheTodasResoluciones.Checked || cheResolucionesAlcoholemia.Checked || cheResolucionesSinAlcoholemia.Checked)
                {
                    setPlanoResoluciones();
                    resultado = true;
                }
                if (cheRecaudos.Checked)
                {
                    setPlanosPago();
                    resultado = true;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrio un error al importar los archivos " + e.Message);
            }
            return resultado;
        }

        private infractorComp buscaInfractor(int idDocto, string nroIdentificacion)
        {
            ServiciosGeneralesCompService mySerGenerales = WS.ServiciosGeneralesCompService();
            infractorComp infractor = new infractorComp();
            infractor.ID_DOCTO = idDocto;
            infractor.NROIDENTIFICACION = nroIdentificacion;
            infractor = mySerGenerales.buscarInfractor(infractor);
            return infractor;
        }

        private String getCadena(String dato, int longitud, String relleno)
        {
            int i, diferencia;
            String resultado = "";
            if (dato.Length > longitud)
                for (i = 1; i <= longitud; i++)
                    resultado = resultado + relleno;
            else //SE COMENTO PARA QUE NO RELLENARA LOS CAMPOS CON CEROS O ESPACIOS SEGUN SEA EL CASO
                resultado = dato;
            /*if (dato.Length == longitud)
                resultado = dato;
            else
            {
                diferencia = longitud - dato.Length;

                for (i = 1; i <= diferencia; i++)
                    resultado = resultado + relleno;
                if (relleno.Equals(" "))
                    resultado = dato + resultado;
                else
                    resultado = resultado + dato;
            }*/
            return resultado;
        }

        private void butPlanosFaltantes_Click(object sender, EventArgs e)
        {
            try
            {
                if (cheComparendos2.Checked || cheRecaudos2.Checked || cheResolucionesSinAlcoholemia2.Checked || cheTodasResoluciones2.Checked || cheUnicamenteAlcoholemia2.Checked)
                {
                    this.Cursor = Cursors.WaitCursor;
                    if (cheNumeroComparendo2.Checked)
                    {
                        busquedaPorNroComparendo = true;
                        if (texNumeroOficio2.Text.Equals(""))
                        {
                            MessageBox.Show("Falta llenar el número de oficio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                        else
                        {
                            if (Convert.ToInt64(texNumeroOficio2.Text) > 2147483646)
                            {
                                MessageBox.Show("El número de oficio no puede ser mayor a \"2147483646\"", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }
                            else
                            {
                                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                                {
                                    ubicacion = folderBrowserDialog1.SelectedPath;
                                    setPlanos(4);
                                }
                                else
                                {
                                    MessageBox.Show("No se generaron archivos planos. Debe eligir una ubicacion para los archivos planos que se van a generar", "No se selecciono ninguna ubicacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    ubicacion = "";
                                }
                            }
                        }
                        this.Cursor = Cursors.Arrow;
                    }
                    if (cheInfractor2.Checked)
                    {
                        if (texIdentificacion2.Text.Equals(""))
                        {
                            MessageBox.Show("Falta llenar el número de identificación", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                        else
                        {
                            if (texNumeroOficio2.Text.Equals(""))
                            {
                                MessageBox.Show("Falta llenar el número de oficio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }
                            else
                            {
                                if (Convert.ToInt64(texNumeroOficio2.Text) > 2147483646)
                                {
                                    MessageBox.Show("El número de oficio no puede ser mayor a \"2147483646\"", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                }
                                else
                                {
                                    if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                                    {
                                        ubicacion = folderBrowserDialog1.SelectedPath;
                                        setPlanos(4);
                                    }
                                    else
                                    {
                                        MessageBox.Show("No se generaron archivos planos. Debe eligir una ubicacion para los archivos planos que se van a generar", "No se selecciono ninguna ubicacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        ubicacion = "";
                                    }
                                }
                            }
                        }
                        this.Cursor = Cursors.Arrow;
                    }
                    else
                    {
                        if (texNumeroOficio2.Text.Equals(""))
                        {
                            MessageBox.Show("Falta llenar el numero de oficio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                        else
                        {
                            if (Convert.ToInt64(texNumeroOficio2.Text) > 2147483646)
                            {
                                MessageBox.Show("El número de oficio no puede ser mayor a \"2147483646\"", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }
                            else
                            {
                                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                                {
                                    ubicacion = folderBrowserDialog1.SelectedPath;
                                    setPlanos(4);
                                }
                                else
                                {
                                    MessageBox.Show("No se generaron archivos planos. Debe eligir una ubicacion para los archivos planos que se van a generar", "No se selecciono ninguna ubicacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    ubicacion = "";
                                }
                            }
                        }
                        this.Cursor = Cursors.Arrow;
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una de las opciones para generar los planos?", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
            }
        }

        private void cheTodasResoluciones_CheckedChanged(object sender, EventArgs e)
        {
            if (cheTodasResoluciones.Checked)
            {
                cheResolucionesAlcoholemia.Enabled = false;
                cheResolucionesAlcoholemia.Checked = false;
                cheResolucionesSinAlcoholemia.Enabled = false;
                cheResolucionesSinAlcoholemia.Checked = false;
            }
            else
            {
                cheResolucionesAlcoholemia.Enabled = true;
                cheResolucionesSinAlcoholemia.Enabled = true;
            }
        }

        private void cheTodasResoluciones2_CheckedChanged(object sender, EventArgs e)
        {
            if (cheTodasResoluciones2.Checked)
            {
                cheUnicamenteAlcoholemia2.Enabled = false;
                cheUnicamenteAlcoholemia2.Checked = false;
                cheResolucionesSinAlcoholemia2.Enabled = false;
                cheResolucionesSinAlcoholemia2.Checked = false;
            }
            else
            {
                cheUnicamenteAlcoholemia2.Enabled = true;
                cheResolucionesSinAlcoholemia2.Enabled = true;
            }
        }

        private void cheInfractor_CheckedChanged(object sender, EventArgs e)
        {
            if (cheInfractor.Checked)
            {
                comTipoIdentificacion.Enabled = true;
                texIdentificacion.ReadOnly = false;
                chePorNumeroComparendo.Checked = false;
            }
            else
            {
                comTipoIdentificacion.Enabled = false;
                texIdentificacion.ReadOnly = true;
            }
        }

        private void chePorNumeroComparendo_CheckedChanged(object sender, EventArgs e)
        {
            if (chePorNumeroComparendo.Checked)
            {
                texNumeroComparendo.ReadOnly = false;
                cheInfractor.Checked = false;
                butCargarListado.Enabled = true;
            }
            else
            {
                texNumeroComparendo.ReadOnly = true;
                butCargarListado.Enabled = true;
            }
        }

        private void cheInfractor2_CheckedChanged(object sender, EventArgs e)
        {
            if (cheInfractor2.Checked)
            {
                comTipoDocumento2.Enabled = true;
                texIdentificacion2.ReadOnly = false;
                cheNumeroComparendo2.Checked = false;
            }
            else
            {
                comTipoDocumento2.Enabled = false;
                texIdentificacion2.ReadOnly = true;
            }
        }

        private void cheNumeroComparendo2_CheckedChanged(object sender, EventArgs e)
        {
            if (cheNumeroComparendo2.Checked)
            {
                texNumeroComparendo2.ReadOnly = false;
                cheInfractor2.Checked = false;
            }
            else
                texNumeroComparendo2.ReadOnly = true;
        }

        public planosSimit createPlanosSimit(planosSimit planos_Simit)
        {
            ServiciosPlanosSimitService serviciosPlanosSimit = WS.ServiciosPlanosSimitService();
            if (planos_Simit != null)
                planos_Simit = serviciosPlanosSimit.createPlanosSimit(planos_Simit, WS.MyUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName());
            return planos_Simit;
        }

        //private void createPlanosComparendo(planoComparendo planos_comparendo)
        //{
        //    ServiciosPlanoComparendoService mySerPlanoComp = WS.ServiciosPlanoComparendoService();
        //    if (planos_comparendo != null)
        //    {
        //        planos_comparendo = mySerPlanoComp.createPlanoComparendo(planos_comparendo, WS.MyUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName());
        //    }
        //}

        private planoComparendo createPlanosComparendo(planoComparendo planos_comparendo)
        {
            ServiciosPlanoComparendoService mySerPlanoComp = WS.ServiciosPlanoComparendoService();
            planoComparendo plano_comparendocreado;

            plano_comparendocreado = mySerPlanoComp.createPlanoComparendo(planos_comparendo, WS.MyUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName());
            return plano_comparendocreado;
        }

        public void createPlanosResoluciones(planoResoluciones planos_resoluciones)
        {
            ServiciosPlanoResolucionesService mySerResol = WS.ServiciosPlanoResolucionesService();
            if (planos_resoluciones != null)
            {
                planos_resoluciones = mySerResol.createPlanoResoluciones(planos_resoluciones, WS.MyUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName());
            }
        }

        public void createPlanosRecaudos(planoRecaudos planos_recuado)
        {
            ServiciosPlanoRecaudosService mySerRecuados = WS.ServiciosPlanoRecaudosService();
            if (planos_recuado != null)
            {
                planos_recuado = mySerRecuados.createPlanoRecaudos(planos_recuado, WS.MyUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName());
            }
        }

        public string limpiarString(string texto)
        {
            string cadenalimpia = texto.Replace(",", "");
            return cadenalimpia;
        }

        public string getDivisionPolitica(string idDepto, string cod_ciudad)
        {
            string divPolitica = "";
            int tmp = int.Parse(idDepto);
            if (tmp < 10)
            {
                idDepto = "0" + idDepto;
            }
            divPolitica = idDepto + cod_ciudad + "000";
            return divPolitica;
        }

        private void setPlanoResoluciones()
        {
            int numRegistros = 0;
            string fec1 = funciones.formatFecha(calFechaIni.SelectionRange.Start.ToString().Remove(10, calFechaIni.SelectionRange.Start.ToString().Length - 10));
            string fec2 = funciones.formatFecha(calFechaFin.SelectionRange.Start.ToString().Remove(10, calFechaFin.SelectionRange.Start.ToString().Length - 10));
            string linea = "";
            double sumRegistros = 0;
            StreamWriter infoResoluciones;
            ArrayList listadatos = new ArrayList();
            int codchequeo = 0;
            if (cheTodasResoluciones.Checked)
            {
                LibreriasSintrat.ServiciosViewResoluciones.viewResoluciones resoluciones = new LibreriasSintrat.ServiciosViewResoluciones.viewResoluciones();
                object[] listaRes;
                ServiciosViewResolucionesService mySerResoluciones = WS.ServiciosViewResolucionesService();
                if (busquedaPorNroComparendo)
                {
                    resoluciones.NUMEROCOMPARENDO = texNumeroComparendo.Text;
                    listaRes = mySerResoluciones.getViewResoluciones(resoluciones);
                }
                else
                {
                    if (cheInfractor.Checked)
                    {
                        infractorComp infractor = buscaInfractor(int.Parse(comTipoIdentificacion.SelectedValue.ToString()), texIdentificacion.Text);
                        if (infractor != null)
                        {
                            resoluciones.NROIDENTIFICACION = infractor.NROIDENTIFICACION;
                            listaRes = mySerResoluciones.getResolucionesPorFechas(resoluciones, fec1, fec2);
                        }
                        else
                        {
                            listaRes = null;
                        }
                    }
                    else
                    {
                        listaRes = mySerResoluciones.getResolucionesPorFechas(resoluciones, fec1, fec2);
                    }
                }
                transitoComp transito = new transitoComp();
                ServiciosGeneralesCompService mySerGenCom = WS.ServiciosGeneralesCompService();
                transito = mySerGenCom.getTransitoComp(transito);
                fileResoluciones = transito.NIT + "resol.txt";
                planosSimit planos_Simit = new planosSimit();
                ServiciosGeneralesService serviciosGenerales = WS.ServiciosGeneralesService();
                planos_Simit.FECHAINIPLANOS = funciones.formatFecha(calFechaIni.SelectionRange.Start.ToString().Remove(10, calFechaIni.SelectionRange.Start.ToString().Length - 10));
                planos_Simit.FECHAFINPLANOS = funciones.formatFecha(calFechaFin.SelectionRange.Start.ToString().Remove(10, calFechaFin.SelectionRange.Start.ToString().Length - 10));
                planos_Simit.FECHAREGISTRO = funciones.formatFecha(serviciosGenerales.getFechaServidor());

                if (datRangos.CurrentRow != null)
                    planos_Simit.ID_RANGOCOMPARENDOS = Convert.ToInt32(datRangos.CurrentRow.Cells["ID_RANGOCOMPARENDO"].Value.ToString());

                planos_Simit.NOMBRECARGA = "Planos de Oficio Numero " + texNumeroOficio.Text + " y Fecha " + planos_Simit.FECHAREGISTRO.ToString();
                planos_Simit.OFICIO = Convert.ToInt32(texNumeroOficio.Text);
                planos_Simit.RUTA = folderBrowserDialog1.SelectedPath;
                planos_Simit = createPlanosSimit(planos_Simit);
                if (listaRes != null)
                {
                    foreach (LibreriasSintrat.ServiciosViewResoluciones.viewResoluciones viewResol in listaRes)
                    {
                        infoResoluciones = new StreamWriter(ubicacion + "/" + fileResoluciones, true);
                        numRegistros++;
                        //1. Consecutivo longitud 5 Numerico
                        if (numRegistros > 19999)
                            numRegistros = 1;
                        linea = numRegistros.ToString() + ",";

                        //2. Numero de resolucion de longitud 10 Alfanumerico
                        if (viewResol.NUMERO == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = limpiarString(viewResol.NUMERO.Trim());
                            tmp = completarLongitudCadenas(tmp, 10, " ");
                            linea = linea + tmp + ",";
                        }

                        //3. Numero de Resolucion anterior longitud 10 Alfanumerico
                        if (viewResol.CODTIPORESOLUCION == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            if (!viewResol.CODTIPORESOLUCION.Equals("1") || !viewResol.CODTIPORESOLUCION.Equals("7"))
                            {
                                //string tmp = limpiarString(viewResol.CODTIPORESOLUCION.Trim());
                                //tmp = completarLongitudCadenas(tmp, 10, " ");
                                string tmp = completarLongitudCadenas("", 10, " ");
                                linea = linea + tmp + ",";
                            }
                            else
                            {
                                string tmp = completarLongitudCadenas("", 10, " ");
                                linea = linea + tmp + ",";
                            }
                        }

                        //4. Fecha de resolucion longitud 10 numerico
                        if (viewResol.FECHA == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            DateTime fecha = DateTime.Parse(viewResol.FECHA);
                            string tmp = completarLongitudCadenas(fecha.ToString("dd/MM/yyyy"), 10, "0");
                            linea = linea + tmp + ",";
                        }

                        //5. Codigo de tipo de resolucion longitud 2 numerico
                        if (viewResol.CODTIPORESOLUCION == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = completarLongitudCadenas(viewResol.CODTIPORESOLUCION.Trim(), 2, "0");
                            linea = linea + tmp + ",";
                        }

                        //6. Fecha hasta en suspensiones longitud 10 numerico
                        if (viewResol.CODTIPORESOLUCION == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            if (viewResol.CODTIPORESOLUCION.Equals("7"))
                            {
                                estadoAlcoholemia ealcoholemia = new estadoAlcoholemia();
                                if (viewResol.VALORALCOLEMIA != null)
                                {
                                    ealcoholemia = mySerGenCom.getFechaSuspension(ealcoholemia, int.Parse(viewResol.VALORALCOLEMIA), true);
                                    if (ealcoholemia != null && ealcoholemia.ID > 0)
                                    {
                                        if (ealcoholemia.TIEMPO == 0)
                                        {
                                            linea = linea + "0000000000,";
                                        }
                                        else
                                        {
                                            DateTime fecha = DateTime.Parse(viewResol.FECHACOMPARENDO);
                                            fecha.AddMonths(ealcoholemia.TIEMPO);
                                            string tmp = completarLongitudCadenas(fecha.ToString("dd/MM/yyyy"), 10, "0");
                                            linea = linea + tmp + ",";
                                        }
                                    }
                                    else
                                    {
                                        linea = linea + "0000000000,";
                                    }
                                }
                                else
                                {
                                    linea = linea + "0000000000,";
                                }
                            }
                            else
                            {
                                linea = linea + "0000000000,";
                            }
                        }

                        //7. Numero de comparendo longitud 20 alfanumerico
                        if (viewResol.NUMEROCOMPARENDO == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = limpiarString(viewResol.NUMEROCOMPARENDO.Trim());
                            tmp = completarLongitudCadenas(tmp, 20, " ");
                            linea = linea + tmp + ",";
                        }

                        //8. Fecha comparendo 10 alfanumerico
                        if (viewResol.FECHACOMPARENDO == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            DateTime fecha = DateTime.Parse(viewResol.FECHACOMPARENDO);
                            string tmp = completarLongitudCadenas(fecha.ToString("dd/MM/yyyy"), 10, " ");
                            linea = linea + tmp + ",";
                        }

                        //9. Nro idenificacion de infractor 15 numerico
                        if (viewResol.NROIDENTIFICACION == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = limpiarString(viewResol.NROIDENTIFICACION.Trim());
                            tmp = completarLongitudCadenas(tmp, 15, "0");
                            linea = linea + tmp + ",";
                        }

                        //10. Codigo tipo de documento longitud 1 numerico
                        if (viewResol.IDREPORTECOMPARENDO <= 0)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = limpiarString(viewResol.IDREPORTECOMPARENDO.ToString());
                            tmp = completarLongitudCadenas(tmp, 1, "0");
                            linea = linea + tmp + ",";
                        }

                        //11. Nombre Infractor longitud 18 alfanumerico
                        if (viewResol.NOMBRES == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = limpiarString(viewResol.NOMBRES);
                            tmp = completarLongitudCadenas(tmp, 18, " ");
                            linea = linea + tmp + ",";
                        }

                        //12. Apellidos Infrector longitud 20 alfanumerico
                        if (viewResol.APELLIDOS == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = limpiarString(viewResol.APELLIDOS);
                            tmp = completarLongitudCadenas(tmp, 19, " ");
                            linea = linea + tmp + ",";
                        }

                        //13. Direccion infrector longitud 40 alfanumerico
                        if (viewResol.DIRECCION == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = limpiarString(viewResol.DIRECCION);
                            tmp = completarLongitudCadenas(tmp, 40, " ");
                            linea = linea + tmp + ",";
                        }

                        //14. Telefono infractor longitud 15 alfanumerico
                        if (viewResol.TELEFONO == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = limpiarString(viewResol.TELEFONO.Trim());
                            tmp = completarLongitudCadenas(tmp, 15, " ");
                            linea = linea + tmp + ",";
                        }

                        //15. Codigo Ciudad de residencia DIVIPO residencia infractor longitud 8 numerico
                        if (viewResol.ID_DEPTO == null && viewResol.CODCIUDAD == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = getDivisionPolitica(viewResol.ID_DEPTO.Trim(), viewResol.CODCIUDAD.Trim());
                            tmp = limpiarString(tmp);
                            tmp = completarLongitudCadenas(tmp, 8, "0");
                            linea = linea + tmp + ",";
                        }

                        //16. Valor total de la resolucion longitud 8 numerico
                        if (viewResol.VALORINFRACCION == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            //double tmpDouble = double.Parse(viewResol.VALORINFRACCION);
                            //string tmp = completarLongitudCadenas(tmpDouble.ToString(), 8, "0");
                            //linea = linea + tmp + ",";
                            //sumRegistros = sumRegistros + double.Parse(viewResol.VALORINFRACCION);

                            string[] aux = viewResol.VALORINFRACCION.Trim().Split('.', ',');
                            string tmp = limpiarString(aux[0]);
                            tmp = completarLongitudCadenas(tmp, 8, " ");
                            linea = linea + tmp + ",";
                            sumRegistros = sumRegistros + Convert.ToDouble(tmp);
                        }

                        //17. Valores adicionales longitud 8 numerico
                        linea = linea + "00000000,";

                        //18. Codigo del organismo que reporta(divipo de secretaria) longitud 8 numerico
                        if (transito.ID_CIUDAD <= 0)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            ciudadComp ciudad = new ciudadComp();
                            ciudad.ID_CIUDAD = transito.ID_CIUDAD;
                            ciudad = (ciudadComp)((object[])serviciosAccesoriasComp.getCiudadComp(ciudad))[0];
                            if (ciudad != null && ciudad.ID_CIUDAD > 0)
                            {
                                string tmp = getDivisionPolitica(ciudad.ID_DEPTO.ToString().Trim(), ciudad.CODCIUDAD.Trim());
                                tmp = limpiarString(tmp);
                                linea = linea + tmp + ",";
                            }
                            else
                            {
                                linea = linea + ",";
                            }
                        }

                        //19. Comparendos policia de carretera longitud 1 alfanumerico
                        if (viewResol.POLCA == null)
                        {
                            linea = linea + "N,";
                        }
                        else
                        {
                            if (viewResol.POLCA.Equals("Si"))
                            {
                                linea = linea + "S,";
                            }
                            else
                            {
                                linea = linea + "N,";
                            }
                        }

                        //20. Codigo infraccion longitud 5 numerico
                        if (viewResol.NUEVO_CODIGOCORREGIDO == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = limpiarString(viewResol.NUEVO_CODIGOCORREGIDO.Trim());
                            //tmp = completarLongitudCadenas(tmp, 5, "0");
                            linea = linea + tmp + ",";
                        }

                        //21. Valor de la infraccion logitud 8 numerico
                        if (viewResol.VALORINFRACCION == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            //double tmpDouble = double.Parse(viewResol.VALORINFRACCION);
                            //string tmp = completarLongitudCadenas(tmpDouble.ToString(), 8, "0");
                            string[] aux = viewResol.VALORINFRACCION.Trim().Split('.', ',');
                            string tmp = limpiarString(aux[0]);
                            tmp = completarLongitudCadenas(tmp, 8, " ");
                            linea = linea + tmp + ",";
                        }

                        //22. Valor a pagar infraccion longitud 8 numerico
                        if (viewResol.VALORINFRACCION != null)
                        {
                            //double tmpDouble = double.Parse(viewResol.VALORINFRACCION);
                            //string tmp = completarLongitudCadenas(tmpDouble.ToString(), 8, "0");
                            //linea = linea + tmp;
                            string[] aux = viewResol.VALORINFRACCION.Trim().Split('.', ',');
                            string tmp = limpiarString(aux[0]);
                            tmp = completarLongitudCadenas(tmp, 8, " ");
                            linea = linea + tmp;
                        }
                        infoResoluciones.WriteLine(linea);
                        infoResoluciones.Close();
                        listadatos.Add(linea);
                        codchequeo = codchequeo + calcularASCIICadena(linea);
                        if (viewResol.NUEVO_CODIGO.Equals("E3"))
                        {
                            infoResoluciones = new StreamWriter(ubicacion + "/" + fileResoluciones, true);
                            string linea2;
                            numRegistros++;
                            //1. Consecutivo longitud 5 Numerico
                            if (numRegistros > 19999)
                                numRegistros = 1;
                            linea2 = numRegistros.ToString() + ",";

                            //2. Numero de resolucion de longitud 10 Alfanumerico
                            if (viewResol.NUMERO == null)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                string tmp = limpiarString(viewResol.NUMERO.Trim());
                                tmp = completarLongitudCadenas(tmp, 10, " ");
                                linea2 = linea2 + tmp + ",";
                            }

                            //3. Numero de Resolucion anterior longitud 10 Alfanumerico
                            if (viewResol.CODTIPORESOLUCION == null)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                if (!viewResol.CODTIPORESOLUCION.Equals("1") || !viewResol.CODTIPORESOLUCION.Equals("7"))
                                {
                                    //string tmp = limpiarString(viewResol.CODTIPORESOLUCION.Trim());
                                    //tmp = completarLongitudCadenas(tmp, 10, " ");
                                    string tmp = completarLongitudCadenas("", 10, " ");
                                    linea2 = linea2 + tmp + ",";
                                }
                                else
                                {
                                    string tmp = completarLongitudCadenas("", 10, " ");
                                    linea2 = linea2 + tmp + ",";
                                }
                            }

                            //4. Fecha de resolucion longitud 10 numerico
                            if (viewResol.FECHA == null)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                DateTime fecha = DateTime.Parse(viewResol.FECHA);
                                string tmp = completarLongitudCadenas(fecha.ToString("dd/MM/yyyy"), 10, "0");
                                linea2 = linea2 + tmp + ",";
                            }

                            //5. Codigo de tipo de resolucion longitud 2 numerico
                            linea2 = linea2 + "01,";

                            //6. Fecha hasta en suspensiones longitud 10 numerico
                            linea2 = linea2 + "00/00/0000,";

                            //7. Numero de comparendo longitud 20 alfanumerico
                            if (viewResol.NUMEROCOMPARENDO == null)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                string tmp = limpiarString(viewResol.NUMEROCOMPARENDO.Trim());
                                tmp = completarLongitudCadenas(tmp, 20, " ");
                                linea2 = linea2 + tmp + ",";
                            }

                            //8. Fecha comparendo 10 alfanumerico
                            if (viewResol.FECHACOMPARENDO == null)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                DateTime fecha = DateTime.Parse(viewResol.FECHACOMPARENDO);
                                string tmp = completarLongitudCadenas(fecha.ToString("dd/MM/yyyy"), 10, " ");
                                linea2 = linea2 + tmp + ",";
                            }

                            //9. Nro idenificacion de infractor 15 numerico
                            if (viewResol.NROIDENTIFICACION == null)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                string tmp = limpiarString(viewResol.NROIDENTIFICACION.Trim());
                                tmp = completarLongitudCadenas(tmp, 15, "0");
                                linea2 = linea2 + tmp + ",";
                            }

                            //10. Codigo tipo de documento longitud 1 numerico
                            if (viewResol.IDREPORTECOMPARENDO <= 0)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                string tmp = limpiarString(viewResol.IDREPORTECOMPARENDO.ToString());
                                tmp = completarLongitudCadenas(tmp, 1, "0");
                                linea2 = linea2 + tmp + ",";
                            }

                            //11. Nombre Infractor longitud 18 alfanumerico
                            if (viewResol.NOMBRES == null)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                string tmp = limpiarString(viewResol.NOMBRES);
                                tmp = completarLongitudCadenas(tmp, 18, " ");
                                linea2 = linea2 + tmp + ",";
                            }

                            //12. Apellidos Infrector longitud 20 alfanumerico
                            if (viewResol.APELLIDOS == null)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                string tmp = limpiarString(viewResol.APELLIDOS);
                                tmp = completarLongitudCadenas(tmp, 19, " ");
                                linea2 = linea2 + tmp + ",";
                            }

                            //13. Direccion infrector longitud 40 alfanumerico
                            if (viewResol.DIRECCION == null)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                string tmp = limpiarString(viewResol.DIRECCION);
                                tmp = completarLongitudCadenas(tmp, 40, " ");
                                linea2 = linea2 + tmp + ",";
                            }

                            //14. Telefono infractor longitud 15 alfanumerico
                            if (viewResol.TELEFONO == null)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                string tmp = limpiarString(viewResol.TELEFONO.Trim());
                                tmp = completarLongitudCadenas(tmp, 15, " ");
                                linea2 = linea2 + tmp + ",";
                            }

                            //15. Codigo Ciudad de residencia DIVIPO residencia infractor longitud 8 numerico
                            if (viewResol.ID_DEPTO == null && viewResol.CODCIUDAD == null)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                string tmp = getDivisionPolitica(viewResol.ID_DEPTO.Trim(), viewResol.CODCIUDAD.Trim());
                                tmp = limpiarString(tmp);
                                tmp = completarLongitudCadenas(tmp, 8, "0");
                                linea2 = linea2 + tmp + ",";
                            }

                            //16. Valor total de la resolucion longitud 8 numerico
                            if (viewResol.VALORINFRACCION == null)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                //double tmpDouble = double.Parse(viewResol.VALORINFRACCION);
                                //string tmp = completarLongitudCadenas(tmpDouble.ToString(), 8, "0");
                                //linea2 = linea2 + tmp + ",";
                                string[] aux = viewResol.VALORINFRACCION.Trim().Split('.', ',');
                                string tmp = limpiarString(aux[0]);
                                tmp = completarLongitudCadenas(tmp, 8, " ");
                                linea2 = linea2 + tmp + ",";
                                sumRegistros = sumRegistros + Convert.ToDouble(viewResol.VALORINFRACCION);
                            }

                            //17. Valores adicionales longitud 8 numerico
                            linea2 = linea2 + "00000000,";

                            //18. Codigo del organismo que reporta(divipo de secretaria) longitud 8 numerico
                            if (transito.ID_CIUDAD <= 0)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                ciudadComp ciudad = new ciudadComp();
                                ciudad.ID_CIUDAD = transito.ID_CIUDAD;
                                ciudad = (ciudadComp)((object[])serviciosAccesoriasComp.getCiudadComp(ciudad))[0];
                                if (ciudad != null && ciudad.ID_CIUDAD > 0)
                                {
                                    string tmp = getDivisionPolitica(ciudad.ID_DEPTO.ToString(), ciudad.CODCIUDAD.Trim());
                                    tmp = limpiarString(tmp);
                                    linea2 = linea2 + tmp + ",";
                                }
                                else
                                {
                                    linea2 = linea2 + ",";
                                }
                            }

                            //19. Comparendos policia de carretera longitud 1 alfanumerico
                            if (viewResol.POLCA == null)
                            {
                                linea2 = linea2 + "N,";
                            }
                            else
                            {
                                if (viewResol.POLCA.Equals("Si"))
                                {
                                    linea2 = linea2 + "S,";
                                }
                                else
                                {
                                    linea2 = linea2 + "N,";
                                }
                            }

                            //20. Codigo infraccion longitud 5 numerico
                            if (viewResol.NUEVO_CODIGOCORREGIDO == null)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                string tmp = limpiarString(viewResol.NUEVO_CODIGOCORREGIDO.Trim());
                                //tmp = completarLongitudCadenas(tmp, 5, "0");
                                linea2 = linea2 + tmp + ",";
                            }

                            //21. Valor de la infraccion logitud 8 numerico
                            if (viewResol.VALORINFRACCION == null)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                //double tmpDouble = double.Parse(viewResol.VALORINFRACCION);
                                //string tmp = completarLongitudCadenas(tmpDouble.ToString(), 8, "0");
                                //linea2 = linea2 + tmp + ",";
                                string[] aux = viewResol.VALORINFRACCION.Trim().Split('.', ',');
                                string tmp = limpiarString(aux[0]);
                                tmp = completarLongitudCadenas(tmp, 8, " ");
                                linea2 = linea2 + tmp + ",";
                            }

                            //22. Valor a pagar infraccion longitud 8 numerico
                            if (viewResol.VALORINFRACCION != null)
                            {
                                //double tmpDouble = double.Parse(viewResol.VALORINFRACCION);
                                //string tmp = completarLongitudCadenas(tmpDouble.ToString(), 8, "0");
                                //linea2 = linea2 + tmp;
                                string[] aux = viewResol.VALORINFRACCION.Trim().Split('.', ',');
                                string tmp = limpiarString(aux[0]);
                                tmp = completarLongitudCadenas(tmp, 8, " ");
                                linea2 = linea2 + tmp;
                            }
                            infoResoluciones.WriteLine(linea2);
                            infoResoluciones.Close();
                            listadatos.Add(linea2);
                            codchequeo = codchequeo + calcularASCIICadena(linea2);
                        }
                    }
                    infoResoluciones = new StreamWriter(ubicacion + "/" + fileResoluciones, true);
                    //----------------------DATOS FINALES DEL ARCHIVO---------------------------------------------------------------------------------
                    //Numero de registros longitud 5 numerico
                    string tmpfinal = completarLongitudCadenas(numRegistros.ToString(), 5, "0");
                    linea = tmpfinal + ",";

                    //Suma de registros longitud 8 numerico
                    //tmpfinal = completarLongitudCadenas(sumRegistros.ToString(), 8, "0");
                    tmpfinal = sumRegistros.ToString();
                    linea = linea + tmpfinal + ",";

                    //Numero de oficio longitud 10 alfanumerico
                    tmpfinal = completarLongitudCadenas(texNumeroOficio.Text.Trim(), 10, " ");
                    linea = linea + tmpfinal + ",";

                    //Codigo de cheqeo longitud 4 numerico
                    linea = linea + completarLongitudCadenas(getCodigoChequeo(codchequeo), 4, "0");

                    infoResoluciones.WriteLine(linea);
                    infoResoluciones.Close();
                    if (MessageBox.Show("Desea almacenar las resoluciones en la base de datos?", "Almacenar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string lineacompleta = "";
                        for (int i = 0; i < listadatos.Count; i++)
                        {
                            lineacompleta = listadatos[i].ToString();
                            lineacompleta = lineacompleta + linea;
                            almacenarArchivosPlanosResoluciones(lineacompleta, planos_Simit.ID);
                        }
                        MessageBox.Show("Registros almacenados con éxito...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron resoluciones en el rango de fechas!!", "Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            if (cheResolucionesAlcoholemia.Checked)
            {
                viewResolucionesAlcoholemia viewalcohelemia = new viewResolucionesAlcoholemia();
                object[] listaResAlcoholemia;
                ServiciosViewResolucionesAlcoholemiaService mySerResolucionesAlcoholemia = WS.ServiciosViewResolucionesAlcoholemiaService();
                if (busquedaPorNroComparendo)
                {
                    viewalcohelemia.NUMEROCOMPARENDO = texNumeroComparendo.Text;
                    listaResAlcoholemia = mySerResolucionesAlcoholemia.getViewResolucionesAlcoholemia(viewalcohelemia);
                }
                else
                {
                    if (cheInfractor.Checked)
                    {
                        infractorComp infractor = buscaInfractor(int.Parse(comTipoIdentificacion.SelectedValue.ToString()), texIdentificacion.Text);
                        if (infractor != null)
                        {
                            viewalcohelemia.NROIDENTIFICACION = infractor.NROIDENTIFICACION;
                            listaResAlcoholemia = mySerResolucionesAlcoholemia.getResolucionesAlcoholemiaPorFechas(viewalcohelemia, fec1, fec2);
                        }
                        else
                        {
                            listaResAlcoholemia = null;
                        }
                    }
                    else
                    {
                        listaResAlcoholemia = mySerResolucionesAlcoholemia.getResolucionesAlcoholemiaPorFechas(viewalcohelemia, fec1, fec2);
                    }
                }
                planosSimit planos_Simit = new planosSimit();
                transitoComp transito = new transitoComp();
                ServiciosGeneralesCompService mySerGenCom = WS.ServiciosGeneralesCompService();
                ServiciosGeneralesService serviciosGenerales = WS.ServiciosGeneralesService();
                transito = mySerGenCom.getTransitoComp(transito);
                fileResoluciones = transito.NIT + "resol.txt";
                if (listaResAlcoholemia != null)
                {
                    planos_Simit = new planosSimit();
                    planos_Simit.FECHAINIPLANOS = funciones.formatFecha(calFechaIni.SelectionRange.Start.ToString().Remove(10, calFechaIni.SelectionRange.Start.ToString().Length - 10));
                    planos_Simit.FECHAFINPLANOS = funciones.formatFecha(calFechaFin.SelectionRange.Start.ToString().Remove(10, calFechaFin.SelectionRange.Start.ToString().Length - 10));
                    planos_Simit.FECHAREGISTRO = funciones.formatFecha(serviciosGenerales.getFechaServidor());

                    if (datRangos.CurrentRow != null)
                        planos_Simit.ID_RANGOCOMPARENDOS = Convert.ToInt32(datRangos.CurrentRow.Cells["ID_RANGOCOMPARENDO"].Value.ToString());

                    planos_Simit.NOMBRECARGA = "Planos de Oficio Numero " + texNumeroOficio.Text + " y Fecha " + planos_Simit.FECHAREGISTRO.ToString();
                    planos_Simit.OFICIO = Convert.ToInt32(texNumeroOficio.Text);
                    planos_Simit.RUTA = folderBrowserDialog1.SelectedPath;
                    planos_Simit = createPlanosSimit(planos_Simit);
                    numRegistros = 0;
                    linea = "";
                    foreach (viewResolucionesAlcoholemia viewResol in listaResAlcoholemia)
                    {
                        infoResoluciones = new StreamWriter(ubicacion + "/" + fileResoluciones, true);
                        numRegistros++;
                        //1. Consecutivo longitud 5 Numerico
                        if (numRegistros > 19999)
                            numRegistros = 1;
                        linea = numRegistros.ToString() + ",";

                        //2. Numero de resolucion de longitud 10 Alfanumerico
                        if (viewResol.NUMERO == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = limpiarString(viewResol.NUMERO.Trim());
                            tmp = completarLongitudCadenas(tmp, 10, " ");
                            linea = linea + tmp + ",";
                        }

                        //3. Numero de Resolucion anterior longitud 10 Alfanumerico
                        if (viewResol.CODTIPORESOLUCION == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            if (!viewResol.CODTIPORESOLUCION.Equals("1") || !viewResol.CODTIPORESOLUCION.Equals("7"))
                            {
                                //string tmp = limpiarString(viewResol.CODTIPORESOLUCION.Trim());
                                //tmp = completarLongitudCadenas(tmp, 10, " ");
                                string tmp = completarLongitudCadenas("", 10, " ");
                                linea = linea + tmp + ",";
                            }
                            else
                            {
                                string tmp = completarLongitudCadenas("", 10, " ");
                                linea = linea + tmp + ",";
                            }
                        }

                        //4. Fecha de resolucion longitud 10 numerico
                        if (viewResol.FECHA == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            DateTime fecha = DateTime.Parse(viewResol.FECHA);
                            string tmp = completarLongitudCadenas(fecha.ToString("dd/MM/yyyy"), 10, "0");
                            linea = linea + tmp + ",";
                        }

                        //5. Codigo de tipo de resolucion longitud 2 numerico
                        if (viewResol.CODTIPORESOLUCION == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = completarLongitudCadenas(viewResol.CODTIPORESOLUCION, 2, "0");
                            linea = linea + tmp + ",";
                        }

                        //6. Fecha hasta en suspensiones longitud 10 numerico
                        if (viewResol.CODTIPORESOLUCION == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            if (viewResol.CODTIPORESOLUCION.Equals("7"))
                            {
                                estadoAlcoholemia ealcoholemia = new estadoAlcoholemia();
                                if (viewResol.VALORALCOLEMIA != null)
                                {
                                    ealcoholemia = mySerGenCom.getFechaSuspension(ealcoholemia, int.Parse(viewResol.VALORALCOLEMIA), true);
                                    if (ealcoholemia != null && ealcoholemia.ID > 0)
                                    {
                                        if (ealcoholemia.TIEMPO == 0)
                                        {
                                            linea = linea + "0000000000,";
                                        }
                                        else
                                        {
                                            DateTime fecha = DateTime.Parse(viewResol.FECHACOMPARENDO);
                                            fecha.AddMonths(ealcoholemia.TIEMPO);
                                            string tmp = completarLongitudCadenas(fecha.ToString("dd/MM/yyyy"), 10, "0");
                                            linea = linea + tmp + ",";
                                        }
                                    }
                                    else
                                    {
                                        linea = linea + "0000000000,";
                                    }
                                }
                                else
                                {
                                    linea = linea + "0000000000,";
                                }
                            }
                            else
                            {
                                linea = linea + "0000000000,";
                            }
                        }

                        //7. Numero de comparendo longitud 20 alfanumerico
                        if (viewResol.NUMEROCOMPARENDO == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = limpiarString(viewResol.NUMEROCOMPARENDO.Trim());
                            tmp = completarLongitudCadenas(tmp, 20, " ");
                            linea = linea + tmp + ",";
                        }

                        //8. Fecha comparendo 10 alfanumerico
                        if (viewResol.FECHACOMPARENDO == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            DateTime fecha = DateTime.Parse(viewResol.FECHACOMPARENDO);
                            string tmp = completarLongitudCadenas(fecha.ToString("dd/MM/yyyy"), 10, " ");
                            linea = linea + tmp + ",";
                        }

                        //9. Nro idenificacion de infractor 15 numerico
                        if (viewResol.NROIDENTIFICACION == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = limpiarString(viewResol.NROIDENTIFICACION.Trim());
                            tmp = completarLongitudCadenas(tmp, 15, "0");
                            linea = linea + tmp + ",";
                        }

                        //10. Codigo tipo de documento longitud 1 numerico
                        if (viewResol.IDREPORTECOMPARENDO <= 0)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = limpiarString(viewResol.IDREPORTECOMPARENDO.ToString());
                            tmp = completarLongitudCadenas(tmp, 1, "0");
                            linea = linea + tmp + ",";
                        }

                        //11. Nombre Infractor longitud 18 alfanumerico
                        if (viewResol.NOMBRES == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = limpiarString(viewResol.NOMBRES);
                            tmp = completarLongitudCadenas(tmp, 18, " ");
                            linea = linea + tmp + ",";
                        }

                        //12. Apellidos Infrector longitud 20 alfanumerico
                        if (viewResol.APELLIDOS == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = limpiarString(viewResol.APELLIDOS);
                            tmp = completarLongitudCadenas(tmp, 19, " ");
                            linea = linea + tmp + ",";
                        }

                        //13. Direccion infrector longitud 40 alfanumerico
                        if (viewResol.DIRECCION == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = limpiarString(viewResol.DIRECCION);
                            tmp = completarLongitudCadenas(tmp, 40, " ");
                            linea = linea + tmp + ",";
                        }

                        //14. Telefono infractor longitud 15 alfanumerico
                        if (viewResol.TELEFONO == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = limpiarString(viewResol.TELEFONO.Trim());
                            tmp = completarLongitudCadenas(tmp, 15, " ");
                            linea = linea + tmp + ",";
                        }

                        //15. Codigo Ciudad de residencia DIVIPO residencia infractor longitud 8 numerico
                        if (viewResol.ID_DEPTO == null && viewResol.CODCIUDAD == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = getDivisionPolitica(viewResol.ID_DEPTO.Trim(), viewResol.CODCIUDAD.Trim());
                            tmp = limpiarString(tmp);
                            tmp = completarLongitudCadenas(tmp, 8, "0");
                            linea = linea + tmp + ",";
                        }

                        //16. Valor total de la resolucion longitud 8 numerico
                        if (viewResol.VALORINFRACCION == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            //double tmpDouble = double.Parse(viewResol.VALORINFRACCION);
                            //string tmp = completarLongitudCadenas(tmpDouble.ToString(), 8, "0");
                            //linea = linea + tmp + ",";
                            //sumRegistros = sumRegistros + double.Parse(viewResol.VALORINFRACCION);
                            string[] aux = viewResol.VALORINFRACCION.Trim().Split('.', ',');
                            string tmp = limpiarString(aux[0]);
                            tmp = completarLongitudCadenas(tmp, 8, " ");
                            linea = linea + tmp + ",";
                            sumRegistros = sumRegistros + Convert.ToDouble(viewResol.VALORINFRACCION);
                        }

                        //17. Valores adicionales longitud 8 numerico
                        linea = linea + "00000000,";

                        //18. Codigo del organismo que reporta(divipo de secretaria) longitud 8 numerico
                        if (transito.ID_CIUDAD <= 0)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            ciudadComp ciudad = new ciudadComp();
                            ciudad.ID_CIUDAD = transito.ID_CIUDAD;
                            ciudad = (ciudadComp)((object[])serviciosAccesoriasComp.getCiudadComp(ciudad))[0];
                            if (ciudad != null && ciudad.ID_CIUDAD > 0)
                            {
                                string tmp = getDivisionPolitica(ciudad.ID_DEPTO.ToString().Trim(), ciudad.CODCIUDAD.Trim());
                                tmp = limpiarString(tmp);
                                linea = linea + tmp + ",";
                            }
                            else
                            {
                                linea = linea + ",";
                            }
                        }

                        //19. Comparendos policia de carretera longitud 1 alfanumerico
                        if (viewResol.POLCA == null)
                        {
                            linea = linea + "N,";
                        }
                        else
                        {
                            if (viewResol.POLCA.Equals("Si"))
                            {
                                linea = linea + "S,";
                            }
                            else
                            {
                                linea = linea + "N,";
                            }
                        }

                        //20. Codigo infraccion longitud 5 numerico
                        if (viewResol.NUEVO_CODIGOCORREGIDO == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = limpiarString(viewResol.NUEVO_CODIGOCORREGIDO.Trim());
                            //tmp = completarLongitudCadenas(tmp, 5, "0");
                            linea = linea + tmp + ",";
                        }

                        //21. Valor de la infraccion logitud 8 numerico
                        if (viewResol.VALORINFRACCION == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            //double tmpDouble = double.Parse(viewResol.VALORINFRACCION);
                            //string tmp = completarLongitudCadenas(tmpDouble.ToString(), 8, "0");
                            //linea = linea + tmp + ",";
                            string[] aux = viewResol.VALORINFRACCION.Trim().Split('.', ',');
                            string tmp = limpiarString(aux[0]);
                            tmp = completarLongitudCadenas(tmp, 8, " ");
                            linea = linea + tmp + ",";
                        }

                        //22. Valor a pagar infraccion longitud 8 numerico
                        if (viewResol.VALORINFRACCION != null)
                        {
                            //double tmpDouble = double.Parse(viewResol.VALORINFRACCION);
                            //string tmp = completarLongitudCadenas(tmpDouble.ToString(), 8, "0");
                            //linea = linea + tmp;
                            string[] aux = viewResol.VALORINFRACCION.Trim().Split('.', ',');
                            string tmp = limpiarString(aux[0]);
                            tmp = completarLongitudCadenas(tmp, 8, " ");
                            linea = linea + tmp;
                        }
                        infoResoluciones.WriteLine(linea);
                        infoResoluciones.Close();
                        listadatos.Add(linea);
                        codchequeo = codchequeo + calcularASCIICadena(linea);
                        if (viewResol.NUEVO_CODIGO.Equals("E3"))
                        {
                            string linea2;
                            numRegistros++;
                            infoResoluciones = new StreamWriter(ubicacion + "/" + fileResoluciones, true);
                            //1. Consecutivo longitud 5 Numerico
                            if (numRegistros > 19999)
                                numRegistros = 1;
                            linea2 = numRegistros.ToString() + ",";

                            //2. Numero de resolucion de longitud 10 Alfanumerico
                            if (viewResol.NUMERO == null)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                string tmp = limpiarString(viewResol.NUMERO.Trim());
                                tmp = completarLongitudCadenas(tmp, 10, " ");
                                linea2 = linea2 + tmp + ",";
                            }

                            //3. Numero de Resolucion anterior longitud 10 Alfanumerico
                            if (viewResol.CODTIPORESOLUCION == null)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                if (!viewResol.CODTIPORESOLUCION.Equals("1") || !viewResol.CODTIPORESOLUCION.Equals("7"))
                                {
                                    //string tmp = limpiarString(viewResol.CODTIPORESOLUCION.Trim());
                                    //tmp = completarLongitudCadenas(tmp, 10, " ");
                                    string tmp = completarLongitudCadenas("", 10, " ");
                                    linea2 = linea2 + tmp + ",";
                                }
                                else
                                {
                                    string tmp = completarLongitudCadenas("", 10, " ");
                                    linea2 = linea2 + tmp + ",";
                                }
                            }

                            //4. Fecha de resolucion longitud 10 numerico
                            if (viewResol.FECHA == null)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                DateTime fecha = DateTime.Parse(viewResol.FECHA);
                                string tmp = completarLongitudCadenas(fecha.ToString("dd/MM/yyyy"), 10, "0");
                                linea2 = linea2 + tmp + ",";
                            }

                            //5. Codigo de tipo de resolucion longitud 2 numerico
                            linea2 = linea2 + "01,";

                            //6. Fecha hasta en suspensiones longitud 10 numerico
                            linea2 = linea2 + "00/00/0000,";

                            //7. Numero de comparendo longitud 20 alfanumerico
                            if (viewResol.NUMEROCOMPARENDO == null)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                string tmp = limpiarString(viewResol.NUMEROCOMPARENDO.Trim());
                                tmp = completarLongitudCadenas(tmp, 20, " ");
                                linea2 = linea2 + tmp + ",";
                            }

                            //8. Fecha comparendo 10 alfanumerico
                            if (viewResol.FECHACOMPARENDO == null)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                DateTime fecha = DateTime.Parse(viewResol.FECHACOMPARENDO);
                                string tmp = completarLongitudCadenas(fecha.ToString("dd/MM/yyyy"), 10, " ");
                                linea2 = linea2 + tmp + ",";
                            }

                            //9. Nro idenificacion de infractor 15 numerico
                            if (viewResol.NROIDENTIFICACION == null)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                string tmp = limpiarString(viewResol.NROIDENTIFICACION.Trim());
                                tmp = completarLongitudCadenas(tmp, 15, "0");
                                linea2 = linea2 + tmp + ",";
                            }

                            //10. Codigo tipo de documento longitud 1 numerico
                            if (viewResol.IDREPORTECOMPARENDO <= 0)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                string tmp = limpiarString(viewResol.IDREPORTECOMPARENDO.ToString());
                                tmp = completarLongitudCadenas(tmp, 1, "0");
                                linea2 = linea2 + tmp + ",";
                            }

                            //11. Nombre Infractor longitud 18 alfanumerico
                            if (viewResol.NOMBRES == null)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                string tmp = limpiarString(viewResol.NOMBRES);
                                tmp = completarLongitudCadenas(tmp, 18, " ");
                                linea2 = linea2 + tmp + ",";
                            }

                            //12. Apellidos Infrector longitud 20 alfanumerico
                            if (viewResol.APELLIDOS == null)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                string tmp = limpiarString(viewResol.APELLIDOS);
                                tmp = completarLongitudCadenas(tmp, 19, " ");
                                linea2 = linea2 + tmp + ",";
                            }

                            //13. Direccion infrector longitud 40 alfanumerico
                            if (viewResol.DIRECCION == null)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                string tmp = limpiarString(viewResol.DIRECCION);
                                tmp = completarLongitudCadenas(tmp, 40, " ");
                                linea2 = linea2 + tmp + ",";
                            }

                            //14. Telefono infractor longitud 15 alfanumerico
                            if (viewResol.TELEFONO == null)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                string tmp = limpiarString(viewResol.TELEFONO.Trim());
                                tmp = completarLongitudCadenas(tmp, 15, " ");
                                linea2 = linea2 + tmp + ",";
                            }

                            //15. Codigo Ciudad de residencia DIVIPO residencia infractor longitud 8 numerico
                            if (viewResol.ID_DEPTO == null && viewResol.CODCIUDAD == null)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                string tmp = getDivisionPolitica(viewResol.ID_DEPTO.Trim(), viewResol.CODCIUDAD.Trim());
                                tmp = limpiarString(tmp);
                                tmp = completarLongitudCadenas(tmp, 8, "0");
                                linea2 = linea2 + tmp + ",";
                            }

                            //16. Valor total de la resolucion longitud 8 numerico
                            if (viewResol.VALORINFRACCION == null)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                //double tmpDouble = double.Parse(viewResol.VALORINFRACCION);
                                //string tmp = completarLongitudCadenas(tmpDouble.ToString(), 8, "0");
                                //linea2 = linea2 + tmp + ",";
                                string[] aux = viewResol.VALORINFRACCION.Trim().Split('.', ',');
                                string tmp = limpiarString(aux[0]);
                                tmp = completarLongitudCadenas(tmp, 8, " ");
                                linea2 = linea2 + tmp + ",";
                                sumRegistros = sumRegistros + Convert.ToDouble(viewResol.VALORINFRACCION);
                            }

                            //17. Valores adicionales longitud 8 numerico
                            linea2 = linea2 + "00000000,";

                            //18. Codigo del organismo que reporta(divipo de secretaria) longitud 8 numerico
                            if (transito.ID_CIUDAD <= 0)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                ciudadComp ciudad = new ciudadComp();
                                ciudad.ID_CIUDAD = transito.ID_CIUDAD;
                                ciudad = (ciudadComp)((object[])serviciosAccesoriasComp.getCiudadComp(ciudad))[0];
                                if (ciudad != null && ciudad.ID_CIUDAD > 0)
                                {
                                    string tmp = getDivisionPolitica(ciudad.ID_DEPTO.ToString(), ciudad.CODCIUDAD.Trim());
                                    tmp = limpiarString(tmp);
                                    linea2 = linea2 + tmp + ",";
                                }
                                else
                                {
                                    linea2 = linea2 + ",";
                                }
                            }

                            //19. Comparendos policia de carretera longitud 1 alfanumerico
                            if (viewResol.POLCA == null)
                            {
                                linea2 = linea2 + "N,";
                            }
                            else
                            {
                                if (viewResol.POLCA.Equals("Si"))
                                {
                                    linea2 = linea2 + "S,";
                                }
                                else
                                {
                                    linea2 = linea2 + "N,";
                                }
                            }

                            //20. Codigo infraccion longitud 5 numerico
                            if (viewResol.NUEVO_CODIGOCORREGIDO == null)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                string tmp = limpiarString(viewResol.NUEVO_CODIGOCORREGIDO.Trim());
                                //tmp = completarLongitudCadenas(tmp, 5, "0");
                                linea2 = linea2 + tmp + ",";
                            }

                            //21. Valor de la infraccion logitud 8 numerico
                            if (viewResol.VALORINFRACCION == null)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                //double tmpDouble = double.Parse(viewResol.VALORINFRACCION);
                                //string tmp = completarLongitudCadenas(tmpDouble.ToString(), 8, "0");
                                //linea2 = linea2 + tmp + ",";
                                string[] aux = viewResol.VALORINFRACCION.Trim().Split('.', ',');
                                string tmp = limpiarString(aux[0]);
                                tmp = completarLongitudCadenas(tmp, 8, " ");
                                linea2 = linea2 + tmp + ",";
                            }

                            //22. Valor a pagar infraccion longitud 8 numerico
                            if (viewResol.VALORINFRACCION != null)
                            {
                                //double tmpDouble = double.Parse(viewResol.VALORINFRACCION);
                                //string tmp = completarLongitudCadenas(tmpDouble.ToString(), 8, "0");
                                //linea2 = linea2 + tmp;
                                string[] aux = viewResol.VALORINFRACCION.Trim().Split('.', ',');
                                string tmp = limpiarString(aux[0]);
                                tmp = completarLongitudCadenas(tmp, 8, " ");
                                linea2 = linea2 + tmp;
                            }
                            infoResoluciones.WriteLine(linea2);
                            infoResoluciones.Close();
                            listadatos.Add(linea2);
                            codchequeo = codchequeo + calcularASCIICadena(linea2);
                        }
                    }
                    infoResoluciones = new StreamWriter(ubicacion + "/" + fileResoluciones, true);
                    //----------------------DATOS FINALES DEL ARCHIVO---------------------------------------------------------------------------------
                    //Numero de registros longitud 5 numerico
                    string tmpfinal = completarLongitudCadenas(numRegistros.ToString(), 5, "0");
                    linea = tmpfinal + ",";

                    //Suma de registros longitud 8 numerico
                    //tmpfinal = completarLongitudCadenas(sumRegistros.ToString(), 8, "0");
                    tmpfinal = sumRegistros.ToString();
                    linea = linea + tmpfinal + ",";

                    //Numero de oficio longitud 10 alfanumerico
                    tmpfinal = completarLongitudCadenas(texNumeroOficio.Text.Trim(), 10, " ");
                    linea = linea + tmpfinal + ",";

                    //Codigo de cheqeo longitud 4 numerico
                    linea = linea + completarLongitudCadenas(getCodigoChequeo(codchequeo), 4, "0");

                    infoResoluciones.WriteLine(linea);
                    infoResoluciones.Close();
                    if (MessageBox.Show("Desea almacenar las resoluciones de alcoholemia en la base de datos?", "Pregunta?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string linecompleta = "";
                        for (int i = 0; i < listadatos.Count; i++)
                        {
                            linecompleta = listadatos[i].ToString();
                            linecompleta = linecompleta + linea;
                            almacenarArchivosPlanosResoluciones(linecompleta, planos_Simit.ID);
                        }
                        MessageBox.Show("Registros almacenados con éxito!!", "Información!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron resoluciones con alcoholemia en esas fechas!!", "Advertencia!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            if (cheResolucionesSinAlcoholemia.Checked)
            {
                viewResSinAlcoholemia viewsinalcohelemia = new viewResSinAlcoholemia();
                object[] listaResSinAlcoholemia;
                ServiciosViewResSinAlcoholemiaService mySerResolucionesAlcoholemia = WS.ServiciosViewResSinAlcoholemiaService();
                if (busquedaPorNroComparendo)
                {
                    viewsinalcohelemia.NUMEROCOMPARENDO = texNumeroComparendo.Text;
                    listaResSinAlcoholemia = mySerResolucionesAlcoholemia.getViewResSinAlcoholemia(viewsinalcohelemia);
                }
                else
                {
                    if (cheInfractor.Checked)
                    {
                        infractorComp infractor = buscaInfractor(int.Parse(comTipoIdentificacion.SelectedValue.ToString()), texIdentificacion.Text);
                        if (infractor != null)
                        {
                            viewsinalcohelemia.NROIDENTIFICACION = infractor.NROIDENTIFICACION;
                            listaResSinAlcoholemia = mySerResolucionesAlcoholemia.getResolucionesSinAlcoholemiaPorFechas(viewsinalcohelemia, fec1, fec2);
                        }
                        else
                        {
                            listaResSinAlcoholemia = null;
                        }
                    }
                    else
                    {
                        listaResSinAlcoholemia = mySerResolucionesAlcoholemia.getResolucionesSinAlcoholemiaPorFechas(viewsinalcohelemia, fec1, fec2);
                    }
                }
                planosSimit planos_Simit = new planosSimit();
                transitoComp transito = new transitoComp();
                ServiciosGeneralesCompService mySerGenCom = WS.ServiciosGeneralesCompService();
                ServiciosGeneralesService serviciosGenerales = WS.ServiciosGeneralesService();
                transito = mySerGenCom.getTransitoComp(transito);
                fileResoluciones = transito.NIT + "resol.txt";
                if (listaResSinAlcoholemia != null)
                {
                    planos_Simit = new planosSimit();
                    planos_Simit.FECHAINIPLANOS = funciones.formatFecha(calFechaIni.SelectionRange.Start.ToString().Remove(10, calFechaIni.SelectionRange.Start.ToString().Length - 10));
                    planos_Simit.FECHAFINPLANOS = funciones.formatFecha(calFechaFin.SelectionRange.Start.ToString().Remove(10, calFechaFin.SelectionRange.Start.ToString().Length - 10));
                    planos_Simit.FECHAREGISTRO = funciones.formatFecha(serviciosGenerales.getFechaServidor());

                    if (datRangos.CurrentRow != null)
                        planos_Simit.ID_RANGOCOMPARENDOS = Convert.ToInt32(datRangos.CurrentRow.Cells["ID_RANGOCOMPARENDO"].Value.ToString());

                    planos_Simit.NOMBRECARGA = "Planos de Oficio Numero " + texNumeroOficio.Text + " y Fecha " + planos_Simit.FECHAREGISTRO.ToString();
                    planos_Simit.OFICIO = Convert.ToInt32(texNumeroOficio.Text);
                    planos_Simit.RUTA = folderBrowserDialog1.SelectedPath;
                    planos_Simit = createPlanosSimit(planos_Simit);

                    numRegistros = 0;
                    linea = "";
                    foreach (viewResSinAlcoholemia viewResol in listaResSinAlcoholemia)
                    {
                        infoResoluciones = new StreamWriter(ubicacion + "/" + fileResoluciones, true);
                        numRegistros++;
                        //1. Consecutivo longitud 5 Numerico
                        if (numRegistros > 19999)
                            numRegistros = 1;
                        linea = numRegistros.ToString() + ",";

                        //2. Numero de resolucion de longitud 10 Alfanumerico
                        if (viewResol.NUMERO == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = limpiarString(viewResol.NUMERO.Trim());
                            tmp = completarLongitudCadenas(tmp, 10, " ");
                            linea = linea + tmp + ",";
                        }

                        //3. Numero de Resolucion anterior longitud 10 Alfanumerico
                        if (viewResol.CODTIPORESOLUCION == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            if (!viewResol.CODTIPORESOLUCION.Equals("1") || !viewResol.CODTIPORESOLUCION.Equals("7"))
                            {
                                //string tmp = limpiarString(viewResol.CODTIPORESOLUCION.Trim());
                                //tmp = completarLongitudCadenas(tmp, 10, " ");
                                string tmp = completarLongitudCadenas("", 10, " ");
                                linea = linea + tmp + ",";
                            }
                            else
                            {
                                string tmp = completarLongitudCadenas("", 10, " ");
                                linea = linea + tmp + ",";
                            }
                        }

                        //4. Fecha de resolucion longitud 10 numerico
                        if (viewResol.FECHA == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            DateTime fecha = DateTime.Parse(viewResol.FECHA);
                            string tmp = completarLongitudCadenas(fecha.ToString("dd/MM/yyyy"), 10, "0");
                            linea = linea + tmp + ",";
                        }

                        //5. Codigo de tipo de resolucion longitud 2 numerico
                        if (viewResol.CODTIPORESOLUCION == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = completarLongitudCadenas(viewResol.CODTIPORESOLUCION.Trim(), 2, "0");
                            linea = linea + tmp + ",";
                        }

                        //6. Fecha hasta en suspensiones longitud 10 numerico
                        if (viewResol.CODTIPORESOLUCION == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            if (viewResol.CODTIPORESOLUCION.Equals("7"))
                            {
                                estadoAlcoholemia ealcoholemia = new estadoAlcoholemia();
                                if (viewResol.VALORALCOLEMIA != null)
                                {
                                    ealcoholemia = mySerGenCom.getFechaSuspension(ealcoholemia, int.Parse(viewResol.VALORALCOLEMIA), true);
                                    if (ealcoholemia != null && ealcoholemia.ID > 0)
                                    {
                                        if (ealcoholemia.TIEMPO == 0)
                                        {
                                            linea = linea + "0000000000,";
                                        }
                                        else
                                        {
                                            DateTime fecha = DateTime.Parse(viewResol.FECHACOMPARENDO);
                                            fecha.AddMonths(ealcoholemia.TIEMPO);
                                            string tmp = completarLongitudCadenas(fecha.ToString("dd/MM/yyyy"), 10, "0");
                                            linea = linea + tmp + ",";
                                        }
                                    }
                                    else
                                    {
                                        linea = linea + "0000000000,";
                                    }
                                }
                                else
                                {
                                    linea = linea + "0000000000,";
                                }
                            }
                            else
                            {
                                linea = linea + "0000000000,";
                            }
                        }

                        //7. Numero de comparendo longitud 20 alfanumerico
                        if (viewResol.NUMEROCOMPARENDO == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = limpiarString(viewResol.NUMEROCOMPARENDO.Trim());
                            tmp = completarLongitudCadenas(tmp, 20, " ");
                            linea = linea + tmp + ",";
                        }

                        //8. Fecha comparendo 10 alfanumerico
                        if (viewResol.FECHACOMPARENDO == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            DateTime fecha = DateTime.Parse(viewResol.FECHACOMPARENDO);
                            string tmp = completarLongitudCadenas(fecha.ToString("dd/MM/yyyy"), 10, " ");
                            linea = linea + tmp + ",";
                        }

                        //9. Nro idenificacion de infractor 15 numerico
                        if (viewResol.NROIDENTIFICACION == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = limpiarString(viewResol.NROIDENTIFICACION.Trim());
                            tmp = completarLongitudCadenas(tmp, 15, "0");
                            linea = linea + tmp + ",";
                        }

                        //10. Codigo tipo de documento longitud 1 numerico
                        if (viewResol.IDREPORTECOMPARENDO <= 0)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = limpiarString(viewResol.IDREPORTECOMPARENDO.ToString());
                            tmp = completarLongitudCadenas(tmp, 1, "0");
                            linea = linea + tmp + ",";
                        }

                        //11. Nombre Infractor longitud 18 alfanumerico
                        if (viewResol.NOMBRES == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = limpiarString(viewResol.NOMBRES);
                            tmp = completarLongitudCadenas(tmp, 18, " ");
                            linea = linea + tmp + ",";
                        }

                        //12. Apellidos Infrector longitud 20 alfanumerico
                        if (viewResol.APELLIDOS == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = limpiarString(viewResol.APELLIDOS);
                            tmp = completarLongitudCadenas(tmp, 19, " ");
                            linea = linea + tmp + ",";
                        }

                        //13. Direccion infrector longitud 40 alfanumerico
                        if (viewResol.DIRECCION == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = limpiarString(viewResol.DIRECCION);
                            tmp = completarLongitudCadenas(tmp, 40, " ");
                            linea = linea + tmp + ",";
                        }

                        //14. Telefono infractor longitud 15 alfanumerico
                        if (viewResol.TELEFONO == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = limpiarString(viewResol.TELEFONO.Trim());
                            tmp = completarLongitudCadenas(tmp, 15, " ");
                            linea = linea + tmp + ",";
                        }

                        //15. Codigo Ciudad de residencia DIVIPO residencia infractor longitud 8 numerico
                        if (viewResol.ID_DEPTO == null && viewResol.CODCIUDAD == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = getDivisionPolitica(viewResol.ID_DEPTO.Trim(), viewResol.CODCIUDAD.Trim());
                            tmp = limpiarString(tmp);
                            tmp = completarLongitudCadenas(tmp, 8, "0");
                            linea = linea + tmp + ",";
                        }

                        //16. Valor total de la resolucion longitud 8 numerico
                        if (viewResol.VALORINFRACCION == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            //double tmpDouble = double.Parse(viewResol.VALORINFRACCION);
                            //string tmp = completarLongitudCadenas(tmpDouble.ToString(), 8, "0");
                            //linea = linea + tmp + ",";
                            string[] aux = viewResol.VALORINFRACCION.Trim().Split('.', ',');
                            string tmp = limpiarString(aux[0]);
                            tmp = completarLongitudCadenas(tmp, 8, " ");
                            linea = linea + tmp + ",";
                            sumRegistros = sumRegistros + double.Parse(viewResol.VALORINFRACCION);
                        }

                        //17. Valores adicionales longitud 8 numerico
                        linea = linea + "00000000,";

                        //18. Codigo del organismo que reporta(divipo de secretaria) longitud 8 numerico
                        if (transito.ID_CIUDAD <= 0)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            ciudadComp ciudad = new ciudadComp();
                            ciudad.ID_CIUDAD = transito.ID_CIUDAD;
                            ciudad = (ciudadComp)((object[])serviciosAccesoriasComp.getCiudadComp(ciudad))[0];
                            if (ciudad != null && ciudad.ID_CIUDAD > 0)
                            {
                                string tmp = getDivisionPolitica(ciudad.ID_DEPTO.ToString(), ciudad.CODCIUDAD.Trim());
                                tmp = limpiarString(tmp);
                                linea = linea + tmp + ",";
                            }
                            else
                            {
                                linea = linea + ",";
                            }
                        }

                        //19. Comparendos policia de carretera longitud 1 alfanumerico
                        if (viewResol.POLCA == null)
                        {
                            linea = linea + "N,";
                        }
                        else
                        {
                            if (viewResol.POLCA.Equals("Si"))
                            {
                                linea = linea + "S,";
                            }
                            else
                            {
                                linea = linea + "N,";
                            }
                        }

                        //20. Codigo infraccion longitud 5 numerico
                        if (viewResol.NUEVO_CODIGOCORREGIDO == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = limpiarString(viewResol.NUEVO_CODIGOCORREGIDO.Trim());
                            //tmp = completarLongitudCadenas(tmp, 5, "0");
                            linea = linea + tmp + ",";
                        }

                        //21. Valor de la infraccion logitud 8 numerico
                        if (viewResol.VALORINFRACCION == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            //double tmpDouble = double.Parse(viewResol.VALORINFRACCION);
                            //string tmp = completarLongitudCadenas(tmpDouble.ToString(), 8, "0");
                            //linea = linea + tmp + ",";
                            string[] aux = viewResol.VALORINFRACCION.Trim().Split('.', ',');
                            string tmp = limpiarString(aux[0]);
                            tmp = completarLongitudCadenas(tmp, 8, " ");
                            linea = linea + tmp + ",";
                        }

                        //22. Valor a pagar infraccion longitud 8 numerico
                        if (viewResol.VALORINFRACCION != null)
                        {
                            //double tmpDouble = double.Parse(viewResol.VALORINFRACCION);
                            //string tmp = completarLongitudCadenas(tmpDouble.ToString(), 8, "0");
                            //linea = linea + tmp;
                            string[] aux = viewResol.VALORINFRACCION.Trim().Split('.', ',');
                            string tmp = limpiarString(aux[0]);
                            tmp = completarLongitudCadenas(tmp, 8, " ");
                            linea = linea + tmp;
                        }
                        infoResoluciones.WriteLine(linea);
                        infoResoluciones.Close();
                        listadatos.Add(linea);
                        codchequeo = codchequeo + calcularASCIICadena(linea);
                    }
                    infoResoluciones = new StreamWriter(ubicacion + "/" + fileResoluciones, true);
                    //----------------------DATOS FINALES DEL ARCHIVO---------------------------------------------------------------------------------
                    //Numero de registros longitud 5 numerico
                    string tmpfinal = completarLongitudCadenas(numRegistros.ToString(), 5, "0");
                    linea = tmpfinal + ",";

                    //Suma de registros longitud 8 numerico
                    //tmpfinal = completarLongitudCadenas(sumRegistros.ToString(), 8, "0");
                    tmpfinal = sumRegistros.ToString();
                    linea = linea + tmpfinal + ",";

                    //Numero de oficio longitud 10 alfanumerico
                    tmpfinal = completarLongitudCadenas(texNumeroOficio.Text, 10, " ");
                    linea = linea + tmpfinal + ",";

                    //Codigo de cheqeo longitud 4 numerico
                    linea = linea + completarLongitudCadenas(getCodigoChequeo(codchequeo), 4, "0");

                    infoResoluciones.WriteLine(linea);
                    infoResoluciones.Close();
                    if (MessageBox.Show("Desea almacenar las resoluciones sin alcoholemia en la base de datos?", "Pregunta?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string linecompleta = "";
                        for (int i = 0; i < listadatos.Count; i++)
                        {
                            linecompleta = listadatos[i].ToString();
                            linecompleta = linecompleta + linea;
                            almacenarArchivosPlanosResoluciones(linecompleta, planos_Simit.ID);
                        }
                        MessageBox.Show("Registros almacenados con éxito!!", "Información!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron resoluciones sin alcoholemia en esas fechas!!", "Advertencia!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public void setPlanosPago()
        {
            int numRegistros = 0;
            string fec1 = funciones.formatFecha(calFechaIni.SelectionRange.Start.ToString().Remove(10, calFechaIni.SelectionRange.Start.ToString().Length - 10));
            string fec2 = funciones.formatFecha(calFechaFin.SelectionRange.Start.ToString().Remove(10, calFechaFin.SelectionRange.Start.ToString().Length - 10));   
            viewPagosSimit viewPagos = new viewPagosSimit();
            transitoComp transito = new transitoComp();
            planosSimit planos_Simit = new planosSimit();
            double sumRegistros = 0;
            double totalrecuado = 0;
            int tiporecaudo = 0;
            ServiciosViewPagosSimitService mySerPago = WS.ServiciosViewPagosSimitService();
            ServiciosGeneralesCompService mySerGen = WS.ServiciosGeneralesCompService();
            ServiciosGeneralesService serviciosGenerales = WS.ServiciosGeneralesService();
            transito = mySerGen.getTransitoComp(transito);
            object[] listapagos;
            if (busquedaPorNroComparendo)
            {
                viewPagos.NUMEROCOMPARENDO = texNumeroComparendo.Text;
                listapagos = mySerPago.getViewPagosSimit(viewPagos);
            }
            else
            {
                if (cheInfractor.Checked)
                {
                    infractorComp infractor = buscaInfractor(int.Parse(comTipoIdentificacion.SelectedValue.ToString()), texIdentificacion.Text);
                    if (infractor != null)
                    {
                        viewPagos.NROIDENTIFICACION = infractor.NROIDENTIFICACION;
                        listapagos = mySerPago.getPagosSimitPorFechas(viewPagos, fec1, fec2);
                    }
                    else
                    {
                        listapagos = null;
                    }
                }
                else
                {
                    listapagos = mySerPago.getPagosSimitPorFechas(viewPagos, fec1, fec2);
                }
            }
            string linea = "";
            ArrayList lineasPagos = new ArrayList();
            fileRecaudos = transito.NIT + "rec.txt";
            int codchequeo = 0;
            StreamWriter infoPagos;
            if (listapagos != null)
            {
                planos_Simit = new planosSimit();
                planos_Simit.FECHAINIPLANOS = funciones.formatFecha(calFechaIni.SelectionRange.Start.ToString().Remove(10, calFechaIni.SelectionRange.Start.ToString().Length - 10));
                planos_Simit.FECHAFINPLANOS = funciones.formatFecha(calFechaFin.SelectionRange.Start.ToString().Remove(10, calFechaFin.SelectionRange.Start.ToString().Length - 10));
                planos_Simit.FECHAREGISTRO = funciones.formatFecha(serviciosGenerales.getFechaServidor());

                if (datRangos.CurrentRow != null)
                    planos_Simit.ID_RANGOCOMPARENDOS = Convert.ToInt32(datRangos.CurrentRow.Cells["ID_RANGOCOMPARENDO"].Value.ToString());

                planos_Simit.NOMBRECARGA = "Planos de Oficio Numero " + texNumeroOficio.Text + " y Fecha " + planos_Simit.FECHAREGISTRO.ToString();
                planos_Simit.OFICIO = Convert.ToInt32(texNumeroOficio.Text);
                planos_Simit.RUTA = folderBrowserDialog1.SelectedPath;
                planos_Simit = createPlanosSimit(planos_Simit);

                foreach (viewPagosSimit pagos in listapagos)
                {
                    infoPagos = new StreamWriter(ubicacion + "/" + fileRecaudos, true);
                    numRegistros++;
                    //----------------------------linea 1 ENCABEZADO
                    //1. Numero de cuenta que reporta el movimiento longitud 15 alfanumerico
                    linea = linea + ",";

                    //2. Fecha desde para este periodo longitud 10 alfanumerico
                    DateTime fecha = Convert.ToDateTime(calFechaIni.SelectionRange.Start.ToString().Remove(10, calFechaIni.SelectionRange.Start.ToString().Length - 10));
                    string fec = completarLongitudCadenas(fecha.ToString("dd/MM/yyyy"), 15, " ");
                    linea = linea + fec + ",";

                    //3. Fecha hasta el periodo longitud 10 alfanumerico
                    fecha = Convert.ToDateTime(calFechaFin.SelectionRange.Start.ToString().Remove(10, calFechaFin.SelectionRange.Start.ToString().Length - 10));
                    fec = completarLongitudCadenas(fecha.ToString("dd/MM/yyyy"), 15, " ");
                    linea = linea + fec + ",";

                    //4. Codigo divipo de secretaria longitud 8 numerico
                    if (transito.ID_CIUDAD > 0)
                    {
                        ciudadComp ciudad = new ciudadComp();
                        ciudad.ID_CIUDAD = transito.ID_CIUDAD;
                        ciudad = (ciudadComp)((object[])serviciosAccesoriasComp.getCiudadComp(ciudad))[0];
                        if (ciudad != null && ciudad.ID_CIUDAD > 0)
                        {
                            string tmp = getDivisionPolitica(ciudad.ID_DEPTO.ToString(), ciudad.CODCIUDAD.Trim());
                            tmp = limpiarString(tmp);
                            linea = linea + tmp + ",";
                        }
                        else
                        {
                            linea = linea + ",";
                        }
                    }

                    //5. Tipo de recaudo que se hace longitud 1 numerico
                    linea = linea + "1,";

                    ///---------------------------linea 2 DETALLE
                    //1. Consecutivo de registro longitud 5 numerico
                    if (numRegistros > 19999)
                        numRegistros = 1;
                    linea = numRegistros.ToString() + ",";

                    //2. Fecha contable de la transaccion longitud 10 alfanumerico
                    if (pagos.FECHAPAGO == null)
                    {
                        linea = linea + ",";
                    }
                    else
                    {
                        fecha = DateTime.Parse(pagos.FECHAPAGO);
                        string tmp = completarLongitudCadenas(fecha.ToString("dd/MM/yyyy"), 10, " ");
                        linea = linea + tmp + ",";
                    }

                    //3. Hora de transaccion longitud 5 alfanumerico
                    if (pagos.HORAREGISTRO == null)
                    {
                        linea = linea + ",";
                    }
                    else
                    {
                        linea = linea + pagos.HORAREGISTRO + ",";
                    }

                    //4. Fecha Real Transaccion longitud 10 alfanumerico
                    if (pagos.FECHAPAGO == null)
                    {
                        linea = linea + ",";
                    }
                    else
                    {
                        fecha = DateTime.Parse(pagos.FECHAPAGO);
                        string tmp = completarLongitudCadenas(fecha.ToString("dd/MM/yyyy"), 10, " ");
                        linea = linea + tmp + ",";
                    }

                    //5. Codigo canal origen longitud 4 numerico
                    linea = linea + "0,";

                    //6. Descripcion del origen longitud 40 alfanumerico
                    string desc = completarLongitudCadenas("TAQUILLA DE TRANSITO", 40, " ");
                    linea = linea + desc + ",";

                    //7. Total efectivo longitud 12 numerico
                    if (pagos.VALORFORMA < 0 && pagos.ID_TIPOPAGO <= 0)
                    {
                        linea = linea + ",";
                    }
                    else
                    {
                        string tmp;
                        if (pagos.ID_TIPOPAGO == 1)
                        {
                            tmp = limpiarString(pagos.VALORFORMA.ToString());
                            tmp = completarLongitudCadenas(tmp, 12, "0");
                            totalrecuado = pagos.VALORFORMA;
                            linea = linea + tmp + ",";
                        }
                    }

                    //8. Total cheque longitud 12 numerico
                    if (pagos.VALORFORMA < 0 && pagos.ID_TIPOPAGO <= 0)
                    {
                        string tmp;
                        if (pagos.ID_TIPOPAGO == 2)
                        {
                            tmp = limpiarString(pagos.VALORFORMA.ToString());
                            tmp = completarLongitudCadenas(tmp, 12, "0");
                            totalrecuado = totalrecuado + pagos.VALORFORMA;
                            linea = linea + tmp + ",";
                        }
                    }

                    //9. Total recaudo longitud 12 numerico
                    desc = completarLongitudCadenas(totalrecuado.ToString(), 12, "0");
                    linea = linea + desc + ",";

                    //10. Numero de comparendo, resolucion, o liquidacion longitud 15 alfanumerico
                    if (pagos.ID <= 0)
                    {
                        linea = linea + ",";
                    }
                    else
                    {
                        string tmp;
                        resolucionesSimit myResSimit = new resolucionesSimit();
                        myResSimit.IDINFRACCION = pagos.ID;
                        myResSimit = mySerGen.getResolucionSimit(myResSimit);
                        if (myResSimit.NR != null)
                        {
                            tiporecaudo = 3;
                            tmp = limpiarString(myResSimit.NR.Trim());
                            tmp = completarLongitudCadenas(tmp, 15, " ");
                            linea = linea + tmp + ",";
                        }
                        else
                        {
                            tiporecaudo = 1;
                            tmp = limpiarString(pagos.NUMEROCOMPARENDO.Trim());
                            tmp = completarLongitudCadenas(tmp, 15, " ");
                            linea = linea + tmp + ",";
                        }
                    }

                    //11. Comparendo policia de carretera longitud 1 alfanumerico
                    if (pagos.POLCA == null)
                    {
                        linea = linea + "N,";
                    }
                    else
                    {
                        if (pagos.POLCA.Equals("Si"))
                        {
                            linea = linea + "S,";
                        }
                        else
                        {
                            linea = linea + "N,";
                        }
                    }

                    //12. Numero identificacion infractor longitud 15 alfanumerico
                    if (pagos.NROIDENTIFICACION == null)
                    {
                        linea = linea + ",";
                    }
                    else
                    {
                        string tmp = limpiarString(pagos.NROIDENTIFICACION.Trim());
                        tmp = completarLongitudCadenas(tmp, 15, " ");
                        linea = linea + tmp;
                    }

                    //13. Tipo de recaudo longitud 2 numerico
                    if (pagos.ID <= 0)
                    {
                        linea = linea + ",";
                    }
                    else
                    {
                        linea = linea + tiporecaudo.ToString() + ",";
                    }

                    //14. Codigo divipo de la secretaria longitud 8 alfanumerico
                    if (transito.NIT == null)
                    {
                        linea = linea + ",";
                    }
                    else
                    {
                        string tmp = limpiarString(transito.NIT.Trim());
                        tmp = completarLongitudCadenas(tmp, 8, " ");
                        linea = linea + transito.NIT;
                    }

                    //15. Numero de consignacion longitud 15 alfanumerico
                    if (pagos.NROCONSIGNACIONBANCO != null)
                    {
                        string tmp = limpiarString(pagos.NROCONSIGNACIONBANCO.Trim());
                        tmp = completarLongitudCadenas(tmp, 15, " ");
                        linea = linea + pagos.NROCONSIGNACIONBANCO;
                    }
                    infoPagos.WriteLine(linea);
                    infoPagos.Close();
                    lineasPagos.Add(linea);
                    codchequeo = codchequeo + calcularASCIICadena(linea);
                }
                infoPagos = new StreamWriter(ubicacion + "/" + fileRecaudos, true);
                //----------------------DATOS FINALES DEL ARCHIVO---------------------------------------------------------------------------------
                //Numero de registros longitud 5 numerico
                string tmpfinal = completarLongitudCadenas(numRegistros.ToString(), 5, "0");
                linea = tmpfinal + ",";

                //Suma de registros longitud 8 numerico
                //tmpfinal = completarLongitudCadenas(sumRegistros.ToString(), 8, "0");
                tmpfinal = sumRegistros.ToString();
                linea = linea + tmpfinal + ",";

                //Numero de oficio longitud 10 alfanumerico
                tmpfinal = completarLongitudCadenas(texNumeroOficio.Text, 10, " ");
                linea = linea + tmpfinal + ",";

                //Codigo de cheqeo longitud 4 numerico
                linea = linea + completarLongitudCadenas(getCodigoChequeo(codchequeo), 4, "0");

                infoPagos.WriteLine(linea);
                infoPagos.Close();
                if (MessageBox.Show("Desea almacenar los recaudos en la base de datos?", "Pregunta?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string linecompleta = "";
                    for (int i = 0; i < lineasPagos.Count; i++)
                    {
                        linecompleta = lineasPagos[i].ToString();
                        linecompleta = linecompleta + linea;
                        almacenarArchivosPlanosRecaudo(linecompleta, planos_Simit.ID);
                    }
                    MessageBox.Show("Registros almacenados con éxito!!", "Información!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No se tienen pagos registrados!", "Advertencia!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public string completarLongitudCadenas(string texto, int longitud, string caracter)
        {
            string nuevacadena = "";
            texto = texto.Trim();
            int diferencia = 0;
            if (texto.Length < longitud)
            {
                nuevacadena = texto;
                //COMENTADO PARA QUE NO COMPLETE LAS CADENAS CON ESPACIOS O NUMEROS SEGUN SEA EL CASO
                /*diferencia = longitud - texto.Length;
                if (caracter.Equals(" "))
                {
                    for (int i = 0; i < diferencia; i++)
                    {
                        nuevacadena = nuevacadena + caracter;
                    }
                }
                else
                {
                    for (int i = 0; i < diferencia; i++)
                    {
                        nuevacadena = caracter + nuevacadena;
                    }
                }*/
            }
            if (texto.Length == longitud)
            {
                nuevacadena = texto;
            }
            if (texto.Length > longitud)
            {
                nuevacadena = texto.Remove(longitud, texto.Length - longitud);
            }
            return nuevacadena;
        }

        private void butPorcentajeCargado_Click(object sender, EventArgs e)
        {
            try
            {
                int totalcompcargadosasignacion = 0;
                int cantidadcompasignacion = 0;
                float porcentaje = 0;
                DataTable dt = (DataTable)datRangos.DataSource;
                int indice = datRangos.SelectedRows[0].Index;
                cantidadcompasignacion = int.Parse(dt.Rows[indice]["CANTIDADRANGOS"].ToString());
                bool tmp = true;
                comparendosCargaAlSimit compcarga = new comparendosCargaAlSimit();
                comparenderas myComparendera = new comparenderas();
                myComparendera.ID_RANGOCOMPARENDOS = int.Parse(dt.Rows[indice]["ID_RANGOCOMPARENDO"].ToString());
                ServiciosComparendosService mySerComp = WS.ServiciosComparendosService();
                object[] listaComparenderas = mySerComp.getSComparenderas(myComparendera);
                if (listaComparenderas != null)
                {
                    myComparendera = (comparenderas)listaComparenderas[0];
                }
                if (myComparendera != null && myComparendera.ID_RANGOCOMPARENDOS > 0)
                {
                    comparendoComp myComparendo = new comparendoComp();
                    myComparendo.IDCOMPARENDERA = myComparendera.ID;
                    ServiciosGeneralesCompService mySerGenComp = WS.ServiciosGeneralesCompService();
                    object[] listaComparendo = mySerGenComp.searchComparendo(myComparendo);
                    if (listaComparendo != null)
                    {
                        myComparendo = (comparendoComp)listaComparendo[0];
                        compcarga.ID_COMPARENDO = myComparendo.ID_COMPARENDO;
                    }
                }
                ServiciosComparendosCargaSimitService mySerCarga = WS.ServiciosComparendosCargaSimitService();
                mySerCarga.getCantidadArchivosAprobadosPorCarga(compcarga, out totalcompcargadosasignacion, out tmp);
                if (cantidadcompasignacion > 0)
                {
                    porcentaje = (totalcompcargadosasignacion * 100) / cantidadcompasignacion;
                }
                labPorcentaje.Text = porcentaje.ToString() + "%";
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
            }
        }

        private bool setPlanoComparendosFaltantes()
        {
            String nombresApellidos;
            int numRegistros = 0;
            double sumRegistros = 0;
            StreamWriter infoTramites;
            Object[] lista;
            bool resultado = false;
            ServiciosViewCompFaltantesCargaService serviciosViewComparendosFaltanCarga;
            viewCompFaltantesCarga viewCompFaltantesCarga;
            transitoComp transito = new transitoComp();
            ServiciosGeneralesCompService serviciosGeneralesComp = WS.ServiciosGeneralesCompService();
            transito.NIT = serviciosGeneralesComp.getNitTransitoComp();
            transito.ID_CIUDAD = serviciosGeneralesComp.getCiudadTransitoComp();
            String linea;
            int codchequeo = 0;
            fileComparendos = transito.NIT + "comp.txt";
            if (cheComparendos2.Checked)
            {
                viewCompFaltantesCarga = new viewCompFaltantesCarga();
                serviciosViewComparendosFaltanCarga = WS.ServiciosViewCompFaltantesCargaService();
                if (busquedaPorNroComparendo)
                {
                    viewCompFaltantesCarga.NUMEROCOMPARENDO = texNumeroComparendo2.Text;
                    lista = serviciosViewComparendosFaltanCarga.getViewCompFaltantesCarga(viewCompFaltantesCarga);
                }
                if (cheComparendos2.Checked)
                {
                    if (chkComparendosPagadosCarga.Checked)
                    {
                        if (cheInfractor2.Checked)
                        {
                            infractorComp infractor = buscaInfractor(int.Parse(comTipoDocumento2.SelectedValue.ToString()), texIdentificacion2.Text);
                            if (infractor != null)
                            {
                                viewCompFaltantesCarga.ID_INFRACTOR = infractor.ID_INFRACTOR;
                                lista = (Object[])serviciosViewComparendosFaltanCarga.getViewCompFaltantesCarga(viewCompFaltantesCarga);
                            }
                            else
                            {
                                lista = null;
                            }
                        }
                        else
                        {
                            lista = (Object[])serviciosViewComparendosFaltanCarga.getViewCompFaltantesCarga(viewCompFaltantesCarga);
                        }
                    }
                    else
                    {
                        lista = (Object[])serviciosViewComparendosFaltanCarga.getViewCompFaltantesCarga(viewCompFaltantesCarga);
                        //lista = (Object[])serviciosViewComparendosFaltanCarga.get(viewCompPorFechas, fec1, fec2);
                    }
                    if (lista != null)
                    {
                        resultado = true;

                        foreach (viewCompFaltantesCarga viewCompFaltantesTmp in lista)
                        {
                            infoTramites = new StreamWriter(ubicacion + "/" + fileComparendos, true);
                            numRegistros++;

                            //1. Consecutivo longitud 5 numerico
                            if (numRegistros > 19999)
                                numRegistros = 1;
                            linea = numRegistros.ToString() + ",";

                            //2. Numero de Comparendo longitud 20 alfanumerico
                            if (viewCompFaltantesTmp.NUMEROCOMPARENDO == null)
                                linea = linea + ",";
                            else
                            {
                                string tmp = limpiarString(viewCompFaltantesTmp.NUMEROCOMPARENDO.Trim());
                                tmp = completarLongitudCadenas(tmp, 20, " ");
                                linea = linea + tmp + ",";
                            }

                            //3. Fecha del comparendo longitud 10 alfanumerico
                            if (viewCompFaltantesTmp.FECHACOMPARENDO == null)
                                linea = linea + ",";
                            else
                            {
                                //viewCompPorFechasTmp.FECHACOMPARENDO = viewCompPorFechasTmp.FECHACOMPARENDO.Replace("-", "/");
                                DateTime fecha = DateTime.Parse(viewCompFaltantesTmp.FECHACOMPARENDO);
                                string tmp = completarLongitudCadenas(fecha.ToString("dd/MM/yyyy"), 10, " ");
                                linea = linea + tmp + ",";
                            }

                            //4. Hora del comparendo longitud 4  hhmm  militar numerico
                            if (viewCompFaltantesTmp.HORACOMPARENDO == null)
                                linea = linea + ",";
                            else
                            {
                                if (viewCompFaltantesTmp.HORACOMPARENDO.Length <= 8)
                                    linea = linea + funciones.formatoHora(viewCompFaltantesTmp.HORACOMPARENDO).Trim() + ",";
                                else
                                    linea = linea + funciones.formatoHora(viewCompFaltantesTmp.HORACOMPARENDO.Remove(5, viewCompFaltantesTmp.HORACOMPARENDO.Length - 5)).Trim() + ",";
                            }

                            //5. Direccion de la infraccion longitud 80 alfanumerico
                            if (viewCompFaltantesTmp.DIRECCIONINFRACCION == null)
                                linea = linea + ",";
                            else
                            {
                                string tmp = limpiarString(viewCompFaltantesTmp.DIRECCIONINFRACCION);
                                tmp = completarLongitudCadenas(tmp, 80, " ");
                                linea = linea + tmp + ",";
                            }

                            //6. Divipo municipio longitud 8 alfanumerico
                            if (viewCompFaltantesTmp.CODCIUDAD == null && viewCompFaltantesTmp.ID_DEPTO == null)
                                linea = linea + ",";
                            else
                            {
                                string divipo = getDivisionPolitica(viewCompFaltantesTmp.ID_DEPTO.Trim(), viewCompFaltantesTmp.CODCIUDAD.Trim());
                                divipo = limpiarString(divipo);
                                divipo = completarLongitudCadenas(divipo, 8, " ");
                                linea = linea + divipo + ",";
                            }

                            //7. Localidad o comuna longitud 30 alfanumerico
                            if (viewCompFaltantesTmp.LOCALIDAD_COMUNADIRECCION == null)
                                linea = linea + ",";
                            else
                            {
                                string tmp = limpiarString(viewCompFaltantesTmp.LOCALIDAD_COMUNADIRECCION.Trim());
                                tmp = completarLongitudCadenas(tmp, 30, " ");
                                linea = linea + tmp + ",";
                            }

                            //8. Placa del vehiculo longitud 6 alfanumerico
                            if (viewCompFaltantesTmp.PLACA == null)
                                linea = linea + ",";
                            else
                            {
                                string tmp = limpiarString(viewCompFaltantesTmp.PLACA.Trim());
                                tmp = completarLongitudCadenas(tmp, 6, " ");
                                linea = linea + tmp + ",";
                            }

                            //-------------------------- VEHICULO COMPARENDO --------------------------------------------------------                            
                            ServiciosViewVehiculoComparendoService serviciosViewVehiculoComparendo = WS.ServiciosViewVehiculoComparendoService();
                            viewVehiculoComparendo vehiculoComparendo = new viewVehiculoComparendo();
                            Object[] vehiculosComparendo;
                            vehiculoComparendo.PLACA = viewCompFaltantesTmp.PLACA;
                            vehiculosComparendo = (Object[])serviciosViewVehiculoComparendo.getViewVehiculoComparendo(vehiculoComparendo);

                            if (vehiculosComparendo != null)
                            {
                                vehiculoComparendo = (viewVehiculoComparendo)vehiculosComparendo[0];
                                //9. Municipio de la Placa longitud 8 alfanumerico
                                if (vehiculoComparendo.NITMATRICULA == null)
                                    linea = linea + "00000000,";
                                else
                                {
                                    string tmp = limpiarString(vehiculoComparendo.NITMATRICULA.Trim());
                                    tmp = completarLongitudCadenas(tmp, 8, " ");
                                    linea = linea + tmp + ",";
                                }

                                //10. Clase de vehiculo longitud 2 numerico
                                if (vehiculoComparendo.ID_CVEHICULO == 0)
                                    linea = linea + ",";
                                else
                                {
                                    string tmp = completarLongitudCadenas(vehiculoComparendo.ID_CVEHICULO.ToString(), 2, "0");
                                    linea = linea + tmp + ",";
                                }

                                //11. Tipo de Servicio longitud 1 numerico
                                if (vehiculoComparendo.ID_SERVICIO <= 0)
                                    linea = linea + ",";
                                else
                                {
                                    string tmp = completarLongitudCadenas(vehiculoComparendo.ID_SERVICIO.ToString(), 1, "0");
                                    linea = linea + tmp + ",";
                                }

                                //12. Radio de accion longitud 1 numerico
                                if (vehiculoComparendo.COD_RADIOACCION == null)
                                    linea = linea + ",";
                                else
                                {
                                    string tmp = limpiarString(vehiculoComparendo.COD_RADIOACCION.Trim());
                                    tmp = completarLongitudCadenas(tmp, 1, "0");
                                    linea = linea + tmp + ",";
                                }

                                //13. Modalidad de trasnporte longitud 1 numerico
                                if (vehiculoComparendo.COD_MODTRANSPORTE == null)
                                    linea = linea + ",";
                                else
                                {
                                    string tmp = completarLongitudCadenas(vehiculoComparendo.COD_MODTRANSPORTE.Trim(), 1, "0");
                                    linea = linea + tmp + ",";
                                }

                                //14. Código transporte pasajeros longitud 1 numerico
                                if (vehiculoComparendo.COD_TIPOTRANSPORTE == null)
                                    linea = linea + ",";
                                else
                                {
                                    string tmp = completarLongitudCadenas(vehiculoComparendo.COD_TIPOTRANSPORTE.Trim(), 1, "0");
                                    linea = linea + tmp + ",";
                                }
                            }
                            else
                                linea = linea + "," + "," + "," + "," + "," + ",";

                            //-------------------------- INFRACTOR ------------------------------------------------------------------
                            infractorComp infractor = new infractorComp();
                            infractor.ID_INFRACTOR = viewCompFaltantesTmp.ID_INFRACTOR;
                            infractor = serviciosGeneralesComp.buscarInfractor(infractor);
                            viewInfractorComparendo infrac = new viewInfractorComparendo();
                            infrac.ID_INFRACTOR = viewCompFaltantesTmp.ID_INFRACTOR.ToString();
                            ServiciosViewInfractorComparendoService mySerViewCom = WS.ServiciosViewInfractorComparendoService();
                            infrac = (viewInfractorComparendo)((object[])mySerViewCom.getViewInfractorComparendo(infrac))[0];

                            //15. Identificacion del infractor longitud 15 numerico
                            if (infractor.NROIDENTIFICACION == null)
                                linea = linea + ",";
                            else
                            {
                                string tmp = limpiarString(infractor.NROIDENTIFICACION.Trim());
                                tmp = completarLongitudCadenas(tmp, 15, "0");
                                linea = linea + tmp.Trim() + ",";
                            }

                            //16. Tipo documento infractor longitud 1 numerico
                            if (viewCompFaltantesTmp.IDREPORTECOMPARENDO == 0)
                                linea = linea + ",";
                            else
                            {
                                string tmp = completarLongitudCadenas(viewCompFaltantesTmp.IDREPORTECOMPARENDO.ToString(), 1, "0");
                                linea = linea + tmp + ",";
                            }

                            //17. Nombres infractor longitud 18 alfanumerico
                            if (infractor.NOMBRES == null)
                                linea = linea + ",";
                            else
                            {
                                string tmp = limpiarString(infractor.NOMBRES);
                                tmp = completarLongitudCadenas(tmp, 18, " ");
                                linea = linea + tmp + ",";
                            }

                            //18. Apellidos infractor longitud 20 alfanumerico
                            if (infractor.APELLIDOS == null)
                                linea = linea + ",";
                            else
                            {
                                string tmp = limpiarString(infractor.APELLIDOS);
                                tmp = completarLongitudCadenas(tmp, 20, " ");
                                linea = linea + tmp + ",";
                            }

                            //19. Edad infractor longitud 2 numerico
                            if (infractor.EDAD == null)
                                linea = linea + ",";
                            else
                            {
                                string tmp = limpiarString(infractor.EDAD.Trim());
                                tmp = completarLongitudCadenas(tmp, 2, "0");
                                linea = linea + tmp + ",";
                            }

                            //20. Direccion infractor longitud 40 alfanumerico
                            if (infractor.DIRECCION == null)
                                linea = linea + ",";
                            else
                            {
                                string tmp = limpiarString(infractor.DIRECCION);
                                tmp = completarLongitudCadenas(tmp, 40, " ");
                                linea = linea + tmp + ",";
                            }

                            //21. Correo electronico infractor longitud 20 alfanumerico
                            if (infractor.EMAIL == null)
                                linea = linea + ",";
                            else
                            {
                                string tmp = limpiarString(infractor.EMAIL.Trim());
                                tmp = completarLongitudCadenas(tmp, 20, " ");
                                linea = linea + tmp + ",";
                            }

                            //22. Telefono infractor longitud 15 alfanumerico
                            if (infractor.TELEFONO == null)
                                linea = linea + ",";
                            else
                            {
                                string tmp = limpiarString(infractor.TELEFONO.Trim());
                                tmp = completarLongitudCadenas(tmp, 15, " ");
                                linea = linea + tmp + ",";
                            }

                            //23. Ciudad residencia infractor longitud 8 numerico
                            if (infractor.ID_CIUDAD <= 0)
                                linea = linea + ",";
                            else
                            {
                                Object[] ciudades;
                                ciudadComp ciudad = new ciudadComp();
                                ServiciosAccesoriasCompService serviciosAccesoriasComp = WS.ServiciosAccesoriasCompService();
                                ciudad.ID_CIUDAD = infractor.ID_CIUDAD;
                                ciudades = (Object[])serviciosAccesoriasComp.getCiudadComp(ciudad);
                                if (ciudades == null)
                                    linea = linea + ",";
                                else
                                {
                                    ciudad = (ciudadComp)ciudades[0];
                                    if (ciudad.CODCIUDAD == null)
                                        linea = linea + ",";
                                    else
                                    {
                                        string tmp = getDivisionPolitica(ciudad.ID_DEPTO.ToString(), ciudad.CODCIUDAD.Trim());
                                        tmp = completarLongitudCadenas(tmp, 8, "0");
                                        linea = linea + tmp + ",";
                                    }
                                }
                            }

                            //24. No. licencia de conduccion longitud 14 alfanumerico
                            if (infractor.NROLICCONDUCCION == null)
                                linea = linea + ",";
                            else
                            {
                                string tmp = limpiarString(infractor.NROLICCONDUCCION.Trim());
                                tmp = completarLongitudCadenas(tmp, 14, " ");
                                linea = linea + tmp + ",";
                            }

                            //25. Categoria Licencia de conduccion longitud 2 alfanumerico
                            if (infrac.NUEVA_CATEGORIA == null)
                            {
                                linea = linea + ",";
                            }
                            else
                            {
                                string tmp = limpiarString(infrac.NUEVA_CATEGORIA.Trim());
                                tmp = completarLongitudCadenas(tmp, 2, " ");
                                linea = linea + tmp + ",";
                            }

                            //26. Organismo Expide lic de conduccion longitud 8 alfanumerico
                            if (infractor.ID_TRANSITO <= 0)
                            {
                                linea = linea + ",";
                            }
                            else
                            {
                                transito.ID_TRANSITO = infractor.ID_TRANSITO;
                                ServiciosGeneralesCompService mySerGen = WS.ServiciosGeneralesCompService();
                                transito = mySerGen.getTransitoComp(transito);
                                if (transito.ID_CIUDAD <= 0)
                                {
                                    linea = linea + ",";
                                }
                                else
                                {
                                    ciudadComp ciudadtmp = new ciudadComp();
                                    ciudadtmp.ID_CIUDAD = transito.ID_CIUDAD;
                                    ciudadtmp = (ciudadComp)((object[])serviciosAccesoriasComp.getCiudadComp(ciudadtmp))[0];
                                    if (ciudadtmp.CODCIUDAD == null && ciudadtmp.ID_DEPTO <= 0)
                                    {
                                        linea = linea + ",";
                                    }
                                    else
                                    {
                                        string tmp = getDivisionPolitica(ciudadtmp.ID_DEPTO.ToString().Trim(), ciudadtmp.CODCIUDAD.Trim());
                                        tmp = completarLongitudCadenas(tmp, 8, " ");
                                        linea = linea + tmp + ",";
                                    }
                                }
                            }

                            //27. fecha vencimiento lic longitud 10 numerico
                            if (infractor.FECHAVENCELICCONDUCCION == null)
                                linea = linea + ",";
                            else
                            {
                                if (infractor.FECHAVENCELICCONDUCCION.Length <= 10)
                                    linea = linea + funciones.formatFecha(infractor.FECHAVENCELICCONDUCCION).Trim() + ",";
                                else
                                    linea = linea + funciones.formatFecha(infractor.FECHAVENCELICCONDUCCION.Remove(10, infractor.FECHAVENCELICCONDUCCION.Length - 10)).Trim() + ",";
                            }

                            //28. Tipo de infractor longitud 1 numerico
                            if (viewCompFaltantesTmp.CODTIPOINFRACTOR == null)
                                linea = linea + ",";
                            else
                            {
                                string tmp = limpiarString(viewCompFaltantesTmp.CODTIPOINFRACTOR.Trim());
                                tmp = completarLongitudCadenas(tmp, 1, "0");
                                linea = linea + tmp + ",";
                            }

                            //29. No. Licencia de transito longitud 16 alfanumerico
                            if (vehiculoComparendo.NROLICENCIA == null)
                                linea = linea + ",";
                            else
                            {
                                string tmp = limpiarString(vehiculoComparendo.NROLICENCIA.Trim());
                                tmp = completarLongitudCadenas(tmp, 16, " ");
                                linea = linea + tmp + ",";
                            }

                            //30. Divipo lic transito longitud 8 alfanumerico
                            if (vehiculoComparendo.NITMATRICULA == null)
                            {
                                linea = linea + ",";
                            }
                            else
                            {
                                string tmp = limpiarString(vehiculoComparendo.NITMATRICULA.Trim());
                                tmp = completarLongitudCadenas(tmp, 8, " ");
                                linea = linea + tmp + ",";
                            }

                            //-------------------------- IDENTIFICACION PROPIETARIO -------------------------------------------------
                            ServiciosViewPropVehiculoComparendoService serviciosViewPropVehiculoComparendo = WS.ServiciosViewPropVehiculoComparendoService();
                            viewPropVehiculoComparendo propietarioVehiculoComparendo = new viewPropVehiculoComparendo();
                            Object[] propietarios;
                            propietarioVehiculoComparendo.ID_COMPARENDO = viewCompFaltantesTmp.ID_COMPARENDO.ToString();
                            propietarios = (Object[])serviciosViewPropVehiculoComparendo.getViewPropVehiculoComparendo(propietarioVehiculoComparendo);
                            if (propietarios == null)
                                linea = linea + "," + "," + "," + "," + "," + "," + "," + "," + "," + "," + "," + "," + "," + ",";
                            else
                            {
                                propietarioVehiculoComparendo = (viewPropVehiculoComparendo)propietarios[0];

                                //31. Identificacion propietario longitud 8 alfanumerico
                                if (propietarioVehiculoComparendo.NROIDENTIFICACION == null)
                                    linea = linea + ",";
                                else
                                {
                                    string tmp = limpiarString(propietarioVehiculoComparendo.NROIDENTIFICACION.Trim());
                                    tmp = completarLongitudCadenas(tmp, 8, " ");
                                    linea = linea + tmp + ",";
                                }

                                //32. Tipo de documento propietario longitud 1 numerico
                                if (propietarioVehiculoComparendo.IDREPORTECOMPARENDO == null)
                                    linea = linea + ",";
                                else
                                {
                                    string tmp = limpiarString(propietarioVehiculoComparendo.IDREPORTECOMPARENDO.Trim());
                                    tmp = completarLongitudCadenas(tmp, 1, "0");
                                    linea = linea + tmp + ",";
                                }

                                //33. Nombres y Apellidos propietario longitud 50 alfanumerico
                                if ((propietarioVehiculoComparendo.NOMBRES == null) && (propietarioVehiculoComparendo.APELLIDOS == null))
                                    linea = linea + ",";
                                else
                                {
                                    string tmp1 = limpiarString(propietarioVehiculoComparendo.NOMBRES);
                                    string tmp2 = limpiarString(propietarioVehiculoComparendo.APELLIDOS);
                                    nombresApellidos = tmp1 + " " + tmp2;
                                    nombresApellidos = completarLongitudCadenas(nombresApellidos, 49, " ");
                                    linea = linea + nombresApellidos + ",";
                                }

                                //-------------------------EMPRESA EN CASO DE VEHICULO DE SERVICIO PUBLICO------------------------------------------------------------------------------
                                //34. Empresa longitu 30 alfanumerico
                                if (vehiculoComparendo.RAZONSOCIAL == null)
                                {
                                    linea = linea + ",";
                                }
                                else
                                {
                                    string tmp = limpiarString(vehiculoComparendo.RAZONSOCIAL);
                                    tmp = completarLongitudCadenas(tmp, 30, " ");
                                    linea = linea + tmp + ",";
                                }

                                //35. Nit Empresa longitud 15 alfanumerico
                                if (vehiculoComparendo.NIT == null)
                                {
                                    linea = linea + ",";
                                }
                                else
                                {
                                    string tmp = limpiarString(vehiculoComparendo.NIT.Trim());
                                    tmp = completarLongitudCadenas(tmp, 15, " ");
                                    linea = linea + tmp + ",";
                                }

                                //36. Tarjeta de operacion longitud 10 alfanumerico
                                if (vehiculoComparendo.TARJETAOPERACION == null)
                                    linea = linea + ",";
                                else
                                {
                                    string tmp = limpiarString(vehiculoComparendo.TARJETAOPERACION.Trim());
                                    tmp = completarLongitudCadenas(tmp, 10, " ");
                                    linea = linea + tmp + ",";
                                }

                                //-----------------------------DATOS AGENTE--------------------------------------------------------------------------
                                //37. Numero de la placa del agente longitud 10 alfanumerico
                                if (viewCompFaltantesTmp.PLACAAGENTE == null)
                                    linea = linea + ",";
                                else
                                {
                                    string tmp = limpiarString(viewCompFaltantesTmp.PLACAAGENTE.Trim());
                                    tmp = completarLongitudCadenas(tmp, 10, " ");
                                    linea = linea + tmp + ",";
                                }

                                //38. Observaciones comparendo longitud 50 alfanumerico
                                if (viewCompFaltantesTmp.OBSERVACION == null)
                                    linea = linea + ",";
                                else
                                {
                                    string tmp = limpiarString(viewCompFaltantesTmp.OBSERVACION);
                                    tmp = completarLongitudCadenas(tmp, 50, " ");
                                    linea = linea + tmp + ",";
                                }

                                //39. Reporta fuga longitud 1 alfanumerico
                                if (viewCompFaltantesTmp.REPORTAFUGA == null)
                                    linea = linea + "N,";
                                else
                                {
                                    if (viewCompFaltantesTmp.REPORTAFUGA.Equals("S") || viewCompFaltantesTmp.REPORTAFUGA.Equals("N"))
                                    {
                                        if (viewCompFaltantesTmp.REPORTAFUGA.Length <= 1)
                                            linea = linea + viewCompFaltantesTmp.REPORTAFUGA.Trim() + ",";
                                        else
                                            linea = linea + viewCompFaltantesTmp.REPORTAFUGA.Remove(1, viewCompFaltantesTmp.REPORTAFUGA.Length - 1).Trim() + ",";
                                    }
                                    else
                                    {
                                        linea = linea + "N,";
                                    }
                                }

                                //40. Reporta accidente longitud 1 alfanumerico
                                if (viewCompFaltantesTmp.REPORTAACCIDENTE == null)
                                    linea = linea + "N,";
                                else
                                {
                                    if (viewCompFaltantesTmp.REPORTAACCIDENTE.Equals("S") || viewCompFaltantesTmp.REPORTAACCIDENTE.Equals("N"))
                                    {
                                        if (viewCompFaltantesTmp.REPORTAACCIDENTE.Length <= 1)
                                            linea = linea + viewCompFaltantesTmp.REPORTAACCIDENTE.Trim() + ",";
                                        else
                                            linea = linea + viewCompFaltantesTmp.REPORTAACCIDENTE.Remove(1, viewCompFaltantesTmp.REPORTAACCIDENTE.Length - 1).Trim() + ",";
                                    }
                                    else
                                    {
                                        linea = linea + "N,";
                                    }
                                }

                                //41. Reporta inmovilizacion longitud 1 alfanumerico
                                if (viewCompFaltantesTmp.REPORTAINMOVILIZACION == null)
                                    linea = linea + "N,";
                                else
                                {
                                    if (viewCompFaltantesTmp.REPORTAINMOVILIZACION.Equals("S") || viewCompFaltantesTmp.REPORTAINMOVILIZACION.Equals("N"))
                                    {
                                        if (viewCompFaltantesTmp.REPORTAINMOVILIZACION.Length <= 1)
                                            linea = linea + viewCompFaltantesTmp.REPORTAINMOVILIZACION.Trim() + ",";
                                        else
                                            linea = linea + viewCompFaltantesTmp.REPORTAINMOVILIZACION.Remove(1, viewCompFaltantesTmp.REPORTAINMOVILIZACION.Length - 1).Trim() + ",";
                                    }
                                    else
                                    {
                                        linea = linea + "N,";
                                    }
                                }

                                //42. Patio inmoviliza longitud 30 alfanumerico
                                if (viewCompFaltantesTmp.DESCRIPCIONPATIO == null)
                                    linea = linea + ",";
                                else
                                {
                                    string tmp = limpiarString(viewCompFaltantesTmp.DESCRIPCIONPATIO);
                                    tmp = completarLongitudCadenas(tmp, 29, " ");
                                    linea = linea + tmp + ",";
                                }

                                //43. Direccion patio inmovilizacion longitud 30 alfanumerico
                                if (viewCompFaltantesTmp.DIRECCIONPATIO_INMOVILIZA == null)
                                    linea = linea + ",";
                                else
                                {
                                    string tmp = limpiarString(viewCompFaltantesTmp.DIRECCIONPATIO_INMOVILIZA);
                                    tmp = completarLongitudCadenas(tmp, 30, " ");
                                    linea = linea + tmp + ",";
                                }

                                //44. No. Grua longitud 10 alfanumerico
                                if (viewCompFaltantesTmp.NUMEROGRUA == null)
                                    linea = linea + ",";
                                else
                                {
                                    string tmp = limpiarString(viewCompFaltantesTmp.NUMEROGRUA.Trim());
                                    tmp = completarLongitudCadenas(tmp, 10, " ");
                                    linea = linea + tmp + ",";
                                }

                                //45. Placa Grua longitud 6 alfanumerico
                                if (viewCompFaltantesTmp.PLACAGRUA == null)
                                    linea = linea + ",";
                                else
                                {
                                    string tmp = limpiarString(viewCompFaltantesTmp.PLACAGRUA.Trim());
                                    tmp = completarLongitudCadenas(tmp, 6, " ");
                                    linea = linea + tmp + ",";
                                }

                                //46. Consecutivo inmovilización longitud 15 numerico
                                if (viewCompFaltantesTmp.CONSECUTIVOINMOVILIZACION == null)
                                    linea = linea + ",";
                                else
                                {
                                    if (viewCompFaltantesTmp.CONSECUTIVOINMOVILIZACION.Length <= 15)
                                        linea = linea + viewCompFaltantesTmp.CONSECUTIVOINMOVILIZACION.Trim() + ",";
                                    else
                                        linea = linea + viewCompFaltantesTmp.CONSECUTIVOINMOVILIZACION.Remove(15, viewCompFaltantesTmp.CONSECUTIVOINMOVILIZACION.Length - 15).Trim() + ",";
                                }

                                //-------------------------- TESTIGO --------------------------------------------------------------------
                                // ServiciosGeneralesCompService serviciosGeneralesComp = WS.ServiciosGeneralesCompService();
                                testigoComp testigo = new testigoComp();
                                testigo.ID_COMPARENDO = viewCompFaltantesTmp.ID_COMPARENDO;
                                testigo = serviciosGeneralesComp.getTestigo(testigo);

                                //47. Identificación del testigo 15 alfanumerico
                                if (testigo.NROIDENTIFICACION == null)
                                    linea = linea + ",";
                                else
                                {
                                    string tmp = limpiarString(testigo.NROIDENTIFICACION.Trim());
                                    tmp = completarLongitudCadenas(tmp, 15, " ");
                                    linea = linea + tmp + ",";
                                }

                                //48. Nombres y apellidos testigo longitud 50 alfanumerico
                                if ((testigo.NOMBRES == null) && (testigo.APELLIDOS == null))
                                    linea = linea + ",";
                                else
                                {
                                    string tmp1 = limpiarString(testigo.NOMBRES);
                                    string tmp2 = limpiarString(testigo.APELLIDOS);
                                    nombresApellidos = tmp1 + " " + tmp2;
                                    nombresApellidos = completarLongitudCadenas(nombresApellidos, 50, " ");
                                    linea = linea + nombresApellidos.Trim() + ",";
                                }

                                //49. Direccion testigo longitud 40 alfanumerico
                                if (testigo.DIRECCION == null)
                                    linea = linea + ",";
                                else
                                {
                                    string tmp = limpiarString(testigo.DIRECCION);
                                    tmp = completarLongitudCadenas(tmp, 40, " ");
                                    linea = linea + tmp + ",";
                                }

                                //50. Teléfono del testigo longitud 15 alfanumerico
                                if (testigo.NROTELEFONO == null)
                                    linea = linea + ",";
                                else
                                {
                                    string tmp = limpiarString(testigo.NROTELEFONO.Trim());
                                    tmp = completarLongitudCadenas(tmp, 15, " ");
                                    linea = linea + tmp + ",";
                                }

                                //51. Valor comparendo longitud 8 numerico
                                if (viewCompFaltantesTmp.VALORINFRACCION == null)
                                    linea = linea + ",";
                                else
                                {
                                    double tmpDouble = double.Parse(viewCompFaltantesTmp.VALORINFRACCION.Trim());
                                    string tmp = limpiarString(tmpDouble.ToString());
                                    tmp = completarLongitudCadenas(tmp, 8, "0");
                                    linea = linea + tmp + ",";
                                    sumRegistros = sumRegistros + double.Parse(viewCompFaltantesTmp.VALORINFRACCION.Trim());
                                }

                                //52. Valores adicionales longitud 8 numerico
                                linea = linea + "0,";

                                //53. Codigo organismo que reporta longitud 8 numerico
                                if (transito.ID_TRANSITO <= 0)
                                    linea = linea + ",";
                                else
                                {
                                    ciudadComp ciudad = new ciudadComp();
                                    Object[] ciudades;
                                    ciudad.ID_CIUDAD = transito.ID_CIUDAD;
                                    ciudades = serviciosAccesoriasComp.getCiudadComp(ciudad);
                                    if (ciudades == null)
                                        linea = linea + ",";
                                    else
                                    {
                                        ciudad = (ciudadComp)ciudades[0];
                                        if (ciudad.CODCIUDAD == null && ciudad.ID_DEPTO <= 0)
                                            linea = linea + ",";
                                        else
                                        {
                                            string divipo = getDivisionPolitica(ciudad.ID_DEPTO.ToString().Trim(), ciudad.CODCIUDAD.Trim());
                                            divipo = completarLongitudCadenas(divipo, 8, "0");
                                            linea = linea + divipo + ",";
                                        }
                                    }
                                }

                                //54. Estado del comparendo longitud 1 numerico
                                linea = linea + "1,";

                                //55. Policia de carreteras longitud 1 alfanumerico
                                if (viewCompFaltantesTmp.POLCA == null || viewCompFaltantesTmp.POLCA.Equals("No") || viewCompFaltantesTmp.POLCA.Equals(""))
                                    linea = linea + "N,";
                                else
                                {
                                    if (viewCompFaltantesTmp.POLCA.Equals("Si"))
                                    {
                                        linea = linea + "S,";
                                    }
                                    else
                                    {
                                        linea = linea + "N,";
                                    }
                                }

                                //56. Codigo infraccion longitud 5 numerico
                                if (viewCompFaltantesTmp.NUEVO_CODIGOCORREGIDO == null)
                                    linea = linea + ",";
                                else
                                {
                                    string tmp = limpiarString(viewCompFaltantesTmp.NUEVO_CODIGOCORREGIDO.Trim());
                                    //tmp = completarLongitudCadenas(tmp, 5, "0");
                                    linea = linea + tmp + ",";
                                }

                                //57. Valor de la infraccion 8 numerico
                                if (viewCompFaltantesTmp.VALORINFRACCION != null)
                                {
                                    double tmpDouble = double.Parse(viewCompFaltantesTmp.VALORINFRACCION.Trim());
                                    string tmp = limpiarString(tmpDouble.ToString());
                                    tmp = completarLongitudCadenas(tmp, 8, "0");
                                    linea = linea + tmp;
                                }
                                //-------------------------------------------------------------------------------------------------------
                                infoTramites.WriteLine(linea);
                                infoTramites.Close();
                                codchequeo = codchequeo + calcularASCIICadena(linea);
                            }
                            infoTramites = new StreamWriter(ubicacion + "/" + fileComparendos, true);
                            //----------------------DATOS FINALES DEL ARCHIVO---------------------------------------------------------------------------------
                            //Numero de registros longitud 5 numerico
                            string tmpfinal = completarLongitudCadenas(numRegistros.ToString(), 5, "0");
                            linea = tmpfinal + ",";

                            //Suma de registros longitud 8 numerico
                            //tmpfinal = completarLongitudCadenas(sumRegistros.ToString(), 8, "0");
                            tmpfinal = sumRegistros.ToString();
                            linea = linea + tmpfinal + ",";

                            //Numero de oficio longitud 10 alfanumerico
                            tmpfinal = completarLongitudCadenas(texNumeroOficio.Text, 10, " ");
                            linea = linea + tmpfinal + ",";

                            //Codigo de cheqeo longitud 4 numerico
                            linea = linea + completarLongitudCadenas(getCodigoChequeo(codchequeo), 4, "0");

                            infoTramites.WriteLine(linea);
                            infoTramites.Close();
                        }
                    }
                }
            }
            if (cheTodasResoluciones2.Checked || cheUnicamenteAlcoholemia2.Checked || cheResolucionesSinAlcoholemia2.Checked)
            {
                setPlanoResolucionesFaltantes();
                resultado = true;
            }
            if (cheRecaudos2.Checked)
            {
                setPlanosPagoFaltantes();
                resultado = true;
            }
            return resultado;
        }

        private void setPlanoResolucionesFaltantes()
        {
            int numRegistros = 0;
            string linea = "";
            double sumRegistros = 0;
            StreamWriter infoResoluciones;
            int codchequeo = 0;
            if (cheTodasResoluciones2.Checked)
            {
                viewResFaltantesCarga resolucionesFaltantes = new viewResFaltantesCarga();
                object[] listaResFaltantes;
                ServiciosViewResFaltantesCargaService mySerResolucionesFaltantes = WS.ServiciosViewResFaltantesCargaService();
                if (busquedaPorNroComparendo)
                {
                    resolucionesFaltantes.NUMEROCOMPARENDO = texNumeroComparendo2.Text;
                    listaResFaltantes = mySerResolucionesFaltantes.getViewResFaltantesCarga(resolucionesFaltantes);
                }
                else
                {
                    if (cheInfractor2.Checked)
                    {
                        infractorComp infractor = buscaInfractor(int.Parse(comTipoDocumento2.SelectedValue.ToString()), texIdentificacion2.Text);
                        if (infractor != null)
                        {
                            resolucionesFaltantes.NROIDENTIFICACION = infractor.NROIDENTIFICACION;
                            listaResFaltantes = mySerResolucionesFaltantes.getViewResFaltantesCarga(resolucionesFaltantes);
                        }
                        else
                        {
                            listaResFaltantes = null;
                        }
                    }
                    else
                    {
                        listaResFaltantes = mySerResolucionesFaltantes.getViewResFaltantesCarga(resolucionesFaltantes);
                    }
                }
                planosSimit planos_Simit = new planosSimit();
                transitoComp transito = new transitoComp();
                ServiciosGeneralesCompService mySerGenCom = WS.ServiciosGeneralesCompService();
                ServiciosGeneralesService serviciosGenerales = WS.ServiciosGeneralesService();
                transito = mySerGenCom.getTransitoComp(transito);

                if (listaResFaltantes != null)
                {
                    foreach (viewResFaltantesCarga viewResolFaltantes in listaResFaltantes)
                    {
                        infoResoluciones = new StreamWriter(ubicacion + "/" + fileResoluciones, true);
                        numRegistros++;
                        //1. Consecutivo longitud 5 Numerico
                        if (numRegistros > 19999)
                            numRegistros = 1;
                        linea = numRegistros.ToString() + ",";

                        //2. Numero de resolucion de longitud 10 Alfanumerico
                        if (viewResolFaltantes.NUMERO == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = limpiarString(viewResolFaltantes.NUMERO.Trim());
                            tmp = completarLongitudCadenas(tmp, 10, " ");
                            linea = linea + tmp + ",";
                        }

                        //3. Numero de Resolucion anterior longitud 10 Alfanumerico
                        if (viewResolFaltantes.CODTIPORESOLUCION == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            if (!viewResolFaltantes.CODTIPORESOLUCION.Equals("1") || !viewResolFaltantes.CODTIPORESOLUCION.Equals("7"))
                            {
                                //string tmp = limpiarString(viewResolFaltantes.CODTIPORESOLUCION.Trim());
                                //tmp = completarLongitudCadenas(tmp, 10, " ");
                                string tmp = completarLongitudCadenas("", 10, " ");
                                linea = linea + tmp + ",";
                            }
                            else
                            {
                                string tmp = completarLongitudCadenas("", 10, " ");
                                linea = linea + tmp + ",";
                            }
                        }

                        //4. Fecha de resolucion longitud 10 numerico
                        if (viewResolFaltantes.FECHA == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            DateTime fecha = DateTime.Parse(viewResolFaltantes.FECHA);
                            string tmp = completarLongitudCadenas(fecha.ToString("dd/MM/yyyy"), 10, "0");
                            linea = linea + tmp + ",";
                        }

                        //5. Codigo de tipo de resolucion longitud 2 numerico
                        if (viewResolFaltantes.CODTIPORESOLUCION == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = completarLongitudCadenas(viewResolFaltantes.CODTIPORESOLUCION, 2, "0");
                            linea = linea + tmp + ",";
                        }

                        //6. Fecha hasta en suspensiones longitud 10 numerico
                        if (viewResolFaltantes.CODTIPORESOLUCION == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            if (viewResolFaltantes.CODTIPORESOLUCION.Equals("7"))
                            {
                                estadoAlcoholemia ealcoholemia = new estadoAlcoholemia();
                                if (viewResolFaltantes.VALORALCOLEMIA != null)
                                {
                                    ealcoholemia = mySerGenCom.getFechaSuspension(ealcoholemia, int.Parse(viewResolFaltantes.VALORALCOLEMIA), true);
                                    if (ealcoholemia != null && ealcoholemia.ID > 0)
                                    {
                                        if (ealcoholemia.TIEMPO == 0)
                                        {
                                            linea = linea + "0000000000,";
                                        }
                                        else
                                        {
                                            DateTime fecha = DateTime.Parse(viewResolFaltantes.FECHACOMPARENDO);
                                            fecha.AddMonths(ealcoholemia.TIEMPO);
                                            string tmp = completarLongitudCadenas(fecha.ToString("dd/MM/yyyy"), 10, "0");
                                            linea = linea + tmp + ",";
                                        }
                                    }
                                    else
                                    {
                                        linea = linea + "0000000000,";
                                    }
                                }
                                else
                                {
                                    linea = linea + "0000000000,";
                                }
                            }
                            else
                            {
                                linea = linea + "0000000000,";
                            }
                        }

                        //7. Numero de comparendo longitud 20 alfanumerico
                        if (viewResolFaltantes.NUMEROCOMPARENDO == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = limpiarString(viewResolFaltantes.NUMEROCOMPARENDO.Trim());
                            tmp = completarLongitudCadenas(tmp, 20, " ");
                            linea = linea + tmp + ",";
                        }

                        //8. Fecha comparendo 10 alfanumerico
                        if (viewResolFaltantes.FECHACOMPARENDO == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            DateTime fecha = DateTime.Parse(viewResolFaltantes.FECHACOMPARENDO);
                            string tmp = completarLongitudCadenas(fecha.ToString("dd/MM/yyyy"), 10, " ");
                            linea = linea + tmp + ",";
                        }

                        //9. Nro idenificacion de infractor 15 numerico
                        if (viewResolFaltantes.NROIDENTIFICACION == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = limpiarString(viewResolFaltantes.NROIDENTIFICACION.Trim());
                            tmp = completarLongitudCadenas(tmp, 15, "0");
                            linea = linea + tmp + ",";
                        }

                        //10. Codigo tipo de documento longitud 1 numerico
                        if (viewResolFaltantes.IDREPORTECOMPARENDO <= 0)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = limpiarString(viewResolFaltantes.IDREPORTECOMPARENDO.ToString());
                            tmp = completarLongitudCadenas(tmp, 1, "0");
                            linea = linea + tmp + ",";
                        }

                        //11. Nombre Infractor longitud 18 alfanumerico
                        if (viewResolFaltantes.NOMBRES == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = limpiarString(viewResolFaltantes.NOMBRES);
                            tmp = completarLongitudCadenas(tmp, 18, " ");
                            linea = linea + tmp + ",";
                        }

                        //12. Apellidos Infrector longitud 20 alfanumerico
                        if (viewResolFaltantes.APELLIDOS == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = limpiarString(viewResolFaltantes.APELLIDOS);
                            tmp = completarLongitudCadenas(tmp, 19, " ");
                            linea = linea + tmp + ",";
                        }

                        //13. Direccion infrector longitud 40 alfanumerico
                        if (viewResolFaltantes.DIRECCION == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = limpiarString(viewResolFaltantes.DIRECCION);
                            tmp = completarLongitudCadenas(tmp, 40, " ");
                            linea = linea + tmp + ",";
                        }

                        //14. Telefono infractor longitud 15 alfanumerico
                        if (viewResolFaltantes.TELEFONO == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = limpiarString(viewResolFaltantes.TELEFONO.Trim());
                            tmp = completarLongitudCadenas(tmp, 15, " ");
                            linea = linea + tmp + ",";
                        }

                        //15. Codigo Ciudad de residencia DIVIPO residencia infractor longitud 8 numerico
                        if (viewResolFaltantes.ID_DEPTO == null && viewResolFaltantes.CODCIUDAD == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = getDivisionPolitica(viewResolFaltantes.ID_DEPTO.Trim(), viewResolFaltantes.CODCIUDAD.Trim());
                            tmp = limpiarString(tmp);
                            tmp = completarLongitudCadenas(tmp, 8, "0");
                            linea = linea + tmp + ",";
                        }

                        //16. Valor total de la resolucion longitud 8 numerico
                        if (viewResolFaltantes.VALORINFRACCION == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            //double tmpDouble = double.Parse(viewResolFaltantes.VALORINFRACCION);
                            //string tmp = completarLongitudCadenas(tmpDouble.ToString(), 8, "0");
                            //linea = linea + tmp + ",";
                            string[] aux = viewResolFaltantes.VALORINFRACCION.Trim().Split('.', ',');
                            string tmp = limpiarString(aux[0]);
                            tmp = completarLongitudCadenas(tmp, 8, " ");
                            linea = linea + tmp + ",";
                            sumRegistros = sumRegistros + Convert.ToDouble(viewResolFaltantes.VALORINFRACCION);
                        }

                        //17. Valores adicionales longitud 8 numerico
                        linea = linea + "00000000,";

                        //18. Codigo del organismo que reporta(divipo de secretaria) longitud 8 numerico
                        if (transito.ID_CIUDAD <= 0)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            ciudadComp ciudad = new ciudadComp();
                            ciudad.ID_CIUDAD = transito.ID_CIUDAD;
                            ciudad = (ciudadComp)((object[])serviciosAccesoriasComp.getCiudadComp(ciudad))[0];
                            if (ciudad != null && ciudad.ID_CIUDAD > 0)
                            {
                                string tmp = getDivisionPolitica(ciudad.ID_DEPTO.ToString(), ciudad.CODCIUDAD.Trim());
                                tmp = limpiarString(tmp);
                                linea = linea + tmp + ",";
                            }
                            else
                            {
                                linea = linea + ",";
                            }
                        }

                        //19. Comparendos policia de carretera longitud 1 alfanumerico
                        if (viewResolFaltantes.POLCA == null)
                        {
                            linea = linea + "N,";
                        }
                        else
                        {
                            if (viewResolFaltantes.POLCA.Equals("Si"))
                            {
                                linea = linea + "S,";
                            }
                            else
                            {
                                linea = linea + "N,";
                            }
                        }

                        //20. Codigo infraccion longitud 5 numerico
                        if (viewResolFaltantes.NUEVO_CODIGOCORREGIDO == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = limpiarString(viewResolFaltantes.NUEVO_CODIGOCORREGIDO.Trim());
                            //tmp = completarLongitudCadenas(tmp, 5, "0");
                            linea = linea + tmp + ",";
                        }

                        //21. Valor de la infraccion logitud 8 numerico
                        if (viewResolFaltantes.VALORINFRACCION == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            //double tmpDouble = double.Parse(viewResolFaltantes.VALORINFRACCION);
                            //string tmp = completarLongitudCadenas(tmpDouble.ToString(), 8, "0");
                            //linea = linea + tmp + ",";
                            string[] aux = viewResolFaltantes.VALORINFRACCION.Trim().Split('.', ',');
                            string tmp = limpiarString(aux[0]);
                            tmp = completarLongitudCadenas(tmp, 8, " ");
                            linea = linea + tmp + ",";
                        }

                        //22. Valor a pagar infraccion longitud 8 numerico
                        if (viewResolFaltantes.VALORINFRACCION != null)
                        {
                            //double tmpDouble = double.Parse(viewResolFaltantes.VALORINFRACCION);
                            //string tmp = completarLongitudCadenas(tmpDouble.ToString(), 8, "0");
                            //linea = linea + tmp;
                            string[] aux = viewResolFaltantes.VALORINFRACCION.Trim().Split('.', ',');
                            string tmp = limpiarString(aux[0]);
                            tmp = completarLongitudCadenas(tmp, 8, " ");
                            linea = linea + tmp;
                        }
                        infoResoluciones.WriteLine(linea);
                        infoResoluciones.Close();
                        codchequeo = codchequeo + calcularASCIICadena(linea);
                        if (viewResolFaltantes.NUEVO_CODIGO.Equals("E3"))
                        {
                            infoResoluciones = new StreamWriter(ubicacion + "/" + fileResoluciones, true);
                            string linea2;
                            numRegistros++;
                            //1. Consecutivo longitud 5 Numerico
                            if (numRegistros > 19999)
                                numRegistros = 1;
                            linea2 = numRegistros.ToString() + ",";

                            //2. Numero de resolucion de longitud 10 Alfanumerico
                            if (viewResolFaltantes.NUMERO == null)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                string tmp = limpiarString(viewResolFaltantes.NUMERO.Trim());
                                tmp = completarLongitudCadenas(tmp, 10, " ");
                                linea2 = linea2 + tmp + ",";
                            }

                            //3. Numero de Resolucion anterior longitud 10 Alfanumerico
                            if (viewResolFaltantes.CODTIPORESOLUCION == null)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                if (!viewResolFaltantes.CODTIPORESOLUCION.Equals("1") || !viewResolFaltantes.CODTIPORESOLUCION.Equals("7"))
                                {
                                    string tmp = completarLongitudCadenas("", 10, " ");
                                    linea2 = linea2 + tmp + ",";
                                }
                                else
                                {
                                    string tmp = completarLongitudCadenas("", 10, " ");
                                    linea2 = linea2 + tmp + ",";
                                }
                            }

                            //4. Fecha de resolucion longitud 10 numerico
                            if (viewResolFaltantes.FECHA == null)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                DateTime fecha = DateTime.Parse(viewResolFaltantes.FECHA);
                                string tmp = completarLongitudCadenas(fecha.ToString("dd/MM/yyyy"), 10, "0");
                                linea2 = linea2 + tmp + ",";
                            }

                            //5. Codigo de tipo de resolucion longitud 2 numerico
                            linea2 = linea2 + "01,";

                            //6. Fecha hasta en suspensiones longitud 10 numerico
                            linea2 = linea2 + "00/00/0000,";

                            //7. Numero de comparendo longitud 20 alfanumerico
                            if (viewResolFaltantes.NUMEROCOMPARENDO == null)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                string tmp = limpiarString(viewResolFaltantes.NUMEROCOMPARENDO.Trim());
                                tmp = completarLongitudCadenas(tmp, 20, " ");
                                linea2 = linea2 + tmp + ",";
                            }

                            //8. Fecha comparendo 10 alfanumerico
                            if (viewResolFaltantes.FECHACOMPARENDO == null)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                DateTime fecha = DateTime.Parse(viewResolFaltantes.FECHACOMPARENDO);
                                string tmp = completarLongitudCadenas(fecha.ToString("dd/MM/yyyy"), 10, " ");
                                linea2 = linea2 + tmp + ",";
                            }

                            //9. Nro idenificacion de infractor 15 numerico
                            if (viewResolFaltantes.NROIDENTIFICACION == null)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                string tmp = limpiarString(viewResolFaltantes.NROIDENTIFICACION.Trim());
                                tmp = completarLongitudCadenas(tmp, 15, "0");
                                linea2 = linea2 + tmp + ",";
                            }

                            //10. Codigo tipo de documento longitud 1 numerico
                            if (viewResolFaltantes.IDREPORTECOMPARENDO <= 0)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                string tmp = limpiarString(viewResolFaltantes.IDREPORTECOMPARENDO.ToString());
                                tmp = completarLongitudCadenas(tmp, 1, "0");
                                linea2 = linea2 + tmp + ",";
                            }

                            //11. Nombre Infractor longitud 18 alfanumerico
                            if (viewResolFaltantes.NOMBRES == null)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                string tmp = limpiarString(viewResolFaltantes.NOMBRES);
                                tmp = completarLongitudCadenas(tmp, 18, " ");
                                linea2 = linea2 + tmp + ",";
                            }

                            //12. Apellidos Infrector longitud 20 alfanumerico
                            if (viewResolFaltantes.APELLIDOS == null)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                string tmp = limpiarString(viewResolFaltantes.APELLIDOS);
                                tmp = completarLongitudCadenas(tmp, 19, " ");
                                linea2 = linea2 + tmp + ",";
                            }

                            //13. Direccion infrector longitud 40 alfanumerico
                            if (viewResolFaltantes.DIRECCION == null)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                string tmp = limpiarString(viewResolFaltantes.DIRECCION);
                                tmp = completarLongitudCadenas(tmp, 40, " ");
                                linea2 = linea2 + tmp + ",";
                            }

                            //14. Telefono infractor longitud 15 alfanumerico
                            if (viewResolFaltantes.TELEFONO == null)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                string tmp = limpiarString(viewResolFaltantes.TELEFONO.Trim());
                                tmp = completarLongitudCadenas(tmp, 15, " ");
                                linea2 = linea2 + tmp + ",";
                            }

                            //15. Codigo Ciudad de residencia DIVIPO residencia infractor longitud 8 numerico
                            if (viewResolFaltantes.ID_DEPTO == null && viewResolFaltantes.CODCIUDAD == null)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                string tmp = getDivisionPolitica(viewResolFaltantes.ID_DEPTO.Trim(), viewResolFaltantes.CODCIUDAD.Trim());
                                tmp = limpiarString(tmp);
                                tmp = completarLongitudCadenas(tmp, 8, "0");
                                linea2 = linea2 + tmp + ",";
                            }

                            //16. Valor total de la resolucion longitud 8 numerico
                            if (viewResolFaltantes.VALORINFRACCION == null)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                //double tmpDouble = double.Parse(viewResolFaltantes.VALORINFRACCION);
                                //string tmp = completarLongitudCadenas(tmpDouble.ToString(), 8, "0");
                                string[] aux = viewResolFaltantes.VALORINFRACCION.Trim().Split('.', ',');
                                string tmp = limpiarString(aux[0]);
                                tmp = completarLongitudCadenas(tmp, 8, " ");
                                linea2 = linea2 + tmp + ",";
                                sumRegistros = sumRegistros + double.Parse(viewResolFaltantes.VALORINFRACCION);
                            }

                            //17. Valores adicionales longitud 8 numerico
                            linea2 = linea2 + "00000000,";

                            //18. Codigo del organismo que reporta(divipo de secretaria) longitud 8 numerico
                            if (transito.ID_CIUDAD <= 0)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                ciudadComp ciudad = new ciudadComp();
                                ciudad.ID_CIUDAD = transito.ID_CIUDAD;
                                ciudad = (ciudadComp)((object[])serviciosAccesoriasComp.getCiudadComp(ciudad))[0];
                                if (ciudad != null && ciudad.ID_CIUDAD > 0)
                                {
                                    string tmp = getDivisionPolitica(ciudad.ID_DEPTO.ToString(), ciudad.CODCIUDAD.Trim());
                                    tmp = limpiarString(tmp);
                                    linea2 = linea2 + tmp + ",";
                                }
                                else
                                {
                                    linea2 = linea2 + ",";
                                }
                            }

                            //19. Comparendos policia de carretera longitud 1 alfanumerico
                            if (viewResolFaltantes.POLCA == null)
                            {
                                linea2 = linea2 + "N,";
                            }
                            else
                            {
                                if (viewResolFaltantes.POLCA.Equals("Si"))
                                {
                                    linea2 = linea2 + "S,";
                                }
                                else
                                {
                                    linea2 = linea2 + "N,";
                                }
                            }

                            //20. Codigo infraccion longitud 5 numerico
                            if (viewResolFaltantes.NUEVO_CODIGOCORREGIDO == null)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                string tmp = limpiarString(viewResolFaltantes.NUEVO_CODIGOCORREGIDO.Trim());
                                //tmp = completarLongitudCadenas(tmp, 5, "0");
                                linea2 = linea2 + tmp + ",";
                            }

                            //21. Valor de la infraccion logitud 8 numerico
                            if (viewResolFaltantes.VALORINFRACCION == null)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                //double tmpDouble = double.Parse(viewResolFaltantes.VALORINFRACCION.Trim());
                                //string tmp = completarLongitudCadenas(tmpDouble.ToString(), 8, "0");
                                string[] aux = viewResolFaltantes.VALORINFRACCION.Trim().Split('.', ',');
                                string tmp = limpiarString(aux[0]);
                                tmp = completarLongitudCadenas(tmp, 8, " ");
                                linea2 = linea2 + tmp + ",";
                            }

                            //22. Valor a pagar infraccion longitud 8 numerico
                            if (viewResolFaltantes.VALORINFRACCION != null)
                            {
                                //double tmpDouble = double.Parse(viewResolFaltantes.VALORINFRACCION.Trim());
                                //string tmp = completarLongitudCadenas(tmpDouble.ToString(), 8, "0");
                                string[] aux = viewResolFaltantes.VALORINFRACCION.Trim().Split('.', ',');
                                string tmp = limpiarString(aux[0]);
                                tmp = completarLongitudCadenas(tmp, 8, " ");
                                linea2 = linea2 + tmp;
                            }
                            infoResoluciones.WriteLine(linea2);
                            infoResoluciones.Close();
                            codchequeo = codchequeo + calcularASCIICadena(linea2);
                        }
                    }
                    infoResoluciones = new StreamWriter(ubicacion + "/" + fileResoluciones, true);
                    //----------------------DATOS FINALES DEL ARCHIVO---------------------------------------------------------------------------------
                    //Numero de registros longitud 5 numerico
                    string tmpfinal = completarLongitudCadenas(numRegistros.ToString(), 5, "0");
                    linea = tmpfinal + ",";

                    //Suma de registros longitud 8 numerico
                    //tmpfinal = completarLongitudCadenas(sumRegistros.ToString(), 8, "0");
                    tmpfinal = sumRegistros.ToString();
                    linea = linea + tmpfinal + ",";

                    //Numero de oficio longitud 10 alfanumerico
                    tmpfinal = completarLongitudCadenas(texNumeroOficio.Text.Trim(), 10, " ");
                    linea = linea + tmpfinal + ",";

                    //Codigo de cheqeo longitud 4 numerico
                    linea = linea + completarLongitudCadenas(getCodigoChequeo(codchequeo), 4, "0");

                    infoResoluciones.WriteLine(linea);
                    infoResoluciones.Close();
                }
                else
                {
                    MessageBox.Show("No hay resoluciones faltantes", "Advertencia!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            if (cheUnicamenteAlcoholemia2.Checked)
            {
                viewResFaltantesCarga resolucionesFaltantes = new viewResFaltantesCarga();
                resolucionesFaltantes.NUEVO_CODIGO = "E3";
                object[] listaResFaltantes;
                ServiciosViewResFaltantesCargaService mySerResolucionesFaltantes = WS.ServiciosViewResFaltantesCargaService();
                if (busquedaPorNroComparendo)
                {
                    resolucionesFaltantes.NUMEROCOMPARENDO = texNumeroComparendo2.Text;
                    listaResFaltantes = mySerResolucionesFaltantes.getViewResFaltantesCarga(resolucionesFaltantes);
                }
                else
                {
                    if (cheInfractor2.Checked)
                    {
                        infractorComp infractor = buscaInfractor(int.Parse(comTipoDocumento2.SelectedValue.ToString()), texIdentificacion2.Text);
                        if (infractor != null)
                        {
                            resolucionesFaltantes.NROIDENTIFICACION = infractor.NROIDENTIFICACION;
                            listaResFaltantes = mySerResolucionesFaltantes.getViewResFaltantesCarga(resolucionesFaltantes);
                        }
                        else
                        {
                            listaResFaltantes = null;
                        }
                    }
                    else
                    {
                        listaResFaltantes = mySerResolucionesFaltantes.getViewResFaltantesCarga(resolucionesFaltantes);
                    }
                }
                planosSimit planos_Simit = new planosSimit();
                transitoComp transito = new transitoComp();
                ServiciosGeneralesCompService mySerGenCom = WS.ServiciosGeneralesCompService();
                ServiciosGeneralesService serviciosGenerales = WS.ServiciosGeneralesService();
                transito = mySerGenCom.getTransitoComp(transito);

                if (listaResFaltantes != null)
                {
                    foreach (viewResFaltantesCarga viewResolFaltantes in listaResFaltantes)
                    {
                        infoResoluciones = new StreamWriter(ubicacion + "/" + fileResoluciones, true);
                        numRegistros++;
                        //1. Consecutivo longitud 5 Numerico
                        if (numRegistros > 19999)
                            numRegistros = 1;
                        linea = numRegistros.ToString() + ",";

                        //2. Numero de resolucion de longitud 10 Alfanumerico
                        if (viewResolFaltantes.NUMERO == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = limpiarString(viewResolFaltantes.NUMERO.Trim());
                            tmp = completarLongitudCadenas(tmp, 10, " ");
                            linea = linea + tmp + ",";
                        }

                        //3. Numero de Resolucion anterior longitud 10 Alfanumerico
                        if (viewResolFaltantes.CODTIPORESOLUCION == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            if (!viewResolFaltantes.CODTIPORESOLUCION.Equals("1") || !viewResolFaltantes.CODTIPORESOLUCION.Equals("7"))
                            {
                                //string tmp = limpiarString(viewResolFaltantes.CODTIPORESOLUCION.Trim());
                                //tmp = completarLongitudCadenas(tmp, 10, " ");
                                string tmp = completarLongitudCadenas("", 10, " ");
                                linea = linea + tmp + ",";
                            }
                            else
                            {
                                string tmp = completarLongitudCadenas("", 10, " ");
                                linea = linea + tmp + ",";
                            }
                        }

                        //4. Fecha de resolucion longitud 10 numerico
                        if (viewResolFaltantes.FECHA == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            DateTime fecha = DateTime.Parse(viewResolFaltantes.FECHA);
                            string tmp = completarLongitudCadenas(fecha.ToString("dd/MM/yyyy"), 10, "0");
                            linea = linea + tmp + ",";
                        }

                        //5. Codigo de tipo de resolucion longitud 2 numerico
                        if (viewResolFaltantes.CODTIPORESOLUCION == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = completarLongitudCadenas(viewResolFaltantes.CODTIPORESOLUCION.Trim(), 2, "0");
                            linea = linea + tmp + ",";
                        }

                        //6. Fecha hasta en suspensiones longitud 10 numerico
                        if (viewResolFaltantes.CODTIPORESOLUCION == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            if (viewResolFaltantes.CODTIPORESOLUCION.Equals("7"))
                            {
                                estadoAlcoholemia ealcoholemia = new estadoAlcoholemia();
                                if (viewResolFaltantes.VALORALCOLEMIA != null)
                                {
                                    ealcoholemia = mySerGenCom.getFechaSuspension(ealcoholemia, int.Parse(viewResolFaltantes.VALORALCOLEMIA), true);
                                    if (ealcoholemia != null && ealcoholemia.ID > 0)
                                    {
                                        if (ealcoholemia.TIEMPO == 0)
                                        {
                                            linea = linea + "0000000000,";
                                        }
                                        else
                                        {
                                            DateTime fecha = DateTime.Parse(viewResolFaltantes.FECHACOMPARENDO);
                                            fecha.AddMonths(ealcoholemia.TIEMPO);
                                            string tmp = completarLongitudCadenas(fecha.ToString("dd/MM/yyyy"), 10, "0");
                                            linea = linea + tmp + ",";
                                        }
                                    }
                                    else
                                    {
                                        linea = linea + "0000000000,";
                                    }
                                }
                                else
                                {
                                    linea = linea + "0000000000,";
                                }
                            }
                            else
                            {
                                linea = linea + "0000000000,";
                            }
                        }

                        //7. Numero de comparendo longitud 20 alfanumerico
                        if (viewResolFaltantes.NUMEROCOMPARENDO == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = limpiarString(viewResolFaltantes.NUMEROCOMPARENDO.Trim());
                            tmp = completarLongitudCadenas(tmp, 20, " ");
                            linea = linea + tmp + ",";
                        }

                        //8. Fecha comparendo 10 alfanumerico
                        if (viewResolFaltantes.FECHACOMPARENDO == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            DateTime fecha = DateTime.Parse(viewResolFaltantes.FECHACOMPARENDO.Trim());
                            string tmp = completarLongitudCadenas(fecha.ToString("dd/MM/yyyy"), 10, " ");
                            linea = linea + tmp + ",";
                        }

                        //9. Nro idenificacion de infractor 15 numerico
                        if (viewResolFaltantes.NROIDENTIFICACION == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = limpiarString(viewResolFaltantes.NROIDENTIFICACION.Trim());
                            tmp = completarLongitudCadenas(tmp, 15, "0");
                            linea = linea + tmp + ",";
                        }

                        //10. Codigo tipo de documento longitud 1 numerico
                        if (viewResolFaltantes.IDREPORTECOMPARENDO <= 0)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = limpiarString(viewResolFaltantes.IDREPORTECOMPARENDO.ToString());
                            tmp = completarLongitudCadenas(tmp, 1, "0");
                            linea = linea + tmp + ",";
                        }

                        //11. Nombre Infractor longitud 18 alfanumerico
                        if (viewResolFaltantes.NOMBRES == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = limpiarString(viewResolFaltantes.NOMBRES);
                            tmp = completarLongitudCadenas(tmp, 18, " ");
                            linea = linea + tmp + ",";
                        }

                        //12. Apellidos Infrector longitud 20 alfanumerico
                        if (viewResolFaltantes.APELLIDOS == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = limpiarString(viewResolFaltantes.APELLIDOS);
                            tmp = completarLongitudCadenas(tmp, 19, " ");
                            linea = linea + tmp + ",";
                        }

                        //13. Direccion infrector longitud 40 alfanumerico
                        if (viewResolFaltantes.DIRECCION == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = limpiarString(viewResolFaltantes.DIRECCION);
                            tmp = completarLongitudCadenas(tmp, 40, " ");
                            linea = linea + tmp + ",";
                        }

                        //14. Telefono infractor longitud 15 alfanumerico
                        if (viewResolFaltantes.TELEFONO == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = limpiarString(viewResolFaltantes.TELEFONO.Trim());
                            tmp = completarLongitudCadenas(tmp, 15, " ");
                            linea = linea + tmp + ",";
                        }

                        //15. Codigo Ciudad de residencia DIVIPO residencia infractor longitud 8 numerico
                        if (viewResolFaltantes.ID_DEPTO == null && viewResolFaltantes.CODCIUDAD == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = getDivisionPolitica(viewResolFaltantes.ID_DEPTO.Trim(), viewResolFaltantes.CODCIUDAD.Trim());
                            tmp = limpiarString(tmp);
                            tmp = completarLongitudCadenas(tmp, 8, "0");
                            linea = linea + tmp + ",";
                        }

                        //16. Valor total de la resolucion longitud 8 numerico
                        if (viewResolFaltantes.VALORINFRACCION == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            //double tmpDouble = double.Parse(viewResolFaltantes.VALORINFRACCION.Trim());
                            //string tmp = completarLongitudCadenas(tmpDouble.ToString(), 8, "0");
                            string[] aux = viewResolFaltantes.VALORINFRACCION.Trim().Split('.', ',');
                            string tmp = limpiarString(aux[0]);
                            tmp = completarLongitudCadenas(tmp, 8, " ");
                            linea = linea + tmp + ",";
                            sumRegistros = sumRegistros + double.Parse(viewResolFaltantes.VALORINFRACCION.Trim());
                        }

                        //17. Valores adicionales longitud 8 numerico
                        linea = linea + "00000000,";

                        //18. Codigo del organismo que reporta(divipo de secretaria) longitud 8 numerico
                        if (transito.ID_CIUDAD <= 0)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            ciudadComp ciudad = new ciudadComp();
                            ciudad.ID_CIUDAD = transito.ID_CIUDAD;
                            ciudad = (ciudadComp)((object[])serviciosAccesoriasComp.getCiudadComp(ciudad))[0];
                            if (ciudad != null && ciudad.ID_CIUDAD > 0)
                            {
                                string tmp = getDivisionPolitica(ciudad.ID_DEPTO.ToString(), ciudad.CODCIUDAD.Trim());
                                tmp = limpiarString(tmp);
                                linea = linea + tmp + ",";
                            }
                            else
                            {
                                linea = linea + ",";
                            }
                        }

                        //19. Comparendos policia de carretera longitud 1 alfanumerico
                        if (viewResolFaltantes.POLCA == null)
                        {
                            linea = linea + "N,";
                        }
                        else
                        {
                            if (viewResolFaltantes.POLCA.Equals("Si"))
                            {
                                linea = linea + "S,";
                            }
                            else
                            {
                                linea = linea + "N,";
                            }
                        }

                        //20. Codigo infraccion longitud 5 numerico
                        if (viewResolFaltantes.NUEVO_CODIGOCORREGIDO == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = limpiarString(viewResolFaltantes.NUEVO_CODIGOCORREGIDO.Trim());
                            //tmp = completarLongitudCadenas(tmp, 5, "0");
                            linea = linea + tmp + ",";
                        }

                        //21. Valor de la infraccion logitud 8 numerico
                        if (viewResolFaltantes.VALORINFRACCION == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            //double tmpDouble = double.Parse(viewResolFaltantes.VALORINFRACCION.Trim());
                            //string tmp = completarLongitudCadenas(tmpDouble.ToString(), 8, "0");
                            string[] aux = viewResolFaltantes.VALORINFRACCION.Trim().Split('.', ',');
                            string tmp = limpiarString(aux[0]);
                            tmp = completarLongitudCadenas(tmp, 8, " ");
                            linea = linea + tmp + ",";
                        }

                        //22. Valor a pagar infraccion longitud 8 numerico
                        if (viewResolFaltantes.VALORINFRACCION != null)
                        {
                            //double tmpDouble = double.Parse(viewResolFaltantes.VALORINFRACCION.Trim());
                            //string tmp = completarLongitudCadenas(tmpDouble.ToString(), 8, "0");
                            string[] aux = viewResolFaltantes.VALORINFRACCION.Trim().Split('.', ',');
                            string tmp = limpiarString(aux[0]);
                            tmp = completarLongitudCadenas(tmp, 8, " ");
                            linea = linea + tmp;
                        }
                        infoResoluciones.WriteLine(linea);
                        infoResoluciones.Close();
                        codchequeo = codchequeo + calcularASCIICadena(linea);
                        if (viewResolFaltantes.NUEVO_CODIGO.Equals("E3"))
                        {
                            string linea2;
                            numRegistros++;
                            //1. Consecutivo longitud 5 Numerico
                            if (numRegistros > 19999)
                                numRegistros = 1;
                            linea2 = numRegistros.ToString() + ",";

                            //2. Numero de resolucion de longitud 10 Alfanumerico
                            if (viewResolFaltantes.NUMERO == null)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                string tmp = limpiarString(viewResolFaltantes.NUMERO.Trim());
                                tmp = completarLongitudCadenas(tmp, 10, " ");
                                linea2 = linea2 + tmp + ",";
                            }

                            //3. Numero de Resolucion anterior longitud 10 Alfanumerico
                            if (viewResolFaltantes.CODTIPORESOLUCION == null)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                if (!viewResolFaltantes.CODTIPORESOLUCION.Equals("1") || !viewResolFaltantes.CODTIPORESOLUCION.Equals("7"))
                                {
                                    //string tmp = limpiarString(viewResolFaltantes.CODTIPORESOLUCION.Trim());
                                    //tmp = completarLongitudCadenas(tmp, 10, " ");
                                    string tmp = completarLongitudCadenas("", 10, " ");
                                    linea2 = linea2 + tmp + ",";
                                }
                                else
                                {
                                    string tmp = completarLongitudCadenas("", 10, " ");
                                    linea2 = linea2 + tmp + ",";
                                }
                            }

                            //4. Fecha de resolucion longitud 10 numerico
                            if (viewResolFaltantes.FECHA == null)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                DateTime fecha = DateTime.Parse(viewResolFaltantes.FECHA);
                                string tmp = completarLongitudCadenas(fecha.ToString("dd/MM/yyyy"), 10, "0");
                                linea2 = linea2 + tmp + ",";
                            }

                            //5. Codigo de tipo de resolucion longitud 2 numerico
                            linea2 = linea2 + "01,";

                            //6. Fecha hasta en suspensiones longitud 10 numerico
                            linea2 = linea2 + "00/00/0000,";

                            //7. Numero de comparendo longitud 20 alfanumerico
                            if (viewResolFaltantes.NUMEROCOMPARENDO == null)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                string tmp = limpiarString(viewResolFaltantes.NUMEROCOMPARENDO);
                                tmp = completarLongitudCadenas(tmp, 20, " ");
                                linea2 = linea2 + tmp + ",";
                            }

                            //8. Fecha comparendo 10 alfanumerico
                            if (viewResolFaltantes.FECHACOMPARENDO == null)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                DateTime fecha = DateTime.Parse(viewResolFaltantes.FECHACOMPARENDO);
                                string tmp = completarLongitudCadenas(fecha.ToString("dd/MM/yyyy"), 10, " ");
                                linea2 = linea2 + tmp + ",";
                            }

                            //9. Nro idenificacion de infractor 15 numerico
                            if (viewResolFaltantes.NROIDENTIFICACION == null)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                string tmp = limpiarString(viewResolFaltantes.NROIDENTIFICACION.Trim());
                                tmp = completarLongitudCadenas(tmp, 15, "0");
                                linea2 = linea2 + tmp + ",";
                            }

                            //10. Codigo tipo de documento longitud 1 numerico
                            if (viewResolFaltantes.IDREPORTECOMPARENDO <= 0)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                string tmp = limpiarString(viewResolFaltantes.IDREPORTECOMPARENDO.ToString());
                                tmp = completarLongitudCadenas(tmp, 1, "0");
                                linea2 = linea2 + tmp + ",";
                            }

                            //11. Nombre Infractor longitud 18 alfanumerico
                            if (viewResolFaltantes.NOMBRES == null)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                string tmp = limpiarString(viewResolFaltantes.NOMBRES);
                                tmp = completarLongitudCadenas(tmp, 18, " ");
                                linea2 = linea2 + tmp + ",";
                            }

                            //12. Apellidos Infrector longitud 20 alfanumerico
                            if (viewResolFaltantes.APELLIDOS == null)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                string tmp = limpiarString(viewResolFaltantes.APELLIDOS);
                                tmp = completarLongitudCadenas(tmp, 19, " ");
                                linea2 = linea2 + tmp + ",";
                            }

                            //13. Direccion infrector longitud 40 alfanumerico
                            if (viewResolFaltantes.DIRECCION == null)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                string tmp = limpiarString(viewResolFaltantes.DIRECCION);
                                tmp = completarLongitudCadenas(tmp, 40, " ");
                                linea2 = linea2 + tmp + ",";
                            }

                            //14. Telefono infractor longitud 15 alfanumerico
                            if (viewResolFaltantes.TELEFONO == null)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                string tmp = limpiarString(viewResolFaltantes.TELEFONO.Trim());
                                tmp = completarLongitudCadenas(tmp, 15, " ");
                                linea2 = linea2 + tmp + ",";
                            }

                            //15. Codigo Ciudad de residencia DIVIPO residencia infractor longitud 8 numerico
                            if (viewResolFaltantes.ID_DEPTO == null && viewResolFaltantes.CODCIUDAD == null)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                string tmp = getDivisionPolitica(viewResolFaltantes.ID_DEPTO.Trim(), viewResolFaltantes.CODCIUDAD.Trim());
                                tmp = limpiarString(tmp);
                                tmp = completarLongitudCadenas(tmp, 8, "0");
                                linea2 = linea2 + tmp + ",";
                            }

                            //16. Valor total de la resolucion longitud 8 numerico
                            if (viewResolFaltantes.VALORINFRACCION == null)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                //double tmpDouble = double.Parse(viewResolFaltantes.VALORINFRACCION.Trim());
                                //string tmp = completarLongitudCadenas(tmpDouble.ToString(), 8, "0");
                                string[] aux = viewResolFaltantes.VALORINFRACCION.Trim().Split('.', ',');
                                string tmp = limpiarString(aux[0]);
                                tmp = completarLongitudCadenas(tmp, 8, " ");
                                linea2 = linea2 + tmp + ",";
                                sumRegistros = sumRegistros + double.Parse(viewResolFaltantes.VALORINFRACCION.Trim());
                            }

                            //17. Valores adicionales longitud 8 numerico
                            linea2 = linea2 + "00000000,";

                            //18. Codigo del organismo que reporta(divipo de secretaria) longitud 8 numerico
                            if (transito.ID_CIUDAD <= 0)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                ciudadComp ciudad = new ciudadComp();
                                ciudad.ID_CIUDAD = transito.ID_CIUDAD;
                                ciudad = (ciudadComp)((object[])serviciosAccesoriasComp.getCiudadComp(ciudad))[0];
                                if (ciudad != null && ciudad.ID_CIUDAD > 0)
                                {
                                    string tmp = getDivisionPolitica(ciudad.ID_DEPTO.ToString(), ciudad.CODCIUDAD.Trim());
                                    tmp = limpiarString(tmp);
                                    linea2 = linea2 + tmp + ",";
                                }
                                else
                                {
                                    linea2 = linea2 + ",";
                                }
                            }

                            //19. Comparendos policia de carretera longitud 1 alfanumerico
                            if (viewResolFaltantes.POLCA == null)
                            {
                                linea2 = linea2 + "N,";
                            }
                            else
                            {
                                if (viewResolFaltantes.POLCA.Equals("Si"))
                                {
                                    linea2 = linea2 + "S,";
                                }
                                else
                                {
                                    linea2 = linea2 + "N,";
                                }
                            }

                            //20. Codigo infraccion longitud 5 numerico
                            if (viewResolFaltantes.NUEVO_CODIGOCORREGIDO == null)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                string tmp = limpiarString(viewResolFaltantes.NUEVO_CODIGOCORREGIDO.Trim());
                                //tmp = completarLongitudCadenas(tmp, 5, "0");
                                linea2 = linea2 + tmp + ",";
                            }

                            //21. Valor de la infraccion logitud 8 numerico
                            if (viewResolFaltantes.VALORINFRACCION == null)
                            {
                                linea2 = linea2 + ",";
                            }
                            else
                            {
                                double tmpDouble = double.Parse(viewResolFaltantes.VALORINFRACCION.Trim());
                                string tmp = completarLongitudCadenas(tmpDouble.ToString(), 8, "0");
                                linea2 = linea2 + tmp + ",";
                            }

                            //22. Valor a pagar infraccion longitud 8 numerico
                            if (viewResolFaltantes.VALORINFRACCION != null)
                            {
                                //double tmpDouble = double.Parse(viewResolFaltantes.VALORINFRACCION.Trim());
                                //string tmp = completarLongitudCadenas(tmpDouble.ToString(), 8, "0");
                                string[] aux = viewResolFaltantes.VALORINFRACCION.Trim().Split('.', ',');
                                string tmp = limpiarString(aux[0]);
                                tmp = completarLongitudCadenas(tmp, 8, " ");
                                linea2 = linea2 + tmp;
                            }
                            infoResoluciones.WriteLine(linea2);
                            infoResoluciones.Close();
                            codchequeo = codchequeo + calcularASCIICadena(linea2);
                        }
                    }
                    infoResoluciones = new StreamWriter(ubicacion + "/" + fileResoluciones, true);
                    //----------------------DATOS FINALES DEL ARCHIVO---------------------------------------------------------------------------------
                    //Numero de registros longitud 5 numerico
                    string tmpfinal = completarLongitudCadenas(numRegistros.ToString(), 5, "0");
                    linea = tmpfinal + ",";

                    //Suma de registros longitud 8 numerico
                    //tmpfinal = completarLongitudCadenas(sumRegistros.ToString(), 8, "0");
                    tmpfinal = sumRegistros.ToString();
                    linea = linea + tmpfinal + ",";

                    //Numero de oficio longitud 10 alfanumerico
                    tmpfinal = completarLongitudCadenas(texNumeroOficio.Text.Trim(), 10, " ");
                    linea = linea + tmpfinal + ",";

                    //Codigo de cheqeo longitud 4 numerico
                    linea = linea + completarLongitudCadenas(getCodigoChequeo(codchequeo), 4, "0");

                    infoResoluciones.WriteLine(linea);
                    infoResoluciones.Close();
                }
                else
                {
                    MessageBox.Show("No se encontraron resoluciones sin alcoholemia faltantes", "Informacion!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            if (cheResolucionesSinAlcoholemia2.Checked)
            {
                viewResFaltantesCarga resolucionesFaltantes = new viewResFaltantesCarga();
                object[] listaResFaltantes;
                ServiciosViewResFaltantesCargaService mySerResolucionesFaltantes = WS.ServiciosViewResFaltantesCargaService();
                if (busquedaPorNroComparendo)
                {
                    resolucionesFaltantes.NUMEROCOMPARENDO = texNumeroComparendo2.Text;
                    listaResFaltantes = mySerResolucionesFaltantes.getViewResFaltantesCarga2(resolucionesFaltantes);
                }
                else
                {
                    if (cheInfractor2.Checked)
                    {
                        infractorComp infractor = buscaInfractor(int.Parse(comTipoDocumento2.SelectedValue.ToString()), texIdentificacion2.Text);
                        if (infractor != null)
                        {
                            resolucionesFaltantes.NROIDENTIFICACION = infractor.NROIDENTIFICACION;
                            listaResFaltantes = mySerResolucionesFaltantes.getViewResFaltantesCarga2(resolucionesFaltantes);
                        }
                        else
                        {
                            listaResFaltantes = null;
                        }
                    }
                    else
                    {
                        listaResFaltantes = mySerResolucionesFaltantes.getViewResFaltantesCarga2(resolucionesFaltantes);
                    }
                }
                planosSimit planos_Simit = new planosSimit();
                transitoComp transito = new transitoComp();
                ServiciosGeneralesCompService mySerGenCom = WS.ServiciosGeneralesCompService();
                ServiciosGeneralesService serviciosGenerales = WS.ServiciosGeneralesService();
                transito = mySerGenCom.getTransitoComp(transito);

                if (listaResFaltantes != null)
                {
                    foreach (viewResFaltantesCarga viewResolFaltantes in listaResFaltantes)
                    {
                        infoResoluciones = new StreamWriter(ubicacion + "/" + fileResoluciones, true);
                        numRegistros++;
                        //1. Consecutivo longitud 5 Numerico
                        if (numRegistros > 19999)
                            numRegistros = 1;
                        linea = numRegistros.ToString() + ",";

                        //2. Numero de resolucion de longitud 10 Alfanumerico
                        if (viewResolFaltantes.NUMERO == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = limpiarString(viewResolFaltantes.NUMERO.Trim());
                            tmp = completarLongitudCadenas(tmp, 10, " ");
                            linea = linea + tmp + ",";
                        }

                        //3. Numero de Resolucion anterior longitud 10 Alfanumerico
                        if (viewResolFaltantes.CODTIPORESOLUCION == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            if (!viewResolFaltantes.CODTIPORESOLUCION.Equals("1") || !viewResolFaltantes.CODTIPORESOLUCION.Equals("7"))
                            {
                                //string tmp = limpiarString(viewResolFaltantes.CODTIPORESOLUCION.Trim());
                                //tmp = completarLongitudCadenas(tmp, 10, " ");
                                string tmp = completarLongitudCadenas("", 10, " ");
                                linea = linea + tmp + ",";
                            }
                            else
                            {
                                string tmp = completarLongitudCadenas("", 10, " ");
                                linea = linea + tmp + ",";
                            }
                        }

                        //4. Fecha de resolucion longitud 10 numerico
                        if (viewResolFaltantes.FECHA == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            DateTime fecha = DateTime.Parse(viewResolFaltantes.FECHA);
                            string tmp = completarLongitudCadenas(fecha.ToString("dd/MM/yyyy"), 10, "0");
                            linea = linea + tmp + ",";
                        }

                        //5. Codigo de tipo de resolucion longitud 2 numerico
                        if (viewResolFaltantes.CODTIPORESOLUCION == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = completarLongitudCadenas(viewResolFaltantes.CODTIPORESOLUCION.Trim(), 2, "0");
                            linea = linea + tmp + ",";
                        }

                        //6. Fecha hasta en suspensiones longitud 10 numerico
                        if (viewResolFaltantes.CODTIPORESOLUCION == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            if (viewResolFaltantes.CODTIPORESOLUCION.Equals("7"))
                            {
                                estadoAlcoholemia ealcoholemia = new estadoAlcoholemia();
                                if (viewResolFaltantes.VALORALCOLEMIA != null)
                                {
                                    ealcoholemia = mySerGenCom.getFechaSuspension(ealcoholemia, int.Parse(viewResolFaltantes.VALORALCOLEMIA), true);
                                    if (ealcoholemia != null && ealcoholemia.ID > 0)
                                    {
                                        if (ealcoholemia.TIEMPO == 0)
                                        {
                                            linea = linea + "0000000000,";
                                        }
                                        else
                                        {
                                            DateTime fecha = DateTime.Parse(viewResolFaltantes.FECHACOMPARENDO);
                                            fecha.AddMonths(ealcoholemia.TIEMPO);
                                            string tmp = completarLongitudCadenas(fecha.ToString("dd/MM/yyyy"), 10, "0");
                                            linea = linea + tmp + ",";
                                        }
                                    }
                                    else
                                    {
                                        linea = linea + "0000000000,";
                                    }
                                }
                                else
                                {
                                    linea = linea + "0000000000,";
                                }
                            }
                            else
                            {
                                linea = linea + "0000000000,";
                            }
                        }

                        //7. Numero de comparendo longitud 20 alfanumerico
                        if (viewResolFaltantes.NUMEROCOMPARENDO == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = limpiarString(viewResolFaltantes.NUMEROCOMPARENDO.Trim());
                            tmp = completarLongitudCadenas(tmp, 20, " ");
                            linea = linea + tmp + ",";
                        }

                        //8. Fecha comparendo 10 alfanumerico
                        if (viewResolFaltantes.FECHACOMPARENDO == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            DateTime fecha = DateTime.Parse(viewResolFaltantes.FECHACOMPARENDO);
                            string tmp = completarLongitudCadenas(fecha.ToString("dd/MM/yyyy"), 10, " ");
                            linea = linea + tmp + ",";
                        }

                        //9. Nro idenificacion de infractor 15 numerico
                        if (viewResolFaltantes.NROIDENTIFICACION == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = limpiarString(viewResolFaltantes.NROIDENTIFICACION.Trim());
                            tmp = completarLongitudCadenas(tmp, 15, "0");
                            linea = linea + tmp + ",";
                        }

                        //10. Codigo tipo de documento longitud 1 numerico
                        if (viewResolFaltantes.IDREPORTECOMPARENDO <= 0)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = limpiarString(viewResolFaltantes.IDREPORTECOMPARENDO.ToString());
                            tmp = completarLongitudCadenas(tmp, 1, "0");
                            linea = linea + tmp + ",";
                        }

                        //11. Nombre Infractor longitud 18 alfanumerico
                        if (viewResolFaltantes.NOMBRES == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = limpiarString(viewResolFaltantes.NOMBRES);
                            tmp = completarLongitudCadenas(tmp, 18, " ");
                            linea = linea + tmp + ",";
                        }

                        //12. Apellidos Infrector longitud 20 alfanumerico
                        if (viewResolFaltantes.APELLIDOS == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = limpiarString(viewResolFaltantes.APELLIDOS);
                            tmp = completarLongitudCadenas(tmp, 19, " ");
                            linea = linea + tmp + ",";
                        }

                        //13. Direccion infrector longitud 40 alfanumerico
                        if (viewResolFaltantes.DIRECCION == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = limpiarString(viewResolFaltantes.DIRECCION);
                            tmp = completarLongitudCadenas(tmp, 40, " ");
                            linea = linea + tmp + ",";
                        }

                        //14. Telefono infractor longitud 15 alfanumerico
                        if (viewResolFaltantes.TELEFONO == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = limpiarString(viewResolFaltantes.TELEFONO.Trim());
                            tmp = completarLongitudCadenas(tmp, 15, " ");
                            linea = linea + tmp + ",";
                        }

                        //15. Codigo Ciudad de residencia DIVIPO residencia infractor longitud 8 numerico
                        if (viewResolFaltantes.ID_DEPTO == null && viewResolFaltantes.CODCIUDAD == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = getDivisionPolitica(viewResolFaltantes.ID_DEPTO.Trim(), viewResolFaltantes.CODCIUDAD.Trim());
                            tmp = limpiarString(tmp);
                            tmp = completarLongitudCadenas(tmp, 8, "0");
                            linea = linea + tmp + ",";
                        }

                        //16. Valor total de la resolucion longitud 8 numerico
                        if (viewResolFaltantes.VALORINFRACCION == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            //double tmpDouble = double.Parse(viewResolFaltantes.VALORINFRACCION);
                            //string tmp = completarLongitudCadenas(tmpDouble.ToString(), 8, "0");
                            string[] aux = viewResolFaltantes.VALORINFRACCION.Trim().Split('.', ',');
                            string tmp = limpiarString(aux[0]);
                            tmp = completarLongitudCadenas(tmp, 8, " ");
                            linea = linea + tmp + ",";
                            sumRegistros = sumRegistros + double.Parse(viewResolFaltantes.VALORINFRACCION);
                        }

                        //17. Valores adicionales longitud 8 numerico
                        linea = linea + "00000000,";

                        //18. Codigo del organismo que reporta(divipo de secretaria) longitud 8 numerico
                        if (transito.ID_CIUDAD <= 0)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            ciudadComp ciudad = new ciudadComp();
                            ciudad.ID_CIUDAD = transito.ID_CIUDAD;
                            ciudad = (ciudadComp)((object[])serviciosAccesoriasComp.getCiudadComp(ciudad))[0];
                            if (ciudad != null && ciudad.ID_CIUDAD > 0)
                            {
                                string tmp = getDivisionPolitica(ciudad.ID_DEPTO.ToString(), ciudad.CODCIUDAD.Trim());
                                tmp = limpiarString(tmp);
                                linea = linea + tmp + ",";
                            }
                            else
                            {
                                linea = linea + ",";
                            }
                        }

                        //19. Comparendos policia de carretera longitud 1 alfanumerico
                        if (viewResolFaltantes.POLCA == null)
                        {
                            linea = linea + "N,";
                        }
                        else
                        {
                            if (viewResolFaltantes.POLCA.Equals("Si"))
                            {
                                linea = linea + "S,";
                            }
                            else
                            {
                                linea = linea + "N,";
                            }
                        }

                        //20. Codigo infraccion longitud 5 numerico
                        if (viewResolFaltantes.NUEVO_CODIGOCORREGIDO == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            string tmp = limpiarString(viewResolFaltantes.NUEVO_CODIGOCORREGIDO.Trim());
                            //tmp = completarLongitudCadenas(tmp, 5, "0");
                            linea = linea + tmp + ",";
                        }

                        //21. Valor de la infraccion logitud 8 numerico
                        if (viewResolFaltantes.VALORINFRACCION == null)
                        {
                            linea = linea + ",";
                        }
                        else
                        {
                            //double tmpDouble = double.Parse(viewResolFaltantes.VALORINFRACCION.Trim());
                            //string tmp = completarLongitudCadenas(tmpDouble.ToString(), 8, "0");
                            string[] aux = viewResolFaltantes.VALORINFRACCION.Trim().Split('.', ',');
                            string tmp = limpiarString(aux[0]);
                            tmp = completarLongitudCadenas(tmp, 8, " ");
                            linea = linea + tmp + ",";
                        }

                        //22. Valor a pagar infraccion longitud 8 numerico
                        if (viewResolFaltantes.VALORINFRACCION != null)
                        {
                            //double tmpDouble = double.Parse(viewResolFaltantes.VALORINFRACCION.Trim());
                            //string tmp = completarLongitudCadenas(tmpDouble.ToString(), 8, "0");
                            string[] aux = viewResolFaltantes.VALORINFRACCION.Trim().Split('.', ',');
                            string tmp = limpiarString(aux[0]);
                            tmp = completarLongitudCadenas(tmp, 8, " ");
                            linea = linea + tmp;
                        }
                        infoResoluciones.WriteLine(linea);
                        infoResoluciones.Close();
                        codchequeo = codchequeo + calcularASCIICadena(linea);
                    }
                    infoResoluciones = new StreamWriter(ubicacion + "/" + fileResoluciones, true);
                    //----------------------DATOS FINALES DEL ARCHIVO---------------------------------------------------------------------------------
                    //Numero de registros longitud 5 numerico
                    string tmpfinal = completarLongitudCadenas(numRegistros.ToString(), 5, "0");
                    linea = tmpfinal + ",";

                    //Suma de registros longitud 8 numerico
                    //tmpfinal = completarLongitudCadenas(sumRegistros.ToString(), 8, "0");
                    tmpfinal = sumRegistros.ToString();
                    linea = linea + tmpfinal + ",";

                    //Numero de oficio longitud 10 alfanumerico
                    tmpfinal = completarLongitudCadenas(texNumeroOficio.Text.Trim(), 10, " ");
                    linea = linea + tmpfinal + ",";

                    //Codigo de cheqeo longitud 4 numerico
                    linea = linea + completarLongitudCadenas(getCodigoChequeo(codchequeo), 4, "0");

                    infoResoluciones.WriteLine(linea);
                    infoResoluciones.Close();
                }
                else
                {
                    MessageBox.Show("No se encontraron resoluciones sin alcoholemia faltantes", "Informacion!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void setPlanosPagoFaltantes()
        {
            int numRegistros = 0;
            
            string fec1 = funciones.formatFecha(calFechaIni.SelectionRange.Start.ToString().Remove(10, calFechaIni.SelectionRange.Start.ToString().Length - 10));
            string fec2 = funciones.formatFecha(calFechaFin.SelectionRange.Start.ToString().Remove(10, calFechaFin.SelectionRange.Start.ToString().Length - 10));
            
            viewPagosFaltantesCarga viewPagosFal = new viewPagosFaltantesCarga();
            transitoComp transito = new transitoComp();
            planosSimit planos_Simit = new planosSimit();
            planoRecaudos planos_recaudo = new planoRecaudos();
            double sumRegistros = 0;
            double totalrecuado = 0;
            int tiporecaudo = 0;
            ServiciosViewPagosFaltantesCargaService mySerFaltaPago = WS.ServiciosViewPagosFaltantesCargaService();
            ServiciosGeneralesCompService mySerGen = WS.ServiciosGeneralesCompService();
            ServiciosGeneralesService serviciosGenerales = WS.ServiciosGeneralesService();
            transito = mySerGen.getTransitoComp(transito);
            object[] listaPagosFaltantes;
            if (busquedaPorNroComparendo)
            {
                viewPagosFal.NUMEROCOMPARENDO = texNumeroComparendo2.Text;
                listaPagosFaltantes = mySerFaltaPago.getViewPagosFaltantesCarga(viewPagosFal);
            }
            else
            {
                if (cheInfractor2.Checked)
                {
                    infractorComp infractor = buscaInfractor(int.Parse(comTipoDocumento2.SelectedValue.ToString()), texIdentificacion2.Text);
                    if (infractor != null)
                    {
                        viewPagosFal.NROIDENTIFICACION = infractor.NROIDENTIFICACION;
                        listaPagosFaltantes = mySerFaltaPago.getViewPagosFaltantesCarga(viewPagosFal);
                    }
                    else
                    {
                        listaPagosFaltantes = null;
                    }
                }
                else
                {
                    listaPagosFaltantes = mySerFaltaPago.getViewPagosFaltantesCarga(viewPagosFal);
                }
            }
            string linea = "";
            fileRecaudos = transito.NIT + "rec.txt";
            int codchequeo = 0;
            StreamWriter infoPagos;
            if (listaPagosFaltantes != null)
            {
                foreach (viewPagosFaltantesCarga pagosFaltantes in listaPagosFaltantes)
                {
                    infoPagos = new StreamWriter(ubicacion + "/" + fileRecaudos, true);
                    numRegistros++;
                    //----------------------------linea 1 ENCABEZADO
                    //1. Numero de cuenta que reporta el movimiento longitud 15 alfanumerico
                    linea = linea + ",";

                    //2. Fecha desde para este periodo longitud 10 alfanumerico
                    DateTime fecha = Convert.ToDateTime(calFechaIni.SelectionRange.Start.ToString().Remove(10, calFechaIni.SelectionRange.Start.ToString().Length - 10));
                    string fec = completarLongitudCadenas(fecha.ToString("dd/MM/yyyy"), 15, " ");
                    linea = linea + fec + ",";

                    //3. Fecha hasta el periodo longitud 10 alfanumerico
                    fecha = Convert.ToDateTime(calFechaFin.SelectionRange.Start.ToString().Remove(10, calFechaFin.SelectionRange.Start.ToString().Length - 10));
                    fec = completarLongitudCadenas(fecha.ToString("dd/MM/yyyy"), 15, " ");
                    linea = linea + fec + ",";

                    //4. Codigo divipo de secretaria longitud 8 numerico
                    if (transito.ID_CIUDAD > 0)
                    {
                        ciudadComp ciudad = new ciudadComp();
                        ciudad.ID_CIUDAD = transito.ID_CIUDAD;
                        ciudad = (ciudadComp)((object[])serviciosAccesoriasComp.getCiudadComp(ciudad))[0];
                        if (ciudad != null && ciudad.ID_CIUDAD > 0)
                        {
                            string tmp = getDivisionPolitica(ciudad.ID_DEPTO.ToString(), ciudad.CODCIUDAD.Trim());
                            tmp = limpiarString(tmp);
                            linea = linea + tmp + ",";
                        }
                        else
                        {
                            linea = linea + ",";
                        }
                    }

                    //5. Tipo de recaudo que se hace longitud 1 numerico
                    linea = linea + "1,";

                    ///---------------------------linea 2 DETALLE
                    //1. Consecutivo de registro longitud 5 numerico
                    if (numRegistros > 19999)
                        numRegistros = 1;
                    linea = numRegistros.ToString() + ",";

                    //2. Fecha contable de la transaccion longitud 10 alfanumerico
                    if (pagosFaltantes.FECHAPAGO == null)
                    {
                        linea = linea + ",";
                    }
                    else
                    {
                        fecha = DateTime.Parse(pagosFaltantes.FECHAPAGO);
                        string tmp = completarLongitudCadenas(fecha.ToString("dd/MM/yyyy"), 10, " ");
                        linea = linea + tmp + ",";
                    }

                    //3. Hora de transaccion longitud 5 alfanumerico
                    if (pagosFaltantes.HORAREGISTRO == null)
                    {
                        linea = linea + ",";
                    }
                    else
                    {
                        linea = linea + pagosFaltantes.HORAREGISTRO + ",";
                    }

                    //4. Fecha Real Transaccion longitud 10 alfanumerico
                    if (pagosFaltantes.FECHAPAGO == null)
                    {
                        linea = linea + ",";
                    }
                    else
                    {
                        fecha = DateTime.Parse(pagosFaltantes.FECHAPAGO);
                        string tmp = completarLongitudCadenas(fecha.ToString("dd/MM/yyyy"), 10, " ");
                        linea = linea + tmp + ",";
                    }

                    //5. Codigo canal origen longitud 4 numerico
                    linea = linea + "0,";

                    //6. Descripcion del origen longitud 40 alfanumerico
                    string desc = completarLongitudCadenas("TAQUILLA DE TRANSITO", 40, " ");
                    linea = linea + desc + ",";

                    //7. Total efectivo longitud 12 numerico
                    if (pagosFaltantes.VALORFORMAPAGO < 0 && pagosFaltantes.ID_TIPOPAGO <= 0)
                    {
                        linea = linea + ",";
                    }
                    else
                    {
                        string tmp;
                        if (pagosFaltantes.ID_TIPOPAGO == 1)
                        {
                            tmp = limpiarString(pagosFaltantes.VALORFORMAPAGO.ToString());
                            tmp = completarLongitudCadenas(tmp, 12, "0");
                            totalrecuado = pagosFaltantes.VALORFORMAPAGO;
                            linea = linea + tmp + ",";
                        }
                    }

                    //8. Total cheque longitud 12 numerico
                    if (pagosFaltantes.VALORFORMAPAGO < 0 && pagosFaltantes.ID_TIPOPAGO <= 0)
                    {
                        string tmp;
                        if (pagosFaltantes.ID_TIPOPAGO == 2)
                        {
                            tmp = limpiarString(pagosFaltantes.VALORFORMAPAGO.ToString());
                            tmp = completarLongitudCadenas(tmp, 12, "0");
                            totalrecuado = totalrecuado + pagosFaltantes.VALORFORMAPAGO;
                            linea = linea + tmp + ",";
                        }
                    }

                    //9. Total recaudo longitud 12 numerico
                    desc = completarLongitudCadenas(totalrecuado.ToString(), 12, "0");
                    linea = linea + desc + ",";

                    //10. Numero de comparendo, resolucion, o liquidacion longitud 15 alfanumerico
                    if (pagosFaltantes.ID <= 0)
                    {
                        linea = linea + ",";
                    }
                    else
                    {
                        string tmp;
                        //string tmp = limpiarString(pagos.NUMEROCOMPARENDO);
                        //tmp = completarLongitudCadenas(tmp, 15, " ");
                        //linea = linea + tmp + ",";
                        resolucionesSimit myResSimit = new resolucionesSimit();
                        myResSimit.IDINFRACCION = pagosFaltantes.ID;
                        //ServiciosGeneralesCompService mySerGen = WS.ServiciosGeneralesCompService();
                        myResSimit = mySerGen.getResolucionSimit(myResSimit);
                        if (myResSimit.NR != null)
                        {
                            tiporecaudo = 3;
                            tmp = limpiarString(myResSimit.NR);
                            tmp = completarLongitudCadenas(tmp, 15, " ");
                            linea = linea + tmp + ",";
                        }
                        else
                        {
                            tiporecaudo = 1;
                            tmp = limpiarString(pagosFaltantes.NUMEROCOMPARENDO.Trim());
                            tmp = completarLongitudCadenas(tmp, 15, " ");
                            linea = linea + tmp + ",";
                        }
                    }

                    //11. Comparendo policia de carretera longitud 1 alfanumerico
                    if (pagosFaltantes.POLCA == null)
                    {
                        linea = linea + "N,";
                    }
                    else
                    {
                        if (pagosFaltantes.POLCA.Equals("Si"))
                        {
                            linea = linea + "S,";
                        }
                        else
                        {
                            linea = linea + "N,";
                        }
                    }

                    //12. Numero identificacion infractor longitud 15 alfanumerico
                    if (pagosFaltantes.NROIDENTIFICACION == null)
                    {
                        linea = linea + ",";
                    }
                    else
                    {
                        string tmp = limpiarString(pagosFaltantes.NROIDENTIFICACION.Trim());
                        tmp = completarLongitudCadenas(tmp, 15, " ");
                        linea = linea + tmp;
                    }

                    //13. Tipo de recaudo longitud 2 numerico
                    if (pagosFaltantes.ID <= 0)
                    {
                        linea = linea + ",";
                    }
                    else
                    {
                        linea = linea + tiporecaudo.ToString() + ",";
                    }

                    //14. Codigo divipo de la secretaria longitud 8 alfanumerico
                    if (transito.NIT == null)
                    {
                        linea = linea + ",";
                    }
                    else
                    {
                        string tmp = limpiarString(transito.NIT.Trim());
                        tmp = completarLongitudCadenas(tmp, 8, " ");
                        linea = linea + transito.NIT;
                    }

                    //15. Numero de consignacion longitud 15 alfanumerico
                    if (pagosFaltantes.NROCONSIGNACIONBANCO != null)
                    {
                        string tmp = limpiarString(pagosFaltantes.NROCONSIGNACIONBANCO.Trim());
                        tmp = completarLongitudCadenas(tmp, 15, " ");
                        linea = linea + pagosFaltantes.NROCONSIGNACIONBANCO;
                    }
                    infoPagos.WriteLine(linea);
                    infoPagos.Close();
                    codchequeo = codchequeo + calcularASCIICadena(linea);
                }
                infoPagos = new StreamWriter(ubicacion + "/" + fileRecaudos, true);
                //----------------------DATOS FINALES DEL ARCHIVO---------------------------------------------------------------------------------
                //Numero de registros longitud 5 numerico
                string tmpfinal = completarLongitudCadenas(numRegistros.ToString(), 5, "0");
                linea = tmpfinal + ",";

                //Suma de registros longitud 8 numerico
                //tmpfinal = completarLongitudCadenas(sumRegistros.ToString(), 8, "0");
                tmpfinal = sumRegistros.ToString();
                linea = linea + tmpfinal + ",";

                //Numero de oficio longitud 10 alfanumerico
                tmpfinal = completarLongitudCadenas(texNumeroOficio.Text, 10, " ");
                linea = linea + tmpfinal + ",";

                //Codigo de cheqeo longitud 4 numerico
                linea = linea + completarLongitudCadenas(getCodigoChequeo(codchequeo), 4, "0");

                infoPagos.WriteLine(linea);
                infoPagos.Close();
            }
            else
            {
                MessageBox.Show("No hay pagos faltantes", "Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void texNumeroOficio_KeyPress(object sender, KeyPressEventArgs e)
        {
            funciones.esNumero(e);
            funciones.lanzarTapConEnter(e);
        }

        private void texNumeroOficio2_KeyPress(object sender, KeyPressEventArgs e)
        {
            funciones.esNumero(e);
            funciones.lanzarTapConEnter(e);
        }

        private void almacenarComparendoCargadoSimit(viewComparendosFechas viewCompPorFechasTmp, int idPlanosSimit)
        {
            comparendosCargaAlSimit myCompCargaSimit = new comparendosCargaAlSimit();
            ServiciosComparendosCargaSimitService mySerCompSimit = WS.ServiciosComparendosCargaSimitService();
            myCompCargaSimit.ID_COMPARENDOCARGA = viewCompPorFechasTmp.ID_COMPARENDO;
            myCompCargaSimit.ID_PLANOSSIMIT = idPlanosSimit;
            myCompCargaSimit.NROCOMPARENDO = viewCompPorFechasTmp.NUMEROCOMPARENDO;
            myCompCargaSimit.REPORTADO_A_SIMIT = "S";  //POR DEFECTO SE COLOCA EN SI CADA QUE SE REGISTRA;
            myCompCargaSimit = mySerCompSimit.createComparendosCargaAlSimit(myCompCargaSimit, WS.MyUsuario.ID_USUARIO, WS.Funciones().obtenerDirIp(), WS.Funciones().obtenerHostName());
        }

        //private void almacenarArchivosPlanosComparendos(string registro, int idSimit)
        //{
        //    planoComparendo planos_comparendo = new planoComparendo();
        //    planoComparendo plano_comparendoRegistrado;
        //    planos_comparendo.REGISTRO = registro;
        //    planos_comparendo.ID_PLANOSIMIT = idSimit;

        //    plano_comparendoRegistrado = createPlanosComparendo(planos_comparendo);
        //}

        private planoComparendo almacenarArchivosPlanosComparendos(string registro, int idSimit)
        {
            planoComparendo planos_comparendo = new planoComparendo();
            planoComparendo plano_comparendoRegistrado;
            planos_comparendo.REGISTRO = registro;
            planos_comparendo.ID_PLANOSIMIT = idSimit;

            plano_comparendoRegistrado = createPlanosComparendo(planos_comparendo);
            return plano_comparendoRegistrado;
        }

        public void almacenarArchivosPlanosResoluciones(string registro, int idSimit)
        {
            planoResoluciones planos_resoluciones;
            planos_resoluciones = new planoResoluciones();
            planos_resoluciones.ID_PLANOSIMIT = idSimit;
            planos_resoluciones.REGISTRO = registro;
            createPlanosResoluciones(planos_resoluciones);
        }

        public void almacenarArchivosPlanosRecaudo(string registro, int idSimit)
        {
            planoRecaudos planos_recaudo = new planoRecaudos();
            planos_recaudo.REGISTRO = registro;
            planos_recaudo.ID_PLANOSIMIT = idSimit;
            createPlanosRecaudos(planos_recaudo);
        }

        public string getCodigoChequeo(int numero)
        {
            string codigo = "";
            //int sumacaracteres = 0;
            bool esMul = false;
            int cont = 0;
            //SABER SI ES MULTIPLO DE 10000
            while (esMul != true)
            {
                //numero = numero - cont;
                esMul = esMultiplo((numero - cont), 10000);
                if (!esMul)
                {
                    cont++;
                }
            }
            codigo = cont.ToString();
            return codigo;
        }

        public bool esMultiplo(int n1, int n2)
        {
            bool esMultiplo = false;
            if (n1 % n2 == 0)
            {
                esMultiplo = true;
            }
            return esMultiplo;
        }

        public int calcularASCIICadena(string cadena)
        {
            int sumcadena = 0;
            //Coger cada caracter (char) de la cadena
            foreach (char caracteres in cadena.ToCharArray())
            {
                //Conversión de cada caracter a su equivalente ASCII. Se convierte el char a int
                int valorascii = (int)caracteres;
                sumcadena = sumcadena + valorascii;
            }
            return sumcadena;
        }

        void datRangos_SelectionChanged(object sender, System.EventArgs e)
        {
            if (datRangos.DataSource != null)
            {
                DataGridViewRow dtRow = datRangos.CurrentRow;
                rangoInicial = dtRow.Cells["RANGOINICIAL"].Value.ToString();
                rangoFinal = dtRow.Cells["RANGOFINAL"].Value.ToString();
            }
        }

        private void butCargarListado_Click(object sender, EventArgs e)
        {
            try
            {
                cargaDeArchivosNroComp = true;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    StreamReader archivocomp = new StreamReader(openFileDialog1.FileName, Encoding.ASCII);
                    string linea = "";
                    string nrocomparendo;
                    while (archivocomp.Peek() >= 0)
                    {
                        linea = archivocomp.ReadLine();
                        nrocomparendo = linea;
                        if (nrocomparendo != null)
                        {
                            listaNrosComparendos.Add(nrocomparendo);
                        }
                        else
                        {
                            MessageBox.Show("No se pudo leer el número de comparendo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Debes seleccionar un archivo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cargaDeArchivosNroComp = false;
                }
            }
            catch (Exception exp)
            {                
                MessageBox.Show("Error desconocido realizando la funcionalidad! " + exp.Message);
            }
        }


        #region Eventos Keypress
            private void texIdentificacion_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.esNumero(e);
                funciones.lanzarTapConEnter(e);
            }

            private void texNumeroComparendo_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.esNumero(e);
            }

            private void texIdentificacion2_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.esNumero(e);
                funciones.lanzarTapConEnter(e);
            }

            private void texNumeroComparendo2_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.esNumero(e);
            }

            private void cheComparendos_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }

            private void cheRecaudos_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }

            private void cheTodasResoluciones_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }

            private void cheResolucionesAlcoholemia_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }

            private void cheResolucionesSinAlcoholemia_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }

            private void cheInfractor_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }

            private void comTipoIdentificacion_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }

            private void chePorNumeroComparendo_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }

            private void cheComparendosPagados_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }

            private void cheComparendos2_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }

            private void cheRecaudos2_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }

            private void cheTodasResoluciones2_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }

            private void cheUnicamenteAlcoholemia2_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }

            private void cheResolucionesSinAlcoholemia2_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }

            private void cheInfractor2_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }

            private void comTipoDocumento2_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }

            private void cheNumeroComparendo2_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }

            private void chkComparendosPagadosCarga_KeyPress(object sender, KeyPressEventArgs e)
            {
                funciones.lanzarTapConEnter(e);
            }
        #endregion
    }

}

