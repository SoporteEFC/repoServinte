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
using LibreriasSintratServiciosCuposTrans;

namespace TransportePublico.servicios.cupos
{
    public partial class cuposporempresa : Form
    {
        ServiciosCuposTransService clienteCuposTrans;
        empresasdeServicioTrans newempresa;
        public cuposporempresa()
        {
            InitializeComponent();
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
            Object[] listat = (Object[])clienteCuposTrans.getTipoVehiculoTrans(tipo);
            if (listat != null)
            {
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
            clienteCuposTrans = WS.ServiciosCuposTransService();
            empresasdeServicioTrans empresa = new empresasdeServicioTrans();
            newempresa = new empresasdeServicioTrans();
            Funciones funciones = WS.Funciones();
            ArrayList Campos = new ArrayList();
            Campos.Add("SIGLA = SIGLA");
            Campos.Add("NOMBRE = NOMBRE");
            Object[] Empresas = (Object[])clienteCuposTrans.getTEmpresasServicio(empresa);
            buscador buscador = new buscador(Empresas, Campos, "Empresas", null);

            if (buscador.ShowDialog() == DialogResult.OK)
            {
                newempresa = (empresasdeServicioTrans)funciones.listToEmpresaServicio(buscador.Seleccion);
                siglaempresa.Text = newempresa.SIGLA;
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
            Funciones funciones=WS.Funciones();
            clienteCuposTrans = WS.ServiciosCuposTransService();
            rangoCuposVehiculoPublicoTrans nuevorango = new rangoCuposVehiculoPublicoTrans();
            //nuevorango.CUPOSASIGNADOS = rangodecupos.Text;
            nuevorango.FECHARESOLUCION = fecharesolucion.Text;
            nuevorango.IDEMPRESATRANSP = newempresa.ID_EMPSERVICIO;
            nuevorango.IDTIPOVEHICULO=Int32.Parse(tipovehiculo.SelectedValue.ToString());
            nuevorango.NRORESOLUCION = numeroresolucion.Text;
            nuevorango.OBSERVACION = observacion.Text;

            String cadenarangos = rangodecupos.Text, asignados = "", noasignados="";
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

            if (noasignados != "")
            {
                //MessageBox.Show("Podrán ser asignados los siquientes cupos = " + asignados + " No se podrán asignar = " + noasignados);
            }

            nuevorango.CUPOSASIGNADOS = asignados;

            if (asignados != "")
            {
                int inserta = 0;
                int insrang = clienteCuposTrans.crearCuposEmpresa(nuevorango);
                if (insrang>0)
                {
                    ArrayList arraysignables = funciones.getRow(asignados.ToString(), ',');
                    for (int e = 0; e < arraysignables.Count;e++ )
                    {
                        clienteCuposTrans = WS.ServiciosCuposTransService();
                        detalleRangoCupoTrans nuevodetalle = new detalleRangoCupoTrans();
                        nuevodetalle.ASIGNADO = "F";
                        nuevodetalle.IDRANGOCUPO = insrang;
                        nuevodetalle.NROCUPO = arraysignables[e].ToString();

                        Boolean insdeta=clienteCuposTrans.crearDetalleCuposEmpresa(nuevodetalle);
                        if (insdeta==true)
                        {
                            inventarioCuposTrans inventarioe = new inventarioCuposTrans();
                            inventarioe.DISPONIBLE = "T";
                            inventarioe.ID_TIPOVEHICULO = Int32.Parse(tipovehiculo.SelectedValue.ToString());
                            inventarioe.NROCUPO = arraysignables[e].ToString();
                            
                            Object[] linventario = clienteCuposTrans.getSInventarioCupos(inventarioe);
                            if (linventario != null && linventario.Length>=0)
                            {
                                inventarioCuposTrans inventarioeditar = new inventarioCuposTrans();
                                inventarioeditar=(inventarioCuposTrans)linventario[0];
                                inventarioeditar.DISPONIBLE = "F";
                                inventarioeditar.ID_EMPRESAASIGNADA = newempresa.ID_EMPSERVICIO;
                                
                                Boolean editcup=clienteCuposTrans.editarCupos(inventarioeditar);
                                if (editcup == true)
                                {
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
