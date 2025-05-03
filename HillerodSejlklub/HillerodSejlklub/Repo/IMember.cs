using HillerodSejlklub.Models;

namespace HillerodSejlklub.Interface
{
    /// <summary>
    /// Interface for managing members of the Hillerod Sejlklub.
    /// </summary>
    public interface IMember
    {
        /// <summary>
        /// Adds a new member to the repository.
        /// </summary>
        /// <param name="member">The member to add.</param>
        public void Add(Member member);

        /// <summary>
        /// Retrieves all members from the repository.
        /// </summary>
        /// <returns>A list of all members.</returns>
        public List<Member> GetAll();

        // /// <summary>
        // /// Retrieves a member by their unique identifier.
        // /// </summary>
        // /// <param name="id">The unique identifier of the member.</param>
        // /// <returns>The member with the specified ID.</returns>
        // public Member Get(int id);
    }
}
