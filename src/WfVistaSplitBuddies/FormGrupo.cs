using Controlador.Interfaces;
using Modelo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WfVistaSplitBuddies.Vista
{
    /// <summary>
    /// Formulario para la creación de un nuevo grupo.
    /// Permite seleccionar integrantes, asignar un nombre y un logo al grupo, y guardar la información.
    /// </summary>
    public partial class FormGrupo : Form
    {
        /// <summary>
        /// Usuario actualmente logueado que crea el grupo.
        /// </summary>
        private Usuario usuarioLogeado;

        /// <summary>
        /// Diálogo para seleccionar el archivo de imagen del logo.
        /// </summary>
        private OpenFileDialog archivo;

        /// <summary>
        /// Controlador encargado de la gestión de grupos.
        /// </summary>
        private IGrupoControlador grupoControlador;

        /// <summary>
        /// Controlador encargado de la gestión de usuarios.
        /// </summary>
        private IUsuarioControlador usuarioControlador;

        /// <summary>
        /// Inicializa una nueva instancia del formulario <see cref="FormGrupo"/>.
        /// </summary>
        /// <param name="usuario">Usuario actualmente logueado.</param>
        /// <param name="grupocontrolador">Controlador de grupos.</param>
        /// <param name="usuarioControlador">Controlador de usuarios.</param>
        public FormGrupo(Usuario usuario, IGrupoControlador grupocontrolador, IUsuarioControlador usuarioControlador)
        {
            InitializeComponent();
            this.archivo = new OpenFileDialog();
            this.usuarioLogeado = usuario;
            this.grupoControlador = grupocontrolador;
            this.usuarioControlador = usuarioControlador;
            this.mostrarPosiblesIntegrantes();
        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón para crear el grupo.
        /// Valida los datos, guarda el grupo y muestra un mensaje de éxito o error.
        /// </summary>
        private void btnCrearGrupo_Click(object sender, EventArgs e)
        {
            string nombreGrupo = txtNombreGrupo.Text;
            bool logoSelecionado = pcBoxCarga.Image != null;

            List<string> integrantes = new List<string>();
            // Agregamos todos los id de los integrantes seleccionados
            foreach (var item in chckListBoxIntegrantes.CheckedItems)
            {
                Usuario usuario = item as Usuario;
                if (usuario != null)
                {
                    integrantes.Add(usuario.Identificacion);
                }
            }
            // Agregamos el id del que creo el grupo
            integrantes.Add(usuarioLogeado.Identificacion);

            // Validamos si lleno todos los campos
            if (logoSelecionado && !nombreGrupo.Equals(string.Empty))
            {
                bool resultado = grupoControlador.guardaGrupo(usuarioLogeado.Identificacion, nombreGrupo, archivo.FileName, integrantes);

                if (resultado)
                {
                    lbGuardado.ForeColor = Color.Green;
                    lbGuardado.Text = "Grupo guardado";
                }
                else
                {
                    lbGuardado.ForeColor = Color.Red;
                    lbGuardado.Text = "No se pudo crear el grupo. Ya existe un grupo con ese nombre.";
                }
            }

            this.limpiarDatos();
        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón para cargar la imagen del logo.
        /// Permite seleccionar una imagen y la muestra en el PictureBox.
        /// </summary>
        private void btnCargaImagen_Click(object sender, EventArgs e)
        {
            this.archivo.Filter = "archivos de imagenes (*.png, *.jpg) | *.png; *.jpg";

            if (this.archivo.ShowDialog() == DialogResult.OK)
            {
                pcBoxCarga.Image = Image.FromFile(archivo.FileName);
            }
        }

        /// <summary>
        /// Muestra en el CheckedListBox los posibles integrantes del grupo, excluyendo al usuario logueado.
        /// </summary>
        private void mostrarPosiblesIntegrantes()
        {
            Dictionary<string, Usuario> posiblesIntegrantes = grupoControlador.cargarPosiblesIntegrantes();

            foreach (var valor in posiblesIntegrantes)
            {
                Usuario usuario = valor.Value;
                if (!usuario.Identificacion.Equals(usuarioLogeado.Identificacion))
                {
                    this.chckListBoxIntegrantes.Items.Add(usuario);
                }
            }
        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón Cancelar.
        /// Cierra el formulario y muestra la ventana de grupos.
        /// </summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MostrarGrupos form = new MostrarGrupos(grupoControlador, usuarioLogeado, usuarioControlador);
            form.Show();
            this.Close();
        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón para limpiar los datos del formulario.
        /// </summary>
        private void limpiar(object sender, EventArgs e)
        {
            this.limpiarDatos();
        }

        /// <summary>
        /// Limpia todos los campos del formulario y desmarca los integrantes seleccionados.
        /// </summary>
        private void limpiarDatos()
        {
            txtNombreGrupo.Text = "";

            // Limpiar el PictureBox
            pcBoxCarga.Image = null;

            // Desmarcar todos los ítems del CheckedListBox
            for (int i = 0; i < chckListBoxIntegrantes.Items.Count; i++)
            {
                chckListBoxIntegrantes.SetItemChecked(i, false);
            }
        }

        /// <summary>
        /// Evento que se ejecuta al cargar el formulario de grupo.
        /// </summary>
        private void FormGrupo_Load(object sender, EventArgs e)
        {

        }
    }
}
