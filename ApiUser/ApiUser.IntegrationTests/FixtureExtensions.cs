using ApiUser.Database;
using ApiUser.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace ApiUser.IntegrationTests;

public static class FixtureExtensions
{
    public static IntegrationTestFixture AddUser(this IntegrationTestFixture integrationTestFixture,
        User user)
    {
        using var scope = integrationTestFixture.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetService<ApiUserContext>();

        dbContext.User.Add(user);
        dbContext.SaveChanges();

        return integrationTestFixture;
    }
}