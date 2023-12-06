using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace orders.middlewares;

public class AuthorizationHeaderMiddleware(ILogger<AuthorizationHeaderMiddleware> logger) : IMiddleware
{
    private readonly ILogger _logger = logger;

    public Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        context.Request.Headers.TryGetValue("api-key", out var apiKey);
        _logger.LogInformation($"api-key: {apiKey.ToString()}");
        if (!apiKey.ToString().StartsWith("web-api-"))
        {
            context.Response.StatusCode = 403;
            return context.Response.WriteAsync("api key should start with web-api-*");
        }
        return next.Invoke(context);
    }
}