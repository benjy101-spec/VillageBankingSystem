using System.Collections.Generic;
using System.Linq;
using VillageBankingSystem.Shared.Models;
using VillageBankingSystem.UI.Services.Interfaces;

namespace VillageBankingSystem.UI.Services.Implementations
{
    public class MemberService : IMemberService
    {
        private readonly List<Member> _members = new List<Member>();

        public List<Member> GetMembers()
        {
            return _members;
        }

        public void AddOrUpdateMember(Member member)
        {
            var existing = _members.FirstOrDefault(m => m.Email == member.Email);
            if (existing != null)
            {
                existing.Name = member.Name;
                existing.Phone = member.Phone;
            }
            else
            {
                _members.Add(member);
            }
        }

        public void DeleteMember(Member member)
        {
            var existing = _members.FirstOrDefault(m => m.Email == member.Email);
            if (existing != null)
            {
                _members.Remove(existing);
            }
        }
    }
}
