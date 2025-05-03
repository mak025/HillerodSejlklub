
    namespace HillerodSejlklub.Models
    {
    /// <summary>
    /// Represents a member of the Hillerod Sejlklub.
    /// </summary>
    public class Member
    {
        /// <summary>
        /// Gets or sets the unique identifier for the member.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the name of the member.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the username of the member.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the member.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the email address of the member.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the profile image URL or path of the member.
        /// </summary>
        public string ProfileImage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the member is an administrator.
        /// </summary>
        public bool IsAdministrator { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Member"/> class.
        /// </summary>
        public Member() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Member"/> class with specified details.
        /// </summary>
        /// <param name="name">The name of the member.</param>
        /// <param name="phone">The phone number of the member.</param>
        /// <param name="email">The email address of the member.</param>
        /// <param name="username">The username of the member.</param>
        /// <param name="profileImage">The profile image URL or path of the member.</param>
        /// <param name="isadministrator">A value indicating whether the member is an administrator.</param>
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
