using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HillerodSejlklub.Model;

namespace HillerodSejlklub.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        private string filePath;
        public LoginModel(IWebHostEnvironment env)
        {
            // Antager at filen ligger i en "Data" mappe i projektroden
            filePath = Path.Combine(env.ContentRootPath, "Data", "login.json");
        }

        public string ErrorMessage { get; set; }

        public IActionResult OnPost()
        {
            var users = JsonSerializer.Deserialize<List<UserModel>>(System.IO.File.ReadAllText(filePath));

            var user = users.FirstOrDefault(u => u.Username == Username && u.PasswordHash == Password);
            if (user != null)
            {
                HttpContext.Session.SetString("Username", Username);
                return RedirectToPage("Index");
            }

            ErrorMessage = "Ugyldigt login";
            return Page();
        }
    }

}
