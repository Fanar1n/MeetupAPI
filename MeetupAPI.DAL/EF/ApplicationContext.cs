using MeetupAPI.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Meetup.DAL.EF
{
    public class ApplicationContext : DbContext
    {
        public DbSet<EventEntity> Event { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.Migrate();
        }
    }
}
