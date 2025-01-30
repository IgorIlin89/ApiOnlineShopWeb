using ApiUser.Application.Commands;
using ApiUser.Application.Handlers.Interfaces;
using ApiUser.Database.Interfaces;
using ApiUser.Domain;

namespace ApiUser.Application.Handlers;

public class ChangePasswordCommandHandler(IUnitOfWork UnitOfWork,
    IUserRepository Repository) : IChangePasswordCommandHandler
{
    public async Task<User> HandleAsync(ChangePasswordCommand command,
        CancellationToken cancellationToken)
    {
        var user = await Repository.ChangePasswordAsync(int.Parse(command.UserId), command.Password,
            cancellationToken);
        await UnitOfWork.SaveChangesAsync(cancellationToken);
        return user;
    }
}
