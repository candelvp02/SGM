using SGM.Persistence.Base;
using SGM.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SGM.Persistence.Repositories.Security
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly SGMDbContext _context;

        public UsuarioRepository(SGMDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Usuario> GetUsuarioByNombreUsuarioAsync(string nombreUsuario)
        {
            var user = await _context.Usuarios
                .AsNoTracking()
                .Include(u => u.UsuarioRoles)
                    .ThenInclude(ur => ur.Rol)
                .FirstOrDefaultAsync(u => u.NombreUsuario == nombreUsuario && !u.IsDeleted);

            return user!; // Si quieres manejar "no encontrado", cambia la interfaz a Task<Usuario?>
        }

        public async Task<Usuario> GetUsuarioByEmailAsync(string email)
        {
            var user = await _context.Usuarios
                .AsNoTracking()
                .Include(u => u.UsuarioRoles)
                    .ThenInclude(ur => ur.Rol)
                .FirstOrDefaultAsync(u => u.Email == email && !u.IsDeleted);

            return user!; // Ídem comentario arriba
        }

        public Task<bool> ExisteNombreUsuarioAsync(string nombreUsuario)
        {
            return _context.Usuarios
                .AnyAsync(u => u.NombreUsuario == nombreUsuario && !u.IsDeleted);
        }

        public Task<bool> ExisteEmailAsync(string email)
        {
            return _context.Usuarios
                .AnyAsync(u => u.Email == email && !u.IsDeleted);
        }

        public async Task<IEnumerable<Usuario>> GetUsuariosActivosAsync()
        {
            return await _context.Usuarios
                .AsNoTracking()
                .Include(u => u.UsuarioRoles)
                    .ThenInclude(ur => ur.Rol)
                .Where(u => u.EsActivo && !u.IsDeleted)
                .OrderBy(u => u.NombreUsuario)
                .ToListAsync();
        }

        public async Task<IEnumerable<Usuario>> GetUsuariosByRolAsync(string nombreRol)
        {
            return await _context.Usuarios
                .AsNoTracking()
                .Include(u => u.UsuarioRoles)
                    .ThenInclude(ur => ur.Rol)
                .Where(u => u.UsuarioRoles.Any(ur => ur.Rol.Nombre == nombreRol) && !u.IsDeleted)
                .OrderBy(u => u.NombreUsuario)
                .ToListAsync();
        }
    }
}