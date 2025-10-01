using Microsoft.EntityFrameworkCore;
using SGM.Domain.Base;
using SGM.Domain.Interfaces.Repository;
using SGM.Persistence.Context;
using System.Linq.Expressions;

namespace SGM.Persistence.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : AuditEntity
    {
        protected readonly SGMDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(SGMDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
            => await _dbSet.AsNoTracking().Where(x => !x.EstaEliminado).ToListAsync();

        public async Task<T?> GetByIdAsync(int id)
            => await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id && !x.EstaEliminado);

        public async Task<T> AddAsync(T entity)
        {
            entity.FechaCreacion = DateTime.Now;
            entity.EstaEliminado = false;
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            entity.FechaModificacion = DateTime.Now;
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(x => x.Id == id && !x.EstaEliminado);
            if (entity is null) return false;

            entity.EstaEliminado = true;
            entity.FechaEliminacion = DateTime.Now;
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
            => await _dbSet.AsNoTracking().Where(predicate).Where(x => !x.EstaEliminado).ToListAsync();

        public Task<bool> ExistsAsync(int id)
            => _dbSet.AnyAsync(x => x.Id == id && !x.EstaEliminado);
    }
}