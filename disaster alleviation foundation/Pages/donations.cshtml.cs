
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using disaster_alleviation_foundation.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace disaster_alleviation_foundation.Pages
{
    public class donationsModel : PageModel
    {


        private readonly disaster_alleviation_foundation.Data.ApplicationDbContext _dbContext;

        public donationsModel(disaster_alleviation_foundation.Data.ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //[Table("DjPromoWebsite")]
        //public class Donations
        //{
        //    [Key] public int Id { get; set; }
        //    public decimal Amount { get; set; }
        //    public DateTime DonationDate { get; set; }
        //    public bool IsAnonymous { get; set; }
        //    // Other properties and relationships
        //}

        //public IActionResult OnGet()
        //{
        //    return Page();// Initialize any necessary data
        //}

        [BindProperty]
        public Donations donations { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid || _dbContext.donations == null || donations == null)
            {
                return Page();

            }
            _dbContext.donations.Add(donations);
            await _dbContext.SaveChangesAsync();
            return RedirectToPage("./Don");
        }


        public IList<Donations> donation { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_dbContext.donations != null)
            {
                donation = await _dbContext.donations.ToListAsync();
            }
        }

    }
}

    

