using HillerodSejlklub.Models;

namespace HillerodSejlklub.Interface
{
    public interface IMember
    {
        public void Add(Member member);
        public void Seed();
        public List<Member> GetAll();
        //public Member Get(int id);
    }
}
