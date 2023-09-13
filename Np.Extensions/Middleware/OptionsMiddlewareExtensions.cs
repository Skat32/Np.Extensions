using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Np.Extensions.Middleware;

/// <summary>
/// Метод расширения для Options
/// </summary>
public static class OptionsMiddlewareExtensions
{
    /// <summary>
    /// Использование middleware Options
    /// </summary>
    public static IApplicationBuilder UseOptions(this IApplicationBuilder builder) => 
        builder.UseMiddleware<OptionsMiddleware>();
}

/// <summary>
/// Обработка запроса OPTIONS
/// Используется для CORS
/// </summary>
public class OptionsMiddleware
{
    private readonly RequestDelegate _next;

    /// ctor
    /// <param name="next"><see cref="RequestDelegate"/></param>
    public OptionsMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    
    /// <summary>
    /// Вызов
    /// </summary>
    /// <param name="context"><see cref="HttpContext"/></param>
    public Task Invoke(HttpContext context) => BeginInvoke(context);
    
    private Task BeginInvoke(HttpContext context)
    {
        if (context.Request.Method != "OPTIONS")
            return _next.Invoke(context);
        
        context.Response.Headers.Add("Access-Control-Allow-Headers", new[] { "Origin, X-Requested-With, Content-Type, Accept, Authorization" });
        context.Response.Headers.Add("Access-Control-Allow-Methods", new[] { "GET, POST, PUT, DELETE, OPTIONS" });
        context.Response.Headers.Add("Access-Control-Allow-Credentials", new[] { "true" });
        context.Response.StatusCode = 200;
        
        return context.Response.WriteAsync("OK");
    }
}
