using POEPart1WebApplication.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace POEPart1WebApplication.Models
{
    public class Booking
    {
        public int BookingId { get; set; }

        [ForeignKey("Event")]
        public int EventId { get; set; }
        public Events Event { get; set; }

        [ForeignKey("Venue")]
        public int VenueId { get; set; }
        public Venue Venue { get; set; }

        public DateTime BookingDate { get; set; } = DateTime.Now;
    }
}
