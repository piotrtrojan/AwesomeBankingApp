using AwesomeBankingApp.Bootstrap;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AwesomeBankingApp.Loan.Validator
{
    public class LoanWebContractsValidatorModule : ModuleBootstrap
    {
        public LoanWebContractsValidatorModule(IServiceCollection serviceCollection, IConfiguration configuration) 
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
                    fv.RegisterValidatorsFromAssemblyContaining(GetType());
                })
                .ConfigureApiBehaviorOptions(opt => opt.SuppressMapClientErrors = true);
        }
    }
}
