using GestorDatos;
using GestorDatos.Interfaces;
using Modelo;

namespace Controlador
{
    public class LoginControlador
    {
        IGestorDatosUsuario GestorDatosUsuario;
        public LoginControlador(IGestorDatosUsuario gestorDatosUsuario)
        {
            GestorDatosUsuario=gestorDatosUsuario;
        }

        public  Usuario ValidarLogin(string identificacion, string password)
        {
            // Se busca si el usuario existe con la identificacion
            Usuario usuario= GestorDatosUsuario.BuscarUsuario(identificacion);
            if(usuario != null && usuario.Password.Equals(password)) {
                return usuario;
            }
            return null;
        }
    }
}
