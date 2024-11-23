using MediatR;

namespace BooksApplication.Models.Commands.Abstractions
{
    public interface ICommand : IRequest
    {
    }

    public interface ICommand<out TResponse> : IRequest<TResponse> 
    { 
    }
}
