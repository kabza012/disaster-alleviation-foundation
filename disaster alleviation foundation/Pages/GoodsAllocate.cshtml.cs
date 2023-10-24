using disaster_alleviation_foundation.Data;
using disaster_alleviation_foundation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace disaster_alleviation_foundation.Pages
{
    public class GoodsAllocateModel : PageModel
    {
        private readonly disaster_alleviation_foundation.Data.ApplicationDbContext _dbContext;

        public GoodsAllocateModel(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        [BindProperty]
        public string goods { get; set; }

        public IActionResult OnPost()
        {
            // Validate user authorization and input data...

            // Retrieve the active disaster based on your business logic.
            var Disasters = _dbContext.allocations.AsEnumerable().FirstOrDefault(d => d.IsActive);

            if (Disasters == null)
            {
                TempData["ErrorMessage"] = "No active disaster found.";
                return RedirectToPage("/god"); // Redirect another page
            }

            // Create a new money allocation entry.
            var moneyAllocation = new Allocations
            {
                DisasterId = Disasters.Id,
                goods = goods,
                // Other properties...
            };

            _dbContext.allocations.Add(moneyAllocation);
            _dbContext.SaveChanges();

            TempData["SuccessMessage"] = "Money allocated successfully.";
            return RedirectToPage("/god"); // Redirect to another page
        }
    }
}
