using AwesomeBankingApp.Loan.Contracts;

namespace AwesomeBankingApp.Loan.Interfaces
{
    public interface IAdministrationFeesCalculationService
    {
        decimal GetFees(LoanCalculationQuery query);
    }
}
