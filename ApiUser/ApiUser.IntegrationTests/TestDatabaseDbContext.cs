using Microsoft.EntityFrameworkCore;

namespace ApiUser.IntegrationTests;

public class TestDatabaseDbContext : DbContext
{
    public TestDatabaseDbContext(DbContextOptions<TestDatabaseDbContext> options)
        : base(options)
    {

    }
}
