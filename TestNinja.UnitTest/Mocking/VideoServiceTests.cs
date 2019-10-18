using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTest.Mocking
{
    [TestFixture]
    public class VideoServiceTests
    {
        private Mock<IFileReader> fileReader;
        private VideoService service;

        [SetUp]
        public void Setup()
        {
            fileReader = new Mock<IFileReader>();
            service = new VideoService(fileReader.Object);
        }


        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            //Arrange
            fileReader.Setup(fr => fr.Read("Video.txt")).Returns("");

            //Act
            var result = service.ReadVideoTitle();

            //Assert
            Assert.That(result, Does.Contain("error").IgnoreCase);
        }


        //[Test]
        //public void ReadVideoTitle_IfVideoIsNull_RetunTitle()
        //{
        //    //Arrange
        //    var video = new VideoService();
        //    var fakeFileReader = new FakeFileReader();
        //    fakeFileReader.Read("Some Movie");

        //    //Act
        //    var result = video.ReadVideoTitle(fakeFileReader);

        //    //Assert
        //    Assert.That(result, Is.EqualTo(""));
        //}

    }
}
