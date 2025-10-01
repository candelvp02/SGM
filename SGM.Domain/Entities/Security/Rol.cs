using SGM.Domain.Base;

namespace SGM.Domain.Entities.Security
{
    public class Rol : AuditEntity
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public ICollection<UsuarioRol> UsuarioRoles { get; set; }
        public Rol()
        {
            UsuarioRoles = new List<UsuarioRol>();
        }
        public int ObtenerCantidadUsuarios()
        {
            return UsuarioRoles.Count;
        }
        public bool EsRolAdministrador()
        {
            return Nombre.Equals("Administrador", StringComparison.OrdinalIgnoreCase);
        }
        public bool EsRolMedico()
        {
            return Nombre.Equals("Medico", StringComparison.OrdinalIgnoreCase);
        }
        public bool EsRolRecepcionista()
        {
            return Nombre.Equals("Recepcionista", StringComparison.OrdinalIgnoreCase);
        }
    }
}