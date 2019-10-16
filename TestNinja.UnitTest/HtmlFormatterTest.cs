namespace TestNinja.UnitTest
{
    using NUnit.Framework;
    using TestNinja.Fundamentals;

    [TestFixture]
    public class HtmlFormatterTest
    {
        [Test]
        public void FormatAsBolt_WhenCall_ShouldEncloseTheStringWithStrongElement()
        {
            //Arrange
            var formatter = new HtmlFormatter();

            //Act
            var result = formatter.FormatAsBold("abc");

            //Assert        
            //Specific
            Assert.That(result, Is.EqualTo("<strong>abc</strong>").IgnoreCase);

            //More general
            Assert.That(result, Does.StartWith("<strong>").IgnoreCase);
            Assert.That(result, Does.EndWith("</strong>"));
            Assert.That(result, Does.Contain("abc"));
        }
    }
}
