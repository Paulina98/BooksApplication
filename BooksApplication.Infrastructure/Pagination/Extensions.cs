using BooksApplication.Models.Abstractions;
using BooksApplication.Models.Queries;
using BooksApplication.Models.Queries.Abstractions;
using System.Linq.Expressions;

namespace BooksApplication.Infrastructure.Pagination
{
    public static class Extensions
    {
        public static IPagedResult<TResult> ToPagedResult<TEntity, TResult>(
            this IQueryable<TEntity> query,
            IPagedQuery<TResult> pagedQuery,
            Expression<Func<TEntity, TResult>> selector,
            int startPagination = 1)
        {
            var totalCount = query.Count();
            var pages = (totalCount + pagedQuery.RowCount - 1) / pagedQuery.RowCount;

            if (pagedQuery.CurrentPage > 0)
            {
                query = query.Skip((pagedQuery.CurrentPage - startPagination) * pagedQuery.RowCount)
                             .Take(pagedQuery.RowCount);
            }

            var items = query.Select(selector).ToList();

            var pagedResponse = new PagedResultModel<TResult>
            {
                Items = items,
                PageSize = pagedQuery.RowCount,
                TotalRowCount = totalCount,
                PageCount = pages,
                CurrentPage = pagedQuery.CurrentPage
            };

            return pagedResponse;
        }
    }
}
