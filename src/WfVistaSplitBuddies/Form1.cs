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
    /// <summary>
    /// Formulario principal de la aplicación SplitBuddies.
    /// Permite a los usuarios iniciar sesión, registrar nuevos usuarios y acceder a la gestión de grupos.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Gestor de datos de usuarios utilizado para operaciones de acceso a datos.
        /// </summary>
        private readonly IGestorDatosUsuario gestorDatosUsuario;

        /// <summary>
        /// Controlador encargado de la autenticación de usuarios.
        /// </summary>
        private readonly LoginControlador loginControlador;

        /// <summary>
        /// Controlador encargado de la gestión de grupos.
        /// </summary>
        private readonly IGrupoControlador grupoControlador;

        /// <summary>
        /// Controlador encargado de la gestión de usuarios.
        /// </summary>
        private readonly IUsuarioControlador usuarioControlador;

        /// <summary>
        /// Inicializa una nueva instancia del formulario principal <see cref="Form1"/>.
        /// Configura los controladores y gestores de datos necesarios.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            this.gestorDatosUsuario = new GestorDatosUsuario();
            loginControlador = new LoginControlador(gestorDatosUsuario);
            this.usuarioControlador = UsuarioControlador.Instancia();
            this.grupoControlador = new GrupoControlador(new GestorDatosGrupos(), gestorDatosUsuario);
        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón de registro de usuario.
        /// Abre el formulario para registrar un nuevo usuario.
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            new RegistrarUsuario(usuarioControlador).Show();
        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón de inicio de sesión.
        /// Valida las credenciales del usuario y, si son correctas, muestra la ventana de grupos.
        /// Si las credenciales son incorrectas, muestra un mensaje de error.
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            string identificacion = txtbxIdentificacion.Text;
            string password = txtbxContrasena.Text;

            // Validar si el usuario es válido
            Usuario usuarioValido = loginControlador.ValidarLogin(identificacion, password);
            if (usuarioValido != null)
            {
                MostrarGrupos form = new MostrarGrupos(grupoControlador, usuarioValido);
                form.Show();
                this.Hide();
            }
            else
            {
                this.LbErrorLogin.ForeColor = System.Drawing.Color.Red;
                LbErrorLogin.Text = "Login fallido verifique la identificacion y la contraseña";
            }
        }

        /// <summary>
        /// Evento que se ejecuta al cargar el formulario principal.
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
