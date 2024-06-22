using Database;
using DatabaseAccess;
using DTO;
using Entity_Layer.Enums;
using EntityLayout;
using InterfaceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using Entity_Layer.Interfaces;
using Manager_Layer;

namespace Entity_Layer
{
    public class RentManager : IRentManager
    {
        public List<RentACar> RentalHistory { get; set; }
        private readonly IDataAccess _dataAccess;
        private readonly IPeopleDataWriter _dataWriter;
        private readonly IPeopleDataRemover _dataRemover;
        private readonly IPeopleManager _peopleManager;
        private readonly ICarManager _carManager;
        private readonly IRentalStrategyFactory _rentalStrategyFactory;

        public RentManager(IDataAccess dataAccess, IPeopleDataWriter dataWriter, IPeopleDataRemover dataRemover, IPeopleManager peopleManager, ICarManager carManager, IRentalStrategyFactory rentalStrategyFactory)
        {
            RentalHistory = new List<RentACar>();
            _dataAccess = dataAccess;
            _dataWriter = dataWriter;
            _dataRemover = dataRemover;
            _peopleManager = peopleManager;
            _carManager = carManager;
            _rentalStrategyFactory = rentalStrategyFactory;
        }

        public decimal CalculatePrice(User user, decimal basePrice, DateTime startDate, DateTime endDate)
        {
            int days = (endDate - startDate).Days;
            int discount = CheckForDiscount(user);
            var strategy = _rentalStrategyFactory.GetRentalStrategy(startDate, endDate);
            return strategy.CalculateRentalPrice(basePrice, days, discount);
        }

        public int CheckForDiscount(User user)
        { 

            int numOfRents = RentalHistory.Count(r => r.user == user && r.RentStatus != RentStatus.CANCELLED);
            if (numOfRents >= 25) return 10;
            if (numOfRents >= 10) return 5;
            return 0;
        }

        public bool RentACar(RentACar rentACar, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                _dataWriter.RentACar(rentACar.car.Id, rentACar.user.Id, rentACar.StartDate, rentACar.ReturnDate, rentACar.RentStatus.ToString());
                RentalHistory.Add(rentACar);
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public bool UpdateRentStatus(RentACar rental, RentStatus newStatus, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                var strategy = _rentalStrategyFactory.GetRentalStrategy(rental.StartDate, rental.ReturnDate);
                strategy.UpdateRentalStatus(rental, newStatus);
                _dataWriter.UpdateRent(rental);
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public bool RemoveRent(RentACar rental, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                _dataRemover.RemoveRental(rental);
                RentalHistory.Remove(rental);
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;




            }
        }

        public List<RentACar> GetRentedPeriods(int carId)
        {
            return RentalHistory
                .Where(r => r.car.Id == carId && r.RentStatus != RentStatus.CANCELLED)
                .ToList();
        }

        public bool IsCarAvailable(int carId, DateTime startDate, DateTime endDate)
        {
            return RentalHistory
                .Where(r => r.car.Id == carId)
                .All(r => startDate >= r.ReturnDate || endDate <= r.StartDate);
        }

        public bool LoadRentals(out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                var loadedRentals = _dataAccess.GetRentals();
                if (loadedRentals == null)
                {
                    errorMessage = "No rentals to load.";
                    return false;
                }

                foreach (var rentDTO in loadedRentals)
                {
                    if (rentDTO == null) continue;

                    if (!Enum.TryParse(rentDTO.Status.ToUpper(), true, out RentStatus status))
                    {
                        errorMessage = $"Warning: {rentDTO.Id} has an invalid status assigned.";
                        return false;
                    }

                    var user = _peopleManager.GetAllUsers().FirstOrDefault(u => u.Id == rentDTO.UserID);
                    if (user == null) continue;

                    var car = _carManager.GetCars().FirstOrDefault(c => c.Id == rentDTO.CarId);
                    if (car == null) continue;

                    if (rentDTO.ReturnDate < DateTime.Now) status = RentStatus.COMPLETED;

                    var rental = new RentACar(user, car, rentDTO.StartDate, rentDTO.ReturnDate, status)
                    {
                        TotalPrice = CalculatePrice(user, car.PricePerDay, rentDTO.StartDate, rentDTO.ReturnDate)
                    };
                    RentalHistory.Add(rental);
                }

                return true;
            }
            catch (Exception ex)
            {
                errorMessage = $"Error: {ex.Message}";
                return false;
            }
        }
    }
}
