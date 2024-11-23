using BooksApplication.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApplication.Models.Queries.Abstractions
{
    public interface IPagedQuery<TResult> : IQuery<IPagedResult<TResult>>
    {
        public int CurrentPage { get; }
        public int RowCount { get; }
    }
}
