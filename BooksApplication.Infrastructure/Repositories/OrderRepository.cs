using BooksApplication.Domain.Entities;
using BooksApplication.Infrastructure.Context;
using BooksApplication.Infrastructure.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace BooksApplication.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BooksApplicationDbContext context;

        public OrderRepository(BooksApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<List<OrderEntity>> GetAllAsync()
        {
            return await context.Orders.ToListAsync();
        }

    }
}
