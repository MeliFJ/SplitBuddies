using Modelo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;


namespace GestorDatos
{
    public class GestorDatos : IGestorDatos
    {
        private readonly string rutaArchivo = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\assets\datos.json"));
        private readonly string rutaArchivoGrupos = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\assets\grupos.json"));
        private readonly string rutaArchivoUsuarioGrupos = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\assets\usuario-grupo.json"));
        private readonly string rutaArchivoGastos = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\assets\gastos.json"));
        private readonly string rutaRelacionGrupoGasto = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\assets\grupo-gasto.json"));
        private readonly string rutaRelacionUsuarioGasto = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\assets\usuario-gasto.json"));
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

        public bool GuardarGasto(Gasto gasto, List<string> integrantes, string quienPagoId, Grupo grupo)
        {
            List<Grupo> grupos = CargarDesdeJson<Grupo>(rutaArchivoGrupos);
            if (!grupos.Any(g => g.Id == grupo.Id))
            {
                return false; // El grupo no existe
            }

            List<Gasto> gastos = CargarDesdeJson<Gasto>(rutaArchivoGastos);

            //Obetener el id del nuevo
            int nuevoId = 1;
            if (gastos.Count > 0)
            {
                nuevoId = gastos.Max(g => g.Id) + 1;
            }
            gasto.Id = nuevoId;

            gastos.Add(gasto);

            // Se guarda el gasto en el archivo JSON
            this.EscribirEnJson(rutaArchivoGastos, gastos);

            // Se guarda la relacion entre el gasto y el grupo
            this.guardarGrupoGasto(grupo, gasto);

            this.guardarUsuarioGasto(gasto, integrantes);

            return true;
        }

        private void guardarUsuarioGasto(Gasto gasto, List<string> integrantes)
        {
            List<RelacionUsuarioGasto> relacionGrupoGastos = CargarDesdeJson<RelacionUsuarioGasto>(rutaRelacionUsuarioGasto);

            foreach (string integranteId in integrantes)
            {
                // Se crea una nueva relacion entre el usuario y el gasto
                RelacionUsuarioGasto nuevaRelacion = new RelacionUsuarioGasto(integranteId, gasto.Id);
                relacionGrupoGastos.Add(nuevaRelacion);
            }

            this.EscribirEnJson(rutaRelacionUsuarioGasto, relacionGrupoGastos);
        }

        public void guardarGrupoGasto(Grupo grupo, Gasto gasto)
        {
            List<RelacionGrupoGasto> relacionGrupoGastos = CargarDesdeJson<RelacionGrupoGasto>(rutaRelacionGrupoGasto);
            RelacionGrupoGasto nuevaRelacion = new RelacionGrupoGasto(grupo.Id, gasto.Id);
            relacionGrupoGastos.Add(nuevaRelacion);

            this.EscribirEnJson(rutaRelacionGrupoGasto, relacionGrupoGastos);

        }

        /// <summary>
        /// Serializa una lista de objetos a formato JSON y la guarda en un archivo.
        /// </summary>
        /// <typeparam name="T">El tipo de los objetos contenidos en la lista.</typeparam>
        /// <param name="rutaArchivo">Ruta completa del archivo donde se guardará el JSON.</param>
        /// <param name="lista">Lista de objetos que se desea serializar.</param>
        /// <remarks>
        /// Si el archivo ya existe, será sobrescrito. El JSON se guarda con formato indentado para facilitar su lectura.
        /// </remarks>

        private void EscribirEnJson<T>(string rutaArchivo, List<T> lista)
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
