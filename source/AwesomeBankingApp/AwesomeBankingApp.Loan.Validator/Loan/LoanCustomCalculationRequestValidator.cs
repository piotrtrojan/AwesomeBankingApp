using AwesomeBankingApp.Loan.Enums;
using AwesomeBankingApp.Loan.WebContracts.Loan;
using FluentValidation;
using System;

namespace AwesomeBankingApp.Loan.Validator.Loan
{
    public class LoanCustomCalculationRequestValidator : AbstractValidator<LoanCustomCalculationRequest>
    {
        public LoanCustomCalculationRequestValidator()
        {
            Include(new LoanCalculationRequestValidator());

            RuleFor(q => q.AnnualInterestRate)
                .NotNull()
                .GreaterThanOrEqualTo(0);

            RuleFor(q => q.AdministrationFeePercent)
                .GreaterThanOrEqualTo(0);

            RuleFor(q => q.AdministrationFeeMaxValue)
                .NotNull()
                .GreaterThanOrEqualTo(0);

            RuleFor(q => q.InterestRateCalculationFrequency)
                .NotNull()
                .NotEmpty()
                .Must(x => Enum.IsDefined(typeof(InterestRateCalculationFrequency), x))
                    .WithMessage(q => $"Invalid value of {nameof(q.InterestRateCalculationFrequency)}");
        }
    }
}
