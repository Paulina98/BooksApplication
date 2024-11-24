using Moq;
using BooksApplication.Infrastructure.Repositories.Abstractions;
using BooksApplication.Domain.Entities;
using BooksApplication.Infrastructure.Handlers.Queries;
using BooksApplication.Models.Queries;

namespace BooksApplication.UnitTests
{
    public class GetBooksQueryHandlerTests
    {
        private readonly Mock<IBookRepository> bookRepositoryMock;
        private readonly GetBooksQueryHandler handler;

        public GetBooksQueryHandlerTests()
        {
            bookRepositoryMock = new Mock<IBookRepository>();
            handler = new GetBooksQueryHandler(bookRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnBooks_Success()
        {
            // Arrange
            var book1 = BookEntity.Create("Book1", 10, 1, 2);
            var book2 = BookEntity.Create("Book2", 20, 1, 3);
            var books = new List<BookEntity> { book1, book2 };

            bookRepositoryMock.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(books);

            // Act
            var result = await handler.Handle(new GetBooksQuery(), CancellationToken.None);

            // Assert
            var bookModels = result.ToList();
            Assert.Equal(2, bookModels.Count);
            Assert.Equal("Book1", book1.Title);
            Assert.Equal(10, book1.Price);
            Assert.Equal("Book2", book2.Title);
            Assert.Equal(20, book2.Price);
        }

        [Fact]
        public async Task Handle_ShouldReturnEmptyList_Success()
        {
            // Arrange
            bookRepositoryMock.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(new List<BookEntity>());

            // Act
            var result = await handler.Handle(new GetBooksQuery(), CancellationToken.None);

            // Assert
            Assert.Empty(result);
        }
    }

}
