using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


namespace Projecto.Modelo
{
    public class GestorDatos
    {
        private readonly string rutaArchivo = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Proyecto\src\assets\datos.json"));
        public void GuardarUsuario(Usuario usuario)
        {
            Dictionary<string, Usuario > usuarios = CargarUsuarios();

            if (usuarios.ContainsKey(usuario.Identificacion))
            {
                Console.WriteLine("Ya existe un usuario con esa identificación.");
                return;
            }

            usuarios[usuario.Identificacion] = usuario;

            var opciones = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(usuarios, opciones);
            File.WriteAllText(rutaArchivo, json);
        }

        public Dictionary<string, Usuario> CargarUsuarios()
        {
            if (!File.Exists(rutaArchivo))
                return new Dictionary<string, Usuario>();

            string json = File.ReadAllText(rutaArchivo);
            if (string.IsNullOrWhiteSpace(json))
                return new Dictionary<string, Usuario>();

            return JsonSerializer.Deserialize<Dictionary<string, Usuario>>(json);
        }

        public Usuario BuscarUsuario(string identificacion)
        {
            var usuarios = CargarUsuarios();
            usuarios.TryGetValue(identificacion, out Usuario usuario);
            return usuario;
        }

    }
}
