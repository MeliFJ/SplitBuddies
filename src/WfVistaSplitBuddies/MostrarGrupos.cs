using Controlador;
using Controlador.Interfaces;
using GestorDatos;
using Modelo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

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
        private List<Usuario> ListaUsuarios;
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
            ConfigurarListViewMiembros();
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
            ListaUsuarios = usuarioControlador.CargarUsuarios().Select(x => x.Value).ToList();
        }
        internal void CargarMiembros(Grupo grupo)
        {
            listMiembros.Items.Clear();
            var usuarios = usuarioControlador.CargarUsuarioPorGrupos(grupo.Id);
            ListaUsuarios = new List<Usuario>();
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
            
            FormResumenGastosPorUsuario form = new FormResumenGastosPorUsuario(ListaUsuarios, ListaGruposCargada);
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (gruposSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un grupo para agregar gastos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                FormGastos form = new FormGastos(gruposSeleccionado, this.usuarioLogeado, gastosControlador, grupoControlador);
                form.ShowDialog();
            }
                
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            FormReporte form = new FormReporte(this.usuarioLogeado, this.gastosControlador);
            form.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormResumenGastosPorUsuario form = new FormResumenGastosPorUsuario(usuarioLogeado,ListaGruposCargada);
            form.ShowDialog();
        }

        private void btnReporte_Click_1(object sender, EventArgs e)
        {
            FormReporte form = new FormReporte(this.usuarioLogeado, this.gastosControlador);
            form.Show();
        }
    }
}
