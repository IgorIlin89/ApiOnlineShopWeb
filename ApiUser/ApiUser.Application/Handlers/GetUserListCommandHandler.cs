using ApiUser.Database.Interfaces;
using ApiUser.Domain;
using ApiUser.Domain.Interfaces.Handlers;

namespace ApiUser.Application.Handlers;

public class GetUserListCommandHandler(IUnitOfWork UnitOfWork, IUserRepository Repository) : IGetUserListCommandHandler
{
    public List<User> Handle()
    {
        return Repository.GetUserList();
    }
}
