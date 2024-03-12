using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class SpeakerRepository : EfRepositoryBase<Speaker, Guid, BaseDbContext>, ISpeakerRepository
    {
        public SpeakerRepository(BaseDbContext context) : base(context)
        {
        }
    }

 
}
