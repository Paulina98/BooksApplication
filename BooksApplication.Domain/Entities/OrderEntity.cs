namespace BooksApplication.Domain.Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public Guid OrderId { get; set; }
        public int BookId { get; set; }
        public BookEntity Book { get; set; }
        public int QuantityNumber { get; set; }

    }
}
