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
            _boats.Add(new SailBoat("Sailboat", "medium", 10, "fiberglas", "Hvis", 80, 2012, "Jytte", "JYT50425034", "../img/boat_temp.jpg", "Main Sail", 1, true));
            _boats.Add(new SailBoat("Sailboat", "small", 8, "fiberglas", "Hvid", 80, 2012, "Jotte", "JYT50425035", "../img/boat_temp.jpg", "Main Sail", 1, true));
            _boats.Add(new SailBoat("Sailboat", "large", 12, "fiberglas", "Grå", 80, 2012, "Jette", "JYT50425036", "../img/boat_temp.jpg", "Main Sail", 1, true));
            _boats.Add(new SailBoat("Sailboat", "medium", 10, "fiberglas", "Blå", 80, 2012, "Jonne", "JYT50425037", "../img/boat_temp.jpg", "Main Sail", 1, true));
            _boats.Add(new MotorBoat("Motorboat", "large", 12, "fiberglas", "Grå", 125, 2010, "Fatty", "FAT23598523", "../img/boat_temp.jpg", 105, "Potatoes", 6));
            _boats.Add(new MotorBoat("Motorboat", "small", 6, "fiberglas", "Sort", 125, 2010, "Fatty 2", "FAT23598523", "../img/boat_temp.jpg", 105, "Potatoes", 6));
            _boats.Add(new MotorBoat("Motorboat", "medium", 8, "fiberglas", "Blå", 125, 2010, "Fatty 3", "FAT23598523", "../img/boat_temp.jpg", 105, "Potatoes", 6));
            _boats.Add(new RowBoat("RowBoat", "small", 2, "Træ", "blue", 125, 2010, "Robåd 1", "FAT23598523", "../img/boat_temp.jpg", 2));
            _boats.Add(new RowBoat("RowBoat", "large", 4, "Gummi (Oppustlig)", "blue", 125, 2010, "Robåd 2", "FAT23598523", "../img/boat_temp.jpg", 4));
            _boats.Add(new RowBoat("RowBoat", "large", 4, "Gummi (Oppustlig)", "blue", 125, 2010, "Robåd 3", "FAT23598523", "../img/boat_temp.jpg", 4));
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