using AwesomeBankingApp.Loan.Enums;

namespace AwesomeBankingApp.Loan.Contracts
{
    public class LoanCalculationQuery
    {
        public decimal LoanAmount { get; set; }
        public int LoanDuration { get; set; }
        public decimal AnnualInterestRate { get; set; }
        public decimal AdministrationFeePercent { get; set; }
        public decimal AdministrationFeeMaxValue { get; set; }
        public InterestRateCalculationFrequency InterestRateCalculationFrequency { get; set; }
    }
}
