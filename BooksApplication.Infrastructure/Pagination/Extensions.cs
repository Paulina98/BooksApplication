using BooksApplication.Models.Abstractions;
using BooksApplication.Models.Queries;
using BooksApplication.Models.Queries.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BooksApplication.Infrastructure.Pagination
{
    public static class Extensions
    {
        public static async Task<IPagedResult<TResult>> ToPagedResult<TEntity, TResult>(
            this IQueryable<TEntity> query,
            IPagedQuery<TResult> pagedQuery,
            Expression<Func<TEntity, TResult>> selector,
            int startPagination = 1)
        {
            var totalCount = await query.CountAsync();
            var pages = (totalCount + pagedQuery.RowCount - 1) / pagedQuery.RowCount;

            if (pagedQuery.CurrentPage > 0)
            {
                query = query.Skip((pagedQuery.CurrentPage - startPagination) * pagedQuery.RowCount)
                             .Take(pagedQuery.RowCount);
            }

            var items = await query.Select(selector).ToListAsync();

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
