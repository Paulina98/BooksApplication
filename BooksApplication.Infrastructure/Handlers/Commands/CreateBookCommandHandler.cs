using BooksApplication.Domain.Entities;
using BooksApplication.Infrastructure.Handlers.Abstractions;
using BooksApplication.Infrastructure.Repositories.Abstractions;
using BooksApplication.Models.Commands;

namespace BooksApplication.Infrastructure.Handlers.Commands
{
    public class CreateBookCommandHandler : ICommandHandler<CreateBookCommand, int>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IBookRepository bookRepository;
        private readonly IAuthorRepository authorRepository;
        private readonly IBookAuthorRepository bookAuthorRepository;

        public CreateBookCommandHandler(IUnitOfWork unitOfWork, IBookRepository bookRepository, IAuthorRepository authorRepository, IBookAuthorRepository bookAuthorRepository)
        {
            this.unitOfWork = unitOfWork;
            this.bookRepository = bookRepository;
            this.authorRepository = authorRepository;
            this.bookAuthorRepository = bookAuthorRepository;

        }

        public async Task<int> Handle(CreateBookCommand command, CancellationToken cancellationToken)
        {
            var book = BookEntity.Create(command.Title, command.Price, command.Bookstand, command.Shelf);
            await bookRepository.AddAsync(book);
            await unitOfWork.SaveChangesAsync();

            foreach (var author in command.BookAuthors)
            {
                var authorEntityId = await GetAuthorIdAsync(author.FirstName, author.LastName);

                var bookAuthor = BookAuthorEntity.Create(book.Id, authorEntityId);
                await bookAuthorRepository.AddAsync(bookAuthor);
            }

            await unitOfWork.SaveChangesAsync();

            return book.Id;
        }

        private async Task<int> GetAuthorIdAsync(string firstName, string lastName)
        {
            var existingAuthor = await authorRepository.FindByNameAsync(firstName, lastName);
            AuthorEntity authorEntity;

            if (existingAuthor != null)
            {
                authorEntity = existingAuthor;
            }
            else
            {
                authorEntity = AuthorEntity.Create(firstName, lastName);
                await authorRepository.AddAsync(authorEntity);
            }
            await unitOfWork.SaveChangesAsync();


            return authorEntity.Id;
        }
    }
}
