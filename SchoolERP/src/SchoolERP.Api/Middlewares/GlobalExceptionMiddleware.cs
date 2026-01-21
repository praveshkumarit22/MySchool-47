using System.Net;
using System.Text.Json;
using SchoolERP.Api.Common;

namespace SchoolERP.Api.Middlewares;

public sealed class GlobalExceptionMiddleware : IMiddleware
{
    private readonly ILogger<GlobalExceptionMiddleware> _logger;

    public GlobalExceptionMiddleware(ILogger<GlobalExceptionMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            var traceId = context.TraceIdentifier;

            // Centralized error logging
            _logger.LogError(ex,
                "Unhandled exception | TraceId: {TraceId} | Path: {Path}",
                traceId,
                context.Request.Path);

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            var response = new ApiErrorResponse
            {
                Message = "An unexpected error occurred.",
                Detail = ex.Message, // hide in prod later if needed
                TraceId = traceId
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
