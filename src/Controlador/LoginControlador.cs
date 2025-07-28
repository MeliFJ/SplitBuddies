using GestorDatos.Interfaces;
using Modelo;

namespace Controlador
{
    /// <summary>
    /// Controlador encargado de la autenticación de usuarios.
    /// Implementa la lógica para validar el inicio de sesión de un usuario.
    /// </summary>
    public class LoginControlador
    {
        /// <summary>
        /// Instancia para la gestión de datos de usuarios.
        /// </summary>
        IGestorDatosUsuario GestorDatosUsuario;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="LoginControlador"/>.
        /// </summary>
        /// <param name="gestorDatosUsuario">Instancia para la gestión de datos de usuarios.</param>
        public LoginControlador(IGestorDatosUsuario gestorDatosUsuario)
        {
            GestorDatosUsuario = gestorDatosUsuario;
        }

        /// <summary>
        /// Valida las credenciales de inicio de sesión de un usuario.
        /// </summary>
        /// <param name="identificacion">La identificación única del usuario.</param>
        /// <param name="password">La contraseña del usuario.</param>
        /// <returns>
        /// El objeto <see cref="Usuario"/> si las credenciales son correctas; de lo contrario, null.
        /// </returns>
        public Usuario? ValidarLogin(string identificacion, string password)
        {
            // Se busca si el usuario existe con la identificacion
            Usuario? usuario = GestorDatosUsuario.BuscarUsuario(identificacion);
            if (usuario != null && usuario.Password.Equals(password))
            {
                return usuario;
            }
            return null;
        }
    }
}
