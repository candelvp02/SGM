namespace SGM.Domain.Base
{
    public abstract class AuditEntity
    {
        public int Id { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public DateTime? FechaEliminacion { get; set; }
        public bool EstaEliminado { get; set; }

    }
}
