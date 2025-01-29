using ApiUser.Application.Commands;
using ApiUser.Domain;

namespace ApiUser.Application.Handlers.Interfaces;

public interface IGetUserByIdCommandHandler
{
    Task<User?> Handle(GetUserByIdCommand command, CancellationToken cancellationToken);
}