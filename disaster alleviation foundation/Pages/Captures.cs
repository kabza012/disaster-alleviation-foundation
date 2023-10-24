using System.ComponentModel.DataAnnotations;

namespace disaster_alleviation_foundation.Pages
{
    public class Captures
    {

        [Key]public decimal amount { get; set; } // The name of the category
        public string goods { get; set; }
    }
}
