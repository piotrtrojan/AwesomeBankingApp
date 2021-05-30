using AwesomeBankingApp.Loan.Enums;

namespace AwesomeBankingApp.Loan.Configuration
{
    public class LoanCalculationConfiguration
    {
        public decimal AnnualInterestRate { get; set; }
        public decimal AdministrationFeePercent { get; set; }
        public decimal AdministrationFeeMaxValue { get; set; }
        public InterestRateCalculationFrequency InterestRateCalculationFrequency { get; set; }
    }
}
