using AwesomeBankingApp.Loan.Contracts;
using AwesomeBankingApp.Loan.Interfaces;
using Microsoft.Extensions.Options;
using System;

namespace AwesomeBankingApp.Loan.Services
{
    public class LoanCalculationService : ILoanCalculationService
    {
        private readonly LoanModuleConfiguration loanConfiguration;

        public LoanCalculationService(IOptions<LoanModuleConfiguration> configuration)
        {
            loanConfiguration = configuration?.Value ?? throw new ArgumentException("Bank configuration not provided.", nameof(configuration));
            _ = loanConfiguration.AdministrationFeeMaxValue ?? 
                    throw new ArgumentException("Administration fee max value not provided.", nameof(loanConfiguration.AdministrationFeeMaxValue));
            _ = loanConfiguration.AdministrationFeePercent ?? 
                    throw new ArgumentException("Administration fee not provided.", nameof(loanConfiguration.AdministrationFeePercent));
            _ = loanConfiguration.AnnualInterestRate ?? 
                    throw new ArgumentException("Annual interest rate not provided.", nameof(loanConfiguration.AnnualInterestRate));
            _ = loanConfiguration.InterestRateCalculationFrequency ?? 
                    throw new ArgumentException("Interest rate calculation frequesncy.", nameof(loanConfiguration.InterestRateCalculationFrequency));
        }

        public LoanCalculationResult GenerateLoanCalculation(LoanCalculationQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
