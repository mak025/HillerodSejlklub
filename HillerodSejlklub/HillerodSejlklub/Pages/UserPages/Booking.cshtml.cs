using HillerodSejlklub.Models;
using HillerodSejlklub.Service;
using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerodSejlklub.Pages.UserPages
{
    /// <summary>
    /// Represents the Booking page model for handling user bookings.
    /// </summary>
    public class BookingModel : PageModel
    {
        private BookingService _bookingService;
        private BoatService _boatService;
        private MemberService _memberService;

        /// <summary>
        /// Gets or sets the start date of the booking.
        /// </summary>
        public DateTime BookingStart { get; set; }

        /// <summary>
        /// Gets or sets the end date of the booking.
        /// </summary>
        public DateTime BookingEnd { get; set; }

        /// <summary>
        /// Gets or sets the start date and time for the booking (bound property).
        /// </summary>
        [BindProperty]
        public DateTime _sDT { get; set; }

        /// <summary>
        /// Gets or sets the end date and time for the booking (bound property).
        /// </summary>
        [BindProperty]
        public DateTime _eDT { get; set; }

        /// <summary>
        /// Gets or sets the name of the boat for the booking (bound property).
        /// </summary>
        [BindProperty]
        public string _boatName { get; set; }

        /// <summary>
        /// Gets or sets the username of the user making the booking (bound property).
        /// </summary>
        [BindProperty]
        public string _user { get; set; }

        /// <summary>
        /// Gets the list of members.
        /// </summary>
        public List<Member> Members { get; private set; }

        /// <summary>
        /// Gets the list of boats.
        /// </summary>
        public List<Boat> Boats { get; private set; }

        /// <summary>
        /// Gets the list of bookings.
        /// </summary>
        public List<Booking> Bookings { get; private set; }

        private readonly string membersFilePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookingModel"/> class.
        /// </summary>
        /// <param name="env">The hosting environment.</param>
        /// <param name="boatS">The boat service.</param>
        /// <param name="memberS">The member service.</param>
        /// <param name="bookingS">The booking service.</param>
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

        /// <summary>
        /// Handles GET requests for the Booking page.
        /// </summary>
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
                        // Log error
                        Console.WriteLine("Error loading members.json: " + ex.Message);
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

        /// <summary>
        /// Handles POST requests for creating a new booking.
        /// </summary>
        /// <returns>A redirection to the Booking page.</returns>
        public IActionResult OnPost()
        {
            Booking booking = new Booking(_user, _boatName, _sDT, _eDT);
            Debug.WriteLine(_user + _boatName + _sDT);

            CreateBooking(booking);
            return RedirectToPage("/UserPages/Booking");
        }

        /// <summary>
        /// Creates a new booking and adds it to the booking service.
        /// </summary>
        /// <param name="booking">The booking to create.</param>
        public void CreateBooking(Booking booking)
        {
            _bookingService.Add(booking);
            Debug.WriteLine("CreateBooking!");
        }
    }
}
