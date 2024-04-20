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
        void AddCar(Car car, List<Picture> pictures, List<Extra> extras);
        void RemoveCar(Car car, Picture picture, Extra extra);
        void UpdateCar(Car car);
        Car SearchForCar(int index);
        List<Car> GetCars();
        List<Car> GetCarsASC();
        List<Car> GetCarsDESC();
        Car GetCarById(int carId);
        void LoadCars();
    }
}
