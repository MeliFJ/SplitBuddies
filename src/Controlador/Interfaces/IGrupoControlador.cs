using Modelo;
using System;
using System.Collections.Generic;

namespace Controlador.Interfaces
{
    public interface IGrupoControlador
    {
        List<Grupo> CargarGrupos();
        Dictionary<string, Usuario> cargarPosiblesIntegrantes();
        List<Usuario> CargarUsuarioPorGrupos(int idgrupo);
        bool guardaGrupo(string identificacion, string nombreGrupo, string RutaDeArchivo, List<string> integrantes);
        void guardaLogo(string RutaDeArchivo, string nuevoNombre);
    }
}