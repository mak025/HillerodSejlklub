using HillerodSejlklub.Repo;
using HillerodSejlklub.Models;
namespace HillerodSejlklub.Service
{
    public class BoatService
    {
        private IBoat _boatInterface;

        public BoatService(IBoat boatInterface)
        {
            _boatInterface = boatInterface;
        }

        public void Add(Boat boat)
        {
            _boatInterface.Add(boat);
        }

        public List<Boat> GetAll()
        {
            return _boatInterface.GetAllBoats();
        }
        public Boat Get(int boatID)
        {
            return _boatInterface.Get(boatID);
        }
    }
}
