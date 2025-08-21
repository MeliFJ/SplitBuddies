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
    /// <summary>
    /// Formulario para mostrar y gestionar los grupos del usuario.
    /// Permite visualizar los grupos, sus miembros, acceder a reportes, registrar gastos y crear nuevos grupos.
    /// </summary>
    public partial class MostrarGrupos : Form
    {
        #region Variables

        /// <summary>
        /// Ruta de la carpeta donde se almacenan los logos de los grupos.
        /// </summary>
        private string carpetaDestino = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\assets\img\"));

        /// <summary>
        /// Controlador encargado de la gestión de grupos.
        /// </summary>
        private readonly IGrupoControlador grupoControlador;

        /// <summary>
        /// Controlador encargado de la gestión de usuarios.
        /// </summary>
        private readonly IUsuarioControlador usuarioControlador;

        /// <summary>
        /// Controlador encargado de la gestión de gastos.
        /// </summary>
        private readonly IGastosControlador gastosControlador;

        /// <summary>
        /// Usuario actualmente logueado.
        /// </summary>
        private readonly Usuario usuarioLogeado;

        /// <summary>
        /// Usuario seleccionado en la lista de miembros.
        /// </summary>
        private Usuario UsuarioSeleccionado;

        /// <summary>
        /// Lista de grupos cargados.
        /// </summary>
        private List<Grupo> ListaGruposCargada;

        /// <summary>
        /// Lista de usuarios cargados.
        /// </summary>
        private List<Usuario> ListaUsuarios;

        /// <summary>
        /// Lista de usuarios integrantes del grupo seleccionado.
        /// </summary>
        private List<Usuario> integrantesDelGrupo;

        /// <summary>
        /// Grupo seleccionado en la lista de grupos.
        /// </summary>
        Grupo gruposSeleccionado;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa una nueva instancia del formulario <see cref="MostrarGrupos"/>.
        /// </summary>
        /// <param name="grupoControlador">Controlador de grupos.</param>
        /// <param name="usuarioValido">Usuario actualmente logueado.</param>
        public MostrarGrupos(IGrupoControlador grupoControlador, Usuario usuarioValido)
        {
            InitializeComponent();
            this.grupoControlador = grupoControlador;
            this.usuarioLogeado = usuarioValido;
            this.usuarioControlador = UsuarioControlador.Instancia();
            this.gastosControlador = new GastosControlador(new GestorDatosGastos(), new GestorDatosUsuario());
        }
        #endregion

        #region Grupos

        /// <summary>
        /// Configura el ListView para mostrar los grupos con sus columnas y opciones.
        /// </summary>
        private void ConfigurarListViewDeGrupos()
        {
            listMostrarGrupos.View = View.Details;
            listMostrarGrupos.FullRowSelect = true;
            listMostrarGrupos.Columns.Clear();
            listMostrarGrupos.Columns.Add("Logo", 150);
            listMostrarGrupos.Columns.Add("Nombre del Grupo", 100);
            listMostrarGrupos.MultiSelect = false;
            ListaUsuarios = usuarioControlador.CargarUsuarios().Select(x => x.Value).ToList();
        }

        /// <summary>
        /// Evento que se ejecuta al cambiar la selección de grupo en el ListView.
        /// Carga los miembros del grupo seleccionado.
        /// </summary>
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

        /// <summary>
        /// Evento que se ejecuta al cargar el formulario.
        /// Configura los ListView y carga los grupos disponibles.
        /// </summary>
        private void MostrarGrupos_Load(object sender, EventArgs e)
        {
            ConfigurarListViewDeGrupos();
            ConfigurarListViewMiembros();
            List<Grupo> grupos = grupoControlador.CargarGruposPorUsuario(usuarioLogeado.Identificacion);
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

        /// <summary>
        /// Configura el ListView para mostrar los miembros de un grupo.
        /// </summary>
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

        /// <summary>
        /// Carga y muestra los miembros del grupo seleccionado en el ListView.
        /// Calcula el balance de cada usuario en el grupo.
        /// </summary>
        /// <param name="grupo">Grupo del cual se mostrarán los miembros.</param>
        internal void CargarMiembros(Grupo grupo)
        {
            listMiembros.Items.Clear();
            integrantesDelGrupo = usuarioControlador.CargarUsuarioPorGrupos(grupo.Id);
            Dictionary<string, double> usuarios = this.gastosControlador.CargarGastoPorUsuarioEnGrupo(grupo.Id, integrantesDelGrupo);

            //Grupo-gasto obtengo los gasto de ese grupo
            //Con eso saco los id de gastos y saco List<Gastos> del grupo, aqui filtro con QuienPagoId en gastos.json para saber quien pago algo
            foreach (var usuario in integrantesDelGrupo)
            {
                ListViewItem item = new ListViewItem(usuario.Identificacion);
                item.Tag = usuario;
                item.SubItems.Add(usuario.Nombre);
                item.SubItems.Add(usuario.Apellido);
                item.SubItems.Add(usuarios.ContainsKey(usuario.Identificacion) ? usuarios[usuario.Identificacion].ToString() : "0");
                listMiembros.Items.Add(item);
            }
        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón Limpiar.
        /// Limpia la selección de grupos y miembros.
        /// </summary>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            listMostrarGrupos.SelectedItems.Clear();
            listMiembros.Items.Clear();
        }

        /// <summary>
        /// Evento que se ejecuta al cambiar la selección de miembro en el ListView.
        /// Actualiza el usuario seleccionado.
        /// </summary>
        private void listMiembros_SelectedIndexChanged(object sender, EventArgs e)
        {
            var itemMiembro = listMiembros.SelectedItems;
            if (itemMiembro.Count > 0)
            {
                UsuarioSeleccionado = (Usuario)itemMiembro[0].Tag;
            }
        }

        #endregion

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón para crear un nuevo grupo.
        /// Abre el formulario de creación de grupo.
        /// </summary>
        private void btnCrearGrupo_Click(object sender, EventArgs e)
        {
            FormGrupo form = new FormGrupo(this.usuarioLogeado, grupoControlador, usuarioControlador);
            form.Show();
            this.Close();
        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón para ver el resumen de gastos por usuario.
        /// Abre el formulario correspondiente.
        /// </summary>
        private void btnGastos_Click(object sender, EventArgs e)
        {
            FormResumenGastosPorUsuario form = new FormResumenGastosPorUsuario(this.ListaUsuarios, ListaGruposCargada);
            form.ShowDialog();
        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón para agregar gastos a un grupo.
        /// Abre el formulario de registro de gastos para el grupo seleccionado.
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            if (gruposSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un grupo para agregar gastos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                FormGastos form = new FormGastos(gruposSeleccionado, integrantesDelGrupo, this.usuarioLogeado, gastosControlador, grupoControlador);
                form.ShowDialog();
            }
        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón para ver reportes.
        /// Abre el formulario de reportes para el usuario logueado.
        /// </summary>
        private void btnReporte_Click(object sender, EventArgs e)
        {
            FormReporte form = new FormReporte(this.usuarioLogeado, this.gastosControlador);
            form.Show();
        }

        /// <summary>
        /// Evento alternativo para ver reportes.
        /// Abre el formulario de reportes para el usuario logueado.
        /// </summary>
        private void btnReporte_Click_1(object sender, EventArgs e)
        {
            FormReporte form = new FormReporte(this.usuarioLogeado, this.gastosControlador);
            form.Show();
        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón para modificar gastos de un grupo.
        /// Abre el formulario de modificación de gastos para el grupo seleccionado.
        /// </summary>
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (gruposSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un grupo para modificar gastos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                FormGastos form = new FormGastos(gruposSeleccionado, integrantesDelGrupo, this.usuarioLogeado, gastosControlador, grupoControlador, true);
                if (!form.IsDisposed)
                {
                    form.DataChanged += cambioEnGastosForm;
                    form.ShowDialog();
                }
            }
        }

        /// <summary>
        /// Evento que se ejecuta cuando hay un cambio en los datos de gastos.
        /// Actualiza la vista de grupos y miembros.
        /// </summary>
        private void cambioEnGastosForm(object sender, EventArgs e) 
        {
            listMostrarGrupos.SelectedItems.Clear();
            listMiembros.Items.Clear();
            MostrarGrupos_Load(sender, e);
        }

        private void btnCerrarSesion_Click_1(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Close();
        }
    }
}
