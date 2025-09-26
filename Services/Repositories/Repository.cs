
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Data;

namespace RepositoryPattern.Services.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private AppDbContext _context;
        private DbSet<T> _dbSet;

        public Repository(AppDbContext context) 
        { 
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            return Task.CompletedTask;
        }
    }
}
