using System.Collections.Generic;
using System.Linq;
using VillageBankingSystem.Shared.Models;
using VillageBankingSystem.UI.Services.Interfaces;

namespace VillageBankingSystem.UI.Services.Implementations
{
    public class SavingsService : ISavingsService
    {
        private readonly List<MemberSavings> _memberSavings = new List<MemberSavings>();

        public List<MemberSavings> GetMemberSavings()
        {
            return _memberSavings;
        }

        public void AddOrUpdateSavings(MemberSavings memberSavings)
        {
            var existing = _memberSavings.FirstOrDefault(m => m.Name == memberSavings.Name);
            if (existing != null)
            {
                existing.MonthlySavings = memberSavings.MonthlySavings;
            }
            else
            {
                _memberSavings.Add(memberSavings);
            }
        }
    }
}
