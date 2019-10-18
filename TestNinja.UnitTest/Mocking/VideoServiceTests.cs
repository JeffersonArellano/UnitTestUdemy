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
        private VideoService videoService;
        private Mock<IFileReader> fileReader;
        private Mock<IVideoRepository> repository;

        [SetUp]
        public void Setup()
        {
            fileReader = new Mock<IFileReader>();
            repository = new Mock<IVideoRepository>();
            videoService = new VideoService(fileReader.Object, repository.Object);
        }

        //[Test]
        //public void ReadVideoTitle_EmptyFile_ReturnError()
        //{
        //    //Arrange
        //    fileReader.Setup(fr => fr.Read("Video.txt")).Returns("");

        //    //Act
        //    var result = videoService.ReadVideoTitle();

        //    //Assert
        //    Assert.That(result, Does.Contain("error").IgnoreCase);
        //}


        [Test]
        public void GetUnprocessedVideosAsCsv_AllVideosAreProcessed_ReturnEmptyString()
        {
            //Arrange 
            repository.Setup(r => r.GetUnprocessVideos()).Returns(new List<Video>());

            //Act
            var result = videoService.GetUnprocessedVideosAsCsv();

            //Assert         
            Assert.That(result, Is.EqualTo(""));
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_AFewUnProcessVideos_ReturnStringWithIdOfUnproccessVideos()
        {
            //Arrange 
            repository.Setup(r => r.GetUnprocessVideos()).Returns(new List<Video>
            {
                new  Video{ Id = 1  },
                new  Video{ Id = 2  },
                new  Video{ Id = 3  },
            });

            //Act
            var result = videoService.GetUnprocessedVideosAsCsv();

            //Assert         
            Assert.That(result, Is.EqualTo("1,2,3"));
        }

    }
}
