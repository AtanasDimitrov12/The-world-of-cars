using Moq;
using AutoMapper;
using DTO;
using InterfaceLayer;
using Manager_Layer;
using Data.Models;

namespace UnitTests
{
    [TestClass]
    public class AdministratorRepositoryTests
    {
        private Mock<IPeopleDataWriter> _mockDataWriter;
        private Mock<IPeopleDataRemover> _mockDataRemover;
        private Mock<IDataAccess> _mockDataAccess;
        private Mock<IMapper> _mockMapper;
        private IAdministratorManager _adminManager;

        [TestInitialize]
        public void Setup()
        {
            _mockDataWriter = new Mock<IPeopleDataWriter>();
            _mockDataRemover = new Mock<IPeopleDataRemover>();
            _mockDataAccess = new Mock<IDataAccess>();
            _mockMapper = new Mock<IMapper>();

            _adminManager = new AdministratorManager(_mockDataAccess.Object, _mockDataWriter.Object, _mockDataRemover.Object, _mockMapper.Object);
        }

        [TestMethod]
        public async Task AddAdminAsync_WhenAdminIsAdded_ReturnsTrue()
        {
            var adminDTO = new AdministratorDTO
            {
                Id = 1,
                Email = "admin@example.com",
                PasswordHash = "passwordHash",
                Salt = "salt",
                Username = "adminName",
                ModifiedOn = DateTime.Now,
                PhoneNumber = "1234567890"
            };

            // Mock the mapping behavior from DTO to Domain object
            _mockMapper.Setup(m => m.Map<Administrator>(It.IsAny<AdministratorDTO>())).Returns(new Administrator());

            // Mock the data writer
            _mockDataWriter.Setup(m => m.AddAdminAsync(It.IsAny<Administrator>())).Returns(Task.CompletedTask);

            var result = await _adminManager.AddAdminAsync(adminDTO);

            Assert.IsTrue(result.Success);
            Assert.AreEqual(null, result.ErrorMessage);
            _mockDataWriter.Verify(m => m.AddAdminAsync(It.IsAny<Administrator>()), Times.Once);
        }

        [TestMethod]
        public async Task RemoveAdminAsync_WhenAdminIsRemoved_ReturnsTrue()
        {
            var adminDTO = new AdministratorDTO
            {
                Id = 1,
                Email = "admin@example.com",
                PasswordHash = "passwordHash",
                Salt = "salt",
                Username = "adminName",
                ModifiedOn = DateTime.Now,
                PhoneNumber = "1234567890"
            };

            // Mock the data remover
            _mockDataRemover.Setup(m => m.RemoveAdminAsync(It.IsAny<int>())).Returns(Task.CompletedTask);

            var result = await _adminManager.RemoveAdminAsync(adminDTO);

            Assert.IsTrue(result.Success);
            Assert.AreEqual(null, result.ErrorMessage);
            _mockDataRemover.Verify(m => m.RemoveAdminAsync(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public async Task UpdateAdminAsync_WhenAdminIsUpdated_ReturnsTrue()
        {
            var adminDTO = new AdministratorDTO
            {
                Id = 1,
                Email = "admin@example.com",
                PasswordHash = "passwordHash",
                Salt = "salt",
                Username = "adminName",
                ModifiedOn = DateTime.Now,
                PhoneNumber = "1234567890"
            };

            // Mock the mapping behavior from DTO to Domain object
            _mockMapper.Setup(m => m.Map<Administrator>(It.IsAny<AdministratorDTO>())).Returns(new Administrator());

            // Mock the data writer
            _mockDataWriter.Setup(m => m.UpdateAdminAsync(It.IsAny<Administrator>())).Returns(Task.CompletedTask);

            var result = await _adminManager.UpdateAdminAsync(adminDTO);

            Assert.IsTrue(result.Success);
            Assert.AreEqual(null, result.ErrorMessage);
            _mockDataWriter.Verify(m => m.UpdateAdminAsync(It.IsAny<Administrator>()), Times.Once);
        }

        [TestMethod]
        public void GetAllAdministrators_WhenCalled_ReturnsAllAdmins()
        {
            var adminDTOList = new List<AdministratorDTO>
            {
                new AdministratorDTO { Id = 1, Email = "admin1@example.com", PasswordHash = "passwordHash", Username = "adminName1", ModifiedOn = DateTime.Now, PhoneNumber = "1234567890", Salt = "salt" },
                new AdministratorDTO { Id = 2, Email = "admin2@example.com", PasswordHash = "passwordHash", Username = "adminName2", ModifiedOn = DateTime.Now, PhoneNumber = "1234567890", Salt = "salt" }
            };

            foreach (var adminDTO in adminDTOList)
            {
                _adminManager.AddAdminAsync(adminDTO).Wait();
            }

            var result = _adminManager.GetAllAdministrators();

            Assert.AreEqual(adminDTOList.Count, result.Count);
        }

        [TestMethod]
        public async Task LoadAdminsAsync_WhenCalled_ReturnsTrue()
        {
            var adminList = new List<Administrator>
            {
                new Administrator { Id = 1, Email = "admin1@example.com", PasswordHash = "passwordHash", Username = "adminName1", ModifiedOn = DateTime.Now, PhoneNumber = "1234567890", Salt = "salt" },
                new Administrator { Id = 2, Email = "admin2@example.com", PasswordHash = "passwordHash", Username = "adminName2", ModifiedOn = DateTime.Now, PhoneNumber = "1234567890", Salt = "salt" }
            };

            _mockDataAccess.Setup(m => m.GetAdministratorsAsync()).ReturnsAsync(adminList);

            // Mock the mapping behavior from Domain to DTO
            _mockMapper.Setup(m => m.Map<AdministratorDTO>(It.IsAny<Administrator>())).Returns((Administrator admin) => new AdministratorDTO
            {
                Id = admin.Id,
                Email = admin.Email,
                PasswordHash = admin.PasswordHash,
                Salt = admin.Salt,
                Username = admin.Username,
                ModifiedOn = admin.ModifiedOn,
                PhoneNumber = admin.PhoneNumber
            });

            var result = await _adminManager.LoadAdminsAsync();

            Assert.IsTrue(result.Success);
            Assert.AreEqual(null, result.ErrorMessage);
            Assert.AreEqual(adminList.Count, _adminManager.GetAllAdministrators().Count);
        }
    }
}
