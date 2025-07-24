using Projecto.Modelo;
using Projecto.src.Controlador;
using Projecto.src.Modelo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.ListViewItem;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Projecto.src.Vista
{
    public partial class MostrarGrupos : Form
    {
        #region Variables
        private readonly IGestorDatos gestorDatos;
        private string carpetaDestino = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Proyecto\src\assets\img\"));
        private readonly GrupoControlador grupoControlador;
        private readonly Usuario usuarioLogeado;

        #endregion

        #region Constructor
        public MostrarGrupos(IGestorDatos gestorDatos, Usuario usuarioValido)
        {
            InitializeComponent();
            this.gestorDatos = gestorDatos;
            grupoControlador = new GrupoControlador(gestorDatos);
            this.usuarioLogeado = usuarioValido;
        }
        #endregion

        #region Grupos

        private void ConfigurarListViewDeGrupos()
        {
            listMostrarGrupos.View = View.Details;
            listMostrarGrupos.FullRowSelect = true;
            listMostrarGrupos.Columns.Clear();
            listMostrarGrupos.Columns.Add("Logo", 150);
            listMostrarGrupos.Columns.Add("Nombre del Grupo", 100);
            listMostrarGrupos.MultiSelect = false;
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var itemgrupo = listMostrarGrupos.SelectedItems;
            if (itemgrupo.Count > 0)
            {
                Grupo gruposeleccionado = (Grupo)itemgrupo[0].Tag;
                CargarMiembros(gruposeleccionado);
            }
        }
        private void MostrarGrupos_Load(object sender, EventArgs e)
        {
            ConfigurarListViewDeGrupos();

            List<Grupo> grupos = grupoControlador.CargarGrupos();
            grupos.ForEach(x =>
            {
                var img = new Bitmap(Path.Combine(carpetaDestino, x.NombreLogo));
                imageList1.Images.Add(x.NombreLogo, img);
            });
            listMostrarGrupos.Items.Clear();

            foreach (var grupo in grupos)
            {

                ListViewItem item = new ListViewItem(grupo.Id.ToString());

                item.Tag = grupo;
                item.SubItems.Add(grupo.Nombre);
                item.SubItems.Add(grupo.CreadorId);
                item.ImageKey = grupo.NombreLogo;
                listMostrarGrupos.Items.Add(item);
            }
        }

        #endregion

        #region Miembros
        private void ConfigurarListViewMiembros()
        {
            listMiembros.View = View.Details;
            listMiembros.FullRowSelect = true;
            listMiembros.Columns.Clear();
            listMiembros.Columns.Add("Identificacion", 150);
            listMiembros.Columns.Add("Nombre", 100);
            listMiembros.Columns.Add("Apellido", 100);
            listMiembros.Columns.Add("Balance", 100);
            listMiembros.MultiSelect = false;
        }
        internal void CargarMiembros(Grupo grupo)
        {
            listMiembros.Items.Clear();
            var usuarios = grupoControlador.CargarUsuarioPorGrupos(grupo.Id);
            foreach (var usuario in usuarios)
            {

                ListViewItem item = new ListViewItem(usuario.Identificacion);
                item.Tag = usuario;
                item.SubItems.Add(usuario.Nombre);
                item.SubItems.Add(usuario.Apellido);
                item.SubItems.Add("0");
                listMiembros.Items.Add(item);
            }
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            listMostrarGrupos.SelectedItems.Clear();
            listMiembros.Items.Clear();
        }


        #endregion

        private void btnCrearGrupo_Click(object sender, EventArgs e)
        {
            FormGrupo form = new FormGrupo(this.usuarioLogeado,gestorDatos);
            form.Show();
            this.Close();
        }
    }
}
