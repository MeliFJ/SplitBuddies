using Controlador;
using Controlador.Interfaces;
using GestorDatos;
using GestorDatos.Interfaces;
using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WfVistaSplitBuddies
{
    public partial class FormResumenGastosPorUsuario : Form
    {
        IGastosControlador gastosControlador;
        IGestorDatosGastos datosGastos;
        List<Grupo> grupos;
        private Usuario UsuarioConectado;
        private Grupo GrupoSeleccionado;
        public FormResumenGastosPorUsuario(Usuario usuarioseleccionado, List<Grupo> grupos)
        {
            InitializeComponent();
            datosGastos = new GestorDatosGastos();
            gastosControlador = new GastosControlador(datosGastos, new GestorDatosUsuario());
            cboGruposDelusuarioResumen.Items.Clear();
            UsuarioConectado = usuarioseleccionado;
            cboGruposDelusuarioResumen.DataSource = grupos;
            cboGruposDelusuarioResumen.DisplayMember = "Nombre"; // Lo que se muestra
            cboGruposDelusuarioResumen.ValueMember = "Id";
            cboGruposDelusuarioResumen.SelectedValue = 1;
            lblusuario.Text = usuarioseleccionado.Nombre;
          



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

        private void CargarDataGridConDatos( Grupo grupo)
        {
            Limpiar();
            GastoGrupoUsuario resultado =  new GastoGrupoUsuario();
            resultado = gastosControlador.ConsultarGastosPorGrupoyUsuario(UsuarioConectado, grupo);
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

        }

        private void cboGruposDelusuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDataGridConDatos((Grupo)((ComboBox)sender).SelectedItem);
        }

        private void FormResumenGastosPorUsuario_Load(object sender, EventArgs e)
        {

        }
    }
}
