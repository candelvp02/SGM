namespace SGM.Persistence.Models.Configuration
{
    public class DisponibilidadGetModel
    {
        public int Id { get; set; }
        public DayOfWeek DiaSemana { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public bool EsActivo { get; set; }

        public int MedicoId { get; set; }
        public string MedicoNombre { get; set; }
        public string MedicoApellido { get; set; }
        public Especialidad MedicoEspecialidad { get; set; }
    }
}