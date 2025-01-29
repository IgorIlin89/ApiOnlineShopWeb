using ApiUser.Application.Commands;
using ApiUser.Domain;

namespace ApiUser.Application.Handlers.Interfaces;

public interface IUpdateUserCommandHandler
{
    Task<User> Handle(UpdateUserCommand command, CancellationToken cancellationToken);
}