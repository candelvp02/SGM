using SGM.Persistence.Base;
using SGM.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using SGM.Domain.Entities.Medical;
using SGM.Persistence.Interfaces.Medical;
using SGM.Domain.Entities.Configuration;

namespace SGM.Persistence.Repositories.Medical
{
    public class MedicoRepository : BaseRepository<Medico>, IMedicoRepository
    {
        private readonly SGMDbContext _context;

        public MedicoRepository(SGMDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Medico>> GetMedicosByEspecialidadAsync(Especialidad especialidad)
        {
            return await _context.Medicos
                .Include(m => m.Disponibilidades)
                .Where(m => m.Especialidad == especialidad && !m.EstaEliminado)
                .OrderBy(m => m.Nombre)
                .ToListAsync();
        }

        public async Task<Medico> GetMedicoByLicenciaAsync(string numeroLicencia)
        {
            return await _context.Medicos
                .Include(m => m.Disponibilidades)
                .Include(m => m.Citas)
                .FirstOrDefaultAsync(m => m.NumeroLicencia == numeroLicencia && !m.EstaEliminado);
        }

        public async Task<Medico> GetMedicoByCedulaAsync(string cedula)
        {
            return await _context.Medicos
                .Include(m => m.Disponibilidades)
                .Include(m => m.Citas)
                .FirstOrDefaultAsync(m => m.Cedula == cedula && !m.EstaEliminado);
        }

        public async Task<bool> ExisteLicenciaAsync(string numeroLicencia)
        {
            return await _context.Medicos
                .AnyAsync(m => m.NumeroLicencia == numeroLicencia && !m.EstaEliminado);
        }

        public async Task<IEnumerable<Medico>> GetMedicosDisponiblesAsync(DateTime fecha)
        {
            var diaSemana = fecha.DayOfWeek;
            var hora = fecha.TimeOfDay;

            return await _context.Medicos
                .Include(m => m.Disponibilidades)
                .Where(m => m.Disponibilidades.Any(d => d.DiaSemana == diaSemana &&
                                                       d.HoraInicio <= hora &&
                                                       d.HoraFin >= hora &&
                                                       d.EsActivo) &&
                           !m.EstaEliminado)
                .ToListAsync();
        }
    }
}