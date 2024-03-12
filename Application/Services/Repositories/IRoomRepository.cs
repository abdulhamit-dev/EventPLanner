using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories
{
    public interface IRoomRepository : IAsyncRepository<Room, Guid>, IRepository<Room, Guid>
    {
    }
}
