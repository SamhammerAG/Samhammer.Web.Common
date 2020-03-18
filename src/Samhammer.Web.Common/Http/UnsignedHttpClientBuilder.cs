using System;
using Microsoft.Extensions.DependencyInjection;
using Samhammer.Web.Common.Extensions;

namespace Samhammer.Web.Common.Http
{
    [Obsolete("use UnsignedHttpClientExtensions instead")]
    public class UnsignedHttpClientBuilder
    {
        public static void Resolve(IServiceCollection serviceCollection)
        {
            serviceCollection.AddUnsignedHttpClient();
        }
    }
}
