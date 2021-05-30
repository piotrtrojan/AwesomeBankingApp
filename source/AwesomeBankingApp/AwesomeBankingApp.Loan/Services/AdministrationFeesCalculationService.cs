using AwesomeBankingApp.Loan.Contracts;
using AwesomeBankingApp.Loan.Interfaces;
using System;

namespace AwesomeBankingApp.Loan.Services
{
    public class AdministrationFeesCalculationService : IAdministrationFeesCalculationService
    {
        public decimal GetFees(LoanCalculationQuery query)
        {
            return Math.Min(query.LoanAmount * query.AdministrationFeePercent, query.AdministrationFeeMaxValue);
        }
    }
}
