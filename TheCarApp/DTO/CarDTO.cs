using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CarDTO
    {
        public int Id { get; set; } 
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime FirstRegistration { get; set; }
        public int Mileage { get; set; }
        public string Fuel { get; set; }
        public int EngineSize { get; set; }
        public int HP { get; set; }
        public string Gearbox { get; set; }
        public int NumOfSeats { get; set; }
        public string NumOfDoors { get; set; }
        public string Color { get; set; }
        public string VIN { get; set; }
        public string Description { get; set; }
        public decimal PricePerDay { get; set; }
        public List<PictureDTO> Pictures { get; set; }
        public List<ExtraDTO> CarExtras { get; set; }
        public string Status { get; set; }
        public int ViewCount { get; set; }

    }
}
