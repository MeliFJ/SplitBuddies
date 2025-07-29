using Modelo;
using System.Collections.Generic;

namespace GestorDatos.Interfaces
{
    /// <summary>
    /// Define el contrato para la gestión de datos relacionados con los grupos.
    /// Proporciona métodos para cargar, guardar y validar grupos, así como para gestionar las relaciones usuario-grupo.
    /// </summary>
    public interface IGestorDatosGrupos
    {
        /// <summary>
        /// Carga la lista de todos los grupos registrados en el sistema.
        /// </summary>
        /// <returns>Una lista de objetos <see cref="Grupo"/>.</returns>
        List<Grupo> CargarGrupos();

        /// <summary>
        /// Verifica si el nombre de un grupo es único para un creador específico.
        /// </summary>
        /// <param name="nuevoNombreGrupo">El nombre del grupo a verificar.</param>
        /// <param name="creadorId">El identificador del usuario creador.</param>
        /// <param name="grupos">La lista de grupos existentes.</param>
        /// <returns>True si el nombre es único para el creador; de lo contrario, false.</returns>
        bool EsNombreGrupoUnico(string nuevoNombreGrupo, string creadorId, List<Grupo> grupos);

        /// <summary>
        /// Guarda un nuevo grupo en el sistema.
        /// </summary>
        /// <param name="grupo">El objeto <see cref="Grupo"/> a guardar.</param>
        /// <returns>True si el grupo se guardó correctamente; de lo contrario, false.</returns>
        bool GuardarGrupos(Grupo grupo);

        /// <summary>
        /// Guarda la relación entre un grupo y sus integrantes.
        /// </summary>
        /// <param name="grupo">El grupo al que se asociarán los integrantes.</param>
        /// <param name="integrantes">Lista de identificadores de los usuarios integrantes.</param>
        /// <returns>True si la relación se guardó correctamente; de lo contrario, false.</returns>
        bool GuardarUsuarioGrupo(Grupo grupo, List<string> integrantes);

        /// <summary>
        /// Carga la lista de relaciones usuario-grupo existentes.
        /// </summary>
        /// <returns>Una lista de objetos <see cref="RelacionUsuarioGrupo"/>.</returns>
        List<RelacionUsuarioGrupo> CargarUsuarioGrupos();
    }
}