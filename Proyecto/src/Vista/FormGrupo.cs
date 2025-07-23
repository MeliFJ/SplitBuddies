using Projecto.Modelo;
using Projecto.src.Controlador;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Projecto.src.Vista
{
    public partial class FormGrupo : Form
    {

        private readonly IGestorDatos gestorDatos;

        private Usuario usuarioLogeado;

        private OpenFileDialog archivo;

        private GrupoControlador grupoControlador;

        public FormGrupo(Usuario usuario, IGestorDatos gestorDatos)
        {
            InitializeComponent();
            this.archivo = new OpenFileDialog();
            this.usuarioLogeado = usuario;
            this.grupoControlador = new GrupoControlador(gestorDatos);
            this.mostrarPosiblesIntegrantes();
            this.gestorDatos = gestorDatos;
        }

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
                bool resultado=grupoControlador.guardaGrupo(usuarioLogeado.Identificacion, nombreGrupo, archivo, integrantes);

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

        private void btnCargaImagen_Click(object sender, EventArgs e)
        {
            this.archivo.Filter = "archivos de imagenes (*.png, *.jpg) | *.png; *.jpg";

            if (this.archivo.ShowDialog() == DialogResult.OK)
            {
                pcBoxCarga.Image = Image.FromFile(archivo.FileName);
            }
        }

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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void limpiar(object sender, EventArgs e)
        {
            this.limpiarDatos();
        }

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

        private void FormGrupo_Load(object sender, EventArgs e)
        {

        }
    }
}
