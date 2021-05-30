using AwesomeBankingApp.Loan.WebContracts;
using FluentValidation;

namespace AwesomeBankingApp.Loan.Validator.Loan
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
