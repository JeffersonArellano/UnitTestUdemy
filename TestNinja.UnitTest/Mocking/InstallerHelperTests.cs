namespace TestNinja.UnitTest.Mocking
{
    using Moq;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    using TestNinja.Mocking;

    [TestFixture]
    public class InstallerHelperTests
    {
        private Mock<IFileDownloader> fileDownloader;
        private InstallerHelper installerHelper;

        [SetUp]
        public void Setup() 
        {
            fileDownloader = new Mock<IFileDownloader>();
            installerHelper = new InstallerHelper(fileDownloader.Object);
        }

        [Test]
        public void DownloadInstaller_DownloadFileFails_ReturnFalse()
        {
            //Arrange
            fileDownloader.Setup(fd => 
            fd.DownloadFile(It.IsAny<string>(), It.IsAny<string>()))
                .Throws<WebException>();

            //Act
            var  result = installerHelper.DownloadInstaller("customer", "installer");

            //Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void DownloadInstaller_DownloadComplete_ReturnTrue()
        {
            //Act
            var result = installerHelper.DownloadInstaller("customer", "installer");

            //Assert
            Assert.That(result, Is.True);
        }

    }
}
