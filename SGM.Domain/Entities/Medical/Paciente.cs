namespace SGM.Domain.Entities.Medical
{
    public class Paciente : Usuario
    {
        public string NumeroSeguro { get; set; }
        public string ProveedorSaludId { get; set; }
        public ProveedorSalud ProveedorSalud { get; set; }
        public ICollection<Cita> Citas { get; set; }
        public ICollection<Recordatorio> Recordatorios { get; set; }
    }
}
