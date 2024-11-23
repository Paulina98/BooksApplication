using BooksApplication.Models.Queries.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApplication.Models.Queries
{
    public class GetBooksQuery : IQuery<IEnumerable<BookModel>>
    {
    }
}
