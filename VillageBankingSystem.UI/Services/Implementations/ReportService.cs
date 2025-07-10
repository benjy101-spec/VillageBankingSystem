using System.Collections.Generic;
using System.Linq;
using VillageBankingSystem.Shared.Models;
using VillageBankingSystem.UI.Services.Interfaces;

namespace VillageBankingSystem.UI.Services.Implementations
{
    public class ReportService : IReportService
    {
        public List<InterestShare> CalculateInterestShares(List<Loan> loans, List<MemberSavings> savings)
        {
            decimal totalInterestCollected = loans.Sum(loan =>
                loan.Principal * loan.InterestRate * loan.MonthsPaid);

            decimal totalSavings = savings.Sum(s => s.MonthlySavings.Sum(ms => ms.Amount));

            var interestShares = savings.Select(s => new InterestShare
            {
                Member = s.Name,
                ShareAmount = totalSavings > 0 ? (totalInterestCollected * s.MonthlySavings.Sum(ms => ms.Amount) / totalSavings) : 0
            }).ToList();

            return interestShares;
        }
    }
}