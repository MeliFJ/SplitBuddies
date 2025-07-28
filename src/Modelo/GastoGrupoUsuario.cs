using System.Collections.Generic;

namespace Modelo
{
    /// <summary>
    /// Representa el resumen de gastos de un usuario dentro de un grupo.
    /// Incluye información sobre el grupo, el usuario, totales de gastos, saldo y la lista de gastos asociados.
    /// </summary>
    public class GastoGrupoUsuario
    {
        /// <summary>
        /// Nombre del grupo al que pertenece el usuario.
        /// </summary>
        public string NombreGrupo { get; set; } = string.Empty;

        /// <summary>
        /// Nombre del usuario al que corresponde el resumen.
        /// </summary>
        public string NombreUsuario { get; set; } = string.Empty;

        /// <summary>
        /// Suma total de los gastos realizados en el grupo.
        /// </summary>
        public double TotalGastosGrupo { get; set; }

        /// <summary>
        /// Monto promedio de gastos por integrante del grupo.
        /// </summary>
        public double TotalGastosPorIntegrante { get; set; }

        /// <summary>
        /// Cantidad total de integrantes en el grupo.
        /// </summary>
        public int CantidadIntegrantes { get; set; }

        /// <summary>
        /// Suma total de los gastos realizados por el usuario en el grupo.
        /// </summary>
        public double TotalGastosPorUsuario { get; set; }

        /// <summary>
        /// Saldo del usuario respecto al promedio del grupo.
        /// Es positivo si el usuario ha pagado más que el promedio, negativo si ha pagado menos.
        /// </summary>
        public double SaldoUsuario
        {
            get
            {
                return TotalGastosPorUsuario - TotalGastosPorIntegrante;
            }
        }

        /// <summary>
        /// Lista de gastos asociados al usuario dentro del grupo.
        /// </summary>
        public List<Gasto> Gastos { get; set; } = new List<Gasto>();
    }
}
