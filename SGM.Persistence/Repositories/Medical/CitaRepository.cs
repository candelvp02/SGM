using SGM.Persistence.Base;
using SGM.Persistence.Context;
using SGM.Persistence.Interfaces.Medical;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SGM.Persistence.Repositories.Medical
{
    public class CitaRepository : BaseRepository<Cita>, ICitaRepository
    {
        private readonly SGMDbContext _context;

        public CitaRepository(SGMDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cita>> GetCitasByPacienteAsync(int pacienteId)
        {
            return await _context.Citas
                .Include(c => c.Paciente)
                .Include(c => c.Medico)
                .Where(c => c.PacienteId == pacienteId && !c.IsDeleted)
                .OrderByDescending(c => c.FechaHora)
                .ToListAsync();
        }

        public async Task<IEnumerable<Cita>> GetCitasByMedicoAsync(int medicoId)
        {
            return await _context.Citas
                .Include(c => c.Paciente)
                .Include(c => c.Medico)
                .Where(c => c.MedicoId == medicoId && !c.IsDeleted)
                .OrderBy(c => c.FechaHora)
                .ToListAsync();
        }

        public async Task<IEnumerable<Cita>> GetCitasByFechaAsync(DateTime fecha)
        {
            var fechaInicio = fecha.Date;
            var fechaFin = fechaInicio.AddDays(1);

            return await _context.Citas
                .Include(c => c.Paciente)
                .Include(c => c.Medico)
                .Where(c => c.FechaHora >= fechaInicio && c.FechaHora < fechaFin && !c.IsDeleted)
                .OrderBy(c => c.FechaHora)
                .ToListAsync();
        }

        public async Task<IEnumerable<Cita>> GetCitasByEstadoAsync(EstadoCita estado)
        {
            return await _context.Citas
                .Include(c => c.Paciente)
                .Include(c => c.Medico)
                .Where(c => c.Estado == estado && !c.IsDeleted)
                .OrderBy(c => c.FechaHora)
                .ToListAsync();
        }

        public async Task<bool> ExisteCitaEnHorarioAsync(int medicoId, DateTime fechaHora)
        {
            return await _context.Citas
                .AnyAsync(c => c.MedicoId == medicoId &&
                          c.FechaHora == fechaHora &&
                          c.Estado != EstadoCita.Cancelada &&
                          !c.IsDeleted);
        }

        public async Task<IEnumerable<Cita>> GetCitasProximasAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            return await _context.Citas
                .Include(c => c.Paciente)
                .Include(c => c.Medico)
                .Where(c => c.FechaHora >= fechaInicio &&
                           c.FechaHora <= fechaFin &&
                           c.Estado == EstadoCita.Programada &&
                           !c.IsDeleted)
                .OrderBy(c => c.FechaHora)
                .ToListAsync();
        }
    }
}
