using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApplication.Models
{
    public class OrderLineModel
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int QuantityNumber { get; set; }
    }
}
