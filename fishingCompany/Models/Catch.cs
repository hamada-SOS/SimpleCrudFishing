using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fishingCompany.Models
{
    public class Catch
    {
        public int CatchID { get; set; }
        public int TripID { get; set; }
        public FishingTrip? FishingTrip { get; set; } // Navigation property
        public string FishType { get; set; } = string.Empty;
        public double Weight { get; set; }
    }
}