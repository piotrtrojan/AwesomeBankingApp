using AwesomeBankingApp.Api.WebContracts.Loan;
using FluentValidation;

namespace AwesomeBankingApp.Api.Validator.Loan
{
    public class LoanCalculationRequestValidator : AbstractValidator<LoanCalculationRequest>
    {
        public LoanCalculationRequestValidator()
        {
            RuleFor(q => q.LoanAmount)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .GreaterThan(0);

            RuleFor(q => q.LoanDuration)
                .Cascade(CascadeMode)
                .NotNull()
                .GreaterThan(0);
        }
    }
}
