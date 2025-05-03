using HillerodSejlklub.Models;

namespace HillerodSejlklub.Interface
{
    /// <summary>
    /// Interface for managing bookings.
    /// </summary>
    public interface IBooking
    {
        /// <summary>
        /// Adds a new booking.
        /// </summary>
        /// <param name="booking">The booking to add.</param>
        void Add(Booking booking);

        /// <summary>
        /// Retrieves all bookings.
        /// </summary>
        /// <returns>A list of all bookings.</returns>
        public List<Booking> GetAll();

        /// <summary>
        /// Deletes a booking by its ID.
        /// </summary>
        /// <param name="bookingId">The ID of the booking to delete.</param>
        void Delete(int bookingId);
    }
}
