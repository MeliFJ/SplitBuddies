using Projecto.Controlador;
using System;
using System.Windows.Forms;

namespace Projecto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string identificacion = txtbxIdentificacion.Text;
            string password = txtbxContrasena.Text;

            //Validar si el usuario es valido
            bool usuarioValido=LoginControlador.ValidarLogin(identificacion, password);
            if (usuarioValido) {
                this.LbErrorLogin.ForeColor = System.Drawing.Color.Green;
                LbErrorLogin.Text = "Login existoso";
                
            }
            else {
                this.LbErrorLogin.ForeColor = System.Drawing.Color.Red;
                LbErrorLogin.Text = "Login fallido verifique la identificacion y la contraseña";
            }
        }
    }
}
