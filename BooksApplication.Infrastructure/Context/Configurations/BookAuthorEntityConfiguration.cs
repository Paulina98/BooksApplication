using BooksApplication.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApplication.Infrastructure.Context.Configurations
{
    public class BookAuthorEntityConfiguration : IEntityTypeConfiguration<BookAuthorEntity>
    {
        protected string Schema { get; set; }

        public BookAuthorEntityConfiguration(string schema)
        {
            Schema = schema;
        }

        public void Configure(EntityTypeBuilder<BookAuthorEntity> builder)
        {
            builder.HasKey(e => new { e.BookId, e.AuthorId });

            builder.HasOne(e => e.Book)
                .WithMany(b => b.BookAuthors)
                .HasForeignKey(e => e.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Author)
                .WithMany(a => a.BookAuthors)
                .HasForeignKey(e => e.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
