using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AwesomeBankingApp.Bootstrap
{
    public abstract class ModuleBootstrap : IModuleBootstrap
    {
        protected IServiceCollection _serviceCollection;
        protected IConfiguration _configuration;
        protected bool _configurationRegistered;

        protected ModuleBootstrap(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            _serviceCollection = serviceCollection ?? throw new ArgumentNullException(nameof(serviceCollection));
            _configuration = configuration;
            _configurationRegistered = false;
        }

        public abstract void RegisterDependencies();

        protected virtual void RegisterDependenciesGuard()
        {
            if (_configurationRegistered)
                throw new InvalidOperationException($"Configuration of {GetType().Name} has already been registered.");
            
            _configurationRegistered = true;
        }

        protected void RegisterConfiguration<TOptions>(string sectionName = null) where TOptions : class
        {
            if (_configuration != null)
            {
                _serviceCollection.Configure<TOptions>(
                    sectionName == null ? 
                    _configuration :
                    _configuration.GetSection(sectionName));
            }
        }

        
    }
}