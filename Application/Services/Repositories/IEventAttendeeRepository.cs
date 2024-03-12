using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories
{
    public interface IEventAttendeeRepository : IAsyncRepository<EventAttendee, Guid>, IRepository<EventAttendee, Guid>
    {
    }
}
