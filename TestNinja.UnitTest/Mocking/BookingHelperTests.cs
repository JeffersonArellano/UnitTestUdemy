using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TestNinja.Mocking;

namespace TestNinja.UnitTest.Mocking
{
    [TestFixture]
    public class BookingHelperTests
    {

        private Booking existingBooking;
        private Mock<IBookingRepository> repository;

        [SetUp]
        public void Setup()
        {
            existingBooking = new Booking
            {
                Id = 2,
                ArrivalDate = ArriveOn(2017, 1, 15),
                DepartureDate = DepartOn(2017, 1, 20),
                Reference = "a"
            };

            repository = new Mock<IBookingRepository>();
            repository.Setup(r => r.GetActiveBookings(1)).Returns(new List<Booking>
            {
                existingBooking
            }.AsQueryable());
        }

        [Test]
        public void OverlappingBookingsExist_BookingStartsAndFinishBeforeAnExistingBooking_ReturnEmptyString()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = Before(existingBooking.ArrivalDate, 2),
                DepartureDate = Before(existingBooking.ArrivalDate),
            }, repository.Object);

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void OverlappingBookingsExist_BookingStartsAndFinisInTheMIddleOfAnExistingBooking_ReturnExistingBookingReference()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = Before(existingBooking.ArrivalDate),
                DepartureDate = After(existingBooking.ArrivalDate),
            }, repository.Object);

            Assert.That(result, Is.EqualTo(existingBooking.Reference));
        }

        [Test]
        public void OverlappingBookingsExist_BookingStartsBeforeAndFinisAfterOfAnExistingBooking_ReturnExistingBookingReference()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = Before(existingBooking.ArrivalDate),
                DepartureDate = After(existingBooking.DepartureDate),
            }, repository.Object);

            Assert.That(result, Is.EqualTo(existingBooking.Reference));
        }

        [Test]
        public void OverlappingBookingsExist_BookingStartsAndFinishInTheMiddleOfAnExistingBooking_ReturnExistingBookingReference()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = After(existingBooking.ArrivalDate),
                DepartureDate = Before(existingBooking.DepartureDate),
            }, repository.Object);

            Assert.That(result, Is.EqualTo(existingBooking.Reference));
        }

        [Test]
        public void OverlappingBookingsExist_BookingStartsInTheMiddleOfAnExistingBookingButFinishesAfter_ReturnExistingBookingReference()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = After(existingBooking.ArrivalDate),
                DepartureDate = After(existingBooking.DepartureDate),
            }, repository.Object);

            Assert.That(result, Is.EqualTo(existingBooking.Reference));
        }

        [Test]
        public void OverlappingBookingsExist_BookingStartsAndFinishesAfterAnExistingBooking_ReturnEmptyString()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = After(existingBooking.DepartureDate),
                DepartureDate = After(existingBooking.DepartureDate, days: 2),
            }, repository.Object);

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void OverlappingBookingsExist_BookingOverlapButNewBookingIsCancelled_ReturnExistingBookingReference()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = After(existingBooking.ArrivalDate),
                DepartureDate = After(existingBooking.DepartureDate),
                Status= "Cancelled"
            }, repository.Object);

            Assert.That(result, Is.Empty);
        }


        private DateTime After(DateTime dateTime, int days = 1)
        {
            return dateTime.AddDays(days);
        }
        private DateTime Before(DateTime dateTime, int days = 1)
        {
            return dateTime.AddDays(-days);
        }

        private DateTime ArriveOn(int year, int month, int day)
        {
            return new DateTime(year, month, day, 14, 0, 0);
        }

        private DateTime DepartOn(int year, int month, int day)
        {
            return new DateTime(year, month, day, 10, 0, 0);
        }



    }
}
