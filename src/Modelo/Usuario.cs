namespace Modelo
{
    public class Usuario
    {
        public string Identificacion { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        // Constructor
        public Usuario(string identificacion, string password, string nombre, string apellido)
        {
            Identificacion = identificacion;
            Password = password;
            Nombre = nombre;
            Apellido = apellido;
        }


        public override string ToString()
        {
            return Nombre; // Esto es lo que se muestra en el CheckedListBox
        }

    }
}
