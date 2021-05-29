using AwesomeBankingApp.Loan.Configuration;

namespace AwesomeBankingApp.Loan.Interfaces
{
    public interface ILoanConfigurationProvider
    {
        LoanCalculationConfiguration GetConfiguration();
    }
}
