using BooksApplication.Domain.Entities;
using BooksApplication.Infrastructure.Context.Configurations;
using Microsoft.EntityFrameworkCore;

namespace BooksApplication.Infrastructure.Context
{
    public class BooksApplicationDbContext : DbContext
    {
        public const string Schema = "dbo";

        public BooksApplicationDbContext(DbContextOptions<BooksApplicationDbContext> options) : base(options) { }

        public DbSet<AuthorEntity> Authors { get; set; }
        public DbSet<BookEntity> Books { get; set; }
        public DbSet<BookAuthorEntity> BookAuthors { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AuthorEntityConfiguration(Schema));
            modelBuilder.ApplyConfiguration(new BookEntityConfiguration(Schema));
            modelBuilder.ApplyConfiguration(new BookAuthorEntityConfiguration(Schema));
            modelBuilder.ApplyConfiguration(new OrderEntityConfiguration(Schema));
        }
    }
}
