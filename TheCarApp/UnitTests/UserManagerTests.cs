using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using InterfaceLayer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DTO;
using ManagerLayer;
using Data.Models;
using AutoMapper;

namespace UnitTests
{
    [TestClass]
    public class UserManagerTests
    {
        private Mock<IPeopleDataWriter> _mockDataWriter;
        private Mock<IPeopleDataRemover> _mockDataRemover;
        private Mock<IDataAccess> _mockDataAccess;
        private IUserManager _userManager;

        [TestInitialize]
        public void Setup()
        {
            _mockDataWriter = new Mock<IPeopleDataWriter>();
            _mockDataRemover = new Mock<IPeopleDataRemover>();
            _mockDataAccess = new Mock<IDataAccess>();
            var mockMapper = new Mock<AutoMapper.IMapper>();
            _userManager = new UserManager(_mockDataAccess.Object, _mockDataWriter.Object, _mockDataRemover.Object, mockMapper.Object);
        }

        [TestMethod]
        public async Task AddUser_WhenUserIsAdded_ReturnsTrue()
        {
            var userDTO = new UserDTO
            {
                Id = 1,
                Email = "user@example.com",
                PasswordHash = "password",
                Username = "username",
                ModifiedOn = DateTime.Now,
                LicenseNumber = 123456789,
                ProfilePictureFilePath = "path/to/pic"
            };
            string errorMessage = string.Empty;

            _mockDataWriter.Setup(m => m.AddUserAsync(It.IsAny<User>())).Returns(Task.CompletedTask);
            _mockDataWriter.Setup(m => m.UploadProfilePictureAsync(It.IsAny<int>(), It.IsAny<string>())).Returns(Task.CompletedTask);

            (bool result, string Error) = await _userManager.AddUserAsync(userDTO);

            Assert.IsTrue(result);
            Assert.AreEqual(string.Empty, Error);
            _mockDataWriter.Verify(m => m.AddUserAsync(It.IsAny<User>()), Times.Once);
            _mockDataWriter.Verify(m => m.UploadProfilePictureAsync(It.IsAny<int>(), It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public async Task RemoveUser_WhenUserIsRemoved_ReturnsTrue()
        {
            var userDTO = new UserDTO { Id = 1 };
            string errorMessage = string.Empty;

            _mockDataRemover.Setup(m => m.RemoveUserAsync(It.IsAny<int>())).Returns(Task.CompletedTask);

            var result = await _userManager.RemoveUserAsync(userDTO);

            Assert.IsTrue(result.Success);
            Assert.AreEqual(string.Empty, result.ErrorMessage);
            _mockDataRemover.Verify(m => m.RemoveUserAsync(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public async Task UpdateUser_WhenUserIsUpdated_ReturnsTrue()
        {
            var userDTO = new UserDTO
            {
                Id = 1,
                Email = "user@example.com",
                PasswordHash = "password",
                Username = "username",
                ModifiedOn = DateTime.Now,
                LicenseNumber = 123456789,
                ProfilePictureFilePath = "path/to/pic"
            };
            string errorMessage = string.Empty;

            _mockDataWriter.Setup(m => m.UpdateUserAsync(It.IsAny<User>())).Returns(Task.CompletedTask);

            var result = await _userManager.UpdateUserAsync(userDTO);

            Assert.IsTrue(result.Success);
            Assert.AreEqual(string.Empty, result.ErrorMessage);
            _mockDataWriter.Verify(m => m.UpdateUserAsync(It.IsAny<User>()), Times.Once);
        }

        [TestMethod]
        public async Task UploadProfilePicture_WhenCalled_UpdatesProfilePicturePath()
        {
            var userDTO = new UserDTO
            {
                Id = 1,
                Email = "user@example.com",
                PasswordHash = "password",
                Username = "username",
                ModifiedOn = DateTime.Now,
                LicenseNumber = 123456789,
                ProfilePictureFilePath = "path/to/pic"
            };
            string errorMessage = string.Empty;

            _mockDataRemover.Setup(m => m.RemoveProfilePictureAsync(It.IsAny<int>())).Returns(Task.CompletedTask);
            _mockDataWriter.Setup(m => m.UploadProfilePictureAsync(It.IsAny<int>(), It.IsAny<string>())).Returns(Task.CompletedTask);

            var result = await _userManager.UploadProfilePictureAsync(userDTO, "new/path/to/pic");

            Assert.IsTrue(result.Success);
            Assert.AreEqual(string.Empty, result.ErrorMessage);
            Assert.AreEqual("new/path/to/pic", userDTO.ProfilePictureFilePath);
            _mockDataRemover.Verify(m => m.RemoveProfilePictureAsync(It.IsAny<int>()), Times.Once);
            _mockDataWriter.Verify(m => m.UploadProfilePictureAsync(It.IsAny<int>(), It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void GetProfilePicPathById_WhenUserExists_ReturnsPath()
        {
            var userDTO = new UserDTO { Id = 24, ProfilePictureFilePath = "path/to/pic" };
            _userManager.GetAllUsers().Add(userDTO);

            var result = _userManager.GetProfilePicPathById(userDTO.Id);

            Assert.AreEqual("path/to/pic", result);
        }

        [TestMethod]
        public void GetUserNameById_WhenUserExists_ReturnsUserName()
        {
            var userDTO = new UserDTO { Id = 24, Username = "username" };
            _userManager.GetAllUsers().Add(userDTO);

            var result = _userManager.GetUserNameById(userDTO.Id);

            Assert.AreEqual("username", result);
        }

        [TestMethod]
        public async Task LoadUsers_WhenCalled_ReturnsTrue()
        {
            // Create a list of User entities to simulate database data
            var userList = new List<User>
            {
                new User { UserId = 1, Email = "user1@example.com", Username = "username1", ModifiedOn = DateTime.Now },
                new User { UserId = 2, Email = "user2@example.com", Username = "username2", ModifiedOn = DateTime.Now }
            };

            // Mock the data access to return the User list
            _mockDataAccess.Setup(m => m.GetUsersAsync()).ReturnsAsync(userList);

            // Ensure mapping from User to UserDTO is properly handled by the mock mapper
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<UserDTO>(It.IsAny<User>())).Returns((User source) => new UserDTO
            {
                Id = source.UserId,
                Email = source.Email,
                Username = source.Username,
                ModifiedOn = source.ModifiedOn
            });

            // Reinitialize UserManager with the mock mapper
            _userManager = new UserManager(_mockDataAccess.Object, _mockDataWriter.Object, _mockDataRemover.Object, mockMapper.Object);

            string errorMessage = string.Empty;
            var result = await _userManager.LoadUsersAsync();

            Assert.IsTrue(result.Success);
            Assert.AreEqual(string.Empty, result.ErrorMessage);
            Assert.AreEqual(userList.Count, _userManager.GetAllUsers().Count);
        }
    }
}
