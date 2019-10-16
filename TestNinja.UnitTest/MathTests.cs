namespace TestNinja.UnitTest
{
    using NUnit.Framework;
    using System.Linq;
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

        [Test]
        public void GetOddNumber_LimitIsGreaterThatZero_ReturnOddNumberToLimit()
        {

            //Act
            var result = _math.GetOddNumbers(5);

            //Assert
            //Assert.That(result, Is.Not.Empty);

            //Assert.That(result.Count(), Is.EqualTo(3));

            //Assert.That(result, Does.Contain(1));
            //Assert.That(result, Does.Contain(3));
            //Assert.That(result, Does.Contain(5));

            Assert.That(result, Is.EquivalentTo(new[] { 1, 3, 5 }));

            //Assert.That(result, Is.Ordered);
            //Assert.That(result, Is.Unique);


        }
    }
}
