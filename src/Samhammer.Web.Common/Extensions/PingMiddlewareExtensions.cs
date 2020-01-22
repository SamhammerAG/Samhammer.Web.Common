using Microsoft.AspNetCore.Builder;
using Samhammer.Web.Common.Middleware;
using Samhammer.Web.Common.Middleware.Options;

namespace Samhammer.Web.Common.Extensions
{
    public static class PingMiddlewareExtensions
    {
        public static IApplicationBuilder UsePing(this IApplicationBuilder builder, string path = "/ping")
        {
            var options = new EndpointOptions { Path = path };
            return builder.UseMiddleware<PingMiddleware>(options);
        }
    }
}
