using Microsoft.AspNetCore.Builder;
using Samhammer.Web.Common.Middleware;
using Samhammer.Web.Common.Middleware.Options;

namespace Samhammer.Web.Common.Extensions
{
    public static class VersionMiddlewareExtensions
    {
        public static IApplicationBuilder UseVersion(this IApplicationBuilder builder, string path = "/version")
        {
            var options = new EndpointOptions { Path = path };
            return builder.UseMiddleware<VersionMiddleware>(options);
        }
    }
}
