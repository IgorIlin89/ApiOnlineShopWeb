using ApiUser.Application.Commands;

namespace ApiUser.Application.Handlers.Interfaces;

public interface IDeleteUserCommandHandler
{
    Task Handle(DeleteUserCommand command, CancellationToken cancellationToken);
}