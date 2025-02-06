using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TestNinja.Mocking;
using System;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class BookingHelper_OverlappingBookingsExistTests
    {
        private Mock<IBookingRepository> _bookRepository;
        private Booking booking;

        [SetUp]
        public void SetUp()
        {
            _bookRepository = new Mock<IBookingRepository>();
            booking = new Booking
            {
                Id = 1,
                ArrivalDate = ArrivalOn(2025, 01, 10),
                DepartureDate = DepartureOn(2025, 01, 15),
                Reference = "a",
                Status = "Confirmed"
            };
            _bookRepository.Setup(b => b.GetBookings(It.IsAny<int>())).Returns(new List<Booking> { booking }.AsQueryable());
        }
        [Test]
        public void IfBookingStatusIsCancelled_ReturnsEmptyString()
        {
            booking.Status = "Cancelled";

            var result = BookingHelper.OverlappingBookingsExist(booking, _bookRepository.Object);

            Assert.That(result, Is.EqualTo(""));
        }
        [Test] //no overlap, should return empty
        public void NewBookingStartsBeforeExistingBookingArrivalAndEndsAfterExistingBookingDeparture_ReturnsOverlappedBookingReference()
        {

            var result = BookingHelper.OverlappingBookingsExist(
                new Booking
                {
                    Id = 1,
                    ArrivalDate = Before(booking.ArrivalDate, days: 3),
                    DepartureDate = After(booking.DepartureDate, days: 3),
                }, _bookRepository.Object);

            Assert.That(result, Is.EqualTo(booking.Reference));
        }
        [Test] //no overlap, should return empty
        public void NewBookingStartsBeforeExistingBookingArrivalAndEndsInTheMiddleOfExistingBooking_ReturnsOverlappedBookingReference()
        {
            var result = BookingHelper.OverlappingBookingsExist(
                 new Booking
                 {
                     Id = 1,
                     ArrivalDate = Before(booking.ArrivalDate, days: 3),
                     DepartureDate = After(booking.ArrivalDate, days: 2),
                 }, _bookRepository.Object);

            Assert.That(result, Is.EqualTo(booking.Reference));
        }
        [Test] //overlap, should return reference
        public void NewBookingStartsAfterExistingBookingArrivalAndEndsBeforeExistingBookingDeparture_ReturnsOverlappedBookingReference()
        {
            var result = BookingHelper.OverlappingBookingsExist(
                 new Booking
                 {
                     Id = 1,
                     ArrivalDate = After(booking.ArrivalDate, days: 1),
                     DepartureDate = Before(booking.DepartureDate, days: 1),
                 },
                 _bookRepository.Object);

            Assert.That(result, Is.EqualTo(booking.Reference));
        }
        [Test] //overlap, returns reference
        public void NewBookingStartsAfterExistingBookingArrivalAndEndsAfterExistingBookingDeparture_ReturnsOverlappedBookingReference()
        {
            var result = BookingHelper.OverlappingBookingsExist(
                 new Booking
                 {
                     Id = 1,
                     ArrivalDate = After(booking.ArrivalDate, days: 1),
                     DepartureDate = After(booking.DepartureDate, days: 1),
                 },
                 _bookRepository.Object);

            Assert.That(result, Is.EqualTo(booking.Reference));
        }
        [Test] // no overlap
        public void NewBookingStartsBeforeAndEndsBeforeExistingBookingArrival_ReturnsEmptyString()
        {
            var result = BookingHelper.OverlappingBookingsExist(
                 new Booking
                 {
                     Id = 1,
                     ArrivalDate = Before(booking.ArrivalDate, days: 5),
                     DepartureDate = Before(booking.ArrivalDate, days: 1),
                 },
                 _bookRepository.Object);

            Assert.That(result, Is.Empty);
        }
        [Test] // no overlap
        public void NewBookingStartsAndEndsAfterExistingBookingDeparture_ReturnsEmptyString()
        {
            var result = BookingHelper.OverlappingBookingsExist(
                 new Booking
                 {
                     Id = 1,
                     ArrivalDate = After(booking.DepartureDate, days: 1),
                     DepartureDate = After(booking.DepartureDate, days: 5),
                 },
                 _bookRepository.Object);

            Assert.That(result, Is.Empty);
        }
        private static DateTime ArrivalOn(int year, int month, int day)
        {
            return new DateTime(year, month, day, 14, 0, 0);
        }
        private static DateTime DepartureOn(int year, int month, int day)
        {
            return new DateTime(year, month, day, 10, 0, 0);
        }
        private static DateTime Before(DateTime dateTime, int days = 1)
        {
            return dateTime.AddDays(-days);
        }
        private static DateTime After(DateTime dateTime, int days = 1)
        {
            return dateTime.AddDays(days);
        }

    }
}
