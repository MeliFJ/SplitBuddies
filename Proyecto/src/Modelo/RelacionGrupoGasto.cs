namespace Projecto.src.Modelo
{
    public class RelacionGrupoGasto
    {
        public int GastoId { get; set; }
        public int GrupoId { get; set; }

        
        public RelacionGrupoGasto(int grupoId, int gastoId)
        { 
            this.GastoId = gastoId;
            this.GrupoId = grupoId;
        }

        public RelacionGrupoGasto()
        {
        }
    }
}
