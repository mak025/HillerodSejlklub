using HillerodSejlklub.Models;
using HillerodSejlklub.Interface;

namespace HillerodSejlklub.Service
{
    /// <summary>
    /// Service class for managing bookings.
    /// </summary>
    public class BookingService
    {
        private IBooking _bookingInterface;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookingService"/> class.
        /// </summary>
        /// <param name="bookRepo">The booking repository interface.</param>
        /// <exception cref="ArgumentNullException">Thrown when the provided repository is null.</exception>
        public BookingService(IBooking bookRepo)
        {
            // Added throw to avoid null exception error
            _bookingInterface = bookRepo ?? throw new ArgumentNullException(nameof(bookRepo));
        }

        /// <summary>
        /// Retrieves all bookings.
        /// </summary>
        /// <returns>A list of all bookings.</returns>
        public List<Booking> GetAll()
        {
            return _bookingInterface.GetAll();
        }

        /// <summary>
        /// Adds a new booking.
        /// </summary>
        /// <param name="book">The booking to add.</param>
        public void Add(Booking book)
        {
            _bookingInterface.Add(book);
        }
    }
}
