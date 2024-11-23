﻿using BooksApplication.Domain.Entities;
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
    public class BookRepository : IBookRepository
    {
        private readonly BooksApplicationDbContext context;

        public BookRepository(BooksApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(BookEntity entity)
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
