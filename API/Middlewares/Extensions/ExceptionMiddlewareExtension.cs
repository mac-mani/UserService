namespace API.Middlewares.Extensions;

using Microsoft.AspNetCore.Builder;

public static class ExceptionMiddlewareExtension
{
    public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionMiddleware>();
    }
}
