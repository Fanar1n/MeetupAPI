using Meetup.DAL.EF;
using Meetup.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Meetup.DAL.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class
    {
        private readonly ApplicationDbContext _db;

        protected readonly DbSet<TEntity> _dbSet;

        public GenericRepository(ApplicationDbContext applicationContext)
        {
            _db = applicationContext;
            _dbSet = _db.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken token)
        {
            return await _dbSet.AsNoTracking().ToListAsync(token);
        }

        public virtual async Task<TEntity> GetByIdAsync(int id, CancellationToken token)
        {
            return await _dbSet.FindAsync(new object[] { id }, token);
        }

        public virtual async Task<TEntity> CreateAsync(TEntity tEntity, CancellationToken token)
        {
            await _dbSet.AddAsync(tEntity, token);

            await _db.SaveChangesAsync(token);

            return tEntity;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity tEntity, CancellationToken token)
        {
            _dbSet.Update(tEntity);

            await _db.SaveChangesAsync(token);

            return tEntity;
        }

        public virtual async Task DeleteByIdAsync(int id, CancellationToken token)
        {
            var tEntity = await _dbSet.FindAsync(new object[] { id }, token);

            _dbSet.Remove(tEntity);

            await _db.SaveChangesAsync(token);
        }
    }
}
