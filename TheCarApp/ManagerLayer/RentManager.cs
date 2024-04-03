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
            RentACar rentACar = new RentACar(user, car, startDate, endDate);
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
                        User loadUser = new User(userDTO.email, userDTO.password, userDTO.Username, userDTO.CreatedOn, userDTO._licenseNumber);


                        RentACar loadRent = new RentACar(loadUser, rentDTO.car, rentDTO.StartDate, rentDTO.ReturnDate, status);

                        rentalHistory.Add(loadRent);

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
