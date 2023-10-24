using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace disaster_alleviation_foundation.Pages
{
    public class DisasterModel : PageModel
    {
        private readonly disaster_alleviation_foundation.Data.ApplicationDbContext _dbContext;

        public DisasterModel(disaster_alleviation_foundation.Data.ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }



        [BindProperty]
        public Disasters disasters { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid || _dbContext.disasters == null || disasters == null)
            {
                return Page();

            }
            _dbContext.disasters.Add(disasters);
            await _dbContext.SaveChangesAsync();
            return RedirectToPage("./Dis");
        }


        public IList<Disasters> disaster { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_dbContext.disasters != null)
            {
                disaster = await _dbContext.disasters.ToListAsync();
            }
        }
    }
}
