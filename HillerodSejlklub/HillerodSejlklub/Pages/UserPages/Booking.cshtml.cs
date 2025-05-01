using HillerodSejlklub.Models;
using HillerodSejlklub.Service;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerodSejlklub.Pages.UserPages
{
    public class BookingModel : PageModel
    {
        private BookingService _bookingService;
        private BoatService _boatService;
        private MemberService _memberService;

        public List<int> _mID = new List<int>();
        public int _boatID;
        public DateTime _sDT;
        public DateTime _eDT;
        public List<Member> Members { get; private set; }
        [BindProperty]
        public List<Boat> Boats { get; private set; }

        public BookingModel(BoatService boatS, MemberService memberS, BookingService bookingS)
        {
            //_bookService = bookingS;
            _boatService = boatS;
            _memberService = memberS;
            _bookingService = bookingS;
            Boats = boatS.GetAll();
            Members = memberS.GetAll();
        }

        public void OnGet()
        {
             
        }

        public IActionResult OnPostBook()
        {
            _bookingService.Add(new Booking(_mID, _boatID, _sDT, _eDT));
            return RedirectToPage("/Index");
        }
    }
}
