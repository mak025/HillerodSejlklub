using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HillerodSejlklub.Models;
using HillerodSejlklub.Interface;
using System.Collections.Generic;
using System.Diagnostics;

namespace HillerodSejlklub.Pages.AdminPages
{
    public class ManageBoatsModel : PageModel
    {
        private readonly BoatCollection _boatCollection;

        public List<Boat> Boats { get; set; } = new();
        [BindProperty]
        public List<string> MaintenanceLog {  get; set; } = new();
        [BindProperty]
        public int Id { get; set; }

        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public string Type { get; set; }

        [BindProperty]
        public string Size { get; set; }

        [BindProperty]
        public double Seats { get; set; }

        [BindProperty]
        public string Material { get; set; }

        [BindProperty]
        public string Color { get; set; }

        [BindProperty]
        public double Weight { get; set; }

        [BindProperty]
        public int YearBuilt { get; set; }

        [BindProperty]
        public string RegistrationNumber { get; set; }

        [BindProperty]
        public string IMGPath { get; set; }

        public ManageBoatsModel(BoatCollection boatCollection)
        {
            _boatCollection = boatCollection;
        }

        public void OnGet()
        {
            // Fetch the list of boats from the JSON file
            Boats = _boatCollection.GetAllBoats();
        }

        public IActionResult OnPostAddBoat()
        {
            // Create a new boat object
            var newBoat = new Boat(
                Type,
                Size,
                Seats,
                Material,
                Color,
                Weight,
                YearBuilt,
                Name,
                RegistrationNumber,
                IMGPath
            );

            // Add the new boat to the collection
            _boatCollection.Add(newBoat);

            // Redirect to refresh the page and show the updated list
            return RedirectToPage();
        }

        public IActionResult OnPostEditBoat()
        {
            Debug.WriteLine("OnPostEdit");
            // Find the boat to edit
            var boatToEdit = _boatCollection.GetAllBoats().FirstOrDefault(b => b.ID == Id);
            if (boatToEdit == null)
            {
                return NotFound();
            }
            Debug.WriteLine(boatToEdit.Name);

            // Update the boat details
            boatToEdit.Name = Name;
            boatToEdit.Type = Type;
            boatToEdit.Size = Size;
            boatToEdit.Seats = Seats;
            boatToEdit.Material = Material;
            boatToEdit.Color = Color;
            boatToEdit.Weight = Weight;
            boatToEdit.YearBuilt = YearBuilt;
            boatToEdit.RegistrationNumber = RegistrationNumber;
            boatToEdit.IMGPath = IMGPath;

            // Save the updated list back to the JSON file
            _boatCollection.Add(boatToEdit);

            // Redirect to refresh the page and show the updated list
            return RedirectToPage();
        }
        public IActionResult OnPostDeleteBoat(int id)
        {
            Console.WriteLine($"DeleteBoat called with ID: {id}");
            var boatToDelete = _boatCollection.GetAllBoats().FirstOrDefault(b => b.ID == id);
            if (boatToDelete == null)
            {
                Console.WriteLine("Boat not found.");
                return NotFound();
            }

            Debug.WriteLine($"Deleting boat: {boatToDelete.Name}");
            _boatCollection.Remove(boatToDelete);

            return RedirectToPage();
        }
         public IActionResult OnPostLog(Boat boat)
        {
            Debug.WriteLine("OnPostLog");
            MaintenanceLog = boat.MaintenanceLog;
            return RedirectToPage();
        }

    }
}
