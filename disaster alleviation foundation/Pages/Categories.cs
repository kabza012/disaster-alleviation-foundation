using System.ComponentModel.DataAnnotations;

namespace disaster_alleviation_foundation.Pages
{
    public class Categories
    {
       [Key] public string Name { get; set; } // The name of the category
        public string Description { get; set; }
    }
}
