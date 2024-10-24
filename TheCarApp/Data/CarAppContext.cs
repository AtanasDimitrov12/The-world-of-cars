using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class CarAppContext : DbContext
    {
        // DbSets for each entity representing the tables in the database
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<CarPicture> CarPictures { get; set; }
        public DbSet<CarExtra> CarExtras { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Comment> Comments { get; set; }


        public CarAppContext() { }

        public CarAppContext(DbContextOptions<CarAppContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Use your connection string here
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        public void ApplyMigrations()
        {
            // Apply any pending migrations
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Configure one-to-many relationship between CarExtra and Car
            modelBuilder.Entity<CarExtra>()
                .HasOne(ce => ce.Car)
                .WithMany(c => c.CarExtras)
                .HasForeignKey(ce => ce.CarId)
                .OnDelete(DeleteBehavior.NoAction);  // Set to restrict to prevent cascading delete conflicts

            // Other relationships, for example:
            modelBuilder.Entity<CarPicture>()
                .HasOne(cp => cp.Car)
                .WithMany(c => c.CarPictures)
                .HasForeignKey(cp => cp.CarId)
                .OnDelete(DeleteBehavior.Restrict);  // Avoid cascading deletes here as well

            modelBuilder.Entity<Rental>()
                .HasOne(r => r.Car)
                .WithMany(c => c.Rentals)
                .HasForeignKey(r => r.CarId)
                .OnDelete(DeleteBehavior.Restrict);  // Avoid cascading deletes here

            modelBuilder.Entity<Car>()
                .Property(c => c.PricePerDay)
                .HasColumnType("decimal(18,4)");

            base.OnModelCreating(modelBuilder);
        }

        public void SeedAdminIfTableIsEmpty()
        {
            if (!Administrators.Any())
            {
                Administrators.Add(new Administrator
                {
                    Id = 1,
                    Username = "admin",
                    Email = "admin@carapp.com",
                    PasswordHash = "7WnVgml5tdLm6Z/6LEV4O3nvVulIoAhafcARLgYcRM1KQ0MWpQ6iFqycYkvKs9Sj6KfR324fjn4BTjxU6scOsQ==",
                    ModifiedOn = DateTime.Now,
                    Salt = "F/j+jlsaXAVJnFzUwVeEKg==",
                    PhoneNumber = "123456789"
                });
                SaveChanges(); // Save the new admin to the database
            }
        }

    }
}