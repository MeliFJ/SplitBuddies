namespace Modelo
{
    /// <summary>
    /// Representa un reporte financiero de un usuario.
    /// Incluye el total de gastos, la deuda y el disponible calculado.
    /// </summary>
    public class Reporte
    {
        /// <summary>
        /// Suma total de los gastos realizados por el usuario.
        /// </summary>
        public double GastoTotal { get; private set; }

        /// <summary>
        /// Suma total de la deuda del usuario.
        /// </summary>
        public double Deuda { get; private set; }

        /// <summary>
        /// Monto disponible, calculado como la diferencia entre el gasto total y la deuda.
        /// </summary>
        public double Disponible { get; private set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Reporte"/> con los valores de gasto total y deuda especificados.
        /// </summary>
        /// <param name="gastoTotal">Suma total de los gastos realizados.</param>
        /// <param name="deuda">Suma total de la deuda.</param>
        public Reporte(double gastoTotal, double deuda)
        {
            this.GastoTotal = gastoTotal;
            this.Deuda = deuda;
            this.Disponible = gastoTotal - deuda;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Reporte"/> con valores en cero.
        /// </summary>
        public Reporte()
        {
            this.GastoTotal = 0;
            this.Deuda = 0;
            this.Disponible = 0;
        }
    }
}
