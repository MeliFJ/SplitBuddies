using Controlador.Interfaces;
using GestorDatos.Interfaces;
using Modelo;
using System.Collections.Generic;
using System.Linq;

namespace Controlador
{
    public class UsuarioControlador:IUsuarioControlador
    {
        internal readonly IGestorDatosUsuario _gestorDatosUsuario;
        public UsuarioControlador( IGestorDatosUsuario gestorDatosUsuario)
        {
            _gestorDatosUsuario = gestorDatosUsuario;
        }

        public  bool GuardaUsuario(Usuario usuario)
        {
            
            
            Usuario usuaroexiste = _gestorDatosUsuario.BuscarUsuario(usuario.Identificacion);
            if (usuaroexiste != null && usuaroexiste.Identificacion.Equals(usuaroexiste.Identificacion))
            {
                
                return false;
            }
            else
            {
                _gestorDatosUsuario.GuardarUsuario(usuario);
                return true;
            }
              

        }

        public Usuario BuscarUsuario(string identificacion)
        {
            return _gestorDatosUsuario.BuscarUsuario(identificacion);
        }

    

        public List<Usuario> CargarUsuarioPorGrupos(int idgrupo)
        {
            return _gestorDatosUsuario.CargarUsuarioPorGrupos(idgrupo);
        }

        public Dictionary<string, Usuario> CargarUsuarios()
        {
            return _gestorDatosUsuario.CargarUsuarios();
        }

       

      
    }
}
