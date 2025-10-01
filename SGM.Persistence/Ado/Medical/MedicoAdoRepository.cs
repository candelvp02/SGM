using SGM.Domain.Entities.Configuration;
using SGM.Persistence.Ado.Common;
using SGM.Persistence.Models.Configuration;

namespace SGM.Persistence.Ado.Medical
{
    public class MedicoAdoRepository
    {
        private readonly StoredProcedureExecutor _sp;
        public MedicoAdoRepository(StoredProcedureExecutor sp) => _sp = sp;

        public async Task<List<MedicoGetModel>> ListarPorEspecialidadAsync(Especialidad especialidad)
        {
            var list = new List<MedicoGetModel>();

            using var r = await _sp.ExecuteReaderAsync("dbo.usp_Medico_ListarPorEspecialidad",
                                                      ("@Especialidad", (int)especialidad));

            while (await r.ReadAsync())
            {
                var m = new MedicoGetModel
                {
                    Id = r.GetInt32(r.GetOrdinal("Id")),
                    Nombre = r.GetString(r.GetOrdinal("Nombre")),
                    Apellido = r.GetString(r.GetOrdinal("Apellido")),
                    NumeroLicencia = r.GetString(r.GetOrdinal("NumeroLicencia")),
                    Especialidad = (Especialidad)r.GetInt32(r.GetOrdinal("Especialidad")),
                    Telefono = r.IsDBNull(r.GetOrdinal("Telefono")) ? "" : r.GetString(r.GetOrdinal("Telefono")),
                    Email = r.IsDBNull(r.GetOrdinal("Email")) ? "" : r.GetString(r.GetOrdinal("Email")),
                    CreatedAt = r.GetDateTime(r.GetOrdinal("CreatedAt"))
                };
            }
            return list;
        }
    }
}