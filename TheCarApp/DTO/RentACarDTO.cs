
namespace DTO
{
    public class RentACarDTO
    {
        public int RentalId { get; set; } 
        public int UserId { get; set; }
        public int CarId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public decimal TotalPrice { get; set; } //Add logic to fill that property
    }
}
