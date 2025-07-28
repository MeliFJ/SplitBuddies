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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WfVistaSplitBuddies
{
    public partial class FrmReporteGastos : Form
    {
        IGastosControlador gastosControlador;
        IGestorDatosGastos datosGastos;
        List<Grupo> grupos;
        
        public FrmReporteGastos(Usuario usuarioseleccionado, List<Grupo> grupos)
        {
            InitializeComponent();
            datosGastos= new GestorDatosGastos();
            cboGruposDelusuario.Items.Clear();
            grupos.Add(new Grupo { Id = -1, Nombre = "Todos" });
            cboGruposDelusuario.DataSource = grupos;
            cboGruposDelusuario.DisplayMember = "Nombre"; // Lo que se muestra
            cboGruposDelusuario.ValueMember = "Id";
            cboGruposDelusuario.SelectedValue = -1;
            lblusuario.Text = usuarioseleccionado.Nombre;
            gastosControlador = new GastosControlador(datosGastos,new GestorDatosUsuario());
            CargarDataGridConDatos(usuarioseleccionado);

        }

        private void CargarDataGridConDatos(Usuario usuarioseleccionado)
        {
            List<Gasto> resultado= new List<Gasto>();
            if(cboGruposDelusuario.SelectedValue is null || cboGruposDelusuario.Text=="Todos")
            {
                resultado = gastosControlador.ConsultarGastosPorUsuario(usuarioseleccionado.Identificacion);

            }

            this.dataGridView1.DataSource = resultado;
        }

        private void FrmReporteGastos_Load(object sender, EventArgs e)
        {

        }

        private void cboGruposDelusuario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
