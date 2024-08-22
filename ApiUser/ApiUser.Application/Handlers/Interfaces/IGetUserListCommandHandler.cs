namespace ApiUser.Domain.Interfaces.Handlers;

public interface IGetUserListCommandHandler
{
    List<User> Handle();
}