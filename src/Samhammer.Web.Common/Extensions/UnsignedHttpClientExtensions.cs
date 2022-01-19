using Microsoft.Extensions.DependencyInjection;
using Samhammer.Web.Common.Http;

namespace Samhammer.Web.Common.Extensions
{
    public static class UnsignedHttpClientExtensions
    {
        public static void AddUnsignedHttpClient(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<UnsignedHttpClientHandler>();

            serviceCollection
                .AddHttpClient(HttpClientNames.UnsignedHttpClient)
                .ConfigurePrimaryHttpMessageHandler(sp => sp.GetService<UnsignedHttpClientHandler>());
        }

        public static IHttpClientBuilder AddAllowUnsignedPrimaryHandler(this IHttpClientBuilder clientBuilder)
        {
            clientBuilder.ConfigurePrimaryHttpMessageHandler(sp => sp.GetService<UnsignedHttpClientHandler>());
            return clientBuilder;
        }
    }
}
