using HillerodSejlklub.Models;

namespace HillerodSejlklub.Repo
{
    public interface IBoat
    {
        public void Add(Boat boat);

        public List<Boat> GetAllBoats();

        public Boat Get(string boatReg);
    }
}
