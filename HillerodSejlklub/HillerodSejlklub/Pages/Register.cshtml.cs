using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mikroprojekt_2.Model;

namespace Mikroprojekt_2.Pages
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using System.Text.Json;

    public class RegisterModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string Message { get; set; }

        private readonly string filePath;

        public RegisterModel(IWebHostEnvironment env)
        {
            filePath = Path.Combine(env.ContentRootPath, "Data", "login.json");
        }

        public void OnGet() { }

        public IActionResult OnPost()
        {
            var newUser = new UserModel
            {
                Username = Username,
                PasswordHash = Password
            };

            List<UserModel> users = new();

            // Hvis filen findes, indlæs eksisterende brugere
            if (System.IO.File.Exists(filePath))
            {
                var json = System.IO.File.ReadAllText(filePath);
                if (!string.IsNullOrWhiteSpace(json))
                {
                    users = JsonSerializer.Deserialize<List<UserModel>>(json) ?? new();
                }
            }

            // Tjek om brugernavn allerede findes
            if (users.Any(u => u.Username == Username))
            {
                Message = "Brugernavn findes allerede.";
                return Page();
            }

            users.Add(newUser);

            var updatedJson = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
            System.IO.File.WriteAllText(filePath, updatedJson);

            Message = "Bruger oprettet!";
            return Page();
        }
    }


}
