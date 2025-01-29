using ApiUser.Database.Interfaces;
using ApiUser.Domain;
using ApiUser.Domain.Interfaces.Handlers;

namespace ApiUser.Application.Handlers;

public class GetUserListCommandHandler(IUnitOfWork UnitOfWork,
    IUserRepository Repository) : IGetUserListCommandHandler
{
    public async Task<List<User>> Handle(CancellationToken cancellationToken)
        => await Repository.GetUserList(cancellationToken);

}
