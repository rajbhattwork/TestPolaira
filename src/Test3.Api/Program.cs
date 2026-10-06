using Serilog;
using Test3.Api.Middleware;
using Test3.Api.Services;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog((context, _, configuration) => configuration
        .ReadFrom.Configuration(context.Configuration)
        .WriteTo.Console());

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new()
        {
            Title = "Test3 API",
            Version = "v1",
            Description = "Production-ready ASP.NET Core Web API scaffold."
        });
        var xmlPath = Path.Combine(AppContext.BaseDirectory, "Test3.Api.xml");
        if (File.Exists(xmlPath))
            options.IncludeXmlComments(xmlPath);
    });

    builder.Services.AddHealthChecks();
    builder.Services.AddScoped<IWeatherService, WeatherService>();
    builder.Services.AddSingleton<ITodoService, TodoService>();

    var app = builder.Build();

    app.UseGlobalExceptionHandler();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test3 API v1"));

    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    app.MapHealthChecks("/health");

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}

// Required for WebApplicationFactory in integration tests
public partial class Program { }
