using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Samhammer.Web.Common.Middleware
{
    public class PingMiddleware
    {
        private RequestDelegate Next { get; }

        public PingMiddleware(RequestDelegate next)
        {
            Next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/ping"))
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
