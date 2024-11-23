using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApplication.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public int Bookstand { get; set; }
        public int Shelf { get; set; }
        public List<AuthorModel> BookAuthors { get; set; } = new List<AuthorModel>();

    }
}
