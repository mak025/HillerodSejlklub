using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HillerodSejlklub.Models;
using HillerodSejlklub.Interface;
using System.Collections.Generic;
using HillerodSejlklub.Service;
using System.Diagnostics;

namespace HillerodSejlklub.Pages.UserPages
{
    public class AvailableBoatsModel : PageModel
    {
        private readonly BoatCollection _boatCollection;
        public List<Boat> AvailableBoats { get; private set; }

        public AvailableBoatsModel()
        {
            // Fixing typo in field name '_boatColleciton' to '_boatCollection'
            _boatCollection = new BoatCollection();

            // Initializing 'AvailableBoats' to avoid nullability issues
            //AvailableBoats = new List<Boat>();
        }

        public void OnGet()
        {
            // Fixing invalid use of 'base' keyword and ensuring proper LINQ usage
            AvailableBoats = _boatCollection
                .GetAllBoats() // Assuming this method exists in 'BoatCollection'
                .Where(boat => boat.IsAvailable) // Correcting 'base' to 'boat'
                .ToList();
        }
        public IActionResult OnPostBook(int boatID)
        {
            Debug.WriteLine("hej");

            Boat bound = _boatCollection.Get(boatID);

            Debug.WriteLine("onPostBook ");
            return RedirectToPage("/Booking", new { boatID = Boat.nextID});
        }
    }
}
