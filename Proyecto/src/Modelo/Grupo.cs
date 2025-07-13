using System.Windows.Forms;

namespace Projecto.src.Modelo
{
    public class Grupo
    {
        //Identificador unico
        public int Id { get; set; }
        public string CreadorId { get; set; }
        public string NombreLogo { get; set; }
        public string Nombre { get; set; }

        // Constructor
        public Grupo( string identificadorUsuario, string nombreLogo, string nombre)
        {
            CreadorId= identificadorUsuario;
            NombreLogo = nombreLogo;
            Nombre = nombre;
        }
    }
}
