using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace InterfaceLayer
{
    public interface IDataAccess
    {
        List<CarDTO> GetCars();
        List<CarNewsDTO> GetCarNews();
        List<CommentDTO> GetCommentsForNews(int newsId);
        List<RentACarDTO> GetRentals();
        UserDTO GetUserById(int userId);
        CarDTO GetCarById(int carId);
        List<UserDTO> GetUsers();
        List<AdministratorDTO> GetAdministrators();
    }
}
