using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Routing;

namespace Samhammer.Web.Common.Middleware
{
    public class VersionMiddleware
    {
        private RequestDelegate Next { get; }

        public VersionMiddleware(RequestDelegate next)
        {
            Next = next;
        }

        public async Task InvokeAsync(HttpContext context, IHostingEnvironment env)
        {
            if (context.Request.Path.StartsWithSegments("/version")
                || context.Request.Path.StartsWithSegments("/api/version"))
            {
                await WriteVersionResponse(context, env.EnvironmentName);
            }
            else
            {
                await Next(context);
            }
        }

        private async Task WriteVersionResponse(HttpContext context, string hostingEnvironment)
        {
            var assembly = Assembly.GetEntryAssembly();
            var versionAttribute = assembly.GetCustomAttribute<AssemblyFileVersionAttribute>();
            var versionInfo = new
            {
                versionAttribute.Version,
                Environment = hostingEnvironment,
            };

            await WriteJsonResponse(context, versionInfo);
        }

        private async Task WriteJsonResponse(HttpContext context, object contract)
        {
            var routeData = context.GetRouteData() ?? new RouteData();
            var actionDescriptor = new ActionDescriptor();
            var actionContext = new ActionContext(context, routeData, actionDescriptor);

            var response = new JsonResult(contract);
            await response.ExecuteResultAsync(actionContext);
        }
    }
}
