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
            configure.UseSqlServer(configuration.GetConnectionString("ApiOnlineShopWebDb"));
        },
        ServiceLifetime.Transient
        );

        serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>()
            .AddScoped<IUnitOfWorkFactory, UnitOfWorkFactory>()
            .AddScoped<ITransactionRepository, TransactionRepository>();

        return serviceCollection;
    }
}
