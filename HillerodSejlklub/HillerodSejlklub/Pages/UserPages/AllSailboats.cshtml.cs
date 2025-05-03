using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HillerodSejlklub.Models;
using HillerodSejlklub.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using HillerodSejlklub.Repo;

namespace HillerodSejlklub.Pages.UserPages
{
    /// <summary>
    /// Represents the model for the Available Sailboats page.
    /// </summary>
    public class AvailableSailBoatsModel : PageModel
    {
        private readonly IBoat _boatCollection;

        /// <summary>
        /// Gets the list of available sailboats.
        /// </summary>
        public List<Boat> AvailableBoats { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AvailableSailBoatsModel"/> class.
        /// </summary>
        /// <param name="boatCollection">The boat collection service.</param>
        public AvailableSailBoatsModel(IBoat boatCollection)
        {
            _boatCollection = boatCollection;
        }

        /// <summary>
        /// Handles GET requests to load available sailboats.
        /// </summary>
        public void OnGet()
        {
            var username = HttpContext.Session.GetString("Username");
            if (string.IsNullOrEmpty(username))
            {
                // Redirect to login page if not logged in
                Response.Redirect("/Index");
            }

            // Fetch available sailboats from the JSON file
            AvailableBoats = _boatCollection.GetAllBoats()
                .Where(boat => boat.Type == "Sailboat" && boat.IsAvailable)
                .ToList();

            // Debug: Check if sailboats are being loaded
            Debug.WriteLine($"Available Sailboats Count: {AvailableBoats.Count}");
            foreach (var boat in AvailableBoats)
            {
                Debug.WriteLine($"Boat Name: {boat.Name}, Type: {boat.Type}, IsAvailable: {boat.IsAvailable}");
            }
        }
    }
}

