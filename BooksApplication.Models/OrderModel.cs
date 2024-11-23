using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApplication.Models
{
    public class OrderModel
    {
        public Guid OrderId { get; set; }
        public List<OrderLineModel> OrderLines { get; set; } = new List<OrderLineModel>();
    }
}
