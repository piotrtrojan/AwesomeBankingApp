using AwesomeBankingApp.Loan.Configuration;
using AwesomeBankingApp.Loan.Enums;

namespace AwesomeBankingApp.Loan.Interfaces
{
    public interface ILoanConfigurationProvider
    {
        LoanCalculationConfiguration GetLoanConfiguration();
        int GetDecimalRoundingPrecision();

        void UpdateAnnualInterest(decimal annualInterest);
        void UpdateAdministartionFee(decimal administrationFee);
        void UpdateInterestFrequency(InterestRateCalculationFrequency frequency);
        void UpdateAdministartionMax(decimal administrationMax);
    }
}
