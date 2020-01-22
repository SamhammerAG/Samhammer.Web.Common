using Microsoft.AspNetCore.Builder;
using Samhammer.Web.Common.Middleware;

namespace Samhammer.Web.Common.Extensions
{
    public static class PingMiddlewareExtensions
    {
        public static IApplicationBuilder UsePing(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<PingMiddleware>();
        }
    }
}
