using ApiUser.Application.Commands;
using ApiUser.Application.Handlers.Interfaces;
using ApiUser.Database.Interfaces;
using ApiUser.Domain;

namespace ApiUser.Application.Handlers;

public class ChangePasswordCommandHandler(IUnitOfWork UnitOfWork,
    IUserRepository Repository) : IChangePasswordCommandHandler
{
    public async Task<User> Handle(ChangePasswordCommand command,
        CancellationToken cancellationToken)
    {
        var user = await Repository.ChangePassword(int.Parse(command.UserId), command.Password,
            cancellationToken);
        UnitOfWork.SaveChanges();
        return user;
    }
}
