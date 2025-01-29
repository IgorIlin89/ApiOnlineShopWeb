using Microsoft.Extensions.DependencyInjection;
using Transaction.Application.Handlers;
using Transaction.Application.Interfaces;

namespace Transaction.Application;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IAddTransactionCommandHandler, AddTransactionCommandHandler>().
            AddScoped<IGetTransactionListCommandHandler, GetTransactionListCommandHandler>().
            AddScoped<IAddTransactionCommandGrpcHandler, AddTransactionCommandGrpcHandler>();

        return serviceCollection;
    }
}
