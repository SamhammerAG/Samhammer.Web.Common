using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace Samhammer.Web.Common.Extensions
{
    public static class ExceptionHandlerExtensions
    {
        public static IApplicationBuilder UseDefaultExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(new ExceptionHandlerOptions
            {
                ExceptionHandler = (context) => Task.CompletedTask
            });

            return app;
        }
    }
}
