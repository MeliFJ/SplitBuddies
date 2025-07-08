using Projecto.Modelo;

namespace Projecto.Controlador
{
    public class LoginControlador
    {
        protected LoginControlador()
        {

        }

        public static bool ValidarLogin(string identificacion, string password)
        {
            //Usuario nuevoUsuario = new Usuario("116640546", "1234", "Melissa", "Fallas");
            GestorDatos servicio = new GestorDatos();
            //servicio.GuardarUsuario(nuevoUsuario);

            // Se busca si el usuario existe con la identificacion
            Usuario usuario=servicio.BuscarUsuario(identificacion);
            if(usuario != null && usuario.Password.Equals(password)) {
                return true;
            }
            return false;
        }
    }
}
