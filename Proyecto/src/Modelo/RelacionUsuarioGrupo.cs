namespace Projecto.src.Modelo
{
    public class RelacionUsuarioGrupo
    {
        public string UsuarioId { get; set; }
        public int GrupoId { get; set; }

        
        public RelacionUsuarioGrupo(string UsuarioId, int GrupoId)
        { 
            this.UsuarioId = UsuarioId;
            this.GrupoId = GrupoId;
        }

        public RelacionUsuarioGrupo()
        {
        }
    }
}
