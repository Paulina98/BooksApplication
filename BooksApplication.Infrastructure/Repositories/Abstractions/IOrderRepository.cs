using BooksApplication.Domain.Entities;

namespace BooksApplication.Infrastructure.Repositories.Abstractions
{
    public interface IOrderRepository
    {
        Task<List<OrderEntity>> GetAllAsync();
    }
}
