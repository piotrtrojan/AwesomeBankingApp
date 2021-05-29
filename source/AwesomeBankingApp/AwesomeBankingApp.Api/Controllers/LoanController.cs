using AwesomeBankingApp.Loan.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeBankingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly ILoanCalculationService service;

        public LoanController(ILoanCalculationService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = service.GenerateLoanCalculation(new Loan.Contracts.LoanCalculationQuery
            {
                DurationOfLoan = 12,
                LoanAmount = 20_000
            });
            return Ok(result);
        }
    }
}
