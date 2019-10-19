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
        Mock<IBookingRepository> repository;

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
        public void OverlappingBookingsExist_BookingStartsAndFinishBeforeExistingBooking_ReturnEmptyString()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = Before(existingBooking.ArrivalDate, 2),
                DepartureDate = Before(existingBooking.DepartureDate),
            }, repository.Object);

            Assert.That(result, Is.Empty);
        }

        private DateTime After(DateTime dateTime)
        {
            return dateTime.AddDays(1);
        }
        private DateTime Before(DateTime dateTime, int days = 1)
        {
            return dateTime.AddDays(days);
        }

        [Test]
        public void OverlappingBookingsExist_OverlappingBookingReference_ReturnOverlappingBookingReference()
        {
            var repository = new Mock<IBookingRepository>();

            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = new DateTime(2017, 1, 10, 14, 0, 0),
                DepartureDate = new DateTime(2017, 1, 14, 10, 0, 0),
                Reference = "a"

            }, repository.Object);


            Assert.That(result, Is.Not.Null);
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
