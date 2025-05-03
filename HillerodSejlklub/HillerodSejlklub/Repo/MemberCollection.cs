using HillerodSejlklub.Models;
using HillerodSejlklub.Pages.UserPages;

namespace HillerodSejlklub.Interface
{
    /// <summary>
    /// Represents a collection of members in the Hillerod Sejlklub.
    /// </summary>
    public class MemberCollection : IMember
    {
        /// <summary>
        /// The internal list of members.
        /// </summary>
        private List<Member> _members;

        /// <summary>
        /// Initializes a new instance of the <see cref="MemberCollection"/> class.
        /// </summary>
        public MemberCollection()
        {
            _members = new List<Member>();
        }

        /// <summary>
        /// Adds a new member to the collection.
        /// </summary>
        /// <param name="member">The member to add.</param>
        public void Add(Member member)
        {
            _members.Add(member);
        }

        /// <summary>
        /// Retrieves all members in the collection.
        /// </summary>
        /// <returns>A list of all members.</returns>
        public List<Member> GetAll()
        {
            return _members;
        }
    }
}
