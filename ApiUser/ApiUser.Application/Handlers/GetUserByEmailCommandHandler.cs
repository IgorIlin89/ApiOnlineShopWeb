using ApiUser.Application.Commands;
using ApiUser.Application.Handlers.Interfaces;
using ApiUser.Database.Interfaces;
using ApiUser.Domain;

namespace ApiUser.Application.Handlers;

public class GetUserByEmailCommandHandler(IUnitOfWork UnitOfWork,
    IUserRepository Repository) : IGetUserByEmailCommandHandler
{
    public async Task<User?> HandleAsync(GetUserByEmailCommand command, CancellationToken cancellationToken)
    {

        //if (string.IsNullOrWhiteSpace(email))
        //{
        //    throw new NotFoundException($"Email should not be null when searching for user by email");
        //}
        return await Repository.GetUserByEMailAsync(command.EMail, cancellationToken);
    }
}