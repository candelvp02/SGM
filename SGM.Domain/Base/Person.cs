namespace SGM.Domain.Base
{
    public abstract class Person : AuditEntity
    {
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public string NombreCompleto => $"{Nombre} {Apellido}";
        public required string Cedula { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Edad
        {
            get
            {
                var hoy = DateTime.Today;
                var edad = hoy.Year - FechaNacimiento.Year;
                if (FechaNacimiento.Date > hoy.AddYears(-edad)) edad--;
                return edad;
            }
        }
        public required string Sexo { get; set; }
    }
}
