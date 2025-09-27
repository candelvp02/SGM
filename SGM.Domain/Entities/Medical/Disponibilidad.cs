using SGM.Domain.Base;

namespace SGM.Domain.Entities.Medical
{
    public class Disponibilidad : AuditEntity
    {
        public Guid Id { get; set; }
        public Guid MedicoId { get; set; }
        public Medico Medico { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public bool EstaDisponible { get; set; }
        public ICollection<Cita> Citas { get; set; }

        public bool EstaDisponibleEn(DateTime fecha, TimeSpan hora)
        {
            return EstaDisponible && 
                   fecha.Date == Fecha.Date && hora >= HoraInicio && hora <= HoraFin && Citas.All(c => c.Fecha.Date != fecha.Date || c.Hora != hora);
        }
    }
}
