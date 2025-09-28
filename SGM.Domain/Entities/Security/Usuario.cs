using SGM.Domain.Base;

namespace SGM.Domain.Entities.Security
{
    public class Usuario : AuditEntity
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Rol { get; set; }
        public ICollection<UsuarioRol> Roles { get; set; }
    }
}
