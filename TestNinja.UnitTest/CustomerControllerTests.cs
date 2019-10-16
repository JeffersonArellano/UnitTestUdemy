
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
    public class CustomerControllerTests
    {


        [Test]
        public void GetCustomer_IdIsZero_ReturnNotFound()
        {
            var controller = new CustomerController();
            var result = controller.GetCustomer(0);

            //NotFound Object
            Assert.That(result, Is.TypeOf<NotFound>());

            //NotFound Object or one of its derivates
            //Assert.That(result, Is.InstanceOf<NotFound>());
        }

        [Test]
        public void GetCustomer_IdNotZero_ReturnOk()
        {
            var controller = new CustomerController();
            var result = controller.GetCustomer(1);

            //NotFound Object
            Assert.That(result, Is.TypeOf<Ok>());
        }
    }
}
