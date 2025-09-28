using SGM.Domain.Entities.Security;

namespace SGM.Domain.Entities.Medical
{
    public class Medico : Usuario
    {
        public string Especialidad { get; set; }
        public string NumeroColegiado { get; set; }
        public ICollection<Disponibilidad> Disponibilidades { get; set; }
        public ICollection<Cita> Citas { get; set; }
    }
}
