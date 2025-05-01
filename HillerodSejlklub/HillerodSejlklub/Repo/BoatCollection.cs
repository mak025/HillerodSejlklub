using System.Text.Json;
using HillerodSejlklub.Models;
using HillerodSejlklub.Repo;

namespace HillerodSejlklub.Interface
{
    public class BoatCollection : IBoat
    {
        private readonly string _filePath;
        private List<Boat> _boats;

        public BoatCollection(IWebHostEnvironment env)
        {
            // Set the file path for the JSON file
            _filePath = Path.Combine(env.ContentRootPath, "Data", "boats.json");
            _boats = LoadBoatsFromFile();
        }

        public BoatCollection()
        {
        }

        public void Add(Boat boat)
        {
            _boats.Add(boat);
            SaveBoatsToFile();
        }

        public List<Boat> GetAllBoats()
        {
            return _boats;
        }

        public Boat Get(string boatReg)
        {
            return _boats.FirstOrDefault(boat => boat.RegistrationNumber == boatReg);
        }

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

        private void SaveBoatsToFile()
        {
            // Serialize the list of boats to JSON and write it to the file
            var json = JsonSerializer.Serialize(_boats, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }
    }
}
