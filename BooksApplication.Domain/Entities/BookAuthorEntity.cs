using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApplication.Domain.Entities
{
    public class BookAuthorEntity
    {
        public int BookId { get; set; }
        public BookEntity Book { get; set; }

        public int AuthorId { get; set; }
        public AuthorEntity Author { get; set; }

        public static BookAuthorEntity Create(int bookId, int authorId)
        {
            var entity = new BookAuthorEntity
            {
                BookId = bookId,
                AuthorId = authorId
            };

            return entity;
        }
    }
}
