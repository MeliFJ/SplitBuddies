namespace Modelo
{
    /// <summary>
    /// Representa la relación entre un usuario y un grupo.
    /// Permite asociar un usuario específico a un grupo determinado.
    /// </summary>
    public class RelacionUsuarioGrupo
    {
        /// <summary>
        /// Identificador único del usuario asociado al grupo.
        /// </summary>
        public string UsuarioId { get; set; } = string.Empty;

        /// <summary>
        /// Identificador único del grupo asociado al usuario.
        /// </summary>
        public int GrupoId { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="RelacionUsuarioGrupo"/> con los identificadores del usuario y del grupo.
        /// </summary>
        /// <param name="UsuarioId">Identificador único del usuario.</param>
        /// <param name="GrupoId">Identificador único del grupo.</param>
        public RelacionUsuarioGrupo(string UsuarioId, int GrupoId)
        {
            this.UsuarioId = UsuarioId;
            this.GrupoId = GrupoId;
        }

        /// <summary>
        /// Constructor sin parámetros requerido para la deserialización.
        /// </summary>
        public RelacionUsuarioGrupo()
        {
        }
    }
}
