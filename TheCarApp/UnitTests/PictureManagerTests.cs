using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ManagerLayer;
using InterfaceLayer;
using DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Models;

namespace UnitTests
{
    [TestClass]
    public class PictureManagerTests
    {
        private Mock<IDataAccess> _mockDataAccess;
        private Mock<ICarDataWriter> _mockDataWriter;
        private Mock<ICarDataRemover> _mockDataRemover;
        private PictureManager _pictureManager;

        [TestInitialize]
        public void Setup()
        {
            _mockDataAccess = new Mock<IDataAccess>();
            _mockDataWriter = new Mock<ICarDataWriter>();
            _mockDataRemover = new Mock<ICarDataRemover>();
            var mapper = new Mock<AutoMapper.IMapper>(); // Mocked mapper for unit tests
            _pictureManager = new PictureManager(_mockDataAccess.Object, _mockDataWriter.Object, _mockDataRemover.Object, mapper.Object);
        }

        [TestMethod]
        public async Task AddPicture_WhenCalled_ReturnsTrue()
        {
            var picDTO = new PictureDTO { Id = 1, PictureURL = "url" };

            _mockDataWriter.Setup(m => m.AddPicture(It.IsAny<string>())).Returns(Task.CompletedTask);

            var result = await _pictureManager.AddPictureAsync(picDTO);

            Assert.IsTrue(result.Success);
            Assert.AreEqual(string.Empty, result.ErrorMessage);
            Assert.AreEqual(1, _pictureManager.Pictures.Count);
        }

        [TestMethod]
        public async Task AddPicture_WhenExceptionThrown_ReturnsFalse()
        {
            var picDTO = new PictureDTO { Id = 1, PictureURL = "url" };

            _mockDataWriter.Setup(m => m.AddPicture(It.IsAny<string>())).ThrowsAsync(new Exception("Database error"));

            var result = await _pictureManager.AddPictureAsync(picDTO);

            Assert.IsFalse(result.Success);
            Assert.AreEqual("Database error", result.ErrorMessage);
        }

        [TestMethod]
        public async Task RemovePicture_WhenCalled_ReturnsTrue()
        {
            var picDTO = new PictureDTO { Id = 1, PictureURL = "url" };
            _pictureManager.Pictures.Add(picDTO);

            _mockDataRemover.Setup(m => m.RemovePictureAsync(It.IsAny<int>())).Returns(Task.CompletedTask);

            var result = await _pictureManager.RemovePictureAsync(picDTO);

            Assert.IsTrue(result.Success);
            Assert.AreEqual(string.Empty, result.ErrorMessage);
            Assert.AreEqual(0, _pictureManager.Pictures.Count);
        }

        [TestMethod]
        public async Task RemovePicture_WhenExceptionThrown_ReturnsFalse()
        {
            var picDTO = new PictureDTO { Id = 1, PictureURL = "url" };
            _pictureManager.Pictures.Add(picDTO);

            _mockDataRemover.Setup(m => m.RemovePictureAsync(It.IsAny<int>())).ThrowsAsync(new Exception("Database error"));

            var result = await _pictureManager.RemovePictureAsync(picDTO);

            Assert.IsFalse(result.Success);
            Assert.AreEqual("Database error", result.ErrorMessage);
        }

        [TestMethod]
        public async Task GetPicId_WhenCalled_ReturnsPictureId()
        {
            var url = "url";
            _mockDataWriter.Setup(m => m.GetPictureId(It.IsAny<string>())).ReturnsAsync(1);

            var result = await _pictureManager.GetPicIdAsync(url);

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public async Task LoadPictures_WhenCalled_ReturnsTrue()
        {
            var loadedPics = new List<CarPicture> // Mock the return of CarPicture entities
            {
                new CarPicture { CarPictureId = 1, PictureURL = "url1" },
                new CarPicture { CarPictureId = 2, PictureURL = "url2" }
            };

            // Setup mock to return CarPicture list
            _mockDataAccess.Setup(m => m.GetAllPicturesAsync()).ReturnsAsync(loadedPics);

            var result = await _pictureManager.LoadPicturesAsync();

            Assert.IsTrue(result.Success);
            Assert.AreEqual(string.Empty, result.ErrorMessage);
            Assert.AreEqual(2, _pictureManager.Pictures.Count);
        }

        [TestMethod]
        public async Task LoadPictures_WhenExceptionThrown_ReturnsFalse()
        {
            _mockDataAccess.Setup(m => m.GetAllPicturesAsync()).ThrowsAsync(new Exception("Database error"));

            var result = await _pictureManager.LoadPicturesAsync();

            Assert.IsFalse(result.Success);
            Assert.AreEqual("Database error", result.ErrorMessage);
        }
    }
}
