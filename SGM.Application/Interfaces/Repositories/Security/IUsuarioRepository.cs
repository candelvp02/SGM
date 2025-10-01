using SGM.Persistence.Base;

namespace SGM.Persistence.Interfaces.Security
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Task<Usuario> GetUsuarioByNombreUsuarioAsync(string nombreUsuario);
        Task<Usuario> GetUsuarioByEmailAsync(string email);
        Task<bool> ExisteNombreUsuarioAsync(string nombreUsuario);
        Task<bool> ExisteEmailAsync(string email);
        Task<IEnumerable<Usuario>> GetUsuariosActivosAsync();
        Task<IEnumerable<Usuario>> GetUsuariosByRolAsync(string nombreRol);
    }
}
