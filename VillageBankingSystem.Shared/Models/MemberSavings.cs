using System.Collections.Generic;

namespace VillageBankingSystem.Shared.Models
{
    public class MemberSavings
    {
        public string Name { get; set; }
        public List<SavingsRecord> MonthlySavings { get; set; } = new List<SavingsRecord>();
    }

    public class SavingsRecord
    {
        public string Month { get; set; }
        public decimal Amount { get; set; }
    }
}
