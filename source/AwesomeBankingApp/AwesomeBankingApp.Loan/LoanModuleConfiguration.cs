
using AwesomeBankingApp.Loan.Enums;

namespace AwesomeBankingApp.Loan
{
    /// <summary>
    /// Contains configuration of whole LoanModule.
    /// </summary>
    public class LoanModuleConfiguration
    {
        public decimal? DefaultAnnualInterestRate { get; set; }
        public decimal? DefaultAdministrationFeePercent { get; set; }
        public decimal? DefaultAdministrationFeeMaxValue { get; set; }
        public InterestRateCalculationFrequency? DefaultInterestRateCalculationFrequency { get; set; }
        public int? DecimalRoundingPrecision { get; set; }

    }
}
