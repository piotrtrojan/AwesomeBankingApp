using AwesomeBankingApp.Loan.Enums;
using AwesomeBankingApp.Loan.Interfaces;
using System;

namespace AwesomeBankingApp.Loan.Services
{
    public class CapitalizationService : ICapitalizationService
    {
        public int GetCapitalizationsPerYear(InterestRateCalculationFrequency frequency)
        {
            return frequency switch
            {
                InterestRateCalculationFrequency.Yearly => 1,
                InterestRateCalculationFrequency.Monthly => 12,
                InterestRateCalculationFrequency.Weekly => 52,
                InterestRateCalculationFrequency.Daily => 365,
                _ => throw new NotImplementedException()
            };
        }
    }
}
