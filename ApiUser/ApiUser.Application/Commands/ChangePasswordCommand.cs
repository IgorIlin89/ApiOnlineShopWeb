namespace ApiUser.Application.Commands;

public record ChangePasswordCommand
{
    public int Id { get; init; }
    public string Password { get; init; }
    public ChangePasswordCommand(int userId, string password)
    {
        Id = userId;
        Password = password;
    }
}
