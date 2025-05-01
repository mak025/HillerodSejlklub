using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HillerodSejlklub.Model;
using HillerodSejlklub.Models;
using HillerodSejlklub.Interface;

namespace HillerodSejlklub.Pages
{
    
        public class RegisterModel : PageModel
        {
            [BindProperty] public string Username { get; set; }
            [BindProperty] public string Password { get; set; }
            [BindProperty] public string Name { get; set; }
            [BindProperty] public string Phone { get; set; }
            [BindProperty] public string Email { get; set; }

            public string Message { get; set; }

            private readonly string loginFilePath;
            private readonly string membersFilePath;

            public RegisterModel(IWebHostEnvironment env)
            {
                loginFilePath = Path.Combine(env.ContentRootPath, "Data", "login.json");
                membersFilePath = Path.Combine(env.ContentRootPath, "Data", "members.json");

        }
        public List<Member> Members { get; set; } = new();
        public void OnGet()
            {
            }

            public IActionResult OnPost()
            {
                if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password)
                    || string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Phone) || string.IsNullOrWhiteSpace(Email))
                {
                    Message = "Alle felter skal udfyldes.";
                    return Page();
                }

                // --- GEM LOGIN ---
                var users = new List<UserModel>();
                if (System.IO.File.Exists(loginFilePath))
                {
                    var json = System.IO.File.ReadAllText(loginFilePath);
                    users = JsonSerializer.Deserialize<List<UserModel>>(json) ?? new();
                }

                if (users.Any(u => u.Username.Equals(Username, StringComparison.OrdinalIgnoreCase)))
                {
                    Message = "Brugernavn findes allerede.";
                    return Page();
                }

                var newUser = new UserModel
                {
                    Username = Username,
                    PasswordHash = Password // OBS: hash på sigt!
                };

                users.Add(newUser);
                System.IO.File.WriteAllText(loginFilePath, JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true }));



            var avatarImages = new[]
{
               "avatar1.png",
               "avatar2.png",
               "avatar3.png",
               "avatar4.png",
               "avatar5.png",
               "avatar6.png",
               "avatar7.png",
               "avatar8.png",
               "avatar9.png",
               "avatar10.png",
               "avatar11.png"
};

            var random = new Random();
            var selectedImage = avatarImages[random.Next(avatarImages.Length)];



            // --- GEM MEDLEM ---
            var members = new List<Member>();
                if (System.IO.File.Exists(membersFilePath))
                {
                    var json = System.IO.File.ReadAllText(membersFilePath);
                    members = JsonSerializer.Deserialize<List<Member>>(json) ?? new();
                }

                var newMember = new Member(Name, Phone, Email, Username, selectedImage)
                {
                    ID = members.Count + 1
                };

                members.Add(newMember);
            System.IO.File.WriteAllText(membersFilePath,
            JsonSerializer.Serialize(members, new JsonSerializerOptions { WriteIndented = true }));


            Message = "Bruger og medlem oprettet!";
                return Page();
            }
        }
    }

