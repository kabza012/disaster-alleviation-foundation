using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace disaster_alleviation_foundation.Pages
{
    public class CategoryModel : PageModel
    {
        private readonly disaster_alleviation_foundation.Data.ApplicationDbContext _dbContext;

        public CategoryModel(disaster_alleviation_foundation.Data.ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }



        [BindProperty]
        public Categories categories { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid || _dbContext.categories == null || categories == null)
            {
                return Page();

            }
            _dbContext.categories.Add(categories);
            await _dbContext.SaveChangesAsync();
            return RedirectToPage("./Cat");
        }


        public IList<Categories> category { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_dbContext.categories != null)
            {
                category = await _dbContext.categories.ToListAsync();
            }
        }
    }
}
