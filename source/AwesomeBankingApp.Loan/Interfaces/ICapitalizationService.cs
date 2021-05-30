using AwesomeBankingApp.Loan.Enums;

namespace AwesomeBankingApp.Loan.Interfaces
{
    public interface ICapitalizationService
    {
        int GetCapitalizationsPerYear(InterestRateCalculationFrequency frequency);
    }
}
