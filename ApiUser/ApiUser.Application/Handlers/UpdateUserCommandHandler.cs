using ApiUser.Application.Commands;
using ApiUser.Application.Handlers.Interfaces;
using ApiUser.Database.Interfaces;
using ApiUser.Domain;

namespace ApiUser.Application.Handlers;

public class UpdateUserCommandHandler(IUnitOfWork UnitOfWork,
    IUserRepository Repository) : IUpdateUserCommandHandler
{
    public async Task<User> HandleAsync(UpdateUserCommand command,
        CancellationToken cancellationToken)
    {
        var user = new User
        {
            Id = int.Parse(command.Id),
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

        var response = await Repository.UpdateAsync(user, cancellationToken);
        await UnitOfWork.SaveChangesAsync(cancellationToken);
        return user;
    }
}
