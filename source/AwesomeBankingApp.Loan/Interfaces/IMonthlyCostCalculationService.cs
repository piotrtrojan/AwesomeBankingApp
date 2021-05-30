using AwesomeBankingApp.Loan.Contracts;

namespace AwesomeBankingApp.Loan.Interfaces
{
    public interface IMonthlyCostCalculationService
    {
        decimal GetMonthlyCost(LoanCalculationQuery query, int capitalizationsPerYear);
    }
}
