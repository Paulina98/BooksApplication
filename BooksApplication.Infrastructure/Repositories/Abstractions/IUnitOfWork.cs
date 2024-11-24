namespace BooksApplication.Infrastructure.Repositories.Abstractions
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}
