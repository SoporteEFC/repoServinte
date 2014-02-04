using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using Comparendos.ServiciosUsuarios;
using Comparendos.utilidades;

namespace Comparendos
{
    public partial class inicio : Form
    {
        public usuarios myUser;
        private bool biomet;
        private int intentos;
        public usuarios usuarioCambioClave;
        Log log = new Log();

        public inicio()
        {
            InitializeComponent();
            log = new Log();
            intentos = 0;

            //tema
            switch (WS.Funciones().tema)
            {
                case Tema.ServiciosIntegrales:
                    this.pictureBox1.Image = global::Comparendos.Properties.Resources.logueoSIATTc;
                    break;
                default:
                    this.pictureBox1.Image = global::Comparendos.Properties.Resources.logueoSINTRATc;
                    break;
            }
        }

        public inicio(usuarios usuarioLogueado)
        {
            InitializeComponent();
            intentos = 0;
        }

        private void fLogin_Load(object sender, EventArgs e)
        {
            myUser = new usuarios();
            //String valor;
            //NameValueCollection sAll;
            //sAll = ConfigurationManager.AppSettings;
            //MessageBox.Show("hola: "+sAll.Count.ToString(), "hola");
            //valor = ConfigurationManager.AppSettings["biometrico"];            
            //tipoAutenticacion(valor);
            verificarConexion();
            
        }

        public void verificarConexion()
        {
            try
            {
                ServiciosUsuariosService mySerUsu = WS.ServiciosUsuariosService();
                mySerUsu.probarConexion(true);
            }
            catch (Exception exc)
            {
                log.escribirError(exc.ToString(), this.GetType());
                MessageBox.Show("El servidor de servicios web no esta disponible", "Error al contactar el Servidor");
                this.DialogResult = DialogResult.Cancel;
            }
        }

        public bool tipoAutenticacion(String valor)
        {
            if (valor == "si")
                return true;
            return false;
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            myUser.LOGIN = txtLogin.Text;
            myUser.CLAVE = txtPass.Text;
            ServiciosUsuariosService mySerUsu = WS.ServiciosUsuariosService();
            myUser = mySerUsu.validarUsuarioComp(myUser);
            if (myUser != null && myUser.ID_USUARIO > 0)
            {
                if (biomet)
                {
                    biometrico();
                }
                if (myUser.ESTADO != "A")
                {
                    MessageBox.Show("El usuario ingresado no esta activo, Cerrando aplicacion", "Usuario no Activo");
                    myUser = null;
                    this.DialogResult = DialogResult.Cancel;
                }
                btnIniciar.Visible = false;
                txtLogin.Enabled = false;
                txtPass.Enabled = false;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                txtPass.Text = "";
                myUser = new usuarios();
                intentos++;
                if (intentos > 2)
                {
                    this.DialogResult = DialogResult.Cancel;
                    MessageBox.Show("La cantidad de intentos fallidos ha superado el limite", "Cerrando la aplicacion");
                }
                else
                    MessageBox.Show("Error al iniciar sesion verifique su login y password", "No se Inicio sesion");
            }
        }

        public void biometrico()
        {
            MessageBox.Show("","Aquí va el llamado a la parte de biometrico");
        }

        private void txtLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPass.Focus();
            }
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnIniciar.Focus();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; 
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox2.Image = Comparendos.Properties.Resources.cerrar2; 
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = Comparendos.Properties.Resources.cerrar; 
        }
    }
}
