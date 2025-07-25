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
    public class GestorDatosGrupos : GestorDatosBase, IGestorDatosGrupos
    {
        public bool GuardarGrupos(Grupo grupo)
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

               // return GuardarUsuarioGrupo(grupo, integrantes);
                return true;
            }

            return false;
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

        public bool EsNombreGrupoUnico(string nuevoNombreGrupo, string creadorId, List<Grupo> grupos)
        {
            return !grupos.Any(g =>
                g.CreadorId.Equals(creadorId) &&
                string.Equals(g.Nombre.Trim(), nuevoNombreGrupo.Trim())
            );
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

        public List<RelacionUsuarioGrupo> CargarUsuarioGrupos()
        {
            if (!File.Exists(rutaArchivoGrupos))
                return new List<RelacionUsuarioGrupo>();

            string json = File.ReadAllText(rutaArchivoUsuarioGrupos);
            if (string.IsNullOrWhiteSpace(json))
                return new List<RelacionUsuarioGrupo>();

            return JsonSerializer.Deserialize<List<RelacionUsuarioGrupo>>(json);
        }


    }
}
