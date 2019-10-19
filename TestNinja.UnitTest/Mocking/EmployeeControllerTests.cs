namespace TestNinja.UnitTest.Mocking
{
    using Moq;
    using NUnit.Framework;
    using TestNinja.Mocking;

    [TestFixture]
    public class EmployeeControllerTests
    {
        [Test]
        public void DeleteEmployee_EmployeeRemove_RedirectToAction()
        {
            var  storage  = new Mock<IEmployeeStorage>();
            var controller = new EmployeeController(storage.Object);

            controller.DeleteEmployee(1);

            storage.Verify(s => s.DeleteEmployee(1));
        }
    }
}
