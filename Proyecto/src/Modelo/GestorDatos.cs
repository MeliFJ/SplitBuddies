using Projecto.src.Modelo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;


namespace Projecto.Modelo
{
    public class GestorDatos : IGestorDatos
    {
        private readonly string rutaArchivo = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Proyecto\src\assets\datos.json"));
        private readonly string rutaArchivoGrupos = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Proyecto\src\assets\grupos.json"));
        private readonly string rutaArchivoUsuarioGrupos = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Proyecto\src\assets\usuario-grupo.json"));
        public void GuardarUsuario(Usuario usuario)
        {
            Dictionary<string, Usuario > usuarios = CargarUsuarios();

            //Se valida que no exita el usuario
            if (usuarios.ContainsKey(usuario.Identificacion))
            {
                usuarios[usuario.Identificacion] = usuario;

                var opciones = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(usuarios, opciones);
                File.WriteAllText(rutaArchivo, json);
            }
        }
        public bool GuardarGrupos(Grupo grupo, List<string> integrantes)
        {
            List<Grupo> grupos = CargarGrupos();

            //Se valida que no exita el grupo
            if (EsNombreGrupoUnico(grupo.Nombre, grupo.CreadorId, grupos))
            {
                // Busca el id mas grande y le agrega 1 para el nuevo
                int nuevoId = 1;
                if (grupos.Count > 0)
                {
                    nuevoId = grupos.Max(g => g.Id) + 1;
                }
                grupo.Id = nuevoId;

                grupos.Add(grupo);
                var opciones = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(grupos, opciones);
                File.WriteAllText(rutaArchivoGrupos, json);

                return this.GuardarUsuarioGrupo(grupo, integrantes);
            }

            return false;
        }


        public bool GuardarUsuarioGrupo(Grupo grupo, List<string> integrantes)
        {
            List<RelacionUsuarioGrupo> relaciones = CargarUsuarioGrupos();

            foreach (string integranteId in integrantes)
            {
                relaciones.Add(new RelacionUsuarioGrupo(integranteId, grupo.Id));
            }

            var opciones = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(relaciones, opciones);
            File.WriteAllText(rutaArchivoUsuarioGrupos, json);
            return true;
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

        public List<Grupo> CargarGrupos()
        {
            if (!File.Exists(rutaArchivoGrupos))
                return new List<Grupo>();

            string json = File.ReadAllText(rutaArchivoGrupos);
            if (string.IsNullOrWhiteSpace(json))
                return new List<Grupo>();

            return JsonSerializer.Deserialize<List<Grupo>>(json);
        }

        public List<RelacionUsuarioGrupo> CargarUsuarioGrupos()
        {
            if (!File.Exists(rutaArchivoGrupos))
                return new List<RelacionUsuarioGrupo>();

            string json = File.ReadAllText(rutaArchivoUsuarioGrupos);
            if (string.IsNullOrWhiteSpace(json))
                return new List<RelacionUsuarioGrupo>();

            return JsonSerializer.Deserialize<List<RelacionUsuarioGrupo>>(json);
        }


        public Usuario BuscarUsuario(string identificacion)
        {
            var usuarios = CargarUsuarios();
            usuarios.TryGetValue(identificacion, out Usuario usuario);
            return usuario;
        }

      

        public bool EsNombreGrupoUnico(string nuevoNombreGrupo, string creadorId, List<Grupo> grupos)
        {
            return !grupos.Any(g =>
                g.CreadorId.Equals(creadorId) &&
                string.Equals(g.Nombre.Trim(), nuevoNombreGrupo.Trim())
            );
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
