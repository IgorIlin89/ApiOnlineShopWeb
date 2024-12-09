namespace ApiUser.Application.Commands;

public record ChangePasswordCommand(string UserId, string Password)
{
}
