using HillerodSejlklub.Models;
using HillerodSejlklub.Interface;

namespace HillerodSejlklub.Service
{
    public class BookingService
    {
        private IBooking _bookingInterface;

        public BookingService(IBooking bookRepo)
        {
            //added throw to avoid null exception error
            _bookingInterface = bookRepo ?? throw new ArgumentNullException(nameof(bookRepo));
        }

        public List<Booking> GetAll()
        {
            return _bookingInterface.GetAll();
        }

        public void Add(Booking book)
        {
            _bookingInterface.Add(book);
        }
    }
}
