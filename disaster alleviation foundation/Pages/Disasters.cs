using System.ComponentModel.DataAnnotations;

namespace disaster_alleviation_foundation.Pages
{
    public class Disasters
    {
        [Key]public int DisasterId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
         public string Location { get; set; }
        public string Description { get; set; }
       
        // Other properties and relationships
    }
}
