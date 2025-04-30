using HillerodSejlklub.Interface;
using HillerodSejlklub.Models;
namespace HillerodSejlklub.Service
{
    public class BoatService
    {
        private IMember _boatInterface;

        public BoatService(IMember boatInterface)
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
        public Boat Get(string boatReg)
        {
            return _boatInterface.Get(boatReg);
        }
    }
}
