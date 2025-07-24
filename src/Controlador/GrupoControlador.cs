using GestorDatos;
using Modelo;
using System;
using System.Collections.Generic;
using System.IO;

namespace Controlador
{
    public class GrupoControlador
    {
        private IGestorDatos gestorDatos;
        private string carpetaDestino = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Proyecto\src\assets\img\"));


        public GrupoControlador(IGestorDatos gestorDatos)
        {
            this.gestorDatos = gestorDatos;
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

        public bool guardaGrupo(string identificacion, string nombreGrupo, string  RutaDeArchivo, List<string> integrantes)
        {
            // Quitar espacios al nombre del grupo para usarlo en el nombre la de imagen
            nombreGrupo = nombreGrupo.Replace(" ", "");

            string nuevoNombreLogo = identificacion + nombreGrupo + Path.GetExtension(RutaDeArchivo);

            this.guardaLogo(RutaDeArchivo, nuevoNombreLogo);

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

        /// Guardar un gasto en el grupo
        public bool guardarGasto(Grupo grupo, Usuario quienPago, string nombreGasto, string descripcionGasto, string enlaceGasto, double montoGasto, List<string> integrantes, DateTime fechaSeleccionada)
        {
            Gasto nuevoGasto = new Gasto(nombreGasto, descripcionGasto, enlaceGasto, montoGasto, quienPago.Identificacion, fechaSeleccionada);
            //Verificar si el que pago esta como integrante del grupo
            integrantes = validarIntegrantes(integrantes, quienPago);

            return gestorDatos.GuardarGasto(nuevoGasto, integrantes, quienPago.Identificacion, grupo);
        }

        private List<string> validarIntegrantes(List<string> integrantes, Usuario usuarioLogeado)
        {
            // Validar que el usuario logueado esté en la lista de integrantes
            if (!integrantes.Contains(usuarioLogeado.Identificacion))
            {
                integrantes.Add(usuarioLogeado.Identificacion);
            }
            return integrantes;
        }
    }
}