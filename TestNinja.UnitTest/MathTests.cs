namespace TestNinja.UnitTest
{
    using NUnit.Framework;
    using TestNinja.Fundamentals;

    [TestFixture]
    public class MathTests
    {
        private Math _math;

        [SetUp]
        public void Setup()
        {
            _math = new Math();
        }

        [Test]
       // [Ignore("Becase I want do!!")]
        public void Add_WhenCalled_ReturnTheSumOfArguments()
        {
            //Arrange
            var a = 1;
            var b = 2;

            //Act
            var result = _math.Add(a, b);

            //Assert
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        [TestCase(2, 1, 2)]
        [TestCase(1, 2, 2)]
        [TestCase(1, 1, 1)]
        public void Max_WhenCalled_ReturnTheGreaterArgument(int a, int b, int expectedResult)
        {
            //Act
            var result = _math.Max(a, b);

            //Assert  
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
