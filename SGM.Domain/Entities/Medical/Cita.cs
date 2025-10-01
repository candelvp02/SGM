using SGM.Domain.Base;
using SGM.Domain.Entities.Configuration;

namespace SGM.Domain.Entities.Medical
{
    public class Cita : AuditEntity
    {
       public DateTime FechaHora { get; set; }
       public EstadoCita Estado { get; set; }
       public string Motivo { get; set; }
       public string Observaciones { get; set; }

       public int PacienteId { get; set; }
       public Paciente Paciente { get; set; }

        public int MedicoId { get; set; }
        public Medico Medico { get; set; }

        public ICollection<Recordatorio> Recordatorios { get; set; }

        public Cita()
        {
            Estado = EstadoCita.Programada;
            Recordatorios = new List<Recordatorio>();
        }

        public bool PuedeSerCancelada()
        {
            return Estado == EstadoCita.Programada || Estado == EstadoCita.Confirmada;
        }

        public bool PuedeSerConfirmada()
        {
            return Estado == EstadoCita.Programada;
        }
        public TimeSpan TiempoRestante()
        {
            return FechaHora - DateTime.Now;
        }

        public bool EsCitaPasada()
        {
            return FechaHora < DateTime.Now;
        }

        public void Confirmar()
        {
            if (PuedeSerConfirmada())
            {
                Estado = EstadoCita.Confirmada;
                FechaModificacion = DateTime.Now;
            }
        }

        public void Cancelar()
        {
            if(PuedeSerCancelada())
            {
                Estado = EstadoCita.Cancelada;
                FechaModificacion = DateTime.Now;
            }
        }

        public void IniciarConsulta()
        {
            Estado = EstadoCita.EnCurso;
            FechaModificacion = DateTime.Now;
        }

        public void Completar(string observaciones = null)
        {
            Estado = EstadoCita.Completada;
            if(!string.IsNullOrEmpty(observaciones) )
            {
                Observaciones = observaciones;
            }
            FechaModificacion = DateTime.Now;
        }
    }
}