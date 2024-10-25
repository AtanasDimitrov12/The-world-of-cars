using Moq;
using InterfaceLayer;
using Manager_Layer;
using DTO;
using AutoMapper;
using Data.Models;
using DTO.Enums;

namespace UnitTests
{
    [TestClass]
    public class CarManagerTests
    {
        private Mock<IDataAccess> _mockDataAccess;
        private Mock<ICarDataWriter> _mockDataWriter;
        private Mock<ICarDataRemover> _mockDataRemover;
        private ICarManager _carManager;
        private Mock<IMapper> _mockMapper;

        [TestInitialize]
        public void Setup()
        {
            _mockDataAccess = new Mock<IDataAccess>();
            _mockDataWriter = new Mock<ICarDataWriter>();
            _mockDataRemover = new Mock<ICarDataRemover>();
            _mockMapper = new Mock<IMapper>();
            _carManager = new CarManager(_mockMapper.Object, _mockDataAccess.Object, _mockDataWriter.Object, _mockDataRemover.Object);
        }

        [TestMethod]
        public async Task AddCarAsync_WhenCarIsAdded_ReturnsTrue()
        {
            var carDTO = new CarDTO { VIN = "123ABC" };
            var car = new Car();

            // Setup mapping from DTO to Car
            _mockMapper.Setup(m => m.Map<Car>(It.IsAny<CarDTO>())).Returns(car);

            // Mock the data writer behavior
            _mockDataWriter.Setup(m => m.AddCar(It.IsAny<Car>())).Returns(Task.CompletedTask);
            _mockDataWriter.Setup(m => m.GetCarId(It.IsAny<string>())).ReturnsAsync(1);

            var result = await _carManager.AddCarAsync(carDTO);

            Assert.IsTrue(result.Success);
            Assert.IsNull(result.ErrorMessage);
            _mockDataWriter.Verify(m => m.AddCar(It.IsAny<Car>()), Times.Once);
        }

        [TestMethod]
        public async Task RemoveCarAsync_WhenCarIsRemoved_ReturnsTrue()
        {
            var carDTO = new CarDTO { Id = 1 };
            var car = new Car();

            // Setup mapping from DTO to Car
            _mockMapper.Setup(m => m.Map<Car>(It.IsAny<CarDTO>())).Returns(car);

            // Mock the data remover behavior
            _mockDataRemover.Setup(m => m.RemoveCarAsync(It.IsAny<int>())).Returns(Task.CompletedTask);

            var result = await _carManager.RemoveCarAsync(carDTO);

            Assert.IsTrue(result.Success);
            Assert.IsNull(result.ErrorMessage);
            _mockDataRemover.Verify(m => m.RemoveCarAsync(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public async Task UpdateCarAsync_WhenCarIsUpdated_ReturnsTrue()
        {
            var carDTO = new CarDTO { Id = 1, Description = "Updated Description", PricePerDay = 50 };
            var car = new Car();

            // Setup mapping from DTO to Car
            _mockMapper.Setup(m => m.Map<Car>(It.IsAny<CarDTO>())).Returns(car);

            // Mock the data writer behavior
            _mockDataWriter.Setup(m => m.UpdateCar(It.IsAny<Car>())).Returns(Task.CompletedTask);

            var result = await _carManager.UpdateCarAsync(carDTO);

            Assert.IsTrue(result.Success);
            Assert.IsNull(result.ErrorMessage);
            _mockDataWriter.Verify(m => m.UpdateCar(It.IsAny<Car>()), Times.Once);
        }

        [TestMethod]
        public async Task ChangeCarStatusAsync_WhenCarStatusIsChanged_ReturnsTrue()
        {
            var carDTO = new CarDTO { Id = 1, Status = CarStatus.AVAILABLE.ToString() };
            var car = new Car { Status = CarStatus.AVAILABLE.ToString() };
            var newStatus = CarStatus.UNAVAILABLE.ToString();

            // Setup mapping from DTO to Car
            _mockMapper.Setup(m => m.Map<Car>(It.IsAny<CarDTO>())).Returns(car);

            // Mock the data writer behavior
            _mockDataWriter.Setup(m => m.ChangeCarStatus(It.IsAny<int>(), It.IsAny<string>())).Returns(Task.CompletedTask);

            var result = await _carManager.ChangeCarStatusAsync(carDTO, newStatus, CarStatus.UNAVAILABLE);

            Assert.IsTrue(result.Success);
            Assert.IsNull(result.ErrorMessage);
            Assert.AreEqual(CarStatus.UNAVAILABLE.ToString(), carDTO.Status);
            _mockDataWriter.Verify(m => m.ChangeCarStatus(It.IsAny<int>(), It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public async Task RecordCarViewAsync_WhenCarIsViewed_ReturnsTrue()
        {
            var carDTO = new CarDTO { Id = 1, ViewCount = 10 };
            var car = new Car { CarId = 1, ViewCount = 10 };

            // Mock the data access behavior
            _mockDataWriter.Setup(m => m.RecordCarView(It.IsAny<int>())).Returns(Task.CompletedTask);

            // Setup mapping from DTO to Car
            _mockMapper.Setup(m => m.Map<Car>(carDTO)).Returns(car);

            _carManager.GetCars().Add(carDTO);

            var result = await _carManager.RecordCarViewAsync(carDTO.Id);

            Assert.IsTrue(result.Success);
            Assert.IsNull(result.ErrorMessage);
            Assert.AreEqual(11, carDTO.ViewCount);
            _mockDataWriter.Verify(m => m.RecordCarView(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public async Task LoadCarsAsync_WhenCarsAreLoaded_ReturnsTrue()
        {
            var carList = new List<Car>
            {
                new Car { CarId = 1, Brand = "Audi", Model = "A4", Status = CarStatus.AVAILABLE.ToString() },
                new Car { CarId = 2, Brand = "BMW", Model = "X5", Status = CarStatus.UNAVAILABLE.ToString() }
            };

            // Mock data access to return the list of cars
            _mockDataAccess.Setup(m => m.GetCarsAsync()).ReturnsAsync(carList);

            // Mock mapping from Car to CarDTO
            _mockMapper.Setup(m => m.Map<CarDTO>(It.IsAny<Car>())).Returns((Car car) => new CarDTO
            {
                Id = car.CarId,
                Brand = car.Brand,
                Model = car.Model,
                Status = car.Status.ToString()
            });

            var result = await _carManager.LoadCarsAsync();

            Assert.IsTrue(result.Success);
            Assert.IsNull(result.ErrorMessage);
            Assert.AreEqual(2, _carManager.GetCars().Count);
        }

        [TestMethod]
        public void GetCarsASC_ReturnsCarsSortedByBrandAscending()
        {
            var carDTOs = new List<CarDTO>
            {
                new CarDTO { Id = 1, Brand = "BMW" },
                new CarDTO { Id = 2, Brand = "Audi" }
            };
            _carManager.GetCars().AddRange(carDTOs);

            var result = _carManager.GetCarsASC();

            Assert.AreEqual("Audi", result[0].Brand);
            Assert.AreEqual("BMW", result[1].Brand);
        }

        [TestMethod]
        public void GetCarsDESC_ReturnsCarsSortedByBrandDescending()
        {
            var carDTOs = new List<CarDTO>
            {
                new CarDTO { Id = 1, Brand = "Audi" },
                new CarDTO { Id = 2, Brand = "BMW" }
            };
            _carManager.GetCars().AddRange(carDTOs);

            var result = _carManager.GetCarsDESC();

            Assert.AreEqual("BMW", result[0].Brand);
            Assert.AreEqual("Audi", result[1].Brand);
        }

        [TestMethod]
        public void GetCarById_WhenCarExists_ReturnsCar()
        {
            var carId = 1;
            var carDTO = new CarDTO { Id = carId, Brand = "Audi" };
            _carManager.GetCars().Add(carDTO);

            var result = _carManager.GetCarById(carId);

            Assert.IsNotNull(result);
            Assert.AreEqual(carId, result.Id);
        }

        [TestMethod]
        public void GetCarById_WhenCarDoesNotExist_ReturnsNull()
        {
            var carId = 1;

            var result = _carManager.GetCarById(carId);

            Assert.IsNull(result);
        }
    }
}
