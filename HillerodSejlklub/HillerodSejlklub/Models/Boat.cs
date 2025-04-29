using System.Xml.Linq;

namespace HillerodSejlklub.Models
{
    public abstract class Boat
    // Abstract class representing a generic boat
    {
        // Boat properties
        // These properties are protected to allow derived classes to access them directly
        // and can be modified through methods in the base class.


        public static int nextID = 1; // Static variable to keep track of the next ID
        public string Type { get; protected set; } // Type of the boat (e.g., Sailboat, Motorboat, etc.)
        public string Size { get; protected set; } // Size of the boat (e.g., Small, Medium, Large)
        public double Seats { get; protected set; } // Number of seats available on the boat
        public string Material { get; protected set; } // Material of the boat (e.g., Wood, Fiberglass, Aluminum)
        public string Color { get; protected set; } // Color of the boat (e.g., Red, Blue, Green)
        public double Weight { get; protected set; } // Weight of the boat in kg
        public int YearBuilt { get; protected set; } // Year the boat was built
        public string Name { get; protected set; } // Name of the boat
        public string RegistrationNumber { get; protected set; } // Unique identifier for the boat
        public bool IsAvailable { get; protected set; } = true; // Indicates if the boat is available for use
        public List<string> MaintenanceLog { get; private set; } = new List<string>(); // List of maintenance logs
        public string CurrentLocation { get; protected set; } // Location of the boat (e.g., dock, marina)
        public DateTime LastMaintenanceDate { get; protected set; } // Date of last maintenance
        public bool NeedsRepair { get; protected set; } = false; // Indicates if the boat needs repair

        public string IMGPath { get; protected set; } // Path to the image of the boat

        public Boat(string type, string size, double seats, string material, string color, double weight, int yearBuilt, string name, string registrationNumber, string imgpath)
        {
            // Constructor to initialize the boat properties

            Boat.nextID = nextID++; // Increment the static ID for each new boat
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
        }

        public void AddMaintenanceLog(string logEntry)
        // Method to add a maintenance log entry
        {
            MaintenanceLog.Add(logEntry); 
            LastMaintenanceDate = DateTime.Now; 
        }

        public void MarkAsRepaired()
        // Method to mark the boat as repaired
        {
            NeedsRepair = false;
            AddMaintenanceLog("Boat repaired.");
        }

        public void UpdateLocation(string newLocation)
        // Method to update the current location of the boat
        {
            CurrentLocation = newLocation;
        }

        public string GetBoatDetails()
        // Method to get the details of the boat
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
                   $"Current Location: {CurrentLocation}\n" +
                   $"Needs Repair: {NeedsRepair}\n" +
                   $"Last Maintenance Date: {LastMaintenanceDate.ToShortDateString()}";
        }
    }

    public class SailBoat : Boat
    // Derived class representing a sailboat
    {
        // Sailboat-specific properties
        public string SailType { get; private set; } // e.g., Main Sail, Jib, Spinnaker
        public int NumberOfSails { get; private set; } // Number of sails on the boat
        public bool HasKeel { get; private set; }    // Indicates if the sailboat has a keel

        public SailBoat(string type, string size, double seats, string material, string color, double weight, int yearBuilt, string name, string registrationNumber, ,string imgpath, string sailType, int numberOfSails, bool hasKeel)
            : base(type, size, seats, material, color, weight, yearBuilt, name, registrationNumber, imgpath)
        {
            // Constructor to initialize the sailboat properties
            this.SailType = sailType;
            this.NumberOfSails = numberOfSails;
            this.HasKeel = hasKeel;
        }

        public string GetSailBoatDetails()
        // Method to get the details of the sailboat
        {
            return GetBoatDetails() + "\n" +
                   $"Sail Type: {SailType}\n" +
                   $"Number of Sails: {NumberOfSails}\n" +
                   $"Has Keel: {HasKeel}";
        }
    }

    public class MotorBoat : Boat
    // Derived class representing a motorboat
    {
        // Motorboat-specific properties
        public int EnginePower { get; private set; } // Engine power in horsepower (HP)
        public string FuelType { get; private set; } // e.g., Gasoline, Diesel, Electric
        public double FuelCapacity { get; private set; } // Fuel capacity in liters

        public MotorBoat(string type, string size, double seats, string material, string color, double weight, int yearBuilt, string name, string registrationNumber, string imgpath, int EnginePower, string FuelType, double FuelCapacity)
            : base(type, size, seats, material, color, weight, yearBuilt, name, registrationNumber, imgpath)
        {
            // Constructor to initialize the motorboat properties
            this.EnginePower = EnginePower;
            this.FuelType = FuelType;
            this.FuelCapacity = FuelCapacity;
        }

        public string GetMotorBoatDetails()
        // Method to get the details of the motorboat
        {
            return GetBoatDetails() + "\n" +
                   $"Engine Power: {EnginePower} HP\n" +
                   $"Fuel Type: {FuelType}\n" +
                   $"Fuel Capacity: {FuelCapacity} liters";
        }
    }
}
