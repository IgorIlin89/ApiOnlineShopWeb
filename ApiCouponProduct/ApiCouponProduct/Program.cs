using ApiCouponProduct.Application;
using ApiCouponProduct.Authentication;
using ApiCouponProduct.Database;
using ApiCouponProduct.Middlewares;
using Microsoft.AspNetCore.Authentication;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

try
{
    var bootstrapLoggingConfiguration = new LoggerConfiguration()
    .WriteTo.File("Logs/ApiCouponProduct_Fatal.log");
    Log.Logger = bootstrapLoggingConfiguration.CreateBootstrapLogger();

    // Add services to the container.

    builder.Services.AddControllers().
        AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
        });

    builder.Services.AddAuthentication(ApiKeyAuthenticationScheme.DefaultScheme)
    .AddScheme<AuthenticationSchemeOptions, ApiKeyAuthenticationHandler>(ApiKeyAuthenticationScheme.DefaultScheme, null);

    builder.Services.AddAuthorization(o =>
    {
        o.AddPolicy(AuthorizeControllerModelConvention.PolicyName, policy =>
        {
            policy.RequireAuthenticatedUser();
        });
    });

    builder.Services.AddMvc(options =>
    {
        options.Conventions.Add(new AuthorizeControllerModelConvention());
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

    ////
    //app.Use(async (context, next) =>
    //{
    //    var authenticateResult = await context.AuthenticateAsync();
    //    if (authenticateResult?.Principal != null)
    //    {
    //        var claims = authenticateResult.Principal.Claims;
    //        foreach (var claim in claims)
    //        {
    //            Console.WriteLine($"{claim.Type}: {claim.Value}");
    //        }
    //    }

    //    await next();
    //});

    app.Run();

}
catch (Exception exception)
{
    Log.Fatal(exception, "Error during start Api");
}
finally
{
    Log.CloseAndFlush();
}
