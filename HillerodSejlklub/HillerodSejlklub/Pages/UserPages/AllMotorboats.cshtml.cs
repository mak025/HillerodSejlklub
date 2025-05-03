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
    /// Represents the Razor Page model for displaying available motorboats.  
    /// </summary>  
    public class AvailableMotorBoatsModel : PageModel
    {
        private readonly IBoat _boatCollection;

        /// <summary>  
        /// Gets the list of available motorboats.  
        /// </summary>  
        public List<Boat> AvailableBoats { get; private set; }

        /// <summary>  
        /// Initializes a new instance of the <see cref="AvailableMotorBoatsModel"/> class.  
        /// </summary>  
        /// <param name="boatCollection">The boat collection interface for retrieving boats.</param>  
        public AvailableMotorBoatsModel(IBoat boatCollection)
        {
            _boatCollection = boatCollection;
        }

        /// <summary>  
        /// Handles GET requests to fetch and display available motorboats.  
        /// </summary>  
        public void OnGet()
        {
            var username = HttpContext.Session.GetString("Username");
            if (string.IsNullOrEmpty(username))
            {
                // Redirect to login page if not logged in  
                Response.Redirect("/Index");
            }

            // Fetch available motorboats from the collection  
            AvailableBoats = _boatCollection.GetAllBoats()
                .Where(boat => boat.Type == "Motorboat" && boat.IsAvailable)
                .ToList();

            // Debug: Log the count and details of available motorboats  
            Debug.WriteLine($"Available Motorboat Count: {AvailableBoats.Count}");
            foreach (var boat in AvailableBoats)
            {
                Debug.WriteLine($"Boat Name: {boat.Name}, Type: {boat.Type}, IsAvailable: {boat.IsAvailable}");
            }
        }
    }
}
