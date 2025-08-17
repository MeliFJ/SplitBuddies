using System;

namespace Modelo
{
    /// <summary>
    /// Representa un gasto realizado dentro de un grupo.
    /// Contiene información sobre el nombre, descripción, enlace, monto, usuario que pagó y la fecha del gasto.
    /// </summary>
    public class Gasto
    {
        /// <summary>
        /// Identificador único del gasto.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre o título del gasto.
        /// </summary>
        public string NombreGasto { get; set; }

        /// <summary>
        /// Descripción detallada del gasto.
        /// </summary>
        public string DescripcionGasto { get; set; }

        /// <summary>
        /// Enlace relacionado con el gasto (por ejemplo, recibo o referencia).
        /// </summary>
        public string EnlaceGasto { get; set; }

        /// <summary>
        /// Monto total del gasto.
        /// </summary>
        public double MontoGasto { get; set; }

        /// <summary>
        /// Identificador del usuario que realizó el pago.
        /// </summary>
        public string QuienPagoId { get; set; }

        /// <summary>
        /// Fecha en que se realizó el gasto.
        /// </summary>
        public DateTime FechaSeleccionada { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Gasto"/> con los datos proporcionados.
        /// </summary>
        /// <param name="nombreGasto">Nombre o título del gasto.</param>
        /// <param name="descripcionGasto">Descripción detallada del gasto.</param>
        /// <param name="enlaceGasto">Enlace relacionado con el gasto.</param>
        /// <param name="montoGasto">Monto total del gasto.</param>
        /// <param name="quienPagoId">Identificador del usuario que realizó el pago.</param>
        /// <param name="fechaSeleccionada">Fecha en que se realizó el gasto.</param>
        public Gasto(string nombreGasto, string descripcionGasto, string enlaceGasto,
                     double montoGasto, string quienPagoId, DateTime fechaSeleccionada)
        {
            NombreGasto = nombreGasto;
            DescripcionGasto = descripcionGasto;
            EnlaceGasto = enlaceGasto;
            MontoGasto = montoGasto;
            QuienPagoId = quienPagoId;
            FechaSeleccionada = fechaSeleccionada;
        }

        public Gasto(int idGasto,string nombreGasto, string descripcionGasto, string enlaceGasto,
             double montoGasto, string quienPagoId, DateTime fechaSeleccionada)
        {
            Id = idGasto;
            NombreGasto = nombreGasto;
            DescripcionGasto = descripcionGasto;
            EnlaceGasto = enlaceGasto;
            MontoGasto = montoGasto;
            QuienPagoId = quienPagoId;
            FechaSeleccionada = fechaSeleccionada;
        }

        /// <summary>
        /// Devuelve el nombre del usuario como representación en texto.
        /// </summary>
        /// <returns>El nombre del usuario.</returns>
        public override string ToString()
        {
            return NombreGasto; // Esto es lo que se muestra en el CheckedListBox
        }
    }
}