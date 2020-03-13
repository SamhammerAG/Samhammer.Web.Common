using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Samhammer.Web.Common.Http
{
    public class UnsignedHttpClientBuilder
    {
        public static void Resolve(IServiceCollection serviceCollection)
        {
            // Generic client
            serviceCollection.AddHttpClient();

            AddUnsignedHttpClient(serviceCollection);
        }

        private static void AddUnsignedHttpClient(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<UnsignedHttpClientHandler>();

            serviceCollection
                .AddHttpClient(HttpClientNames.UnsignedHttpClient)
                .ConfigurePrimaryHttpMessageHandler(sp => sp.GetService<UnsignedHttpClientHandler>());
        }
    }
}
