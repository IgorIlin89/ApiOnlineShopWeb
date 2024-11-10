using ApiUser.Domain;
namespace ApiUser.Application.Commands;

public record AddUserCommand
{
    public User UserToAdd { get; init; }

    public AddUserCommand(User userToAdd)
    {
        UserToAdd = userToAdd;
    }
}
