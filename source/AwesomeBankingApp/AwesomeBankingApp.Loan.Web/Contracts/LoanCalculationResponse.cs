namespace AwesomeBankingApp.Loan.WebContracts.Loan
{
    /// <summary>
    /// Contains loan calculation results.
    /// </summary>
    public class LoanCalculationResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public decimal YearlyPercentageCost { get; set; }
        /// <summary>
        /// Money to be paid each month.
        /// </summary>
        public decimal MonthlyCost { get; set; }
        /// <summary>
        /// Total amount of all fees related to interests.
        /// </summary>
        public decimal TotalInterstsFees { get; set; }
        /// <summary>
        /// Total amount of administration fees. Administrative fees are not included in monthly cost. 
        /// It is paid on loan startup.
        /// </summary>
        public decimal TotalAdministrativeFees { get; set; }
    }
}
