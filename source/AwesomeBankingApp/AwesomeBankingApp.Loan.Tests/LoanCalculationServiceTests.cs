using AwesomeBankingApp.Bootstrap;
using AwesomeBankingApp.Loan.Enums;
using AwesomeBankingApp.Loan.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using Xunit;

namespace AwesomeBankingApp.Loan.Tests
{
    public class LoanCalculationServiceTests
    {
        private readonly ILoanCalculationService loanService;
        private readonly ILoanConfigurationProvider configurationProvider;

        public LoanCalculationServiceTests()
        {
            var defaultLoanConfiguration = new Dictionary<string, string> 
            { 
                {"LoanModule:DefaultAnnualInterestRate", "5"},
                {"LoanModule:DefaultAdministrationFeePercent", "1"},
                {"LoanModule:DefaultAdministrationFeeMaxValue", "10000"},
                {"LoanModule:DefaultInterestRateCalculationFrequency", "Monthly"},
                {"LoanModule:DecimalRoundingPrecision", "2" }
            };

            var configurationObject = new ConfigurationBuilder()
                .AddInMemoryCollection(defaultLoanConfiguration)
                .Build();

            var servicesProvider = new ServiceCollection()
                .AddModule<LoanModule>(configurationObject)
                .BuildServiceProvider();

            loanService = servicesProvider.GetRequiredService<ILoanCalculationService>();
            configurationProvider = servicesProvider.GetRequiredService<ILoanConfigurationProvider>();

        }

        [Theory]
        [InlineData(5, 1, 10_000, InterestRateCalculationFrequency.Monthly, 500_000, 120, 5_303.28, 136_393.09, 5_000)]
        [InlineData(6, 0, 0, InterestRateCalculationFrequency.Monthly, 150_000, 240, 1_074.65, 107_915.18, 0)]
        [InlineData(6, 0, 0, InterestRateCalculationFrequency.Weekly, 150_000, 240, 1_073.58, 107_659.15, 0)]
        [InlineData(6, 0, 0, InterestRateCalculationFrequency.Yearly, 150_000, 240, 1_089.81, 111_553.67, 0)]
        public void GenerateLoanCalculation_Correct(
            decimal annualInterest, decimal administrationFee, decimal administrationMax, InterestRateCalculationFrequency frequency, 
            decimal loanAmount, int loanDuration, 
            decimal expectedMonthly, decimal expectedTotalFees, decimal expectedAdministrationFee)
        {
            configurationProvider.UpdateAnnualInterest(annualInterest);
            configurationProvider.UpdateAdministartionFee(administrationFee);
            configurationProvider.UpdateAdministartionMax(administrationMax);
            configurationProvider.UpdateInterestFrequency(frequency);

            var config = configurationProvider.GetLoanConfiguration();

            var calculationResult = loanService.GenerateLoanCalculation(new Contracts.LoanCalculationQuery
            {
                LoanDuration = loanDuration,
                LoanAmount = loanAmount,
                AdministrationFeeMaxValue = config.AdministrationFeeMaxValue,
                AdministrationFeePercent = config.AdministrationFeePercent,
                AnnualInterestRate = config.AnnualInterestRate,
                InterestRateCalculationFrequency = config.InterestRateCalculationFrequency
            });

            var roundingUsed = configurationProvider.GetDecimalRoundingPrecision();

            Assert.Equal(expectedMonthly, calculationResult.MonthlyCost, roundingUsed);
            Assert.Equal(expectedTotalFees, calculationResult.TotalInterstsFees, roundingUsed);
            Assert.Equal(expectedAdministrationFee, calculationResult.TotalAdministrativeFees, roundingUsed);
        }
    }
}
