using System.Net;
using System.Text.Json;

namespace Test3.Api.Middleware;

/// <summary>Catches unhandled exceptions and returns a structured JSON error response.</summary>
public sealed class GlobalExceptionHandlerMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlerMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unhandled exception for {Method} {Path}", context.Request.Method, context.Request.Path);
            await WriteErrorResponseAsync(context, ex);
        }
    }

    private static async Task WriteErrorResponseAsync(HttpContext context, Exception ex)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = ex switch
        {
            ArgumentException or InvalidOperationException => (int)HttpStatusCode.BadRequest,
            KeyNotFoundException => (int)HttpStatusCode.NotFound,
            _ => (int)HttpStatusCode.InternalServerError
        };

        var body = JsonSerializer.Serialize(new
        {
            status = context.Response.StatusCode,
            error = ex.Message
        });

        await context.Response.WriteAsync(body);
    }
}

/// <summary>Extension methods for registering <see cref="GlobalExceptionHandlerMiddleware"/>.</summary>
public static class GlobalExceptionHandlerExtensions
{
    /// <summary>Adds the global exception handler to the request pipeline.</summary>
    public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder app) =>
        app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
}
