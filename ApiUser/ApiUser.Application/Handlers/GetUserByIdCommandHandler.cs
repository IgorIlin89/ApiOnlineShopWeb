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
    public async Task<User?> Handle(GetUserByIdCommand command, CancellationToken cancellationToken)
        => await Repository.GetUserById(int.Parse(command.UserId), cancellationToken);

}
