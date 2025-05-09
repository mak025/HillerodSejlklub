using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerodSejlklub.Pages
{
    public class WelcomeModel : PageModel
    {
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
}
