using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POEPart1WebApplication.Models
{
    public class Events
    {
        [Key]  // Marks EventId as the Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-increment
        public int EventId { get; set; }

        [Required]  // Ensures EventName is not null
        public string EventName { get; set; } = string.Empty;

        [Required]
        public DateTime EventDate { get; set; }

        public string? Description { get; set; }

        // Foreign Key for Venue
        public int? VenueId { get; set; }
        public Venue? Venue { get; set; } // Navigation Property

        public ICollection<Booking>? Bookings { get; set; } // Navigation Property
    }
}