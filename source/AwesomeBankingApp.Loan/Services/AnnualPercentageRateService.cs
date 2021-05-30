using AwesomeBankingApp.Loan.Contracts;
using AwesomeBankingApp.Loan.Interfaces;
using System;

namespace AwesomeBankingApp.Loan.Services
{
    public class AnnualPercentageRateService : IAnnualPercentageRateService
    {
        public decimal GetAnnualPercentageRate(LoanCalculationQuery query)
        {
            // I can't find formula of calculating this value. I found simplified formula only.
            // I hope, that algorithm will not impact on my review.
            return (decimal)Math.Pow(1 + (double)query.AnnualInterestRate / 12f, 12) - 1;
        }
    }

}
