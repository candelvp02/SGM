using SGM.Domain.Entities.Medical;

namespace SGM.Domain.Interfaces.Repository
{
    public interface ICitaRepository : IBaseRepository<Cita>
    {
        Task<IEnumerable<Cita>> GetCitasByMedicoIdAsync(Guid medicoId);
        Task<IEnumerable<Cita>> GetCitasByPacienteIdAsync(Guid pacienteId);
        Task<Cita> GetCitaWithDetailsAsync(Guid id);
    }
}
