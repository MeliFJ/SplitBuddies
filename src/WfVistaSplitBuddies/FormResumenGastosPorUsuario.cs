using Controlador;
using Controlador.Interfaces;
using GestorDatos;
using GestorDatos.Interfaces;
using Modelo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WfVistaSplitBuddies
{
    /// <summary>
    /// Formulario para mostrar el resumen de gastos de un usuario dentro de un grupo.
    /// Permite seleccionar un usuario y un grupo, y visualizar los gastos, totales, saldo y detalles asociados.
    /// </summary>
    public partial class FormResumenGastosPorUsuario : Form
    {
        /// <summary>
        /// Controlador encargado de la gestión de gastos.
        /// </summary>
        IGastosControlador gastosControlador;

        /// <summary>
        /// Gestor de datos de gastos.
        /// </summary>
        IGestorDatosGastos datosGastos;

        /// <summary>
        /// Usuario actualmente seleccionado para mostrar el resumen.
        /// </summary>
        private Usuario UsuarioSeleccionado;

        /// <summary>
        /// Grupo actualmente seleccionado para mostrar el resumen.
        /// </summary>
        private Grupo GrupoSeleccionado;

        /// <summary>
        /// Usuario principal para el cual se muestra el resumen.
        /// </summary>
        private List<Usuario> Usuarios;

        /// <summary>
        /// Inicializa una nueva instancia del formulario <see cref="FormResumenGastosPorUsuario"/>.
        /// </summary>
        /// <param name="usuarioseleccionado">Usuario para el cual se mostrará el resumen.</param>
        /// <param name="grupos">Lista de grupos disponibles.</param>
        public FormResumenGastosPorUsuario(List<Usuario> usuarioseleccionado, List<Grupo> grupos)
        {
            InitializeComponent();
            datosGastos = new GestorDatosGastos();
            gastosControlador = new GastosControlador(datosGastos, new GestorDatosUsuario());
            cboGruposDelusuarioResumen.Items.Clear();
            Usuarios = usuarioseleccionado;
            
            cboGruposDelusuarioResumen.DataSource = grupos;
            cboGruposDelusuarioResumen.DisplayMember = "Nombre"; // Lo que se muestra
            cboGruposDelusuarioResumen.ValueMember = "Id";
            cboGruposDelusuarioResumen.SelectedIndex = 1;

            cboUsuario.DataSource = Usuarios;
            cboUsuario.DisplayMember = "Nombre"; // Lo que se muestra
            cboUsuario.ValueMember = "Identificacion";
            cboUsuario.SelectedIndex = 1;
        }

        /// <summary>
        /// Limpia los datos mostrados en el formulario y restablece los valores a cero.
        /// </summary>
        private void Limpiar()
        {
            GastoGrupoUsuario resultado = new GastoGrupoUsuario();
            this.dgtGrupos.DataSource = resultado.Gastos;
            lblgastosPagosPorusuario.Text = resultado.TotalGastosPorUsuario.ToString();
            lbltotalPorIntegrante.Text = resultado.TotalGastosPorUsuario.ToString();
            lblCantidadIntegrantes.Text = resultado.CantidadIntegrantes.ToString();
            lblTotalGastosGrupo.Text = resultado.TotalGastosGrupo.ToString();
            lbltotalPorIntegrante.Text = resultado.TotalGastosPorIntegrante.ToString();
            lblSaldoUsuario.Text = resultado.SaldoUsuario.ToString();
        }

        /// <summary>
        /// Carga y muestra en el DataGrid los datos de gastos del usuario seleccionado en el grupo seleccionado.
        /// Actualiza los totales, el saldo y los detalles en las etiquetas correspondientes.
        /// </summary>
        /// <param name="usuarioseleccionado">Usuario seleccionado.</param>
        /// <param name="grupo">Grupo seleccionado.</param>
        private void CargarDataGridConDatos(Usuario usuarioseleccionado, Grupo grupo)
        {
            Limpiar();
            GastoGrupoUsuario resultado =  new GastoGrupoUsuario();
            resultado = gastosControlador.ConsultarGastosPorGrupoyUsuario(usuarioseleccionado, grupo);
            this.dgtGrupos.DataSource = resultado.Gastos;
            lblgastosPagosPorusuario.Text = resultado.TotalGastosPorUsuario.ToString();
            lbltotalPorIntegrante.Text = resultado.TotalGastosPorUsuario.ToString();
            lblCantidadIntegrantes.Text = resultado.CantidadIntegrantes.ToString();
            lblTotalGastosGrupo.Text = resultado.TotalGastosGrupo.ToString();
            lbltotalPorIntegrante.Text = resultado.TotalGastosPorIntegrante.ToString();
            lblSaldoUsuario.Text = resultado.SaldoUsuario.ToString();
            if(resultado.SaldoUsuario > 0)
            {
                lblSaldoUsuario.ForeColor = Color.Green;
            }
            else if (resultado.SaldoUsuario < 0)
            {
                lblSaldoUsuario.ForeColor = Color.Red;
            }
            else
            {
                lblSaldoUsuario.ForeColor = Color.Black;
            }
            lblusuario.Text = UsuarioSeleccionado.Nombre;
        }

        /// <summary>
        /// Evento que se ejecuta al cambiar la selección del grupo en el ComboBox.
        /// Actualiza el grupo seleccionado.
        /// </summary>
        private void cboGruposDelusuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            GrupoSeleccionado = (Grupo)((ComboBox)sender).SelectedItem;
        }

        /// <summary>
        /// Evento que se ejecuta al cargar el formulario.
        /// Carga los datos iniciales del usuario y grupo seleccionados.
        /// </summary>
        private void FormResumenGastosPorUsuario_Load(object sender, EventArgs e)
        {
            CargarDataGridConDatos(UsuarioSeleccionado, GrupoSeleccionado);
        }

        /// <summary>
        /// Evento que se ejecuta al cambiar la selección del usuario en el ComboBox.
        /// Actualiza el usuario seleccionado.
        /// </summary>
        private void cboUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            UsuarioSeleccionado = (Usuario)((ComboBox)sender).SelectedItem;
        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón para ver el balance.
        /// Actualiza la información mostrada en el formulario.
        /// </summary>
        private void btnVerBalance_Click(object sender, EventArgs e)
        {
            CargarDataGridConDatos(UsuarioSeleccionado, GrupoSeleccionado);
        }
    }
}
