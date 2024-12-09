using ApiUser.Application.Commands;
using ApiUser.Application.Handlers.Interfaces;
using ApiUser.Database.Interfaces;
using ApiUser.Domain;

namespace ApiUser.Application.Handlers;

public class GetUserByIdCommandHandler(IUserRepository Repository) : IGetUserByIdCommandHandler
{

    //if (id is null)
    //    {
    //        throw new NotFoundException($"The id may not be null when calling 'GetUserById'");
    //    }
    public User Handle(GetUserByIdCommand command)
    {
        return Repository.GetUserById(int.Parse(command.UserId));
    }
}
