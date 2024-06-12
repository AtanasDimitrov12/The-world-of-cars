using DTO;
using Entity_Layer;
using Entity_Layer.Enums;
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
        bool AddCar(Car car, List<Picture> pictures, List<Extra> extras, out string errorMessage);
        bool RemoveCar(Car car, out string errorMessage);
        bool ChangeCarStatus(Car car, string newStatus, CarStatus Status, out string errorMessage);
        bool RecordCarView(int carId, out string errorMessage);
        bool UpdateCar(Car car, List<Picture> pictures, List<Extra> extras, out string errorMessage);
        Car SearchForCar(int index);
        List<Car> GetCars();
        List<Car> GetCarsASC();
        List<Car> GetCarsDESC();
        Car GetCarById(int carId);
        Car MapCarDtoToCar(CarDTO carDTO);
        bool LoadCars(out string errorMessage);
    }
}

