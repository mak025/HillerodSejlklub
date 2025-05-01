
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

            public Member() { }

            public Member(string name, string phone, string email, string username, string profileImage)
            {
                Name = name;
                Phone = phone;
                Email = email;
                Username = username;
                ProfileImage = profileImage;
            }
        }
    }
