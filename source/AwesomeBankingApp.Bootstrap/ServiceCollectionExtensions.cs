using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AwesomeBankingApp.Bootstrap
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddModule<TModule>(this IServiceCollection services, IConfigurationRoot configurationRoot = null) where TModule : ModuleBootstrap
        {
            var instance = Activator.CreateInstance(typeof(TModule), services, configurationRoot) as ModuleBootstrap;
            instance.RegisterDependencies();
            return services.AddSingleton(instance);
        }
    }
}