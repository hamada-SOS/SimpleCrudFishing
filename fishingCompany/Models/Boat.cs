using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace fishingCompany.Models
{
    public class Boat
    {
        public int BoatID { get; set; }
        public string Name { get; set; } = string.Empty;

        
        public float Capacity { get; set; } // Assuming capacity is in tons
        [MaxLength(255)]
        public string Status { get; set; } = "Active"; // Default status
    }
}