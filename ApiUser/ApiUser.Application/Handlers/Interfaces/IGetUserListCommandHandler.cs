namespace ApiUser.Domain.Interfaces.Handlers;

public interface IGetUserListCommandHandler
{
    Task<List<User>> Handle(CancellationToken cancellationToken);
}