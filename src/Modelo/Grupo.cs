namespace Modelo
{
    public class Grupo
    {
        // Identificador unico  
        public int Id { get; set; }
        public string CreadorId { get; set; } = string.Empty;
        public string NombreLogo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;

        // Constructor  
        public Grupo(string identificadorUsuario, string nombreLogo, string nombre)
        {
            CreadorId = identificadorUsuario;
            NombreLogo = nombreLogo;
            Nombre = nombre;
        }

        public Grupo(int id, string identificadorUsuario, string nombreLogo, string nombre)
        {
            Id = id;
            CreadorId = identificadorUsuario;
            NombreLogo = nombreLogo;
            Nombre = nombre;
        }

        // ✅ Constructor sin parámetros (requerido para deserialización)  
        public Grupo() { }
    }
}
