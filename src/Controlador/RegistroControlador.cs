using Modelo;
using System.Linq;

namespace Projecto.Controlador
{
    public class RegistroControlador
    {
        protected RegistroControlador()
        {

        }

        public static bool GuardaUsuario(Usuario usuario)
        {
            
            GestorDatos.GestorDatos gestorDatos = new GestorDatos.GestorDatos();
            Usuario usuaroexiste = gestorDatos.BuscarUsuario(usuario.Identificacion);
            if (usuaroexiste != null && usuaroexiste.Identificacion.Equals(usuaroexiste.Identificacion))
            {
                
                return false;
            }
            else
            {
                gestorDatos.GuardarUsuario(usuario);
                return true;
            }
              

        }
}
}
