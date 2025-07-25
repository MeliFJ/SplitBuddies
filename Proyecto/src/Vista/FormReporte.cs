using Projecto.Modelo;
using System;
using System.Windows.Forms;

namespace Projecto.src.Vista
{
    public partial class FormReporte : Form
    {
        private readonly IGestorDatos gestorDatos;
        private readonly Usuario usuarioLogeado;
        public FormReporte(Usuario usuarioLogeado, IGestorDatos gestorDatos)
        {
            InitializeComponent();
            this.gestorDatos = gestorDatos;
            this.usuarioLogeado = usuarioLogeado;
        }

        private void btnGenerarXFechas_Click(object sender, EventArgs e)
        {
            DateTime fechaDesde = dtpDesde.Value;
            DateTime fechaHasta = dtpHasta.Value;
            if (fechaDesde > fechaHasta)
            {
                MessageBox.Show("La fecha desde no puede ser mayor que la fecha hasta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else 
            {
                this.gestorDatos.GenerarReportePorFechas(fechaDesde, fechaHasta, this.usuarioLogeado);
            }
        }
    }
}
