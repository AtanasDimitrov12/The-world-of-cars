using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Data.Models
{
    public class CarExtra
    {
        [Key]
        public int CarExtraId { get; set; }

        [Required]
        [MaxLength(50)]
        public string ExtraName { get; set; }

        // Foreign Key to Car
        [ForeignKey("Car")]
        public int? CarId { get; set; } // Ensure only one CarId is defined
        public virtual Car Car { get; set; }
    }
}
