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
    /// Represents the model for the Available Rowboats page.
    /// </summary>
    public class AvailableRowBoatsModel : PageModel
    {
        private readonly IBoat _boatCollection;

        /// <summary>
        /// Gets the list of available rowboats.
        /// </summary>
        public List<Boat> AvailableBoats { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AvailableRowBoatsModel"/> class.
        /// </summary>
        /// <param name="boatCollection">The boat collection service.</param>
        public AvailableRowBoatsModel(IBoat boatCollection)
        {
            _boatCollection = boatCollection;
        }

        /// <summary>
        /// Handles GET requests to fetch available rowboats.
        /// </summary>
        public void OnGet()
        {
            var username = HttpContext.Session.GetString("Username");
            if (string.IsNullOrEmpty(username))
            {
                // Redirect to login page if not logged in
                Response.Redirect("/Index");
            }

            // Fetch available Rowboats from the JSON file
            AvailableBoats = _boatCollection.GetAllBoats()
                .Where(boat => boat.Type == "Rowboat" && boat.IsAvailable)
                .ToList();

            // Debug: Check if Rowboats are being loaded
            Debug.WriteLine($"Available Rowboats Count: {AvailableBoats.Count}");
            foreach (var boat in AvailableBoats)
            {
                Debug.WriteLine($"Boat Name: {boat.Name}, Type: {boat.Type}, IsAvailable: {boat.IsAvailable}");
            }
        }
    }
}