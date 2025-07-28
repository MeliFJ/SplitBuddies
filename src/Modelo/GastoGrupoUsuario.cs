using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class GastoGrupoUsuario
    {
        public string NombreGrupo { get; set; } = string.Empty;
        public string NombreUsuario { get; set; } = string.Empty;
        public double TotalGastosGrupo {  get; set; }
        public double TotalGastosPorIntegrante {  get; set; }

        public int CantidadIntegrantes { get; set; }
        public double TotalGastosPorUsuario {  get; set; }
        public double SaldoUsuario
        {
            get
            {
                return TotalGastosPorUsuario - TotalGastosPorIntegrante;
            }
        }
       public  List<Gasto> Gastos { get; set; } = new List<Gasto>();
    }
}
