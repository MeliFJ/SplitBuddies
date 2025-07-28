using Controlador.Interfaces;
using GestorDatos;
using GestorDatos.Interfaces;
using Modelo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Permissions;

namespace Controlador
{
    public class GrupoControlador : IGrupoControlador
    {
        private IGestorDatosGrupos gestorDatos;
        private IGestorDatosUsuario grupoUsuario;
        private string carpetaDestino = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\src\assets\img\"));


        public GrupoControlador(IGestorDatosGrupos gestorDatos, IGestorDatosUsuario grupoUsuario)
        {
            this.gestorDatos = gestorDatos;
            this.grupoUsuario = grupoUsuario;
        }
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

        public Dictionary<string, Usuario> cargarPosiblesIntegrantes()
        {
            return grupoUsuario.CargarUsuarios();
        }
        public List<Usuario> CargarUsuarioPorGrupos(int idgrupo)
        {
            return grupoUsuario.CargarUsuarioPorGrupos(idgrupo);
        }

        public List<Grupo> CargarGrupos()
        {
            return gestorDatos.CargarGrupos();
        }
        public List<RelacionUsuarioGrupo> CargarUsuarioGrupos()
        {
            return gestorDatos.CargarUsuarioGrupos();
        }

        /// Guardar un gasto en el grupo


    }
}