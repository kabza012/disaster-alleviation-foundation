using System.ComponentModel.DataAnnotations;

namespace disaster_alleviation_foundation.Pages
{
    public class register
    {
        [Key] public string Password { get; set; }
        public string Username { get; set; }

        public string Email { get; set; }

    }
}
