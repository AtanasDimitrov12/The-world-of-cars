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

        public RentManager(IDataAccess dataAccess, IPeopleDataWriter dataWriter, IPeopleDataRemover dataRemover)
        {
            rentalHistory = new List<RentACar>();
            writer = dataWriter;
            remover = dataRemover;
            access = dataAccess;
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

        public string RentACar(User user, Car car, DateTime startDate, DateTime endDate)
        {
            try
            {
                writer.RentACar(car.Id, user.Id, startDate, endDate, RentStatus.SCHEDULE.ToString());

                RentACar rentACar = new RentACar(user, car, startDate, endDate, RentStatus.SCHEDULE);
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
                var loadedRentals = access.GetRentals();
                if (loadedRentals != null)
                {
                    foreach (RentACarDTO rentDTO in loadedRentals)
                    {
                        RentStatus status;
                        bool isValidArea = Enum.TryParse(rentDTO.status.ToUpper(), true, out status);

                        if (isValidArea)
                        {
                            UserDTO userDTO = rentDTO.user;
                            CarDTO carDTO = rentDTO.car;

                            CarStatus carStatusCheck;
                            bool isValidStatus = Enum.TryParse(carDTO.CarStatus.ToUpper(), true, out carStatusCheck);
                            if (isValidStatus)
                            {
                                User loadUser = new User(userDTO.Id, userDTO.email, userDTO.password, userDTO.Username, userDTO.CreatedOn, userDTO._licenseNumber, userDTO.passSalt); // ne sum siguren dali veche ne trqbva da go vzimam ot sushtestvuvashtite users
                                Car loadCar = new Car(carDTO.Id, carDTO.Brand, carDTO.Model, carDTO.FirstRegistration, carDTO.Mileage, carDTO.Fuel, carDTO.EngineSize, carDTO.HorsePower, carDTO.Gearbox, carDTO.Color, carDTO.VIN, carDTO.Description, carDTO.PricePerDay, carStatusCheck, carDTO.NumberOfSeats, carDTO.NumberOfDoors, carDTO.Views);

                                RentACar loadRent = new RentACar(loadUser, loadCar, rentDTO.StartDate, rentDTO.ReturnDate, status);

                                rentalHistory.Add(loadRent);

                            }
                            else
                            {
                                return $"Warning: {rentDTO.Id} has an invalid status assigned.";
                            }

                        }
                        else
                        {
                            return $"Warning: {rentDTO.Id} has an invalid area assigned.";
                        }
                    }
                }
                return "done";
            }
            catch (ApplicationException ex)
            {
                return ex.Message;
            }


        }
    }
}
