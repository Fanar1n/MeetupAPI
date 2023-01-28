using Meetup.DAL.EF;
using Meetup.DAL.Interfaces;
using MeetupAPI.DAL.Entities;

namespace Meetup.DAL.Repository
{
    public class EventRepository : GenericRepository<EventEntity>, IEventRepository
    {
        public EventRepository(ApplicationDbContext applicationContext)
            : base(applicationContext)
        {
        }
    }
}