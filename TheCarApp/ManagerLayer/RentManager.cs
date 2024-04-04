using Database;
using DTO;
using Entity_Layer;
using Entity_Layer.Enums;
using EntityLayout;
using Manager_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLayer
{
    public class RentManager
    {
        public List<RentACar> rentalHistory { get; set; }
        private DataAccess access;

        public RentManager() 
        { 
            rentalHistory = new List<RentACar>();
        }

        public void RentACar(User user, Car car, DateTime startDate, DateTime endDate)
        {
            RentACar rentACar = new RentACar(user, car, startDate, endDate, RentStatus.SCHEDULE);
        }

        public void ChangeRentStatus(RentACar rentACar, RentStatus status)
        { 
            rentACar.ChangeStatus(status);
        }

        public void LoadRentals()
        {
            if (access.GetRentals() != null)
            {
                foreach (RentACarDTO rentDTO in access.GetRentals())
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
                            User loadUser = new User(userDTO.email, userDTO.password, userDTO.Username, userDTO.CreatedOn, userDTO._licenseNumber);
                            Car loadCar = new Car(carDTO.Id, carDTO.Brand, carDTO.Model, carDTO.FirstRegistration, carDTO.Mileage, carDTO.Fuel, carDTO.EngineSize, carDTO.HorsePower, carDTO.Gearbox, carDTO.Color, carDTO.VIN, carDTO.Description, carDTO.PricePerDay, carStatusCheck);

                            RentACar loadRent = new RentACar(loadUser, loadCar, rentDTO.StartDate, rentDTO.ReturnDate, status);

                            rentalHistory.Add(loadRent);

                        }

                    }
                    else
                    {
                        Console.WriteLine($"Warning: {rentDTO.Id} has an invalid area assigned.");
                    }
                }
            }
        }
    }
}
