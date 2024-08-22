using ApiUser.Application.Handlers.Interfaces;
using ApiUser.Database.Interfaces;
using ApiUser.Domain;
using ApiUser.Domain.Interfaces.Commands;

namespace ApiUser.Application.Handlers;

public class GetUserByEmailCommandHandler(IUnitOfWork UnitOfWork, IUserRepository Repository) : IGetUserByEmailCommandHandler
{
    public User Handle(IGetUserByEmailCommand command)
    {
        return Repository.GetUserByEMail(command.Email);
    }
}