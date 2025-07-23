using Projecto.Modelo;
using Projecto.src.Modelo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Projecto.src.Controlador
{
    public class GrupoControlador
    {
        private IGestorDatos gestorDatos;
        private string carpetaDestino = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Proyecto\src\assets\img\"));


        public GrupoControlador(IGestorDatos gestorDatos)
        {
            this.gestorDatos = gestorDatos;
        }
        public void guardaLogo(string identificacion, string nombreGrupo, OpenFileDialog logoSelecionado, string nuevoNombreLogo)
        {
            //Ruta donde esta la imagen
            string rutaImagenSeleccionada = logoSelecionado.FileName;

            // Crear la carpeta si no existe
            if (!Directory.Exists(carpetaDestino))
            {
                Directory.CreateDirectory(carpetaDestino);
            }

            // Quitar espacios al nombre del grupo para usarlo en el nombre la de imagen
            nombreGrupo = nombreGrupo.Replace(" ", "");

            // Cambiar el nombre de la imagen
            string nuevoNombre = identificacion + nombreGrupo + Path.GetExtension(rutaImagenSeleccionada);

            string rutaDestino = Path.Combine(carpetaDestino, nuevoNombre);

            File.Copy(rutaImagenSeleccionada, rutaDestino, true);

        }

        public bool guardaGrupo(string identificacion, string nombreGrupo, OpenFileDialog logoSelecionado, List<string> integrantes)
        {
            string nuevoNombreLogo = identificacion + nombreGrupo;
            this.guardaLogo(identificacion, nombreGrupo, logoSelecionado, nuevoNombreLogo);

            Grupo nuevoGrupo = new Grupo(identificacion, nuevoNombreLogo, nombreGrupo);

            return gestorDatos.GuardarGrupos(nuevoGrupo, integrantes);
        }

        public Dictionary<string, Usuario> cargarPosiblesIntegrantes()
        {
            return gestorDatos.CargarUsuarios();
        }
        public List<Usuario> CargarUsuarioPorGrupos(int idgrupo)
        {
            return gestorDatos.CargarUsuarioPorGrupos(idgrupo);
        }

        public List<Grupo> CargarGrupos()
        {
            return gestorDatos.CargarGrupos();
        }
    }
}