using ApiUser.Application.Commands;
using ApiUser.Domain;

namespace ApiUser.Application.Handlers.Interfaces;

public interface IAddUserCommandHandler
{
    Task<User> HandleAsync(AddUserCommand command, CancellationToken cancellationToken);
}