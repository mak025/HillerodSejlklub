using System.Text.Json;
using HillerodSejlklub.Models;
using HillerodSejlklub.Repo;

namespace HillerodSejlklub.Interface
{
    /// <summary>
    /// Represents a collection of boats and provides methods to manage them.
    /// </summary>
    public class BoatCollection : IBoat
    {
        /// <summary>
        /// The file path where the boat data is stored in JSON format.
        /// </summary>
        private readonly string _filePath;

        /// <summary>
        /// The list of boats managed by this collection.
        /// </summary>
        private List<Boat> _boats;

        /// <summary>
        /// Initializes a new instance of the <see cref="BoatCollection"/> class with the specified environment.
        /// </summary>
        /// <param name="env">The web host environment to determine the file path.</param>
        public BoatCollection(IWebHostEnvironment env)
        {
            // Set the file path for the JSON file
            _filePath = Path.Combine(env.ContentRootPath, "Data", "boats.json");
            _boats = LoadBoatsFromFile();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BoatCollection"/> class.
        /// </summary>
        public BoatCollection()
        {
        }

        /// <summary>
        /// Adds a new boat to the collection and saves the updated list to the file.
        /// </summary>
        /// <param name="boat">The boat to add.</param>
        public void Add(Boat boat)
        {
            _boats.Add(boat);
            SaveBoatsToFile();
        }

        /// <summary>
        /// Retrieves all boats in the collection.
        /// </summary>
        /// <returns>A list of all boats.</returns>
        public List<Boat> GetAllBoats()
        {
            return _boats;
        }

        /// <summary>
        /// Retrieves a boat by its registration number.
        /// </summary>
        /// <param name="boatReg">The registration number of the boat.</param>
        /// <returns>The boat with the specified registration number, or null if not found.</returns>
        public Boat Get(string boatReg)
        {
            return _boats.FirstOrDefault(boat => boat.RegistrationNumber == boatReg);
        }

        /// <summary>
        /// Retrieves the maintenance log for a specific boat by its ID.
        /// </summary>
        /// <param name="boatID">The ID of the boat.</param>
        /// <returns>A list of maintenance log entries for the boat.</returns>
        public List<string> GetMaintenanceLog(int boatID)
        {
            foreach (var boat in _boats)
            {
                if (boat.ID == boatID)
                {
                    return boat.GetMaintenanceLog(boat);
                }
            }
            return new List<string>();
        }

        /// <summary>
        /// Loads the list of boats from the JSON file.
        /// </summary>
        /// <returns>A list of boats loaded from the file, or an empty list if the file does not exist.</returns>
        private List<Boat> LoadBoatsFromFile()
        {
            // Check if the file exists
            if (!File.Exists(_filePath))
            {
                Console.WriteLine("JSON file not found. Returning an empty list.");
                return new List<Boat>();
            }

            // Read the JSON file
            var json = File.ReadAllText(_filePath);

            // Deserialize the JSON into a list of Boat objects
            var boats = JsonSerializer.Deserialize<List<Boat>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return boats ?? new List<Boat>();
        }

        /// <summary>
        /// Saves the current list of boats to the JSON file.
        /// </summary>
        private void SaveBoatsToFile()
        {
            // Serialize the list of boats to JSON and write it to the file
            var json = JsonSerializer.Serialize(_boats, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }

        /// <summary>
        /// Removes a boat from the collection and saves the updated list to the file.
        /// </summary>
        /// <param name="boat">The boat to remove.</param>
        public void Remove(Boat boat)
        {
            // Remove the boat from the list
            _boats.Remove(boat);

            // Save the updated list back to the JSON file
            SaveBoatsToFile();
        }
    }
}
