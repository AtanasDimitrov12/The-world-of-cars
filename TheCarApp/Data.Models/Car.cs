using System.ComponentModel.DataAnnotations;


namespace Data.Models
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Brand { get; set; }

        [Required]
        [MaxLength(50)]
        public string Model { get; set; }

        [Required]
        public DateTime FirstRegistration { get; set; }

        [Required]
        public int Mileage { get; set; }

        [Required]
        [MaxLength(20)]
        public string Fuel { get; set; }

        [Required]
        public int EngineSize { get; set; }

        [Required]
        public int HP { get; set; }

        [Required]
        [MaxLength(20)]
        public string Gearbox { get; set; }

        [Required]
        public int NumOfSeats { get; set; }

        [Required]
        [MaxLength(10)]
        public string NumOfDoors { get; set; }

        [Required]
        [MaxLength(20)]
        public string Color { get; set; }

        [Required]
        [MaxLength(17)]
        public string VIN { get; set; }

        [Required]
        [MaxLength(20)]
        public string Status { get; set; }

        // Combined from CarDescription table
        public string CarDescription { get; set; }

        public decimal PricePerDay { get; set; }

        // Combined from CarViews table
        public int ViewCount { get; set; }

        // Relationships
        public virtual ICollection<CarPicture> CarPictures { get; set; }
        public virtual ICollection<CarExtra> CarExtras { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }

        public Car()
        {
            CarPictures = new HashSet<CarPicture>();
            CarExtras = new HashSet<CarExtra>();
            Rentals = new HashSet<Rental>();
        }
    }

}
