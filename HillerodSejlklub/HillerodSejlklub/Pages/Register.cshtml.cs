using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HillerodSejlklub.Model;
using HillerodSejlklub.Models;
using HillerodSejlklub.Interface;

namespace HillerodSejlklub.Pages
{
    
    ///<summary>
    /// Represents the model for the Register page.
    /// </summary>
    public class RegisterModel : PageModel
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
        /// Gets or sets the name entered by the user.
        /// </summary>
        [BindProperty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the phone number entered by the user.
        /// </summary>
        [BindProperty]
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the email address entered by the user.
        /// </summary>
        [BindProperty]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user is an administrator.
        /// </summary>
        [BindProperty]
        public bool isadministrator { get; set; } = false;

        /// <summary>
        /// Gets or sets the message to be displayed to the user.
        /// </summary>
        public string Message { get; set; }

        private readonly string loginFilePath;
        private readonly string membersFilePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterModel"/> class.
        /// </summary>
        /// <param name="env">The hosting environment.</param>
        public RegisterModel(IWebHostEnvironment env)
        {
            loginFilePath = Path.Combine(env.ContentRootPath, "Data", "login.json");
            membersFilePath = Path.Combine(env.ContentRootPath, "Data", "members.json");
        }

        /// <summary>
        /// Gets or sets the list of members.
        /// </summary>
        public List<Member> Members { get; set; } = new();

        /// <summary>
        /// Handles GET requests to the Register page.
        /// </summary>
        public void OnGet()
        {
        }

        /// <summary>
        /// Handles POST requests to the Register page.
        /// </summary>
        /// <returns>
        /// The result of the POST operation. If the registration is successful, the user is informed with a success message. 
        /// If any required fields are missing, the user is prompted to fill all fields. 
        /// If the username is already taken, the user is informed about the conflict.
        /// </returns>
        /// <remarks>
        /// This method performs the following actions:
        /// 1. Validates that all required fields (Username, Password, Name, Phone, Email) are filled. 
        ///    If any field is missing, a message "Alle felter skal udfyldes." is displayed to the user.
        /// 2. Checks if the provided username already exists in the login data. 
        ///    If the username is taken, a message "Brugernavn findes allerede." is displayed to the user.
        /// 3. Assigns a random avatar image from a predefined list of avatar images to the new member. 
        ///    This image is used as the profile picture for the member.
        /// 4. Saves the new user credentials (username and password) to the login file (`login.json`).
        /// 5. Creates a new member record with the provided details and the assigned avatar image, 
        ///    and saves it to the members file (`members.json`).
        /// 6. If all operations are successful, a success message "Bruger og medlem oprettet!" is displayed to the user.
        /// </remarks>
        public IActionResult OnPost()
        {
            var AvatarImages = new[]
            {
                "Avatar1.jpg",
                "Avatar2.jpg",
                "Avatar3.jpg",
                "Avatar4.jpg",
                "Avatar5.jpg",
                "Avatar6.jpg",
                "Avatar7.jpg",
                "Avatar8.jpg",
                "Avatar9.jpg",
                "Avatar10.jpg",
                "Avatar11.jpg"
            };

            var random = new Random();
            var selectedImage = AvatarImages[random.Next(AvatarImages.Length)];

            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password)
                || string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Phone) || string.IsNullOrWhiteSpace(Email))
            {
                Message = "Alle felter skal udfyldes.";
                return Page();
            }

            // --- Save Login ---
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
                PasswordHash = Password // TODO: Hash password in the future.
            };

            users.Add(newUser);
            System.IO.File.WriteAllText(loginFilePath, JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true }));

            // --- Save Member ---
            var members = new List<Member>();
            if (System.IO.File.Exists(membersFilePath))
            {
                var json = System.IO.File.ReadAllText(membersFilePath);
                members = JsonSerializer.Deserialize<List<Member>>(json) ?? new();
            }

            var newMember = new Member(Name, Phone, Email, Username, selectedImage, isadministrator)
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

