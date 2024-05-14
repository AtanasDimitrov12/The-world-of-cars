using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Manager_Layer;
using Entity_Layer;
using Entity_Layer.Enums;
using InterfaceLayer;
using System.Collections.Generic;
using EntityLayout;

namespace UnitTests
{
    [TestClass]
    public class CarManagerTests
    {
        private Mock<IDataAccess> _mockDataAccess;
        private Mock<IDataWriter> _mockDataWriter;
        private Mock<IDataRemover> _mockDataRemover;
        private CarManager _carManager;

        [TestInitialize]
        public void Setup()
        {
            _mockDataAccess = new Mock<IDataAccess>();
            _mockDataWriter = new Mock<IDataWriter>();
            _mockDataRemover = new Mock<IDataRemover>();
            _carManager = new CarManager(_mockDataAccess.Object, _mockDataWriter.Object, _mockDataRemover.Object);
        }

        [TestMethod]
        public void AddCar_WhenCalled_ReturnsDone()
        {
            var car = new Car { VIN = "123ABC" };
            var pictures = new List<Picture>();
            var extras = new List<Extra>();

            _mockDataWriter.Setup(m => m.AddCar(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                           .Returns("done");
            _mockDataWriter.Setup(m => m.GetCarId(It.IsAny<string>())).Returns("1");
            _mockDataWriter.Setup(m => m.AddCarDescription(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<decimal>())).Verifiable();

            var result = _carManager.AddCar(car, pictures, extras);

            Assert.AreEqual("done", result);
            _mockDataWriter.Verify(m => m.AddCarDescription(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<decimal>()), Times.Once);
        }

        [TestMethod]
        public void RemoveCar_WhenCalled_ReturnsDone()
        {
            var car = new Car { Id = 1 };
            _mockDataRemover.Setup(m => m.RemoveCar(It.IsAny<int>())).Returns("done");

            var result = _carManager.RemoveCar(car);

            Assert.AreEqual("done", result);
        }

        [TestMethod]
        public void UpdateCar_WhenAllUpdatesSucceed_ReturnsDone()
        {
            // Arrange
            var car = new Car { Id = 1, Description = "Details", PricePerDay = 50, Pictures = new List<Picture>(), CarExtras = new List<Extra>() };
            var pictures = new List<Picture>() { new Picture(1, "url") };
            var extras = new List<Extra>() { new Extra("GPS", 1) };
            _mockDataWriter.Setup(m => m.UpdateCar(car)).Returns("done");
            _mockDataWriter.Setup(m => m.UpdateCarDescription(car)).Returns("done");
            _mockDataWriter.Setup(m => m.RemoveCarPictures(car.Id)).Returns("done");
            _mockDataWriter.Setup(m => m.RemoveCarExtras(car.Id)).Returns("done");
            _mockDataWriter.Setup(m => m.AddCarPictures(car.Id, It.IsAny<int>())).Verifiable();
            _mockDataWriter.Setup(m => m.AddCarExtras(car.Id, It.IsAny<int>())).Verifiable();

            // Act
            var result = _carManager.UpdateCar(car, pictures, extras);

            // Assert
            Assert.AreEqual("done", result);
            _mockDataWriter.Verify(m => m.AddCarPictures(car.Id, It.IsAny<int>()), Times.Exactly(pictures.Count));
            _mockDataWriter.Verify(m => m.AddCarExtras(car.Id, It.IsAny<int>()), Times.Exactly(extras.Count));
        }



    }
}