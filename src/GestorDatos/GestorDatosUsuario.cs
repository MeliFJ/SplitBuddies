using GestorDatos.Interfaces;
using Modelo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GestorDatos
{
    public class GestorDatosUsuario : GestorDatosBase, IGestorDatosUsuario
    {
        public void GuardarUsuario(Usuario usuario)
        {
            Dictionary<string, Usuario> usuarios = CargarUsuarios();

            //Se valida que no exita el usuario
            if (usuarios.ContainsKey(usuario.Identificacion)==false)
            {
                usuarios[usuario.Identificacion] = usuario;

                var opciones = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(usuarios, opciones);
                File.WriteAllText(rutaArchivo, json);
            }
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

        public List<Usuario> CargarUsuarioPorGrupos(int idgrupo)
        {
            if (!File.Exists(rutaArchivoGrupos))
                return new List<Usuario>();

            string json = File.ReadAllText(rutaArchivoUsuarioGrupos);
            if (string.IsNullOrWhiteSpace(json))
                return new List<Usuario>();
            var relacionusuariosgrupo = JsonSerializer.Deserialize<List<RelacionUsuarioGrupo>>(json)?.Where(x => x.GrupoId == idgrupo).ToList();
            var usuarios = CargarUsuarios().ToList();
            var resul = from usuario
                        in usuarios
                        join relacion in relacionusuariosgrupo
                        on usuario.Key equals relacion.UsuarioId
                        select usuario.Value;

            return resul?.ToList();
        }

   
    }


}
