using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class RentACarDTO
    {
        public int Id { get; set; } 
        public UserDTO user { get; set; }
        public CarDTO car { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string status { get; set; }
    }
}
