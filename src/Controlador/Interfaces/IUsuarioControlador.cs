using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador.Interfaces
{
    public interface IUsuarioControlador
    {

            Usuario BuscarUsuario(string identificacion);
            List<Usuario> CargarUsuarioPorGrupos(int idgrupo);
            Dictionary<string, Usuario> CargarUsuarios();
          bool GuardaUsuario(Usuario usuario);



    }
}
