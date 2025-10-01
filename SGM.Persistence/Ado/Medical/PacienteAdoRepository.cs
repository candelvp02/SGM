using SGM.Persistence.Ado.Common;
using SGM.Persistence.Models.Configuration;

namespace SGM.Persistence.Ado.Medical
{
    public class PacienteAdoRepository
    {
        private readonly StoredProcedureExecutor _sp;
        public PacienteAdoRepository(StoredProcedureExecutor sp) => _sp = sp;

        public async Task<List<PacienteGetModel>> BuscarPorNombreAsync(string texto)
        {
            var list = new List<PacienteGetModel>();

            using var r = await _sp.ExecuteReaderAsync("dbo.usp_Paciente_BuscarPorNombre",
                                                       ("@Texto", texto));

            while (await r.ReadAsync())
            {
                var p = new PacienteGetModel
                {
                    Id = r.GetInt32(r.GetOrdinal("Id")),
                    Nombre = r.GetString(r.GetOrdinal("Nombre")),
                    Apellido = r.GetString(r.GetOrdinal("Apellido")),
                    FechaNacimiento = r.GetDateTime(r.GetOrdinal("FechaNacimiento")),
                    Sexo = r.GetString(r.GetOrdinal("Sexo")),
                    Telefono = r.IsDBNull(r.GetOrdinal("Telefono")) ? "" : r.GetString(r.GetOrdinal("Telefono")),
                    Email = r.IsDBNull(r.GetOrdinal("Email")) ? "" : r.GetString(r.GetOrdinal("Email")),
                    Direccion = r.IsDBNull(r.GetOrdinal("Direccion")) ? "" : r.GetString(r.GetOrdinal("Direccion")),
                    CreatedAt = r.GetDateTime(r.GetOrdinal("CreatedAt"))
                };
                list.Add(p);
            }
            return list;
        }

    }
}