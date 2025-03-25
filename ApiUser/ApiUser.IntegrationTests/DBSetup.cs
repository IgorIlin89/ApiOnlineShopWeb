using ApiUser.Migrations;
using FluentMigrator.Runner;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ApiUser.IntegrationTests;

public class DBSetup : IDisposable
{
    private readonly string _connectionString;

    public DBSetup(string configfile)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile(configfile)
            .Build();

        _connectionString = configuration.GetConnectionString("ApiOnlineShopWebDb");

        EnsureDatabaseCreated(_connectionString);

        MigrateUp(_connectionString, typeof(Initial).Assembly);
    }

    private string EnsureDatabaseCreated(string connectionString)
    {
        var dbContextOptions = new DbContextOptionsBuilder<TestDatabaseDbContext>()
            .UseSqlServer(connectionString)
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
            .Options;

        using var context = new TestDatabaseDbContext(dbContextOptions);
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        return connectionString;
    }

    private string MigrateUp(string connectionString, params Assembly[] assemblies)
    {
        if (connectionString is null) throw new ArgumentNullException(nameof(connectionString));
        if (assemblies is null) throw new ArgumentNullException(nameof(assemblies));
        if (!assemblies.Any()) throw new ArgumentOutOfRangeException(nameof(assemblies));

        var servicecollection = new ServiceCollection();

        AddFluentMigrator(servicecollection, connectionString, assemblies);

        servicecollection.BuildServiceProvider(false)
        .GetRequiredService<IMigrationRunner>()
        .MigrateUp();

        return connectionString;
    }

    private IServiceCollection AddFluentMigrator(IServiceCollection services,
        string connectionString,
        params Assembly[] assemblies)
    {
        return services
            .AddFluentMigratorCore()
            .ConfigureRunner(rb => rb
                .ConfigureGlobalProcessorOptions(o => o.Timeout = TimeSpan.FromMinutes(15))
                .AddSqlServer2016()
                .WithGlobalConnectionString(connectionString)
                .ScanIn(assemblies).For.Migrations())
            .AddLogging(lb => lb.AddFluentMigratorConsole());
    }

    public void Dispose()
    {
        DropDbIfExists(_connectionString);
    }

    public string DropDbIfExists(string connectionString)
    {
        if (connectionString == null)
        {
            throw new ArgumentNullException("connectionString");
        }

        SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);
        string initialCatalog = ClearInitialCatalog(sqlConnectionStringBuilder);
        using SqlConnection sqlConnection = CreateSqlConnection(sqlConnectionStringBuilder);
        sqlConnection.Open();
        if (DbExists(sqlConnection, initialCatalog))
        {
            DropDb(sqlConnection, initialCatalog);
        }

        return connectionString;
    }

    private string ClearInitialCatalog(SqlConnectionStringBuilder sqlConnectionStringBuilder)
    {
        string initialCatalog = sqlConnectionStringBuilder.InitialCatalog;
        sqlConnectionStringBuilder.Remove("Initial Catalog");
        return initialCatalog;
    }

    private SqlConnection CreateSqlConnection(SqlConnectionStringBuilder sqlConnectionStringBuilder)
    {
        return new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
    }

    private bool DbExists(SqlConnection sqlConnection, string initialCatalog)
    {
        using SqlCommand sqlCommand = new SqlCommand("SELECT * FROM sys.databases WHERE NAME = '" + initialCatalog + "'", sqlConnection);
        using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
        return sqlDataReader.HasRows;
    }

    private void DropDb(SqlConnection sqlConnection, string initialCatalog)
    {
        using SqlCommand sqlCommand = new SqlCommand($"USE master;ALTER DATABASE {initialCatalog} SET SINGLE_USER WITH ROLLBACK IMMEDIATE;DROP DATABASE {initialCatalog}", sqlConnection);

        sqlCommand.ExecuteNonQuery();
    }

    public void Reset()
    {
        // Inhalt der Datenbank zurücksetzen
        ResetData(_connectionString, new[]
        {
            "dbo.User"
        });
    }

    private void ResetData(string connectionString, IEnumerable<string> tableNames)
    {
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        foreach (var tableName in tableNames)
        {
            ExecuteSql(connection, $"DELETE FROM {tableName}");
        }
    }

    private void ExecuteSql(SqlConnection sqlConnection, string sql)
    {
        using var command = new SqlCommand(sql, sqlConnection);
        command.ExecuteNonQuery();
    }
}
