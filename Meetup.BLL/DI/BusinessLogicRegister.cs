using Meetup.BLL.Interfaces;
using Meetup.BLL.Services;
using Meetup.DAL.DI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Meetup.BLL.DI
{
    public static class BusinessLogicRegister
    {
        public static void AddBusinessLogic(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped<IEventService, EventService>();
            serviceCollection.AddDataAccess(configuration);
        }
    }
}
