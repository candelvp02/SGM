using SGM.Domain.Base;
using SGM.Domain.Entities.Configuration;
using SGM.Domain.Entities.Security;

namespace SGM.Domain.Entities.Medical
{
    public class Paciente : Person
    {
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string ContactoEmergencia { get; set; }
        public string TelefonoEmergencia { get; set; }
        public ICollection<Cita> Citas { get; set; }
        public Paciente()
        {
            Citas = new List<Cita>();
        }
        public int ObtenerCantidadCitas()
        {
            return Citas.Count;
        }
        public Cita ObtenerUltimaCita()
        {
            return Citas
                .Where(c => c.Estado == Configuration.EstadoCita.Completada)
                .OrderByDescending(c => c.FechaHora)
                .FirstOrDefault();
        }
        public Cita? ObtenerProximaCita()
        {
            return Citas
                .Where(c => c.Estado == EstadoCita.Programada || c.Estado == Configuration.EstadoCita.Confirmada && c.FechaHora > DateTime.Now)
                .OrderBy(c => c.FechaHora)
                .FirstOrDefault();
        }
    public bool TieneCitasPendientes()
        {
            return Citas.Any(c => c.Estado == EstadoCita.Programada || c.Estado == EstadoCita.Confirmada);
        }
        public List<Cita> ObtenerHistorialCitas()
        {
            return Citas
                 .Where(c => c.Estado == EstadoCita.Completada)
                 .OrderByDescending(c => c.FechaHora)
                 .ToList();
        }
        public int ObtenerCitasCanceladas()
        {
            return Citas.Count(c => c.Estado == EstadoCita.Cancelada);
        }
        public int ObtenerCitasNoAsistidas()
        {
            return Citas.Count(c => c.Estado == EstadoCita.NoAsistio);
        }
    }
}