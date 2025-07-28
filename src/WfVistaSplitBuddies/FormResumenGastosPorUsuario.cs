using Controlador;
using Controlador.Interfaces;
using GestorDatos;
using GestorDatos.Interfaces;
using Modelo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WfVistaSplitBuddies
{
    public partial class FormResumenGastosPorUsuario : Form
    {
        IGastosControlador gastosControlador;
        IGestorDatosGastos datosGastos;
        List<Grupo> grupos;
        private Usuario UsuarioSeleccionado;
        private Grupo GrupoSeleccionado;
        private List<Usuario> Usuarios= new List<Usuario>();
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

        private void CargarDataGridConDatos(Usuario usuarioseleccionado, Grupo grupo)
        {
            Limpiar();
            GastoGrupoUsuario resultado =  new GastoGrupoUsuario();
            resultado = gastosControlador.ConsultarGastosPorGrupoyUsuario(usuarioseleccionado, grupo);
            this.dgtGrupos.DataSource = resultado.Gastos;
            lblgastosPagosPorusuario.Text = resultado.TotalGastosPorUsuario.ToString();
            lbltotalPorIntegrante.Text=resultado.TotalGastosPorUsuario.ToString();
            lblCantidadIntegrantes.Text = resultado.CantidadIntegrantes.ToString();
            lblTotalGastosGrupo.Text = resultado.TotalGastosGrupo.ToString();
            lbltotalPorIntegrante.Text=resultado.TotalGastosPorIntegrante.ToString();
            lblSaldoUsuario.Text = resultado.SaldoUsuario.ToString();
            if(resultado.SaldoUsuario>0)
            {
                lblSaldoUsuario.ForeColor = Color.Green;
            }
            else if (resultado.SaldoUsuario < 0)
            {
                lblSaldoUsuario.ForeColor = Color.Red;
            }else
            {
                lblSaldoUsuario.ForeColor = Color.Black;
            }
            lblusuario.Text = UsuarioSeleccionado.Nombre;

        }

        private void cboGruposDelusuario_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            GrupoSeleccionado = (Grupo)((ComboBox)sender).SelectedItem;
        }

        private void FormResumenGastosPorUsuario_Load(object sender, EventArgs e)
        {
            CargarDataGridConDatos(UsuarioSeleccionado, GrupoSeleccionado);
        }

        private void cboUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            UsuarioSeleccionado = (Usuario)((ComboBox)sender).SelectedItem;
        }

        private void btnVerBalance_Click(object sender, EventArgs e)
        {
            CargarDataGridConDatos(UsuarioSeleccionado, GrupoSeleccionado);
        }
    }
}
