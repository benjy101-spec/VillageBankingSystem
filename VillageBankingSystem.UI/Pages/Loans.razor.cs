using Microsoft.AspNetCore.Components;
using VillageBankingSystem.UI.Services.Interfaces;
using VillageBankingSystem.UI.Services.Implementations;
using VillageBankingSystem.Shared.Models;

namespace VillageBankingSystem.UI.Pages
{
    public partial class Loans : ComponentBase
    {
        private List<Loan> _loans = new List<Loan>();
        private List<Repayment> _repayments = new List<Repayment>();

        private bool _dialogOpen = false;
        private string? _selectedMember;
        private List<Member> _eligibleMembers = new List<Member>();
        private decimal _loanAmount;
        private bool _canIssueLoan => !string.IsNullOrEmpty(_selectedMember) && _loanAmount > 0;
        private List<string> _months = new List<string>
        {
            "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"
        };

        private string GetPrincipalStyle(Loan loan)
        {
            // Example color coding based on loan principal amount
            if (loan.Principal > 10000)
                return "color: red; font-weight: bold;";
            else if (loan.Principal > 5000)
                return "color: orange;";
            else
                return "color: green;";
        }

        [Inject]
        public ILoanManagementService? LoanManagementService { get; set; }

        [Inject]
        public IMemberService? MemberService { get; set; }

        [Inject]
        public MudBlazor.ISnackbar Snackbar { get; set; } = default!;

        private bool _isProcessing = false;

        protected override async Task OnInitializedAsync()
        {
            if (LoanManagementService != null)
            {
                _loans = LoanManagementService.GetLoans();
                _repayments = LoanManagementService.GetRepayments();
            }
            if (MemberService != null)
            {
                _eligibleMembers = MemberService.GetMembers();
            }
            await base.OnInitializedAsync();
        }

        void OpenIssueLoanDialog()
        {
            _dialogOpen = true;
        }

        void CloseIssueLoanDialog()
        {
            _dialogOpen = false;
            _selectedMember = null;
            _loanAmount = 0;
        }

        async Task ConfirmIssueLoan()
        {
            if (!_canIssueLoan)
            {
                Snackbar.Add("Please select a member and enter a valid loan amount.", MudBlazor.Severity.Error);
                return;
            }

            if (LoanManagementService != null && _selectedMember != null)
            {
                try
                {
                    _isProcessing = true;
                    StateHasChanged();

                    await Task.Run(() => LoanManagementService.IssueLoan(_selectedMember, _loanAmount));
                    _loans = LoanManagementService.GetLoans();
                    _dialogOpen = false;
                    _selectedMember = null;
                    _loanAmount = 0;

                    Snackbar.Add("Loan issued successfully.", MudBlazor.Severity.Success);
                }
                catch (System.Exception ex)
                {
                    Snackbar.Add($"Error issuing loan: {ex.Message}", MudBlazor.Severity.Error);
                }
                finally
                {
                    _isProcessing = false;
                    StateHasChanged();
                }
            }
        }

        List<(decimal BalanceBf, decimal Current, decimal Total)> GetMonthlyBalances(Loan loan)
        {
            // Placeholder logic for monthly balances, can be replaced with real calculations
            var balances = new List<(decimal, decimal, decimal)>();
            decimal balanceBf = loan.Principal;
            for (int i = 0; i < _months.Count; i++)
            {
                decimal current = loan.Principal / _months.Count;
                decimal total = balanceBf - current;
                balances.Add((balanceBf, current, total));
                balanceBf = total;
            }
            return balances;
        }

        void IssueLoan(string member, decimal principal)
        {
            LoanManagementService!.IssueLoan(member, principal);
            _loans = LoanManagementService!.GetLoans();
        }

        void MakeRepayment(string member, decimal amount)
        {
            LoanManagementService!.MakeRepayment(member, amount);
            _loans = LoanManagementService!.GetLoans();
            _repayments = LoanManagementService!.GetRepayments();
        }

        public void ApplyLoan()
        {
            string member = "John Doe"; // Example, should come from a form
            decimal principal = 1000m;  // Example, should come from a form

            IssueLoan(member, principal);

            // Refresh repayments if needed
            _repayments = LoanManagementService!.GetRepayments();

            // Optionally, call StateHasChanged() if you want to force UI update
            StateHasChanged();
        }
    }
}
