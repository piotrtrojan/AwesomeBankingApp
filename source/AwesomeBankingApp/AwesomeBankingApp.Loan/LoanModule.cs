using AwesomeBankingApp.Bootstrap;
using AwesomeBankingApp.Loan.Interfaces;
using AwesomeBankingApp.Loan.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AwesomeBankingApp.Loan
{
    public class LoanModule : ModuleBootstrap
    {
        public LoanModule(IServiceCollection serviceCollection, IConfiguration configuration) : base(serviceCollection, configuration)
        {
            RegisterConfiguration<LoanModuleConfiguration>("LoanModule");
        }

        public override void Run(ILogger logger)
        {
            logger.LogInformation("LoanModule has been properly started...");
        }

        protected override void RegisterDependencies(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ILoanCalculationService, LoanCalculationService>();
        }
    }
}
