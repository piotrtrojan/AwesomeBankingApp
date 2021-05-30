using AwesomeBankingApp.Loan.Configuration;
using AwesomeBankingApp.Loan.Enums;
using AwesomeBankingApp.Loan.Interfaces;
using Microsoft.Extensions.Options;
using System;

namespace AwesomeBankingApp.Loan.Services
{
    public class LoanConfigurationProvider : ILoanConfigurationProvider
    {
        private readonly LoanModuleConfiguration configuration;
        private readonly LoanCalculationConfiguration loanConfiguration;

        public LoanConfigurationProvider(IOptions<LoanModuleConfiguration> startupConfig)
        {
            configuration = startupConfig?.Value 
                ?? throw new ArgumentException("Bank default configuration not provided.", nameof(startupConfig));

            _ = configuration.DecimalRoundingPrecision ??
                throw new ArgumentException("Decimal rounding precision not provided");

            loanConfiguration = new LoanCalculationConfiguration
            {
                AdministrationFeeMaxValue = configuration.DefaultAdministrationFeeMaxValue ??
                    throw new ArgumentException($"{nameof(configuration.DefaultAdministrationFeeMaxValue)} not provided."),
                AdministrationFeePercent = configuration.DefaultAdministrationFeePercent / 100 ??
                    throw new ArgumentException($"{nameof(configuration.DefaultAdministrationFeePercent)} not provided."),
                AnnualInterestRate = configuration.DefaultAnnualInterestRate / 100 ??
                    throw new ArgumentException($"{nameof(configuration.DefaultAnnualInterestRate)} not provided."),
                InterestRateCalculationFrequency = configuration.DefaultInterestRateCalculationFrequency ??
                    throw new ArgumentException($"{nameof(configuration.DefaultInterestRateCalculationFrequency)} not provided.")
            };
        }

        public LoanCalculationConfiguration GetLoanConfiguration() 
            => loanConfiguration;

        public int GetDecimalRoundingPrecision()
            => configuration.DecimalRoundingPrecision.Value;

        public void UpdateAdministartionFee(decimal administrationFee) 
            => loanConfiguration.AdministrationFeePercent = administrationFee / 100;

        public void UpdateAdministartionMax(decimal administrationMax) 
            => loanConfiguration.AdministrationFeeMaxValue = administrationMax;

        public void UpdateAnnualInterest(decimal annualInterest) 
            => loanConfiguration.AnnualInterestRate = annualInterest / 100;

        public void UpdateInterestFrequency(InterestRateCalculationFrequency frequency) 
            => loanConfiguration.InterestRateCalculationFrequency = frequency;
    }
}
