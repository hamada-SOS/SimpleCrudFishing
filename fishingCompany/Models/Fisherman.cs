using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fishingCompany.Models
{
    public class Fisherman
    {
       public int FishermanID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime HireDate { get; set; }

    }
}