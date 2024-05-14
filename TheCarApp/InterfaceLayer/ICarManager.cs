using Entity_Layer;
using EntityLayout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer
{
    public interface ICarManager
    {
        string AddCar(Car car, List<Picture> pictures, List<Extra> extras);
        string RemoveCar(Car car);
        string UpdateCar(Car car, List<Picture> pictures, List<Extra> extras);
        Car SearchForCar(int index);
        List<Car> GetCars();
        List<Car> GetCarsASC();
        List<Car> GetCarsDESC();
        Car GetCarById(int carId);
        string LoadCars();
    }
}
