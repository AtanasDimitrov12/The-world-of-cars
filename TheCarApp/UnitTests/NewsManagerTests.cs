using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Entity_Layer;
using InterfaceLayer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class NewsManagerTests
    {
        private Mock<IDataAccess> _mockDataAccess;
        private Mock<IDataWriter> _mockDataWriter;
        private Mock<IDataRemover> _mockDataRemover;
        private NewsManager _newsManager;

        [TestInitialize]
        public void Setup()
        {
            _mockDataAccess = new Mock<IDataAccess>();
            _mockDataWriter = new Mock<IDataWriter>();
            _mockDataRemover = new Mock<IDataRemover>();
            _newsManager = new NewsManager(_mockDataAccess.Object, _mockDataWriter.Object, _mockDataRemover.Object);
        }

        [TestMethod]
        public void AddNews_WhenCalled_ExpectedBehavior()
        {
            // Arrange
            var news = new CarNews { Title = "New Model Release", Author = "Car Company" };
            _mockDataWriter.Setup(x => x.AddCarNews(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns("done");
            _mockDataWriter.Setup(x => x.GetNewsId(It.IsAny<string>())).Returns("1");

            // Act
            var result = _newsManager.AddNews(news);

            // Assert
            Assert.AreEqual("done", result);
            Assert.AreEqual(1, news.Id);
        }

        [TestMethod]
        public void DeleteNews_WhenCalled_ReturnsDone()
        {
            // Arrange
            var news = new CarNews { Id = 1 };
            _mockDataRemover.Setup(x => x.RemoveNews(news.Id)).Returns("done");

            // Act
            var result = _newsManager.DeleteNews(news);

            // Assert
            Assert.AreEqual("done", result);
        }


        [TestMethod]
        public void UpdateNews_WhenCalled_ReturnsDone()
        {
            // Arrange
            var news = new CarNews { Id = 1, Title = "Updated News" };
            _mockDataWriter.Setup(x => x.UpdateNews(news)).Returns("done");

            // Act
            var result = _newsManager.UpdateNews(news);

            // Assert
            Assert.AreEqual("done", result);
        }


    }
}
