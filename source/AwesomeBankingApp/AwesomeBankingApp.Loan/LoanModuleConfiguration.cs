
using AwesomeBankingApp.Loan.Enums;

namespace AwesomeBankingApp.Loan
{
    public class LoanModuleConfiguration
    {
        public decimal? DefaultAnnualInterestRate { get; set; }
        public decimal? DefaultAdministrationFeePercent { get; set; }
        public decimal? DefaultAdministrationFeeMaxValue { get; set; }
        public InterestRateCalculationFrequency? DefaultInterestRateCalculationFrequency { get; set; }

    }
}
