namespace Mikroprojekt_2.Model
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public List<int> BookingList { get; }

        public User()
        {

        }
        public User(int userID, string userName)
        {
            UserID = userID;
            UserName = userName;
        }

        public void AddBooking(int bookingNum)
        {
            BookingList.Add(bookingNum);
        }
        public void RemoveBooking(int bookingNum)
        {
            BookingList.Remove(bookingNum);
        }

    }
}
