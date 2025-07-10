using System.Collections.Generic;

namespace VillageBankingSystem.Shared.Models
{
    public class LoanRecord
    {
        public required string MemberName { get; set; }
        public List<LoanMonthData> MonthlyData { get; set; } = new List<LoanMonthData>();
    }
}
