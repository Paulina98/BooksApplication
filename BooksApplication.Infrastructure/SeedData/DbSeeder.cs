using BooksApplication.Domain.Entities;
using BooksApplication.Infrastructure.Context;

namespace BooksApplication.Infrastructure.SeedData
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(BooksApplicationDbContext context)
        {
            if (!context.Authors.Any())
            {
                context.Authors.Add(new AuthorEntity { FirstName = "FirstName", LastName = "LastName" });
                await context.SaveChangesAsync();
            }

            if (!context.Books.Any() || context.Books.Count() < 2)
            {
                var book1 = new BookEntity { Title = "title1", Price = 10, Bookstand = 2, Shelf = 1 };
                var book2 = new BookEntity { Title = "title2", Price = 20, Bookstand = 1, Shelf = 2 };

                context.Books.AddRange(book1, book2);
                await context.SaveChangesAsync();

                var authorId = context.Authors.FirstOrDefault();
                if (authorId != null)
                {
                    context.BookAuthors.AddRange(new List<BookAuthorEntity>
                    {
                        new BookAuthorEntity { BookId = book1.Id, AuthorId = authorId.Id },
                        new BookAuthorEntity { BookId = book2.Id, AuthorId = authorId.Id }
                    });

                    await context.SaveChangesAsync();
                }
            }
            
            if (!context.Orders.Any())
            {
                var orderId1 = Guid.NewGuid();
                var orderId2 = Guid.NewGuid();
                var book = context.Books.ToList();
                if (book != null)
                {
                    context.Orders.AddRange(new List<OrderEntity>
                    {
                        new OrderEntity { OrderId = orderId1, BookId = book[0].Id, QuantityNumber = 2 },
                        new OrderEntity { OrderId = orderId1, BookId = book[1].Id, QuantityNumber = 3 },
                        new OrderEntity { OrderId = orderId2, BookId = book[0].Id, QuantityNumber = 1 },
                        new OrderEntity { OrderId = orderId2, BookId = book[1].Id, QuantityNumber = 5 }
                    });

                    await context.SaveChangesAsync();
                }
            }
        }
    }

}
