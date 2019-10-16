using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTest
{

    [TestFixture]
    public class ErrorLoggerTests
    {
        [Test]
        public void Log_WhenCalled_SetTheLastErrorProperty()
        {
            //Arrange 
            string error = "error";
            var logger = new ErrorLogger();

            //Act
            logger.Log(error);

            //Assert
            Assert.That(logger.LastError, Is.EqualTo(error));
        }


        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Log_InvalidError_ThrowArgumentException(string error)
        {
            //Arrange 
            var logger = new ErrorLogger();

            //Assert
            Assert.That(() => logger.Log(error), Throws.ArgumentNullException);
        }


        [Test]
        public void Log_ValidError_RaiseErrorLoggedEvent()
        {
            //Arrange 
            string error = "error";
            var logger = new ErrorLogger();

            var id = Guid.Empty;
            logger.ErrorLogged += (sender, args) => { id = args;  };

            logger.Log(error);

            //Assert
            Assert.That(id , Is.Not.EqualTo(Guid.Empty));
        }
    }
}
