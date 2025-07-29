using GestorDatos.Interfaces;
using Modelo;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace GestorDatos
{
    /// <summary>
    /// Clase encargada de la gestión de datos relacionados con los grupos.
    /// Implementa la lógica para guardar, cargar y validar grupos, así como para gestionar las relaciones usuario-grupo.
    /// </summary>
    public class GestorDatosGrupos : GestorDatosBase, IGestorDatosGrupos
    {
        /// <summary>
        /// Guarda un nuevo grupo en el sistema si el nombre es único para el creador.
        /// </summary>
        /// <param name="grupo">El objeto <see cref="Grupo"/> a guardar.</param>
        /// <returns>True si el grupo se guardó correctamente; de lo contrario, false.</returns>
        public bool GuardarGrupos(Grupo grupo)
        {
            List<Grupo> grupos = CargarGrupos();

            // Se valida que no exista el grupo
            if (EsNombreGrupoUnico(grupo.Nombre, grupo.CreadorId, grupos))
            {
                // Busca el id más grande y le agrega 1 para el nuevo
                int nuevoId = 1;
                if (grupos.Count > 0)
                {
                    nuevoId = grupos.Max(g => g.Id) + 1;
                }
                grupo.Id = nuevoId;

                grupos.Add(grupo);
                var opciones = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(grupos, opciones);
                File.WriteAllText(rutaArchivoGrupos, json);

                // return GuardarUsuarioGrupo(grupo, integrantes);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Carga la lista de todos los grupos registrados en el sistema.
        /// </summary>
        /// <returns>Una lista de objetos <see cref="Grupo"/>.</returns>
        public List<Grupo> CargarGrupos()
        {
            if (!File.Exists(rutaArchivoGrupos))
                return new List<Grupo>();

            string json = File.ReadAllText(rutaArchivoGrupos);
            if (string.IsNullOrWhiteSpace(json))
                return new List<Grupo>();

            var grupos = JsonSerializer.Deserialize<List<Grupo>>(json);
            return grupos ?? new List<Grupo>();
        }

        /// <summary>
        /// Verifica si el nombre de un grupo es único para un creador específico.
        /// </summary>
        /// <param name="nuevoNombreGrupo">El nombre del grupo a verificar.</param>
        /// <param name="creadorId">El identificador del usuario creador.</param>
        /// <param name="grupos">La lista de grupos existentes.</param>
        /// <returns>True si el nombre es único para el creador; de lo contrario, false.</returns>
        public bool EsNombreGrupoUnico(string nuevoNombreGrupo, string creadorId, List<Grupo> grupos)
        {
            return !grupos.Any(g =>
                g.CreadorId.Equals(creadorId) &&
                string.Equals(g.Nombre.Trim(), nuevoNombreGrupo.Trim())
            );
        }

        /// <summary>
        /// Guarda la relación entre un grupo y sus integrantes.
        /// </summary>
        /// <param name="grupo">El grupo al que se asociarán los integrantes.</param>
        /// <param name="integrantes">Lista de identificadores de los usuarios integrantes.</param>
        /// <returns>True si la relación se guardó correctamente; de lo contrario, false.</returns>
        public bool GuardarUsuarioGrupo(Grupo grupo, List<string> integrantes)
        {
            List<RelacionUsuarioGrupo> relaciones = CargarUsuarioGrupos();

            foreach (string integranteId in integrantes)
            {
                relaciones.Add(new RelacionUsuarioGrupo(integranteId, grupo.Id));
            }

            var opciones = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(relaciones, opciones);
            File.WriteAllText(rutaArchivoUsuarioGrupos, json);
            return true;
        }

        /// <summary>
        /// Carga la lista de relaciones usuario-grupo existentes.
        /// </summary>
        /// <returns>Una lista de objetos <see cref="RelacionUsuarioGrupo"/>.</returns>
        public List<RelacionUsuarioGrupo> CargarUsuarioGrupos()
        {
            if (!File.Exists(rutaArchivoUsuarioGrupos))
                return new List<RelacionUsuarioGrupo>();

            string json = File.ReadAllText(rutaArchivoUsuarioGrupos);
            if (string.IsNullOrWhiteSpace(json))
                return new List<RelacionUsuarioGrupo>();

            var relaciones = JsonSerializer.Deserialize<List<RelacionUsuarioGrupo>>(json);
            return relaciones ?? new List<RelacionUsuarioGrupo>();
        }
    }
}
