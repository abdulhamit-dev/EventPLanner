using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class EventAttendeeRepository : EfRepositoryBase<EventAttendee, Guid, BaseDbContext>, IEventAttendeeRepository
    {
        public EventAttendeeRepository(BaseDbContext context) : base(context)
        {
        }
    }

 
}
