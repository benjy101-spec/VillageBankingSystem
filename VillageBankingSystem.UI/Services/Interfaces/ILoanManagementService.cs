using System.Collections.Generic;
using VillageBankingSystem.Shared.Models;

namespace VillageBankingSystem.UI.Services.Interfaces
{
    public interface ILoanManagementService
    {
        List<Loan> GetLoans();
        List<Repayment> GetRepayments();
        void IssueLoan(string member, decimal principal);
        void MakeRepayment(string member, decimal amount);
    }
}
