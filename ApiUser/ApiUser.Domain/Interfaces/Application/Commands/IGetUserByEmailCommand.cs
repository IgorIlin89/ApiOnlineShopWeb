namespace ApiUser.Domain.Interfaces.Commands
{
    public interface IGetUserByEmailCommand
    {
        string Email { get; init; }

        bool Equals(IGetUserByEmailCommand? other);
        bool Equals(object? obj);
        int GetHashCode();
        string ToString();
    }
}