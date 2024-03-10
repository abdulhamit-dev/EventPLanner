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
            service.AddDbContext<BaseDbContext>(options => options.UseInMemoryDatabase("EventPlannerDb"));
            service.AddScoped<IEventRepository, EventRepository>();
            return service;
        }
    }
}
