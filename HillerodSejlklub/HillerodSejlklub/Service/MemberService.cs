using HillerodSejlklub.Interface;
using HillerodSejlklub.Models;

namespace HillerodSejlklub.Service
{
    /// <summary>
    /// Service class for managing members of the Hillerod Sejlklub.
    /// </summary>
    public class MemberService
    {
        private IMember _memberInterface;

        /// <summary>
        /// Initializes a new instance of the <see cref="MemberService"/> class.
        /// </summary>
        /// <param name="memberInterface">The interface for member operations.</param>
        public MemberService(IMember memberInterface)
        {
            _memberInterface = memberInterface;
        }

        /// <summary>
        /// Adds a new member to the system.
        /// </summary>
        /// <param name="member">The member to add.</param>
        public void Add(Member member)
        {
            _memberInterface.Add(member);
        }

        /// <summary>
        /// Retrieves all members from the system.
        /// </summary>
        /// <returns>A list of all members.</returns>
        public List<Member> GetAll()
        {
            return _memberInterface.GetAll();
        }
    }
}
