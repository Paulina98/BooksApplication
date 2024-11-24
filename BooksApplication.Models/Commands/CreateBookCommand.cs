using BooksApplication.Models.Commands.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace BooksApplication.Models.Commands
{
    public class CreateBookCommand : ICommand<int>
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public double Price { get; set; }
        public int Bookstand { get; set; }
        public int Shelf { get; set; }
        [Required]
        public List<BookAuthorModel> BookAuthors { get; set; }
        
        public CreateBookCommand(string title, double price, int bookstand, int shelf, List<BookAuthorModel> bookAuthors)
        {
            Title = title;
            Price = price;
            Bookstand = bookstand;
            Shelf = shelf;
            BookAuthors = bookAuthors;
        }
    }
}
