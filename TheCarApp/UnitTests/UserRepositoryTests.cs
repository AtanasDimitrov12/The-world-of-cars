using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Repositories;
using Database;
using Entity_Layer;
using InterfaceLayer;
using System;
using System.Collections.Generic;
using DTO;

namespace UnitTests
{
    [TestClass]
    public class UserRepositoryTests
    {
        private Mock<IPeopleDataWriter> _mockDataWriter;
        private Mock<IPeopleDataRemover> _mockDataRemover;
        private Mock<IDataAccess> _mockDataAccess;
        private UserRepository _userRepo;

        [TestInitialize]
        public void Setup()
        {
            _mockDataWriter = new Mock<IPeopleDataWriter>();
            _mockDataRemover = new Mock<IPeopleDataRemover>();
            _mockDataAccess = new Mock<IDataAccess>();
            _userRepo = new UserRepository(_mockDataAccess.Object, _mockDataWriter.Object, _mockDataRemover.Object);
        }

        [TestMethod]
        public void AddUser_WhenUserIsAdded_ReturnsTrue()
        {
            var user = new User(1, "user@example.com", "password", "username", DateTime.Now, 123456789, "salt", "path/to/pic");
            string errorMessage = string.Empty;
            _mockDataWriter.Setup(m => m.AddUser(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<DateTime>(), It.IsAny<string>())).Verifiable();
            _mockDataWriter.Setup(m => m.UploadProfilePicture(It.IsAny<User>(), It.IsAny<string>())).Verifiable();

            var result = _userRepo.AddUser(user, out errorMessage);

            Assert.IsTrue(result);
            Assert.AreEqual(string.Empty, errorMessage);
            _mockDataWriter.Verify(m => m.AddUser(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<DateTime>(), It.IsAny<string>()), Times.Once);
            _mockDataWriter.Verify(m => m.UploadProfilePicture(It.IsAny<User>(), It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void RemoveUser_WhenUserIsRemoved_ReturnsTrue()
        {
            var user = new User(1, "user@example.com", "password", "username", DateTime.Now, 123456789, "salt", "path/to/pic");
            string errorMessage = string.Empty;
            _mockDataRemover.Setup(m => m.RemoveUser(It.IsAny<int>())).Verifiable();

            var result = _userRepo.RemoveUser(user, out errorMessage);

            Assert.IsTrue(result);
            Assert.AreEqual(string.Empty, errorMessage);
            _mockDataRemover.Verify(m => m.RemoveUser(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void UpdateUser_WhenUserIsUpdated_ReturnsTrue()
        {
            var user = new User(1, "user@example.com", "password", "username", DateTime.Now, 123456789, "salt", "path/to/pic");
            string errorMessage = string.Empty;
            _mockDataWriter.Setup(m => m.UpdateUser(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<DateTime>())).Verifiable();

            var result = _userRepo.UpdateUser(user, out errorMessage);

            Assert.IsTrue(result);
            Assert.AreEqual(string.Empty, errorMessage);
            _mockDataWriter.Verify(m => m.UpdateUser(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<DateTime>()), Times.Once);
        }

        [TestMethod]
        public void UploadProfilePicture_WhenCalled_UpdatesProfilePicturePath()
        {
            var user = new User(1, "user@example.com", "password", "username", DateTime.Now, 123456789, "salt", "path/to/pic");
            string errorMessage = string.Empty;
            _mockDataRemover.Setup(m => m.RemoveProfilePicture(It.IsAny<int>())).Verifiable();
            _mockDataWriter.Setup(m => m.UploadProfilePicture(It.IsAny<User>(), It.IsAny<string>())).Verifiable();

            var result = _userRepo.UploadProfilePicture(user, "new/path/to/pic", out errorMessage);

            Assert.IsTrue(result);
            Assert.AreEqual(string.Empty, errorMessage);
            Assert.AreEqual("new/path/to/pic", user.ProfilePicturePath);
            _mockDataRemover.Verify(m => m.RemoveProfilePicture(It.IsAny<int>()), Times.Once);
            _mockDataWriter.Verify(m => m.UploadProfilePicture(It.IsAny<User>(), It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void GetProfilePicPathById_WhenUserExists_ReturnsPath()
        {
            var user = new User(1, "user@example.com", "password", "username", DateTime.Now, 123456789, "salt", "path/to/pic");
            _userRepo.AddUser(user, out _);

            var result = _userRepo.GetProfilePicPathById(1);

            Assert.AreEqual("path/to/pic", result);
        }

        [TestMethod]
        public void GetUserNameById_WhenUserExists_ReturnsUserName()
        {
            var user = new User(1, "user@example.com", "password", "username", DateTime.Now, 123456789, "salt", "path/to/pic");
            _userRepo.AddUser(user, out _);

            var result = _userRepo.GetUserNameById(1);

            Assert.AreEqual("username", result);
        }

        [TestMethod]
        public void GetAllUsers_WhenCalled_ReturnsAllUsers()
        {
            var user1 = new User(1, "user1@example.com", "password", "username1", DateTime.Now, 123456789, "salt", "path/to/pic1");
            var user2 = new User(2, "user2@example.com", "password", "username2", DateTime.Now, 123456789, "salt", "path/to/pic2");
            _userRepo.AddUser(user1, out _);
            _userRepo.AddUser(user2, out _);

            var result = _userRepo.GetAllUsers();

            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void LoadUsers_WhenCalled_ReturnsTrue()
        {
            var userDTOList = new List<UserDTO>
            {
                new UserDTO { Id = 1, email = "user1@example.com", password = "password", Username = "username1", CreatedOn = DateTime.Now, _licenseNumber = 123456789, passSalt = "salt", ProfilePicturePath = "path/to/pic1" },
                new UserDTO { Id = 2, email = "user2@example.com", password = "password", Username = "username2", CreatedOn = DateTime.Now, _licenseNumber = 123456789, passSalt = "salt", ProfilePicturePath = "path/to/pic2" }
            };
            _mockDataAccess.Setup(m => m.GetUsers()).Returns(userDTOList);

            string errorMessage = string.Empty;
            var result = _userRepo.LoadUsers(out errorMessage);

            Assert.IsTrue(result);
            Assert.AreEqual(string.Empty, errorMessage);
            Assert.AreEqual(userDTOList.Count, _userRepo.GetAllUsers().Count);
        }
    }
}
