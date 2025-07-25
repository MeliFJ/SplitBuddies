using Modelo;
using System.Collections.Generic;

namespace GestorDatos.Interfaces
{
    public interface IGestorDatosUsuario
    {
        Usuario BuscarUsuario(string identificacion);
        List<Usuario> CargarUsuarioPorGrupos(int idgrupo);
        Dictionary<string, Usuario> CargarUsuarios();
        void GuardarUsuario(Usuario usuario);
    }
}