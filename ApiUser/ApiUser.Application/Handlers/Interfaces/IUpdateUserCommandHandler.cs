using ApiUser.Application.Commands;
using ApiUser.Domain;

namespace ApiUser.Application.Handlers.Interfaces;

public interface IUpdateUserCommandHandler
{
    Task<User> HandleAsync(UpdateUserCommand command, CancellationToken cancellationToken);
}