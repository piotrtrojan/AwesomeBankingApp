using AwesomeBankingApp.Loan.Contracts;

namespace AwesomeBankingApp.Loan.Interfaces
{
    public interface IAnnualPercentageRateService
    {
        decimal GetAnnualPercentageRate(LoanCalculationQuery query);
    }
}
