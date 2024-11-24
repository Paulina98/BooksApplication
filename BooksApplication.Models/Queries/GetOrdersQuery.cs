using BooksApplication.Models.Queries.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace BooksApplication.Models.Queries
{
    public class GetOrdersQuery : IPagedQuery<OrderModel>
    {
        public GetOrdersQuery(int currentPage, int rowCount)
        {
            CurrentPage = currentPage;
            RowCount = rowCount;
        }

        public GetOrdersQuery()
        {
        }

        [Required]
        public int CurrentPage { get; set; }
        [Required]
        public int RowCount { get; set; }
    }
}
