using Controlador;
using Controlador.Interfaces;
using GestorDatos;
using GestorDatos.Interfaces;
using Modelo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.ListViewItem;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WfVistaSplitBuddies.Vista
{
    public partial class MostrarGrupos : Form
    {
        #region Variables
      
        private string carpetaDestino = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\assets\img\"));
        private readonly IGrupoControlador grupoControlador;
        private readonly IUsuarioControlador usuarioControlador;
        private readonly IGastosControlador gastosControlador;
        private readonly Usuario usuarioLogeado;

        private Usuario UsuarioSeleccionado;
        private List<Grupo> ListaGruposCargada;
        Grupo gruposSeleccionado;
        #endregion

        #region Constructor
        public MostrarGrupos(IGrupoControlador grupoControlador,  Usuario usuarioValido, IUsuarioControlador usuarioControlador )
        {
            InitializeComponent();
            this.grupoControlador = grupoControlador;
            this.usuarioLogeado = usuarioValido;
            this.usuarioControlador = usuarioControlador;
            this.gastosControlador = new GastosControlador( new GestorDatosGastos(),new GestorDatosUsuario());

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
                this.gruposSeleccionado = gruposeleccionado;
                CargarMiembros(gruposeleccionado);
            }
            else
                gruposSeleccionado = null;
        }
        private void MostrarGrupos_Load(object sender, EventArgs e)
        {
            ConfigurarListViewDeGrupos();

            List<Grupo> grupos = grupoControlador.CargarGrupos();
            ListaGruposCargada = grupos;
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
            var usuarios = usuarioControlador.CargarUsuarioPorGrupos(grupo.Id);
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
        private void listMiembros_SelectedIndexChanged(object sender, EventArgs e)
        {
            var itemMiembro = listMiembros.SelectedItems;
            if (itemMiembro.Count > 0)
            {
                UsuarioSeleccionado = (Usuario)itemMiembro[0].Tag;
            }
        }

        #endregion

        private void btnCrearGrupo_Click(object sender, EventArgs e)
        {
            FormGrupo form = new FormGrupo(this.usuarioLogeado, grupoControlador, usuarioControlador);
            form.Show();
            this.Close();
        }

        private void btnGastos_Click(object sender, EventArgs e)
        {
            new FrmReporteGastos(UsuarioSeleccionado, ListaGruposCargada).ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Usuario usuarioValido = new Usuario("116640546", "1234", "Melissa", "Fallas");
            //Grupo grupo = new Grupo(1, "116640546", "116640546Inversion1", "Inversion1");
            FormGastos form = new FormGastos(gruposSeleccionado,UsuarioSeleccionado,gastosControlador,grupoControlador);
            form.ShowDialog();
            //this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormResumenGastosPorUsuario form = new FormResumenGastosPorUsuario(usuarioLogeado,ListaGruposCargada);
            form.ShowDialog();
        }
    }
}
