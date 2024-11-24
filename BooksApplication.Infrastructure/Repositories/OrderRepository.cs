using BooksApplication.Domain.Entities;
using BooksApplication.Infrastructure.Context;
using BooksApplication.Infrastructure.Repositories.Abstractions;

namespace BooksApplication.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BooksApplicationDbContext context;

        public OrderRepository(BooksApplicationDbContext context)
        {
            this.context = context;
        }

        public IQueryable<OrderEntity> GetAll()
        {
            return context.Orders.AsQueryable();
        }

    }
}
