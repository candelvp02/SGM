namespace SGM.Persistence.Interfaces.Medical
{
    public interface IMedicoRepository : IBaseRepository<Medico>
    {
        Task<IEnumerable<Medico>> GetMedicosByEspecialidadAsync(Especialidad especialidad);
        Task<Medico> GetMedicoByLicenciaAsync(string numeroLicencia);
        Task<Medico> GetMedicoByCedulaAsync(string numeroCedula);
        Task<bool> ExisteLicenciaAsync(string numeroLicencia);
        Task<IEnumerable<Medico>> GetMedicosDisponiblesAsync(DateTime fecha);
    }
}
