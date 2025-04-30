using HillerodSejlklub.Models;
using HillerodSejlklub.Service;
using HillerodSejlklub.Interface;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace HillerodSejlklub.Pages;

public class IndexModel : PageModel
{
    private readonly BookingService _bookingService;
    private readonly BoatService _boatService;
    [BindProperty]
    public List<Boat> Boats { get; set; }

    public List<Booking> Bookings { get; set; }
    //List<Booking> _activeBookings = new List<Booking>();

    private readonly ILogger<IndexModel> _logger;


    //bool _isBooked = false;
    //[BindProperty]
    //public int filterCap { get; set; }
    //[BindProperty]
    //public bool filterWB { get; set; }
    //[BindProperty]
    //public bool filterSB { get; set; }
    //[BindProperty]
    //public DateOnly filterDate { get; set; }

    //bool dateIsSet = false;

    public IndexModel(ILogger<IndexModel> logger, BoatService boatS, BookingService bookingS)
    {
        //if (!dateIsSet)
        //    filterDate = DateOnly.FromDateTime(DateTime.Now.Date);

        _logger = logger;
        Boats = boatS.GetAll();
        _boatService = boatS;
        Bookings = bookingS.GetAll();
        _bookingService = bookingS;
    }

    public void OnGet()
    {

    }
    public IActionResult OnPostBook(string boatReg, DateOnly bookingDate)
    {
        Debug.WriteLine("hej");

        Boat bound = _boatService.Get(boatReg);

        Debug.WriteLine("onPostBook " + bookingDate);
        return RedirectToPage("/Form", new { roomname = bound.RegistrationNumber, roomdate = bookingDate });
    }
}
