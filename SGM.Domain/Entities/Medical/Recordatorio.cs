using SGM.Domain.Base;
using SGM.Domain.Entities.Configuration;

namespace SGM.Domain.Entities.Medical
{
    public class Recordatorio : AuditEntity
    {
        public int CitaId { get; set; }
        public Cita Cita { get; set; }

        public DateTime FechaEnvio { get; set; }
        public TipoNotificacion TipoNotificacion { get; set; }
        public string Mensaje { get; set; }
        public bool FueEnviado { get; set; }
        public Recordatorio()
        {
            FueEnviado = false;
        }
        public string ObtenerTipoNotificacionNombre()
        {
            return TipoNotificacion switch
            {
                TipoNotificacion.Email => "Email",
                TipoNotificacion.SMS => "Mensaje de Texto",
                TipoNotificacion.PushNotification => "Push Notification",
                _ => "No especificado"
            };
        }
        public bool DebeSerEnviado()
        {
            return !FueEnviado && FechaEnvio <= DateTime.Now;
        }
        public void MarcarComoEnviado()
        {
            FueEnviado = true;
            FechaModificacion = DateTime.Now;
        }
        public TimeSpan TiempoHastaEnvio()
        {
            return FechaEnvio - DateTime.Now;
        }
    }
}