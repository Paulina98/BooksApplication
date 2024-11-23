using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApplication.Models
{
    public class PagedQueryModel
    {
        public int CurrentPage { get; set; }
        public int RowCount { get; set; }
    }
}
