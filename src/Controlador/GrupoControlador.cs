using Controlador.Interfaces;
using GestorDatos.Interfaces;
using Modelo;
using System;
using System.Collections.Generic;
using System.IO;

namespace Controlador
{
    /// <summary>
    /// Controlador encargado de la gestión de grupos y sus integrantes.
    /// Implementa la lógica para cargar grupos, posibles integrantes, usuarios por grupo,
    /// guardar grupos y guardar logos de grupo.
    /// </summary>
    public class GrupoControlador : IGrupoControlador
    {
        private IGestorDatosGrupos gestorDatos;
        private IGestorDatosUsuario grupoUsuario;
        private string carpetaDestino = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\assets\img\"));

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="GrupoControlador"/>.
        /// </summary>
        /// <param name="gestorDatos">Instancia para la gestión de datos de grupos.</param>
        /// <param name="grupoUsuario">Instancia para la gestión de datos de usuarios.</param>
        public GrupoControlador(IGestorDatosGrupos gestorDatos, IGestorDatosUsuario grupoUsuario)
        {
            this.gestorDatos = gestorDatos;
            this.grupoUsuario = grupoUsuario;
        }

        /// <summary>
        /// Guarda el logo del grupo en la ruta especificada con un nuevo nombre.
        /// </summary>
        /// <param name="RutaDeArchivo">Ruta del archivo de origen del logo.</param>
        /// <param name="nuevoNombre">Nuevo nombre para el archivo del logo.</param>
        public void guardaLogo(string RutaDeArchivo, string nuevoNombre)
        {
            // Crear la carpeta si no existe
            if (!Directory.Exists(carpetaDestino))
            {
                Directory.CreateDirectory(carpetaDestino);
            }

            string rutaDestino = Path.Combine(carpetaDestino, nuevoNombre);

            //Ruta donde esta la imagen
            string rutaImagenSeleccionada = RutaDeArchivo;

            File.Copy(rutaImagenSeleccionada, rutaDestino, true);
        }

        /// <summary>
        /// Guarda un nuevo grupo con los datos proporcionados y su logo.
        /// </summary>
        /// <param name="identificacion">Identificación del usuario creador del grupo.</param>
        /// <param name="nombreGrupo">Nombre del grupo.</param>
        /// <param name="RutaDeArchivo">Ruta del archivo del logo del grupo.</param>
        /// <param name="integrantes">Lista de identificaciones de los integrantes del grupo.</param>
        /// <returns>True si el grupo se guardó correctamente; de lo contrario, false.</returns>
        public bool guardaGrupo(string identificacion, string nombreGrupo, string RutaDeArchivo, List<string> integrantes)
        {
            // Quitar espacios al nombre del grupo para usarlo en el nombre la de imagen
            nombreGrupo = nombreGrupo.Replace(" ", "");

            string nuevoNombreLogo = identificacion + nombreGrupo + Path.GetExtension(RutaDeArchivo);

            this.guardaLogo(RutaDeArchivo, nuevoNombreLogo);

            Grupo nuevoGrupo = new Grupo(identificacion, nuevoNombreLogo, nombreGrupo);

            gestorDatos.GuardarGrupos(nuevoGrupo);
            return gestorDatos.GuardarUsuarioGrupo(nuevoGrupo, integrantes);
        }

        /// <summary>
        /// Carga los posibles integrantes que pueden ser añadidos a un grupo.
        /// </summary>
        /// <returns>
        /// Un diccionario donde la clave es la identificación del usuario y el valor es el objeto <see cref="Usuario"/> correspondiente.
        /// </returns>
        public Dictionary<string, Usuario> cargarPosiblesIntegrantes()
        {
            return grupoUsuario.CargarUsuarios();
        }

        /// <summary>
        /// Carga la lista de usuarios que pertenecen a un grupo específico.
        /// </summary>
        /// <param name="idgrupo">El identificador único del grupo.</param>
        /// <returns>Una lista de objetos <see cref="Usuario"/> que pertenecen al grupo.</returns>
        public List<Usuario> CargarUsuarioPorGrupos(int idgrupo)
        {
            return grupoUsuario.CargarUsuarioPorGrupos(idgrupo) ?? new List<Usuario>();
        }

        /// <summary>
        /// Carga la lista de todos los grupos disponibles.
        /// </summary>
        /// <returns>Una lista de objetos <see cref="Grupo"/>.</returns>
        public List<Grupo> CargarGruposPorUsuario(string usuarioId)
        {
            return gestorDatos.CargarGruposPorUsuario(usuarioId);
        }

        /// <summary>
        /// Carga la lista de relaciones usuario-grupo existentes.
        /// </summary>
        /// <returns>Una lista de objetos <see cref="RelacionUsuarioGrupo"/>.</returns>
        public List<RelacionUsuarioGrupo> CargarUsuarioGrupos()
        {
            return gestorDatos.CargarUsuarioGrupos();
        }
    }
}