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
            _boats.Add(new SailBoat("sailboat", "small", 6, "fiberglas", "alle sammen", 80, 2012, "Jytte", "JYT50425034", "Main Sail", 1, true));
            _boats.Add(new SailBoat("sailboat", "small", 6, "fiberglas", "alle sammen", 80, 2012, "Jytte", "JYT50425035", "Main Sail", 1, true));
            _boats.Add(new SailBoat("sailboat", "small", 6, "fiberglas", "alle sammen", 80, 2012, "Jytte", "JYT50425036", "Main Sail", 1, true));
            _boats.Add(new SailBoat("sailboat", "small", 6, "fiberglas", "alle sammen", 80, 2012, "Jytte", "JYT50425037", "Main Sail", 1, true));
        } //test
    }
}
