using HillerodSejlklub.Models;

namespace HillerodSejlklub.Interface
{
    public interface IBooking
    {
        void Add(Booking booking);

        List<Booking> GetAll();

        void Delete(int bookingId);
    }
}
