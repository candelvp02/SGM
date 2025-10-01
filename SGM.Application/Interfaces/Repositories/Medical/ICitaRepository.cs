namespace SGM.Persistence.Interfaces.Medical
{
    public interface ICitaRepository : IBaseRepository<Cita> 
    {
        Task<IEnumerable<Cita>> GetCitasByPacienteAsync(int pacienteId);
        Task<IEnumerable<Cita>> GetCitasByMedicoAsync(int medicoId);
        Task<IEnumerable<Cita>> GetCitasByFechaAsync(DateTime fecha);
        Task<IEnumerable<Cita>> GetCitasByEstadoAsync(EstadoCita estado);
        Task<bool> ExisteCitaEnHorarioAsync(int medicoId, DateTime fechaHora);
        Task<IEnumerable<Cita>> GetCitasProximasAsync(DateTime fechaInicio, DateTime fechaFin);
    }
}
