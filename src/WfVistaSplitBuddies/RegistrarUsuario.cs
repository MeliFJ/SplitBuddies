using Controlador.Interfaces;
using Modelo;
using System;
using System.Windows.Forms;

namespace WfVistaSplitBuddies.Vista
{
    /// <summary>
    /// Formulario para el registro de un nuevo usuario en el sistema.
    /// Permite ingresar los datos personales y credenciales, y guarda el usuario si no existe previamente.
    /// </summary>
    public partial class RegistrarUsuario : Form
    {
        /// <summary>
        /// Controlador encargado de la gestión de usuarios.
        /// </summary>
        private readonly IUsuarioControlador usuarioControlador;

        /// <summary>
        /// Limpia los campos del formulario de registro.
        /// </summary>
        private void Limpiar()
        {
            txtIdentificacion.Clear();
            txtNombre.Clear();
            TxtApellido.Clear();
            txtContrasena.Clear();
        }

        /// <summary>
        /// Inicializa una nueva instancia del formulario <see cref="RegistrarUsuario"/>.
        /// </summary>
        /// <param name="usuarioControlador">Controlador de usuarios.</param>
        public RegistrarUsuario(IUsuarioControlador usuarioControlador)
        {
            InitializeComponent();
            this.usuarioControlador = usuarioControlador;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón Guardar.
        /// Intenta registrar un nuevo usuario y muestra un mensaje de éxito o error.
        /// </summary>
        private void btnguardar_Click(object sender, EventArgs e)
        {
            string Identificacion = txtIdentificacion.Text;
            string nombre = txtNombre.Text;
            string apellido = TxtApellido.Text;
            string password = txtContrasena.Text;
            Usuario usuarionuevo = new Usuario(Identificacion, password, nombre, apellido);
            bool resultado = usuarioControlador.GuardaUsuario(usuarionuevo);
            if (resultado)
            {
                MessageBox.Show("Registro éxitoso", "Registro de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
                this.Close();
            }
            else
            {
                MessageBox.Show("El Usuario ya éxiste o campos vacios", "Registro de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Limpiar();
                this.Close();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void RegistrarUsuario_Load(object sender, EventArgs e)
        {

        }
    }
}
