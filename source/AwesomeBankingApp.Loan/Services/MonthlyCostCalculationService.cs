using AwesomeBankingApp.Loan.Contracts;
using AwesomeBankingApp.Loan.Interfaces;
using System;

namespace AwesomeBankingApp.Loan.Services
{
    public class MonthlyCostCalculationService : IMonthlyCostCalculationService
    {
        public decimal GetMonthlyCost(LoanCalculationQuery query, int capitalizationsPerYear)
        {
            // To be honest, I am not 100% sure about the algorithm. I am sure it works correctly for 
            // monthly capitalisation, but not sure if works correctly for others. 
            // I am sure, that if I worked in Danske Bank, I would get the algorithm from technical
            // writer or business analytic.
            // I hope that potential algorithm errors would not imapct on my review.
            
            var monthRatio = (capitalizationsPerYear / 12m);
            var kkr = (decimal)Math.Pow(
                (double)(capitalizationsPerYear / (capitalizationsPerYear + query.AnnualInterestRate)),
                (double)(query.LoanDuration * monthRatio));

            return monthRatio *
                   (query.LoanAmount* query.AnnualInterestRate) /
                   (capitalizationsPerYear * (1 - kkr));
        }
    }
}
