namespace HillerodSejlklub.Models
{
    public abstract class Boats
    {
        public string type { get; protected set; }

        public string size { get; protected set; }

        public double seats { get; protected set; }

        public Boats(string type, string size, double seats)
        {
            this.type = type;
            this.size = size;
            this.seats = seats;
        }

        public string getBoatDetails()
        {
            return "Boat Type: " + type + "\n" +                   // This returns the details of the device brand in a string format.
                   "Boat Size: " + size + "\n" +     // This returns the details of the device manufacturer in a string format.
                   "Amount of seats: " + seats;
        }
    }

    public class SailBoats : Boats
    {
        private string Sails { get; set; }

        public SailBoats(string type, string size, double seats, string Sails)
            : base(type, size, seats)
        {
            this.Sails = Sails;
        }
    }
}
