using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IVFSuccessCalculatorController : ControllerBase
    {
        private readonly ICalculateSuccessRateService _formulaCalculationService;

        public IVFSuccessCalculatorController(ICalculateSuccessRateService formulaCalculationService)
        {
            _formulaCalculationService = formulaCalculationService;
        }

        [HttpPost]
        public async Task<IActionResult> CalculateIVFSuccessRate([FromBody] UserInput input)
        {
            try
            {
                double successRate = await _formulaCalculationService.CalculateIVFSuccessRate(input);

                return Ok(successRate);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
