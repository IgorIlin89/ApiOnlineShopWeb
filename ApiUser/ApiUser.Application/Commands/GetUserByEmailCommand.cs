using ApiUser.Domain.Exceptions;
using ApiUser.Domain.Interfaces.Commands;

namespace ApiUser.Application.Commands;

public record GetUserByEmailCommand : IGetUserByEmailCommand
{
    public string Email { get; init; }
    public GetUserByEmailCommand(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new NotFoundException($"Email should not be null when searching for user by email");
        }

        Email = email;
    }

    public bool Equals(IGetUserByEmailCommand? other)
    {
        throw new NotImplementedException();
    }
}
