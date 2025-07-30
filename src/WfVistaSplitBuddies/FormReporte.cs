using Controlador.Interfaces;
using Modelo;
using System;
using System.Windows.Forms;

namespace WfVistaSplitBuddies
{
    /// <summary>
    /// Formulario para la generación y visualización de reportes financieros de un usuario.
    /// Permite consultar el total gastado, la deuda y el disponible en diferentes periodos (por fechas, mes o año).
    /// </summary>
    public partial class FormReporte : Form
    {
        /// <summary>
        /// Controlador encargado de la gestión de gastos.
        /// </summary>
        private readonly IGastosControlador gestorGastos;

        /// <summary>
        /// Usuario actualmente logueado para el cual se generan los reportes.
        /// </summary>
        private readonly Usuario usuarioLogeado;

        /// <summary>
        /// Inicializa una nueva instancia del formulario <see cref="FormReporte"/>.
        /// </summary>
        /// <param name="usuarioLogeado">Usuario actualmente logueado.</param>
        /// <param name="gestorGastos">Controlador de gastos.</param>
        public FormReporte(Usuario usuarioLogeado, IGastosControlador gestorGastos)
        {
            InitializeComponent();
            this.gestorGastos = gestorGastos;
            this.usuarioLogeado = usuarioLogeado;
            LbUsuario.Text = $"Usuario: {usuarioLogeado.Nombre} {usuarioLogeado.Apellido}";
        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón para generar reporte por rango de fechas.
        /// Muestra el total gastado, la deuda y el disponible en el periodo seleccionado.
        /// </summary>
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
                Reporte reporte = this.gestorGastos.GenerarReportePorFechas(fechaDesde, fechaHasta, this.usuarioLogeado);
                lbMontoMontoGastado.Text = $"Monto pagado en el periodo: {reporte.GastoTotal}";
                lbMonteAdeudado.Text = $"Monto adeudado en el periodo: {reporte.Deuda}";
                this.lbDisponible.ForeColor = reporte.Disponible > 0 ? System.Drawing.Color.Green : System.Drawing.Color.Red;
                lbDisponible.Text = $"Monto disponible en el periodo: {reporte.Disponible}";
            }
        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón para generar reporte mensual.
        /// Muestra el total gastado, la deuda y el disponible en el mes seleccionado.
        /// </summary>
        private void btnGenerarMes_Click(object sender, EventArgs e)
        {
            DateTime fechaMes = dtpMes.Value;
            Reporte reporte = this.gestorGastos.GenerarReportePorMes(fechaMes, this.usuarioLogeado);
            lbMontoMontoGastado.Text = $"Monto pagado en el periodo: {reporte.GastoTotal}";
            lbMonteAdeudado.Text = $"Monto adeudado en el periodo: {reporte.Deuda}";
            this.lbDisponible.ForeColor = reporte.Disponible > 0 ? System.Drawing.Color.Green : System.Drawing.Color.Red;
            lbDisponible.Text = $"Monto disponible en el periodo: {reporte.Disponible}";
        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón Limpiar.
        /// Limpia los resultados mostrados en el formulario.
        /// </summary>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            lbMontoMontoGastado.Text = $"Monto pagado en el periodo: 0";
            lbMonteAdeudado.Text = $"Monto adeudado en el periodo: 0";
            lbDisponible.Text = $"Monto disponible en el periodo: 0";
            this.lbDisponible.ForeColor = System.Drawing.Color.Black;
        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón para generar reporte anual.
        /// Muestra el total gastado, la deuda y el disponible en el año seleccionado.
        /// </summary>
        private void btnGenerarAnual_Click(object sender, EventArgs e)
        {
            DateTime fechaAnual = dtpAnno.Value;
            Reporte reporte = this.gestorGastos.GenerarReportePorAnno(fechaAnual, this.usuarioLogeado);
            lbMontoMontoGastado.Text = $"Monto pagado en el periodo: {reporte.GastoTotal}";
            lbMonteAdeudado.Text = $"Monto adeudado en el periodo: {reporte.Deuda}";
            this.lbDisponible.ForeColor = reporte.Disponible > 0 ? System.Drawing.Color.Green : System.Drawing.Color.Red;
            lbDisponible.Text = $"Monto disponible en el periodo: {reporte.Disponible}";
        }
    }
}
