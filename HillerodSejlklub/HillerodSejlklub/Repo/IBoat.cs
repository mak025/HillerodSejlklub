using HillerodSejlklub.Models;

namespace HillerodSejlklub.Interface
{
    public interface IBoat
    {
        public void Add(Boat boat);

        public void Seed();

        public List<Boat> GetAllBoats();

        public Boat Get(string boatReg);
    }
}
