using HillerodSejlklub.Models;
using HillerodSejlklub.Repo;

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

        public void Add(Boat boat)
        {
            _boats.Add(boat);
        }

        public void Seed()
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

        public Boat Get(string boatReg)
        {
            foreach (Boat boat in _boats)
            {
                if (boatReg == boat.RegistrationNumber)
                {
                    return boat;
                }
            }
            return null;
        }
    }
}