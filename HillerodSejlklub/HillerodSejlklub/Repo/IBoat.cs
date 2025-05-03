using HillerodSejlklub.Models;

namespace HillerodSejlklub.Repo
{
    /// <summary>
    /// Interface for managing boat-related operations.
    /// </summary>
    public interface IBoat
    {
        /// <summary>
        /// Adds a new boat to the repository.
        /// </summary>
        /// <param name="boat">The boat to add.</param>
        public void Add(Boat boat);

        /// <summary>
        /// Retrieves all boats from the repository.
        /// </summary>
        /// <returns>A list of all boats.</returns>
        public List<Boat> GetAllBoats();

        /// <summary>
        /// Retrieves a specific boat by its registration number.
        /// </summary>
        /// <param name="boatReg">The registration number of the boat.</param>
        /// <returns>The boat with the specified registration number.</returns>
        public Boat Get(string boatReg);

        /// <summary>
        /// Retrieves the maintenance log for a specific boat.
        /// </summary>
        /// <param name="boatID">The ID of the boat.</param>
        /// <returns>A list of maintenance log entries for the boat.</returns>
        public List<string> GetMaintenanceLog(int boatID);
    }
}
