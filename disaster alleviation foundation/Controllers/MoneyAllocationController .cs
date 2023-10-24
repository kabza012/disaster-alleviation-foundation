using disaster_alleviation_foundation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace disaster_alleviation_foundation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoneyAllocationController : ControllerBase
    {
        
        private readonly disaster_alleviation_foundation.Data.ApplicationDbContext _dbContext;

        public MoneyAllocationController(disaster_alleviation_foundation.Data.ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost("allocate-money")]
        public IActionResult AllocateMoney([FromBody] MoneyAllocationRequestModel model)
        {
            // Validate model and user authorization...

            // Retrieve the active disaster based on your business logic.
            var activeDisaster = _dbContext.allocations.AsEnumerable().FirstOrDefault(d => d.IsActive);

            if (activeDisaster == null)
            {
                return BadRequest("No active disaster found.");
            }

            // Create a new money allocation entry.
            var moneyAllocation = new Allocations
            {
                DisasterId = activeDisaster.Id,
                Amount = model.Amount,
                // Other properties...
            };

            _dbContext.allocations.Add(moneyAllocation);
            _dbContext.SaveChanges();

            return Ok("Money allocated successfully.");
        }
    }
}

