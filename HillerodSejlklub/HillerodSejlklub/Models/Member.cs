
    namespace HillerodSejlklub.Models
    {
        public class Member
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Username { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
            public string ProfileImage { get; set; }
            // Added property for admin status
            public bool IsAdministrator { get; set; } // Determines if the member is an admin

        public Member() { }

            public Member(string name, string phone, string email, string username, string profileImage, bool isadministrator)
            {
                Name = name;
                Phone = phone;
                Email = email;
                Username = username;
                ProfileImage = profileImage;
                IsAdministrator = isadministrator;
        }
        }
    }
