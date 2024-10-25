using Moq;
using ManagerLayer;
using InterfaceLayer;
using DTO;
using AutoMapper;
using Data.Models;

namespace UnitTests
{
    [TestClass]
    public class ExtraManagerTests
    {
        private Mock<IDataAccess> _mockDataAccess;
        private Mock<ICarDataWriter> _mockDataWriter;
        private Mock<ICarDataRemover> _mockDataRemover;
        private ExtraManager _extraManager;
        private Mock<IMapper> _mockMapper;

        [TestInitialize]
        public void Setup()
        {
            _mockDataAccess = new Mock<IDataAccess>();
            _mockDataWriter = new Mock<ICarDataWriter>();
            _mockDataRemover = new Mock<ICarDataRemover>();
            _mockMapper = new Mock<IMapper>();
            _extraManager = new ExtraManager(_mockDataAccess.Object, _mockDataWriter.Object, _mockDataRemover.Object, _mockMapper.Object);
        }

        [TestMethod]
        public async Task AddExtraAsync_WhenCalled_ReturnsTrue()
        {
            var extraDTO = new ExtraDTO { Id = 1, ExtraName = "GPS" };
            var extraEntity = new CarExtra { CarExtraId = 1, ExtraName = "GPS" };

            // Setup mapping from DTO to Entity
            _mockMapper.Setup(m => m.Map<CarExtra>(It.IsAny<ExtraDTO>())).Returns(extraEntity);

            // Mock data writer behavior
            _mockDataWriter.Setup(m => m.AddExtra(It.IsAny<string>())).Returns(Task.CompletedTask);

            var result = await _extraManager.AddExtraAsync(extraDTO);

            Assert.IsTrue(result.Success);
            Assert.AreEqual(string.Empty, result.ErrorMessage);
            Assert.AreEqual(1, _extraManager.Extras.Count);
        }

        [TestMethod]
        public async Task AddExtraAsync_WhenExceptionThrown_ReturnsFalse()
        {
            var extraDTO = new ExtraDTO { Id = 1, ExtraName = "GPS" };

            // Mock data writer to throw an exception
            _mockDataWriter.Setup(m => m.AddExtra(It.IsAny<string>())).ThrowsAsync(new Exception("Database error"));

            var result = await _extraManager.AddExtraAsync(extraDTO);

            Assert.IsFalse(result.Success);
            Assert.AreEqual("Database error", result.ErrorMessage);
        }

        [TestMethod]
        public async Task RemoveExtraAsync_WhenCalled_ReturnsTrue()
        {
            var extraDTO = new ExtraDTO { Id = 1, ExtraName = "GPS" };
            _extraManager.Extras.Add(extraDTO);

            // Mock data remover behavior
            _mockDataRemover.Setup(m => m.RemoveExtraAsync(It.IsAny<int>())).Returns(Task.CompletedTask);

            var result = await _extraManager.RemoveExtraAsync(extraDTO);

            Assert.IsTrue(result.Success);
            Assert.AreEqual(string.Empty, result.ErrorMessage);
            Assert.AreEqual(0, _extraManager.Extras.Count);
        }

        [TestMethod]
        public async Task RemoveExtraAsync_WhenExceptionThrown_ReturnsFalse()
        {
            var extraDTO = new ExtraDTO { Id = 1, ExtraName = "GPS" };
            _extraManager.Extras.Add(extraDTO);

            // Mock data remover to throw an exception
            _mockDataRemover.Setup(m => m.RemoveExtraAsync(It.IsAny<int>())).ThrowsAsync(new Exception("Database error"));

            var result = await _extraManager.RemoveExtraAsync(extraDTO);

            Assert.IsFalse(result.Success);
            Assert.AreEqual("Database error", result.ErrorMessage);
        }

        [TestMethod]
        public async Task GetExtraIdAsync_WhenCalled_ReturnsExtraId()
        {
            var extraName = "GPS";

            // Mock data writer behavior
            _mockDataWriter.Setup(m => m.GetExtraId(extraName)).ReturnsAsync(1);

            var result = await _extraManager.GetExtraIdAsync(extraName);

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public async Task LoadExtraAsync_WhenCalled_ReturnsTrue()
        {
            // Mock data access behavior: Set the return value to a Task<List<CarExtra>>
            var loadExtras = new List<CarExtra>
            {
                new CarExtra { CarExtraId = 1, ExtraName = "GPS", CarId = 101 },
                new CarExtra { CarExtraId = 2, ExtraName = "Sunroof", CarId = 102 }
            };

            // Ensure that the mock method returns the correct type (Task<List<CarExtra>>)
            _mockDataAccess.Setup(m => m.GetAllExtrasAsync())
                           .ReturnsAsync(loadExtras);

            var result = await _extraManager.LoadExtraAsync();

            Assert.IsTrue(result.Success);
            Assert.AreEqual(string.Empty, result.ErrorMessage);
            Assert.AreEqual(2, _extraManager.Extras.Count); // Verifying that 2 extras were loaded
        }



        [TestMethod]
        public async Task LoadExtraAsync_WhenExceptionThrown_ReturnsFalse()
        {
            // Mock data access to throw an exception
            _mockDataAccess.Setup(m => m.GetAllExtrasAsync()).ThrowsAsync(new Exception("Database error"));

            var result = await _extraManager.LoadExtraAsync();

            Assert.IsFalse(result.Success);
            Assert.AreEqual("Database error", result.ErrorMessage);
        }
    }
}
