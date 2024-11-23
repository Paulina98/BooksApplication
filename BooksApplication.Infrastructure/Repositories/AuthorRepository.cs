using BooksApplication.Domain.Entities;
using BooksApplication.Infrastructure.Context;
using BooksApplication.Infrastructure.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApplication.Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BooksApplicationDbContext context;

        public AuthorRepository(BooksApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(AuthorEntity entity)
        {
            await context.AddAsync(entity);
        }

        public async Task<AuthorEntity?> FindByNameAsync(string firstName, string lastName)
        {
            return await context.Set<AuthorEntity>()
                .FirstOrDefaultAsync(a => a.FirstName == firstName && a.LastName == lastName);
        }
    }

}
