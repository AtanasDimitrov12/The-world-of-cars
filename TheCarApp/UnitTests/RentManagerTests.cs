using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ManagerLayer;
using Entity_Layer;
using Entity_Layer.Enums;
using InterfaceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using EntityLayout;
using ManagerLayer.Strategy;
using DTO;
using Manager_Layer;

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

            _rentManager = new RentManager(_mockDataAccess.Object, _mockDataWriter.Object, _mockDataRemover.Object, _mockPeopleManager.Object, _mockCarManager.Object, _mockRentalStrategyFactory.Object);
        }

        [TestMethod]
        public void CalculatePrice_WhenCalled_ReturnsExpectedPrice()
        {
            var user = new User(1, "user@example.com", "password", "username", DateTime.Now, 12345, "salt", "/path/to/profile");
            decimal basePrice = 100m;
            DateTime startDate = new DateTime(2023, 10, 1);
            DateTime endDate = new DateTime(2023, 10, 10);
            int days = (int)(endDate - startDate).TotalDays;
            int discount = 5;
            decimal expectedPrice = 900m;

            _mockRentalStrategy.Setup(s => s.CalculateRentalPrice(basePrice, days, discount))
                               .Returns(expectedPrice);

            var result = _rentManager.CalculatePrice(user, basePrice, startDate, endDate);

            Assert.AreEqual(expectedPrice, result);
        }

        [TestMethod]
        public void CheckForDiscount_WhenUserHasNoRents_ReturnsZero()
        {
            var user = new User(1, "user@example.com", "password", "username", DateTime.Now, 12345, "salt", "/path/to/profile");
            _rentManager.rentalHistory = new List<RentACar>();

            var result = _rentManager.CheckForDiscount(user);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CheckForDiscount_WhenUserHasRents_ReturnsExpectedDiscount()
        {
            var user = new User(1, "user@example.com", "password", "username", DateTime.Now, 12345, "salt", "/path/to/profile");
            _rentManager.rentalHistory = new List<RentACar>
            {
                new RentACar { user = user, RentStatus = RentStatus.COMPLETED },
                new RentACar { user = user, RentStatus = RentStatus.COMPLETED },
                new RentACar { user = user, RentStatus = RentStatus.COMPLETED },
                new RentACar { user = user, RentStatus = RentStatus.COMPLETED },
                new RentACar { user = user, RentStatus = RentStatus.COMPLETED },
                new RentACar { user = user, RentStatus = RentStatus.COMPLETED },
                new RentACar { user = user, RentStatus = RentStatus.COMPLETED },
                new RentACar { user = user, RentStatus = RentStatus.COMPLETED },
                new RentACar { user = user, RentStatus = RentStatus.COMPLETED },
                new RentACar { user = user, RentStatus = RentStatus.COMPLETED }
            };

            var result = _rentManager.CheckForDiscount(user);

            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void RentACar_WhenCalled_ReturnsDone()
        {
            var rent = new RentACar
            {
                car = new Car { Id = 1 },
                user = new User(1, "user@example.com", "password", "username", DateTime.Now, 12345, "salt", "/path/to/profile"),
                StartDate = DateTime.Now,
                ReturnDate = DateTime.Now.AddDays(5),
                RentStatus = RentStatus.REQUESTED
            };

            _mockDataWriter.Setup(m => m.RentACar(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<string>()))
                           .Verifiable();

            var result = _rentManager.RentACar(rent);

            Assert.AreEqual("done", result);
            _mockDataWriter.Verify();
        }

        [TestMethod]
        public void UpdateRentStatus_WhenCalled_UpdatesStatus()
        {
            var rent = new RentACar
            {
                car = new Car { Id = 1 },
                user = new User(1, "user@example.com", "password", "username", DateTime.Now, 12345, "salt", "/path/to/profile"),
                StartDate = DateTime.Now,
                ReturnDate = DateTime.Now.AddDays(5),
                RentStatus = RentStatus.REQUESTED
            };

            var newStatus = RentStatus.COMPLETED;

            _mockRentalStrategy.Setup(s => s.UpdateRentalStatus(rent, newStatus)).Verifiable();
            _mockDataWriter.Setup(m => m.UpdateRent(It.IsAny<RentACar>())).Verifiable();

            _rentManager.UpdateRentStatus(rent, newStatus);

            _mockRentalStrategy.Verify();
            _mockDataWriter.Verify();
        }


        [TestMethod]
        public void IsCarAvailable_WhenCarIsNotAvailable_ReturnsFalse()
        {
            var rent = new RentACar
            {
                car = new Car { Id = 1 },
                user = new User(1, "user@example.com", "password", "username", DateTime.Now, 12345, "salt", "/path/to/profile"),
                StartDate = new DateTime(2023, 6, 1),
                ReturnDate = new DateTime(2023, 6, 10),
                RentStatus = RentStatus.REQUESTED
            };

            _rentManager.rentalHistory.Add(rent);

            var result = _rentManager.IsCarAvailable(1, new DateTime(2023, 6, 5), new DateTime(2023, 6, 15));

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsCarAvailable_WhenCarIsAvailable_ReturnsTrue()
        {
            var rent = new RentACar
            {
                car = new Car { Id = 1 },
                user = new User(1, "user@example.com", "password", "username", DateTime.Now, 12345, "salt", "/path/to/profile"),
                StartDate = new DateTime(2023, 6, 1),
                ReturnDate = new DateTime(2023, 6, 10),
                RentStatus = RentStatus.REQUESTED
            };

            _rentManager.rentalHistory.Add(rent);

            var result = _rentManager.IsCarAvailable(1, new DateTime(2023, 6, 11), new DateTime(2023, 6, 15));

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void LoadRentals_WhenCalled_ReturnsDone()
        {
            var rentals = new List<RentACarDTO>
            {
                new RentACarDTO
                {
                    Id = 1,
                    CarId = 1,
                    UserID = 1,
                    StartDate = DateTime.Now,
                    ReturnDate = DateTime.Now.AddDays(5),
                    Status = "REQUESTED"
                }
            };

            var user = new User(1, "user@example.com", "password", "username", DateTime.Now, 12345, "salt", "/path/to/profile");
            var car = new Car { Id = 1, PricePerDay = 100 };

            _mockDataAccess.Setup(m => m.GetRentals()).Returns(rentals);
            _mockPeopleManager.Setup(m => m.GetAllUsers()).Returns(new List<User> { user });
            _mockCarManager.Setup(m => m.GetCars()).Returns(new List<Car> { car });
            _mockRentalStrategy.Setup(s => s.CalculateRentalPrice(It.IsAny<decimal>(), It.IsAny<int>(), It.IsAny<int>())).Returns(500);

            var result = _rentManager.LoadRentals();

            Assert.AreEqual("done", result);
            Assert.AreEqual(1, _rentManager.rentalHistory.Count);
        }
    }
}
