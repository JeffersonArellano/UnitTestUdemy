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
    public class HousekeeperServiceTests
    {
        private HousekeeperService service;
        private Mock<IStatementGenerator> statementGenerator;
        private Mock<IEmailSender> emailSender;
        private Mock<IXtraMessageBox> messageBox;
        readonly DateTime statementDate = new DateTime(2017, 1, 1);
        private Housekeeper housekeeper;

        [SetUp]
        public void Setup()
        {
            housekeeper = new Housekeeper { Email = "a", FullName = "b", Oid = 1, StatementEmailBody = "c" };

            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(uow => uow.Query<Housekeeper>()).Returns(new List<Housekeeper>
            {
                housekeeper
            }.AsQueryable());

            statementGenerator = new Mock<IStatementGenerator>();
            emailSender = new Mock<IEmailSender>();
            messageBox = new Mock<IXtraMessageBox>();

            service = new HousekeeperService(unitOfWork.Object,
                            statementGenerator.Object,
                            emailSender.Object,
                            messageBox.Object);
        }


        [Test]
        public void SendStatementEmails_WhenCalled_GenerateStatements()
        {
            service.SendStatementEmails(statementDate);

            statementGenerator.Verify(sg =>
            sg.SaveStatement(housekeeper.Oid, housekeeper.FullName, statementDate));
        }

        [Test]
        public void SendStatementEmails_HouseKeeperEmailIsNull_ShouldNotGenerateStatement()
        {
            housekeeper.Email = null;
            service.SendStatementEmails(statementDate);

            statementGenerator.Verify(sg =>
            sg.SaveStatement(housekeeper.Oid, housekeeper.FullName, statementDate),
            Times.Never);
        }

        [Test]
        public void SendStatementEmails_HouseKeeperEmailIsWhiteSpace_ShouldNotGenerateStatement()
        {
            housekeeper.Email = " ";
            service.SendStatementEmails(statementDate);

            statementGenerator.Verify(sg =>
            sg.SaveStatement(housekeeper.Oid, housekeeper.FullName, statementDate),
            Times.Never);
        }

        [Test]
        public void SendStatementEmails_HouseKeeperEmailIsEmpty_ShouldNotGenerateStatement()
        {
            housekeeper.Email = string.Empty;
            service.SendStatementEmails(statementDate);

            statementGenerator.Verify(sg =>
            sg.SaveStatement(housekeeper.Oid, housekeeper.FullName, statementDate),
            Times.Never);
        }



    }
}
