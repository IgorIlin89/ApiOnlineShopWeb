using ApiUser.Application.Commands;
using ApiUser.Domain;

namespace ApiUser.Application.Handlers.Interfaces;

public interface IGetUserByEmailCommandHandler
{
    Task<User> HandleAsync(GetUserByEmailCommand command, CancellationToken cancellationToken);
}