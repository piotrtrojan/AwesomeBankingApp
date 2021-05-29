using AwesomeBankingApp.Bootstrap;
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

        public LoanCalculationServiceTests()
        {
            var configuration = new Dictionary<string, string> 
            { 
                {"LoanModule:AnnualInterestRate", "5"},
                {"LoanModule:AdministrationFeePercent", "1"},
                {"LoanModule:AdministrationFeeMaxValue", "10000"},
                {"LoanModule:InterestRateCalculationFrequency", "Monthly"},
            };

            var configurationObject = new ConfigurationBuilder()
                .AddInMemoryCollection(configuration)
                .Build();

            var servicesProvider = new ServiceCollection()
                .AddModule<LoanModule>(configurationObject)
                .BuildServiceProvider();

            loanService = servicesProvider.GetRequiredService<ILoanCalculationService>();

        }

        [Fact]
        public void GenerateLoanCalculation_Correct()
        {
            var calculationResult = loanService.GenerateLoanCalculation(new Contracts.LoanCalculationQuery 
            { 
                DurationOfLoan = 10 * 12, 
                LoanAmount = 500_000 
            });
            Assert.Equal(5_303.28m, calculationResult.MonthlyCost, 2);
            Assert.Equal(136_393.09m, calculationResult.TotalInterstsFees, 2);
            Assert.Equal(5_000m, calculationResult.TotalAdministrativeFees, 2);
        }
    }
}
