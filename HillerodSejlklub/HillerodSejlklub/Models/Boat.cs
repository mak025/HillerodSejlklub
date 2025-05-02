using System.Xml.Linq;
using System.Diagnostics;

namespace HillerodSejlklub.Models
{
    public class Boat
    // Concrete class representing a generic boat
    {
        private static int _tempID = 1;

        public int ID { get; set; } // Static variable to keep track of the next ID
        public string Type { get; set; } // Type of the boat (e.g., Sailboat, Motorboat, etc.)
        public string Size { get; set; } // Size of the boat (e.g., Small, Medium, Large)
        public double Seats { get; set; } // Number of seats available on the boat
        public string Material { get; set; } // Material of the boat (e.g., Wood, Fiberglass, Aluminum)
        public string Color { get; set; } // Color of the boat (e.g., Red, Blue, Green)
        public double Weight { get; set; } // Weight of the boat in kg
        public int YearBuilt { get; set; } // Year the boat was built
        public string Name { get; set; } // Name of the boat
        public string RegistrationNumber { get; set; } // Unique identifier for the boat
        public bool IsAvailable { get; set; } = true; // Indicates if the boat is available for use
        public List<string> MaintenanceLog { get; private set; } = new List<string>(); // List of maintenance logs
        public DateTime LastMaintenanceDate { get; set; } // Date of last maintenance
        public bool NeedsRepair { get; set; } = false; // Indicates if the boat needs repair
        public string IMGPath { get; set; } // Path to the image of the boat

        public Boat(string type, string size, double seats, string material, string color, double weight, int yearBuilt, string name, string registrationNumber, string imgpath)
        {
            this.ID = _tempID++; // Increment the static ID for each new boat
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

        public void AddMaintenanceLog(string logEntry)
        {
            MaintenanceLog.Add(logEntry);
            LastMaintenanceDate = DateTime.Now;
        }

        public List<string> GetMaintenanceLog(Boat boat)
        {
            return boat.MaintenanceLog;
        }

        public void MarkAsRepaired()
        {
            NeedsRepair = false;
            AddMaintenanceLog("Boat repaired.");
        }

        public void UpdateLocation(string newLocation)
        {
            // Placeholder for location update logic
        }

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

    public class SailBoat : Boat
    {
        public string SailType { get; private set; } // e.g., Main Sail, Jib, Spinnaker
        public int NumberOfSails { get; private set; } // Number of sails on the boat
        public bool HasKeel { get; private set; } // Indicates if the sailboat has a keel

        public SailBoat(string type, string size, double seats, string material, string color, double weight, int yearBuilt, string name, string registrationNumber, string imgpath, string sailType, int numberOfSails, bool hasKeel)
            : base(type, size, seats, material, color, weight, yearBuilt, name, registrationNumber, imgpath)
        {
            this.SailType = sailType;
            this.NumberOfSails = numberOfSails;
            this.HasKeel = hasKeel;
        }

        public string GetSailBoatDetails()
        {
            return GetBoatDetails() + "\n" +
                   $"Sail Type: {SailType}\n" +
                   $"Number of Sails: {NumberOfSails}\n" +
                   $"Has Keel: {HasKeel}";
        }
    }

    public class MotorBoat : Boat
    {
        public int EnginePower { get; private set; } // Engine power in horsepower (HP)
        public string FuelType { get; private set; } // e.g., Gasoline, Diesel, Electric
        public double FuelCapacity { get; private set; } // Fuel capacity in liters

        public MotorBoat(string type, string size, double seats, string material, string color, double weight, int yearBuilt, string name, string registrationNumber, string imgpath, int enginePower, string fuelType, double fuelCapacity)
            : base(type, size, seats, material, color, weight, yearBuilt, name, registrationNumber, imgpath)
        {
            this.EnginePower = enginePower;
            this.FuelType = fuelType;
            this.FuelCapacity = fuelCapacity;
        }

        public string GetMotorBoatDetails()
        {
            return GetBoatDetails() + "\n" +
                   $"Engine Power: {EnginePower} HP\n" +
                   $"Fuel Type: {FuelType}\n" +
                   $"Fuel Capacity: {FuelCapacity} liters";
        }
    }

    public class RowBoat : Boat
    {
        public int NumberOfOars { get; private set; } // Number of oars available

        public RowBoat(string type, string size, double seats, string material, string color, double weight, int yearBuilt, string name, string registrationNumber, string imgpath, int numberOfOars)
            : base(type, size, seats, material, color, weight, yearBuilt, name, registrationNumber, imgpath)
        {
            this.NumberOfOars = numberOfOars;
        }

        public string GetRowBoatDetails()
        {
            return GetBoatDetails() + "\n" +
                   $"Number of Oars: {NumberOfOars}";
        }
    }
}
