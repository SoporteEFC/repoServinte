//librerias externas
using LibreriasSintrat;
using LibreriasSintrat.utilidades;
using LibreriasSintrat.ServiciosComparendos;
using LibreriasSintrat.ServiciosUsuarios;
using LibreriasSintrat.ServiciosLiquidacionComp;
using LibreriasSintrat.ServiciosLiquidadorComparendos;
using LibreriasSintrat.ServiciosConfiguraciones;
using LibreriasSintrat.ServiciosDocumentos;
using LibreriasSintrat.ServiciosAccesoriasComp;
using LibreriasSintrat.ServiciosGeneralesComp;
using LibreriasSintrat.ServiciosConfiguraciones;

//librerias sistema
using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//clases aplicación
using Comparendos.servicios.reportes.reporteGeneral;
using Comparendos.utilidades;
using TransitoPrincipal;

namespace Comparendos.servicios.reportes
{

    public partial class fReportesGenerales : Form
    {
        Funciones funciones;
        ServiciosDocumentosService serviciosDocumentos;
        ServiciosAccesoriasCompService serviciosAccesoriasComp;
        ServiciosGeneralesCompService serviciosGeneralesComp;
        ServiciosConfiguracionesService serviciosConfiguraciones;

        usuarios myUsuario;
        LibreriasSintrat.ServiciosLiquidadorComparendos.comparendoComp comparendo;

        string nroRecibo;

        //String[] tablasPorPrioridad = { "ESTADOCOM", "INFRACCIONES", "INFRACTOR", "COMPARENDO", "HISTORICOSESTADOSCOM", "RECIBOSCOMPARENDO" };
        String[] tablasPorPrioridad;
        ArrayList alistTablasSel;

        //Rango dias reportes
        int numDias = 0;

        //verificación datos consulta      
        bool codInfVacio = true; //codigo INFRACCION
        bool nuevoCodInfVacio = true; //nuevo cod INFRACCION
        bool placaVacio = true; // placa COMPARENDO
        bool nrocompVacio = true; // numero COMPARENDO 
        bool identVacio = true; // identificacion INFRACTOR
        bool estadoVacio = true; // estado ESTADOCOM     

        public fReportesGenerales(usuarios myUsuario)
        {
            InitializeComponent();

            funciones = new Funciones();

            serviciosDocumentos = WS.ServiciosDocumentosService();
            serviciosAccesoriasComp = WS.ServiciosAccesoriasCompService();
            serviciosConfiguraciones = WS.ServiciosConfiguracionesService();

            comparendo = new LibreriasSintrat.ServiciosLiquidadorComparendos.comparendoComp();
            funciones.llenarCombo(cmbTipoDocInfra, serviciosAccesoriasComp.obtenerTiposDocumento());

            object[] listEstadosComp = serviciosAccesoriasComp.listarEstadosComp();

            funciones.llenarCombo(cmbEstado, listEstadosComp);

            this.myUsuario = myUsuario;

            tablasPrioridad tablas = new tablasPrioridad();
            alistTablasSel = new ArrayList();

            tablas.llenarTablaPrioridad("ESTADOCOM");
            tablas.llenarTablaPrioridad("INFRACCIONES");
            tablas.llenarTablaPrioridad("INFRACTOR");
            tablas.llenarTablaPrioridad("COMPARENDO");
            tablas.llenarTablaPrioridad("HISTORICOESTADOSCOM");
            //tablas.llenarTablaPrioridad("RECIBOSCOMPARENDO");

            tablasPorPrioridad = tablas.establecerOrdenTabla(tablasPrioridad.ORDEN.ASCENDENTE);

            //chkEstado.Checked = true;

            //cmbEstado.SelectedValue = 4;
            cmbEstado.SelectedIndex = 1;

            //chkFecComp.Checked = true;

            //chkRangoDiasReporte.Checked = true;
            cmbRangoFechaReportes.SelectedIndex = 5;
        }

        //Funciones varias
        #region Funciones varias

        //funciones OLD
        #region funciones OLD

        private String crearSql(String criterios)
        {
            String sql;
            sql = "SELECT DISTINCT " +
                  "COMPARENDO.NUMEROCOMPARENDO," +
                  "COMPARENDO.FECHACOMPARENDO," +
                  "COMPARENDO.PLACA," +
                  "INFRACCIONES.COD_INFRACCION," +
                  "INFRACCIONES.NUEVO_CODIGO," +
                  "ESTADOCOM.DESCRIPCION AS ESTADO," +
                  "INFRACCIONCOMPARENDO.VALORINFRACCION," +
                  "INFRACTOR.NOMBRES," +
                  "INFRACTOR.APELLIDOS," +
                  "INFRACTOR.NROIDENTIFICACION," +
                  "INFRACCIONES.DESCRIPCION AS INFRACCION " +
                  "FROM COMPARENDO " +
                  "LEFT OUTER JOIN INFRACTOR ON (COMPARENDO.ID_INFRACTOR = INFRACTOR.ID_INFRACTOR) " +
                  "LEFT OUTER JOIN INFRACCIONCOMPARENDO ON (COMPARENDO.ID_COMPARENDO = INFRACCIONCOMPARENDO.IDCOMPARENDO) " +
                  "LEFT OUTER JOIN INFRACCIONES ON (INFRACCIONCOMPARENDO.IDINFRACCION = INFRACCIONES.ID_INFRACCION) " +
                  "LEFT OUTER JOIN ESTADOCOM ON (INFRACCIONCOMPARENDO.IDESTADO = ESTADOCOM.ID_ESTADO) " +
                  "LEFT OUTER JOIN DATOSLIQUIDACION ON (DATOSLIQUIDACION.idinfraccion = INFRACCIONCOMPARENDO.id) " +
                  "LEFT OUTER JOIN LIQUIDACION ON (LIQUIDACION.idliquidacion = DATOSLIQUIDACION.idliquidacion) " +
                  "LEFT OUTER JOIN RECIBOSCOMPARENDO ON (RECIBOSCOMPARENDO.idliquidacion = LIQUIDACION.idliquidacion) " +
                  "LEFT OUTER JOIN HISTORICOESTADOSCOM ON (INFRACCIONCOMPARENDO.ID = HISTORICOESTADOSCOM.ID_INFRACCIONCOMPARENDO) " + //cambiar por HISTORIALCOMPARENDO
                  "WHERE 1 = 1 " +
                  criterios;

            return sql;
        }

        private void generarConsulta()
        {
            DataTable dt = new DataTable();
            String query;
            Object[] tmp;
            ArrayList campos;
            query = crearSql(getCriterios());
            tmp = serviciosDocumentos.verificarConsultaComp(query);
            campos = funciones.ObjectToArrayList(tmp);
            tmp = serviciosDocumentos.executeQuery(query);
            gridResultados.DataSource = funciones.getData(funciones.ObjectToArrayList(tmp), campos);
            gridResultados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            campos = funciones.asignarNombres(campos);
            lblCantReg.Text = gridResultados.RowCount.ToString();
            //funciones.configurarGrilla(gridResultados, campos);
        }

        private String getCriterios()
        {
            String criterios = "";

            if (chkPlaca.Checked)
                criterios = criterios + " AND (COMPARENDO.PLACA = '" + txtPlaca.Text + "') ";
            if (chkNroComp.Checked)
                criterios = criterios + " AND (COMPARENDO.NUMEROCOMPARENDO = '" + txtNroComparendo.Text + "') ";
            if (chkTipoDoc.Checked)
                criterios = criterios + " AND (INFRACTOR.ID_DOCTO =" + cmbTipoDocInfra.SelectedValue + ")";
            if (chkTipoDoc.Checked)
                criterios = criterios + " AND (INFRACTOR.NROIDENTIFICACION = '" + txtIdentInfrac.Text + "') ";
            if (chkEstado.Checked)
                criterios = criterios + " AND (ESTADOCOM.ID_ESTADO = " + cmbEstado.SelectedValue + ")";
            if (chkCodInfrac.Checked)
                criterios = criterios + " AND (INFRACCIONES.COD_INFRACCION = '" + txtInfraccion.Text + "') ";
            if (chkFecComp.Checked)
                criterios = criterios + " AND (COMPARENDO.FECHACOMPARENDO BETWEEN '" + txtFecCompDesde.Value.ToString("MM/dd/yyyy") + "' AND '" + txtFecCompHasta.Value.ToString("MM/dd/yyyy") + "')";
            //if (chkRangoFechaReportes.Checked)
            //    criterios = criterios + " AND (RECIBOSCOMPARENDO.FECHAPAGO BETWEEN '" + txtFecPagoCompIni.Value.ToString("MM/dd/yyyy") + "' AND '" + txtFecPagoCompFin.Value.ToString("MM/dd/yyyy") + "')";
            if (chkFecAnula.Checked)
                criterios = criterios + " AND (HISTORICOESTADOSCOM.FECHA BETWEEN '" + txtFecAnulaIni.Value.ToString("MM/dd/yyyy") + "' AND '" + txtFecAnulaFin.Value.ToString("MM/dd/yyyy") + "')";
            if (chkNuevoCod.Checked)
                criterios = criterios + " AND (INFRACCIONES.NUEVO_CODIGO = '" + txtnuevainfraccion.Text + "')";

            return criterios;
        }

        void buscarDatos()
        {
            if (txtnuevainfraccion.Text.Equals("") && chkNuevoCod.Checked == true)
            {
                object[] listinfracciones;
                LibreriasSintrat.ServiciosAccesoriasComp.infraccionesComp infracciones = new LibreriasSintrat.ServiciosAccesoriasComp.infraccionesComp();
                listinfracciones = serviciosAccesoriasComp.listarInfraccionesComp();
                ArrayList campos = new ArrayList();
                campos.Add("NUEVO_CODIGO = Nuevo Código");

                if (listinfracciones != null)
                {
                    buscador myBuscador = new buscador(listinfracciones, campos, null, null);

                    if (myBuscador.ShowDialog() == DialogResult.OK)
                    {
                        infracciones = (LibreriasSintrat.ServiciosAccesoriasComp.infraccionesComp)funciones.listToInfraccion(myBuscador.Seleccion);
                    }

                    myBuscador.Dispose();
                }

                txtnuevainfraccion.Text = infracciones.NUEVO_CODIGO;
            }

            if (txtInfraccion.Text.Equals("") && chkCodInfrac.Checked == true)
            {
                object[] listinfracciones;
                LibreriasSintrat.ServiciosAccesoriasComp.infraccionesComp infracciones = new LibreriasSintrat.ServiciosAccesoriasComp.infraccionesComp();
                listinfracciones = serviciosAccesoriasComp.listarInfraccionesComp();
                ArrayList campos = new ArrayList();

                campos.Add("COD_INFRACCION = Código Infracción");

                if (listinfracciones != null)
                {
                    buscador myBuscador = new buscador(listinfracciones, campos, null, null);
                    if (myBuscador.ShowDialog() == DialogResult.OK)
                    {
                        infracciones = (LibreriasSintrat.ServiciosAccesoriasComp.infraccionesComp)funciones.listToInfraccion(myBuscador.Seleccion);
                    }

                    myBuscador.Dispose();
                }

                txtInfraccion.Text = infracciones.COD_INFRACCION;
            }

            generarConsulta();
        }

        #endregion

        /// <summary>
        /// Realiza una limpieza del formulario de modo parcial o total.
        /// </summary>
        private void limpiarFormulario(string tipo)
        {
            if (tipo == "parcial")
            {
                codInfVacio = true;
                nuevoCodInfVacio = true;
                placaVacio = true;
                nrocompVacio = true;
                identVacio = true;
                estadoVacio = true;
            }

            if (tipo == "todo")
            {
                codInfVacio = true;
                nuevoCodInfVacio = true;
                placaVacio = true;
                nrocompVacio = true;
                identVacio = true;
                estadoVacio = true;

                txtIdentInfrac.Text = "";
                cmbTipoDocInfra.SelectedIndex = -1;
                txtInfraccion.Text = "";
                txtNroComparendo.Text = "";
                txtnuevainfraccion.Text = "";
                txtPlaca.Text = "";

                chkPlaca.Checked = false;
                chkNroComp.Checked = false;
                chkTipoDoc.Checked = false;
                chkEstado.Checked = false;
                chkCodInfrac.Checked = false;
                chkFecComp.Checked = false;
                //chkFecPago.Checked = false;
                chkFecAnula.Checked = false;
                //chkFecReciboPago.Checked = false;
                chkNuevoCod.Checked = false;

                gridResultados.DataSource = null;

                lblCantReg.Text = "0";

                chkEstado.Checked = true;

                cmbEstado.SelectedIndex = 1;
                //cmbEstado.SelectedValue = 4;

                chkFecComp.Checked = true;

                cmbRangoFechaReportes.SelectedIndex = 5;
            }
        }

        /// <summary>
        /// Valida si el usuario ha seleccionado al menos un criterio de búsqueda y cuyo valor no sea trivial
        /// </summary>
        private bool validarSeleccionCriterios()
        {
            bool res = false;

            bool cplaca = chkPlaca.Checked;
            bool cnrocomp = chkNroComp.Checked;
            bool ctipoDoc = chkTipoDoc.Checked;
            bool cestado = chkEstado.Checked;
            bool ccodinfr = chkCodInfrac.Checked;
            bool cfeccomp = chkFecComp.Checked;
            //bool cfecpago = chkFecPago.Checked;
            bool cfecanul = chkFecAnula.Checked;
            bool cnuevoco = chkNuevoCod.Checked;

            bool reschecked = false;

            reschecked = (cplaca == true) || (cnrocomp == true) ||
                         (ctipoDoc == true) || (cestado == true) ||
                         (ccodinfr == true) || (cfeccomp == true) ||
                //(cfecpago == true) || (cfecanul == true) ||
                         (cfecanul == true) || (cnuevoco == true) ? true : false;

            if (reschecked)
            {
                //validación seleccion de combos fecha

                if (cfeccomp)
                {
                    DateTime dtimeFechaInicial = Convert.ToDateTime(txtFecCompDesde.Text);
                    DateTime dtimeFechaFinal = Convert.ToDateTime(txtFecCompHasta.Text);

                    TimeSpan ts = dtimeFechaFinal - dtimeFechaInicial;

                    int diferenciaDias = ts.Days;

                    if (dtimeFechaFinal < dtimeFechaInicial)
                        return res;
                    else if (diferenciaDias <= numDias)
                    {
                        alistTablasSel.Add("COMPARENDO");
                    }
                    else return res;
                }

                if (cfecanul)
                {
                    DateTime dtimeFechaInicial = Convert.ToDateTime(txtFecAnulaIni.Text);
                    DateTime dtimeFechaFinal = Convert.ToDateTime(txtFecAnulaFin.Text);

                    TimeSpan ts = dtimeFechaFinal - dtimeFechaInicial;

                    int diferenciaDias = ts.Days;

                    if (dtimeFechaFinal < dtimeFechaInicial)
                        return res;
                    else if (diferenciaDias <= numDias)
                    {
                        alistTablasSel.Add("HISTORICOESTADOSCOM");
                    }
                    else return res;
                }

                //validación valores de criterios ingresados 

                if (cplaca)
                {
                    if (String.IsNullOrEmpty(txtPlaca.Text))
                        return res;
                    else
                    {
                        placaVacio = false;
                        alistTablasSel.Add("COMPARENDO");
                    }
                }

                if (cnrocomp)
                {
                    if (String.IsNullOrEmpty(txtNroComparendo.Text))
                        return res;
                    else
                    {
                        nrocompVacio = false;
                        alistTablasSel.Add("COMPARENDO");
                    }
                }

                if (ctipoDoc)
                {
                    if (cmbTipoDocInfra.SelectedIndex > -1 && !String.IsNullOrEmpty(txtIdentInfrac.Text))
                    {
                        identVacio = false;
                        alistTablasSel.Add("INFRACTOR");
                    }
                    else return res;
                }

                if (cestado)
                {
                    if (cmbEstado.SelectedIndex < 0)
                        return res;
                    else
                    {
                        estadoVacio = false;
                        alistTablasSel.Add("ESTADOCOM");
                    }
                }

                if (ccodinfr)
                {
                    alistTablasSel.Add("INFRACCIONES");

                    if (!String.IsNullOrEmpty(txtInfraccion.Text))
                    {
                        codInfVacio = false;
                    }
                }
                else codInfVacio = false;

                if (cnuevoco)
                {
                    alistTablasSel.Add("INFRACCIONES");

                    if (!String.IsNullOrEmpty(txtnuevainfraccion.Text))
                    {
                        nuevoCodInfVacio = false;
                    }
                }
                else nuevoCodInfVacio = false;

                res = reschecked;
            }

            return res;
        }

        /// <summary>
        /// Valida si el criterio código y nuevo código de infracción están chequeados y los valores correspondientes a los campos estan vacíos. 
        /// Si es true, en cada caso, se levanta buscador para colocar los valores correspondientes.
        /// </summary>
        private void buscarDatosInfracciones()
        {
            if (nuevoCodInfVacio)
            {
                object[] listinfracciones;

                LibreriasSintrat.ServiciosAccesoriasComp.infraccionesComp infracciones = new LibreriasSintrat.ServiciosAccesoriasComp.infraccionesComp();
                listinfracciones = serviciosAccesoriasComp.listarInfraccionesComp();

                ArrayList campos = new ArrayList();
                campos.Add("NUEVO_CODIGO = Nuevo Código");

                if (listinfracciones != null)
                {
                    buscador myBuscador = new buscador(listinfracciones, campos, null, null);

                    if (myBuscador.ShowDialog() == DialogResult.OK)
                    {
                        infracciones = (LibreriasSintrat.ServiciosAccesoriasComp.infraccionesComp)funciones.listToInfraccion(myBuscador.Seleccion);
                    }

                    myBuscador.Dispose();
                }

                txtnuevainfraccion.Text = infracciones.NUEVO_CODIGO;
            }

            if (codInfVacio)
            {
                object[] listinfracciones;

                LibreriasSintrat.ServiciosAccesoriasComp.infraccionesComp infracciones = new LibreriasSintrat.ServiciosAccesoriasComp.infraccionesComp();
                listinfracciones = serviciosAccesoriasComp.listarInfraccionesComp();

                ArrayList campos = new ArrayList();
                campos.Add("COD_INFRACCION = Código Infracción");

                if (listinfracciones != null)
                {
                    buscador myBuscador = new buscador(listinfracciones, campos, null, null);
                    if (myBuscador.ShowDialog() == DialogResult.OK)
                    {
                        infracciones = (LibreriasSintrat.ServiciosAccesoriasComp.infraccionesComp)funciones.listToInfraccion(myBuscador.Seleccion);
                    }

                    myBuscador.Dispose();
                }

                txtInfraccion.Text = infracciones.COD_INFRACCION;
            }
        }

        /// <summary>
        /// Establece un segmento de la consulta SQL referida a los valores de los criterios de búsqueda escogidos por el usuario. 
        /// </summary>
        private String establecerSQLValoresCriterios()
        {
            String sqlvalcriterios = "";

            string motor = serviciosConfiguraciones.leerRegistroIni("MOTOR");

            if (!placaVacio)
                sqlvalcriterios = " (COMPARENDO.PLACA = '" + txtPlaca.Text + "') ";

            if (!nrocompVacio)
            {
                if (!String.IsNullOrEmpty(sqlvalcriterios))
                    sqlvalcriterios = sqlvalcriterios + " AND (COMPARENDO.NUMEROCOMPARENDO = '" + txtNroComparendo.Text + "') ";
                else sqlvalcriterios = " (COMPARENDO.NUMEROCOMPARENDO = '" + txtNroComparendo.Text + "') ";
            }

            if (!identVacio)
            {
                if (!String.IsNullOrEmpty(sqlvalcriterios))
                {
                    sqlvalcriterios = sqlvalcriterios + " AND (INFRACTOR.ID_DOCTO =" + cmbTipoDocInfra.SelectedValue + ")";
                    sqlvalcriterios = sqlvalcriterios + " AND (INFRACTOR.NROIDENTIFICACION = '" + txtIdentInfrac.Text + "') ";
                }
                else
                {
                    sqlvalcriterios = " (INFRACTOR.ID_DOCTO =" + cmbTipoDocInfra.SelectedValue + ")";
                    sqlvalcriterios = sqlvalcriterios + " AND (INFRACTOR.NROIDENTIFICACION = '" + txtIdentInfrac.Text + "') ";
                }
            }

            if (!estadoVacio)
            {
                if (!String.IsNullOrEmpty(sqlvalcriterios))
                    sqlvalcriterios = sqlvalcriterios + " AND (ESTADOCOM.ID_ESTADO = " + cmbEstado.SelectedValue + ")";
                else
                    sqlvalcriterios = " (ESTADOCOM.ID_ESTADO = " + cmbEstado.SelectedValue + ")";
            }

            if (!String.IsNullOrEmpty(txtInfraccion.Text))
            {
                if (!String.IsNullOrEmpty(sqlvalcriterios))
                    sqlvalcriterios = sqlvalcriterios + " AND (INFRACCIONES.COD_INFRACCION = '" + txtInfraccion.Text + "') ";
                else sqlvalcriterios = " (INFRACCIONES.COD_INFRACCION = '" + txtInfraccion.Text + "') ";
            }

            if (chkFecComp.Checked)
            {
                if (motor.ToUpper() != "ORACLE")
                {
                    if (!String.IsNullOrEmpty(sqlvalcriterios))
                        sqlvalcriterios = sqlvalcriterios + " AND (COMPARENDO.FECHACOMPARENDO BETWEEN '" + txtFecCompDesde.Value.ToString("MM/dd/yyyy") + "' AND '" + txtFecCompHasta.Value.ToString("MM/dd/yyyy") + "')";
                    else sqlvalcriterios = " (COMPARENDO.FECHACOMPARENDO BETWEEN '" + txtFecCompDesde.Value.ToString("MM/dd/yyyy") + "' AND '" + txtFecCompHasta.Value.ToString("MM/dd/yyyy") + "')";
                }
                else
                {
                    if (!String.IsNullOrEmpty(sqlvalcriterios))
                        sqlvalcriterios = sqlvalcriterios + " AND (COMPARENDO.FECHACOMPARENDO BETWEEN '" + txtFecCompDesde.Value.ToString("dd/MM/yyyy") + "' AND '" + txtFecCompHasta.Value.ToString("dd/MM/yyyy") + "')";
                    else sqlvalcriterios = " (COMPARENDO.FECHACOMPARENDO BETWEEN '" + txtFecCompDesde.Value.ToString("dd/MM/yyyy") + "' AND '" + txtFecCompHasta.Value.ToString("dd/MM/yyyy") + "')";

                }
            }

            if (chkFecAnula.Checked)
            {
                if (motor.ToUpper() != "ORACLE")
                {
                    if (!String.IsNullOrEmpty(sqlvalcriterios))
                        sqlvalcriterios = sqlvalcriterios + " AND (HISTORICOESTADOSCOM.FECHA BETWEEN '" + txtFecAnulaIni.Value.ToString("MM/dd/yyyy") + "' AND '" + txtFecAnulaFin.Value.ToString("MM/dd/yyyy") + "')";
                    else sqlvalcriterios = " (HISTORICOESTADOSCOM.FECHA BETWEEN '" + txtFecAnulaIni.Value.ToString("MM/dd/yyyy") + "' AND '" + txtFecAnulaFin.Value.ToString("MM/dd/yyyy") + "')";
                }
                else 
                {
                    if (!String.IsNullOrEmpty(sqlvalcriterios))
                        sqlvalcriterios = sqlvalcriterios + " AND (HISTORICOESTADOSCOM.FECHA BETWEEN '" + txtFecAnulaIni.Value.ToString("dd/MM/yyyy") + "' AND '" + txtFecAnulaFin.Value.ToString("dd/MM/yyyy") + "')";
                    else sqlvalcriterios = " (HISTORICOESTADOSCOM.FECHA BETWEEN '" + txtFecAnulaIni.Value.ToString("dd/MM/yyyy") + "' AND '" + txtFecAnulaFin.Value.ToString("dd/MM/yyyy") + "')";
                }
            }

            if (!String.IsNullOrEmpty(txtnuevainfraccion.Text))
            {
                if (!String.IsNullOrEmpty(sqlvalcriterios))
                    sqlvalcriterios = sqlvalcriterios + " AND (INFRACCIONES.NUEVO_CODIGO = '" + txtnuevainfraccion.Text + "')";
                else sqlvalcriterios = " (INFRACCIONES.NUEVO_CODIGO = '" + txtnuevainfraccion.Text + "')";
            }

            return sqlvalcriterios;
        }

        /// <summary>
        /// Genera la consulta total del Reporte segun los criterios de busqueda y su prioridad
        /// </summary>
        private void generarSQLConsultaReporte(string nombreTabla, String sqlcriterios)
        {
            DataTable dtReporte = new DataTable();
            String SQLREPORTE;
            Object[] listResultados;
            ArrayList campos;

            SQLREPORTE = crearSQLReporte(nombreTabla, sqlcriterios);

            listResultados = serviciosDocumentos.verificarConsultaComp(SQLREPORTE);
            campos = funciones.ObjectToArrayList(listResultados);

            listResultados = serviciosDocumentos.executeQuery(SQLREPORTE);

            if (listResultados != null && listResultados.Length > 0)
            {
                gridResultados.DataSource = funciones.getData(funciones.ObjectToArrayList(listResultados), campos);
                gridResultados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                campos = funciones.asignarNombres(campos);
                lblCantReg.Text = gridResultados.RowCount.ToString();
            }
            else
            {
                funciones.mostrarMensaje("No se encontrarón resultados!", "W");

                gridResultados.DataSource = null;

                lblCantReg.Text = "0";
            }
        }

        private String crearSQLReporte(string nombreTablaFrom, string valcriterios)
        {
            string sqlencabezado = "";
            string sqlcontenido = "";

            String sqlReporteresultante = "";

            sqlencabezado = "SELECT DISTINCT " +
                             "COMPARENDO.NUMEROCOMPARENDO, " +
                             "COMPARENDO.FECHACOMPARENDO, " +
                             "COMPARENDO.PLACA, " +
                             "INFRACCIONES.COD_INFRACCION, " +
                             "INFRACCIONES.NUEVO_CODIGO, " +
                             "ESTADOCOM.DESCRIPCION AS ESTADO, " +
                             "INFRACCIONCOMPARENDO.VALORINFRACCION, " +
                             "INFRACTOR.NOMBRES, " +
                             "INFRACTOR.APELLIDOS, " +
                             "INFRACTOR.NROIDENTIFICACION, " +
                             "INFRACCIONES.DESCRIPCION AS INFRACCION ";

            sqlcontenido = obtenerContenidoSQlReporte(nombreTablaFrom);

            sqlReporteresultante = sqlencabezado + sqlcontenido + valcriterios;

            return sqlReporteresultante;
        }

        /// <summary>
        /// Obiene de las tablas asociadas a los criterios de búsqueda, seleccionados por el usuario, la tabla con mayor o menor prioridad para el From de la consulta SQL. 
        /// El valor de la prioridad lo da la posición del elemento en el arreglo.
        /// </summary>
        private String obtenerTablaPorPrioridad(ArrayList listTablasSel, bool mayor)
        {
            Funciones funciones = new Funciones();

            String nomTablaSel = "";

            int[] prioridades;

            prioridades = new int[listTablasSel.Count];

            for (int el = 0; el < listTablasSel.Count; el++)
            {
                string nomtablatmp = (string)listTablasSel[el];

                for (int el2 = 0; el2 < tablasPorPrioridad.Length; el2++)
                {
                    if (nomtablatmp == tablasPorPrioridad[el2])
                    {
                        prioridades[el] = el2;

                        break;
                    }
                }
            }

            if (mayor)
            {
                //El menor valor lleva la mas alta prioridad
                int menorvalor = funciones.obtenerMayorMenorValor(prioridades, 0);

                nomTablaSel = tablasPorPrioridad[menorvalor];
            }
            else
            {
                //El mayor valor lleva la mas baja prioridad
                int mayorvalor = funciones.obtenerMayorMenorValor(prioridades, 1);

                nomTablaSel = tablasPorPrioridad[mayorvalor];
            }

            return nomTablaSel;
        }

        public string obtenerContenidoSQlReporte(string nombreTabla)
        {
            string sqlres = "";

            switch (nombreTabla)
            {
                case "ESTADOCOM":

                    sqlres =

                    "FROM ESTADOCOM " +

                    "INNER JOIN INFRACCIONCOMPARENDO ON (ESTADOCOM.ID_ESTADO = INFRACCIONCOMPARENDO.IDESTADO) " +
                    "INNER JOIN INFRACCIONES ON (INFRACCIONCOMPARENDO.IDINFRACCION = INFRACCIONES.ID_INFRACCION) " +
                    "LEFT JOIN COMPARENDO ON (INFRACCIONCOMPARENDO.IDCOMPARENDO = COMPARENDO.ID_COMPARENDO) " +
                    "LEFT JOIN INFRACTOR ON (COMPARENDO.ID_INFRACTOR = INFRACTOR.ID_INFRACTOR) " +
                    "LEFT JOIN HISTORICOESTADOSCOM ON (INFRACCIONCOMPARENDO.ID = HISTORICOESTADOSCOM.ID_INFRACCIONCOMPARENDO) " +
                    "LEFT JOIN DATOSLIQUIDACION ON (INFRACCIONCOMPARENDO.ID = DATOSLIQUIDACION.IDINFRACCION) " +
                    "LEFT JOIN LIQUIDACION ON (DATOSLIQUIDACION.ID = LIQUIDACION.IDLIQUIDACION) "; // +
                    //"LEFT JOIN RECIBOSCOMPARENDO ON (LIQUIDACION.IDLIQUIDACION = RECIBOSCOMPARENDO.IDLIQUIDACION) ";

                    break;

                case "INFRACCIONES":

                    sqlres =

                    "FROM INFRACCIONES " +

                    "INNER JOIN INFRACCIONCOMPARENDO ON (INFRACCIONCOMPARENDO.IDINFRACCION = INFRACCIONES.ID_INFRACCION) " +
                    "INNER JOIN ESTADOCOM ON (ESTADOCOM.ID_ESTADO = INFRACCIONCOMPARENDO.IDESTADO) " +
                    "LEFT JOIN COMPARENDO ON (INFRACCIONCOMPARENDO.IDCOMPARENDO = COMPARENDO.ID_COMPARENDO) " +
                    "LEFT JOIN INFRACTOR ON (COMPARENDO.ID_INFRACTOR = INFRACTOR.ID_INFRACTOR) " +
                    "LEFT JOIN HISTORICOESTADOSCOM ON (INFRACCIONCOMPARENDO.ID = HISTORICOESTADOSCOM.ID_INFRACCIONCOMPARENDO) " +
                    "LEFT JOIN DATOSLIQUIDACION ON (INFRACCIONCOMPARENDO.ID = DATOSLIQUIDACION.IDINFRACCION) " +
                    "LEFT JOIN LIQUIDACION ON (DATOSLIQUIDACION.ID = LIQUIDACION.IDLIQUIDACION) "; // +
                    //"LEFT JOIN RECIBOSCOMPARENDO ON (LIQUIDACION.IDLIQUIDACION = RECIBOSCOMPARENDO.IDLIQUIDACION) ";

                    break;

                case "INFRACTOR":

                    sqlres =

                    "FROM INFRACTOR " +

                    "INNER JOIN COMPARENDO ON (COMPARENDO.ID_INFRACTOR = INFRACTOR.ID_INFRACTOR) " +
                    "INNER JOIN INFRACCIONCOMPARENDO ON (INFRACCIONCOMPARENDO.IDCOMPARENDO = COMPARENDO.ID_COMPARENDO) " +
                    "LEFT JOIN ESTADOCOM ON (ESTADOCOM.ID_ESTADO = INFRACCIONCOMPARENDO.IDESTADO) " +
                    "LEFT JOIN INFRACCIONES ON (INFRACCIONCOMPARENDO.IDINFRACCION = INFRACCIONES.ID_INFRACCION) " +
                    "LEFT JOIN HISTORICOESTADOSCOM ON (INFRACCIONCOMPARENDO.ID = HISTORICOESTADOSCOM.ID_INFRACCIONCOMPARENDO) " +
                    "LEFT JOIN DATOSLIQUIDACION ON (INFRACCIONCOMPARENDO.ID = DATOSLIQUIDACION.IDINFRACCION) " +
                    "LEFT JOIN LIQUIDACION ON (DATOSLIQUIDACION.ID = LIQUIDACION.IDLIQUIDACION) "; // +
                    //"LEFT JOIN RECIBOSCOMPARENDO ON (LIQUIDACION.IDLIQUIDACION = RECIBOSCOMPARENDO.IDLIQUIDACION) ";

                    break;

                case "HISTORICOESTADOSCOM":

                    sqlres =

                    "FROM HISTORICOESTADOSCOM " +

                    "INNER JOIN INFRACCIONCOMPARENDO ON (INFRACCIONCOMPARENDO.ID = HISTORICOESTADOSCOM.ID_INFRACCIONCOMPARENDO) " +
                    "INNER JOIN ESTADOCOM ON (ESTADOCOM.ID_ESTADO = INFRACCIONCOMPARENDO.IDESTADO) " +
                    "LEFT JOIN INFRACCIONES ON (INFRACCIONCOMPARENDO.IDINFRACCION = INFRACCIONES.ID_INFRACCION) " +
                    "LEFT JOIN COMPARENDO ON (INFRACCIONCOMPARENDO.IDCOMPARENDO = COMPARENDO.ID_COMPARENDO) " +
                    "LEFT JOIN INFRACTOR ON (COMPARENDO.ID_INFRACTOR = INFRACTOR.ID_INFRACTOR) " +
                    "LEFT JOIN DATOSLIQUIDACION ON (INFRACCIONCOMPARENDO.ID = DATOSLIQUIDACION.IDINFRACCION) " +
                    "LEFT JOIN LIQUIDACION ON (DATOSLIQUIDACION.ID = LIQUIDACION.IDLIQUIDACION) "; // +
                    //"LEFT JOIN RECIBOSCOMPARENDO ON (LIQUIDACION.IDLIQUIDACION = RECIBOSCOMPARENDO.IDLIQUIDACION) ";

                    break;

                case "RECIBOSCOMPARENDO":

                    sqlres =

                    "FROM RECIBOSCOMPARENDO " +

                    "INNER JOIN LIQUIDACION ON (LIQUIDACION.IDLIQUIDACION = RECIBOSCOMPARENDO.IDLIQUIDACION) " +
                    "INNER JOIN DATOSLIQUIDACION ON (DATOSLIQUIDACION.ID = LIQUIDACION.IDLIQUIDACION) " +
                    "LEFT JOIN INFRACCIONCOMPARENDO ON (INFRACCIONCOMPARENDO.ID = DATOSLIQUIDACION.IDINFRACCION) " +
                    "LEFT JOIN ESTADOCOM ON (ESTADOCOM.ID_ESTADO = INFRACCIONCOMPARENDO.IDESTADO) " +
                    "LEFT JOIN INFRACCIONES ON (INFRACCIONKCOMPARENDO.IDINFRACCION = INFRACCIONES.ID_INFRACCION) " +
                    "LEFT JOIN COMPARENDO ON (INFRACCIONCOMPARENDO.IDCOMPARENDO = COMPARENDO.ID_COMPARENDO) " +
                    "LEFT JOIN INFRACTOR ON (COMPARENDO.ID_INFRACTOR = INFRACTOR.ID_INFRACTOR) " +
                    "LEFT JOIN HISTORICOESTADOSCOM ON (INFRACCIONCOMPARENDO.ID = HISTORICOESTADOSCOM.ID_INFRACCIONCOMPARENDO) ";

                    break;

                default: //COMPARENDO

                    sqlres =

                    "FROM COMPARENDO " +

                    "INNER JOIN INFRACCIONCOMPARENDO ON (INFRACCIONCOMPARENDO.IDCOMPARENDO = COMPARENDO.ID_COMPARENDO) " +
                    "INNER JOIN INFRACTOR ON (COMPARENDO.ID_INFRACTOR = INFRACTOR.ID_INFRACTOR) " +
                    "INNER JOIN ESTADOCOM ON (ESTADOCOM.ID_ESTADO = INFRACCIONCOMPARENDO.IDESTADO) " +
                    "LEFT JOIN INFRACCIONES ON (INFRACCIONCOMPARENDO.IDINFRACCION = INFRACCIONES.ID_INFRACCION) " +
                    "LEFT JOIN HISTORICOESTADOSCOM ON (INFRACCIONCOMPARENDO.ID = HISTORICOESTADOSCOM.ID_INFRACCIONCOMPARENDO) " +
                    "LEFT JOIN DATOSLIQUIDACION ON (INFRACCIONCOMPARENDO.ID = DATOSLIQUIDACION.IDINFRACCION) " +
                    "LEFT JOIN LIQUIDACION ON (DATOSLIQUIDACION.ID = LIQUIDACION.IDLIQUIDACION) "; // +
                    //"LEFT JOIN RECIBOSCOMPARENDO ON (LIQUIDACION.IDLIQUIDACION = RECIBOSCOMPARENDO.IDLIQUIDACION) ";

                    break;
            }

            sqlres = sqlres + " WHERE ";

            return sqlres;
        }

        public void buscarGenerarConsulta()
        {
            limpiarFormulario("parcial");

            bool resval = validarSeleccionCriterios();

            if (resval)
            {
                string nombretablaprioridad = obtenerTablaPorPrioridad(alistTablasSel, true);

                buscarDatosInfracciones();

                string SQLCRITERIOS = establecerSQLValoresCriterios();

                generarSQLConsultaReporte(nombretablaprioridad, SQLCRITERIOS);
            }
            else
                funciones.mostrarMensaje("Uno o más criterios están seleccionados pero no está diligenciado correctamente su campo asociado. " +
                                         "Verifique que las fechas estén dentro del rango considerado", "W");
        }

        private void establecerRangoDiasInicial(int numDias)
        {
            txtFecCompDesde.Text = DateTime.Now.AddDays(-numDias).ToString();
            txtFecCompHasta.Text = DateTime.Now.ToString();

            txtFecAnulaIni.Text = DateTime.Now.AddDays(-numDias).ToString();
            txtFecAnulaFin.Text = DateTime.Now.ToString();
        }

        #endregion

        //Eventos formulario
        #region Eventos formulario

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            buscarGenerarConsulta();

            this.Cursor = Cursors.Arrow;
        }

        private void chkPlaca_CheckedChanged(object sender, EventArgs e)
        {
            txtPlaca.Enabled = chkPlaca.Checked;
        }

        private void chkNroComp_CheckedChanged(object sender, EventArgs e)
        {
            txtNroComparendo.Enabled = chkNroComp.Checked;
        }

        private void chkTipoDoc_CheckedChanged(object sender, EventArgs e)
        {
            cmbTipoDocInfra.Enabled = chkTipoDoc.Checked;
            txtIdentInfrac.Enabled = chkTipoDoc.Checked;
        }

        private void chkEstado_CheckedChanged(object sender, EventArgs e)
        {
            cmbEstado.Enabled = chkEstado.Checked;
        }

        private void chkCodInfrac_CheckedChanged(object sender, EventArgs e)
        {
            txtInfraccion.Enabled = chkCodInfrac.Checked;
        }

        private void chkFecComp_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFecComp.Checked)
            {
                txtFecCompDesde.Enabled = chkFecComp.Checked;
                txtFecCompHasta.Enabled = chkFecComp.Checked;
            }
            else
            {
                txtFecCompDesde.Enabled = chkFecComp.Checked;
                txtFecCompHasta.Enabled = chkFecComp.Checked;
                txtFecCompDesde.Text = DateTime.Now.Date.ToString();
                txtFecCompHasta.Text = DateTime.Now.Date.ToString();
            }
        }

        private void chkRangoDiasReporte_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRangoDiasReporte.Checked)
            {
                cmbRangoFechaReportes.Enabled = true;
            }
            else
            {
                cmbRangoFechaReportes.Enabled = false;

                cmbRangoFechaReportes.SelectedIndex = 5;
            }
        }

        private void chkFecAnula_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFecAnula.Checked)
            {
                txtFecAnulaIni.Enabled = chkFecAnula.Checked;
                txtFecAnulaFin.Enabled = chkFecAnula.Checked;
            }
            else
            {
                txtFecAnulaIni.Enabled = chkFecAnula.Checked;
                txtFecAnulaFin.Enabled = chkFecAnula.Checked;
                txtFecAnulaIni.Text = DateTime.Now.Date.ToString();
                txtFecAnulaFin.Text = DateTime.Now.Date.ToString();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();

            this.Cursor = Cursors.WaitCursor;

            if (saveFileDialog1.FileName != "")
                funciones.exportarDataGridViewAExcel(saveFileDialog1.FileName, "Reporte Comparendos", gridResultados);

            this.Cursor = Cursors.Arrow;

            funciones.mostrarMensaje("¡Proceso Realizado!", "I");
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //repGeneral rp = new repGeneral();
            //rp.SetDataSource(gridResultados.DataSource);
            //fVerReporte viewer = new fVerReporte((DataTable)gridResultados.DataSource); //TODO
            //viewer.Show();   
            //viewer.ShowDialog();

            datosRepGenerales dtRepGenerales = new datosRepGenerales();

            object[] datos = new object[8];
            datos[0] = ""; //Numero Comparendo
            datos[1] = ""; //Placa
            datos[2] = ""; //Codigo Infraccion
            datos[3] = ""; //Estado
            datos[4] = 0; //Valor Infraccion
            datos[5] = ""; //Nombres
            datos[6] = ""; //Apellidos
            datos[7] = ""; //Numero Identificacion

            DataTable dt = new DataTable();

            dt = (DataTable)gridResultados.DataSource;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                datos[0] = dt.Rows[i]["NUMEROCOMPARENDO"];
                datos[1] = dt.Rows[i]["PLACA"];
                datos[2] = dt.Rows[i]["COD_INFRACCION"];
                datos[3] = dt.Rows[i]["ESTADO"];
                datos[4] = dt.Rows[i]["VALORINFRACCION"];
                datos[5] = dt.Rows[i]["NOMBRES"];
                datos[6] = dt.Rows[i]["APELLIDOS"];
                datos[7] = dt.Rows[i]["NROIDENTIFICACION"];
                dtRepGenerales._datosRepGenerales.Rows.Add(datos);
            }

            //dtRepGenerales._datosRepGenerales.Rows.Add(gridResultados.DataSource);
            fVerReportesGenerales viewer = new fVerReportesGenerales(dtRepGenerales);
            viewer.Show();
        }

        private void chkNuevoCod_CheckedChanged(object sender, EventArgs e)
        {
            txtnuevainfraccion.Enabled = chkNuevoCod.Checked;
        }

        private void txtnuevainfraccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRealizarPago_Click(object sender, EventArgs e)
        {
            string numeroComparendo = "";

            if (gridResultados.SelectedRows.Count > 0)
                numeroComparendo = gridResultados.SelectedRows[0].Cells["NUMEROCOMPARENDO"].Value.ToString();

            servicios.liquidacion.PagarFactura frm = new Comparendos.servicios.liquidacion.PagarFactura(numeroComparendo, myUsuario);

            frm.ShowDialog();
        }

        void gridResultados_SelectionChanged(object sender, System.EventArgs e)
        {
            if (gridResultados.SelectedRows.Count > 0)
            {
                //changeState

                if (gridResultados.SelectedRows[0].Cells["Estado"].Value.ToString() == "LIQUIDADO")
                //if (gridResultados.SelectedRows[0].Cells["Estado"].Value.ToString() == "RESOLUCION")
                {
                    btnRealizarPago.Enabled = true;
                }
                else
                {
                    btnRealizarPago.Enabled = false;
                }

                //endChangeState
            }
        }

        private void txtNroComparendo_KeyPress(object sender, KeyPressEventArgs e)
        {
            funciones.esNumero(e);

            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                //buscarDatos();

                buscarGenerarConsulta();
            }
        }

        private void txtIdentInfrac_KeyPress(object sender, KeyPressEventArgs e)
        {
            funciones.esNumero(e);
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                //buscarDatos();

                buscarGenerarConsulta();
            }
        }

        private void txtPlaca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                //buscarDatos();

                buscarGenerarConsulta();
            }
        }

        private void txtInfraccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                //buscarDatos();

                buscarGenerarConsulta();
            }
        }

        private void txtnuevainfraccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                //buscarDatos();

                buscarGenerarConsulta();
            }
        }

        private void btnLimpiarFormulario_Click(object sender, EventArgs e)
        {
            limpiarFormulario("todo");
        }

        #endregion

        private void cmbRangoFechaReportes_SelectedValueChanged(object sender, EventArgs e)
        {
            numDias = int.Parse(cmbRangoFechaReportes.SelectedItem.ToString());

            //establecerRangoDiasInicial(numDias);
        }

        private void cmbTipoDocInfra_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }

    /// <summary>
    /// Clase Auxiliar para la organizacion de las prioridades de las tablas a consultar segun Formulario
    /// </summary>
    public class tablasPrioridad
    {
        ArrayList tablaPrioridadLista;

        public enum ORDEN
        {
            ASCENDENTE,
            DESCENDENTE
        };

        public tablasPrioridad()
        {
            tablaPrioridadLista = new ArrayList();
        }

        public void llenarTablaPrioridad(string nombreTabla)
        {
            tablaPrioridadLista.Add(nombreTabla);
        }

        public String[] establecerOrdenTabla(ORDEN orden)
        {
            String[] tablaOrdenada = null;
            ArrayList lisvalores = new ArrayList();

            if (tablaPrioridadLista.Count > 0)
            {
                if (orden == ORDEN.DESCENDENTE)
                {
                    tablaPrioridadLista.Reverse();
                }

                tablaOrdenada = tablaPrioridadLista.ToArray(typeof(string)) as String[];
            }

            return tablaOrdenada;
        }
    }
}
