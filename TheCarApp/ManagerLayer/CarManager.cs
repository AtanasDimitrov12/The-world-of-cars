using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;
using DatabaseAccess;
using DTO;
using Entity_Layer;
using Entity_Layer.Enums;
using Entity_Layer.Interfaces;
using EntityLayout;



namespace Manager_Layer
{
    public class CarManager
    {
        private List<Car> cars;
        public List<Picture> pictures { get; set; }
        public List<Extra> extras { get; set; }
        private DataAccess access;
        private DataWriter writer;
        private DataRemover remover;

        public CarManager()
        {
            cars = new List<Car>();
            pictures = new List<Picture>();
            extras = new List<Extra>(); 
            access = new DataAccess();
            writer = new DataWriter();
            remover = new DataRemover();
        }

        public void AddCar(Car car, List<Picture> pics, List<Extra> extras)
        {
            cars.Add(car);
            writer.AddCar(car.brand, car.Model, car.FirstRegistration, car.Mileage, car.Fuel, car.EngineSize, car.HorsePower, car.Gearbox, car.NumberOfSeats, car.NumberOfDoors, car.Color, car.VIN, car.CarStatus.ToString());
            int carId = writer.GetCarId(car.VIN);
            car.Id = carId;
            writer.AddCarDescription(car.Id, car.Description, car.PricePerDay);
            foreach (Picture pic in pics)
            {
                writer.AddCarPictures(car.Id, pic.Id);
            }
            foreach (Extra extra in extras)
            {
                writer.AddCarExtras(car.Id, extra.Id);
            }

        }

        public void RemoveCar(Car car, Picture pic, Extra extra)
        {
            cars.Remove(car);
            remover.RemoveCar(car.Id, extra.Id, pic.Id);
        }

        public void AddPicture(Picture pic)
        {//tqbva da napravq idto kakto napravih na kolite. Sushto i na extrite
            pictures.Add(pic);
            writer.AddPicture(pic.PictureURL);
        }

        public void RemovePicture(Picture pic)
        {
            pictures.Remove(pic);
            //remover.RemovePicture(pic.Id);
        }

        public void AddExtra(Extra extra)
        {
            extras.Add(extra);
            writer.AddExtra(extra.extraName);
        }
        public void RemoveExtra(Extra extra)
        {
            extras.Remove(extra);
            //remover.RemoveExtras(extra.Id);
        }

        public Car SearchForCar(int index)
        {
            return cars[index];
        }

        public List<Car> GetCars()
        {
            return cars;
        }

        public List<Car> GetCarsASC()
        {
            AscendingBrandComparer asc = new AscendingBrandComparer();
            cars.Sort(asc);
            return cars;
        }
        public List<Car> GetCarsDESC()
        {
            DescendingBrandComparer desc = new DescendingBrandComparer();
            cars.Sort(desc);
            return cars;
        }

        public void LoadCars()
        {
            if (access.GetCars() != null)
            {
                foreach (CarDTO carDTO in access.GetCars())
                {
                    CarStatus status;
                    bool isValidArea = Enum.TryParse(carDTO.CarStatus.ToUpper(), true, out status);

                    if (isValidArea)
                    { //load cat Extra and Picture

                        Car loadCar = new Car(carDTO.Id, carDTO.Brand, carDTO.Model, carDTO.FirstRegistration, carDTO.Mileage, carDTO.Fuel, carDTO.EngineSize, carDTO.HorsePower, carDTO.Gearbox, carDTO.Color, carDTO.VIN, carDTO.Description, carDTO.PricePerDay, status, carDTO.NumberOfSeats, carDTO.NumberOfDoors);
                        cars.Add(loadCar);

                        foreach (ExtraDTO extraDTO in carDTO.CarExtras)
                        {
                            Extra extra = new Extra(extraDTO.extraName, extraDTO.Id);
                            loadCar.AddExtra(extra);
                        }
                        foreach (PictureDTO picDTO in carDTO.Pictures)
                        {
                            Picture pic = new Picture(picDTO.Id, picDTO.PictureURL);
                            loadCar.AddPicture(pic);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Warning: {carDTO.Id} has an invalid status assigned.");
                    }
                }
            }
        }
    }
}
