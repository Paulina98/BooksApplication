using BooksApplication.Domain.Entities;
using BooksApplication.Infrastructure.Context;
using BooksApplication.Infrastructure.Repositories.Abstractions;
using BooksApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
