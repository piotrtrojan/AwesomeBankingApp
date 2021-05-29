using AwesomeBankingApp.Bootstrap;
using AwesomeBankingApp.Loan.Interfaces;
using AwesomeBankingApp.Loan.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AwesomeBankingApp.Loan
{
    public class LoanModule : ModuleBootstrap
    {
        public LoanModule(IServiceCollection serviceCollection, IConfiguration configuration) : base(serviceCollection, configuration)
        {
            RegisterConfiguration<LoanModuleConfiguration>("LoanModule");
        }

        public override void RegisterDependencies()
        {
            RegisterDependenciesGuard();

            _serviceCollection.AddTransient<ILoanCalculationService, LoanCalculationService>();
            _serviceCollection.AddSingleton<ILoanConfigurationProvider, LoanConfigurationProvider>();
        }
    }
}
