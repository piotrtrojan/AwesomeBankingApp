using AwesomeBankingApp.Loan.Configuration;
using AwesomeBankingApp.Loan.Interfaces;
using Microsoft.Extensions.Options;

namespace AwesomeBankingApp.Loan.Services
{
    public class LoanConfigurationProvider : ILoanConfigurationProvider
    {
        private readonly LoanModuleConfiguration configuration;

        public LoanConfigurationProvider(IOptions<LoanModuleConfiguration> configuration)
        {
            //loanConfiguration = configuration?.Value ?? throw new ArgumentException("Bank configuration not provided.", nameof(configuration));
            //_ = loanConfiguration.AdministrationFeeMaxValue ??
            //        throw new ArgumentException("Administration fee max value not provided.", nameof(loanConfiguration.AdministrationFeeMaxValue));
            //_ = loanConfiguration.AdministrationFeePercent ??
            //        throw new ArgumentException("Administration fee not provided.", nameof(loanConfiguration.AdministrationFeePercent));
            //_ = loanConfiguration.AnnualInterestRate ??
            //        throw new ArgumentException("Annual interest rate not provided.", nameof(loanConfiguration.AnnualInterestRate));
            //_ = loanConfiguration.InterestRateCalculationFrequency ??
            //        throw new ArgumentException("Interest rate calculation frequesncy.", nameof(loanConfiguration.InterestRateCalculationFrequency));
            this.configuration = configuration.Value;
        }

        public LoanCalculationConfiguration GetConfiguration()
        {
            return new LoanCalculationConfiguration
            {
                AdministrationFeeMaxValue = configuration.DefaultAdministrationFeeMaxValue.Value,
                AdministrationFeePercent = configuration.DefaultAdministrationFeePercent.Value / 100,
                AnnualInterestRate = configuration.DefaultAnnualInterestRate.Value / 100,
                InterestRateCalculationFrequency = configuration.DefaultInterestRateCalculationFrequency.Value
            };
        }
    }
}
