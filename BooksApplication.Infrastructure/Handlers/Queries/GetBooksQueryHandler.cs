using BooksApplication.Infrastructure.Handlers.Abstractions;
using BooksApplication.Infrastructure.Repositories.Abstractions;
using BooksApplication.Models;
using BooksApplication.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApplication.Infrastructure.Handlers.Queries
{
    public class GetBooksQueryHandler : IQueryHandler<GetBooksQuery, IEnumerable<BookModel>>
    {
        private readonly IBookRepository bookRepository;

        public GetBooksQueryHandler(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public async Task<IEnumerable<BookModel>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await bookRepository.GetAllAsync(); 

            var result = books.Select(book => new BookModel
            {
                Id = book.Id,
                Title = book.Title,
                Price = book.Price,
                Bookstand = book.Bookstand,
                Shelf = book.Shelf,
                BookAuthors = book.BookAuthors
                    .Select(ba => new AuthorModel
                    {
                        Id = ba.Author.Id,
                        FirstName = ba.Author.FirstName,
                        LastName = ba.Author.LastName
                    })
                    .ToList()
            }).ToList();

            return result;
        }
    }
}
