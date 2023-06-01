using WKTechnology.Core.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using WKTechnology.Domain;

namespace WKTechnology.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly WKTechnologyDbContext _dbContext;

        public GenericRepository(WKTechnologyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IReadOnlyList<T>> GetAll()
        {
            var query = _dbContext.Set<T>().AsQueryable();

            if (typeof(T) == typeof(Produto))
            {
                query = query.Include(p => ((Produto)(object)p).Categoria);
            }

            return await query.ToListAsync();
        }

        public async Task<T> Get(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task Add(T entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}