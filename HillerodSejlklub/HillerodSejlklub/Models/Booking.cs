namespace HillerodSejlklub.Models
{
    /// <summary>
    /// Represents a booking for a boat.
    /// </summary>
    public class Booking
    {
        /// <summary>
        /// Temporary ID counter for generating unique Booking IDs.
        /// </summary>
        static int _tempID = 1;

        /// <summary>
        /// Gets or sets the unique identifier for the booking.
        /// </summary>
        public int BookingID { get; set; }

        //public List<int> MemberID { get;  set; }

        /// <summary>
        /// Gets or sets the name of the user who made the booking.
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// Gets or sets the name of the boat being booked.
        /// </summary>
        public string BoatName { get; set; }

        /// <summary>
        /// Gets or sets the start date and time of the booking.
        /// </summary>
        public DateTime StartDT { get; set; }

        /// <summary>
        /// Gets or sets the end date and time of the booking.
        /// </summary>
        public DateTime EndDT { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Booking"/> class.
        /// </summary>
        /// <param name="user">The name of the user making the booking.</param>
        /// <param name="boatName">The name of the boat being booked.</param>
        /// <param name="startDT">The start date and time of the booking.</param>
        /// <param name="endTime">The end date and time of the booking.</param>
        public Booking(string user, string boatName, DateTime startDT, DateTime endTime)
        {
            //MemberID = memberID;
            User = user;
            BoatName = boatName;
            StartDT = startDT;
            EndDT = endTime;
            BookingID = _tempID;
            _tempID++;
        }

        //public void Add()
    }
}
