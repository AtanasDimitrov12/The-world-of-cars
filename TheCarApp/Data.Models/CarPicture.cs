using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Data.Models
{
    public class CarPicture
    {
        [Key]
        public int CarPictureId { get; set; }

        [Required]
        public string PictureURL { get; set; }

        // Foreign Key to Car
        [ForeignKey("Car")]
        public int? CarId { get; set; } // Ensure only one CarId is defined
        public virtual Car Car { get; set; }
    }

}
