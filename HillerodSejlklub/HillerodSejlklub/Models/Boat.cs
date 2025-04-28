namespace HillerodSejlklub.Models
{
    public abstract class Boat
    {
        public string Type { get; protected set; }
        public string Size { get; protected set; }
        public double Seats { get; protected set; }
        public string Material { get; protected set; }
        public string Color { get; protected set; }
        public double Weight { get; protected set; }
        public int YearBuilt { get; protected set; }
        public string Name { get; protected set; }
        public string RegistrationNumber { get; protected set; }
        public bool IsAvailable { get; protected set; } = true;
        public List<string> MaintenanceLog { get; private set; } = new List<string>();
        public string CurrentLocation { get; protected set; }
        public DateTime LastMaintenanceDate { get; protected set; }
        public bool NeedsRepair { get; protected set; } = false;

        public Boat(string type, string size, double seats, string material, string color, double weight, int yearBuilt, string name, string registrationNumber)
        {
            Type = type;
            Size = size;
            Seats = seats;
            Material = material;
            Color = color;
            Weight = weight;
            YearBuilt = yearBuilt;
            Name = name;
            RegistrationNumber = registrationNumber;
        }

        public void AddMaintenanceLog(string logEntry)
        {
            MaintenanceLog.Add(logEntry);
            LastMaintenanceDate = DateTime.Now;
        }

        public void MarkAsRepaired()
        {
            NeedsRepair = false;
            AddMaintenanceLog("Boat repaired.");
        }

        public void UpdateLocation(string newLocation)
        {
            CurrentLocation = newLocation;
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
                   $"Current Location: {CurrentLocation}\n" +
                   $"Needs Repair: {NeedsRepair}\n" +
                   $"Last Maintenance Date: {LastMaintenanceDate.ToShortDateString()}";
        }
    }

    public class SailBoat : Boat
    {
        public string SailType { get; private set; } // e.g., Main Sail, Jib, Spinnaker
        public int NumberOfSails { get; private set; }
        public bool HasKeel { get; private set; }    // Indicates if the sailboat has a keel

        public SailBoat(string type, string size, double seats, string material, string color, double weight, int yearBuilt, string name, string registrationNumber, string sailType, int numberOfSails, bool hasKeel)
            : base(type, size, seats, material, color, weight, yearBuilt, name, registrationNumber)
        {
            SailType = sailType;
            NumberOfSails = numberOfSails;
            HasKeel = hasKeel;
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

        public MotorBoat(string type, string size, double seats, string material, string color, double weight, int yearBuilt, int enginePower, string fuelType, double fuelCapacity)
            : base(type, size, seats, material, color, weight, yearBuilt, name: null, registrationNumber: null)
        {
            EnginePower = enginePower;
            FuelType = fuelType;
            FuelCapacity = fuelCapacity;
        }

        public string GetMotorBoatDetails()
        {
            return GetBoatDetails() + "\n" +
                   $"Engine Power: {EnginePower} HP\n" +
                   $"Fuel Type: {FuelType}\n" +
                   $"Fuel Capacity: {FuelCapacity} liters";
        }
    }
}
