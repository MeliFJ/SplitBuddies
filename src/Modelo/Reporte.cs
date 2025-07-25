
namespace Modelo
{
    public class Reporte
    {
        public double GastoTotal { get; private set; }
        public double Deuda { get; private set; }
        public double Disponible { get; private set; }


        public Reporte(double gastoTotal, double deuda)
        {
            this.GastoTotal = gastoTotal;
            this.Deuda = deuda;
            this.Disponible = gastoTotal-deuda;
        }

        public Reporte()
        {
            this.GastoTotal = 0;
            this.Deuda = 0;
            this.Disponible = 0;
        }
    }
}
