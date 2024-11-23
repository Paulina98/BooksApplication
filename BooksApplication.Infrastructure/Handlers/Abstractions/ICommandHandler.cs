using BooksApplication.Models.Commands.Abstractions;
using MediatR;

namespace BooksApplication.Infrastructure.Handlers.Abstractions
{
    public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand> where TCommand : ICommand
    {
    }

    public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse> where TCommand : ICommand<TResponse>
    {
    }
}
