using BooksApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApplication.Infrastructure.Repositories.Abstractions
{
    public interface IBookRepository
    {
        Task AddAsync(BookEntity entity);
        Task<IEnumerable<BookEntity>> GetAllAsync();
    }
}
