namespace AwesomeBankingApp.Loan.WebContracts.Loan
{
    /// <summary>
    /// Contains data required to make a custom loan calculation, where more data must be provided.
    /// </summary>
    public class LoanCustomCalculationRequest : LoanCalculationRequest
    {
        /// <summary>
        /// Annual interest rate in percents, e.g. 5 means 5%.
        /// </summary>
        public decimal? AnnualInterestRate { get; set; }
        /// <summary>
        /// Administartion fee that needs to be paid, represented as percent of LoanAmount.
        /// </summary>
        public decimal? AdministrationFeePercent { get; set; }
        /// <summary>
        /// Maximum value of administration fee that can be paid.
        /// </summary>
        public decimal? AdministrationFeeMaxValue { get; set; }
        /// <summary>
        /// Interest rate calculation frequency. Possible values are: Daily, Weekly, Monthly, Yearly
        /// </summary>
        public string InterestRateCalculationFrequency { get; set; }
    }
}
