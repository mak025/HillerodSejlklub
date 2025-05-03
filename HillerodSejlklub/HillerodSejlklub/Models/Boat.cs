using System.Xml.Linq;
using System.Diagnostics;

namespace HillerodSejlklub.Models
{
    /// <summary>
    /// Represents a generic boat with common properties and methods.
    /// </summary>
    public class Boat
    {
        private static int _tempID = 1;

        /// <summary>
        /// Gets or sets the unique ID of the boat.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the type of the boat (e.g., Sailboat, Motorboat, etc.).
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the size of the boat (e.g., Small, Medium, Large).
        /// </summary>
        public string Size { get; set; }

        /// <summary>
        /// Gets or sets the number of seats available on the boat.
        /// </summary>
        public double Seats { get; set; }

        /// <summary>
        /// Gets or sets the material of the boat (e.g., Wood, Fiberglass, Aluminum).
        /// </summary>
        public string Material { get; set; }

        /// <summary>
        /// Gets or sets the color of the boat.
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets the weight of the boat in kilograms.
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Gets or sets the year the boat was built.
        /// </summary>
        public int YearBuilt { get; set; }

        /// <summary>
        /// Gets or sets the name of the boat.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the unique registration number of the boat.
        /// </summary>
        public string RegistrationNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the boat is available for use.
        /// </summary>
        public bool IsAvailable { get; set; } = true;

        /// <summary>
        /// Gets the list of maintenance logs for the boat.
        /// </summary>
        public List<string> MaintenanceLog { get; private set; } = new List<string>();

        /// <summary>
        /// Gets or sets the date of the last maintenance performed on the boat.
        /// </summary>
        public DateTime LastMaintenanceDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the boat needs repair.
        /// </summary>
        public bool NeedsRepair { get; set; } = false;

        /// <summary>
        /// Gets or sets the path to the image of the boat.
        /// </summary>
        public string IMGPath { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Boat"/> class with specified properties.
        /// </summary>
        public Boat(string type, string size, double seats, string material, string color, double weight, int yearBuilt, string name, string registrationNumber, string imgpath)
        {
            this.ID = _tempID++;
            this.Type = type;
            this.Size = size;
            this.Seats = seats;
            this.Material = material;
            this.Color = color;
            this.Weight = weight;
            this.YearBuilt = yearBuilt;
            this.Name = name;
            this.RegistrationNumber = registrationNumber;
            this.IMGPath = imgpath;
            Debug.WriteLine(ID);
        }

        /// <summary>
        /// Adds a maintenance log entry and updates the last maintenance date.
        /// </summary>
        /// <param name="logEntry">The maintenance log entry to add.</param>
        public void AddMaintenanceLog(string logEntry)
        {
            MaintenanceLog.Add(logEntry);
            LastMaintenanceDate = DateTime.Now;
        }

        /// <summary>
        /// Retrieves the maintenance log for the specified boat.
        /// </summary>
        /// <param name="boat">The boat whose maintenance log is to be retrieved.</param>
        /// <returns>A list of maintenance log entries.</returns>
        public List<string> GetMaintenanceLog(Boat boat)
        {
            return boat.MaintenanceLog;
        }

        /// <summary>
        /// Marks the boat as repaired and adds a repair log entry.
        /// </summary>
        public void MarkAsRepaired()
        {
            NeedsRepair = false;
            AddMaintenanceLog("Boat repaired.");
        }

        /// <summary>
        /// Updates the location of the boat.
        /// </summary>
        /// <param name="newLocation">The new location of the boat.</param>
        public void UpdateLocation(string newLocation)
        {
            // Placeholder for location update logic
        }

        /// <summary>
        /// Retrieves the details of the boat as a formatted string.
        /// </summary>
        /// <returns>A string containing the boat's details.</returns>
        public string GetBoatDetails()
        {
            return $"Boat Type: {Type}\n" +
                   $"Boat Size: {Size}\n" +
                   $"Seats: {Seats}\n" +
                   $"Material: {Material}\n" +
                   $"Color: {Color}\n" +
                   $"Weight: {Weight} kg\n" +
                   $"Year Built: {YearBuilt}\n" +
                   $"Name: {Name}\n" +
                   $"Registration Number: {RegistrationNumber}\n" +
                   $"Is Available: {IsAvailable}\n" +
                   $"Needs Repair: {NeedsRepair}\n" +
                   $"Last Maintenance Date: {LastMaintenanceDate.ToShortDateString()}";
        }
    }

    /// <summary>
    /// Represents a sailboat with additional properties specific to sailboats.
    /// </summary>
    public class SailBoat : Boat
    {
        /// <summary>
        /// Gets the type of sail (e.g., Main Sail, Jib, Spinnaker).
        /// </summary>
        public string SailType { get; private set; }

        /// <summary>
        /// Gets the number of sails on the sailboat.
        /// </summary>
        public int NumberOfSails { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the sailboat has a keel.
        /// </summary>
        public bool HasKeel { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SailBoat"/> class with specified properties.
        /// </summary>
        public SailBoat(string type, string size, double seats, string material, string color, double weight, int yearBuilt, string name, string registrationNumber, string imgpath, string sailType, int numberOfSails, bool hasKeel)
            : base(type, size, seats, material, color, weight, yearBuilt, name, registrationNumber, imgpath)
        {
            this.SailType = sailType;
            this.NumberOfSails = numberOfSails;
            this.HasKeel = hasKeel;
        }

        /// <summary>
        /// Retrieves the details of the sailboat as a formatted string.
        /// </summary>
        /// <returns>A string containing the sailboat's details.</returns>
        public string GetSailBoatDetails()
        {
            return GetBoatDetails() + "\n" +
                   $"Sail Type: {SailType}\n" +
                   $"Number of Sails: {NumberOfSails}\n" +
                   $"Has Keel: {HasKeel}";
        }
    }

    /// <summary>
    /// Represents a motorboat with additional properties specific to motorboats.
    /// </summary>
    public class MotorBoat : Boat
    {
        /// <summary>
        /// Gets the engine power in horsepower (HP).
        /// </summary>
        public int EnginePower { get; private set; }

        /// <summary>
        /// Gets the type of fuel used by the motorboat (e.g., Gasoline, Diesel, Electric).
        /// </summary>
        public string FuelType { get; private set; }

        /// <summary>
        /// Gets the fuel capacity in liters.
        /// </summary>
        public double FuelCapacity { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MotorBoat"/> class with specified properties.
        /// </summary>
        public MotorBoat(string type, string size, double seats, string material, string color, double weight, int yearBuilt, string name, string registrationNumber, string imgpath, int enginePower, string fuelType, double fuelCapacity)
            : base(type, size, seats, material, color, weight, yearBuilt, name, registrationNumber, imgpath)
        {
            this.EnginePower = enginePower;
            this.FuelType = fuelType;
            this.FuelCapacity = fuelCapacity;
        }

        /// <summary>
        /// Retrieves the details of the motorboat as a formatted string.
        /// </summary>
        /// <returns>A string containing the motorboat's details.</returns>
        public string GetMotorBoatDetails()
        {
            return GetBoatDetails() + "\n" +
                   $"Engine Power: {EnginePower} HP\n" +
                   $"Fuel Type: {FuelType}\n" +
                   $"Fuel Capacity: {FuelCapacity} liters";
        }
    }

    /// <summary>
    /// Represents a rowboat with additional properties specific to rowboats.
    /// </summary>
    public class RowBoat : Boat
    {
        /// <summary>
        /// Gets the number of oars available on the rowboat.
        /// </summary>
        public int NumberOfOars { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RowBoat"/> class with specified properties.
        /// </summary>
        public RowBoat(string type, string size, double seats, string material, string color, double weight, int yearBuilt, string name, string registrationNumber, string imgpath, int numberOfOars)
            : base(type, size, seats, material, color, weight, yearBuilt, name, registrationNumber, imgpath)
        {
            this.NumberOfOars = numberOfOars;
        }

        /// <summary>
        /// Retrieves the details of the rowboat as a formatted string.
        /// </summary>
        /// <returns>A string containing the rowboat's details.</returns>
        public string GetRowBoatDetails()
        {
            return GetBoatDetails() + "\n" +
                   $"Number of Oars: {NumberOfOars}";
        }
    }
}
