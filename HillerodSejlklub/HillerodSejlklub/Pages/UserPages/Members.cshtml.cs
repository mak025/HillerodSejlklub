using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerodSejlklub.Pages.UserFunctions
{
    /// <summary>
    /// Razor Page Model for managing members.
    /// </summary>
    public class MemebrsModel : PageModel
    {
        /// <summary>
        /// Handles GET requests to the Members page.
        /// Redirects to the login page if the user is not logged in.
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
}
