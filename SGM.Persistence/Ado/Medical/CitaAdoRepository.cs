using SGM.Domain.Entities.Configuration;
using SGM.Persistence.Ado.Common;
using SGM.Persistence.Models.Configuration;

namespace SGM.Persistence.Ado.Medical
{
    public class CitaAdoRepository
    {
        private readonly StoredProcedureExecutor _sp;
        public CitaAdoRepository(StoredProcedureExecutor sp) => _sp = sp;

        public async Task<List<CitaGetModel>> ListaPorMedicoYFechaAsync(int medicoId, DateTime fecha)
        {
            var list = new List<CitaGetModel>();

            using var r = await _sp.ExecuteReaderAsync("dbo.usp_Cita_ListarPorMedicoYFecha",
                                                      ("@MedicoId", medicoId),
                                                      ("@Fecha", fecha.Date));


            while (await r.ReadAsync())
            {
                list.Add(new CitaGetModel
                {
                    Id = r.GetInt32(r.GetOrdinal("Id")),
                    FechaHora = r.GetDateTime(r.GetOrdinal("FechaHora")),
                    Estado = (EstadoCita)r.GetInt32(r.GetOrdinal("Estado")),
                    Motivo = r.IsDBNull(r.GetOrdinal("Motivo")) ? "" : r.GetString(r.GetOrdinal("Motivo")),
                    Observaciones = r.IsDBNull(r.GetOrdinal("Observaciones")) ? "" : r.GetString(r.GetOrdinal("Observaciones")),
                    PacienteId = r.GetInt32(r.GetOrdinal("PacienteId")),
                    PacienteNombre = r.GetString(r.GetOrdinal("PacienteNombre")),
                    PacienteApellido = r.GetString(r.GetOrdinal("PacienteApellido")),
                    MedicoId = r.GetInt32(r.GetOrdinal("MedicoId")),
                    MedicoNombre = r.GetString(r.GetOrdinal("MedicoNombre")),
                    MedicoApellido = r.GetString(r.GetOrdinal("MedicoApellido"))
                });
            }
            return list;
        }
    }
}