using Moq;
using ManagerLayer;
using Data.Models;
using InterfaceLayer;
using DTO;
using AutoMapper;

namespace UnitTests
{
    [TestClass]
    public class NewsManagerTests
    {
        private Mock<IDataAccess> _mockDataAccess;
        private Mock<ICarNewsDataWriter> _mockDataWriter;
        private Mock<ICarNewsDataRemover> _mockDataRemover;
        private NewsManager _newsManager;
        private IMapper _mapper;

        [TestInitialize]
        public void Setup()
        {
            _mockDataAccess = new Mock<IDataAccess>();
            _mockDataWriter = new Mock<ICarNewsDataWriter>();
            _mockDataRemover = new Mock<ICarNewsDataRemover>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CarNewsDTO, News>().ReverseMap();
            });

            _mapper = config.CreateMapper();
            _newsManager = new NewsManager(_mockDataAccess.Object, _mockDataWriter.Object, _mockDataRemover.Object, _mapper);
        }

        [TestMethod]
        public async Task AddNews_WhenCalled_ReturnsTrue()
        {
            var carNewsDTO = new CarNewsDTO
            {
                Title = "Test News",
                Author = "Author",
                NewsDescription = "Description",
                ReleaseDate = DateTime.Now,
                ImageURL = "image.jpg",
                ShortIntro = "Intro"
            };

            _mockDataWriter.Setup(m => m.AddCarNewsAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                           .Returns(Task.CompletedTask)
                           .Verifiable();

            _mockDataWriter.Setup(m => m.GetNewsIdAsync(It.IsAny<string>())).ReturnsAsync(1);

            var result = await _newsManager.AddNewsAsync(carNewsDTO);

            Assert.IsTrue(result.Success);
            Assert.AreEqual(string.Empty, result.ErrorMessage);
            Assert.AreEqual(1, carNewsDTO.Id);
        }

        [TestMethod]
        public async Task DeleteNews_WhenCalled_ReturnsTrue()
        {
            var carNewsDTO = new CarNewsDTO
            {
                Id = 1,
                Title = "Test News",
                Comments = new List<CommentDTO> { new CommentDTO { Id = 1, UserId = 1, CommentDate = DateTime.Now, Content = "Test Comment" } }
            };

            _mockDataRemover.Setup(m => m.RemoveCommentAsync(It.IsAny<int>())).Returns(Task.CompletedTask).Verifiable();
            _mockDataRemover.Setup(m => m.RemoveNewsAsync(It.IsAny<int>())).Returns(Task.CompletedTask).Verifiable();

            var result = await _newsManager.DeleteNewsAsync(carNewsDTO);

            Assert.IsTrue(result.Success);
            Assert.AreEqual(string.Empty, result.ErrorMessage);
        }

        [TestMethod]
        public async Task UpdateNews_WhenCalled_ReturnsTrue()
        {
            var carNewsDTO = new CarNewsDTO
            {
                Id = 1,
                Title = "Updated Title"
            };

            _mockDataWriter.Setup(m => m.UpdateNewsAsync(It.IsAny<News>())).Returns(Task.CompletedTask).Verifiable();

            var result = await _newsManager.UpdateNewsAsync(carNewsDTO);

            Assert.IsTrue(result.Success);
            Assert.AreEqual(string.Empty, result.ErrorMessage);
        }

        [TestMethod]
        public void GetNewsById_WhenNewsExists_ReturnsNews()
        {
            var newsId = 1;
            var carNewsDTO = new CarNewsDTO { Id = newsId };
            _newsManager.News.Add(carNewsDTO);

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
        public async Task LoadNews_WhenCalled_ReturnsTrue()
        {
            // Use News (Data.Models) for mock return type
            var carNewsEntities = new List<News>
            {
                new News
                {
                    NewsId = 1,
                    Title = "Test News",
                    Author = "Author",
                    DatePosted = DateTime.Now,
                    NewsDescription = "Description",
                    ImageURL = "image.jpg",
                    ShortIntro = "Intro",
                    Comments = new List<Comment>()
                }
            };

            // Mocking GetCarNewsAsync to return News (entity type)
            _mockDataAccess.Setup(m => m.GetCarNewsAsync()).ReturnsAsync(carNewsEntities);

            var result = await _newsManager.LoadNewsAsync();

            Assert.IsTrue(result.Success);
            Assert.AreEqual(string.Empty, result.ErrorMessage);
            Assert.AreEqual(carNewsEntities.Count, _newsManager.News.Count);
        }

        [TestMethod]
        public async Task LoadNews_WhenExceptionThrown_ReturnsFalse()
        {
            _mockDataAccess.Setup(m => m.GetCarNewsAsync()).ThrowsAsync(new Exception("Database error"));

            var result = await _newsManager.LoadNewsAsync();

            Assert.IsFalse(result.Success);
            Assert.AreEqual("Database error", result.ErrorMessage);
        }
    }
}
