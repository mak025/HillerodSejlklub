using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HillerodSejlklub.Models;
using HillerodSejlklub.Service;
using HillerodSejlklub.Interface;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace HillerodSejlklub.Pages;

/// <summary>  
/// Represents the Index page model for the application.  
/// </summary>  
public class IndexModel : PageModel
{
    private readonly BookingService _bookingService;
    private readonly BoatService _boatService;

    /// <summary>  
    /// Gets or sets the list of boats available.  
    /// </summary>  
    [BindProperty]
    public List<Boat> Boats { get; set; }

    /// <summary>  
    /// Gets or sets the list of bookings.  
    /// </summary>  
    public List<Booking> Bookings { get; set; }

    private readonly ILogger<IndexModel> _logger;

    /// <summary>  
    /// Initializes a new instance of the <see cref="IndexModel"/> class.  
    /// </summary>  
    /// <param name="logger">The logger instance.</param>  
    /// <param name="boatS">The boat service instance.</param>  
    /// <param name="bookingS">The booking service instance.</param>  
    public IndexModel(ILogger<IndexModel> logger, BoatService boatS, BookingService bookingS)
    {
        _logger = logger;
        Boats = boatS.GetAll();
        _boatService = boatS;
        Bookings = bookingS.GetAll();
        _bookingService = bookingS;
    }

    /// <summary>  
    /// Handles GET requests to the Index page.  
    /// </summary>  
    public void OnGet()
    {
        var username = HttpContext.Session.GetString("Username");
        if (string.IsNullOrEmpty(username))
        {
            // Redirect to login page if not logged in  
            Response.Redirect("/Index");
        }
    }
}
