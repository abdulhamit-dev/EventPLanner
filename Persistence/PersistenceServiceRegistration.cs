using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection service,IConfiguration configuration)
        {
            //service.AddDbContext<BaseDbContext>(options => options.UseInMemoryDatabase("EventPlannerDb"));
            service.AddDbContext<BaseDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("EventPlannerCon")));
            service.AddScoped<IEventRepository, EventRepository>();
            service.AddScoped<IEventAttendeeRepository, EventAttendeeRepository>();
            return service;
        }
    }
}
