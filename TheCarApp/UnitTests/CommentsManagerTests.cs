using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ManagerLayer;
using Entity_Layer;
using InterfaceLayer;
using System;
using System.Collections.Generic;
using EntityLayout;

namespace UnitTests
{
    [TestClass]
    public class CommentsManagerTests
    {
        private Mock<IDataAccess> _mockDataAccess;
        private Mock<ICarNewsDataWriter> _mockDataWriter;
        private Mock<ICarNewsDataRemover> _mockDataRemover;
        private CommentsManager _commentsManager;

        [TestInitialize]
        public void Setup()
        {
            _mockDataAccess = new Mock<IDataAccess>();
            _mockDataWriter = new Mock<ICarNewsDataWriter>();
            _mockDataRemover = new Mock<ICarNewsDataRemover>();
            _commentsManager = new CommentsManager(_mockDataAccess.Object, _mockDataWriter.Object, _mockDataRemover.Object);
        }

        [TestMethod]
        public void AddComment_WhenCalled_ReturnsTrue()
        {
            var news = new CarNews { Id = 1, Comments = new List<Comment>() };
            var comment = new Comment { UserId = 1, Date = DateTime.Now, Message = "Test Comment" };

            _mockDataWriter.Setup(m => m.AddComment(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<DateTime>(), It.IsAny<string>())).Verifiable();
            _mockDataWriter.Setup(m => m.GetCommentId(It.IsAny<DateTime>())).Returns(1);

            var result = _commentsManager.AddComment(news, comment, out string errorMessage);

            Assert.IsTrue(result);
            Assert.AreEqual(string.Empty, errorMessage);
            Assert.AreEqual(1, comment.Id);
            Assert.AreEqual(1, news.Comments.Count);
        }

        [TestMethod]
        public void AddComment_WhenExceptionThrown_ReturnsFalse()
        {
            var news = new CarNews { Id = 1, Comments = new List<Comment>() };
            var comment = new Comment { UserId = 1, Date = DateTime.Now, Message = "Test Comment" };

            _mockDataWriter.Setup(m => m.AddComment(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<DateTime>(), It.IsAny<string>()))
                           .Throws(new Exception("Database error"));

            var result = _commentsManager.AddComment(news, comment, out string errorMessage);

            Assert.IsFalse(result);
            Assert.AreEqual("Database error", errorMessage);
        }

        [TestMethod]
        public void RemoveComment_WhenCalled_ReturnsTrue()
        {
            var news = new CarNews { Id = 1, Comments = new List<Comment>() };
            var comment = new Comment { Id = 1, UserId = 1, Date = DateTime.Now, Message = "Test Comment" };
            news.Comments.Add(comment);

            _mockDataRemover.Setup(m => m.RemoveComment(It.IsAny<int>())).Verifiable();

            var result = _commentsManager.RemoveComment(news, comment, out string errorMessage);

            Assert.IsTrue(result);
            Assert.AreEqual(string.Empty, errorMessage);
            Assert.AreEqual(0, news.Comments.Count);
        }

        [TestMethod]
        public void RemoveComment_WhenExceptionThrown_ReturnsFalse()
        {
            var news = new CarNews { Id = 1, Comments = new List<Comment>() };
            var comment = new Comment { Id = 1, UserId = 1, Date = DateTime.Now, Message = "Test Comment" };
            news.Comments.Add(comment);

            _mockDataRemover.Setup(m => m.RemoveComment(It.IsAny<int>()))
                            .Throws(new Exception("Database error"));

            var result = _commentsManager.RemoveComment(news, comment, out string errorMessage);

            Assert.IsFalse(result);
            Assert.AreEqual("Database error", errorMessage);
        }
    }
}
