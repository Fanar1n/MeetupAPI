using Meetup.BLL.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Meetup.BLL.Interfaces
{
    public interface IEventService
    {
        Task<IEnumerable<Event>> GetAllAsync(CancellationToken token);
        Task<Event> GetByIdAsync(int id, CancellationToken token);
        Task<Event> CreateAsync(Event item, CancellationToken token);
        Task<Event> UpdateAsync(Event item, CancellationToken token);
        Task DeleteByIdAsync(int id, CancellationToken token);
    }
}
