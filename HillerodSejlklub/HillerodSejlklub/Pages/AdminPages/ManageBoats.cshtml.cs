using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HillerodSejlklub.Models;
using HillerodSejlklub.Interface;
using System.Collections.Generic;
using System.Diagnostics;

namespace HillerodSejlklub.Pages.AdminPages
{
    /// <summary>
    /// PageModel for managing boats in the admin section.
    /// </summary>
    public class ManageBoatsModel : PageModel
    {
        private readonly BoatCollection _boatCollection;

        /// <summary>
        /// Gets or sets the list of boats.
        /// </summary>
        public List<Boat> Boats { get; set; } = new();

        /// <summary>
        /// Gets or sets the maintenance log for a boat.
        /// </summary>
        [BindProperty]
        public List<string> MaintenanceLog { get; set; } = new();

        /// <summary>
        /// Gets or sets the ID of the boat being managed.
        /// </summary>
        [BindProperty]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the boat.
        /// </summary>
        [BindProperty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type of the boat.
        /// </summary>
        [BindProperty]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the size of the boat.
        /// </summary>
        [BindProperty]
        public string Size { get; set; }

        /// <summary>
        /// Gets or sets the number of seats on the boat.
        /// </summary>
        [BindProperty]
        public double Seats { get; set; }

        /// <summary>
        /// Gets or sets the material of the boat.
        /// </summary>
        [BindProperty]
        public string Material { get; set; }

        /// <summary>
        /// Gets or sets the color of the boat.
        /// </summary>
        [BindProperty]
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets the weight of the boat.
        /// </summary>
        [BindProperty]
        public double Weight { get; set; }

        /// <summary>
        /// Gets or sets the year the boat was built.
        /// </summary>
        [BindProperty]
        public int YearBuilt { get; set; }

        /// <summary>
        /// Gets or sets the registration number of the boat.
        /// </summary>
        [BindProperty]
        public string RegistrationNumber { get; set; }

        /// <summary>
        /// Gets or sets the image path of the boat.
        /// </summary>
        [BindProperty]
        public string IMGPath { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManageBoatsModel"/> class.
        /// </summary>
        /// <param name="boatCollection">The collection of boats.</param>
        public ManageBoatsModel(BoatCollection boatCollection)
        {
            _boatCollection = boatCollection;
        }

        /// <summary>
        /// Handles GET requests to fetch the list of boats.
        /// </summary>
        public void OnGet()
        {
            Boats = _boatCollection.GetAllBoats();
        }

        /// <summary>
        /// Handles POST requests to add a new boat.
        /// </summary>
        /// <returns>A redirection to the same page.</returns>
        public IActionResult OnPostAddBoat()
        {
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

            _boatCollection.Add(newBoat);
            return RedirectToPage();
        }

        /// <summary>
        /// Handles POST requests to edit an existing boat.
        /// </summary>
        /// <returns>A redirection to the same page or a NotFound result if the boat is not found.</returns>
        public IActionResult OnPostEditBoat()
        {
            Debug.WriteLine("OnPostEdit");
            var boatToEdit = _boatCollection.GetAllBoats().FirstOrDefault(b => b.ID == Id);
            if (boatToEdit == null)
            {
                return NotFound();
            }

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

            _boatCollection.Add(boatToEdit);
            return RedirectToPage();
        }

        /// <summary>
        /// Handles POST requests to delete a boat.
        /// </summary>
        /// <param name="id">The ID of the boat to delete.</param>
        /// <returns>A redirection to the same page or a NotFound result if the boat is not found.</returns>
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

        /// <summary>
        /// Handles POST requests to log maintenance for a boat.
        /// </summary>
        /// <param name="boat">The boat for which to log maintenance.</param>
        /// <returns>A redirection to the same page.</returns>
        public IActionResult OnPostLog(Boat boat)
        {
            Debug.WriteLine("OnPostLog");
            MaintenanceLog = boat.MaintenanceLog;
            return RedirectToPage();
        }
    }
}
