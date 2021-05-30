using AwesomeBankingApp.Loan.Contracts;
using AwesomeBankingApp.Loan.Interfaces;
using System;

namespace AwesomeBankingApp.Loan.Services
{
    public class LoanCalculationService : ILoanCalculationService
    {
        private readonly ILoanConfigurationProvider loanConfigurationProvider;
        private readonly IMonthlyCostCalculationService monthlyCostCalculationService;
        private readonly IAdministrationFeesCalculationService administrationFeesCalculationService;
        private readonly ICapitalizationService capitalizationService;
        private readonly IAnnualPercentageRateService annualPercentageRateService;

        public LoanCalculationService(
            ILoanConfigurationProvider loanConfigurationProvider,
            IMonthlyCostCalculationService monthlyCostCalculationService,
            IAdministrationFeesCalculationService administrationFeesCalculationService,
            ICapitalizationService capitalizationService,
            IAnnualPercentageRateService annualPercentageRateService)
        {
            this.loanConfigurationProvider = loanConfigurationProvider;
            this.monthlyCostCalculationService = monthlyCostCalculationService;
            this.administrationFeesCalculationService = administrationFeesCalculationService;
            this.capitalizationService = capitalizationService;
            this.annualPercentageRateService = annualPercentageRateService;
        }

        public LoanCalculationResult GenerateLoanCalculation(LoanCalculationQuery query)
        {
            var roundingPrecision = loanConfigurationProvider.GetDecimalRoundingPrecision();
            var capitalizationsPerYear = capitalizationService.GetCapitalizationsPerYear(query.InterestRateCalculationFrequency);
            var monthlyCost = monthlyCostCalculationService.GetMonthlyCost(query, capitalizationsPerYear);
            var administartiveCosts = administrationFeesCalculationService.GetFees(query);
            
            return new LoanCalculationResult
            {
                MonthlyCost = Math.Round(monthlyCost, roundingPrecision),
                TotalAdministrativeFees = Math.Round(administartiveCosts, roundingPrecision),
                TotalInterstsFees = Math.Round(monthlyCost * query.LoanDuration - query.LoanAmount, roundingPrecision),
                YearlyPercentageCost = Math.Round(annualPercentageRateService.GetAnnualPercentageRate(query), roundingPrecision)
            };
        }
    }
}
