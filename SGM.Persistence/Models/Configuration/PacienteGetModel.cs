namespace SGM.Persistence.Models.Configuration
{
    public class PacienteGetModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreCompleto => $"{Nombre} {Apellido}";
        public string Cedula { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Edad => DateTime.Now.Year - FechaNacimiento.Year;
        public string Sexo { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string ContactoEmergencia { get; set; }
        public string TelefonoEmergencia { get; set; }
        public DateTime CreatedAt { get; set; }
        public int TotalCitas { get; set; }
        public DateTime? UltimaCita { get; set; }
        public DateTime? ProximaCita { get; set; }
    }
}