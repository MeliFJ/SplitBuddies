using Modelo;
using System.Collections.Generic;

namespace Controlador.Interfaces
{
    /// <summary>
    /// Define el contrato para la gestión de usuarios.
    /// Proporciona métodos para buscar, cargar y guardar usuarios,
    /// así como para obtener usuarios por grupo.
    /// </summary>
    public interface IUsuarioControlador
    {
        /// <summary>
        /// Busca un usuario por su identificación.
        /// </summary>
        /// <param name="identificacion">La identificación única del usuario.</param>
        /// <returns>El objeto <see cref="Usuario"/> correspondiente, o null si no se encuentra.</returns>
        Usuario BuscarUsuario(string identificacion);

        /// <summary>
        /// Carga la lista de usuarios que pertenecen a un grupo específico.
        /// </summary>
        /// <param name="idgrupo">El identificador único del grupo.</param>
        /// <returns>Una lista de objetos <see cref="Usuario"/> que pertenecen al grupo.</returns>
        List<Usuario> CargarUsuarioPorGrupos(int idgrupo);

        /// <summary>
        /// Carga todos los usuarios disponibles.
        /// </summary>
        /// <returns>
        /// Un diccionario donde la clave es la identificación del usuario y el valor es el objeto <see cref="Usuario"/> correspondiente.
        /// </returns>
        Dictionary<string, Usuario> CargarUsuarios();

        /// <summary>
        /// Guarda un usuario en el sistema.
        /// </summary>
        /// <param name="usuario">El objeto <see cref="Usuario"/> a guardar.</param>
        /// <returns>True si el usuario se guardó correctamente; de lo contrario, false.</returns>
        bool GuardaUsuario(Usuario usuario);
    }
}