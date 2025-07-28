using System;

namespace Modelo
{
    public class Gasto
    {
        public int Id { get; set; }
        public string NombreGasto { get; set; }
        public string DescripcionGasto { get; set; }
        public string EnlaceGasto { get; set; }
        public double MontoGasto { get; set; }
        public string QuienPagoId { get; set; }
        public DateTime FechaSeleccionada { get; set; }

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

    }
}