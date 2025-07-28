
using Controlador;
using Controlador.Interfaces;
using GestorDatos;
using GestorDatos.Interfaces;
using Modelo;

using System;
using System.Windows.Forms;
using WfVistaSplitBuddies.Vista;
namespace WfVistaSplitBuddies
{
    public partial class Form1 : Form
    {
        private readonly IGestorDatosUsuario gestorDatosUsuario;
        private readonly LoginControlador loginControlador;
        private readonly IGrupoControlador grupoControlador ;
        private readonly IUsuarioControlador usuarioControlador ;
        public Form1()
        {
            InitializeComponent();
            this.gestorDatosUsuario = new GestorDatosUsuario();
            loginControlador= new LoginControlador(gestorDatosUsuario);
            this.usuarioControlador = new UsuarioControlador(gestorDatosUsuario);
            this.grupoControlador = new GrupoControlador(new GestorDatosGrupos(), gestorDatosUsuario);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new RegistrarUsuario(usuarioControlador).Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string identificacion = txtbxIdentificacion.Text;
            string password = txtbxContrasena.Text;

            //Validar si el usuario es valido
            Usuario usuarioValido = loginControlador.ValidarLogin(identificacion, password);
            if (usuarioValido != null)
            {
                MostrarGrupos form= new MostrarGrupos(grupoControlador, usuarioValido,usuarioControlador);
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
            //Usuario usuarioValido = new Usuario("116640546", "1234", "Melissa", "Fallas");
            //Grupo grupo = new Grupo(1, "116640546", "116640546Inversion1", "Inversion1");
            //FormGastos form = new FormGastos(grupo, usuarioValido, gastosControlador,grupoControlador);
            //form.Show();
            //this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
