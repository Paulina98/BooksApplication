using BooksApplication.Domain.Entities;
using BooksApplication.Infrastructure.Context;
using BooksApplication.Infrastructure.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace BooksApplication.Infrastructure.Repositories
{
    public class BookAuthorRepository : IBookAuthorRepository
    {
        private readonly BooksApplicationDbContext context;

        public BookAuthorRepository(BooksApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(BookAuthorEntity entity)
        {
            await context.AddAsync(entity);
        }
        public async Task<IEnumerable<BookEntity>> GetAllAsync()
        {
            return await context.Books
                .Include(b => b.BookAuthors) 
                .ThenInclude(ba => ba.Author) 
                .ToListAsync();
        }
    }
}
