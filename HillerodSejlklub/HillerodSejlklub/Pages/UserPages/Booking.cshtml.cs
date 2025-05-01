using HillerodSejlklub.Models;
using HillerodSejlklub.Service;
using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerodSejlklub.Pages.UserPages
{
    public class BookingModel : PageModel
    {
        private BookingService _bookingService;
        private BoatService _boatService;
        private MemberService _memberService;

        public DateTime BookingStart {  get; set; }
        public DateTime BookingEnd { get; set; }
        [BindProperty]
        public DateTime _sDT { get; set; }
        [BindProperty]
        public DateTime _eDT { get; set; }
        [BindProperty]
        public string _boatName { get; set; }
        [BindProperty]
        public string _user { get; set; }

        public List<Member> Members { get; private set; }
        public List<Boat> Boats { get; private set; }
        public List<Booking> Bookings { get; private set; }

        private readonly string membersFilePath;

        public BookingModel(IWebHostEnvironment env, BoatService boatS, MemberService memberS, BookingService bookingS)
        {
            membersFilePath = Path.Combine(env.ContentRootPath, "Data", "members.json");
            _boatService = boatS;
            _memberService = memberS;
            _bookingService = bookingS;
            Boats = boatS.GetAll();
            Members = memberS.GetAll();
            Bookings = bookingS.GetAll();
        }

        public void OnGet()
        {
            var username = HttpContext.Session.GetString("Username");
            if (string.IsNullOrEmpty(username))
            {
                // Redirect to login page if not logged in
                Response.Redirect("/Index");
            }
            if (System.IO.File.Exists(membersFilePath))
            {
                var json = System.IO.File.ReadAllText(membersFilePath);

                if (!string.IsNullOrWhiteSpace(json))
                {
                    try
                    {
                        Members = JsonSerializer.Deserialize<List<Member>>(json) ?? new();
                    }
                    catch (Exception ex)
                    {
                        // Log evt. fejl
                        Console.WriteLine("Fejl ved indlæsning af members.json: " + ex.Message);
                        Members = new();
                    }
                }
                else
                {
                    Members = new();
                }
            }
            else
            {
                Members = new();
            }
        }

        public IActionResult OnPost()
        {
            Booking booking = new Booking(_user, _boatName, _sDT, _eDT);
            Debug.WriteLine(_user + _boatName + _sDT);

            CreateBooking(booking);
            return RedirectToPage("/UserPages/Booking");
        }

        public void CreateBooking(Booking booking)
        {
            _bookingService.Add(booking);
            Debug.WriteLine("CreateBooking!");

        }
    }
}
