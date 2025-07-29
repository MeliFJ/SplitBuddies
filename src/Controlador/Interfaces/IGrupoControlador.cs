using Modelo;
using System;
using System.Collections.Generic;

namespace Controlador.Interfaces
{
    /// <summary>
    /// Define el contrato para la gestión de grupos y sus integrantes.
    /// Proporciona métodos para cargar grupos, cargar posibles integrantes,
    /// obtener usuarios por grupo, guardar grupos y guardar logos de grupo.
    /// </summary>
    public interface IGrupoControlador
    {
        /// <summary>
        /// Carga la lista de todos los grupos disponibles.
        /// </summary>
        /// <returns>Una lista de objetos <see cref="Grupo"/>.</returns>
        List<Grupo> CargarGrupos();

        /// <summary>
        /// Carga los posibles integrantes que pueden ser añadidos a un grupo.
        /// </summary>
        /// <returns>
        /// Un diccionario donde la clave es la identificación del usuario y el valor es el objeto <see cref="Usuario"/> correspondiente.
        /// </returns>
        Dictionary<string, Usuario> cargarPosiblesIntegrantes();

        /// <summary>
        /// Carga la lista de usuarios que pertenecen a un grupo específico.
        /// </summary>
        /// <param name="idgrupo">El identificador único del grupo.</param>
        /// <returns>Una lista de objetos <see cref="Usuario"/> que pertenecen al grupo.</returns>
        List<Usuario> CargarUsuarioPorGrupos(int idgrupo);

        /// <summary>
        /// Guarda un nuevo grupo con los datos proporcionados.
        /// </summary>
        /// <param name="identificacion">Identificación del usuario creador del grupo.</param>
        /// <param name="nombreGrupo">Nombre del grupo.</param>
        /// <param name="RutaDeArchivo">Ruta del archivo del logo del grupo.</param>
        /// <param name="integrantes">Lista de identificaciones de los integrantes del grupo.</param>
        /// <returns>True si el grupo se guardó correctamente; de lo contrario, false.</returns>
        bool guardaGrupo(string identificacion, string nombreGrupo, string RutaDeArchivo, List<string> integrantes);

        /// <summary>
        /// Guarda el logo del grupo en la ruta especificada con un nuevo nombre.
        /// </summary>
        /// <param name="RutaDeArchivo">Ruta del archivo de origen del logo.</param>
        /// <param name="nuevoNombre">Nuevo nombre para el archivo del logo.</param>
        void guardaLogo(string RutaDeArchivo, string nuevoNombre);
    }
}