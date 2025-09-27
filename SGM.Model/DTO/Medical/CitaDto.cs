namespace SGM.Model.DTO.Medical
{
    public class CitaDto
    {
        public Guid Id { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public EstadoCita Estado { get; set; }
        public MedicoDto Medico { get; set; }
        public PacienteDto Paciente { get; set; }
        public string Motivo { get; set; }
    }

    public class CrearCitaDto
    {
        public Guid MedicoId { get; set; }
        public Guid PacienteId { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public string Motivo { get; set; }
    }
}
