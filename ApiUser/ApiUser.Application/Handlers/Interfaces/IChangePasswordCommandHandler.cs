using ApiUser.Application.Commands;
using ApiUser.Domain;

namespace ApiUser.Application.Handlers.Interfaces;

public interface IChangePasswordCommandHandler
{
    Task<User> Handle(ChangePasswordCommand command, CancellationToken cancellationToken);
}