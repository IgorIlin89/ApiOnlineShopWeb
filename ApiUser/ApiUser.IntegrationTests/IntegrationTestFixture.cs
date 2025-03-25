using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;

namespace ApiUser.IntegrationTests;

public class IntegrationTestFixture : WebApplicationFactory<Program>
{
    private const string Environment = "Integration";
    public DBSetup DbSetup { get; init; }

    public IntegrationTestFixture()
    {
        DbSetup = new DBSetup("appsettings.Integration.json");
    }

    protected override void Dispose(bool disposing)
    {
        try
        {
            if (disposing)
            {
                DbSetup.Dispose();
            }
        }
        catch (Exception) { }
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder
            .UseEnvironment(Environment)
            .ConfigureTestServices(testServices =>
            {
            }
        );
    }
}
