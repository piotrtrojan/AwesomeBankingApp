using AwesomeBankingApp.Loan.Contracts;
using AwesomeBankingApp.Loan.Interfaces;
using System;

namespace AwesomeBankingApp.Loan.Services
{
    public class LoanCalculationService : ILoanCalculationService
    {
        private readonly ILoanConfigurationProvider configurationProvider;

        public LoanCalculationService(ILoanConfigurationProvider configurationProvider)
        {
            this.configurationProvider = configurationProvider;
        }

        public LoanCalculationResult GenerateLoanCalculation(LoanCalculationQuery query)
        {
            var loanConfiguration = configurationProvider.GetConfiguration();

            var r = loanConfiguration.AnnualInterestRate;
            var k = 12;
            var n = query.DurationOfLoan;
            var fees = Math.Min(query.LoanAmount * loanConfiguration.AdministrationFeePercent, loanConfiguration.AdministrationFeeMaxValue);
            var bigN = query.LoanAmount;
            var kkr = Math.Pow((double)(k / (k + r)), n);
            var fPerMonth = fees / n;
            var rata = (bigN * r) / (decimal)(k * (1 - kkr));
            //var rataAll = rata + fPerMonth;

            var totalFees = (rata * n) - bigN;

            return new LoanCalculationResult
            {
                MonthlyCost = Math.Round(rata, 2),
                TotalAdministrativeFees = Math.Round(fees, 2),
                TotalInterstsFees = Math.Round(totalFees, 2)
            };
        }
    }
}
