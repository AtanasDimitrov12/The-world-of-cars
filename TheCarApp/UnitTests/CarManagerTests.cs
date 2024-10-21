using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Entity_Layer;
using Entity_Layer.Enums;
using InterfaceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using EntityLayout;
using DTO;
using Manager_Layer;

namespace UnitTests
{
    [TestClass]
    public class CarManagerTests
    {
        private Mock<IDataAccess> _mockDataAccess;
        private Mock<ICarDataWriter> _mockDataWriter;
        private Mock<ICarDataRemover> _mockDataRemover;
        private CarManager _carManager;

        [TestInitialize]
        public void Setup()
        {
            _mockDataAccess = new Mock<IDataAccess>();
            _mockDataWriter = new Mock<ICarDataWriter>();
            _mockDataRemover = new Mock<ICarDataRemover>();
            _carManager = new CarManager(_mockDataAccess.Object, _mockDataWriter.Object, _mockDataRemover.Object);
        }

        public Car MapCarDtoToCar(CarDTO carDTO)
        {
            if (carDTO == null)
                throw new ArgumentNullException(nameof(carDTO));

            if (string.IsNullOrEmpty(carDTO.CarStatus))
                throw new ArgumentException("CarStatus cannot be null or empty", nameof(carDTO.CarStatus));

            var status = Enum.Parse<CarStatus>(carDTO.CarStatus, true);

            var car = new Car(carDTO.Id, carDTO.Brand, carDTO.Model, carDTO.FirstRegistration, carDTO.Mileage, carDTO.Fuel, carDTO.EngineSize, carDTO.HorsePower, carDTO.Gearbox, carDTO.Color, carDTO.VIN, carDTO.Description, carDTO.PricePerDay, status, carDTO.NumberOfSeats, carDTO.NumberOfDoors, carDTO.Views);

            foreach (var extraDTO in carDTO.CarExtras)
            {
                var extra = new Extra(extraDTO.extraName, extraDTO.Id);
                car.CarExtras.Add(extra);
            }

            foreach (var picDTO in carDTO.Pictures)
            {
                var pic = new Picture(picDTO.Id, picDTO.PictureURL);
                car.Pictures.Add(pic);
            }

            return car;
        }

        [TestMethod]
        public void AddCar_WhenCalled_ReturnsTrue()
        {
            var car = new Car { VIN = "123ABC" };
            var pictures = new List<Picture>();
            var extras = new List<Extra>();

            _mockDataWriter.Setup(m => m.AddCar(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                           .Verifiable();
            _mockDataWriter.Setup(m => m.GetCarId(It.IsAny<string>())).Returns(1);
            _mockDataWriter.Setup(m => m.AddCarDescription(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<decimal>())).Verifiable();

            var result = _carManager.AddCar(car, pictures, extras, out string errorMessage);

            Assert.IsTrue(result);
            Assert.AreEqual(string.Empty, errorMessage);
            _mockDataWriter.Verify(m => m.AddCarDescription(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<decimal>()), Times.Once);
        }

        [TestMethod]
        public void RemoveCar_WhenCalled_ReturnsTrue()
        {
            var car = new Car { Id = 1 };
            _mockDataRemover.Setup(m => m.RemoveCar(It.IsAny<int>())).Verifiable();

            var result = _carManager.RemoveCar(car, out string errorMessage);

            Assert.IsTrue(result);
            Assert.AreEqual(string.Empty, errorMessage);
        }

        [TestMethod]
        public void UpdateCar_WhenAllUpdatesSucceed_ReturnsTrue()
        {
            var car = new Car { Id = 1, Description = "Details", PricePerDay = 50, Pictures = new List<Picture>(), CarExtras = new List<Extra>() };
            var pictures = new List<Picture>() { new Picture(1, "url") };
            var extras = new List<Extra>() { new Extra("GPS", 1) };
            _mockDataWriter.Setup(m => m.UpdateCar(car)).Verifiable();
            _mockDataWriter.Setup(m => m.UpdateCarDescription(car)).Verifiable();
            _mockDataRemover.Setup(m => m.RemoveCarPictures(car.Id)).Verifiable();
            _mockDataRemover.Setup(m => m.RemoveCarExtras(car.Id)).Verifiable();
            _mockDataWriter.Setup(m => m.AddCarPictures(car.Id, It.IsAny<int>())).Verifiable();
            _mockDataWriter.Setup(m => m.AddCarExtras(car.Id, It.IsAny<int>())).Verifiable();

            var result = _carManager.UpdateCar(car, pictures, extras, out string errorMessage);

            Assert.IsTrue(result);
            Assert.AreEqual(string.Empty, errorMessage);
            _mockDataWriter.Verify(m => m.AddCarPictures(car.Id, It.IsAny<int>()), Times.Exactly(pictures.Count));
            _mockDataWriter.Verify(m => m.AddCarExtras(car.Id, It.IsAny<int>()), Times.Exactly(extras.Count));
        }

        [TestMethod]
        public void ChangeCarStatus_WhenCalled_ReturnsTrue()
        {
            var car = new Car { Id = 1, CarStatus = CarStatus.AVAILABLE };
            var newStatus = "UNAVAILABLE";
            var status = CarStatus.UNAVAILABLE;

            _mockDataWriter.Setup(m => m.ChangeCarStatus(It.IsAny<Car>(), It.IsAny<string>())).Verifiable();

            var result = _carManager.ChangeCarStatus(car, newStatus, status, out string errorMessage);

            Assert.IsTrue(result);
            Assert.AreEqual(string.Empty, errorMessage);
            Assert.AreEqual(status, car.CarStatus);
        }

        [TestMethod]
        public void RecordCarView_WhenCarExists_ReturnsTrue()
        {
            var carId = 1;
            var carDTO = new CarDTO
            {
                Id = carId,
                Views = 10,
                CarStatus = CarStatus.AVAILABLE.ToString(),
                Brand = "Test Brand",
                Model = "Test Model",
                FirstRegistration = DateTime.Now,
                Mileage = 10000,
                Fuel = "Gasoline",
                EngineSize = 2000,
                HorsePower = 150,
                Gearbox = "Automatic",
                Color = "Black",
                VIN = "123ABC",
                Description = "Test Description",
                PricePerDay = 100,
                NumberOfSeats = 5,
                NumberOfDoors = "4/5",
                CarExtras = new List<ExtraDTO>(), // Initialize to avoid null reference
                Pictures = new List<PictureDTO>() // Initialize to avoid null reference
            };

            _mockDataAccess.Setup(m => m.GetCarById(carId)).Returns(carDTO);
            _mockDataWriter.Setup(m => m.RecordCarView(It.IsAny<int>())).Verifiable();

            var car = _carManager.MapCarDtoToCar(carDTO);
            _carManager.GetCars().Add(car);

            var result = _carManager.RecordCarView(carId, out string errorMessage);

            Assert.IsTrue(result);
            Assert.AreEqual(string.Empty, errorMessage);
            Assert.AreEqual(11, car.Views);
        }


        [TestMethod]
        public void RecordCarView_WhenCarDoesNotExist_ReturnsFalse()
        {
            var carId = 1;
            _mockDataWriter.Setup(m => m.RecordCarView(It.IsAny<int>())).Verifiable();
            _mockDataAccess.Setup(m => m.GetCarById(carId)).Returns((CarDTO)null);

            var result = _carManager.RecordCarView(carId, out string errorMessage);

            Assert.IsFalse(result);
            Assert.AreEqual("Car not found", errorMessage);
        }

        [TestMethod]
        public void GetCarById_WhenCarExists_ReturnsCar()
        {
            var carId = 1;
            var carDTO = new CarDTO
            {
                Id = carId,
                CarStatus = CarStatus.AVAILABLE.ToString(), // Ensure CarStatus is properly set
                Brand = "Test Brand",
                Model = "Test Model",
                FirstRegistration = DateTime.Now,
                Mileage = 10000,
                Fuel = "Gasoline",
                EngineSize = 2000,
                HorsePower = 150,
                Gearbox = "Automatic",
                Color = "Black",
                VIN = "123ABC",
                Description = "Test Description",
                PricePerDay = 100,
                NumberOfSeats = 5,
                NumberOfDoors = "4/5",
                Views = 0,
                CarExtras = new List<ExtraDTO>(),
                Pictures = new List<PictureDTO>()
            };

            _mockDataAccess.Setup(m => m.GetCarById(carId)).Returns(carDTO);

            var car = _carManager.MapCarDtoToCar(carDTO);
            _carManager.GetCars().Add(car);

            var result = _carManager.GetCarById(carId);

            Assert.IsNotNull(result);
            Assert.AreEqual(carId, result.Id);
        }

        [TestMethod]
        public void GetCarById_WhenCarDoesNotExist_ReturnsNull()
        {
            var carId = 1;
            _mockDataAccess.Setup(m => m.GetCarById(carId)).Returns((CarDTO)null);

            var result = _carManager.GetCarById(carId);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetCars_ReturnsAllCars()
        {
            var carDTOs = new List<CarDTO>
    {
        new CarDTO { Id = 1, CarStatus = CarStatus.AVAILABLE.ToString(), Brand = "Test", Model = "Model1", FirstRegistration = DateTime.Now, Mileage = 1000, Fuel = "Gasoline", EngineSize = 2000, HorsePower = 150, Gearbox = "Automatic", Color = "Black", VIN = "VIN1", Description = "Desc1", PricePerDay = 100, NumberOfSeats = 5, NumberOfDoors = "4/5", Views = 10, CarExtras = new List<ExtraDTO>(), Pictures = new List<PictureDTO>() },
        new CarDTO { Id = 2, CarStatus = CarStatus.UNAVAILABLE.ToString(), Brand = "Test2", Model = "Model2", FirstRegistration = DateTime.Now, Mileage = 2000, Fuel = "Diesel", EngineSize = 3000, HorsePower = 200, Gearbox = "Manual", Color = "Red", VIN = "VIN2", Description = "Desc2", PricePerDay = 150, NumberOfSeats = 4, NumberOfDoors = "2/3", Views = 20, CarExtras = new List<ExtraDTO>(), Pictures = new List<PictureDTO>() }
    };

            var cars = carDTOs.Select(dto => _carManager.MapCarDtoToCar(dto)).ToList();
            _carManager.GetCars().AddRange(cars);

            var result = _carManager.GetCars();

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(1, result[0].Id);
            Assert.AreEqual(2, result[1].Id);
        }

        [TestMethod]
        public void GetCarsASC_ReturnsCarsSortedByBrandAscending()
        {
            var car1 = new Car { Brand = "Audi" };
            var car2 = new Car { Brand = "BMW" };
            var cars = new List<Car> { car2, car1 };
            _carManager.GetCars().AddRange(cars);

            var result = _carManager.GetCarsASC();

            Assert.AreEqual(car1.Brand, result[0].Brand);
            Assert.AreEqual(car2.Brand, result[1].Brand);
        }

        [TestMethod]
        public void GetCarsDESC_ReturnsCarsSortedByBrandDescending()
        {
            var car1 = new Car { Brand = "Audi" };
            var car2 = new Car { Brand = "BMW" };
            var cars = new List<Car> { car1, car2 };
            _carManager.GetCars().AddRange(cars);

            var result = _carManager.GetCarsDESC();

            Assert.AreEqual(car2.Brand, result[0].Brand);
            Assert.AreEqual(car1.Brand, result[1].Brand);
        }

        [TestMethod]
        public void LoadCars_WhenCalled_ReturnsTrue()
        {
            var carDTOs = new List<CarDTO>
            {
                new CarDTO
                {
                    Id = 1,
                    Brand = "Audi",
                    CarStatus = "Available",
                    CarExtras = new List<ExtraDTO>(),
                    Pictures = new List<PictureDTO>()
                }
            };
            _mockDataAccess.Setup(m => m.GetCars()).Returns(carDTOs);

            var result = _carManager.LoadCars(out string errorMessage);

            Assert.IsTrue(result);
            Assert.AreEqual(string.Empty, errorMessage);
            Assert.AreEqual(carDTOs.Count, _carManager.GetCars().Count);
        }

        [TestMethod]
        public void LoadCars_WhenExceptionThrown_ReturnsFalse()
        {
            _mockDataAccess.Setup(m => m.GetCars()).Throws(new Exception("Database error"));

            var result = _carManager.LoadCars(out string errorMessage);

            Assert.IsFalse(result);
            Assert.AreEqual("Database error", errorMessage);
        }
    }
}
