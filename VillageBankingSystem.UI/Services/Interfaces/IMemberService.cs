using System.Collections.Generic;
using VillageBankingSystem.Shared.Models;
using VillageBankingSystem.UI.Pages;

namespace VillageBankingSystem.UI.Services.Interfaces
{
    public interface IMemberService
    {
        List<Member> GetMembers();
        void AddOrUpdateMember(Member member);
        void DeleteMember(Member member);
    }
}
