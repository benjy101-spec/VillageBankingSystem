using Microsoft.AspNetCore.Components;
using VillageBankingSystem.UI.Services.Interfaces;
using VillageBankingSystem.UI.Services.Implementations;
using VillageBankingSystem.Shared.Models;

namespace VillageBankingSystem.UI.Pages
{
    public partial class Reports : Microsoft.AspNetCore.Components.ComponentBase
    {
        private List<MemberSavings> _memberSavings = new List<MemberSavings>();
        private List<InterestShare> _interestShares = new List<InterestShare>();

        [Inject]
        public IReportService? ReportService { get; set; }

        protected override void OnInitialized()
        {
            _memberSavings = new List<MemberSavings>();
            _interestShares = new List<InterestShare>();
        }

        public void CalculateInterestShares(List<Loan> loans, List<MemberSavings> savings)
        {
            _interestShares = ReportService!.CalculateInterestShares(loans, savings);
        }
    }
}
