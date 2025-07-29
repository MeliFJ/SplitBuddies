namespace Modelo
{
    /// <summary>
    /// Representa un usuario dentro del sistema.
    /// Contiene información de identificación, credenciales y datos personales.
    /// </summary>
    public class Usuario
    {
        /// <summary>
        /// Identificación única del usuario.
        /// </summary>
        public string Identificacion { get; set; }

        /// <summary>
        /// Contraseña del usuario.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Nombre del usuario.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Apellido del usuario.
        /// </summary>
        public string Apellido { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Usuario"/> con los datos proporcionados.
        /// </summary>
        /// <param name="identificacion">Identificación única del usuario.</param>
        /// <param name="password">Contraseña del usuario.</param>
        /// <param name="nombre">Nombre del usuario.</param>
        /// <param name="apellido">Apellido del usuario.</param>
        public Usuario(string identificacion, string password, string nombre, string apellido)
        {
            Identificacion = identificacion;
            Password = password;
            Nombre = nombre;
            Apellido = apellido;
        }

        /// <summary>
        /// Devuelve el nombre del usuario como representación en texto.
        /// </summary>
        /// <returns>El nombre del usuario.</returns>
        public override string ToString()
        {
            return Nombre; // Esto es lo que se muestra en el CheckedListBox
        }
    }
}
