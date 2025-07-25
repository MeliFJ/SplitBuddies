using GestorDatos.Interfaces;
using Modelo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;


namespace GestorDatos
{
    public class GestorDatosBase 
    {
        internal readonly string rutaArchivo = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\assets\datos.json"));
        internal readonly string rutaArchivoGrupos = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\assets\grupos.json"));
        internal readonly string rutaArchivoUsuarioGrupos = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\assets\usuario-grupo.json"));
        internal readonly string rutaArchivoGastos = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\assets\gastos.json"));
        internal readonly string rutaRelacionGrupoGasto = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\assets\grupo-gasto.json"));
        internal readonly string rutaRelacionUsuarioGasto = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\assets\usuario-gasto.json"));

        /// <summary>
        /// Serializa una lista de objetos a formato JSON y la guarda en un archivo.
        /// </summary>
        /// <typeparam name="T">El tipo de los objetos contenidos en la lista.</typeparam>
        /// <param name="rutaArchivo">Ruta completa del archivo donde se guardará el JSON.</param>
        /// <param name="lista">Lista de objetos que se desea serializar.</param>
        /// <remarks>
        /// Si el archivo ya existe, será sobrescrito. El JSON se guarda con formato indentado para facilitar su lectura.
        /// </remarks>
        internal void EscribirEnJson<T>(string rutaArchivo, List<T> lista)
        {
            var opciones = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(lista, opciones);
            File.WriteAllText(rutaArchivo, json);
        }

        /// <summary>
        /// Carga una lista de objetos desde un archivo JSON.
        /// </summary>
        /// <typeparam name="T">El tipo de objeto que contiene la lista.</typeparam>
        /// <param name="rutaArchivo">Ruta completa del archivo JSON.</param>
        /// <returns>Una lista de objetos del tipo especificado. Si el archivo no existe o está vacío, retorna una lista vacía.</returns

        public static List<T> CargarDesdeJson<T>(string rutaArchivo)
        {
            if (!File.Exists(rutaArchivo))
                return new List<T>();

            string json = File.ReadAllText(rutaArchivo);
            if (string.IsNullOrWhiteSpace(json))
                return new List<T>();

            return JsonSerializer.Deserialize<List<T>>(json);
        }
    }
}
