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

        public static BookEntity Create(string title, double price, int bookstand, int shelf)
        {
            var entity = new BookEntity
            {
                Title = title,
                Price = price,
                Bookstand = bookstand,
                Shelf = shelf
            };

            return entity;
        }
    }
}
