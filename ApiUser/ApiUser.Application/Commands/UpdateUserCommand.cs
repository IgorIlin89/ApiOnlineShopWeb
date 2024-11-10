using ApiUser.Domain;

namespace ApiUser.Application.Commands;

public record UpdateUserCommand
{
    public User User { get; init; }

    public UpdateUserCommand(User userToUpdate)
    {
        User = userToUpdate;
    }
}
