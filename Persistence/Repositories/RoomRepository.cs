using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class RoomRepository : EfRepositoryBase<Room, Guid, BaseDbContext>, IRoomRepository
    {
        public RoomRepository(BaseDbContext context) : base(context)
        {
        }
    }

 
}
