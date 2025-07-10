using Microsoft.AspNetCore.Components;
using VillageBankingSystem.UI.Services.Implementations;
using VillageBankingSystem.UI.Services.Interfaces;
using VillageBankingSystem.Shared.Models;
using System.Collections.Generic;

namespace VillageBankingSystem.UI.Pages
{
    public partial class LoanCalculator : ComponentBase
    {
        private List<LoanRecord> _loanRecords = new();

        [Inject]
        public ILoanService? loanService { get; set; }

        protected override void OnInitialized()
        {
            if (loanService != null)
            {
                _loanRecords = loanService.GetLoanProjections();
            }
        }
    }
}
