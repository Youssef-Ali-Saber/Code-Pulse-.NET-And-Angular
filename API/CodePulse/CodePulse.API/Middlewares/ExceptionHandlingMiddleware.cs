using System.Net;
using System.Text.Json;
using CodePulse.Domain.Exceptions;

namespace CodePulse.API.Middlewares;

public class ExceptionHandlingMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        // Map specific exceptions to HTTP status codes
        HttpStatusCode statusCode = exception.GetType().IsGenericType && exception.GetType().GetGenericTypeDefinition() == typeof(EntityNotFoundException<>)
            ? HttpStatusCode.NotFound
            : HttpStatusCode.InternalServerError;

        context.Response.StatusCode = (int)statusCode;

        var response = new
        {
            error = exception.Message,
            statusCode = context.Response.StatusCode
        };

        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}