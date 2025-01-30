using ApiUser.Application.Commands;
using ApiUser.Application.Handlers.Interfaces;
using ApiUser.Database.Interfaces;
using ApiUser.Domain;

namespace ApiUser.Application.Handlers;

public class AddUserCommandHandler(IUnitOfWork UnitOfWork,
    IUserRepository UserRepository) : IAddUserCommandHandler
{
    public async Task<User> HandleAsync(AddUserCommand command, CancellationToken cancellationToken)
    {
        var user = new User
        {
            EMail = command.EMail,
            GivenName = command.GivenName,
            Surname = command.Surname,
            Age = command.Age,
            Country = command.Country,
            City = command.City,
            Street = command.Street,
            HouseNumber = command.HouseNumber,
            PostalCode = command.PostalCode,
            Password = command.Password
        };


        var response = await UserRepository.AddUserAsync(user, cancellationToken);
        await UnitOfWork.SaveChangesAsync(cancellationToken);
        return user;
    }
}
