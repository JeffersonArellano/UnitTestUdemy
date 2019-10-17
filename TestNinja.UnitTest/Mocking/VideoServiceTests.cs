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

        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            //Arrange
            var service = new VideoService(new FakeFileReader());

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
