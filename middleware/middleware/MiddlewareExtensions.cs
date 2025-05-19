using Microsoft.AspNetCore.Builder;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<Middleware>();
    }
}
