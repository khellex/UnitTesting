using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class VideoServiceTests
    {
        private Mock<IFileReader> _fileReaderMock;
        private VideoService _videoService;
        private Mock<IVideoRepository> _videoRepositoryMock;
        [SetUp]
        public void SetUp()
        {
            _fileReaderMock = new Mock<IFileReader>();
            _videoRepositoryMock = new Mock<IVideoRepository>();
            _videoService = new VideoService(_fileReaderMock.Object, _videoRepositoryMock.Object);
        }
        [Test]
        public void ReadVideoTitle_EmptyFile_ThrowsError()
        {
            _fileReaderMock.Setup(fr => fr.ReadFile("video.txt")).Returns("");

            var result = _videoService.ReadVideoTitle();

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }
        [Test]
        public void ReadVideoTitle_FileHasData_ReturnVideoTitle()
        {
            // Arrange
            var json = "{ \"Title\": \"Inception\" }";
            _fileReaderMock.Setup(fr => fr.ReadFile("video.txt")).Returns(json);

            // Act
            var result = _videoService.ReadVideoTitle();

            // Assert
            Assert.That(result, Is.EqualTo("Inception"));
        }
        [Test]
        public void GetUnprocessedVideosAsCsv_WhenThereAreNoVideos_ReturnsEmptyString()
        {
            _videoRepositoryMock.Setup(v => v.GetUnprocessedVideos()).Returns(new List<Video>());

            var result = _videoService.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.Empty);
        }
        [Test]
        public void GetUnprocessedVideosAsCsv_WhenThereAreUnprocessedVideos_ReturnsStringOfIds()
        {
            _videoRepositoryMock.Setup(v => v.GetUnprocessedVideos()).Returns(new List<Video>{
                new Video { Id = 1},
                new Video { Id = 2},
                new Video { Id = 3},
            });

            var result = _videoService.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo("1,2,3"));
        }
    }
}
