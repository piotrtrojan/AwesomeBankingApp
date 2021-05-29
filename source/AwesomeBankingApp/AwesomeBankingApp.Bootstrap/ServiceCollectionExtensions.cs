using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AwesomeBankingApp.Bootstrap
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddModule<TModule>(this IServiceCollection services, IConfigurationRoot configurationRoot) where TModule : ModuleBootstrap
        {
            object instance = Activator.CreateInstance(typeof(TModule), services, configurationRoot);
            return services.AddSingleton(instance);
        }
    }
}