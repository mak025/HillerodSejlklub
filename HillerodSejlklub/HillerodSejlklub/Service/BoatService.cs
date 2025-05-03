using HillerodSejlklub.Repo;
using HillerodSejlklub.Models;
namespace HillerodSejlklub.Service
{
    /// <summary>
    /// Provides services for managing boats, including adding, retrieving, and maintenance operations.
    /// </summary>
    public class BoatService
    {
        private IBoat _boatInterface;

        /// <summary>
        /// Initializes a new instance of the <see cref="BoatService"/> class with the specified boat interface.
        /// </summary>
        /// <param name="boatInterface">The interface for boat operations.</param>
        public BoatService(IBoat boatInterface)
        {
            _boatInterface = boatInterface;
        }

        /// <summary>
        /// Adds a new boat to the system.
        /// </summary>
        /// <param name="boat">The boat to add.</param>
        public void Add(Boat boat)
        {
            _boatInterface.Add(boat);
        }

        /// <summary>
        /// Retrieves all boats from the system.
        /// </summary>
        /// <returns>A list of all boats.</returns>
        public List<Boat> GetAll()
        {
            return _boatInterface.GetAllBoats();
        }

        /// <summary>
        /// Retrieves a specific boat by its registration number.
        /// </summary>
        /// <param name="boatReg">The registration number of the boat.</param>
        /// <returns>The boat with the specified registration number.</returns>
        public Boat Get(string boatReg)
        {
            return _boatInterface.Get(boatReg);
        }

        /// <summary>
        /// Retrieves the maintenance log for a specific boat.
        /// </summary>
        /// <param name="boatID">The ID of the boat.</param>
        /// <returns>A list of maintenance log entries for the boat.</returns>
        public List<string> GetMaintenanceLog(int boatID)
        {
            return _boatInterface.GetMaintenanceLog(boatID);
        }
    }
}
