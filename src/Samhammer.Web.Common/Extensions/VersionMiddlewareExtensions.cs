using Microsoft.AspNetCore.Builder;
using Samhammer.Web.Common.Middleware;

namespace Samhammer.Web.Common.Extensions
{
    public static class VersionMiddlewareExtensions
    {
        public static IApplicationBuilder UseVersion(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<VersionMiddleware>();
        }
    }
}
