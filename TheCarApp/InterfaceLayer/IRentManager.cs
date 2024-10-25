using DTO.Enums;
using DTO;

namespace InterfaceLayer
{
    public interface IRentManager
    {
        List<RentACarDTO> RentalHistory { get; set; }
        decimal CalculatePrice(UserDTO user, decimal basePrice, DateTime startDate, DateTime endDate);
        int CheckForDiscount(UserDTO user);
        Task<(bool Success, string ErrorMessage)> RentACarAsync(RentACarDTO rentDTO);
        Task<(bool Success, string ErrorMessage)> UpdateRentStatusAsync(RentACarDTO rentalDTO, RentStatus newStatus);
        Task<(bool Success, string ErrorMessage)> RemoveRentAsync(RentACarDTO rentalDTO);
        Task<(bool Success, string ErrorMessage)> LoadRentalsAsync();
        List<RentACarDTO> GetRentedPeriods(int carId);
        bool IsCarAvailable(int carId, DateTime startDate, DateTime endDate);
    }
}
