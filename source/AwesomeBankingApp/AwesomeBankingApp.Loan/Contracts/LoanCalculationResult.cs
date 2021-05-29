namespace AwesomeBankingApp.Loan.Contracts
{
    public class LoanCalculationResult
    {
        public decimal YearlyPercentageCost { get; set; }
        public decimal MonthlyCost { get; set; }
        public decimal TotalInterstsFees { get; set; }
        public decimal TotalAdministrativeFees { get; set; }
    }
}
