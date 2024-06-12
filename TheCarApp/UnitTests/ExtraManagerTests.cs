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
    public class ExtraManagerTests
    {
        private Mock<IDataAccess> _mockDataAccess;
        private Mock<ICarDataWriter> _mockDataWriter;
        private Mock<ICarDataRemover> _mockDataRemover;
        private ExtraManager _extraManager;

        [TestInitialize]
        public void Setup()
        {
            _mockDataAccess = new Mock<IDataAccess>();
            _mockDataWriter = new Mock<ICarDataWriter>();
            _mockDataRemover = new Mock<ICarDataRemover>();
            _extraManager = new ExtraManager(_mockDataAccess.Object, _mockDataWriter.Object, _mockDataRemover.Object);
        }

        [TestMethod]
        public void AddExtra_WhenCalled_ReturnsTrue()
        {
            var extra = new Extra("GPS", 1);

            _mockDataWriter.Setup(m => m.AddExtra(It.IsAny<string>())).Verifiable();

            var result = _extraManager.AddExtra(extra, out string errorMessage);

            Assert.IsTrue(result);
            Assert.AreEqual(string.Empty, errorMessage);
            Assert.AreEqual(1, _extraManager.extras.Count);
        }

        [TestMethod]
        public void AddExtra_WhenExceptionThrown_ReturnsFalse()
        {
            var extra = new Extra("GPS", 1);

            _mockDataWriter.Setup(m => m.AddExtra(It.IsAny<string>()))
                           .Throws(new Exception("Database error"));

            var result = _extraManager.AddExtra(extra, out string errorMessage);

            Assert.IsFalse(result);
            Assert.AreEqual("Database error", errorMessage);
        }

        [TestMethod]
        public void RemoveExtra_WhenCalled_ReturnsTrue()
        {
            var extra = new Extra("GPS", 1);
            _extraManager.extras.Add(extra);

            _mockDataRemover.Setup(m => m.RemoveExtra(It.IsAny<int>())).Verifiable();

            var result = _extraManager.RemoveExtra(extra, out string errorMessage);

            Assert.IsTrue(result);
            Assert.AreEqual(string.Empty, errorMessage);
            Assert.AreEqual(0, _extraManager.extras.Count);
        }

        [TestMethod]
        public void RemoveExtra_WhenExceptionThrown_ReturnsFalse()
        {
            var extra = new Extra("GPS", 1);
            _extraManager.extras.Add(extra);

            _mockDataRemover.Setup(m => m.RemoveExtra(It.IsAny<int>()))
                            .Throws(new Exception("Database error"));

            var result = _extraManager.RemoveExtra(extra, out string errorMessage);

            Assert.IsFalse(result);
            Assert.AreEqual("Database error", errorMessage);
        }

        [TestMethod]
        public void GetExtraId_WhenCalled_ReturnsExtraId()
        {
            var extraName = "GPS";
            _mockDataWriter.Setup(m => m.GetExtraId(It.IsAny<string>())).Returns(1);

            var result = _extraManager.GetExtraId(extraName);

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void LoadExtra_WhenCalled_ReturnsTrue()
        {
            var loadExtras = new List<ExtraDTO>
            {
                new ExtraDTO { Id = 1, extraName = "GPS" },
                new ExtraDTO { Id = 2, extraName = "Sunroof" }
            };
            _mockDataAccess.Setup(m => m.GetAllExtras()).Returns(loadExtras);

            var result = _extraManager.LoadExtra(out string errorMessage);

            Assert.IsTrue(result);
            Assert.AreEqual(string.Empty, errorMessage);
            Assert.AreEqual(2, _extraManager.extras.Count);
        }

        [TestMethod]
        public void LoadExtra_WhenExceptionThrown_ReturnsFalse()
        {
            _mockDataAccess.Setup(m => m.GetAllExtras()).Throws(new Exception("Database error"));

            var result = _extraManager.LoadExtra(out string errorMessage);

            Assert.IsFalse(result);
            Assert.AreEqual("Database error", errorMessage);
        }
    }
}
