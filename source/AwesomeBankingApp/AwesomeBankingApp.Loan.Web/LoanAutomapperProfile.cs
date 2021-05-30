using AutoMapper;
using AwesomeBankingApp.Loan.Contracts;
using AwesomeBankingApp.Loan.WebContracts;
using AwesomeBankingApp.Loan.WebContracts.Loan;

namespace AwesomeBankingApp.Loan
{
    internal class LoanAutomapperProfile : Profile
    {
        public LoanAutomapperProfile()
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
