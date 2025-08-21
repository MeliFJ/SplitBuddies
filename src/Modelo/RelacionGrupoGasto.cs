namespace Modelo
{
    /// <summary>
    /// Representa la relación entre un grupo y un gasto.
    /// Permite asociar un gasto específico a un grupo determinado.
    /// </summary>
    public class RelacionGrupoGasto
    {
        /// <summary>
        /// Identificador único del gasto asociado al grupo.
        /// </summary>
        public int GastoId { get; set; }

        /// <summary>
        /// Identificador único del grupo asociado al gasto.
        /// </summary>
        public int GrupoId { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="RelacionGrupoGasto"/> con los identificadores del grupo y del gasto.
        /// </summary>
        /// <param name="grupoId">Identificador único del grupo.</param>
        /// <param name="gastoId">Identificador único del gasto.</param>
        public RelacionGrupoGasto(int grupoId, int gastoId)
        { 
            this.GastoId = gastoId;
            this.GrupoId = grupoId;
        }

        /// <summary>
        /// Constructor sin parámetros requerido para la deserialización.
        /// </summary>
        public RelacionGrupoGasto()
        {
        }
    }
}
