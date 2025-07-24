using Modelo;

namespace Controlador
{
    public class LoginControlador
    {
        protected LoginControlador()
        {

        }

        public static Usuario ValidarLogin(string identificacion, string password)
        {
            GestorDatos.GestorDatos servicio = new GestorDatos.GestorDatos();

            // Se busca si el usuario existe con la identificacion
            Usuario usuario=servicio.BuscarUsuario(identificacion);
            if(usuario != null && usuario.Password.Equals(password)) {
                return usuario;
            }
            return null;
        }
    }
}
