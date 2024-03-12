using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories
{
    public interface IAttendeeRepository : IAsyncRepository<Attendee, Guid>, IRepository<Attendee, Guid>
    {
    }
}
