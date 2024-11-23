using BooksApplication.Infrastructure.Context;
using BooksApplication.Infrastructure.Repositories.Abstractions;

namespace BooksApplication.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected BooksApplicationDbContext context;
        public UnitOfWork(BooksApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
