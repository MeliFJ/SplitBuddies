using Projecto.Controlador;
using Projecto.Modelo;
using Projecto.src.Modelo;
using Projecto.src.Vista;
using Projecto.Vista;
using System;
using System.Windows.Forms;

namespace Projecto
{
    public partial class Form1 : Form
    {
        private readonly IGestorDatos gestorDatos;

        public Form1(IGestorDatos gestorDatos)
        {
            InitializeComponent();
            this.gestorDatos = gestorDatos;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new RegistrarUsuario().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string identificacion = txtbxIdentificacion.Text;
            string password = txtbxContrasena.Text;

            //Validar si el usuario es valido
            Usuario usuarioValido = LoginControlador.ValidarLogin(identificacion, password);
            if (usuarioValido != null)
            {
                MostrarGrupos form= new MostrarGrupos(gestorDatos, usuarioValido);
                form.Show();
                this.Hide();
            }
            else {
                this.LbErrorLogin.ForeColor = System.Drawing.Color.Red;
                LbErrorLogin.Text = "Login fallido verifique la identificacion y la contraseña";
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Usuario usuarioValido = new Usuario("116640546", "1234", "Melissa", "Fallas");
            Grupo grupo = new Grupo(1, "116640546", "116640546Inversion1", "Inversion1");
            FormReporte form = new FormReporte();
            form.Show();
            this.Hide();
        }
    }
}
