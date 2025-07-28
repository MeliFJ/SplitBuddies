namespace Modelo
{
    public class RelacionUsuarioGasto
    {
        public string UsuarioId { get; set; }
        public int GastoId { get; set; }

        
        public RelacionUsuarioGasto(string UsuarioId, int GastoId)
        { 
            this.UsuarioId = UsuarioId;
            this.GastoId = GastoId;
        }

        public RelacionUsuarioGasto()
        {
        }
    }
}
