using BooksApplication.Domain.Entities;

namespace BooksApplication.Infrastructure.Repositories.Abstractions
{
    public interface IOrderRepository
    {
        IQueryable<OrderEntity> GetAll();
    }
}
