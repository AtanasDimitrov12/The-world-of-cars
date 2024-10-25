using AutoMapper;
using Data.Models;
using DTO;
using DTO.Enums;
using InterfaceLayer;
using Manager_Layer;

namespace ManagerLayer
{
    public class RentManager : IRentManager
    {
        public List<RentACarDTO> RentalHistory { get; set; }
        private readonly IDataAccess _dataAccess;
        private readonly IPeopleDataWriter _dataWriter;
        private readonly IPeopleDataRemover _dataRemover;
        private readonly IPeopleManager _peopleManager;
        private readonly ICarManager _carManager;
        private readonly IRentalStrategyFactory _rentalStrategyFactory;
        private readonly IMapper _mapper;

        public RentManager(IDataAccess dataAccess, IPeopleDataWriter dataWriter, IPeopleDataRemover dataRemover, IPeopleManager peopleManager, ICarManager carManager, IRentalStrategyFactory rentalStrategyFactory, IMapper mapper)
        {
            RentalHistory = new List<RentACarDTO>();
            _dataAccess = dataAccess;
            _dataWriter = dataWriter;
            _dataRemover = dataRemover;
            _peopleManager = peopleManager;
            _carManager = carManager;
            _rentalStrategyFactory = rentalStrategyFactory;
            _mapper = mapper;
        }

        public decimal CalculatePrice(UserDTO user, decimal basePrice, DateTime startDate, DateTime endDate)
        {
            int days = (endDate - startDate).Days;
            int discount = CheckForDiscount(user);
            var strategy = _rentalStrategyFactory.GetRentalStrategy(startDate, endDate);
            return strategy.CalculateRentalPrice(basePrice, days, discount);
        }

        public int CheckForDiscount(UserDTO user)
        {
            int numOfRents = RentalHistory.Count(r => r.UserId == user.Id && r.Status != RentStatus.CANCELLED.ToString());
            if (numOfRents >= 25) return 10;
            if (numOfRents >= 10) return 5;
            return 0;
        }

        public async Task<(bool Success, string ErrorMessage)> RentACarAsync(RentACarDTO rentDTO)
        {
            try
            {
                var rental = _mapper.Map<Rental>(rentDTO);
                await _dataWriter.RentACarAsync(rental);

                // Add to RentalHistory DTO list
                RentalHistory.Add(rentDTO);
                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<(bool Success, string ErrorMessage)> UpdateRentStatusAsync(RentACarDTO rentalDTO, RentStatus newStatus)
        {
            try
            {
                var strategy = _rentalStrategyFactory.GetRentalStrategy(rentalDTO.StartDate, rentalDTO.EndDate);
                strategy.UpdateRentalStatus(rentalDTO, newStatus);

                var rental = _mapper.Map<Rental>(rentalDTO);
                await _dataWriter.UpdateRentAsync(rental);

                // Update the DTO status in RentalHistory
                rentalDTO.Status = newStatus.ToString();
                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<(bool Success, string ErrorMessage)> RemoveRentAsync(RentACarDTO rentalDTO)
        {
            try
            {
                var rental = _mapper.Map<Rental>(rentalDTO);
                await _dataRemover.RemoveRentalAsync(rental);
                RentalHistory.Remove(rentalDTO);
                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<(bool Success, string ErrorMessage)> LoadRentalsAsync()
        {
            try
            {
                var loadedRentals = await _dataAccess.GetRentalsAsync();
                if (loadedRentals == null)
                {
                    return (false, "No rentals to load.");
                }

                foreach (var rents in loadedRentals)
                {
                    if (rents == null) continue;

                    

                    var user = _peopleManager.GetAllUsers().FirstOrDefault(u => u.Id == rents.UserId);
                    if (user == null) continue;

                    var car = _carManager.GetCars().FirstOrDefault(c => c.Id == rents.CarId);
                    if (car == null) continue;

                    if (rents.EndDate < DateTime.Now) rents.Status = RentStatus.COMPLETED.ToString();

                    

                    // Add to RentalHistory as DTO
                    RentalHistory.Add(_mapper.Map<RentACarDTO>(rents)); // Add custom logic for calculate total price || call the method on the top
                }

                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, $"Error: {ex.Message}");
            }
        }

        public List<RentACarDTO> GetRentedPeriods(int carId)
        {
            return RentalHistory
                .Where(r => r.CarId == carId && r.Status != RentStatus.CANCELLED.ToString())
                .ToList();
        }

        public bool IsCarAvailable(int carId, DateTime startDate, DateTime endDate)
        {
            return RentalHistory
                .Where(r => r.CarId == carId)
                .All(r => startDate >= r.EndDate || endDate <= r.StartDate);
        }
    }
}
