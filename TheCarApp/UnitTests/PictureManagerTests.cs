using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ManagerLayer;
using Entity_Layer;
using InterfaceLayer;
using System;
using System.Collections.Generic;
using DTO;

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
            _pictureManager = new PictureManager(_mockDataAccess.Object, _mockDataWriter.Object, _mockDataRemover.Object);
        }

        [TestMethod]
        public void AddPicture_WhenCalled_ReturnsTrue()
        {
            var pic = new Picture(1, "url");

            _mockDataWriter.Setup(m => m.AddPicture(It.IsAny<string>())).Verifiable();

            var result = _pictureManager.AddPicture(pic, out string errorMessage);

            Assert.IsTrue(result);
            Assert.AreEqual(string.Empty, errorMessage);
            Assert.AreEqual(1, _pictureManager.pictures.Count);
        }

        [TestMethod]
        public void AddPicture_WhenExceptionThrown_ReturnsFalse()
        {
            var pic = new Picture(1, "url");

            _mockDataWriter.Setup(m => m.AddPicture(It.IsAny<string>()))
                           .Throws(new Exception("Database error"));

            var result = _pictureManager.AddPicture(pic, out string errorMessage);

            Assert.IsFalse(result);
            Assert.AreEqual("Database error", errorMessage);
        }

        [TestMethod]
        public void RemovePicture_WhenCalled_ReturnsTrue()
        {
            var pic = new Picture(1, "url");
            _pictureManager.pictures.Add(pic);

            _mockDataRemover.Setup(m => m.RemovePicture(It.IsAny<int>())).Verifiable();

            var result = _pictureManager.RemovePicture(pic, out string errorMessage);

            Assert.IsTrue(result);
            Assert.AreEqual(string.Empty, errorMessage);
            Assert.AreEqual(0, _pictureManager.pictures.Count);
        }

        [TestMethod]
        public void RemovePicture_WhenExceptionThrown_ReturnsFalse()
        {
            var pic = new Picture(1, "url");
            _pictureManager.pictures.Add(pic);

            _mockDataRemover.Setup(m => m.RemovePicture(It.IsAny<int>()))
                            .Throws(new Exception("Database error"));

            var result = _pictureManager.RemovePicture(pic, out string errorMessage);

            Assert.IsFalse(result);
            Assert.AreEqual("Database error", errorMessage);
        }

        [TestMethod]
        public void GetPicId_WhenCalled_ReturnsPictureId()
        {
            var url = "url";
            _mockDataWriter.Setup(m => m.GetPictureId(It.IsAny<string>())).Returns(1);

            var result = _pictureManager.GetPicId(url);

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void LoadPictures_WhenCalled_ReturnsTrue()
        {
            var loadedPics = new List<PictureDTO>
            {
                new PictureDTO { Id = 1, PictureURL = "url1" },
                new PictureDTO { Id = 2, PictureURL = "url2" }
            };
            _mockDataAccess.Setup(m => m.GetAllPictures()).Returns(loadedPics);

            var result = _pictureManager.LoadPictures(out string errorMessage);

            Assert.IsTrue(result);
            Assert.AreEqual(string.Empty, errorMessage);
            Assert.AreEqual(2, _pictureManager.pictures.Count);
        }

        [TestMethod]
        public void LoadPictures_WhenExceptionThrown_ReturnsFalse()
        {
            _mockDataAccess.Setup(m => m.GetAllPictures()).Throws(new Exception("Database error"));

            var result = _pictureManager.LoadPictures(out string errorMessage);

            Assert.IsFalse(result);
            Assert.AreEqual("Database error", errorMessage);
        }
    }
}
