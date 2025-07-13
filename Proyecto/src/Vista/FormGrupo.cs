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
            bool logoSelecionado = this.archivo.ShowDialog() == DialogResult.OK;
            List<string> integrantes= new List<string>();

            // Validamos si lleno todos los campos
            if (logoSelecionado && !nombreGrupo.Equals(string.Empty)) 
            {
                grupoControlador.guardaGrupo(usuarioLogeado.Identificacion,nombreGrupo, archivo, integrantes);
            }
        }

        private void btnCargaImagen_Click(object sender, EventArgs e)
        {
            this.archivo.Filter = "archivos de imagenes (*.png, *.jpg) | *.png; *.jpg";

            if (this.archivo.ShowDialog()==DialogResult.OK)
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
    }
}
