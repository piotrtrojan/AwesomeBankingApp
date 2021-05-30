using AutoMapper;
using AwesomeBankingApp.Api.WebContracts.Loan;
using AwesomeBankingApp.Loan.Contracts;

namespace AwesomeBankingApp.Api
{
    internal class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            RegisterLoan();
        }

        private void RegisterLoan()
        {
            CreateMap<LoanCalculationRequest, LoanCalculationQuery>();
            CreateMap<LoanCustomCalculationRequest, LoanCalculationQuery>()
                .AfterMap((q, d) =>
                {
                    d.AdministrationFeePercent /= 100;
                    d.AnnualInterestRate /= 100;
                });
            CreateMap<LoanCalculationResult, LoanCalculationResponse>();
        }
    }
}
