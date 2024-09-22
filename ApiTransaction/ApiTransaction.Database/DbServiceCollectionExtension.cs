using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Transaction.Domain.Interfaces;

namespace Transaction.Database;

public static class DbServiceCollectionExtension
{
    public static IServiceCollection AddDatabase(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        serviceCollection.AddDbContext<TransactionContext>(configure =>
        {
            configure.UseSqlServer(configuration.GetConnectionString("ApiOnlineShopWebDb"), b => b.MigrationsAssembly("Transaction"));
        });

        serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>()
            .AddScoped<ITransactionRepository, TransactionRepository>();

        return serviceCollection;
    }
}
