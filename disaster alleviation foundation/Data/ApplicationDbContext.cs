using disaster_alleviation_foundation.Pages;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;


namespace disaster_alleviation_foundation.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) { }

        public DbSet<disaster_alleviation_foundation.Pages.Donations> donations { get; set; }
     
        public DbSet<Disasters> disasters { get; set; }

        public DbSet<Categories> categories { get; set; }
        public DbSet<disaster_alleviation_foundation.Models.Allocations> allocations { get; set; }

        public DbSet<Captures> captures { get; set; }


    }
}
