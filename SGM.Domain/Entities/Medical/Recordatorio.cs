using SGM.Domain.Base;
using SGM.Domain.Entities.Configuration;

namespace SGM.Domain.Entities.Medical
{
    public class Recordatorio : AuditEntity
    {
        public Guid Id { get; set; }
        public Cita Id { get; set; }
        public Cita Cita { get; set; }
        public DateTime FechaEnvio { get; set; }
        public TimeSpan HoraEnvio { get; set; }
        public TipoNotificacion Tipo { get; set; }
        public string Mensaje { get; set; }
        public bool Enviado { get; set; }
        public DateTime? FechaEnvioReal { get; set; }
        public bool Visto { get; set; }

        public TimeSpan TiempoAntelacion
        {
            get => Cita.Fecha - FechaEnvio;
            set => FechaEnvio = Cita.Fecha - value;
        }
    }
}
