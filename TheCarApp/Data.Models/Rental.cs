using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Rental
    {
        [Key]
        public int RentalId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [MaxLength(20)]
        public string Status { get; set; }

        // Foreign Key to User
        public int UserId { get; set; }
        public User User { get; set; }

        // Foreign Key to Car
        public int CarId { get; set; }
        public Car Car { get; set; }
    }

}
