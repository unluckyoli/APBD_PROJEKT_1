using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System_Uznawania_Przychodów_dla_dużej_korporacji_ABC.Models;


namespace System_Uznawania_Przychodów_dla_dużej_korporacji_ABC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ContractsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ContractsController(DatabaseContext context)
        {
            _context = context;
        }
        
        [HttpPost]
        public async Task<IActionResult> AddContract([FromBody] SoftwareContract contract)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if ((contract.EndDate - contract.StartDate).Days < 3 || (contract.EndDate - contract.StartDate).Days > 30)
            {
                return BadRequest("Contract duration must be between 3 and 30 days.");
            }
            
            contract.Software = await _context.SoftwareLicenses.FindAsync(contract.SoftwareId);
            contract.Client = await _context.Clients.FindAsync(contract.ClientId);

            if (contract.Software == null)
            {
                return BadRequest("Invalid SoftwareId.");
            }

            if (contract.Client == null)
            {
                return BadRequest("Invalid ClientId.");
            }

            foreach (var discount in contract.Discounts)
            {
                discount.Product = await _context.SoftwareLicenses.FindAsync(discount.ProductId);
                if (discount.Product == null)
                {
                    return BadRequest($"Invalid ProductId in discount with Id {discount.Id}.");
                }
            }

            contract.Price = CalculateTotalPrice(contract);

            _context.Contracts.Add(contract);
            await _context.SaveChangesAsync();

            return Ok(contract);
        }


        
        [HttpPost("{id}/payment")]
        public async Task<IActionResult> AddPayment(int id, [FromBody] Payment payment)
        {
            var contract = await _context.Contracts.FindAsync(id);
            if (contract == null)
            {
                return NotFound("Contract not found");
            }

            payment.ContractId = id;
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();

            return Ok(payment);
        }

        private decimal CalculateTotalPrice(SoftwareContract contract)
        {
            var basePrice = contract.Software.Price;
            var discountAmount = contract.Discounts.Sum(d => d.Percentage);

            var finalPrice = basePrice * (1 - discountAmount / 100);

            var yearsOfSupport = (contract.EndDate.Year - contract.StartDate.Year);
            finalPrice += yearsOfSupport * 1000;

            return finalPrice;
        }

    }
}
