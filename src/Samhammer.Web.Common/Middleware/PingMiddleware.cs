using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Samhammer.Web.Common.Middleware.Options;

namespace Samhammer.Web.Common.Middleware
{
    public class PingMiddleware
    {
        private RequestDelegate Next { get; }

        private EndpointOptions EndpointOptions { get; }

        public PingMiddleware(RequestDelegate next, EndpointOptions endpointOptions)
        {
            Next = next;
            EndpointOptions = endpointOptions;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments(EndpointOptions.Path))
            {
                await context.Response.WriteAsync("OK");
            }
            else
            {
                await Next(context);
            }
        }
    }
}
