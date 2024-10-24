using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int CarId { get; set; } // Ensure only one CarId is defined
        public Car Car { get; set; }
    }
}
