using SGM.Persistence.Base;

namespace SGM.Persistence.Interfaces.Medical
{
    public interface IPacienteRepository : IBaseRepository<Paciente>
    {
        Task<Paciente> GetPacienteByCedulaAsync(string cedula);
        Task<IEnumerable<Paciente>> GetPacientesByNombreAsync(string nombre);
        Task<bool> ExisteCedulaAsync(string cedula);
        Task<IEnumerable<Paciente>> GetPacientesActivosAsync();
    }
}
