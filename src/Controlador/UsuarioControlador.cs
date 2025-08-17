using Controlador.Interfaces;
using GestorDatos;
using GestorDatos.Interfaces;
using Modelo;
using System.Collections.Generic;

namespace Controlador
{
    /// <summary>
    /// Controlador encargado de la gestión de usuarios.
    /// Implementa la lógica para buscar, cargar y guardar usuarios,
    /// así como para obtener usuarios por grupo.
    /// </summary>
    public class UsuarioControlador : IUsuarioControlador
    {
        private static UsuarioControlador? instancia;
        /// <summary>
        /// Instancia para la gestión de datos de usuarios.
        /// </summary>
        internal readonly IGestorDatosUsuario _gestorDatosUsuario;

        public static IUsuarioControlador Instancia()
        {
            if(instancia == null)
            {
                instancia = new UsuarioControlador(new GestorDatosUsuario());
            }
           return  instancia;
        }
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UsuarioControlador"/>.
        /// </summary>
        /// <param name="gestorDatosUsuario">Instancia para la gestión de datos de usuarios.</param>
        private UsuarioControlador(IGestorDatosUsuario gestorDatosUsuario)
        {
            _gestorDatosUsuario = gestorDatosUsuario;
        }

        /// <summary>
        /// Guarda un usuario en el sistema si no existe previamente.
        /// </summary>
        /// <param name="usuario">El objeto <see cref="Usuario"/> a guardar.</param>
        /// <returns>True si el usuario se guardó correctamente; de lo contrario, false si ya existe.</returns>
        public bool GuardaUsuario(Usuario usuario)
        {
            Usuario usuaroexiste = _gestorDatosUsuario.BuscarUsuario(usuario.Identificacion);
            if (usuaroexiste != null && usuaroexiste.Identificacion.Equals(usuaroexiste.Identificacion))
            {
                return false;
            }
            else
            {
                _gestorDatosUsuario.GuardarUsuario(usuario);
                return true;
            }
        }

        /// <summary>
        /// Busca un usuario por su identificación.
        /// </summary>
        /// <param name="identificacion">La identificación única del usuario.</param>
        /// <returns>El objeto <see cref="Usuario"/> correspondiente, o null si no se encuentra.</returns>
        public Usuario BuscarUsuario(string identificacion)
        {
            return _gestorDatosUsuario.BuscarUsuario(identificacion);
        }

        /// <summary>
        /// Carga la lista de usuarios que pertenecen a un grupo específico.
        /// </summary>
        /// <param name="idgrupo">El identificador único del grupo.</param>
        /// <returns>Una lista de objetos <see cref="Usuario"/> que pertenecen al grupo.</returns>
        public List<Usuario> CargarUsuarioPorGrupos(int idgrupo)
        {
            return _gestorDatosUsuario.CargarUsuarioPorGrupos(idgrupo) ?? new List<Usuario>();
        }

        /// <summary>
        /// Carga todos los usuarios disponibles.
        /// </summary>
        /// <returns>
        /// Un diccionario donde la clave es la identificación del usuario y el valor es el objeto <see cref="Usuario"/> correspondiente.
        /// </returns>
        public Dictionary<string, Usuario> CargarUsuarios()
        {
            return _gestorDatosUsuario.CargarUsuarios();
        }

        public List<Usuario> CargarUsuarioPorGastoId(int gastoId)
        {
            return _gestorDatosUsuario.CargarUsuariosPorGastoId(gastoId) ?? new List<Usuario>();
        }
    }
}
