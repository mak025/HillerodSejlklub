namespace HillerodSejlklub.Models
{
    public class Booking
    {
        static int _tempID = 1;

        public int BookingID { get; set; }
        public List<int> MemberID { get;  set; }
        public int BoatID { get; set; }
        public DateTime StartDT { get; set; }
        public DateTime EndTime { get; set; }

        public Booking(List<int> memberID, int boatID,  DateTime startDT, DateTime endTime)
        {
            MemberID = memberID;
            BoatID = boatID;
            StartDT = startDT;
            EndTime = endTime;
            BookingID = _tempID;
            _tempID++;
        }

        //public void Add()

    }
}
