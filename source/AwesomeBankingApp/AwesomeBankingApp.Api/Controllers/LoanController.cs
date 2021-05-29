using Microsoft.AspNetCore.Mvc;

namespace AwesomeBankingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        public LoanController()
        {

        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
