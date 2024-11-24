using BooksApplication.Domain.Entities;

namespace BooksApplication.Infrastructure.Repositories.Abstractions
{
    public interface IAuthorRepository
    {
        Task AddAsync(AuthorEntity entity);
        Task<AuthorEntity?> FindByNameAsync(string firstName, string lastName);
    }
}
