using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace disaster_alleviation_foundation.Pages
{
    public class CapturePurchaseModel : PageModel
    {
        private readonly disaster_alleviation_foundation.Data.ApplicationDbContext _dbContext;

        public CapturePurchaseModel(disaster_alleviation_foundation.Data.ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }



        [BindProperty]
        public Captures captures { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid || _dbContext.captures == null || captures == null)
            {
                return Page();

            }
            _dbContext.captures.Add(captures);
            await _dbContext.SaveChangesAsync();
            return RedirectToPage("./capp");
        }


        public IList<Captures> capture { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_dbContext.captures != null)
            {
                capture = await _dbContext.captures.ToListAsync();
            }
        }
    }
}
