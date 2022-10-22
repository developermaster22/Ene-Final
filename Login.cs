using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prueba_Ene
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        public string Control_login(string usuario, string password)
        {
            Data_usuario users = new Data_usuario();
            string Rpta = "";
            Pro_usuario datos_usuarios = null;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password))
            {
                Rpta = "Debe llenar todos los campos";
            }
            else
            {
                datos_usuarios = users.Login_user(usuario);

                if (datos_usuarios == null)
                {
                    Rpta = "El usuario no existe";
                }
                else
                {
                    if (datos_usuarios.password != password)
                    {
                        Rpta = "El usuario y/o contraseña no coinciden";
                    }
                }
            }
            return Rpta;
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string usuario = txt_usuario.Text;
            string password = txt_password.Text;

            try
            {
                string Rpta = Control_login(usuario, password);

                if (Rpta.Length > 0)
                {
                    MessageBox.Show(Rpta, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    Registro form = new Registro();//si es correcto lo mande operaciones
                    form.Visible = true;
                    this.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
