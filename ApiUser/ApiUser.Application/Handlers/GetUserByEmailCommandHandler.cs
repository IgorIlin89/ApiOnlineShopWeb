using ApiUser.Application.Commands;
using ApiUser.Application.Handlers.Interfaces;
using ApiUser.Database.Interfaces;
using ApiUser.Domain;

namespace ApiUser.Application.Handlers;

public class GetUserByEmailCommandHandler(IUnitOfWork UnitOfWork, IUserRepository Repository) : IGetUserByEmailCommandHandler
{
    public User? Handle(GetUserByEmailCommand command)
    {

        //if (string.IsNullOrWhiteSpace(email))
        //{
        //    throw new NotFoundException($"Email should not be null when searching for user by email");
        //}
        return Repository.GetUserByEMail(command.EMail);
    }
}