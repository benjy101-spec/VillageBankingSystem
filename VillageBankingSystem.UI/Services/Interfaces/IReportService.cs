using System.Collections.Generic;
using VillageBankingSystem.Shared.Models;

namespace VillageBankingSystem.UI.Services.Interfaces
{
    public interface IReportService
    {
        List<InterestShare> CalculateInterestShares(List<Loan> loans, List<MemberSavings> savings);
    }
}