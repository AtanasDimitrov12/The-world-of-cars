using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using DTO;
using InterfaceLayer;
using ManagerLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace UnitTests
{
    [TestClass]
    public class PeopleManagerTests
    {
        private Mock<IUserManager> _mockUserManager;
        private Mock<IAdministratorManager> _mockAdminManager;
        private PeopleManager _peopleManager;

        [TestInitialize]
        public void Setup()
        {
            _mockUserManager = new Mock<IUserManager>();
            _mockAdminManager = new Mock<IAdministratorManager>();
            var mapper = new Mock<AutoMapper.IMapper>(); // AutoMapper is not necessary for tests
            _peopleManager = new PeopleManager(_mockUserManager.Object, _mockAdminManager.Object, mapper.Object);
        }

        [TestMethod]
        public async Task AddPerson_WhenUserIsAdded_ReturnsTrue()
        {
            var userDto = new UserDTO { Id = 1, Email = "user@example.com", PasswordHash = "password", Username = "username" };
            _mockUserManager.Setup(m => m.AddUserAsync(userDto)).ReturnsAsync((true, string.Empty));

            var result = await _peopleManager.AddPersonAsync(userDto);

            Assert.IsTrue(result.Success);
            Assert.AreEqual(string.Empty, result.ErrorMessage);
        }

        [TestMethod]
        public async Task AddPerson_WhenAdminIsAdded_ReturnsTrue()
        {
            var adminDto = new AdministratorDTO { Id = 1, Email = "admin@example.com", PasswordHash = "password", Username = "adminname" };
            _mockAdminManager.Setup(m => m.AddAdminAsync(adminDto)).ReturnsAsync((true, string.Empty));

            var result = await _peopleManager.AddPersonAsync(adminDto);

            Assert.IsTrue(result.Success);
            Assert.AreEqual(string.Empty, result.ErrorMessage);
        }

        [TestMethod]
        public async Task RemovePerson_WhenUserIsRemoved_ReturnsTrue()
        {
            var userDto = new UserDTO { Id = 1, Email = "user@example.com" };
            _mockUserManager.Setup(m => m.RemoveUserAsync(userDto)).ReturnsAsync((true, string.Empty));

            var result = await _peopleManager.RemovePersonAsync(userDto);

            Assert.IsTrue(result.Success);
            Assert.AreEqual(string.Empty, result.ErrorMessage);
        }

        [TestMethod]
        public async Task RemovePerson_WhenAdminIsRemoved_ReturnsTrue()
        {
            var adminDto = new AdministratorDTO { Id = 1, Email = "admin@example.com" };
            _mockAdminManager.Setup(m => m.RemoveAdminAsync(adminDto)).ReturnsAsync((true, string.Empty));

            var result = await _peopleManager.RemovePersonAsync(adminDto);

            Assert.IsTrue(result.Success);
            Assert.AreEqual(string.Empty, result.ErrorMessage);
        }

        [TestMethod]
        public async Task UpdatePerson_WhenUserIsUpdated_ReturnsTrue()
        {
            var userDto = new UserDTO { Id = 1, Email = "user@example.com", PasswordHash = "newpassword" };
            _mockUserManager.Setup(m => m.UpdateUserAsync(userDto)).ReturnsAsync((true, string.Empty));

            var result = await _peopleManager.UpdatePersonAsync(userDto);

            Assert.IsTrue(result.Success);
            Assert.AreEqual(string.Empty, result.ErrorMessage);
        }

        [TestMethod]
        public async Task UpdatePerson_WhenAdminIsUpdated_ReturnsTrue()
        {
            var adminDto = new AdministratorDTO { Id = 1, Email = "admin@example.com", PasswordHash = "newpassword" };
            _mockAdminManager.Setup(m => m.UpdateAdminAsync(adminDto)).ReturnsAsync((true, string.Empty));

            var result = await _peopleManager.UpdatePersonAsync(adminDto);

            Assert.IsTrue(result.Success);
            Assert.AreEqual(string.Empty, result.ErrorMessage);
        }

        [TestMethod]
        public void AuthenticateUser_WhenCredentialsAreValid_ReturnsTrue()
        {
            var email = "user@example.com";
            var password = "password";
            var (hashedPassword, salt) = _peopleManager.HashPassword(password);

            var userDto = new UserDTO { Id = 1, Email = email, PasswordHash = hashedPassword, Salt = salt };

            _mockUserManager.Setup(m => m.GetAllUsers()).Returns(new List<UserDTO> { userDto });

            var result = _peopleManager.AuthenticateUser(email, password, out string errorMessage);

            Assert.IsTrue(result);
            Assert.AreEqual(string.Empty, errorMessage);
        }

        [TestMethod]
        public void AuthenticateUser_WhenPasswordIsInvalid_ReturnsFalse()
        {
            var email = "user@example.com";
            var password = "wrongpassword";
            var (hashedPassword, salt) = _peopleManager.HashPassword("password");

            var userDto = new UserDTO { Id = 1, Email = email, PasswordHash = hashedPassword, Salt = salt };

            _mockUserManager.Setup(m => m.GetAllUsers()).Returns(new List<UserDTO> { userDto });

            var result = _peopleManager.AuthenticateUser(email, password, out string errorMessage);

            Assert.IsFalse(result);
            Assert.AreEqual("Invalid credentials.", errorMessage);
        }

        [TestMethod]
        public void AuthenticateUser_WhenEmailIsInvalid_ReturnsFalse()
        {
            string errorMessage = string.Empty;
            _mockUserManager.Setup(m => m.GetAllUsers()).Returns(new List<UserDTO>());

            var result = _peopleManager.AuthenticateUser("invalid@example.com", "password", out errorMessage);

            Assert.IsFalse(result);
            Assert.AreEqual("Invalid credentials.", errorMessage);
        }

        [TestMethod]
        public void GetUser_WhenUserExists_ReturnsUser()
        {
            var userDto = new UserDTO { Id = 1, Email = "user@example.com" };
            _mockUserManager.Setup(m => m.GetAllUsers()).Returns(new List<UserDTO> { userDto });

            var result = _peopleManager.GetAllUsers().FirstOrDefault(u => u.Email == "user@example.com");

            Assert.IsNotNull(result);
            Assert.AreEqual(userDto.Email, result.Email);
        }

        [TestMethod]
        public void GetUser_WhenUserDoesNotExist_ReturnsNull()
        {
            _mockUserManager.Setup(m => m.GetAllUsers()).Returns(new List<UserDTO>());

            var result = _peopleManager.GetAllUsers().FirstOrDefault(u => u.Email == "user@example.com");

            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetAllPeople_ReturnsAllPeople()
        {
            var userDto = new UserDTO { Id = 1, Email = "user@example.com" };
            var adminDto = new AdministratorDTO { Id = 1, Email = "admin@example.com" };
            _mockUserManager.Setup(m => m.GetAllUsers()).Returns(new List<UserDTO> { userDto });
            _mockAdminManager.Setup(m => m.GetAllAdministrators()).Returns(new List<AdministratorDTO> { adminDto });

            var result = _peopleManager.GetAllPeople();

            Assert.AreEqual(2, result.Count());
            Assert.IsTrue(result.Any(p => p is UserDTO));
            Assert.IsTrue(result.Any(p => p is AdministratorDTO));
        }
    }
}
