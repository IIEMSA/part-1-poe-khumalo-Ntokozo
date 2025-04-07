using Microsoft.Extensions.Logging;

namespace POEPart1WebApplication.Models
{
    public class Venue
    {
        public int VenueId { get; set; }
        public string VenueName { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public string? ImageUrl { get; set; } = "https://via.placeholder.com/300";

        // Navigation Property - A venue can have multiple events
        public ICollection<Events>? Eventss { get; set; }
    }
}
