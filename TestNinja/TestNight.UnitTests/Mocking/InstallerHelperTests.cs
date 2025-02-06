using Moq;
using NUnit.Framework;
using System;
using System.Net;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class InstallerHelperTests
    {
        private Mock<IFileDownloader> _downloaderMock;
        private InstallerHelper _installerHelper;
        [SetUp]
        public void SetUp()
        {
            _downloaderMock = new Mock<IFileDownloader>();
            _installerHelper = new InstallerHelper( _downloaderMock.Object );
        }
        [Test]
        public void DownloadInstaller_WhenDownloadFails_ReturnsFalse()
        {
            _downloaderMock.Setup(d => d.FileDownloader(It.IsAny<string>(), It.IsAny<string>())).Throws<WebException>();

            var result = _installerHelper.DownloadInstaller("customer", "installer");

            Assert.IsFalse( result );
        }
        [Test]
        public void DownloadInstaller_WhenDownloadIsSuccessful_ReturnsTrue()
        {
            var result = _installerHelper.DownloadInstaller("customer", "installer");

            Assert.IsTrue(result);
        }
    }
}
