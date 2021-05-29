using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace AwesomeBankingApp.Bootstrap
{
    public abstract class ModuleBootstrap : IModuleBootstrap
    {
        protected IServiceCollection _serviceCollection;
        protected IConfiguration _configuration;

        protected ModuleBootstrap(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            IServiceCollection serviceCollection1 = serviceCollection;
            _serviceCollection = serviceCollection1 ?? throw new ArgumentNullException(nameof(serviceCollection));
            IConfiguration configuration1 = configuration;
            _configuration = configuration1 ?? throw new ArgumentNullException(nameof(configuration));
            RegisterDependencies(serviceCollection);
        }

        public abstract void Run(ILogger logger);

        protected abstract void RegisterDependencies(IServiceCollection serviceCollection);

        protected void RegisterConfiguration<TOptions>(string sectionName = null) where TOptions : class
        {
            _serviceCollection.Configure<TOptions>(
                    sectionName == null ? 
                    _configuration :
                    _configuration.GetSection(sectionName));
        }
    }
}