using HillerodSejlklub.Models;

namespace HillerodSejlklub.Interface
{
    public class BookingCollection : IBooking
    {
        private List<Booking> _bookings;

        public BookingCollection()
        {
            _bookings = new List<Booking>();
            Seed();
        }

        /// <summary>
        /// adds a new booking to the repository
        /// </summary>
        /// <param name="booking">the booking being added</param>
        public void Add(Booking booking)
        {
            _bookings.Add(booking);
        }

        /// <summary>
        /// Henter alle kæledyr i repositoryet.
        /// Dette svarer til en "Read all"-operation i en database.
        /// </summary>
        /// <returns>En liste med alle kæledyr.</returns>
        public List<Booking> GetAll()
        {
            return _bookings;
        }

        //new deletion method
        public void Delete(int bookingId)
        {
            var bookingToDelete = _bookings.FirstOrDefault(b => b.BookingID == bookingId);
            if (bookingToDelete != null)
            {
                _bookings.Remove(bookingToDelete);
            }
        }

        private void Seed()
        {
            _bookings.Add(new Booking("Marcus", "Jytte", new DateTime(2025, 05, 03, 10, 0, 0), new DateTime(2025, 04, 01, 15, 0, 0) ));
            _bookings.Add(new Booking("Lucas", "Jette", new DateTime(2025, 05, 14, 12, 0, 0), new DateTime(2025, 04, 14, 15, 0, 0)));
            _bookings.Add(new Booking("Mikkel", "Jonna", new DateTime(2025, 05, 24, 8, 0, 0), new DateTime(2025, 04, 24, 11, 0, 0)));
        }
    }
}
