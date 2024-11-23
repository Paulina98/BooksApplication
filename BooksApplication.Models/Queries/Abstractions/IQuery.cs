using MediatR;

namespace BooksApplication.Models.Queries.Abstractions
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}
