using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Repositories;
using Database;
using Entity_Layer;
using InterfaceLayer;
using System.Collections.Generic;
using DTO;
using ManagerLayer;
using Manager_Layer;

namespace UnitTests
{
    [TestClass]
    public class AdministratorRepositoryTests
    {
        private Mock<IPeopleDataWriter> _mockDataWriter;
        private Mock<IPeopleDataRemover> _mockDataRemover;
        private Mock<IDataAccess> _mockDataAccess;
        private IAdministratorRepository _adminRepo;

        [TestInitialize]
        public void Setup()
        {
            _mockDataWriter = new Mock<IPeopleDataWriter>();
            _mockDataRemover = new Mock<IPeopleDataRemover>();
            _mockDataAccess = new Mock<IDataAccess>();
            _adminRepo = new AdministratorRepository(_mockDataAccess.Object, _mockDataWriter.Object, _mockDataRemover.Object);
        }

        [TestMethod]
        public void AddAdmin_WhenAdminIsAdded_ReturnsTrue()
        {
            var admin = new Administrator(1, "admin@example.com", "password", "adminName", DateTime.Now, "1234567890", "salt");
            string errorMessage = string.Empty;
            _mockDataWriter.Setup(m => m.AddAdmin(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<string>())).Verifiable();

            var result = _adminRepo.AddAdmin(admin, out errorMessage);

            Assert.IsTrue(result);
            Assert.AreEqual(string.Empty, errorMessage);
            _mockDataWriter.Verify(m => m.AddAdmin(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void RemoveAdmin_WhenAdminIsRemoved_ReturnsTrue()
        {
            var admin = new Administrator(1, "admin@example.com", "password", "adminName", DateTime.Now, "1234567890", "salt");
            string errorMessage = string.Empty;
            _mockDataRemover.Setup(m => m.RemoveAdmin(It.IsAny<int>())).Verifiable();

            var result = _adminRepo.RemoveAdmin(admin, out errorMessage);

            Assert.IsTrue(result);
            Assert.AreEqual(string.Empty, errorMessage);
            _mockDataRemover.Verify(m => m.RemoveAdmin(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void UpdateAdmin_WhenAdminIsUpdated_ReturnsTrue()
        {
            var admin = new Administrator(1, "admin@example.com", "password", "adminName", DateTime.Now, "1234567890", "salt");
            string errorMessage = string.Empty;
            _mockDataWriter.Setup(m => m.UpdateAdministration(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<string>())).Verifiable();

            var result = _adminRepo.UpdateAdmin(admin, out errorMessage);

            Assert.IsTrue(result);
            Assert.AreEqual(string.Empty, errorMessage);
            _mockDataWriter.Verify(m => m.UpdateAdministration(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void GetAllAdministrators_WhenCalled_ReturnsAllAdmins()
        {
            var adminList = new List<Administrator>
            {
                new Administrator(1, "admin1@example.com", "password", "adminName1", DateTime.Now, "1234567890", "salt"),
                new Administrator(2, "admin2@example.com", "password", "adminName2", DateTime.Now, "1234567890", "salt")
            };
            foreach (var admin in adminList)
            {
                _adminRepo.AddAdmin(admin, out _);
            }

            var result = _adminRepo.GetAllAdministrators();

            Assert.AreEqual(adminList.Count, result.Count);
        }

        [TestMethod]
        public void LoadAdmins_WhenCalled_ReturnsTrue()
        {
            var adminDTOList = new List<AdministratorDTO>
            {
                new AdministratorDTO { Id = 1, email = "admin1@example.com", password = "password", Username = "adminName1", CreatedOn = DateTime.Now, _phoneNumber = "1234567890", passSalt = "salt" },
                new AdministratorDTO { Id = 2, email = "admin2@example.com", password = "password", Username = "adminName2", CreatedOn = DateTime.Now, _phoneNumber = "1234567890", passSalt = "salt" }
            };
            _mockDataAccess.Setup(m => m.GetAdministrators()).Returns(adminDTOList);

            string errorMessage = string.Empty;
            var result = _adminRepo.LoadAdmins(out errorMessage);

            Assert.IsTrue(result);
            Assert.AreEqual(string.Empty, errorMessage);
            Assert.AreEqual(adminDTOList.Count, _adminRepo.GetAllAdministrators().Count);
        }
    }
}
