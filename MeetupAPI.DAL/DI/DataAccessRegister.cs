using Meetup.DAL.EF;
using Meetup.DAL.Interfaces;
using Meetup.DAL.Repository;
using MeetupAPI.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Meetup.DAL.DI
{
    public static class DataAccessRegister
    {
        public static void AddDataAccess(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped<IEventRepository, EventRepository>();
            serviceCollection.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            serviceCollection.AddDbContext<ApplicationContext>(c => c.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
