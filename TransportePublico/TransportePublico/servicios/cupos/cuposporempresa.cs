using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TransportePublico;
using LibreriasSintrat.ServiciosCuposTrans;
using LibreriasSintrat.utilidades;
using TransitoPrincipal;
using LibreriasSintrat.ServiciosLogs;
using LibreriasSintrat.ServiciosUsuarios;
using TransportePublico.utilidades;

//cupos empresa

namespace TransportePublico.servicios.cupos
{
    public partial class cuposporempresa : Form
    {
        ServiciosCuposTransService clienteCuposTrans;
        empresasdeServicioTrans newempresa;
        ServiciosLogsService serviciosLogs;
        usuarios usuarioSistema;
 
        public cuposporempresa(usuarios user)
        {
            InitializeComponent();
            serviciosLogs = WS.ServiciosLogsService();
            usuarioSistema = user;
        }
        public void limpiar() 
        {
            siglaempresa.Clear();
            nombreempresa.Clear();
            rangodecupos.Clear();
            numeroresolucion.Clear();
            observacion.Clear();
        }

        private void cuposporempresa_Load(object sender, EventArgs e)
        {
            tipoVehiculoTrans tipo = new tipoVehiculoTrans();
            clienteCuposTrans = WS.ServiciosCuposTransService();
            Funciones funciones = WS.Funciones();
            logs tmpLog = new logs();
            tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
            tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
            tmpLog.OBJETO = "TIPOVEHICULO";
            tmpLog.MODULO = "TPUBLICO";
            tmpLog.TIPO_TRANSACCION = "SELECT";
            TimeSpan TS; 
            DateTime dt1 = DateTime.Now;

            string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(tipo.GetType(), new object[] { tipo });
            tmpLog.ESTADO_ANTERIOR = objetoAnalizado;

            Object[] listat = (Object[])clienteCuposTrans.getTipoVehiculoTrans(tipo);
            
            if (listat != null)
            {
                DateTime dt2 = DateTime.Now;
                TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
                tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;
                
                serviciosLogs.crearRegistroLog(tmpLog);
                
                tipovehiculo.DataSource = null;
                tipovehiculo.DisplayMember = "NOMBRE";
                tipovehiculo.ValueMember = "ID";
                funciones.llenarCombo(tipovehiculo, listat);
            }
            siglaempresa.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnbuscarempresa_Click(object sender, EventArgs e)
        {
            buscarEmpresa();
        }

        public void buscarEmpresa()
        {
            logs tmpLog = new logs();
            tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
            tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
            tmpLog.OBJETO = "EMPRESASDESERVICIO";
            tmpLog.MODULO = "TPUBLICO";
            tmpLog.TIPO_TRANSACCION = "SELECT";
            TimeSpan TS; 
            DateTime dt1 = DateTime.Now;
            
            clienteCuposTrans = WS.ServiciosCuposTransService();
            empresasdeServicioTrans empresa = new empresasdeServicioTrans();
            newempresa = new empresasdeServicioTrans();
            Funciones funciones = WS.Funciones();
            ArrayList Campos = new ArrayList();
            Campos.Add("SIGLA = SIGLA");
            Campos.Add("NOMBRE = NOMBRE");
            Campos.Add("NIT = NIT");

            string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(empresa.GetType(), new object[] { empresa });
            tmpLog.ESTADO_ANTERIOR = objetoAnalizado;

            Object[] Empresas = (Object[])clienteCuposTrans.getTEmpresasServicio(empresa);

            DateTime dt2 = DateTime.Now;
            TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
            tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;
            serviciosLogs.crearRegistroLog(tmpLog);
            
            buscador buscador = new buscador(Empresas, Campos, "Empresas", null);

            if (buscador.ShowDialog() == DialogResult.OK)
            {
                newempresa = (empresasdeServicioTrans)funciones.listToEmpresaServicio(buscador.Seleccion);
                siglaempresa.Text = newempresa.NIT;
                nombreempresa.Text = newempresa.NOMBRE;
            }


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            validaciones();
        }

        private void validaciones()
        {
            if(newempresa==null)
            {
                MessageBox.Show("Debe seleccionar una empresa","Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
                buscarEmpresa();
            }
            else if(Int32.Parse(tipovehiculo.SelectedIndex.ToString()) < 0)
            {
                MessageBox.Show("Debe seleccionar un tipo de vehículo","Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else if (rangodecupos.Text == "")
            {
                MessageBox.Show("Debe ingresar un valor para el Rango de Cupos", "Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
                rangodecupos.Focus();
            }
            else
            {
                guardarCupos();
            }
        }

        private void guardarCupos()
        {
            logs tmpLog = new logs();
            tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
            tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
            tmpLog.OBJETO = "T_INVENTARIOCUPOS";
            tmpLog.MODULO = "TPUBLICO";
            tmpLog.TIPO_TRANSACCION = "SELECT";
            TimeSpan TS;
            DateTime dt1 = DateTime.Now;

            Funciones funciones = WS.Funciones();
            clienteCuposTrans = WS.ServiciosCuposTransService();
            rangoCuposVehiculoPublicoTrans nuevorango = new rangoCuposVehiculoPublicoTrans();

            //nuevorango.CUPOSASIGNADOS = rangodecupos.Text;
        
            nuevorango.FECHARESOLUCION = funciones.convFormatoFecha(fecharesolucion.Text, "MM/dd/yyyy");
            nuevorango.IDEMPRESATRANSP = newempresa.ID_EMPSERVICIO;
            nuevorango.IDTIPOVEHICULO = Int32.Parse(tipovehiculo.SelectedValue.ToString());
            nuevorango.NRORESOLUCION = numeroresolucion.Text;
            nuevorango.OBSERVACION = observacion.Text;

            string cadenarangos = rangodecupos.Text; 
            string asignados = "";
            string noasignados="";

            ArrayList arrayrangos = funciones.getRow(cadenarangos.ToString(), ';');

            for (int p = 0; p < arrayrangos.Count;p++ )
            {
                ArrayList arraycupos = funciones.getRow(arrayrangos[p].ToString(), '-');

                if (arraycupos.Count > 1)
                {
                    if (Int32.Parse(arraycupos[0].ToString()) < Int32.Parse(arraycupos[1].ToString()))
                    {
                        for (int n = Int32.Parse(arraycupos[0].ToString()); n <= Int32.Parse(arraycupos[1].ToString()); n++)
                        {
                            inventarioCuposTrans inventarioe = new inventarioCuposTrans();

                            inventarioe.ID_TIPOVEHICULO = Int32.Parse(tipovehiculo.SelectedValue.ToString());
                            inventarioe.NROCUPO = n.ToString();
                            inventarioe.DISPONIBLE = "T";

                            Object[] listae = (Object[])clienteCuposTrans.getSInventarioCupos(inventarioe);

                            if (listae != null && listae.Length > 0)
                            {
                                DateTime dt2 = DateTime.Now;
                                TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
                                tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;

                                serviciosLogs.crearRegistroLog(tmpLog);

                                if (asignados == "")
                                {
                                    asignados = n.ToString();
                                }
                                else
                                {
                                    asignados = asignados + "," + n.ToString();
                                }
                            }
                            else
                            {
                                if (noasignados == "")
                                {
                                    noasignados = n.ToString();
                                }
                                else
                                {
                                    noasignados = noasignados + "," + n.ToString();
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por favor verifique la informacion del rango de cupos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        rangodecupos.Focus();
                    }
                }
                else
                {
                    inventarioCuposTrans inventarioe = new inventarioCuposTrans();

                    inventarioe.ID_TIPOVEHICULO = Int32.Parse(tipovehiculo.SelectedValue.ToString());
                    inventarioe.NROCUPO = arraycupos[0].ToString();
                    inventarioe.DISPONIBLE = "T";

                    Object[] listae = (Object[])clienteCuposTrans.getSInventarioCupos(inventarioe);

                    if (listae != null && listae.Length > 0)
                    {
                        DateTime dt2 = DateTime.Now;
                        TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
                        tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;

                        serviciosLogs.crearRegistroLog(tmpLog);

                        if (asignados == "")
                        {
                            asignados = arraycupos[0].ToString();
                        }
                        else
                        {
                            asignados = asignados + "," + arraycupos[0].ToString();
                        }
                    }
                    else
                    {
                        if (noasignados == "")
                        {
                            noasignados = arraycupos[0].ToString();
                        }
                        else
                        {
                            noasignados = noasignados + "," + arraycupos[0].ToString();
                        }
                    }
                }
            }

            string infoAsignacion = "";

            if (noasignados != "")
            {
               infoAsignacion = "\n No podrán ser asignados los siguientes cupos: " + noasignados;
            }
           
            nuevorango.CUPOSASIGNADOS = asignados;

            if (asignados != "")
            {
                infoAsignacion = "Podrán ser asignados los siquientes cupos:" + asignados + infoAsignacion;

                MessageBox.Show(infoAsignacion);
                
                int inserta = 0;
                
                logs tmpLog2 = new logs();
                tmpLog2.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                tmpLog2.ID_USUARIO = usuarioSistema.ID_USUARIO;
                tmpLog2.OBJETO = "T_RANGOCUPOSVEHPUBLICO";
                tmpLog2.MODULO = "TPUBLICO";
                tmpLog2.TIPO_TRANSACCION = "INSERT";
                TimeSpan TS2;
                DateTime dt12 = DateTime.Now;
            

                int insrang = clienteCuposTrans.crearCuposEmpresa(nuevorango);

                if (insrang > 0)
                {

                    DateTime dt22 = DateTime.Now;
                    TS2 = new TimeSpan(dt22.Ticks - dt12.Ticks);
                    tmpLog2.TIEMPO_EJECUCION = TS2.Milliseconds;
                    serviciosLogs.crearRegistroLog(tmpLog2);

                    ArrayList arraysignables = funciones.getRow(asignados.ToString(), ',');

                    for (int e = 0; e < arraysignables.Count;e++ )
                    {
                        logs tmpLog3 = new logs();
                        tmpLog3.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                        tmpLog3.ID_USUARIO = usuarioSistema.ID_USUARIO;
                        tmpLog3.OBJETO = "T_DETALLERANGOCUPO";
                        tmpLog3.MODULO = "TPUBLICO";
                        tmpLog3.TIPO_TRANSACCION = "INSERT";
                        TimeSpan TS3;
                        DateTime dt13 = DateTime.Now;

                        clienteCuposTrans = WS.ServiciosCuposTransService();
                        detalleRangoCupoTrans nuevodetalle = new detalleRangoCupoTrans();
                        nuevodetalle.ASIGNADO = "F";
                        nuevodetalle.IDRANGOCUPO = insrang;
                        nuevodetalle.NROCUPO = arraysignables[e].ToString();

                        Boolean insdeta=clienteCuposTrans.crearDetalleCuposEmpresa(nuevodetalle);

                        if (insdeta == true)
                        {
                            DateTime dt23 = DateTime.Now;
                            TS3 = new TimeSpan(dt23.Ticks - dt13.Ticks);
                            tmpLog3.TIEMPO_EJECUCION = TS3.Milliseconds;
                            serviciosLogs.crearRegistroLog(tmpLog3);

                            logs tmpLog4 = new logs();
                            tmpLog4.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                            tmpLog4.ID_USUARIO = usuarioSistema.ID_USUARIO;
                            tmpLog4.OBJETO = "T_INVENTARIOCUPOS";
                            tmpLog4.MODULO = "TPUBLICO";
                            tmpLog4.TIPO_TRANSACCION = "SELECT";
                            TimeSpan TS4;
                            DateTime dt14 = DateTime.Now;


                            inventarioCuposTrans inventarioe = new inventarioCuposTrans();
                            inventarioe.DISPONIBLE = "T";
                            inventarioe.ID_TIPOVEHICULO = Int32.Parse(tipovehiculo.SelectedValue.ToString());
                            inventarioe.NROCUPO = arraysignables[e].ToString();
                            
                            Object[] linventario = clienteCuposTrans.getSInventarioCupos(inventarioe);


                            if (linventario != null && linventario.Length>=0)
                            {
                                DateTime dt24 = DateTime.Now;
                                TS4 = new TimeSpan(dt24.Ticks - dt14.Ticks);
                                tmpLog4.TIEMPO_EJECUCION = TS4.Milliseconds;
                                serviciosLogs.crearRegistroLog(tmpLog4);

                                logs tmpLog5 = new logs();
                                tmpLog5.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                                tmpLog5.ID_USUARIO = usuarioSistema.ID_USUARIO;
                                tmpLog5.OBJETO = "T_INVENTARIOCUPOS";
                                tmpLog5.MODULO = "TPUBLICO";
                                tmpLog5.TIPO_TRANSACCION = "UPDATE";
                                TimeSpan TS5;
                                DateTime dt15 = DateTime.Now;


                                inventarioCuposTrans inventarioeditar = new inventarioCuposTrans();
                                inventarioeditar=(inventarioCuposTrans)linventario[0];
                                inventarioeditar.DISPONIBLE = "F";
                                inventarioeditar.ID_EMPRESAASIGNADA = newempresa.ID_EMPSERVICIO;
                                
                                Boolean editcup=clienteCuposTrans.editarCupos(inventarioeditar);
                                if (editcup == true)
                                {
                                    DateTime dt25 = DateTime.Now;
                                    TS5 = new TimeSpan(dt25.Ticks - dt15.Ticks);
                                    tmpLog5.TIEMPO_EJECUCION = TS5.Milliseconds;
                                    serviciosLogs.crearRegistroLog(tmpLog5);

                                    //MessageBox.Show("Cupo Modificado");
                                }
                                else
                                {
                                    //MessageBox.Show("Error en Modificación");
                                }
                            }

                            inserta++;
                        }
                    }
                }

                if (inserta > 0)
                {
                    MessageBox.Show("Registro Exitoso","Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    limpiar();
                }
                else
                {
                    MessageBox.Show("Error en Registro","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    limpiar();
                }
            }
            else
            {
                MessageBox.Show("No es posible asignar este rango de cupos para este tipo de vehiculo", "Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void rangodecupos_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones funciones = WS.Funciones();
            funciones.formatoRangos(e);
            funciones.lanzarTapConEnter(e);
        }

        private void numeroresolucion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones funciones = WS.Funciones();
            funciones.esNumero(e);
            funciones.lanzarTapConEnter(e);
        }

        private void siglaempresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                buscarEmpresa();
            }
        }

        private void tipovehiculo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones myFun = new Funciones();
            myFun.lanzarTapConEnter(e);
        }

        private void fecharesolucion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones myFun = new Funciones();
            myFun.lanzarTapConEnter(e);
        }
    }
}
