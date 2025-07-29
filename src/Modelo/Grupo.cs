namespace Modelo
{
    /// <summary>
    /// Representa un grupo dentro del sistema.
    /// Contiene información sobre el identificador, el usuario creador, el nombre del grupo y el nombre del logo asociado.
    /// </summary>
    public class Grupo
    {
        /// <summary>
        /// Identificador único del grupo.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identificador del usuario que creó el grupo.
        /// </summary>
        public string CreadorId { get; set; } = string.Empty;

        /// <summary>
        /// Nombre del archivo de logo asociado al grupo.
        /// </summary>
        public string NombreLogo { get; set; } = string.Empty;

        /// <summary>
        /// Nombre del grupo.
        /// </summary>
        public string Nombre { get; set; } = string.Empty;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Grupo"/> con los datos del usuario creador, el logo y el nombre del grupo.
        /// </summary>
        /// <param name="identificadorUsuario">Identificador del usuario creador.</param>
        /// <param name="nombreLogo">Nombre del archivo de logo.</param>
        /// <param name="nombre">Nombre del grupo.</param>
        public Grupo(string identificadorUsuario, string nombreLogo, string nombre)
        {
            CreadorId = identificadorUsuario;
            NombreLogo = nombreLogo;
            Nombre = nombre;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Grupo"/> con el identificador, el usuario creador, el logo y el nombre del grupo.
        /// </summary>
        /// <param name="id">Identificador único del grupo.</param>
        /// <param name="identificadorUsuario">Identificador del usuario creador.</param>
        /// <param name="nombreLogo">Nombre del archivo de logo.</param>
        /// <param name="nombre">Nombre del grupo.</param>
        public Grupo(int id, string identificadorUsuario, string nombreLogo, string nombre)
        {
            Id = id;
            CreadorId = identificadorUsuario;
            NombreLogo = nombreLogo;
            Nombre = nombre;
        }

        /// <summary>
        /// Constructor sin parámetros requerido para la deserialización.
        /// </summary>
        public Grupo() { }
    }
}
