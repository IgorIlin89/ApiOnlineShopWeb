using ApiUser.Application.Commands;
using ApiUser.Domain;

namespace ApiUser.Application.Handlers.Interfaces;

public interface IGetUserByIdCommandHandler
{
    Task<User?> HandleAsync(GetUserByIdCommand command, CancellationToken cancellationToken);
}