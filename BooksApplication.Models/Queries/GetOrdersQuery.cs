using BooksApplication.Models.Queries.Abstractions;

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

        public int CurrentPage { get; set; }
        public int RowCount { get; set; }
    }
}
