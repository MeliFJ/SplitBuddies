﻿using Projecto.Modelo;
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
        public void guardaLogo(OpenFileDialog logoSelecionado, string nuevoNombre)
        {

            // Crear la carpeta si no existe
            if (!Directory.Exists(carpetaDestino))
            {
                Directory.CreateDirectory(carpetaDestino);
            }

            string rutaDestino = Path.Combine(carpetaDestino, nuevoNombre);

            //Ruta donde esta la imagen
            string rutaImagenSeleccionada = logoSelecionado.FileName;

            File.Copy(rutaImagenSeleccionada, rutaDestino, true);

        }

        public bool guardaGrupo(string identificacion, string nombreGrupo, OpenFileDialog logoSelecionado, List<string> integrantes)
        {
            // Quitar espacios al nombre del grupo para usarlo en el nombre la de imagen
            nombreGrupo = nombreGrupo.Replace(" ", "");

            string nuevoNombreLogo = identificacion + nombreGrupo + Path.GetExtension(logoSelecionado.FileName);

            this.guardaLogo(logoSelecionado, nuevoNombreLogo);

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