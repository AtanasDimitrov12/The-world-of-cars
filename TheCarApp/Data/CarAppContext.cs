using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class CarAppContext : DbContext
    {
        // DbSets for each entity representing the tables in the database
        public DbSet<Car> Cars { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CarExtra> CarExtras { get; set; }
        public DbSet<CarPicture> CarPictures { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<News> News { get; set; }


        public CarAppContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Use your connection string here
            if (!optionsBuilder.IsConfigured)
            { 
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API can be used here if needed for relationships or configurations
            base.OnModelCreating(modelBuilder);
        }
    }
}
