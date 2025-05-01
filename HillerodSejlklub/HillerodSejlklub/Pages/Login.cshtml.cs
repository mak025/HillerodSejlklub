using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HillerodSejlklub.Model;
using System.IO;

namespace HillerodSejlklub.Pages
{
   
        public class LoginModel : PageModel
        {
            [BindProperty]
            public string Username { get; set; }

            [BindProperty]
            public string Password { get; set; }

            public string ErrorMessage { get; set; }

            private readonly string filePath;

            public LoginModel(IWebHostEnvironment env)
            {
                filePath = Path.Combine(env.ContentRootPath, "Data", "login.json");
            }

            public void OnGet()
            {
            }

            public IActionResult OnPost()
            {
                if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
                {
                    ErrorMessage = "Udfyld både brugernavn og adgangskode.";
                    return Page();
                }

                List<UserModel> users = new();

                if (System.IO.File.Exists(filePath))
                {
                    var json = System.IO.File.ReadAllText(filePath);
                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        users = JsonSerializer.Deserialize<List<UserModel>>(json) ?? new();
                    }
                }

                var user = users.FirstOrDefault(u => u.Username == Username && u.PasswordHash == Password);

                if (user == null)
                {
                    ErrorMessage = "Forkert brugernavn eller adgangskode.";
                    return Page();
                }

                // Hvis login er korrekt, kan vi evt. sætte en session eller gå til en ny side
                return RedirectToPage("/Welcome"); // Du skal lave en Welcome.cshtml side hvis du vil
            }
        }
    }


