using BooksApplication.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApplication.Infrastructure.Context.Configurations
{
    public class AuthorEntityConfiguration : IEntityTypeConfiguration<AuthorEntity>
    {
        protected string Schema { get; set; }

        public AuthorEntityConfiguration(string schema)
        {
            Schema = schema;
        }

        public void Configure(EntityTypeBuilder<AuthorEntity> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(e => e.FirstName).IsRequired();
            builder.Property(e => e.LastName).IsRequired();
            builder.Metadata.FindNavigation(nameof(AuthorEntity.BookAuthors))
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
