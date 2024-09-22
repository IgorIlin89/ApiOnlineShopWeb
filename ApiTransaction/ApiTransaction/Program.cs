using Transaction.Application;
using Transaction.Database;
using Transaction.Middlewares;
using Microsoft.Data.SqlClient;
using NServiceBus;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
IEndpointInstance endpointInstance = null;

try
{

    var bootstrapLoggingConfiguration = new LoggerConfiguration()
        .WriteTo.File("Logs/Transaction_Fatal.log");
    Log.Logger = bootstrapLoggingConfiguration.CreateBootstrapLogger();

    // Add services to the container.

    builder.Services.AddControllers().
        AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
        });

    builder.Services.AddDatabase(builder.Configuration);
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddApplication();

    var loggingConfiguration = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration)
        .Enrich.FromLogContext()
        .Enrich.WithProcessId()
        .Enrich.WithProcessName()
        .Enrich.WithMachineName();

    var logger = loggingConfiguration.CreateLogger();
    builder.Host.UseSerilog(logger);

    //NServiceBus
    //This is name in Database
    var endpointConfiguration = new EndpointConfiguration("ApiTransaction");
    endpointConfiguration.SendFailedMessagesTo("error");
    endpointConfiguration.AuditProcessedMessagesTo("audit");
    endpointConfiguration.EnableInstallers();

    // Choose JSON to serialize and deserialize messages
    endpointConfiguration.UseSerialization<NServiceBus.SystemJsonSerializer>();

    var nserviceBusConnectionString = builder.Configuration.GetConnectionString("NServiceBus");

    var transportConfig = new NServiceBus.SqlServerTransport(nserviceBusConnectionString)
    {
        DefaultSchema = "dbo",
        TransportTransactionMode = TransportTransactionMode.SendsAtomicWithReceive,
        Subscriptions =
    {
        CacheInvalidationPeriod = TimeSpan.FromMinutes(1),
        SubscriptionTableName = new NServiceBus.Transport.SqlServer.SubscriptionTableName(
            table: "Subscriptions",
            schema: "dbo")
    }
    };

    transportConfig.SchemaAndCatalog.UseSchemaForQueue("error", "dbo");
    transportConfig.SchemaAndCatalog.UseSchemaForQueue("audit", "dbo");

    var transport = endpointConfiguration.UseTransport<SqlServerTransport>(transportConfig);

    //persistence
    var persistence = endpointConfiguration.UsePersistence<SqlPersistence>();
    var dialect = persistence.SqlDialect<SqlDialect.MsSqlServer>();
    dialect.Schema("dbo");
    persistence.ConnectionBuilder(() => new SqlConnection(nserviceBusConnectionString));
    persistence.TablePrefix("");

    //await SqlServerHelper.CreateSchema(nserviceBusConnectionString, "dbo");

    var endpointContainer = EndpointWithExternallyManagedContainer.Create(endpointConfiguration, builder.Services);
    endpointInstance = await endpointContainer.Start(builder.Services.BuildServiceProvider());

    //End NServiceBus

    var app = builder.Build();

    app.UseMiddleware<ExceptionHandlingMiddleware>();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    await app.RunAsync();
}
catch (Exception exception)
{
    Log.Fatal(exception, "Error during Start Api");
}
finally
{
    if (endpointInstance is not null)
    {
        await endpointInstance.Stop()
        .ConfigureAwait(false);
        //TODO in microsoft learn look up ConfigureAwait
    }
    Log.CloseAndFlush();
}
