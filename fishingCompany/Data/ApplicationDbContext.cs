using fishingCompany.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace fishingCompany.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
            public DbSet<Boat> boats {get; set;}
            public DbSet<Catch> catches {get; set;}
            public DbSet<Fisherman> fishermen {get; set;}
            public DbSet<FishingTrip> fishingTrips {get; set;}
            public DbSet<Sale> sales {get; set;}

              protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // This ensures Identity-related configurations are applied

            // Ensure that the TeacherID foreign key is mapped correctly to the AspNetUsers tabl


            // Primary Key Configuration for CompetitiveRoom
            modelBuilder.Entity<FishingTrip>()
                .HasKey(ft => ft.TripID);  // Ensure the primary key is correctly recognized

    }
}

}