namespace Modelo
{
    /// <summary>
    /// Representa la relación entre un usuario y un gasto.
    /// Permite asociar un gasto específico a un usuario determinado.
    /// </summary>
    public class RelacionUsuarioGasto
    {
        /// <summary>
        /// Identificador único del usuario asociado al gasto.
        /// </summary>
        public string UsuarioId { get; set; } = string.Empty;

        /// <summary>
        /// Identificador único del gasto asociado al usuario.
        /// </summary>
        public int GastoId { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="RelacionUsuarioGasto"/> con los identificadores del usuario y del gasto.
        /// </summary>
        /// <param name="UsuarioId">Identificador único del usuario.</param>
        /// <param name="GastoId">Identificador único del gasto.</param>
        public RelacionUsuarioGasto(string UsuarioId, int GastoId)
        {
            this.UsuarioId = UsuarioId;
            this.GastoId = GastoId;
        }

        /// <summary>
        /// Constructor sin parámetros requerido para la deserialización.
        /// </summary>
        public RelacionUsuarioGasto()
        {
        }
    }
}
