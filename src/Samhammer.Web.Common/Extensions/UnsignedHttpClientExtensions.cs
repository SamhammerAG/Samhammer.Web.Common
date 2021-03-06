﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Samhammer.Web.Common.Http;

namespace Samhammer.Web.Common.Extensions
{
    public static class UnsignedHttpClientExtensions
    {
        public static void AddUnsignedHttpClient(this IWebHostBuilder webHostBuilder)
        {
            webHostBuilder.ConfigureServices(AddUnsignedHttpClient);
        }

        public static void AddUnsignedHttpClient(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<UnsignedHttpClientHandler>();

            serviceCollection
                .AddHttpClient(HttpClientNames.UnsignedHttpClient)
                .ConfigurePrimaryHttpMessageHandler(sp => sp.GetService<UnsignedHttpClientHandler>());
        }
    }
}
