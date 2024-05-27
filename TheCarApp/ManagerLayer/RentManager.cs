using Database;
using DatabaseAccess;
using DTO;
using Entity_Layer;
using Entity_Layer.Enums;
using EntityLayout;
using Manager_Layer;
using Entity_Layer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLayer;
using ManagerLayer.Strategy;

namespace ManagerLayer
{
    public class RentManager : IRentManager
    {
        private IRentalStrategy _rentalStrategy;
        public List<RentACar> rentalHistory { get; set; }
        private IPeopleDataWriter writer;
        private IPeopleDataRemover remover;
        private IDataAccess access;
        private IPeopleManager peopleManager;
        private ICarManager carManager;

        public RentManager(IDataAccess dataAccess, IPeopleDataWriter dataWriter, IPeopleDataRemover dataRemover, IPeopleManager pm, ICarManager carManager)
        {
            rentalHistory = new List<RentACar>();
            writer = dataWriter;
            remover = dataRemover;
            access = dataAccess;
            peopleManager = pm;
            this.carManager = carManager;
        }




        public bool IsPeakSeason(DateTime startDate, DateTime endDate)
        {
            // Define peak season logic
            // Example: June to August is peak season
            if (startDate.Month >= 6 && startDate.Month <= 8)
            { return true; }
            else
            {
                return false;
            }
        }

        public decimal CalculatePrice(decimal BasePrice, DateTime startDate, DateTime endDate)
        {
            TimeSpan timeSpan = endDate - startDate;
            int days = (int)timeSpan.TotalDays;
            if (IsPeakSeason(startDate, endDate))
            {
                _rentalStrategy = new PeakSeasonRentalStrategy();
                return _rentalStrategy.CalculateRentalPrice(BasePrice, Convert.ToInt32(days));
            }
            else
            {
                _rentalStrategy = new StandardRentalStrategy();
                return _rentalStrategy.CalculateRentalPrice(BasePrice, Convert.ToInt32(days));
            }
        }

        public string RentACar(RentACar rentACar)
        {
            try
            {
                writer.RentACar(rentACar.car.Id, rentACar.user.Id, rentACar.StartDate, rentACar.ReturnDate, rentACar.RentStatus.ToString());


                rentalHistory.Add(rentACar);
                return "done";

            }

            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public void UpdateRental(RentACar rental, RentStatus newStatus)
        {
            _rentalStrategy.UpdateRentalStatus(rental, newStatus);
        }

        public string LoadRentals()
        {
            try
            {
                var loadedRentals = access?.GetRentals();
                if (loadedRentals == null)
                {
                    return "No rentals to load.";
                }

                foreach (var rentDTO in loadedRentals)
                {
                    if (rentDTO == null)
                    {
                        continue;
                    }

                    if (!Enum.TryParse(rentDTO.Status.ToUpper(), true, out RentStatus status))
                    {
                        return $"Warning: {rentDTO.Id} has an invalid status assigned.";
                    }

                    var user = peopleManager.GetAllUsers().FirstOrDefault(u => u.Id == rentDTO.UserID);
                    if (user == null)
                    {
                        continue;
                    }

                    var car = carManager?.GetCars()?.FirstOrDefault(c => c.Id == rentDTO.CarId);
                    if (car == null)
                    {
                        continue;
                    }

                    var rental = new RentACar(user, car, rentDTO.StartDate, rentDTO.ReturnDate, status);
                    rental.TotalPrice = CalculatePrice(car.PricePerDay, rentDTO.StartDate, rentDTO.ReturnDate);
                    rentalHistory.Add(rental);

                }

                return "done";
            }
            catch (Exception ex) // Catch general exceptions for safety.
            {
                // Log the exception here if necessary.
                return $"Error: {ex.Message}";
            }
        }


    }
}
