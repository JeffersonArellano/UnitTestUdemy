namespace TestNinja.UnitTest
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TestNinja.Fundamentals;

    [TestFixture]
    public class DemeritPointsCalculatorTests
    {
        [Test]
        [TestCase(-1)]
        [TestCase(301)]
        public void CalculateDemeritPoints_SpeedIsOutOfRange_ThrowArgumentOutOfRangeException(int speed)
        { 
            var calculator = new DemeritPointsCalculator(); 
            Assert.That(()=>calculator.CalculateDemeritPoints(speed) , Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        [TestCase(60)]
        public void CalculateDemeritPoints_SpeedLessEqualThatSpeedLimit_ReturnZero(int speed)
        {
            var demeritPoints = new DemeritPointsCalculator();

            var result = demeritPoints.CalculateDemeritPoints(speed);

            Assert.That(result,Is.EqualTo(0));
        }

        [Test]
        [TestCase(0,0)]
        [TestCase(64, 0)]
        [TestCase(65, 0)]
        [TestCase(66, 0)]
        [TestCase(70, 1)]
        [TestCase(75, 2)]
        public void CalculateDemeritPoints_WhenCalled_ReturnDemeritPoints(int speed, int expectedResult)
        {
            var calculator = new DemeritPointsCalculator();

            var result = calculator.CalculateDemeritPoints(speed);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
