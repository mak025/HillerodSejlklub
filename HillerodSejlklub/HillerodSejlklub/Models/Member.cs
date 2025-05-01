namespace HillerodSejlklub.Models
{
    public class Member
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public int ID { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ProfileImage { get; set; }


        public Member(string name, string phone, string email, string username, string profileImage)
        {
            Name = name;
            Username = username;
            Phone = phone;
            Email = email;
            ProfileImage = profileImage;
        }
    }
}
