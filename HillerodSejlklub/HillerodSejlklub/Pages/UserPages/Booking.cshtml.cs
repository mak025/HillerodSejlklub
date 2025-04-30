using HillerodSejlklub.Models;
using HillerodSejlklub.Service;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerodSejlklub.Pages.UserPages
{
    public class BookingModel : PageModel
    {
        private BookingService _bookService;
        private BoatService _boatService;
        private MemberService _memberService;
        [BindProperty]
        public Booking Booking { get; set; }
        private List<Member> Members { get; set; }
        public int Lokale { get; set; }

        public BookingModel(BookingService bookingS, BoatService boatS, MemberService memberS)
        {
            _bookService = bookingS;
            _boatService = boatS;
            _memberService = memberS;
            _members = memberS.GetAll();
        }

        public void OnGet()
        {
            //Booking.EndDateTime = Booking.StartDateTime.Date;
        }

        public IActionResult OnPost()
        {
            Booking = new Booking();
            Debug.WriteLine("test " + Booking.BookingID);
            _bookService.Add(Booking);
            return RedirectToPage("/BookingEditor");
        }
    }
}
