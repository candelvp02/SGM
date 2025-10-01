using SGM.Persistence.Base;
using SGM.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SGM.Persistence.Repositories.Medical
{
    public class PacienteRepository : BaseRepository<Paciente>, IPacienteRepository
    {
        private readonly SGMDbContext _context;

        public PacienteRepository(SGMDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Paciente> GetPacienteByCedulaAsync(string cedula)
        {
            return await _context.Pacientes
                .Include(p => p.Citas)
                .FirstOrDefaultAsync(p => p.Cedula == cedula && !p.IsDeleted);
        }

        public async Task<IEnumerable<Paciente>> GetPacientesByNombreAsync(string nombre)
        {
            return await _context.Pacientes
                .Where(p => (p.Nombre.Contains(nombre) || p.Apellido.Contains(nombre)) && !p.IsDeleted)
                .OrderBy(p => p.Nombre)
                .ThenBy(p => p.Apellido)
                .ToListAsync();
        }

        public async Task<bool> ExisteCedulaAsync(string cedula)
        {
            return await _context.Pacientes
                .AnyAsync(p => p.Cedula == cedula && !p.IsDeleted);
        }

        public async Task<IEnumerable<Paciente>> GetPacientesActivosAsync()
        {
            return await _context.Pacientes
                .Include(p => p.Citas)
                .Where(p => !p.IsDeleted)
                .OrderBy(p => p.Nombre)
                .ThenBy(p => p.Apellido)
                .ToListAsync();
        }
    }
}