using HillerodSejlklub.Interface;
using HillerodSejlklub.Models;

namespace HillerodSejlklub.Service
{
    public class MemberService
    {
        private IMember _memberInterface;

        public MemberService(IMember memberInterface)
        {
            _memberInterface = memberInterface;
        }

        public void Add(Member member)
        {
            _memberInterface.Add(member);
        }

        public List<Member> GetAll()
        {
            return _memberInterface.GetAll();
        }
        //public Member Get(int id)
        //{
        //    return _memberInterface.Get(id);
        //}
    }
}
