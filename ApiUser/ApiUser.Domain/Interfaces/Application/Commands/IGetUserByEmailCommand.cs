namespace ApiUser.Domain.Interfaces.Commands
{
    public interface IGetUserByEmailCommand
    {
        string Email { get; init; }
    }
}