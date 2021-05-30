namespace AwesomeBankingApp.Loan.WebContracts
{
    /// <summary>
    /// Contains data required to make a loan calculation.
    /// </summary>
    public class LoanCalculationRequest
    {
        /// <summary>
        /// Amount of money that client wants to loan. 
        /// </summary>
        public decimal? LoanAmount { get; set; }

        /// <summary>
        /// Length of a loan measured in months. It equals number of loan installments. Accept full months only.
        /// </summary>
        public int? LoanDuration { get; set; }
    }
}
