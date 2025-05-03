namespace HillerodSejlklub.Model
{
    /// <summary>
    /// Represents a user in the Hillerod Sejlklub system.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the unique identifier for the user.
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// Gets or sets the username of the user.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets the list of booking numbers associated with the user.
        /// </summary>
        public List<int> BookingList { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class with specified user ID and username.
        /// </summary>
        /// <param name="userID">The unique identifier for the user.</param>
        /// <param name="userName">The username of the user.</param>
        public User(int userID, string userName)
        {
            UserID = userID;
            UserName = userName;
        }

        /// <summary>
        /// Adds a booking number to the user's booking list.
        /// </summary>
        /// <param name="bookingNum">The booking number to add.</param>
        public void AddBooking(int bookingNum)
        {
            BookingList.Add(bookingNum);
        }

        /// <summary>
        /// Removes a booking number from the user's booking list.
        /// </summary>
        /// <param name="bookingNum">The booking number to remove.</param>
        public void RemoveBooking(int bookingNum)
        {
            BookingList.Remove(bookingNum);
        }
    }
}
