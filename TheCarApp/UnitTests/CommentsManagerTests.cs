using Moq;
using ManagerLayer;
using InterfaceLayer;
using DTO;
using AutoMapper;
using Data.Models;

namespace UnitTests
{
    [TestClass]
    public class CommentsManagerTests
    {
        private Mock<ICarNewsDataWriter> _mockDataWriter;
        private Mock<ICarNewsDataRemover> _mockDataRemover;
        private ICommentsManager _commentsManager;
        private Mock<IMapper> _mockMapper;

        [TestInitialize]
        public void Setup()
        {
            _mockDataWriter = new Mock<ICarNewsDataWriter>();
            _mockDataRemover = new Mock<ICarNewsDataRemover>();
            _mockMapper = new Mock<IMapper>();
            _commentsManager = new CommentsManager(_mockDataWriter.Object, _mockDataRemover.Object, _mockMapper.Object);
        }

        [TestMethod]
        public async Task AddCommentAsync_WhenCalled_ReturnsTrue()
        {
            var newsDTO = new CarNewsDTO() { Id = 1, Comments = new List<CommentDTO>(), NrOfComments = 0 };
            var commentDTO = new CommentDTO() { UserId = 1, CommentDate = DateTime.Now, Content = "Test Comment" };
            var comment = new Comment { UserId = 1, CommentDate = commentDTO.CommentDate, Content = "Test Comment" };

            // Setup mapping from CommentDTO to Comment entity
            _mockMapper.Setup(m => m.Map<Comment>(It.IsAny<CommentDTO>())).Returns(comment);

            // Mock the data writer behavior
            _mockDataWriter.Setup(m => m.AddCommentAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<DateTime>(), It.IsAny<string>()))
                           .Returns(Task.CompletedTask);
            _mockDataWriter.Setup(m => m.GetCommentIdAsync(It.IsAny<DateTime>())).ReturnsAsync(1);

            var result = await _commentsManager.AddCommentAsync(newsDTO, commentDTO);

            Assert.IsTrue(result.Success);
            Assert.IsNull(result.ErrorMessage);
            Assert.AreEqual(1, commentDTO.Id);
            Assert.AreEqual(1, newsDTO.Comments.Count);
            Assert.AreEqual(1, newsDTO.NrOfComments);

            // Verify that AddCommentAsync and GetCommentIdAsync were called correctly
            _mockDataWriter.Verify(m => m.AddCommentAsync(newsDTO.Id, commentDTO.UserId, commentDTO.CommentDate, commentDTO.Content), Times.Once);
            _mockDataWriter.Verify(m => m.GetCommentIdAsync(commentDTO.CommentDate), Times.Once);
        }

        [TestMethod]
        public async Task AddCommentAsync_WhenExceptionThrown_ReturnsFalse()
        {
            var newsDTO = new CarNewsDTO { Id = 1, ImageURL = "file/to/path", Comments = new List<CommentDTO>() };
            var commentDTO = new CommentDTO { UserId = 1, CommentDate = DateTime.Now, Content = "Test Comment" };

            // Mock the data writer behavior to throw an exception
            _mockDataWriter.Setup(m => m.AddCommentAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<DateTime>(), It.IsAny<string>()))
                           .ThrowsAsync(new Exception("Object reference not set to an instance of an object."));

            var result = await _commentsManager.AddCommentAsync(newsDTO, commentDTO);

            // Check if the exception is handled correctly and the proper error message is returned
            Assert.IsFalse(result.Success);
            Assert.AreEqual("Object reference not set to an instance of an object.", result.ErrorMessage);

            // Verify that AddCommentAsync was called and failed as expected
            _mockDataWriter.Verify(m => m.AddCommentAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<DateTime>(), It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public async Task RemoveCommentAsync_WhenCalled_ReturnsTrue()
        {
            var newsDTO = new CarNewsDTO { Id = 1, Comments = new List<CommentDTO>() };
            var commentDTO = new CommentDTO { Id = 1, UserId = 1, CommentDate = DateTime.Now, Content = "Test Comment" };
            newsDTO.Comments.Add(commentDTO);
            newsDTO.NrOfComments = 1;

            // Mock the data remover behavior
            _mockDataRemover.Setup(m => m.RemoveCommentAsync(It.IsAny<int>())).Returns(Task.CompletedTask);

            var result = await _commentsManager.RemoveCommentAsync(newsDTO, commentDTO);

            Assert.IsTrue(result.Success);
            Assert.IsNull(result.ErrorMessage);
            Assert.AreEqual(0, newsDTO.Comments.Count);
            Assert.AreEqual(0, newsDTO.NrOfComments);

            // Verify that RemoveCommentAsync was called correctly
            _mockDataRemover.Verify(m => m.RemoveCommentAsync(commentDTO.Id), Times.Once);
        }

        [TestMethod]
        public async Task RemoveCommentAsync_WhenExceptionThrown_ReturnsFalse()
        {
            var newsDTO = new CarNewsDTO { Id = 1, Comments = new List<CommentDTO>() };
            var commentDTO = new CommentDTO { Id = 1, UserId = 1, CommentDate = DateTime.Now, Content = "Test Comment" };
            newsDTO.Comments.Add(commentDTO);

            // Mock the data remover behavior to throw an exception
            _mockDataRemover.Setup(m => m.RemoveCommentAsync(It.IsAny<int>())).ThrowsAsync(new Exception("Object reference not set to an instance of an object."));

            var result = await _commentsManager.RemoveCommentAsync(newsDTO, commentDTO);

            Assert.IsFalse(result.Success);
            Assert.AreEqual("Object reference not set to an instance of an object.", result.ErrorMessage);

            // Verify that RemoveCommentAsync was called and failed as expected
            _mockDataRemover.Verify(m => m.RemoveCommentAsync(commentDTO.Id), Times.Once);
        }
    }
}
