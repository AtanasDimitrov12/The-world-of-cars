using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class CarPicture
    {
        [Key]
        public int PictureId { get; set; }

        [Required]
        public string PictureURL { get; set; }

        // Foreign Key to Car
        public int CarId { get; set; }
        public Car Car { get; set; }
    }

}
