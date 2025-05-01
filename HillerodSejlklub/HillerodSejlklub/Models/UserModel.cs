namespace HillerodSejlklub.Model
{
    public class UserModel
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public bool IsAdministrator { get; set; } // Determines if the user is an admin


    }
}
