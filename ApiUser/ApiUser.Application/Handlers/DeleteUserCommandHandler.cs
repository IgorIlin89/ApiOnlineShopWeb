using ApiUser.Application.Commands;
using ApiUser.Application.Handlers.Interfaces;
using ApiUser.Database.Interfaces;

namespace ApiUser.Application.Handlers;

public class DeleteUserCommandHandler(IUnitOfWork UnitOfWork, IUserRepository Repository) : IDeleteUserCommandHandler
{
    public void Handle(DeleteUserCommand command)
    {
        //if (id is null)
        //{
        //    throw new NotFoundException($"No id passed to delete the appropriate user");
        //}
        Repository.Delete(Int32.Parse(command.UserId));
        UnitOfWork.SaveChanges();
    }
}
