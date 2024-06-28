using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace System_Uznawania_Przychodów_dla_dużej_korporacji_ABC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RevenueController : ControllerBase
    {
        private readonly IContractService _contractService;

        public RevenueController(IContractService contractService)
        {
            _contractService = contractService;
        }

        [HttpGet("current")]
        public async Task<IActionResult> GetCurrentRevenue()
        {
            var revenue = await _contractService.CalculateCurrentRevenue();
            return Ok(revenue);
        }

        [HttpGet("expected")]
        public async Task<IActionResult> GetExpectedRevenue()
        {
            var revenue = await _contractService.CalculateExpectedRevenue();
            return Ok(revenue);
        }

        [HttpGet("current/{productId}")]
        public async Task<IActionResult> GetCurrentRevenueForProduct(int productId)
        {
            var revenue = await _contractService.CalculateRevenueForProduct(productId);
            return Ok(revenue);
        }

        [HttpGet("expected/{productId}")]
        public async Task<IActionResult> GetExpectedRevenueForProduct(int productId)
        {
            var revenue = await _contractService.CalculateExpectedRevenueForProduct(productId);
            return Ok(revenue);
        }

    }
}
