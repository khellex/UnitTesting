using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public class BookingRepository : IBookingRepository
    {
        private UnitOfWork _unitOfWork;

        public BookingRepository(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IQueryable<Booking> GetBookings(int? bookingId = null)
        {
            var bookings =
                _unitOfWork.Query<Booking>()
                .Where(b => b.Status != "Cancelled");
            if (bookingId.HasValue)
            {
                bookings = bookings.Where(b => b.Id != bookingId);
            }
            return bookings;
        }
    }
}
