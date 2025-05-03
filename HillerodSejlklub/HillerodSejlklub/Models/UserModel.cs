namespace HillerodSejlklub.Model
{
    /// <summary>
    /// Represents a user in the system.
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// Gets or sets the username of the user.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the hashed password of the user.
        /// </summary>
        public string PasswordHash { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user is an administrator.
        /// </summary>
        public bool IsAdministrator { get; set; } // Determines if the user is an admin
    }
}
