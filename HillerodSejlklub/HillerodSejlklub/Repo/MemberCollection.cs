using HillerodSejlklub.Models;
using HillerodSejlklub.Pages.UserPages;

namespace HillerodSejlklub.Interface
{
    public class MemberCollection : IMember
    {
        private List<Member> _members;

        public MemberCollection()
        {
            _members = new List<Member>();
            Seed();
        }

        public void Add(Member member)
        {
            _members.Add(member);
        }

        public void Seed()
        {
            //_members.Add(new Member("Mikkel", "29249283", "Mikkel@mail.com"));
            //_members.Add(new Member("Lucas", "29249383", "Lucas@mail.com"));
            //_members.Add(new Member("Marcus", "29249283", "Marcus@mail.com"));
            //_members.Add(new Member("Christian", "29249283", "Christian@mail.com"));
            //_members.Add(new Member("Magnus", "29249283", "Magnus@mail.com"));
        }

        public List<Member> GetAll()
        {
            return _members;
        }

        //public Member Get(int id)
        //{
        //    foreach (Member member in _members)
        //    {
        //        if (id == Member.ID)
        //        {
        //            return member;
        //        }
        //    }
        //    return null;
        //}
    }
}
