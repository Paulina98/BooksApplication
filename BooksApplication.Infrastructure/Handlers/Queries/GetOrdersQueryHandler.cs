using BooksApplication.Infrastructure.Handlers.Abstractions;
using BooksApplication.Infrastructure.Repositories.Abstractions;
using BooksApplication.Models.Queries;
using BooksApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksApplication.Models.Abstractions;
using BooksApplication.Infrastructure.Pagination;

namespace BooksApplication.Infrastructure.Handlers.Queries
{
    public class GetOrdersQueryHandler : IQueryHandler<GetOrdersQuery, IPagedResult<OrderModel>>
    {
        private readonly IOrderRepository orderRepository;

        public GetOrdersQueryHandler(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task<IPagedResult<OrderModel>> Handle(GetOrdersQuery query, CancellationToken cancellationToken)
        {
            var entities = orderRepository.GetAll();
            var orderedEntities = entities
                .GroupBy(e => e.OrderId)
                .Select(group => new OrderModel
                {
                    OrderId = group.Key,
                    OrderLines = group.Select(order => new OrderLineModel
                    {
                        Id = order.Id,
                        BookId = order.BookId,
                        QuantityNumber = order.QuantityNumber
                    }).ToList()
                })
                .OrderBy(x => x.OrderId) 
                .AsQueryable();

            var pagedResult = await orderedEntities.ToPagedResult(query, x => new OrderModel
            {
                OrderId = x.OrderId,
                OrderLines = x.OrderLines
            });

            return pagedResult;
        }
    }
}
