using BooksApplication.Domain.Entities;

namespace BooksApplication.Infrastructure.Repositories.Abstractions
{
    public interface IBookRepository
    {
        Task AddAsync(BookEntity entity);
        Task<IEnumerable<BookEntity>> GetAllAsync();
    }
}
