namespace HillerodSejlklub.Models
{
    public class Booking
    {
        static int _tempID = 1;

        public int BookingID { get; set; }
        //public List<int> MemberID { get;  set; }
        public string User { get; set; }
        public string BoatName { get; set; }
        public DateTime StartDT { get; set; }
        public DateTime EndDT { get; set; }

        public Booking(string user, string boatName,  DateTime startDT, DateTime endTime)
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
