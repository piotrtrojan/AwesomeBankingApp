using AwesomeBankingApp.Loan.Contracts;

namespace AwesomeBankingApp.Loan.Interfaces
{
    public interface ILoanCalculationService
    {
        LoanCalculationResult GenerateLoanCalculation(LoanCalculationQuery query);
    }
}
