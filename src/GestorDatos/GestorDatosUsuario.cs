using GestorDatos.Interfaces;
using Modelo;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace GestorDatos
{
    /// <summary>
    /// Clase encargada de la gestión de datos relacionados con los usuarios.
    /// Implementa la lógica para buscar, cargar y guardar usuarios,
    /// así como para obtener usuarios por grupo y por gasto.
    /// </summary>
    public class GestorDatosUsuario : GestorDatosBase, IGestorDatosUsuario
    {
        /// <summary>
        /// Guarda un usuario en el sistema si no existe previamente.
        /// </summary>
        /// <param name="usuario">El objeto <see cref="Usuario"/> a guardar.</param>
        public void GuardarUsuario(Usuario usuario)
        {
            Dictionary<string, Usuario> usuarios = CargarUsuarios();

            // Se valida que no exista el usuario
            if (usuarios.ContainsKey(usuario.Identificacion) == false)
            {
                usuarios[usuario.Identificacion] = usuario;

                var opciones = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(usuarios, opciones);
                File.WriteAllText(rutaArchivo, json);
            }
        }

        /// <summary>
        /// Carga todos los usuarios disponibles.
        /// </summary>
        /// <returns>
        /// Un diccionario donde la clave es la identificación del usuario y el valor es el objeto <see cref="Usuario"/> correspondiente.
        /// </returns>
        public Dictionary<string, Usuario> CargarUsuarios()
        {
            if (!File.Exists(rutaArchivo))
                return new Dictionary<string, Usuario>();

            string json = File.ReadAllText(rutaArchivo);
            if (string.IsNullOrWhiteSpace(json))
                return new Dictionary<string, Usuario>();

            var usuarios = JsonSerializer.Deserialize<Dictionary<string, Usuario>>(json);
            return usuarios ?? new Dictionary<string, Usuario>();
        }

        /// <summary>
        /// Busca un usuario por su identificación.
        /// </summary>
        /// <param name="identificacion">La identificación única del usuario.</param>
        /// <returns>El objeto <see cref="Usuario"/> correspondiente, o null si no se encuentra.</returns>
        public Usuario BuscarUsuario(string identificacion)
        {
            var usuarios = CargarUsuarios();
            usuarios.TryGetValue(identificacion, out Usuario usuario);
            return usuario;
        }

        /// <summary>
        /// Carga la lista de usuarios que pertenecen a un grupo específico.
        /// </summary>
        /// <param name="idgrupo">El identificador único del grupo.</param>
        /// <returns>Una lista de objetos <see cref="Usuario"/> que pertenecen al grupo, o una lista vacía si no hay resultados.</returns>
        public List<Usuario>? CargarUsuarioPorGrupos(int idgrupo)
        {
            if (!File.Exists(rutaArchivoGrupos))
                return new List<Usuario>();

            string json = File.ReadAllText(rutaArchivoUsuarioGrupos);
            if (string.IsNullOrWhiteSpace(json))
                return new List<Usuario>();
            var relacionusuariosgrupo = JsonSerializer.Deserialize<List<RelacionUsuarioGrupo>>(json)?.Where(x => x.GrupoId == idgrupo).ToList();
            var usuarios = CargarUsuarios().ToList();
            var resul = from usuario
                        in usuarios
                        join relacion in relacionusuariosgrupo
                        on usuario.Key equals relacion.UsuarioId
                        select usuario.Value;

            return resul?.ToList();
        }

        /// <summary>
        /// Carga la lista de usuarios que están asociados a un gasto específico.
        /// </summary>
        /// <param name="gastoId">Identificador único del gasto.</param>
        /// <returns>Una lista de objetos <see cref="Usuario"/> que están asociados al gasto, o una lista vacía si no hay resultados.</returns>
        public List<Usuario> CargarUsuariosPorGastoId(int gastoId)
        {
            List<Usuario> usuarios = new List<Usuario>();

            if (!File.Exists(rutaRelacionUsuarioGasto))
                return new List<Usuario>();

            string json = File.ReadAllText(rutaRelacionUsuarioGasto);
            if (string.IsNullOrWhiteSpace(json))
                return new List<Usuario>();

            var relacionUsuariosGastos = JsonSerializer.Deserialize<List<RelacionUsuarioGasto>>(json);

            // Lista de relación usuario-gasto que tiene el id del gasto seleccionado
            var resultadoIdUsuariosFiltrado = relacionUsuariosGastos?
                .Where(usuarioGasto => usuarioGasto.GastoId == gastoId);

            List<RelacionUsuarioGasto>? resultadoIdUsuarios = resultadoIdUsuariosFiltrado?.ToList();

            if (resultadoIdUsuarios != null)
            {
                usuarios = buscarLosUsuarioDelGasto(resultadoIdUsuarios);
                return usuarios;
            }

            return usuarios;
        }

        /// <summary>
        /// Busca y retorna los usuarios asociados a una lista de relaciones usuario-gasto.
        /// </summary>
        /// <param name="resultadoIdUsuarios">Lista de relaciones usuario-gasto filtradas por gasto.</param>
        /// <returns>Lista de objetos <see cref="Usuario"/> asociados al gasto.</returns>
        private List<Usuario> buscarLosUsuarioDelGasto(List<RelacionUsuarioGasto> resultadoIdUsuarios)
        {
            List<Usuario> usuariosDelGasto = new List<Usuario>();
            Dictionary<string, Usuario> usuariosDic = CargarUsuarios();

            foreach (RelacionUsuarioGasto resultadoIdUsuario in resultadoIdUsuarios)
            {
                if (usuariosDic.ContainsKey(resultadoIdUsuario.UsuarioId))
                {
                    usuariosDelGasto.Add(usuariosDic[resultadoIdUsuario.UsuarioId]);
                }
            }
            return usuariosDelGasto;
        }
    }
}
