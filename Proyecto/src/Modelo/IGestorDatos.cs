
using System.Collections.Generic;
using Projecto.src.Modelo;

namespace Projecto.Modelo
{
    public interface IGestorDatos
    {
        void GuardarUsuario(Usuario usuario);
        bool GuardarGrupos(Grupo grupo, List<string> integrantes);
        bool GuardarUsuarioGrupo(Grupo grupo, List<string> integrantes);

        Dictionary<string, Usuario> CargarUsuarios();
        List<Grupo> CargarGrupos();
        List<RelacionUsuarioGrupo> CargarUsuarioGrupos();

        Usuario BuscarUsuario(string identificacion);
        bool EsNombreGrupoUnico(string nuevoNombreGrupo, string creadorId, List<Grupo> grupos);
        List<Usuario> CargarUsuarioPorGrupos(int idgrupo);
    }
}
