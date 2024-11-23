using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApplication.Models.Abstractions
{
    public interface IPagedResult<TResult>
    {
        public IEnumerable<TResult> Items { get; }
        public int CurrentPage { get; }
        public int PageCount { get; }
        public int PageSize { get; }
        public int TotalRowCount { get; }

    }
}
