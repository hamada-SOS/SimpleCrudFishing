using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fishingCompany.Models
{
    public class FishingTrip
    {
        public int TripID { get; set; }
        public int BoatID { get; set; }
        public Boat? Boat { get; set; } // Navigation property
        public DateTime TripDate { get; set; }
        public string Destination { get; set; } = string.Empty;
        public string? Status { get; set; } // Default status
    }
}