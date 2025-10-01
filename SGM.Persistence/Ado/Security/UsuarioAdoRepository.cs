using SGM.Persistence.Ado.Common;
using SGM.Persistence.Models.Security;

namespace SGM.Persistence.Ado.Security
{
    public class UsuarioAdoRepository
    {
        private readonly StoredProcedureExecutor _sp;
        public UsuarioAdoRepository(StoredProcedureExecutor sp) => _sp = sp;

        public async Task<List<UsuarioGetModel>> ListarActivosAsync()
        {
            var result = new List<UsuarioGetModel>();

            using var r = await _sp.ExecuteReaderAsync("dbo.usp_Usuario_ListarActivos");
            while (await r.ReadAsync())
            {
                result.Add(new UsuarioGetModel
                {
                    Id = r.GetInt32(r.GetOrdinal("Id")),
                    NombreUsuario = r.GetString(r.GetOrdinal("NombreUsuario")),
                    Email = r.GetString(r.GetOrdinal("Email")),
                    EsActivo = r.GetBoolean(r.GetOrdinal("EsActivo")),
                    CreatedAt = r.GetDateTime(r.GetOrdinal("CreatedAt")),
                    ModifiedAt = r.IsDBNull(r.GetOrdinal("ModifiedAt"))
                                 ? (DateTime?)null
                                 : r.GetDateTime(r.GetOrdinal("ModifiedAt"))
                });
            }
            return result;
        }
        public async Task<List<UsuarioGetModel>> ListarPorRolAsync(string rolNombre)
        {
            var result = new List<UsuarioGetModel>();

            using var r = await _sp.ExecuteReaderAsync("dbo.usp_Usuario_ListarPorRol",
                                                       ("@RolNombre", rolNombre));
            while (await r.ReadAsync())
            {
                result.Add (new UsuarioGetModel
                {
                    Id = r.GetInt32(r.GetOrdinal("Id")),
                    NombreUsuario = r.GetString(r.GetOrdinal("NombreUsuario")),
                    Email = r.GetString(r.GetOrdinal("Email")),
                    EsActivo = r.GetBoolean(r.GetOrdinal("EsActivo")),
                    CreatedAt = r.GetDateTime(r.GetOrdinal("CreatedAt")),
                    ModifiedAt = r.IsDBNull(r.GetOrdinal("ModifiedAt"))
                                 ? (DateTime?)null
                                 : r.GetDateTime(r.GetOrdinal("ModifiedAt"))
                });
            }
            return result;
        }
    }
}