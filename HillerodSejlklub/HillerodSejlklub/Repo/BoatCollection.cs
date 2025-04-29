using HillerodSejlklub.Models;

namespace HillerodSejlklub.Interface
{
    public class BoatCollection : IBoat
    {
        private List<Boat> _boats;

        public BoatCollection()
        {
            _boats = new List<Boat>();
            Seed();
        }

        private void Seed()
        {
            _boats.Add(new SailBoat("sailboat", "small", 6, "fiberglas", "alle sammen", 80, 2012, "Jytte", "JYT50425034", "../img/boat_temp.jpg", "Main Sail", 1, true));
            _boats.Add(new SailBoat("sailboat", "small", 6, "fiberglas", "alle sammen", 80, 2012, "Jotte", "JYT50425035", "../img/boat_temp.jpg", "Main Sail", 1, true));
            _boats.Add(new SailBoat("sailboat", "small", 6, "fiberglas", "alle sammen", 80, 2012, "Jette", "JYT50425036", "../img/boat_temp.jpg", "Main Sail", 1, true));
            _boats.Add(new SailBoat("sailboat", "small", 6, "fiberglas", "alle sammen", 80, 2012, "Jonne", "JYT50425037", "../img/boat_temp.jpg", "Main Sail", 1, true));
            _boats.Add(new MotorBoat("Motorboat", "medium", 12, "fiberglass", "blue", 125, 2010, "Fatty", "FAT23598523", "../img/boat_temp.jpg", 105, "Potatoes", 6));
        }



        public List<Boat> GetAllBoats()
        {
            return _boats;
        }
    }
}