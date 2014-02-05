using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibreriasSintrat.ServiciosCuposTrans;
using LibreriasSintrat.utilidades;
using LibreriasSintrat.ServiciosLogs;
using LibreriasSintrat.ServiciosUsuarios;

using LibreriasSintrat.utilidades;

namespace TransportePublico.servicios.cupos
{
    public partial class inventariocupos : Form
    {
        ServiciosCuposTransService clienteCuposTrans;
        ServiciosLogsService serviciosLogs;
        usuarios usuarioSistema;

        public inventariocupos(usuarios user)
        {
            InitializeComponent();
            usuarioSistema = user;
            serviciosLogs = WS.ServiciosLogsService();
        }

        public void limpiar() 
        {
            rangoinicial.Clear();
            rangofinal.Clear();
        }

        private void inventariocupos_Load(object sender, EventArgs e)
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

            DateTime dt2 = DateTime.Now;
            TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
            tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;
            serviciosLogs.crearRegistroLog(tmpLog);

            if (listat != null)
            {
                tipovehiculo.DataSource = null;
                tipovehiculo.DisplayMember = "NOMBRE";
                tipovehiculo.ValueMember = "ID";
                funciones.llenarCombo(tipovehiculo, listat);
                tipovehiculo.Focus();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            validaciones();
        }

        private void validaciones()
        {
            if (tipovehiculo.SelectedIndex < 0)
            {
                MessageBox.Show("debe seleccionar un tipo de vehículo","Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
                tipovehiculo.Focus();
            }
            else if (rangoinicial.Text == "" && rangofinal.Text == "") 
            {
                MessageBox.Show("El Rango Inicial y el Rango final no tiene valores. Debe Ingresar datos", "Alto", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                rangoinicial.Focus();
            }
            else if (rangoinicial.Text == "")
            {
                MessageBox.Show("El campo Rango Inicial no puede ser vacio", "Alto", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                rangoinicial.Focus();
            }
            else if (rangofinal.Text == "")
            {
                MessageBox.Show("El campo Rango Final no puede ser vacio", "Alto", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                rangofinal.Focus();
            }
            else
            {
                validarCupos();
            }
        }

        private void validarCupos()
        {
            clienteCuposTrans = WS.ServiciosCuposTransService();
            inventarioCuposTrans inventarioi = new inventarioCuposTrans();
            inventarioCuposTrans inventariof = new inventarioCuposTrans();

            int idtipoveh = Int32.Parse(tipovehiculo.SelectedValue.ToString());
            int numrangoinicial = Int32.Parse(rangoinicial.Text);
            int numrangofinal = Int32.Parse(rangofinal.Text);

            if (numrangoinicial > numrangofinal)
            {
                MessageBox.Show("El valor del Rango Inicial no puede ser mayor al valor del Rango Final", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rangoinicial.Focus();
            }
            else
            {
                //T_INVENTARIOCUPOS
                logs tmpLog = new logs();
                tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
                tmpLog.OBJETO = "T_INVENTARIOCUPOS";
                tmpLog.MODULO = "TPUBLICO";
                tmpLog.TIPO_TRANSACCION = "SELECT";
                TimeSpan TS;
                DateTime dt1 = DateTime.Now;

                bool existencupos = clienteCuposTrans.validarRangoInventarioCupoEmpresa(numrangoinicial, numrangofinal, idtipoveh);

                string objetoAnalizado = numrangoinicial + "-" + numrangofinal;
                tmpLog.ESTADO_ANTERIOR = objetoAnalizado;

                DateTime dt2 = DateTime.Now;
                TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
                tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;
                serviciosLogs.crearRegistroLog(tmpLog);

                if (existencupos)
                {
                    MessageBox.Show("El rango de cupos ya ha sido asignado para este tipo de vehículo o hay cupos asignados dentro de este rango", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else 
                {
                    MessageBox.Show("Rango de cupos disponible", "Información",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);

                    guardarCupos();
                }
            }

            /*

            inventarioi.ID_TIPOVEHICULO = Int32.Parse(tipovehiculo.SelectedValue.ToString());
            inventarioi.NROCUPO = rangoinicial.Text;
            inventariof.ID_TIPOVEHICULO = Int32.Parse(tipovehiculo.SelectedValue.ToString());
            inventariof.NROCUPO = rangofinal.Text;

            Object[] listai = (Object[])clienteCuposTrans.getSInventarioCupos(inventarioi);
            Object[] listaf = (Object[])clienteCuposTrans.getSInventarioCupos(inventariof);*/

            /*if (Int32.Parse(rangoinicial.Text) > Int32.Parse(rangofinal.Text))
            {
                MessageBox.Show("El valor del Rango Inicial no puede ser mayor al valor del Rango Final", "Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                rangoinicial.Focus();
            }
            else if (listai != null && listai.Length > 0 || listaf != null && listaf.Length > 0)
            {
                MessageBox.Show("El rango de cupos ya ha sido asignado para este tipo de vehículo","Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                guardarCupos();
            }
             
             */
        }

        private void guardarCupos()
        {
            clienteCuposTrans = WS.ServiciosCuposTransService();

            int inserciones = 0;

            for (int q = Int32.Parse(rangoinicial.Text); q <= Int32.Parse(rangofinal.Text);q++ )
            {
                inventarioCuposTrans nuevoinventario = new inventarioCuposTrans();

                nuevoinventario.DISPONIBLE = "T";
                nuevoinventario.ID_EMPRESAASIGNADA = 0;
                nuevoinventario.ID_TIPOVEHICULO = Int32.Parse(tipovehiculo.SelectedValue.ToString());
                nuevoinventario.NROCUPO = q.ToString();

                logs tmpLog = new logs();
                tmpLog.FECHA_HORA = DateTime.Now.ToString("dd/MM/yyyy");
                tmpLog.ID_USUARIO = usuarioSistema.ID_USUARIO;
                tmpLog.OBJETO = "T_INVENTARIOCUPOS";
                tmpLog.MODULO = "TPUBLICO";
                tmpLog.TIPO_TRANSACCION = "INSERT";
                TimeSpan TS;
                DateTime dt1 = DateTime.Now;

                string objetoAnalizado = AnalizadorDeObjetos.analizarObjeto(nuevoinventario.GetType(), new object[] { nuevoinventario });
                tmpLog.ESTADO_ANTERIOR = objetoAnalizado;

                Boolean inscupo = clienteCuposTrans.crearCupos(nuevoinventario);

                DateTime dt2 = DateTime.Now;
                TS = new TimeSpan(dt2.Ticks - dt1.Ticks);
                tmpLog.TIEMPO_EJECUCION = TS.Milliseconds;
                serviciosLogs.crearRegistroLog(tmpLog);

                if (inscupo == true)
                {
                    inserciones++;
                }
            }

            if (inserciones > 0)
            {
                MessageBox.Show("Registro Exitoso","Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
                limpiar();
            }
            else
            {
                MessageBox.Show("Error al Registrar Cupos","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void rangoinicial_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones funciones = WS.Funciones();
            funciones.esNumero(e);
            funciones.lanzarTapConEnter(e);
        }

        private void rangofinal_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones funciones = WS.Funciones();
            funciones.esNumero(e);
            funciones.lanzarTapConEnter(e);
        }

        private void tipovehiculo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones myFun = new Funciones();
            myFun.lanzarTapConEnter(e);
        }
    }
}
