using System.Collections.Generic;
using VillageBankingSystem.Shared.Models;

namespace VillageBankingSystem.UI.Services.Interfaces
{
    public interface ISavingsService
    {
        List<MemberSavings> GetMemberSavings();
        void AddOrUpdateSavings(MemberSavings memberSavings);
    }
}
