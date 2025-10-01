using SGM.Domain.Base;

namespace SGM.Domain.Entities.Security
{
    public class UsuarioRol : AuditEntity
    {
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int RolId { get; set; }
        public Rol Rol { get; set; }
        public DateTime FechaAsignacion { get; set; }
        public UsuarioRol()
        {
            FechaAsignacion = DateTime.Now;
        }
        public string ObtenerInformacionCompleta()
        {
                       return $"{Usuario?.NombreUsuario} - {Rol?.Nombre}";
        }
        public TimeSpan TiempoConRol()
        {
                       return DateTime.Now - FechaAsignacion;
        }
    }
}