using Modelo;
using System.Collections.Generic;

namespace GestorDatos.Interfaces
{
    public interface IGestorDatosGrupos
    {
        List<Grupo> CargarGrupos();
        bool EsNombreGrupoUnico(string nuevoNombreGrupo, string creadorId, List<Grupo> grupos);
        bool GuardarGrupos(Grupo grupo);
        bool GuardarUsuarioGrupo(Grupo grupo, List<string> integrantes);
        List<RelacionUsuarioGrupo> CargarUsuarioGrupos();

    }
}