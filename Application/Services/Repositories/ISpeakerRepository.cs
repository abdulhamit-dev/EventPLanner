using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories
{
    public interface ISpeakerRepository : IAsyncRepository<Speaker, Guid>, IRepository<Speaker, Guid>
    {
    }
}
