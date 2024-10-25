using Moq;
using ManagerLayer;
using InterfaceLayer;
using Manager_Layer;
using DTO;
using DTO.Enums;
using Data.Models;

namespace UnitTests
{
    [TestClass]
    public class RentManagerTests
    {
        private Mock<IDataAccess> _mockDataAccess;
        private Mock<IPeopleDataWriter> _mockDataWriter;
        private Mock<IPeopleDataRemover> _mockDataRemover;
        private Mock<IPeopleManager> _mockPeopleManager;
        private Mock<ICarManager> _mockCarManager;
        private Mock<IRentalStrategyFactory> _mockRentalStrategyFactory;
        private Mock<IRentalStrategy> _mockRentalStrategy;
        private RentManager _rentManager;

        [TestInitialize]
        public void Setup()
        {
            _mockDataAccess = new Mock<IDataAccess>();
            _mockDataWriter = new Mock<IPeopleDataWriter>();
            _mockDataRemover = new Mock<IPeopleDataRemover>();
            _mockPeopleManager = new Mock<IPeopleManager>();
            _mockCarManager = new Mock<ICarManager>();
            _mockRentalStrategyFactory = new Mock<IRentalStrategyFactory>();
            _mockRentalStrategy = new Mock<IRentalStrategy>();

            _mockRentalStrategyFactory.Setup(f => f.GetRentalStrategy(It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                                      .Returns(_mockRentalStrategy.Object);

            var mockMapper = new Mock<AutoMapper.IMapper>(); // Mock the AutoMapper
            _rentManager = new RentManager(_mockDataAccess.Object, _mockDataWriter.Object, _mockDataRemover.Object, _mockPeopleManager.Object, _mockCarManager.Object, _mockRentalStrategyFactory.Object, mockMapper.Object);
        }

        [TestMethod]
        public void CalculatePrice_WhenCalled_ReturnsExpectedPrice()
        {
            var user = new UserDTO { Id = 1, Email = "user@example.com" };
            decimal basePrice = 100m;
            DateTime startDate = new DateTime(2023, 10, 1);
            DateTime endDate = new DateTime(2023, 10, 10);
            int days = (int)(endDate - startDate).TotalDays;
            int discount = 0;
            decimal expectedPrice = 900m;

            _mockRentalStrategy.Setup(s => s.CalculateRentalPrice(basePrice, days, discount))
                               .Returns(expectedPrice);

            var result = _rentManager.CalculatePrice(user, basePrice, startDate, endDate);

            Assert.AreEqual(expectedPrice, result);
        }

        [TestMethod]
        public void CheckForDiscount_WhenUserHasNoRents_ReturnsZero()
        {
            var user = new UserDTO { Id = 1, Email = "user@example.com" };
            _rentManager.RentalHistory = new List<RentACarDTO>();

            var result = _rentManager.CheckForDiscount(user);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CheckForDiscount_WhenUserHasRents_ReturnsExpectedDiscount()
        {
            var user = new UserDTO { Id = 1, Email = "user@example.com" };
            _rentManager.RentalHistory = new List<RentACarDTO>
            {
                new RentACarDTO { UserId = user.Id, Status = RentStatus.COMPLETED.ToString() },
                new RentACarDTO { UserId = user.Id, Status = RentStatus.COMPLETED.ToString() },
                new RentACarDTO { UserId = user.Id, Status = RentStatus.COMPLETED.ToString() },
                new RentACarDTO { UserId = user.Id, Status = RentStatus.COMPLETED.ToString() },
                new RentACarDTO { UserId = user.Id, Status = RentStatus.COMPLETED.ToString() },
                new RentACarDTO { UserId = user.Id, Status = RentStatus.COMPLETED.ToString() },
                new RentACarDTO { UserId = user.Id, Status = RentStatus.COMPLETED.ToString() },
                new RentACarDTO { UserId = user.Id, Status = RentStatus.COMPLETED.ToString() },
                new RentACarDTO { UserId = user.Id, Status = RentStatus.COMPLETED.ToString() },
                new RentACarDTO { UserId = user.Id, Status = RentStatus.COMPLETED.ToString() },
                new RentACarDTO { UserId = user.Id, Status = RentStatus.COMPLETED.ToString() },
                new RentACarDTO { UserId = user.Id, Status = RentStatus.COMPLETED.ToString() },
                new RentACarDTO { UserId = user.Id, Status = RentStatus.COMPLETED.ToString() },
                new RentACarDTO { UserId = user.Id, Status = RentStatus.COMPLETED.ToString() },
                new RentACarDTO { UserId = user.Id, Status = RentStatus.COMPLETED.ToString() }
                // Repeat for more completed rents to test discount logic
            };

            var result = _rentManager.CheckForDiscount(user);

            Assert.AreEqual(5, result); // Depending on the number of rents in the history, adjust the expected discount
        }

        [TestMethod]
        public async Task RentACar_WhenCalled_ReturnsDone()
        {
            var rent = new RentACarDTO
            {
                CarId = 1,
                UserId = 1,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(5),
                Status = RentStatus.REQUESTED.ToString()
            };

            _mockDataWriter.Setup(m => m.RentACarAsync(It.IsAny<Rental>()))
                           .Returns(Task.CompletedTask)
                           .Verifiable();

            var (success, errorMessage) = await _rentManager.RentACarAsync(rent);

            Assert.IsTrue(success);
            _mockDataWriter.Verify();
        }

        [TestMethod]
        public async Task UpdateRentStatus_WhenCalled_UpdatesStatus()
        {
            var rent = new RentACarDTO
            {
                CarId = 1,
                UserId = 1,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(5),
                Status = RentStatus.REQUESTED.ToString()
            };

            var newStatus = RentStatus.COMPLETED;

            _mockRentalStrategy.Setup(s => s.UpdateRentalStatus(It.IsAny<RentACarDTO>(), newStatus)).Verifiable();
            _mockDataWriter.Setup(m => m.UpdateRentAsync(It.IsAny<Rental>())).Returns(Task.CompletedTask).Verifiable();

            var (success, errorMessage) = await _rentManager.UpdateRentStatusAsync(rent, newStatus);

            Assert.IsTrue(success);
            _mockRentalStrategy.Verify();
            _mockDataWriter.Verify();
        }

        [TestMethod]
        public void IsCarAvailable_WhenCarIsNotAvailable_ReturnsFalse()
        {
            var rent = new RentACarDTO
            {
                CarId = 1,
                UserId = 1,
                StartDate = new DateTime(2023, 6, 1),
                EndDate = new DateTime(2023, 6, 10),
                Status = RentStatus.REQUESTED.ToString()
            };

            _rentManager.RentalHistory.Add(rent);

            var result = _rentManager.IsCarAvailable(1, new DateTime(2023, 6, 5), new DateTime(2023, 6, 15));

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsCarAvailable_WhenCarIsAvailable_ReturnsTrue()
        {
            var rent = new RentACarDTO
            {
                CarId = 1,
                UserId = 1,
                StartDate = new DateTime(2023, 6, 1),
                EndDate = new DateTime(2023, 6, 10),
                Status = RentStatus.REQUESTED.ToString()
            };

            _rentManager.RentalHistory.Add(rent);

            var result = _rentManager.IsCarAvailable(1, new DateTime(2023, 6, 11), new DateTime(2023, 6, 15));

            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task LoadRentals_WhenCalled_ReturnsDone()
        {
                    // Create a list of Rental entities
            var rentals = new List<Rental>
            {
                new Rental
                {
                    RentalId = 1,
                    CarId = 1,
                    UserId = 1,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(5),
                    Status = RentStatus.REQUESTED.ToString()
                }
            };

            // Mock the data access method to return a Task with List<Rental>
            _mockDataAccess.Setup(m => m.GetRentalsAsync()).ReturnsAsync(rentals);

            // Mock the people manager to return a list of UserDTOs
             _mockPeopleManager.Setup(m => m.GetAllUsers()).Returns(new List<UserDTO>
            {
                new UserDTO { Id = 1, Email = "user@example.com" }
            });

            // Mock the car manager to return a list of CarDTOs
             _mockCarManager.Setup(m => m.GetCars()).Returns(new List<CarDTO>
            {
                new CarDTO { Id = 1, PricePerDay = 100 }
            });

            // Execute the method
            var (success, errorMessage) = await _rentManager.LoadRentalsAsync();

            // Assert the result
            Assert.IsTrue(success);
            Assert.AreEqual(1, _rentManager.RentalHistory.Count);
        }

    }
}
