using SGM.Domain.Entities.Configuration;
namespace SGM.Persistence.Models.Configuration

{
    public class CitaGetModel
    {
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public EstadoCita Estado { get; set; }
        public string Motivo { get; set; }
        public string Observaciones { get; set; }

        public int PacienteId { get; set; }
        public string PacienteNombre { get; set; }
        public string PacienteApellido { get; set; }
        public string PacienteCedula { get; set; }

        public int MedicoId { get; set; }
        public string MedicoNombre { get; set; }
        public string MedicoApellido { get; set; }
        public Especialidad MedicoEspecialidad { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}