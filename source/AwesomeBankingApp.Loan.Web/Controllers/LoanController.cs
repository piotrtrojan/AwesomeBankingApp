using AutoMapper;
using AwesomeBankingApp.Loan.Contracts;
using AwesomeBankingApp.Loan.Interfaces;
using AwesomeBankingApp.Loan.WebContracts;
using AwesomeBankingApp.Loan.WebContracts.Loan;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeBankingApp.Loan.Controllers
{
    /// <summary>
    /// Handles actions related to Loans.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly ILoanCalculationService service;
        private readonly ILoanConfigurationProvider configurationProvider;
        private readonly IMapper mapper;

        /// <summary>
        /// Instantiates LoanController.
        /// </summary>
        /// <param name="service"></param>
        /// <param name="configurationProvider"></param>
        /// <param name="mapper">Automapper instance</param>
        public LoanController(ILoanCalculationService service,
            ILoanConfigurationProvider configurationProvider,
            IMapper mapper)
        {
            this.service = service;
            this.configurationProvider = configurationProvider;
            this.mapper = mapper;
        }

        /// <summary>
        /// Makes loan calculation. Default values of Fees and interest rates will be applied.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Information about monthly costs, fees and others. <see cref="LoanCalculationResponse"/></returns>
        [HttpGet]
        public IActionResult MakeCalculation([FromQuery] LoanCalculationRequest request)
        {
            var query = mapper.Map<LoanCalculationQuery>(request);

            var config = configurationProvider.GetLoanConfiguration();
            query.AdministrationFeeMaxValue = config.AdministrationFeeMaxValue;
            query.AdministrationFeePercent = config.AdministrationFeePercent;
            query.AnnualInterestRate = config.AnnualInterestRate;
            query.InterestRateCalculationFrequency = config.InterestRateCalculationFrequency;

            var result = service.GenerateLoanCalculation(query);

            var response = mapper.Map<LoanCalculationResponse>(result);
            return Ok(response);
        }

        /// <summary>
        /// Makes custom loan calculation, where additional data must be provided.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Information about monthly costs, fees and others. <see cref="LoanCalculationResponse"/></returns>
        [HttpGet("Custom")]
        public IActionResult MakeCalculationCustom([FromQuery] LoanCustomCalculationRequest request)
        {
            var query = mapper.Map<LoanCalculationQuery>(request);
            var result = service.GenerateLoanCalculation(query);
            var response = mapper.Map<LoanCalculationResponse>(result);
            return Ok(response);
        }
    }
}
