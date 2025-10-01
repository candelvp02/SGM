namespace SGM.Persistence.Models.Configuration
{
    public class MedicoGetModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreCompleto => $"{Nombre} {Apellido}";
        public string Cedula { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public string NumeroLicencia { get; set; }
        public Especialidad Especialidad { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public int TotalCitas { get; set; }
        public int CitasPendientes { get; set; }
        public bool TieneDisponibilidad { get; set; }
    }
}