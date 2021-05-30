using AwesomeBankingApp.Bootstrap;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AwesomeBankingApp.Api.Validator
{
    public class ApiWebContractsValidatorModule : ModuleBootstrap
    {
        public ApiWebContractsValidatorModule(IServiceCollection serviceCollection, IConfiguration configuration) 
            : base(serviceCollection, configuration)
        {
        }

        public override void RegisterDependencies()
        {
            _serviceCollection
                .AddControllers()
                .AddFluentValidation(fv =>
                {
                    fv.DisableDataAnnotationsValidation = true;
                    fv.RegisterValidatorsFromAssemblyContaining<ApiWebContractsValidatorModule>();
                });
        }
    }
}
