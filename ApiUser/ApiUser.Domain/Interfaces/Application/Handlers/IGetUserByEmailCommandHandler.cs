using ApiUser.Domain;
using ApiUser.Domain.Interfaces.Commands;

namespace ApiUser.Application.Handlers.Interfaces;

public interface IGetUserByEmailCommandHandler
{
    User Handle(IGetUserByEmailCommand command);
}