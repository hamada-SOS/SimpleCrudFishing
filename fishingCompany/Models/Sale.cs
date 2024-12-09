using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace fishingCompany.Models
{
    public class Sale
    {
        public int SaleID { get; set; }
        public int CatchID { get; set; }
        public Catch? Catch { get; set; } // Navigation property
        public string MarketName { get; set; } = string.Empty;
        public DateTime SaleDate { get; set; }
        [Precision(18, 2)]
        public decimal SalePrice { get; set; }
    }
}