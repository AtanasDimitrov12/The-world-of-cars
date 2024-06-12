using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Entity_Layer;
using Entity_Layer.Interfaces;
using InterfaceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using EntityLayout;
using DTO;

namespace UnitTests
{
    [TestClass]
    public class NewsManagerTests
    {
        private Mock<IDataAccess> _mockDataAccess;
        private Mock<ICarNewsDataWriter> _mockDataWriter;
        private Mock<ICarNewsDataRemover> _mockDataRemover;
        private NewsManager _newsManager;

        [TestInitialize]
        public void Setup()
        {
            _mockDataAccess = new Mock<IDataAccess>();
            _mockDataWriter = new Mock<ICarNewsDataWriter>();
            _mockDataRemover = new Mock<ICarNewsDataRemover>();
            _newsManager = new NewsManager(_mockDataAccess.Object, _mockDataWriter.Object, _mockDataRemover.Object);
        }

        [TestMethod]
        public void AddNews_WhenCalled_ReturnsTrue()
        {
            var carnews = new CarNews { Title = "Test News" };

            _mockDataWriter.Setup(m => m.AddCarNews(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                           .Verifiable();
            _mockDataWriter.Setup(m => m.GetNewsId(It.IsAny<string>())).Returns(1);

            var result = _newsManager.AddNews(carnews, out string errorMessage);

            Assert.IsTrue(result);
            Assert.AreEqual(string.Empty, errorMessage);
            Assert.AreEqual(1, carnews.Id);
        }

        [TestMethod]
        public void DeleteNews_WhenCalled_ReturnsTrue()
        {
            var carnews = new CarNews { Id = 1, Comments = new List<Comment> { new Comment(1, 1, DateTime.Now, "Test Comment") } };
            _mockDataRemover.Setup(m => m.RemoveComment(It.IsAny<int>())).Verifiable();
            _mockDataRemover.Setup(m => m.RemoveNews(It.IsAny<int>())).Verifiable();

            var result = _newsManager.DeleteNews(carnews, out string errorMessage);

            Assert.IsTrue(result);
            Assert.AreEqual(string.Empty, errorMessage);
        }

        [TestMethod]
        public void UpdateNews_WhenCalled_ReturnsTrue()
        {
            var carnews = new CarNews { Id = 1, Title = "Updated Title" };
            _mockDataWriter.Setup(m => m.UpdateNews(carnews)).Verifiable();

            var result = _newsManager.UpdateNews(carnews, out string errorMessage);

            Assert.IsTrue(result);
            Assert.AreEqual(string.Empty, errorMessage);
        }

        [TestMethod]
        public void GetNewsById_WhenNewsExists_ReturnsNews()
        {
            var newsId = 1;
            var carnews = new CarNews { Id = newsId };
            _newsManager.news.Add(carnews);

            var result = _newsManager.GetNewsById(newsId);

            Assert.IsNotNull(result);
            Assert.AreEqual(newsId, result.Id);
        }

        [TestMethod]
        public void GetNewsById_WhenNewsDoesNotExist_ReturnsNull()
        {
            var newsId = 1;

            var result = _newsManager.GetNewsById(newsId);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void LoadNews_WhenCalled_ReturnsTrue()
        {
            var carNewsDTOs = new List<CarNewsDTO>
            {
                new CarNewsDTO
                {
                    Id = 1,
                    Title = "Test News",
                    Author = "Author",
                    ReleaseDate = DateTime.Now,
                    NewsDescription = "Description",
                    ImageURL = "image.jpg",
                    ShortIntro = "Intro",
                    comments = new List<CommentDTO>()
                }
            };
            _mockDataAccess.Setup(m => m.GetCarNews()).Returns(carNewsDTOs);

            var result = _newsManager.LoadNews(out string errorMessage);

            Assert.IsTrue(result);
            Assert.AreEqual(string.Empty, errorMessage);
            Assert.AreEqual(carNewsDTOs.Count, _newsManager.news.Count);
        }

        [TestMethod]
        public void LoadNews_WhenExceptionThrown_ReturnsFalse()
        {
            _mockDataAccess.Setup(m => m.GetCarNews()).Throws(new Exception("Database error"));

            var result = _newsManager.LoadNews(out string errorMessage);

            Assert.IsFalse(result);
            Assert.AreEqual("Database error", errorMessage);
        }
    }
}
