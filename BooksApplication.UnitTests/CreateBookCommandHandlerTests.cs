using BooksApplication.Domain.Entities;
using BooksApplication.Infrastructure.Handlers.Commands;
using BooksApplication.Infrastructure.Repositories.Abstractions;
using BooksApplication.Models;
using BooksApplication.Models.Commands;
using Moq;

namespace BooksApplication.UnitTests
{
    public class CreateBookCommandHandlerTests
    {
        private readonly Mock<IBookRepository> bookRepositoryMock;
        private readonly Mock<IAuthorRepository> authorRepositoryMock;
        private readonly Mock<IBookAuthorRepository> bookAuthorRepositoryMock;
        private readonly Mock<IUnitOfWork> unitOfWorkMock;
        private readonly CreateBookCommandHandler handler;

        public CreateBookCommandHandlerTests()
        {
            bookRepositoryMock = new Mock<IBookRepository>();
            authorRepositoryMock = new Mock<IAuthorRepository>();
            bookAuthorRepositoryMock = new Mock<IBookAuthorRepository>();
            unitOfWorkMock = new Mock<IUnitOfWork>();

            handler = new CreateBookCommandHandler(
                unitOfWorkMock.Object,
                bookRepositoryMock.Object,
                authorRepositoryMock.Object,
                bookAuthorRepositoryMock.Object
            );
        }

        [Fact]
        public async Task Handle_ShouldAddBookAndNewAuthors_Success()
        {
            // Arrange
            var bookAuthors = new List<BookAuthorModel>
            {
                new BookAuthorModel { FirstName = "John", LastName = "Doe" },
                new BookAuthorModel { FirstName = "Jane", LastName = "Smith" },
            };
            var command = new CreateBookCommand("Test Book", 100, 1, 2, bookAuthors);
            var bookId = 1;
            InitializeDefaultMockBehavior(bookId: bookId);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal(bookId, result);

            bookRepositoryMock.Verify(repo => repo.AddAsync(It.IsAny<BookEntity>()), Times.Once);
            authorRepositoryMock.Verify(repo => repo.AddAsync(It.IsAny<AuthorEntity>()), Times.Exactly(2));
            bookAuthorRepositoryMock.Verify(repo => repo.AddAsync(It.IsAny<BookAuthorEntity>()), Times.Exactly(2));
        }

        [Fact]
        public async Task Handle_ShouldAddBookAndUseExistingAuthor_Success()
        {
            // Arrange
            var bookAuthors = new List<BookAuthorModel>
            {
                new BookAuthorModel { FirstName = "John", LastName = "Doe" },
            };
            var command = new CreateBookCommand("Test Book", 100, 1, 2, bookAuthors);

            var bookId = 1;
            var existingAuthor = AuthorEntity.Create("John", "Doe");
            InitializeDefaultMockBehavior(bookId: bookId, existingAuthor: existingAuthor);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal(bookId, result);

            bookRepositoryMock.Verify(repo => repo.AddAsync(It.IsAny<BookEntity>()), Times.Once);
            authorRepositoryMock.Verify(repo => repo.AddAsync(It.IsAny<AuthorEntity>()), Times.Never);
            bookAuthorRepositoryMock.Verify(repo => repo.AddAsync(It.IsAny<BookAuthorEntity>()), Times.Once);
        }


        private void InitializeDefaultMockBehavior(int bookId = 1, int author1Id = 1, int author2Id = 2, AuthorEntity existingAuthor = null)
        {
            bookRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<BookEntity>()))
                .Callback<BookEntity>(b => b.Id = bookId)
                .Returns(Task.CompletedTask);

            authorRepositoryMock.Setup(repo => repo.FindByNameAsync("John", "Doe"))
                .ReturnsAsync(existingAuthor ?? (AuthorEntity)null);
            authorRepositoryMock.Setup(repo => repo.FindByNameAsync("Jane", "Smith"))
                .ReturnsAsync((AuthorEntity)null);

            authorRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<AuthorEntity>()))
                .Callback<AuthorEntity>(a => a.Id = a.FirstName == "John" ? author1Id : author2Id)
                .Returns(Task.CompletedTask);

            bookAuthorRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<BookAuthorEntity>()))
                .Returns(Task.CompletedTask);

            unitOfWorkMock.Setup(uow => uow.SaveChangesAsync())
                .Returns(Task.CompletedTask);
        }
    }
}