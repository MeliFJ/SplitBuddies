using Controlador.Interfaces;
using Modelo;
using System;
using System.Windows.Forms;

namespace WfVistaSplitBuddies
{
    public partial class FormReporte : Form
    {
        private readonly IGastosControlador gestorGastos;
        private readonly Usuario usuarioLogeado;
        public FormReporte(Usuario usuarioLogeado, IGastosControlador gestorGastos)
        {
            InitializeComponent();
            this.gestorGastos = gestorGastos;
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
                Reporte reporte=this.gestorGastos.GenerarReportePorFechas(fechaDesde, fechaHasta, this.usuarioLogeado);
                lbMontoMontoGastado.Text = $"Monto Pagado: {reporte.GastoTotal}";
                lbMonteAdeudado.Text = $"Monto Adeudado: {reporte.Deuda}";
                lbDisponible.Text = $"Monto Disponible: {reporte.Disponible}";
            }
        }

        private void btnGenerarMes_Click(object sender, EventArgs e)
        {
            DateTime fechaMes = dtpMes.Value;
            Reporte reporte = this.gestorGastos.GenerarReportePorMes(fechaMes, this.usuarioLogeado);
            lbMontoMontoGastado.Text = $"Monto Pagado: {reporte.GastoTotal}";
            lbMonteAdeudado.Text = $"Monto Adeudado: {reporte.Deuda}";
            lbDisponible.Text = $"Monto Disponible: {reporte.Disponible}";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            lbMontoMontoGastado.Text = $"Monto Pagado: 0";
            lbMonteAdeudado.Text = $"Monto Adeudado: 0";
            lbDisponible.Text = $"Monto Disponible: 0";
        }

        private void btnGenerarAnual_Click(object sender, EventArgs e)
        {
            DateTime fechaAnual = dtpAnno.Value;
            Reporte reporte = this.gestorGastos.GenerarReportePorAnno(fechaAnual, this.usuarioLogeado);
            lbMontoMontoGastado.Text = $"Monto Pagado: {reporte.GastoTotal}";
            lbMonteAdeudado.Text = $"Monto Adeudado: {reporte.Deuda}";
            lbDisponible.Text = $"Monto Disponible: {reporte.Disponible}";
        }
    }
}
