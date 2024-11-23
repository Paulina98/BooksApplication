using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApplication.Domain.Entities
{
    public class BookEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public int Bookstand { get; set; }
        public int Shelf { get; set; }
        public ICollection<BookAuthorEntity> BookAuthors { get; set; } = new List<BookAuthorEntity>();
    }
}
