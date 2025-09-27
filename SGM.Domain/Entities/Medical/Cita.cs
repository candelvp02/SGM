using SGM.Domain.Entities.Configuration;

namespace SGM.Domain.Entities.Medical
{
    public class Cita : AuditEntity
    {
        public Guid Id { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public EstadoCita Estado { get; set; }
        public Guid MedicoId { get; set; }
        public Medico Medico { get; set; }
        public Guid PacienteId { get; set; }
        public Paciente Paciente { get; set; }
        public string Motivo { get; set; }
        public ICollection<Recordatorio> Recordatorios { get; set; }
    }
}
