
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using HillerodSejlklub.Model;

namespace HillerodSejlklub.Pages
{
    /// <summary>
    /// The LoginModel class handles user login and logout functionality for the Razor Page.
    /// </summary>
    public class LoginModel : PageModel
    {
        /// <summary>
        /// Gets or sets the username entered by the user.
        /// </summary>
        [BindProperty]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password entered by the user.
        /// </summary>
        [BindProperty]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the error message to display when login fails.
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets the success message to display when login succeeds.
        /// </summary>
        public string Message { get; set; }

        private readonly string loginFilePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginModel"/> class.
        /// </summary>
        /// <param name="env">The hosting environment to determine the file path for login data.</param>
        public LoginModel(IWebHostEnvironment env)
        {
            loginFilePath = Path.Combine(env.ContentRootPath, "Data", "login.json");
        }

        /// <summary>
        /// Handles GET requests to the login page.
        /// </summary>
        public void OnGet() { }

        /// <summary>
        /// Handles POST requests for user login.
        /// </summary>
        /// <returns>A redirection to the appropriate page based on login success or failure.</returns>
        public IActionResult OnPost()
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                ErrorMessage = "Udfyld både brugernavn og adgangskode.";
                return Page();
            }

            var users = new List<UserModel>();
            if (System.IO.File.Exists(loginFilePath))
            {
                var json = System.IO.File.ReadAllText(loginFilePath);
                users = JsonSerializer.Deserialize<List<UserModel>>(json) ?? new();
            }

            var user = users.FirstOrDefault(u =>
                u.Username.Equals(Username, StringComparison.OrdinalIgnoreCase) &&
                u.PasswordHash == Password);

            if (user == null)
            {
                ErrorMessage = "Forkert brugernavn eller adgangskode.";
                return Page();
            }

            // Store the username in the session
            HttpContext.Session.SetString("Username", user.Username);

            // Store the IsAdministrator value in the session
            HttpContext.Session.SetString("IsAdministrator", user.IsAdministrator.ToString().ToLower());

            Message = "Login lykkedes!";
            return RedirectToPage("/Forside");
        }

        /// <summary>
        /// Handles POST requests for user logout.
        /// </summary>
        /// <returns>A redirection to the login page after clearing session data.</returns>
        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear(); // Clear all session data
            return RedirectToPage("/Index"); // Redirect to the login page
        }
    }
}

