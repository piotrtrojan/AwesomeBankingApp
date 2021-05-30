using AwesomeBankingApp.Bootstrap;
using AwesomeBankingApp.Loan.Interfaces;
using AwesomeBankingApp.Loan.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AwesomeBankingApp.Loan
{
    public class LoanModule : ModuleBootstrap
    {
        public LoanModule(IServiceCollection serviceCollection, IConfiguration configuration) 
            : base(serviceCollection, configuration)
        {
            RegisterConfiguration<LoanModuleConfiguration>(GetType().Name);
        }

        public override void RegisterDependencies()
        {
            _serviceCollection.AddSingleton<ILoanConfigurationProvider, LoanConfigurationProvider>();
            _serviceCollection.AddTransient<IAdministrationFeesCalculationService, AdministrationFeesCalculationService>();
            _serviceCollection.AddTransient<ICapitalizationService, CapitalizationService>();
            _serviceCollection.AddTransient<IMonthlyCostCalculationService, MonthlyCostCalculationService>();
            _serviceCollection.AddTransient<IAnnualPercentageRateService, AnnualPercentageRateService>();
            _serviceCollection.AddTransient<ILoanCalculationService, LoanCalculationService>();
        }
    }
}
