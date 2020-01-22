using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Samhammer.Web.Common.Http
{
    public class UnsignedHttpClientBuilder
    {
        public static void Resolve(WebHostBuilderContext builder, IServiceCollection serviceCollection)
        {
            ResolveUnsignedHttpClient(serviceCollection);
        }

        private static void ResolveUnsignedHttpClient(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<UnsignedCertificateHttpClientHandler>();

            serviceCollection
                .AddHttpClient(HttpClientNames.UnsignedHttpClient)
                .ConfigurePrimaryHttpMessageHandler(sp => sp.GetService<UnsignedCertificateHttpClientHandler>());
        }
    }
}
