namespace TestNinja.UnitTest
{
    using NUnit.Framework;
    using TestNinja.Fundamentals;

    [TestFixture]
    public class FizzBuzzTests
    {
        [Test]

        [TestCase(15)]
        public void GetOutput_InputDivisibleBy3And5_ReturnFizzBuzz(int number)
        {
            //Act
            var result = FizzBuzz.GetOutput(number);

            //Assert 
            Assert.That(result, Is.EqualTo("FizzBuzz"));
        }

        [Test]
        [TestCase(3)]
        public void GetOutput_InputDivisibleBy3Only_ReturnFizz(int number)
        {
            //Act
            var result = FizzBuzz.GetOutput(number);

            //Assert 
            Assert.That(result, Is.EqualTo("Fizz"));

        }

        [Test]
        [TestCase(5)]
        public void GetOutput_InputDivisibleBy5Only_ReturnBuzz(int number)
        {
            //Act
            var result = FizzBuzz.GetOutput(number);

            //Assert 
            Assert.That(result, Is.EqualTo("Buzz"));
        }


        [Test]
        [TestCase(2)]
        public void GetOutput_InputIsNoDivisibleBy3Or5_ReturnSameNumber(int number)
        {
            //Act
            var result = FizzBuzz.GetOutput(number);

            //Assert 
            Assert.That(result, Is.EqualTo(number.ToString()));
        }
    }
}
