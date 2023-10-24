using disaster_alleviation_foundation.Data;
using disaster_alleviation_foundation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace disaster_alleviation_foundation.Pages
{
    public class AllocateMoneyModel : PageModel
    {
        private readonly disaster_alleviation_foundation.Data.ApplicationDbContext _dbContext;

        public AllocateMoneyModel(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        [BindProperty]
        public decimal Amount { get; set; }

        public IActionResult OnPost()
        {
            // Validate user authorization and input data...

            // Retrieve the active disaster based on your business logic.
            var Disasters = _dbContext.allocations.AsEnumerable().FirstOrDefault(d => d.IsActive);

            if (Disasters == null)
            {
                TempData["ErrorMessage"] = "No active disaster found.";
                return RedirectToPage("/Aloc"); // Redirect another page
            }

            // Create a new money allocation entry.
            var moneyAllocation = new Allocations
            {
                DisasterId = Disasters.Id,
                Amount = Amount,
                // Other properties...
            };

            _dbContext.allocations.Add(moneyAllocation);
            _dbContext.SaveChanges();

            TempData["SuccessMessage"] = "Money allocated successfully.";
            return RedirectToPage("/Aloc"); // Redirect to another page
        }
    }
}

