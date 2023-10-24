using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace disaster_alleviation_foundation.Pages
{
    
    public class Donations
    {
     
        [Key] public double Amount { get; set; }
        public DateTime DonationDate { get; set; }
    
        // Other properties and relationships
    }
}
