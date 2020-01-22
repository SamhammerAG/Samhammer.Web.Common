using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Samhammer.Web.Common.Contracts;

namespace Samhammer.Web.Common.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VersionController : ControllerBase
    {
        public IHostingEnvironment HostingEnvironment { get; set; }

        public VersionController(IHostingEnvironment env)
        {
            HostingEnvironment = env;
        }

        [HttpGet]
        public ActionResult<VersionContract> Get()
        {
            var assembly = typeof(VersionController).GetTypeInfo().Assembly;
            var versionAttribute = assembly.GetCustomAttribute<AssemblyFileVersionAttribute>();
            var versionInfo = new VersionContract
            {
                Version = versionAttribute.Version,
                Environment = HostingEnvironment.EnvironmentName,
            };

            return Ok(versionInfo);
        }
    }
}
