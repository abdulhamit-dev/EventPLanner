using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class AttendeeRepository : EfRepositoryBase<Attendee, Guid, BaseDbContext>, IAttendeeRepository
    {
        public AttendeeRepository(BaseDbContext context) : base(context)
        {
        }
    }

 
}
