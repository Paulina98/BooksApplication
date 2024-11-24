using BooksApplication.Domain.Entities;

namespace BooksApplication.Infrastructure.Repositories.Abstractions
{
    public interface IBookAuthorRepository
    {
        Task AddAsync(BookAuthorEntity entity);
        Task<IEnumerable<BookEntity>> GetAllAsync();
    }
}
