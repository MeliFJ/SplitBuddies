using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projecto.Modelo;

namespace Projecto.Controlador
{
    public class LoginControlador
    {
        private List<Usuario> usuariosRegistrados;

        public LoginControlador()
        {
            // Simular datos, o luego conectar a DB
            usuariosRegistrados = new List<Usuario>
        {
            new Usuario("admin", "1234", "Admin", "Principal")
        };
        }

        public bool ValidarLogin(string identificacion, string password)
        {
            return true;
        }
    }
}
