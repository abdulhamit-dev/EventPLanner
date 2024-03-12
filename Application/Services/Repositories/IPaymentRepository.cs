using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories
{
    public interface IPaymentRepository : IAsyncRepository<Payment, Guid>, IRepository<Payment, Guid>
    {
    }
}
