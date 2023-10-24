namespace disaster_alleviation_foundation.Models
{
    public class Allocations
    {
        internal bool IsActive;

        public int Id { get; set; }
        public int DisasterId { get; set; }
        public decimal Amount { get; set; }
        public string goods { get; internal set; }
    }
}
