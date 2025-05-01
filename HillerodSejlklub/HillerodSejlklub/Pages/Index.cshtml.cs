
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using HillerodSejlklub.Model;

namespace HillerodSejlklub.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty] public string Username { get; set; }
        [BindProperty] public string Password { get; set; }

        public string ErrorMessage { get; set; }
        public string Message { get; set; }

        private readonly string loginFilePath;

        public LoginModel(IWebHostEnvironment env)
        {
            loginFilePath = Path.Combine(env.ContentRootPath, "Data", "login.json");
        }

        public void OnGet() { }

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
            // return RedirectToPage("/Members"); ← aktiver når test virker
            return RedirectToPage("/Forside");
        }
        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear(); // Clear all session data
            return RedirectToPage("/Index"); // Redirect to the login page
        }
    }
}

