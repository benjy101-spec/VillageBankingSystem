using Microsoft.AspNetCore.Components;
using VillageBankingSystem.UI.Services.Interfaces;
using VillageBankingSystem.UI.Services.Implementations;
using VillageBankingSystem.Shared.Models;

namespace VillageBankingSystem.UI.Pages
{
    public partial class Savings : ComponentBase
    {
        private List<MemberSavings> _members = new List<MemberSavings>();
        private List<Member> _allMembers = new List<Member>();
        private readonly List<string> _months = new List<string>
        {
            "January", "February", "March", "April", "May", "June",
            "July", "August", "September", "October", "November", "December"
        };

        [Inject]
        public ISavingsService? SavingsService { get; set; }

        [Inject]
        public IMemberService? MemberService { get; set; }

        protected override void OnInitialized()
        {
            if (MemberService != null)
            {
                _allMembers = MemberService.GetMembers();
            }

            if (SavingsService != null)
            {
                var savedSavings = SavingsService.GetMemberSavings();

                // Merge members and savings data
                _members = _allMembers.Select(m =>
                {
                    var memberSavings = savedSavings.FirstOrDefault(s => s.Name == m.Name);
                    if (memberSavings == null)
                    {
                        memberSavings = new MemberSavings
                        {
                            Name = m.Name,
                            MonthlySavings = _months.Select(month => new SavingsRecord { Month = month, Amount = 0 }).ToList()
                        };
                    }
                    return memberSavings;
                }).ToList();
            }
            else
            {
                _members = new List<MemberSavings>();
            }
        }

private void OnAmountChanged(MemberSavings member, string month, decimal newAmount)
{
    var monthlySaving = member.MonthlySavings.FirstOrDefault(ms => ms.Month == month);
    if (monthlySaving != null)
    {
        monthlySaving.Amount = newAmount;
    }
}

private EventCallback<decimal> CreateValueChangedCallback(MemberSavings member, string month)
{
    return EventCallback.Factory.Create<decimal>(this, (decimal value) =>
    {
        var monthlySaving = member.MonthlySavings.FirstOrDefault(ms => ms.Month == month);
        if (monthlySaving != null)
        {
            monthlySaving.Amount = value;
        }
    });
}

        private void SaveSavings()
        {
            if (SavingsService != null)
            {
                foreach (var member in _members)
                {
                    SavingsService.AddOrUpdateSavings(member);
                }
            }
        }
    }
}
