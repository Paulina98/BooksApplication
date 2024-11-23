using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApplication.Domain.Entities
{
    public class AuthorEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<BookAuthorEntity> BookAuthors { get; set; } = new List<BookAuthorEntity>();

        public static AuthorEntity Create(string firstName, string lastName)
        {
            var entity = new AuthorEntity
            {
                FirstName = firstName,
                LastName = lastName
            };

            return entity;
        }
    }
}
