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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.NoAction;
            }

            modelBuilder.Entity<CarExtra>()
                .HasOne(ce => ce.Car)
                .WithMany(c => c.CarExtras)
                .HasForeignKey(ce => ce.CarId)
                .OnDelete(DeleteBehavior.NoAction);


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
                SaveChanges(); 
            }

            if (!Users.Any())
            {
                Users.Add(new User 
                {
                    Username = "john_doe",
                    Email = "john.doe@example.com",
                    PasswordHash = "Nhph1n5BII0eeM4At+y8QaOUiKPwVZyNK8tMQKMfon4/vkd0wNLzU8XGK5Qe58KXmwVitm+H2VKxTFFJbmrIBw==",  // Example password hash (this should be created securely)
                    LicenseNumber = "A123456789",  // Optional, can be null if not required
                    ModifiedOn = DateTime.Now,
                    Salt = "kE6Bm59ysBjmEybDj8KwXg==",  // This should be a randomly generated salt for password hashing
                    ProfilePictureFilePath = "blank-profile-picture.jpg"
                });
                SaveChanges();
            }
            if (!Cars.Any())
            {
                Cars.Add(new Car
                {
                    Brand = "Audi",
                    Model = "A5",
                    FirstRegistration = DateTime.Now,
                    Mileage = 500,
                    Fuel = "Gasoline",
                    EngineSize = 3000,
                    HP = 250,
                    Gearbox = "automatic",
                    NumOfSeats = 5,
                    NumOfDoors = "4/5",
                    Color = "WHITE",
                    VIN = "5GAKRDED0CJ396612",
                    Status = "AVAILABLE",
                    CarDescription = "White Audi A5 with 250 horse power.",
                    PricePerDay = 80,
                    ViewCount = 0,
                    CarPictures = new List<CarPicture> {
                        new CarPicture{ PictureURL = "AudiA5.jpg", CarId = 1 },
                        new CarPicture{ PictureURL = "AudiA52.jpg", CarId = 1 },
                        new CarPicture{ PictureURL = "AudiA53.jpg" , CarId = 1},
                        new CarPicture{ PictureURL = "AudiA54.jpg" , CarId = 1},
                    },
                    CarExtras = new List<CarExtra> {
                        new CarExtra{ ExtraName = "Head Up", CarId = 1},
                        new CarExtra{ ExtraName = "Memory Seats", CarId = 1},
                        new CarExtra{ ExtraName = "Sunroof", CarId = 1},
                        new CarExtra{ ExtraName = "Carbon steering wheel", CarId = 1},
                    }
                });

                Cars.Add(new Car
                {
                    Brand = "Audi",
                    Model = "Q7",
                    FirstRegistration = DateTime.Now,
                    Mileage = 500,
                    Fuel = "Gasoline",
                    EngineSize = 3000,
                    HP = 350,
                    Gearbox = "automatic",
                    NumOfSeats = 5,
                    NumOfDoors = "4/5",
                    Color = "BLUE",
                    VIN = "JH4DB1640MS004246",
                    Status = "AVAILABLE",
                    CarDescription = "Blue Audi Q7 with 350 horse power.",
                    PricePerDay = 130,
                    ViewCount = 0,
                    CarPictures = new List<CarPicture> {
                        new CarPicture{ PictureURL = "AudiQ7.jpg", CarId = 2 },
                        new CarPicture{ PictureURL = "AudiQ72.jpg", CarId = 2 },
                        new CarPicture{ PictureURL = "AudiQ73.jpg" , CarId = 2},
                        new CarPicture{ PictureURL = "AudiQ74.jpg" , CarId = 2},
                    },
                    CarExtras = new List<CarExtra> {
                        new CarExtra{ ExtraName = "Head Up", CarId = 2},
                        new CarExtra{ ExtraName = "Memory Seats", CarId = 2},
                        new CarExtra{ ExtraName = "Sunroof", CarId = 2},
                        new CarExtra{ ExtraName = "4x4", CarId = 2},
                    }
                });

                Cars.Add(new Car
                {
                    Brand = "BMW",
                    Model = "330",
                    FirstRegistration = DateTime.Now,
                    Mileage = 5050,
                    Fuel = "Gasoline",
                    EngineSize = 3000,
                    HP = 270,
                    Gearbox = "automatic",
                    NumOfSeats = 5,
                    NumOfDoors = "4/5",
                    Color = "BLUE",
                    VIN = "4T1BG22K8VU176482",
                    Status = "AVAILABLE",
                    CarDescription = "Blue BMW 330 with 270 horse power.",
                    PricePerDay = 90,
                    ViewCount = 0,
                    CarPictures = new List<CarPicture> {
                        new CarPicture{ PictureURL = "BMW330.jpg", CarId = 3 },
                        new CarPicture{ PictureURL = "BMW3302.jpg", CarId = 3 },
                        new CarPicture{ PictureURL = "BMW3303.jpg" , CarId = 3},
                        new CarPicture{ PictureURL = "BMW3304.jpg" , CarId = 3},
                    },
                    CarExtras = new List<CarExtra> {
                        new CarExtra{ ExtraName = "Head Up", CarId = 3},
                        new CarExtra{ ExtraName = "Memory Seats", CarId = 3},
                        new CarExtra{ ExtraName = "Sunroof", CarId = 3},
                        new CarExtra{ ExtraName = "Carbon steering wheel", CarId = 3},
                    }
                });

                Cars.Add(new Car
                {
                    Brand = "BMW",
                    Model = "X5",
                    FirstRegistration = DateTime.Now,
                    Mileage = 5050,
                    Fuel = "Gasoline",
                    EngineSize = 3000,
                    HP = 410,
                    Gearbox = "automatic",
                    NumOfSeats = 5,
                    NumOfDoors = "4/5",
                    Color = "BLACK",
                    VIN = "1FVACWCSX4HM74500",
                    Status = "AVAILABLE",
                    CarDescription = "Black BMW X5 with 410 horse power.",
                    PricePerDay = 180,
                    ViewCount = 0,
                    CarPictures = new List<CarPicture> {
                        new CarPicture{ PictureURL = "BMWX5.jpg", CarId = 4 },
                        new CarPicture{ PictureURL = "BMWX52.jpg", CarId = 4 },
                        new CarPicture{ PictureURL = "BMWX53.jpg" , CarId = 4},
                        new CarPicture{ PictureURL = "BMWX54.jpg" , CarId = 4},
                    },
                    CarExtras = new List<CarExtra> {
                        new CarExtra{ ExtraName = "Head Up", CarId = 4},
                        new CarExtra{ ExtraName = "Memory Seats", CarId = 4},
                        new CarExtra{ ExtraName = "Sunroof", CarId = 4},
                        new CarExtra{ ExtraName = "Carbon steering wheel", CarId = 4},
                    }
                });
                SaveChanges();
            }

            if (!News.Any())
            {
                News.Add(new News
                {
                    Title = "Tesla Model Y Breaks Sales Records",
                    Author = "Jane Doe",
                    DatePosted = DateTime.Now,
                    NewsDescription = "Tesla’s Model Y has taken the electric vehicle market by storm, achieving record sales in multiple countries. Known for its efficiency, performance, and advanced tech, the Model Y is now one of the best-selling electric vehicles worldwide.",
                    ImageURL = "TeslaYNews.jpg",
                    ShortIntro = "Tesla Model Y hits record-breaking sales worldwide, reshaping the EV landscape.",
                    Comments = new HashSet<Comment>
                    {
                        new Comment { Content = "Amazing! Tesla is unstoppable!", CommentDate = DateTime.Now },
                        new Comment {  Content = "Can't wait to see the future of EVs.", CommentDate = DateTime.Now }
                    }
                });

                News.Add(new News
                {
                    Title = "Jeep Grand Cherokee 2024 Launches with Upgraded Features",
                    Author = "John Smith",
                    DatePosted = DateTime.Now,
                    NewsDescription = "The new 2024 Jeep Grand Cherokee is here, boasting advanced off-road capabilities and a refined interior. With enhanced safety features and an eco-friendly hybrid option, this SUV is ready to conquer both city streets and rugged terrains.",
                    ImageURL = "JeepGrandCherokee.jpg",
                    ShortIntro = "Jeep Grand Cherokee 2024 debuts with upgraded features and hybrid options.",
                    Comments = new HashSet<Comment>
                    {
                        new Comment {Content = "This is a game-changer for Jeep lovers!", CommentDate = DateTime.Now },
                        new Comment { Content = "The perfect balance of luxury and power.", CommentDate = DateTime.Now }
                    }
                });

                News.Add(new News
                {
                    Title = "Ford Unveils the New F-150 Lightning",
                    Author = "Alex Johnson",
                    DatePosted = DateTime.Now,
                    NewsDescription = "Ford’s all-electric F-150 Lightning has finally arrived, featuring impressive towing capabilities and range. This electric pickup is designed for both work and adventure, with sustainable power and a durable build that Ford fans are excited about.",
                    ImageURL = "FordNews.jpg",
                    ShortIntro = "Ford introduces the F-150 Lightning, an electric pickup for the future.",
                    Comments = new HashSet<Comment>
                    {
                        new Comment {  Content = "Ford is leading the way with electric trucks!", CommentDate = DateTime.Now },
                        new Comment {  Content = "This is what the EV industry needed.", CommentDate = DateTime.Now }
                    }
                });

                News.Add(new News
                {
                    Title = "BMW iX - The Future of Electric Luxury SUVs",
                    Author = "Emily Brown",
                    DatePosted = DateTime.Now,
                    NewsDescription = "BMW’s latest addition, the iX, is a fully electric luxury SUV that combines performance with sustainability. Equipped with a spacious interior and cutting-edge technology, the iX represents BMW’s commitment to a greener, high-performance future.",
                    ImageURL = "BMWIX.jpg",
                    ShortIntro = "BMW iX redefines luxury with a fully electric, eco-conscious design.",
                    Comments = new HashSet<Comment>
                    {
                        new Comment {  Content = "BMW continues to set the bar for luxury EVs!", CommentDate = DateTime.Now },
                        new Comment {  Content = "The perfect SUV for the modern driver.", CommentDate = DateTime.Now }
                    }
                });

                SaveChanges();
            }
        }

    }
}