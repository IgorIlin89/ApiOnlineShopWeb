using ApiUser.Application.Commands;

namespace ApiUser.Application.Handlers.Interfaces;

public interface IDeleteUserCommandHandler
{
    Task HandleAsync(DeleteUserCommand command, CancellationToken cancellationToken);
}