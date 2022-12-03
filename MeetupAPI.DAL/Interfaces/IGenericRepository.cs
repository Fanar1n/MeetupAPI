using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Meetup.DAL.Interfaces
{
    public interface IGenericRepository<TEntity>
        where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken token);
        Task<TEntity> GetByIdAsync(int id, CancellationToken token);
        Task<TEntity> CreateAsync(TEntity item, CancellationToken token);
        Task<TEntity> UpdateAsync(TEntity item, CancellationToken token);
        Task DeleteByIdAsync(int id, CancellationToken token);
    }
}
