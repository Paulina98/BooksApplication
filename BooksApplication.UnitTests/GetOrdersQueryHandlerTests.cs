using BooksApplication.Domain.Entities;
using BooksApplication.Infrastructure.Handlers.Queries;
using BooksApplication.Infrastructure.Repositories.Abstractions;
using BooksApplication.Models.Queries;
using Moq;

namespace BooksApplication.UnitTests
{
    public class GetOrdersQueryHandlerTests
    {
        private readonly Mock<IOrderRepository> orderRepositoryMock;
        private readonly GetOrdersQueryHandler handler;
        public GetOrdersQueryHandlerTests()
        {
            orderRepositoryMock = new Mock<IOrderRepository>();
            handler = new GetOrdersQueryHandler(orderRepositoryMock.Object);
        }

        [Fact]
        public async Task GetOrdersQueryHandler_ShouldReturnPagedOrders_Success()
        {
            // Arrange
            var orderId1 = Guid.NewGuid();
            var orderId2 = Guid.NewGuid();
            var orders = new List<OrderEntity>
            {
                new OrderEntity { OrderId = orderId1, Id = 1, BookId = 101, QuantityNumber = 2 },
                new OrderEntity { OrderId = orderId1, Id = 2, BookId = 102, QuantityNumber = 3 },
                new OrderEntity { OrderId = orderId2, Id = 3, BookId = 103, QuantityNumber = 1 },
                new OrderEntity { OrderId = orderId2, Id = 4, BookId = 104, QuantityNumber = 5 }
            };

            orderRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(orders);

            // Act
            var result = await handler.Handle(new GetOrdersQuery { CurrentPage = 1, RowCount = 2 }, default);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.TotalRowCount); 

            var ordersGroupedByOrderId = result.Items.ToList();

            Assert.Equal(2, ordersGroupedByOrderId.Count);
            Assert.Equal(orderId1, ordersGroupedByOrderId[0].OrderId);
            Assert.Equal(orderId2, ordersGroupedByOrderId[1].OrderId);
            Assert.Equal(2, ordersGroupedByOrderId[0].OrderLines.Count);
            Assert.Equal(2, ordersGroupedByOrderId[1].OrderLines.Count);
            Assert.Equal(1, result.CurrentPage);
            Assert.Equal(2, result.PageSize);
        }
    }
}
