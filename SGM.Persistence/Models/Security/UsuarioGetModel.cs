using System;
using System.Collections.Generic;
using System.Linq;

namespace SGM.Persistence.Models.Security
{
    public class UsuarioGetModel
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Email { get; set; }
        public bool EsActivo { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public List<string> Roles { get; set; } = new List<string>();
        public string RolesPrincipal => Roles.FirstOrDefault();
        public DateTime? UltimoAcceso { get; set; }
    }
}