using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace disaster_alleviation_foundation.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly disaster_alleviation_foundation.Data.ApplicationDbContext _dbContext;

        public RegisterModel(disaster_alleviation_foundation.Data.ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
