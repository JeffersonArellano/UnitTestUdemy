namespace TestNinja.UnitTest.Mocking
{
    using Moq;
    using NUnit.Framework;
    using TestNinja.Mocking;

    [TestFixture]
    public class OrderServiceTests
    {
        [Test]
        public void PlaceOrder_StorageOrder_ReturnOrderId()
        {
            //Arrange
            var storage = new Mock<IStorage>();
            var service = new OrderService(storage.Object);

            //Act
            var order = new Order();
            service.PlaceOrder(order);

            //Assert        
            storage.Verify(s => s.Store(order));
        }
    }
}
