namespace HillerodSejlklub.Models
{
    public class Member
    {
        public string Name { get; set; }
        public static int ID { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public Member(string name, string phone, string email)
        {
            Name = name;
            Phone = phone;
            Email = email;
            Member.ID = ID++;
        }
    }
}
